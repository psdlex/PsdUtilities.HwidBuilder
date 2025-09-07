using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using PsdUtilities.HwidBuilder.Wmi.Identifiers;
using PsdUtilities.HwidBuilder.Wmi.Identifiers.Common;
using PsdUtilities.HwidBuilder.Wmi.Identifiers.DiskDrives;
using PsdUtilities.HwidBuilder.Wmi.Identifiers.Ram;
using PsdUtilities.HwidBuilder.Wmi.Manager;

namespace PsdUtilities.HwidBuilder.Builder;

partial class HwidBuilder
{
    private readonly HashSet<IHwidIdentifier> _identifiers;

    public HwidBuilder AddCpuIdentifier()
    {
        _identifiers.Add(new CpuIdentifier(_wmiManager));
        return this;
    }

    public HwidBuilder AddGpuIdentifier()
    {
        _identifiers.Add(new GpuIdentifier(_wmiManager));
        return this;
    }

    public HwidBuilder AddBiosIdentifier()
    {
        _identifiers.Add(new BiosIdentifier(_wmiManager));
        return this;
    }

    public HwidBuilder AddMotherboardIdentifier()
    {
        _identifiers.Add(new MotherboardIdentifier(_wmiManager));
        return this;
    }

    public HwidBuilder AddMacIdentifier() => AddMacIdentifier(nic => nic.OperationalStatus == OperationalStatus.Up);
    public HwidBuilder AddMacIdentifier(MacIdentifier.NicFilter filter)
    {
        _identifiers.Add(new MacIdentifier(filter));
        return this;
    }

    public HwidBuilder AddDiskDrivesIdentifier() => AddDiskDrivesIdentifier(DiskMediaTypes.None);
    public HwidBuilder AddDiskDrivesIdentifier(DiskMediaTypes ignoredTypes)
    {
        _identifiers.Add(new DiskDrivesIdentifier(_wmiManager, ignoredTypes));
        return this;
    }

    public HwidBuilder AddRamIdentifier() => AddRamIdentifier(RamIdentifierPropertyType.SerialNumber);
    public HwidBuilder AddRamIdentifier(RamIdentifierPropertyType propertyType)
    {
        _identifiers.Add(new RamIdentifier(_wmiManager, propertyType));
        return this;
    }

    public HwidBuilder AddCustomIdentifier(IHwidIdentifier identifier)
    {
        _identifiers.Add(identifier);
        return this;
    }

    public HwidBuilder AddCustomIdentifier<TIdentifier>()
        where TIdentifier : IHwidIdentifier, new()
    {
        var identifier = new TIdentifier();
        return AddCustomIdentifier(identifier);
    }

    public HwidBuilder AddCustomIdentifier<TIdentifier>(Func<IWmiManager, TIdentifier> factory)
        where TIdentifier : IHwidIdentifier
    {
        var identifier = factory(_wmiManager);
        return AddCustomIdentifier(identifier);
    }
}