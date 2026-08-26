using DTOs;
using Servicios;

namespace WebAPI
{
    public static class TipoCanchaEndpoints
    {
        public static void MapTipoCanchaEndpoints(this WebApplication app)
        {
            app.MapGet("/tipos-cancha", async (ITipoCanchaServicio TipoCanchaServicio) =>
            {
                var dto = await TipoCanchaServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/tipos-cancha/{id}", async (int id, ITipoCanchaServicio TipoCanchaServicio) =>
            {
                TipoCanchaDTO? dto = await TipoCanchaServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

       
        }
    }
}
