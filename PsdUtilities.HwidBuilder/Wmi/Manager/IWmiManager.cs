using System.Collections.Generic;

using PsdUtilities.HwidBuilder.Wmi.Manager.Models;

namespace PsdUtilities.HwidBuilder.Wmi.Manager;

public interface IWmiManager
{
    IReadOnlyWmiPropertyCollection GetWmiProperties(string wmiClass, params string[] properties);
    IReadOnlyList<IReadOnlyWmiPropertyCollection> GetManyWmiProperties(string wmiClass, params string[] properties);
}