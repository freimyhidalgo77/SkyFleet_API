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

            var connectionString = "workstation id=freimyDbo.mssql.somee.com;packet size=4096;user id=freimyHidalgo77;pwd=srt10db9;data source=freimyDbo.mssql.somee.com;persist security info=False;initial catalog=freimyDbo;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new SkyFleetContext(optionsBuilder.Options);
        }
    }


}

