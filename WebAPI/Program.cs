using Data;
using Microsoft.EntityFrameworkCore;
using Servicios;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Lee la conexión del appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AplicacionDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Dependency Injection

builder.Services.AddScoped<ITipoUsuarioRepositorio, TipoUsuarioRepositorio>();
builder.Services.AddScoped<ITipoUsuarioServicio, TipoUsuarioServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IPersonaFisicaRepositorio, PersonaFisicaRepositorio>();
builder.Services.AddScoped<IPersonaFisicaServicio, PersonaFisicaServicio>();
builder.Services.AddScoped<IPersonaJuridicaRepositorio, PersonaJuridicaRepositorio>();
builder.Services.AddScoped<IPersonaJuridicaServicio, PersonaJuridicaServicio>();
builder.Services.AddScoped<IComplejoRepositorio, ComplejoRepositorio>();
builder.Services.AddScoped<IComplejoServicio, ComplejoServicio>();
builder.Services.AddScoped<IHorarioRepositorio, HorarioRepositorio>();
builder.Services.AddScoped<IHorarioServicio, HorarioServicio>();
builder.Services.AddScoped<IPrecioRepositorio, PrecioRepositorio>();
builder.Services.AddScoped<IPrecioServicio, PrecioServicio>();
builder.Services.AddScoped<ICanchaRepositorio, CanchaRepositorio>();
builder.Services.AddScoped<ICanchaServicio, CanchaServicio>();
builder.Services.AddScoped<ITipoCanchaRepositorio, TipoCanchaRepositorio>();
builder.Services.AddScoped<ITipoCanchaServicio, TipoCanchaServicio>();
builder.Services.AddScoped<ITurnoRepositorio,TurnoRepositorio>();
builder.Services.AddScoped<ITurnoServicio,TurnoServicio>();
builder.Services.AddScoped<ITipoTurnoRepositorio, TipoTurnoRepositorio>();
builder.Services.AddScoped<ITipoTurnoServicio, TipoTurnoServicio>();
builder.Services.AddScoped<ILocalidadRepositorio, LocalidadRepositorio>();
builder.Services.AddScoped<ILocalidadServicio, LocalidadServicio>();
builder.Services.AddScoped<IProvinciaRepositorio,ProvinciaRepositorio>();
builder.Services.AddScoped<IProvinciaServicio, ProvinciaServicio>();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Map endpoints
app.MapUsuarioEndpoints();
app.MapTipoUsuarioEndpoints();
app.MapPersonaFisicaEndpoints();
app.MapPersonaJuridicaEndpoints();
app.MapComplejoEndpoints();
app.MapTipoCanchaEndpoints();
app.MapTipoTurnoEndpoints();
app.MapProvinciaEndpoints();
app.MapLocalidadEndpoints();
app.MapTurnoEndpoints();


app.Run();