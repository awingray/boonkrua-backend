using System.Text.Json;
using System.Text.Json.Serialization;

namespace Boonkrua.Common.Extensions;

public static class ObjectExtensions
{
    private static readonly JsonSerializerOptions DefaultJsonSerializerOptions =
        new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
        };

    public static string ToJson(this object obj, JsonSerializerOptions? options = null) =>
        JsonSerializer.Serialize(obj, options ?? DefaultJsonSerializerOptions);
}
