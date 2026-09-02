using DTOs;
using Servicios;

namespace WebAPI
{
    public static class AutenticacionEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/auth/login", async (LoginDTO request, AutenticacionServicio authServicio) =>
            {
                var resultado = await authServicio.LoginAsync(request);

                if (resultado == null)
                {
                    return Results.Unauthorized();
                }

                return Results.Ok(resultado);
            });
        }
    }
}