namespace Api
{
    using System.Text.Json.Serialization;
    using Api.Converter;
    using Api.DataAccess;
    using Api.DataAccess.Repository;
    using Api.DataAccess.Wrapper;
    using Api.ErrorHandling;
    using Api.Hubs;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Models.Car;
    using Newtonsoft.Json;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CarConverter>();
            services.AddSingleton(typeof(Repository<>));
            services.AddSingleton<ErrorHandlingMiddleware>();
            services.AddSingleton<IAssemblyTypeProvider, AssemblyTypeProvider>();
            services.AddSingleton<IEntityProvider, EntityProvider>();

            services.AddSingleton<EntityDbContext>();
            services.AddSingleton<IDataProviderWrapper<CarModel>, CarDataWrapper>();
            services.AddSingleton<CarHub>();

            services.AddControllers();
            services.AddSignalR();

            services.AddMvc()
                .AddNewtonsoftJson(o => o.SerializerSettings.TypeNameHandling = TypeNameHandling.All)
                .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Semantic Data For Frontend Rest API", Version = "v1" });
                //options.SwaggerDoc("v2", new OpenApiInfo { Title = "Tube Technology Rest API ", Version = "v2" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(
                builder => builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<CarHub>("/api/v1/CarHub");
            });

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                //c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2");
            });
        }
    }
}
