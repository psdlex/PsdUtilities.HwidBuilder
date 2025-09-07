namespace PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;

public interface IHwidIdentifier
{
    string?[] GetIds();
    string ComponentName { get; }
}