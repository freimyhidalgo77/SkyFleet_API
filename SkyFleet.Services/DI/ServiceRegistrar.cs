using Microsoft.Extensions.DependencyInjection;
using SkyFleet.Abstraccion;
using SkyFleet.Data.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Services.DI
{
    public static class ServiceRegistrar
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterDbContextFactory();
            services.AddScoped<ITipoVueloService, TipoVueloService>();
            services.AddScoped<IRutasService, RutaSercvice>();
            return services;
        }
    }
}
