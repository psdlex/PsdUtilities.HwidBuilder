using System;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers.DiskDrives;

[Flags]
public enum DiskMediaTypes : byte
{
    Unknown =   1 << 0,
    HDD =       1 << 1,
    SSD =       1 << 2,
    Removable = 1 << 3,
    Virtual =   1 << 4,

    None =      0,
    All =       (1 << 5) - 1
}