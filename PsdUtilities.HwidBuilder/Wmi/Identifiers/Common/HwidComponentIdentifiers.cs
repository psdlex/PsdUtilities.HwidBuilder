namespace PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;

[System.Flags]
public enum HwidComponentIdentifiers : byte
{
    Bios =          1 << 0,
    Cpu =           1 << 1,
    Mac =           1 << 2,
    Gpu =           1 << 3,
    Motherboard =   1 << 4,
    Ram =           1 << 5,
    DiskDrives =    1 << 6,

    None =          0,
    All =           (1 << 7) - 1
}