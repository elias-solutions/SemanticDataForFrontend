namespace Client
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class HttpContentExtension
    {
        private static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent httpContent)
        {
            var response = await httpContent.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(response, serializerSettings);
        }
    }
}
