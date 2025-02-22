namespace Boonkrua.Shared.Extensions;

public static class EnumerableExtensions
{
    public static List<TResult> ToMappedList<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> mapper
    )
    {
        if (source is not ICollection<TSource> collection)
            return [.. source.Select(mapper)];

        var result = new List<TResult>(collection.Count);
        result.AddRange(collection.Select(mapper));
        return result;
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source) =>
        source is null || !source.Any();
}
