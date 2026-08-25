using Servicios;
using DTOs;

namespace WebAPI
{
    public static class TipoTurnoEndpoints
    {
        public static void MapTipoTurnoEndpoints(this WebApplication app)
        {
            app.MapGet("/tipos-turno", async (ITipoTurnoServicio TipoTurnoServicio) =>
            {
                var dto = await TipoTurnoServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/tipos-turno/{id}", async (int id, ITipoTurnoServicio TipoTurnoServicio) =>
            {
                TipoTurnoDTO? dto = await TipoTurnoServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

        }
    }
}
