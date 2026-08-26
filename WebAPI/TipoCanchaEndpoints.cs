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

            app.MapPost("/tipos-cancha", async (TipoCanchaDTO dto, ITipoCanchaServicio TipoCanchaServicio) =>
            {
                try
                {
                    TipoCanchaDTO tipoCanchaDTO = await TipoCanchaServicio.AddAsync(dto);
                    return Results.Created($"/tipos-cancha/{tipoCanchaDTO.Id}", tipoCanchaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/tipos-cancha", async (TipoCanchaDTO dto, ITipoCanchaServicio TipoCanchaServicio) =>
            {
                try
                {
                    var encontrado = await TipoCanchaServicio.UpdateAsync(dto);
                    if (!encontrado)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapDelete("/tipos-cancha/{id}", async (int id, ITipoCanchaServicio TipoCanchaServicio) =>
            {
                var deleted = await TipoCanchaServicio.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
        }
    }
}
