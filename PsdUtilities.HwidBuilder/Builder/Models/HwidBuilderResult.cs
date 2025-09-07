using System;
using System.Collections.Generic;

using PsdUtilities.HwidBuilder.Hashers;

namespace PsdUtilities.HwidBuilder.Builder.Models;

public sealed class HwidBuilderResult : IHwidBuilderResult
{
    private readonly Dictionary<string, string> _hwids;

    private HwidBuilderResult(Dictionary<string, string> hwids)
    {
        _hwids = hwids;
    }

    public IReadOnlyDictionary<string, string> Hwids => _hwids;

    public byte[] DefaultHash()
        => Hash<DefaultHwidHasher>();

    public byte[] Hash<THasher>()
        where THasher : IHwidHasher, new()
    {
        var hasher = new THasher();

        return hasher.ComputeHash(this);
    }

    internal static HwidBuilderResult Create(Action<Dictionary<string, string>> configure)
    {
        var hwids = new Dictionary<string, string>();
        configure(hwids);

        return new HwidBuilderResult(hwids);
    }
}
