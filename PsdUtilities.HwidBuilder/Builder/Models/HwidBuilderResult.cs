using System;
using System.Collections.Generic;

using PsdUtilities.HwidBuilder.Hashers;
using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;

namespace PsdUtilities.HwidBuilder.Builder.Models;

public sealed class HwidBuilderResult : IHwidBuilderResult
{
    private readonly Dictionary<HwidComponentIdentifiers, string> _hwids;

    private HwidBuilderResult(Dictionary<HwidComponentIdentifiers, string> hwids)
    {
        _hwids = hwids;
    }

    public IReadOnlyDictionary<HwidComponentIdentifiers, string> Hwids => _hwids;

    public byte[] DefaultHash()
        => Hash<DefaultHwidHasher>();

    public byte[] Hash<THasher>()
        where THasher : IHwidHasher, new()
    {
        var hasher = new THasher();

        return hasher.ComputeHash(this);
    }

    internal static HwidBuilderResult Create(Action<Dictionary<HwidComponentIdentifiers, string>> configure)
    {
        var hwids = new Dictionary<HwidComponentIdentifiers, string>();
        configure(hwids);

        return new HwidBuilderResult(hwids);
    }
}
