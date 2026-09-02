using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    public static class LocalidadRepositorioProvider
    {
        private static ILocalidadRepositorio? _instance;

        public static ILocalidadRepositorio Instance
        {
            get
            {
                if (_instance == null)
                {
                    IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();
                    string connectionString = config.GetConnectionString("DefaultConnection")
                        ?? config["ConnectionStrings:DefaultConnection"];
                    var optionsBuilder = new DbContextOptionsBuilder<AplicacionDbContext>();
                    optionsBuilder.UseSqlServer(connectionString);
                    var dbContext = new AplicacionDbContext(optionsBuilder.Options);
                    _instance = new LocalidadRepositorio(dbContext);
                }
                return _instance;
            }
        }
    }
}
