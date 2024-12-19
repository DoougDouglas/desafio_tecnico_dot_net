using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EclipseWorks.DesafioTecnico.Api.Extensions
{
    public static class JsonConvertExtensions
    {
        public static string Serialize<T>(this T item) where T : class
        {
            return JsonConvert.SerializeObject(item, SerializeSettings);
        }

        public static T DeSerialize<T>(this string item) where T : class
        {
            return JsonConvert.DeserializeObject<T>(item, SerializeSettings);
        }

        private static JsonSerializerSettings SerializeSettings => new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
