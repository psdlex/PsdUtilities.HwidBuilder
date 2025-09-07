using System;
using System.Collections.Generic;

namespace PsdUtilities.HwidBuilder.Extensions;

public static class StringExtensions
{
    public static bool Contains(this string source, string value, StringComparison comparison)
        => source.IndexOf(value, comparison) >= 0;

    public static bool ContainsAny(this string source, string[] values, StringComparison comparison)
    {
        foreach (var value in values)
        {
            if (source.Contains(value, comparison))
                return true;
        }

        return false;
    }

    public static string Join<T>(this IEnumerable<T> source, string seperator)
        => string.Join(seperator, source);
}