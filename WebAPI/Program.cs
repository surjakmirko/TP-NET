using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Servicios;
using System.Text;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddAuthorization();

var corsPolicy = "AllowBlazorWasm";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy, policy =>
    {
        policy.WithOrigins(
                "https://localhost:7293",
                "http://localhost:5123"
              )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AutenticacionServicio>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AplicacionDbContext>(options =>
    options.UseSqlServer(connectionString));

// Inyección de dependencias (Repositorios y Servicios)
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
builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();
builder.Services.AddScoped<ITurnoServicio, TurnoServicio>();
builder.Services.AddScoped<ITipoTurnoRepositorio, TipoTurnoRepositorio>();
builder.Services.AddScoped<ITipoTurnoServicio, TipoTurnoServicio>();
builder.Services.AddScoped<ILocalidadRepositorio, LocalidadRepositorio>();
builder.Services.AddScoped<ILocalidadServicio, LocalidadServicio>();
builder.Services.AddScoped<IProvinciaRepositorio, ProvinciaRepositorio>();
builder.Services.AddScoped<IProvinciaServicio, ProvinciaServicio>();

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(corsPolicy);
app.UseAuthentication(); 
app.UseAuthorization();

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
app.MapAuthEndpoints();

app.Run();  