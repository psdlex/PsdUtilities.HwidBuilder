using System.Collections.Generic;

using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers.DiskDrives;

public sealed class DiskDrivesIdentifier : IHwidIdentifier
{
    const string Win32DiskDrive = "Win32_DiskDrive";
    const string SerialNumber = "SerialNumber";
    const string Model = "Model";
    const string MediaType = "MediaType";

    private readonly IWmiManager _wmiManager;
    private readonly DiskMediaTypes _ignoredTypes;

    public DiskDrivesIdentifier(IWmiManager wmiManager, DiskMediaTypes ignoredTypes)
    {
        _wmiManager = wmiManager;
        _ignoredTypes = ignoredTypes;
    }

    public HwidComponentIdentifiers Component => HwidComponentIdentifiers.DiskDrives;

    public string?[] GetIds()
    {
        var diskDrives = _wmiManager.GetManyWmiProperties(Win32DiskDrive, SerialNumber, Model, MediaType);
        List<string?> ids = new(diskDrives.Count);

        foreach (var diskDrive in diskDrives)
        {
            var mediaTypeRaw = diskDrive[MediaType];
            var model = diskDrive[Model];

            var mediaType = MediaTypeParser.Parse(mediaTypeRaw, model);

            if (_ignoredTypes.HasFlag(mediaType))
                continue;

            ids.Add(diskDrive[SerialNumber]);
        }

        ids.TrimExcess();
        return ids.ToArray();
    }
}