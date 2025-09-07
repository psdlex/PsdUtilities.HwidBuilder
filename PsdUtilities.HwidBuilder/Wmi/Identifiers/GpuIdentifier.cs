using System.Linq;

using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers;

public sealed class GpuIdentifier : IHwidIdentifier
{
    private const string Win32VideoController = "Win32_VideoController";
    private const string PnpDeviceId = "PNPDeviceID";

    private readonly IWmiManager _wmiManager;

    public GpuIdentifier(IWmiManager wmiManager)
    {
        _wmiManager = wmiManager;
    }

    public string ComponentName => HwidComponentIdentifiers.Gpu;

    public string?[] GetIds()
    {
        var gpus = _wmiManager.GetManyWmiProperties(Win32VideoController, PnpDeviceId);

        return gpus
            .Select(gpu => gpu[PnpDeviceId])
            .ToArray();
    }
}