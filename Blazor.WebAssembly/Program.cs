using API;
using API.Client;
using Blazor.WebAssembly;
using Blazor.WebAssembly.Servicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

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

builder.Services.AddScoped<IAutenticacionService, BlazorWasmAuthService>();


await builder.Build().RunAsync();