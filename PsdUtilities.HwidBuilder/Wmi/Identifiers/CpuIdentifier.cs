using System.Linq;

using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers;

public sealed class CpuIdentifier : IHwidIdentifier
{
    private const string Win32Processor = "Win32_Processor";
    private const string ProcessorId = "ProcessorId";

    private readonly IWmiManager _wmiManager;

    public CpuIdentifier(IWmiManager wmiManager)
    {
        _wmiManager = wmiManager;
    }

    public HwidComponentIdentifiers Component => HwidComponentIdentifiers.Cpu;

    public string?[] GetIds()
    {
        var cpus = _wmiManager.GetManyWmiProperties(Win32Processor, ProcessorId);

        return cpus
            .Select(cpu => cpu[ProcessorId])
            .ToArray();
    }
}
