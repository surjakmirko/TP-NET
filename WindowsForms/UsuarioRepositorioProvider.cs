using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WindowsForms
{
    public static class UsuarioRepositorioProvider
    {
        private static IUsuarioRepositorio? _instance;

        public static IUsuarioRepositorio Instance
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
                    _instance = new UsuarioRepositorio(dbContext);
                }
                return _instance;
            }
        }
    }
}
