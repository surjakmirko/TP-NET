using Data;
using Servicios;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITipoUsuarioServicio, TipoUsuarioServicio>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection

builder.Services.AddScoped<ITipoUsuarioRepositorio, TipoUsuarioRepositorio>();
builder.Services.AddScoped<ITipoUsuarioServicio, TipoUsuarioServicio>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Map endpoints
app.MapUsuarioEndpoints();
app.MapTipoUsuarioEndpoints();

app.Run();