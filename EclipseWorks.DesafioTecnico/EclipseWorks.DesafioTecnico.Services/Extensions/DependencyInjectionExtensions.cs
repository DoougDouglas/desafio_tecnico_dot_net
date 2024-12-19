using EclipseWorks.DesafioTecnico.Services.Validators.Projetos;
using EclipseWorks.DesafioTecnico.Services.Validators.Tarefas;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.DesafioTecnico.Services.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterBusinessDependencies(this IServiceCollection services)
        {
            RegisterMediatorDependencies(services);

            services.AddScoped<IDomainNotificationAppService, DomainNotificationAppService>();

            services.AddTransient<AdicionarProjetoValidator>();
            services.AddTransient<RemoverProjetoValidator>();

            services.AddTransient<AtualizarTarefaValidator>();
            services.AddTransient<AdicionarTarefaValidator>();
            services.AddTransient<RemoverTarefaValidator>();
            services.AddTransient<AdicionarComentarioTarefaValidator>();

            return services;
        }

        private static void RegisterMediatorDependencies(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly));
        }
    }
}
