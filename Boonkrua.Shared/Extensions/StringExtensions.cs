using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Shared.Extensions;

public static class StringExtensions
{
    public static bool TryParse<TEnum>(this string value, out TEnum result)
        where TEnum : struct, Enum =>
        Enum.TryParse(value, true, out result) && Enum.IsDefined(typeof(TEnum), result);

    public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);

    public static Message ToMessage(this string value) => value;
}
