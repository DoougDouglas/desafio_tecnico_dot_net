using EclipseWorks.DesafioTecnico.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorks.DesafioTecnico.Api.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterApiDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddLogging();

            services.AddMvc();
            //.AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //});

            //services.AddScoped<HistoricoAtualizacaoTarefaFilter>();

            //services
            //    //.ConfigureSwaggerRoute()
            //    .ConfigureCors()
            //    .RegisterEntityFrameworkContext(config)
            //    .AddMvcSecurity();

            return services;
        }

        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            return app;
        }



        private static IServiceCollection RegisterEntityFrameworkContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
