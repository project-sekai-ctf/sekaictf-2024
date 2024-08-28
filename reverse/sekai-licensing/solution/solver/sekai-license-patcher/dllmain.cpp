#define PHNT_VERSION PHNT_WIN11

#include <phnt_windows.h>
#include <phnt.h>

#include "framework.h"

#include <json.hpp>
#include <base64.hpp>

#include <lazy_importer/lazy_importer.hpp>
#include <intrin.h>

#include <fstream>
#include <vector>
#include <unordered_map>

// Instruction where .text section start is moved for program hasher. Instructions for finding are in writeup.
constexpr ptrdiff_t hasher_hook_rva = 0x3d488;

uint8_t* cloned_text_section = nullptr;

std::unordered_map<uint64_t, std::vector<std::uint64_t>> cpuid_spoof = {
	{
		0x80000002,
		{
			779510849, 1802063136, 1698963573, 1701013878
		}
	},

	{
		0x80000003,
		{
			1817518195, 543257204, 758266161, 1701998403
		}
	},

	{
		0x80000004,
		{
			1869762592, 1936942435, 538997359, 538976288
		}
	}
};

bool nt_query_system_information_handler(const PEXCEPTION_POINTERS exception) {
	switch (exception->ContextRecord->R10) {
		case SystemBasicInformation: {
			auto* sbi = reinterpret_cast<PSYSTEM_BASIC_INFORMATION>(exception->ContextRecord->Rdx);

			const auto status = LI_FN(NtQuerySystemInformation).nt()(SystemBasicInformation, sbi, exception->ContextRecord->R8, reinterpret_cast<PULONG>(exception->ContextRecord->R9));
			if (!NT_SUCCESS(status))
				return false;

			sbi->NumberOfProcessors = 192;

			exception->ContextRecord->Rax = status;
			exception->ContextRecord->Rip += 2;

			return true;
		}
		case SystemBootEnvironmentInformation: {
			auto* sbei = reinterpret_cast<PSYSTEM_BOOT_ENVIRONMENT_INFORMATION>(exception->ContextRecord->Rdx);

			const auto status = LI_FN(NtQuerySystemInformation).nt()(SystemBootEnvironmentInformation, sbei, exception->ContextRecord->R8, reinterpret_cast<PULONG>(exception->ContextRecord->R9));
			if (!NT_SUCCESS(status))
				return false;

			sbei->FirmwareType = FirmwareTypeBios;

			const uint8_t boot_id[] = {
				0xf3, 0x5d, 0x3c, 0x35, 0xaf, 0xcf, 0xb1, 0x46, 0xeb, 0x6d, 0xab, 0x4f,
				0xe2, 0xe0, 0x0c, 0xc2
			};
			memcpy(&sbei->BootIdentifier, boot_id, sizeof boot_id);

			exception->ContextRecord->Rax = status;
			exception->ContextRecord->Rip += 2;

			return true;
		}
		case SystemKernelDebuggerInformation: {
			auto* kdbg = reinterpret_cast<PSYSTEM_KERNEL_DEBUGGER_INFORMATION>(exception->ContextRecord->Rdx);

			kdbg->KernelDebuggerEnabled = false;
			kdbg->KernelDebuggerNotPresent = true;

			exception->ContextRecord->Rax = STATUS_SUCCESS;
			exception->ContextRecord->Rip += 2;

			return true;
		}
		default: return false;
	}
}

LONG veh_handler(const PEXCEPTION_POINTERS exception) {
	if (exception->ExceptionRecord->ExceptionCode == EXCEPTION_ILLEGAL_INSTRUCTION) {
		switch (const auto address = exception->ExceptionRecord->ExceptionAddress; *static_cast<uint16_t*>(address)) {
			case 0x0b0f: {
				// CPUID

				if (const auto eax = static_cast<uint32_t>(exception->ContextRecord->Rax); cpuid_spoof.contains(eax)) {
					const auto spoofed_values = cpuid_spoof[eax];
					exception->ContextRecord->Rax = spoofed_values[0];
					exception->ContextRecord->Rbx = spoofed_values[1];
					exception->ContextRecord->Rcx = spoofed_values[2];
					exception->ContextRecord->Rdx = spoofed_values[3];
				} else {
					int cpuid[4];
					__cpuid(cpuid, eax);
					exception->ContextRecord->Rax = cpuid[0];
					exception->ContextRecord->Rbx = cpuid[1];
					exception->ContextRecord->Rcx = cpuid[2];
					exception->ContextRecord->Rdx = cpuid[3];
				}
				
				exception->ContextRecord->Rip += 2;

				return EXCEPTION_CONTINUE_EXECUTION;
			}
			case 0xff0f: {
				// Syscall

				if (nt_query_system_information_handler(exception))
					return EXCEPTION_CONTINUE_EXECUTION;

				break;
			}
			case 0xb90f: {
				// Program Hash

				exception->ContextRecord->Rcx = reinterpret_cast<uintptr_t>(cloned_text_section);
				exception->ContextRecord->Rip += 7;

				return EXCEPTION_CONTINUE_EXECUTION;
			}
			default: break;
		}
	}

	return EXCEPTION_CONTINUE_SEARCH;
}

bool write_patch(const uintptr_t address, const uint8_t* patch, const size_t size) {
	DWORD old_protect;
	if (!VirtualProtect(reinterpret_cast<void*>(address), size, PAGE_EXECUTE_READWRITE, &old_protect))
		return false;

	memcpy(reinterpret_cast<void*>(address), patch, size);

	if (!VirtualProtect(reinterpret_cast<void*>(address), size, old_protect, &old_protect))
		return false;

	return true;
}

void handle_patches() {
    AddVectoredExceptionHandler(true, veh_handler);

	std::ifstream fs("offsets.json");
	std::string content((std::istreambuf_iterator(fs)), std::istreambuf_iterator<char>());
	fs.close();

	const auto base_address = reinterpret_cast<uintptr_t>(GetModuleHandleA(nullptr));
	const auto nt_headers = reinterpret_cast<PIMAGE_NT_HEADERS>(base_address + reinterpret_cast<PIMAGE_DOS_HEADER>(base_address)->e_lfanew);
	const auto text_section_header = reinterpret_cast<PIMAGE_SECTION_HEADER>(nt_headers + 1);

	const auto text_section_start = base_address + text_section_header->VirtualAddress;
	const auto text_section_size = text_section_header->Misc.VirtualSize;

	// Clone the text section to bypass program hasher.
	cloned_text_section = new uint8_t[text_section_size];
	memcpy(cloned_text_section, reinterpret_cast<void*>(text_section_start), text_section_size);

	auto json = nlohmann::json::parse(content);

	// Patch CPUIDs for VEH handler.
	for (const auto& offset_json : json["CpuidOffsets"]) {
		const auto address = base_address + offset_json.get<int>();

		constexpr uint8_t patch[] = { 0xf, 0xb }; // UD2
		write_patch(address, patch, sizeof(patch));
	}

	// Patch NtQuerySystemInformation syscalls for VEH handler.
	for (const auto& offset_json : json["SyscallOffsets"]) {
		const auto address = base_address + offset_json.get<int>();

		constexpr uint8_t patch[] = { 0xf, 0xff }; // Invalid sequence
		write_patch(address, patch, sizeof(patch));
	}

	// Perform constant patches
	for (const auto& patch_json : json["Patches"]) {
		const auto offset = base_address + patch_json["Offset"].get<int>();
		const auto patch = base64::from_base64(patch_json["Patch"].get<std::string>());

		write_patch(offset, reinterpret_cast<const uint8_t*>(patch.data()), patch.size());
	}

	// Program hasher hook
    {
		const auto address = base_address + hasher_hook_rva;

		constexpr uint8_t patch[] = { 0xf, 0xb9, 0x90, 0x90, 0x90, 0x90, 0x90 }; // UD1 + NOPs
		write_patch(address, patch, sizeof(patch));
    }
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
    switch (ul_reason_for_call)
    {
	    case DLL_PROCESS_ATTACH:
	        handle_patches();
			break;
	    case DLL_THREAD_ATTACH:
	    case DLL_THREAD_DETACH:
	    case DLL_PROCESS_DETACH:
	        break;
    }

    return TRUE;
}

