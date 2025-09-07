using System.Linq;
using System.Text;

using PsdUtilities.HwidBuilder.Builder.Models;

using BC = BCrypt.Net.BCrypt;

namespace PsdUtilities.HwidBuilder.Hashers;

public sealed class DefaultHwidHasher : IHwidHasher
{
    public static readonly Encoding DefaultEncoding = Encoding.UTF8;

    public byte[] ComputeHash(IHwidBuilderResult result)
    {
        var str = GenerateString(result);
        var hashed = BC.EnhancedHashPassword(str);

        return DefaultEncoding.GetBytes(hashed);
    }

    public bool VerifyHash(IHwidBuilderResult result, byte[] hash)
    {
        var str = GenerateString(result);
        return BC.EnhancedVerify(str, DefaultEncoding.GetString(hash));
    }

    private static string GenerateString(IHwidBuilderResult result)
    {
        return string.Join("-", result.Hwids.Select(kv => $"{kv.Key}:{kv.Value}"));
    }
}