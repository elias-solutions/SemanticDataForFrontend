namespace Client
{
    using System.Net.Http;
    using System.Net.Mime;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class HttpClientExtension
    {
        private static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
        {
            var json = JsonConvert.SerializeObject(value, serializerSettings);
            return client.PostAsync(requestUri, new StringContent(json, Encoding.Unicode, MediaTypeNames.Application.Json));
        }
    }
}
