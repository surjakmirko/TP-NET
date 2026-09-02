using Microsoft.AspNetCore.Identity.Data;
using Servicios;

namespace WebAPI
{
    public static class AutenticacionEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/auth/login", async (LoginRequest request, IConfiguration configuration) =>
            {
                //try
                //{
                //    var authService = new AutenticacionServicio(configuration);
                //    var response = await authService.LoginAsync(request);

                //    if (response == null)
                //    {
                //        return Results.Unauthorized();
                //    }

                //    return Results.Ok(response);
                //}
                //catch (Exception ex)
                //{
                //    return Results.Problem($"Error durante el login: {ex.Message}");
                //}
            });
        }
    }
}
