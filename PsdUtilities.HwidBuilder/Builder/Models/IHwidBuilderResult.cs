using System.Collections.Generic;

using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;

namespace PsdUtilities.HwidBuilder.Builder.Models;

public interface IHwidBuilderResult
{
    IReadOnlyDictionary<HwidComponentIdentifiers, string> Hwids { get; }
}