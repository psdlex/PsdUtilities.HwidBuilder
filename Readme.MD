# PsdUtilities.HwidBuilder

## How to use?
```csharp
var result = HwidBuilder.Create()
  .AddCpuIdentifier()
  .AddGpuIdentifier()
  .Build();

var bytes = result.DefaultHash();
```

## How to add custom identifiers if the built-in ones are insufficient
### Case 1
```csharp
public sealed class MyCustomIdentifier : IHwidIdentifier
{
    public string ComponentName => "MyCustomComponentName";

    public string?[] GetIds()
    {
      // custom logic of obtaining ids/serial numbers
      // a collection, because you might have multiple hardwares, alike the case of HDD/SSD, GPU and CPU
    }
}

var identifier = new MyCustomIdentifier();

var result = HwidBuilder.Create()
    .AddCustomIdentifier(identifier)
    .Build();

// OR

var result = HwidBuilder.Create()
    .AddCustomIdentifier<MyCustomIdentifier>() // where MyCustomIdentifier must have an empty constructor
    .Build();
```

### Case 2
#### Need the shared WMI manager? here is the solution:
```csharp
public sealed class MyCustomIdentifier : IHwidIdentifier
{
    private readonly IWmiManager _wmiManager;

    public MyCustomIdentifier(IWmiManager manager)
    {
      _wmiManager = manager;
    }

    public string ComponentName => "MyCustomComponentName";

    public string?[] GetIds()
    {
      // do something with the manager
    }
}

var result = HwidBuilder.Create()
    .AddCustomIdentifier<MyCustomIdentifier>(manager => new MyCustomIdentifier(manager)) // manager is being provided through the delegate object
    .Build();
```
