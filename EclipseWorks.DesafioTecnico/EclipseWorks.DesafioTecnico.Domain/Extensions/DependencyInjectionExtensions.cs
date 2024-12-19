using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Domain.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUser, AspNetUser>();
            return services;
        }
    }
}
