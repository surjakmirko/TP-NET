using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
{
    public class AplicacionDbContextFactory : IDesignTimeDbContextFactory<AplicacionDbContext>
    {
        public AplicacionDbContext CreateDbContext(string[] args)
        {
            // Apunta directamente a la carpeta de la WebAPI para leer el appsettings.json
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI");

            if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
            {
                basePath = Directory.GetCurrentDirectory();
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AplicacionDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AplicacionDbContext(optionsBuilder.Options);
        }
    }
}