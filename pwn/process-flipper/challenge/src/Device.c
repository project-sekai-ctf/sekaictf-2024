/*++

Module Name:

    device.c - Device handling events for example driver.

Abstract:

   This file contains the device entry points and callbacks.
    
Environment:

    Kernel-mode Driver Framework

--*/

#include "driver.h"
#include "device.tmh"

#ifdef ALLOC_PRAGMA
#pragma alloc_text (PAGE, ProcessFlipperCreateDevice)
#endif

VOID
ProcessFlipperShutdown(
    WDFDEVICE Device
)
/*++

Routine Description:
    Callback invoked when the machine is shutting down.  If you register for
    a last chance shutdown notification you cannot do the following:
    o Call any pageable routines
    o Access pageable memory
    o Perform any file I/O operations

    If you register for a normal shutdown notification, all of these are
    available to you.

    This function implementation does nothing, but if you had any outstanding
    file handles open, this is where you would close them.

Arguments:
    Device - The device which registered the notification during init

Return Value:
    None

  --*/

{
    UNREFERENCED_PARAMETER(Device);
    return;
}

NTSTATUS
ProcessFlipperCreateDevice(
    _Inout_ PWDFDEVICE_INIT DeviceInit
    )
/*++

Routine Description:

    Worker routine called to create a device and its software resources.

Arguments:

    DeviceInit - Pointer to an opaque init structure. Memory for this
                    structure will be freed by the framework when the WdfDeviceCreate
                    succeeds. So don't access the structure after that point.

Return Value:

    NTSTATUS

--*/
{
    WDF_OBJECT_ATTRIBUTES deviceAttributes;
    WDFDEVICE device;
    NTSTATUS status;

    PAGED_CODE();

    DECLARE_CONST_UNICODE_STRING(DeviceName, DEVICE_NAME);
    DECLARE_CONST_UNICODE_STRING(DosDeviceName, DOS_DEVICE_NAME);

    //
    // Set exclusive to TRUE so that no more than one app can talk to the
    // control device at any time.
    //
    WdfDeviceInitSetExclusive(DeviceInit, TRUE);

    WdfDeviceInitSetIoType(DeviceInit, WdfDeviceIoBuffered);

    status = WdfDeviceInitAssignName(
        DeviceInit,
        &DeviceName
    );
    if (!NT_SUCCESS(status)) {
        //TraceEvents(TRACE_LEVEL_ERROR, TRACE_DRIVER, "WdfDeviceInitAssignName failed %!STATUS!", status);
        goto End;
    }

    WdfControlDeviceInitSetShutdownNotification(DeviceInit,
        ProcessFlipperShutdown,
        WdfDeviceShutdown);

    WDF_OBJECT_ATTRIBUTES_INIT_CONTEXT_TYPE(&deviceAttributes, DEVICE_CONTEXT);

    status = WdfDeviceCreate(&DeviceInit, &deviceAttributes, &device);

    if (!NT_SUCCESS(status)) {
        //TraceEvents(TRACE_LEVEL_ERROR, TRACE_DRIVER, "WdfDeviceCreate failed %!STATUS!", status);
        goto End;
    }

    status = WdfDeviceCreateSymbolicLink(device, &DosDeviceName);

    if (!NT_SUCCESS(status)) {
        //TraceEvents(TRACE_LEVEL_ERROR, TRACE_DRIVER, "WdfDeviceCreateSymbolicLink failed %!STATUS!", status);
        goto End;
    }

    status = ProcessFlipperQueueInitialize(device);

    if (!NT_SUCCESS(status)) {
        goto End;
    }

    WdfControlFinishInitializing(device);

End:
    //
    // If the device is created successfully, framework would clear the
    // DeviceInit value. Otherwise device create must have failed so we
    // should free the memory ourself.
    //
    if (DeviceInit != NULL) {
        WdfDeviceInitFree(DeviceInit);
    }

    return status;
}
