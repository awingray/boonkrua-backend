namespace Boonkrua.Extensions;

public static class StringExtensions
{
    public static bool TryParse<TEnum>(this string value, out TEnum result)
        where TEnum : struct, Enum =>
        Enum.TryParse(value, true, out result) && Enum.IsDefined(typeof(TEnum), result);
}
