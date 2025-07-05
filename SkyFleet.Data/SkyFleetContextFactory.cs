using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SkyFleet.Data.Context;
using System.IO;

namespace SkyFleet.Data
{
    public class SkyFleetContextFactory : IDesignTimeDbContextFactory<SkyFleetContext>
    {
        public SkyFleetContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkyFleetContext>();

            var connectionString = "Server=FREIMYHP\\SQLEXPRESS;Database=SkyFleetDb;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true;";

            optionsBuilder.UseSqlServer(connectionString);

            return new SkyFleetContext(optionsBuilder.Options);
        }
    }


}

