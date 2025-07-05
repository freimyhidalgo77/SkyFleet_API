using Microsoft.EntityFrameworkCore;
using SkyFleet.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Data.Context
{
    public class SkyFleetContext : DbContext
    {
        public SkyFleetContext(DbContextOptions<SkyFleetContext> options) : base(options) { }

        public DbSet<TipoVuelo> tipoVuelo { get; set; }

        public DbSet<Rutas> rutas { get; set; }


    }
}
