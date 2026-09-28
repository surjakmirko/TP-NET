using DTOs;
using Servicios;

namespace WebAPI
{
    public static class TurnoEndpoints
    {
        public static void MapTurnoEndpoints(this WebApplication app)
        {
            app.MapGet("/turnos", async (ITurnoServicio turnoServicio) =>
            {
                var dto = await turnoServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/turnos/{id}", async (int id, ITurnoServicio turnoServicio) =>
            {
                TurnoDTO? dto = await turnoServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/turnos", async (TurnoCrearDTO dto, ITurnoServicio turnoServicio) =>
            {
                try
                {
                    TurnoDTO turnoDTO = await turnoServicio.AddAsync(dto);

                    return Results.Created($"/turnos/{turnoDTO.Id}", turnoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/turnos", async (TurnoDTO dto, ITurnoServicio turnoServicio) =>
            {
                try
                {
                    var encontrado = await turnoServicio.UpdateAsync(dto);

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
            app.MapDelete("/turnos/{id}", async (int id, ITurnoServicio turnoServicio) =>
            {
                var deleted = await turnoServicio.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
            app.MapGet("/turnos/cliente/{idCliente}", async (int idCliente, ITurnoServicio turnoServicio) =>
            {
                var turnos = await turnoServicio.ObtenerPorClienteIdAsync(idCliente);

                if (turnos == null || !turnos.Any())
                {
                    return Results.Ok(new List<TurnoDTO>()); // Devuelve lista vacía si no tiene turnos
                }

                return Results.Ok(turnos);
            });
        }
    }
}
