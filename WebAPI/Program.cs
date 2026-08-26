using Data;
using Microsoft.EntityFrameworkCore;
using Servicios;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// 1. REGISTRAR EL DBCONTEXT EN EL CONTENEDOR (OBLIGATORIO)
builder.Services.AddDbContext<AplicacionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Dependency Injection

builder.Services.AddScoped<ITipoUsuarioRepositorio, TipoUsuarioRepositorio>();
builder.Services.AddScoped<ITipoUsuarioServicio, TipoUsuarioServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Map endpoints
app.MapUsuarioEndpoints();
app.MapTipoUsuarioEndpoints();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AplicacionDbContext>();
    try
    {
        // CanConnectAsync() evalúa si el motor de SQL Server responde
        bool seConecto = await context.Database.CanConnectAsync();
        if (seConecto)
        {
            Console.WriteLine("¡Conexión exitosa con el servidor de SQL Server!");
        }
        else
        {
            Console.WriteLine("No se pudo conectar al servidor. Revisa tu cadena de conexión.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error grave de conexión: {ex.Message}");
    }
}

app.Run();