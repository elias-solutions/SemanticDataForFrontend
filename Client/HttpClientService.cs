namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    using System.Threading.Tasks;
    using Models.Car;
    using Models.Car.Parameters;
    using Models.Common;

    public class HttpClientService
    {
        private static HttpClient _httpClient;

        public HttpClientService(string url)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(url) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }

        public async Task CreateData()
        {
            var models = CreateCars().ToList();
            foreach (var model in models)
            {
                await _httpClient.PostAsJsonAsync("cars", model);
            }
        }

        private static IEnumerable<CarModel> CreateCars()
        {
            yield return new CarModel(Guid.NewGuid(), CreateCarProperties(350, "991", "Porsche").ToList());
            yield return new CarModel(Guid.NewGuid(), CreateCarProperties(300, "997", "Porsche").ToList());
            yield return new CarModel(Guid.NewGuid(), CreateCarProperties(450, "992", "Porsche").ToList());
        }

        private static IEnumerable<ParameterBase> CreateCarProperties(double value, string model, string brand)
        {
            yield return new Speed(value);
            yield return new Model(model);
            yield return new Brand(brand);
        }
    }
}
