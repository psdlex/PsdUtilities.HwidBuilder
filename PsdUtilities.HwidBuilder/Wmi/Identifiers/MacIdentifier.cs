using System.Linq;
using System.Net.NetworkInformation;

using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers;

public sealed class MacIdentifier : IHwidIdentifier
{
    public delegate bool NicFilter(NetworkInterface nic);

    private readonly NicFilter _nicFilter;

    public MacIdentifier(NicFilter nicFilter)
    {
        _nicFilter = nicFilter;
    }
    public string ComponentName => HwidComponentIdentifiers.Mac;

    public string?[] GetIds()
    {
        return NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(nic => _nicFilter(nic))
            .Select(nic => nic.GetPhysicalAddress().ToString())
            .ToArray();
    }
}