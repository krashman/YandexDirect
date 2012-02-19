using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yandex.Direct.Serialization
{
    internal sealed class YapiSerializer
    {
        public JsonSerializerSettings JsonSettings { get; private set; }

        public YapiSerializer()
        {
            this.JsonSettings =
                new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        Converters = {new IsoDateTimeConverter {DateTimeFormat = "yyyy-MM-dd"}}
                    };
        }

        public T DeserializeObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, JsonSettings);
        }

        public string SerializeToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, JsonSettings);
        }
    }
}