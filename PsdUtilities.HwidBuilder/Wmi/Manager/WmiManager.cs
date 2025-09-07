using System.Collections.Generic;
using System.Management;

using PsdUtilities.HwidBuilder.Wmi.Manager.Models;

namespace PsdUtilities.HwidBuilder.Wmi.Manager;

public sealed class WmiManager : IWmiManager
{
    public IReadOnlyList<IReadOnlyWmiPropertyCollection> GetManyWmiProperties(string wmiClass, params string[] properties)
    {
        var list = new List<IReadOnlyWmiPropertyCollection>();
        using var searcher = new ManagementObjectSearcher($"SELECT {string.Join(", ", properties)} FROM {wmiClass}");

        foreach (var obj in searcher.Get())
        {
            var collection = new WmiPropertyCollection();

            foreach (var property in properties)
            {
                var wmiProperty = new WmiProperty(property, obj[property]?.ToString());
                collection.Add(wmiProperty);
            }    

            list.Add(collection);
        }

        return list;
    }

    public IReadOnlyWmiPropertyCollection GetWmiProperties(string wmiClass, params string[] properties)
    {
        var collection = new WmiPropertyCollection();
        using var searcher = new ManagementObjectSearcher($"SELECT {string.Join(", ", properties)} FROM {wmiClass}");

        foreach (var obj in searcher.Get())
        {
            foreach (var property in properties)
            {
                var wmiProperty = new WmiProperty(property, obj[property]?.ToString());
                collection.Add(wmiProperty);
            }

            break;
        }

        return collection;
    }
}