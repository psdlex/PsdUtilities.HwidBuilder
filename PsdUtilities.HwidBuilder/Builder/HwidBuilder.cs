using PsdUtilities.HwidBuilder.Builder.Models;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Builder;

public sealed partial class HwidBuilder
{
    private readonly HwidBuilderOptions _hwidBuilderOptions;
    private readonly IWmiManager _wmiManager;

    private HwidBuilder(HwidBuilderOptions hwidBuilderOptions)
    {
        _hwidBuilderOptions = hwidBuilderOptions;
        _wmiManager = new WmiManager();
        _identifiers = [];
    }

    public static HwidBuilder Create() => new(HwidBuilderOptions.Default);
    public static HwidBuilder Create(HwidBuilderOptions hwidBuilderOptions) => new(hwidBuilderOptions);
}