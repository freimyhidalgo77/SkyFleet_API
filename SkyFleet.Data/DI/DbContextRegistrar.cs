using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkyFleet.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Data.DI
{
    public static  class DbContextRegistrar
    {
        public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
        {
            services.AddDbContextFactory<SkyFleetContext>(o => o.UseSqlServer("Name=ConStr"));
            return services;
        }

    }
}
