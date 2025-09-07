namespace PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;

public interface IHwidIdentifier
{
    string?[] GetIds();
    HwidComponentIdentifiers Component { get; }
}