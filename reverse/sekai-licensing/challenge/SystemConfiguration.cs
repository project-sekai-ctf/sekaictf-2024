namespace license_server;

public class SystemConfiguration
{
    public byte NumberOfProcessors { get; set; }
    public uint FirmwareType { get; set; }
    public byte[] BootGuid { get; set; } = new byte[16];
    public uint NtMinorVersion { get; set; }
    public uint NtMajorVersion { get; set; }
    public uint NtBuildNumber { get; set; }
    public uint[] CpuBrandString1 { get; set; } = new uint[4];
    public uint[] CpuBrandString2 { get; set; } = new uint[4];
    public uint[] CpuBrandString3 { get; set; } = new uint[4];
    public ulong ImageBaseAddress { get; set; }
}