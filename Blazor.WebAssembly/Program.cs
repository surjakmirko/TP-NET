using API;
using API.Client;
using Blazor.WebAssembly;
using Blazor.WebAssembly.Servicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7016")
});

builder.Services.AddScoped<ComplejoApiClient>();
builder.Services.AddScoped<AutenticacionApi>();
builder.Services.AddScoped<UsuarioApiClient>();
builder.Services.AddScoped<PersonaFisicaApiClient>();
builder.Services.AddScoped<TurnoApiClient>();


// Habilita el sistema de autorización en Blazor
builder.Services.AddAuthorizationCore();

// Registra el proveedor de estado de autenticación (usando tu CustomAuthenticationStateProvider)
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IAutenticacionService, BlazorWasmAuthService>();
builder.Services.AddScoped<BlazorWasmAuthService>();


await builder.Build().RunAsync();