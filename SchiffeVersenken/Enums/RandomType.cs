using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SchiffeVersenken.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RandomType
    {
        uint8,
        uint16,
        hex16
    }
}
