#include <Windows.h>
#include <iostream>

void dll_inject(const HANDLE process_handle, const wchar_t* dll_path) {
	// Inject DLL into process
	const auto dll_path_size = (wcslen(dll_path) + 1) * sizeof(wchar_t);
	const auto load_library_address = GetProcAddress(GetModuleHandle(L"kernel32.dll"), "LoadLibraryW");
	const auto remote_dll_path = VirtualAllocEx(process_handle, nullptr, dll_path_size, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
	WriteProcessMemory(process_handle, remote_dll_path, dll_path, dll_path_size, nullptr);
	const auto thread_handle = CreateRemoteThread(process_handle, nullptr, 0, reinterpret_cast<LPTHREAD_START_ROUTINE>(load_library_address), remote_dll_path, 0, nullptr);
	WaitForSingleObject(thread_handle, INFINITE);
	CloseHandle(process_handle);
}

int main() {
	// Correct license key.
	const std::wstring command_line = L"sekai-licensing.exe 21D4BA14519138F6E0FE409C6EE31EC59496E4DE18F17FD4949306FA7FE5CE79";

	STARTUPINFOW si{ sizeof(si)};
	PROCESS_INFORMATION pi{};
	if (!CreateProcessW(L"sekai-licensing.exe", const_cast<wchar_t*>(command_line.c_str()), NULL, NULL, FALSE, CREATE_SUSPENDED, NULL, NULL, &si, &pi)) {
		printf("Failed to create process\n");
		return -1;
	}

	dll_inject(pi.hProcess, L"sekai-license-patcher.dll");

	ResumeThread(pi.hThread);
}