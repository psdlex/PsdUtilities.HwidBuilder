using PsdUtilities.HwidBuilder.Builder.Models;

namespace PsdUtilities.HwidBuilder.Hashers;

public interface IHwidHasher
{
    byte[] ComputeHash(IHwidBuilderResult result);
    bool VerifyHash(IHwidBuilderResult result, byte[] hash);
}