using System;
using System.Linq;

using PsdUtilities.HwidBuilder.Builder.Models;
using PsdUtilities.HwidBuilder.Extensions;

namespace PsdUtilities.HwidBuilder.Builder;

partial class HwidBuilder
{
    public HwidBuilderResult Build()
    {
        var result = HwidBuilderResult.Create(dic =>
        {
            foreach (var identifier in _identifiers)
            {
                var ids = identifier.GetIds();

                Func<string?, bool> predicate = _hwidBuilderOptions.IgnoreEmptyIds
                    ? static id => !string.IsNullOrWhiteSpace(id)
                    : static id => true;

                var joined = ids
                    .Where(predicate)
                    .Join(_hwidBuilderOptions.Seperator);

                dic.Add(identifier.ComponentName, joined);
            }
        });

        return result;
    }
}