using System.Collections.Generic;
using System.Linq;

namespace PsdUtilities.HwidBuilder.Wmi.Manager.Models;

public sealed class WmiPropertyCollection : List<WmiProperty>, IReadOnlyWmiPropertyCollection
{
    public string? this[string propertyName] => this.FirstOrDefault(p => p.Name == propertyName)?.Value;
}