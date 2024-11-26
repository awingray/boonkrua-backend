using System;
using System.Collections.Generic;
using System.Linq;

namespace Boonkrua.Shared.Extensions;

public static class EnumerableExtensions
{
    public static List<TResult> ToMappedList<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> mapper
    ) => source?.Select(mapper).ToList() ?? [];

    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source) =>
        source is null || !source.Any();
}
