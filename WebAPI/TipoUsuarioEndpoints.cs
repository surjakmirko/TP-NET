using Servicios;
using DTOs;

namespace WebAPI
{
    public static class TipoUsuarioEndpoints
    {
        public static void MapTipoUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/tipos-usuario", async (ITipoUsuarioServicio TipoUsuarioServicio) =>
            {
                var dto = await TipoUsuarioServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/tipos-usuario/{id}", async (int id, ITipoUsuarioServicio TipoUsuarioServicio) =>
            {
                TipoUsuarioDTO? dto = await TipoUsuarioServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });
        }
    }
}
