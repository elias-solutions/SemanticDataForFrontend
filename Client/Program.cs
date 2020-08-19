namespace Client
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        private const string URL = "http://localhost:5000/api/v1/";

        static async Task Main(string[] args)
        {
            var eventService = new EventService(URL, "CarHub");
            await eventService.StartAsync();

            var httpClientService = new HttpClientService(URL);
            await httpClientService.CreateData();

            Console.ReadLine();
        }
    }
}
