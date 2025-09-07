using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers;

public sealed class MotherboardIdentifier : IHwidIdentifier
{
    private const string Win32BaseBoard = "Win32_BaseBoard";
    private const string SerialNumber = "SerialNumber";

    private readonly IWmiManager _wmiManager;

    public MotherboardIdentifier(IWmiManager wmiManager)
    {
        _wmiManager = wmiManager;
    }

    public string ComponentName => HwidComponentIdentifiers.Motherboard;

    public string?[] GetIds()
    {
        var baseboard = _wmiManager.GetWmiProperties(Win32BaseBoard, SerialNumber);

        return [baseboard[SerialNumber]];
    }
}
