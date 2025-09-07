using System.Collections.Generic;

namespace PsdUtilities.HwidBuilder.Wmi.Manager.Models;

public interface IReadOnlyWmiPropertyCollection : IReadOnlyList<WmiProperty>
{
    string? this[string propertyName] { get; }
}