using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers;

public sealed class BiosIdentifier : IHwidIdentifier
{
    private const string Win32Bios = "Win32_BIOS";
    private const string SerialNumber = "SerialNumber";

    private readonly IWmiManager _wmiManager;

    public BiosIdentifier(IWmiManager wmiManager)
    {
        _wmiManager = wmiManager;
    }

    public string ComponentName => HwidComponentIdentifiers.Bios;

    public string?[] GetIds()
    {
        var bios = _wmiManager.GetWmiProperties(Win32Bios, SerialNumber);

        return [bios[SerialNumber]];
    }
}
