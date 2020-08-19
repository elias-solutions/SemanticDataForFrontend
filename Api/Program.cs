namespace Api
{
    using Api.Hubs;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ResolveInstancesSignalR(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://0.0.0.0:5000");
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                });
        }


        private static void ResolveInstancesSignalR(IHost host)
        {
            _ = host.Services.GetService<CarHub>();
        }
    }
}
