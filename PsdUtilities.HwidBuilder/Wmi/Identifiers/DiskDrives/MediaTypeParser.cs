using System;

using PsdUtilities.HwidBuilder.Extensions;

namespace PsdUtilities.HwidBuilder.Wmi.Identifiers.DiskDrives;

internal static class MediaTypeParser
{
    public static DiskMediaTypes Parse(string? mediaTypeRaw, string? model)
    {
        if (string.IsNullOrWhiteSpace(mediaTypeRaw) && string.IsNullOrWhiteSpace(model))
            return DiskMediaTypes.Unknown;

        if (string.IsNullOrWhiteSpace(mediaTypeRaw) == false)
        {
            if (mediaTypeRaw!.Contains("Removable", StringComparison.OrdinalIgnoreCase))
                return DiskMediaTypes.Removable;

            if (mediaTypeRaw!.Contains("Fixed", StringComparison.OrdinalIgnoreCase) &&
                string.IsNullOrWhiteSpace(model) == false)
            {
                return model!.Contains("SSD", StringComparison.OrdinalIgnoreCase)
                    ? DiskMediaTypes.SSD
                    : DiskMediaTypes.HDD;
            }
        }

        if (string.IsNullOrWhiteSpace(model))
            return DiskMediaTypes.Unknown;

        if (model!.Contains("SSD", StringComparison.OrdinalIgnoreCase))
            return DiskMediaTypes.SSD;

        if (model!.Contains("HDD", StringComparison.OrdinalIgnoreCase))
            return DiskMediaTypes.HDD;

        if (model!.ContainsAny(["Virtual", "VBOX", "VMware"], StringComparison.OrdinalIgnoreCase))
            return DiskMediaTypes.Virtual;

        return DiskMediaTypes.Unknown;
    }
}