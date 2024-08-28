/*++

Module Name:

    public.h

Abstract:

    This module contains the common declarations shared by driver
    and user applications.

Environment:

    user and kernel

--*/

//
// Define an Interface Guid so that apps can find the device and talk to it.
//

DEFINE_GUID (GUID_DEVINTERFACE_ProcessFlipper,
    0x8cfb195a,0xedad,0x4817,0xa6,0xf5,0x6a,0x5f,0xcc,0x44,0x43,0xde);
// {8cfb195a-edad-4817-a6f5-6a5fcc4443de}

#define DEVICE_NAME  L"\\Device\\ProcessFlipper"
#define DOS_DEVICE_NAME  L"\\DosDevices\\ProcessFlipper"

#define IOCTL_PROCESS_FLIP CTL_CODE(FILE_DEVICE_UNKNOWN, 0x800, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_PROCESS_SET CTL_CODE(FILE_DEVICE_UNKNOWN, 0x801, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_PROCESS_CLEAR CTL_CODE(FILE_DEVICE_UNKNOWN, 0x802, METHOD_BUFFERED, FILE_ANY_ACCESS)
