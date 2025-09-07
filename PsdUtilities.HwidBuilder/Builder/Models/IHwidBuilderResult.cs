using System.Collections.Generic;

namespace PsdUtilities.HwidBuilder.Builder.Models;

public interface IHwidBuilderResult
{
    IReadOnlyDictionary<string, string> Hwids { get; }
}