using PsdUtilities.HwidBuilder.Builder;
using PsdUtilities.HwidBuilder.Hashers;

var hwid = HwidBuilder.Create()
    .AddCpuIdentifier()
    .AddDiskDrivesIdentifier()
    .AddGpuIdentifier()
    .AddBiosIdentifier()
    .AddRamIdentifier()
    .AddGpuIdentifier()
    .Build();

var defaultHasher = new DefaultHwidHasher();
var hash = defaultHasher.ComputeHash(hwid);
var hashString = DefaultHwidHasher.DefaultEncoding.GetString(hash);
var isEqual = defaultHasher.VerifyHash(hwid, hash);

Console.WriteLine($"""
    Hash: {hashString}
    Is Equal: {isEqual}
    """);