using EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Repository.Projetos;
using EclipseWorks.DesafioTecnico.Repository.Tarefas;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Repository.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterRepositoryDependencies(this IServiceCollection services)
        {
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<IProjetoRepository, ProjetoRepository>();
            //services.AddTransient<IMetricaProjetoRepository, MetricaProjetoRepository>();

            return services;
        }
    }
}
