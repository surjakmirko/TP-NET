using Servicios;
using DTOs;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/usuarios", async (IUsuarioServicio usuarioServicio) =>
            {
                var dto = await usuarioServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/{id}", async (int id, IUsuarioServicio usuarioServicio) =>
            {
                UsuarioDTO? dto = await usuarioServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/usuarios", async (UsuarioCrearDTO dto, IUsuarioServicio usuarioServicio) =>
            {
                try
                {
                    UsuarioDTO usuarioDTO = await usuarioServicio.AddAsync(dto);

                    return Results.Created($"/usuarios/{usuarioDTO.Id}", usuarioDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/usuarios", async (UsuarioDTO dto, IUsuarioServicio usuarioServicio) =>
            {
                try
                {
                    var encontrado = await usuarioServicio.UpdateAsync(dto);

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
            app.MapDelete("/usuarios/{id}", async (int id, IUsuarioServicio usuarioServicio) =>
            {
                var deleted = await usuarioServicio.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
            app.MapGet("/usuarios/duenos", async (IUsuarioServicio usuarioServicio) =>
            {
                try
                {
                    var dueños = await usuarioServicio.GetDuenosAsync();
                    return Results.Ok(dueños);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
        }
    }
}