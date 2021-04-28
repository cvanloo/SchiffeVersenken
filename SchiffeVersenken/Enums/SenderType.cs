using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SchiffeVersenken.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SenderType
    {
        User,
        Enemy,
        Info
    }
}
