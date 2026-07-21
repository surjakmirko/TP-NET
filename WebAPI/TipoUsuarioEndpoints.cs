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

            app.MapPost("/tipos-usuario", async (TipoUsuarioDTO dto, ITipoUsuarioServicio TipoUsuarioServicio) =>
            {
                try
                {
                    TipoUsuarioDTO tipoUsarioDTO = await TipoUsuarioServicio.AddAsync(dto);

                    return Results.Created($"/tipos-usuario/{tipoUsarioDTO.Id}", tipoUsarioDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/tipos-usuario", async (TipoUsuarioDTO dto, ITipoUsuarioServicio TipoUsuarioServicio) =>
            {
                try
                {
                    var encontrado = await TipoUsuarioServicio.UpdateAsync(dto);

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
            app.MapDelete("/tipos-usuario/{id}", async (int id, ITipoUsuarioServicio TipoUsuarioServicio) =>
            {
                var deleted = await TipoUsuarioServicio.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
        }
    }
}
