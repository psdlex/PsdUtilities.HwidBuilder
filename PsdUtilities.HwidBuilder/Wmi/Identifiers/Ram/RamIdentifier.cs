using System;
using System.Linq;

using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers.Ram;

public sealed class RamIdentifier : IHwidIdentifier
{
    private const string Win32PhysicalMemory = "Win32_PhysicalMemory";
    private const string SerialNumber = "SerialNumber";
    private const string PartNumber = "PartNumber";

    private readonly IWmiManager _wmiManager;
    private readonly RamIdentifierPropertyType _ramIdentifierPropertyType;

    public RamIdentifier(IWmiManager wmiManager, RamIdentifierPropertyType ramIdentifierPropertyType)
    {
        _wmiManager = wmiManager;
        _ramIdentifierPropertyType = ramIdentifierPropertyType;
    }

    public string ComponentName => HwidComponentIdentifiers.Ram;

    public string?[] GetIds()
    {
        var rams = _wmiManager.GetManyWmiProperties(Win32PhysicalMemory, SerialNumber, PartNumber);
        var idenfifierProperty = _ramIdentifierPropertyType switch
        {
            RamIdentifierPropertyType.SerialNumber => SerialNumber,
            RamIdentifierPropertyType.PartNumber => PartNumber,
            _ => throw new ArgumentException("Invalid identifier property type", nameof(_ramIdentifierPropertyType))
        };

        return rams
            .Select(ram => ram[idenfifierProperty])
            .ToArray();
    }
}