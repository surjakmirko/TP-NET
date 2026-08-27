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
builder.Services.AddScoped<IPersonaFisicaRepositorio, PersonaFisicaRepositorio>();
builder.Services.AddScoped<IPersonaFisicaServicio, PersonaFisicaServicio>();
builder.Services.AddScoped<IPersonaJuridicaRepositorio, PersonaJuridicaRepositorio>();
builder.Services.AddScoped<IPersonaJuridicaServicio, PersonaJuridicaServicio>();
builder.Services.AddScoped<IComplejoRepositorio, ComplejoRepositorio>();
builder.Services.AddScoped<IComplejoServicio, ComplejoServicio>();
builder.Services.AddScoped<IHorarioRepositorio, HorarioRepositorio>();
builder.Services.AddScoped<IHorarioServicio, HorarioServicio>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Map endpoints
app.MapUsuarioEndpoints();
app.MapTipoUsuarioEndpoints();
app.MapPersonaFisicaEndpoints();
app.MapPersonaJuridicaEndpoints();
app.MapComplejoEndpoints();



app.Run();