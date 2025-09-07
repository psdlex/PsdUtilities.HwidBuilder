namespace PsdUtilities.HwidBuilder.Builder.Models;

public sealed record HwidBuilderOptions
{
    public string Seperator { get; init; } = "|";
    public bool IgnoreEmptyIds { get; init; } = true;

    public static readonly HwidBuilderOptions Default = new();
}