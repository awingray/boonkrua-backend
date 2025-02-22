namespace Boonkrua.Shared.Extensions;

public static class EnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source) =>
        source is null || !source.Any();
}
