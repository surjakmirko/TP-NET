using Servicios;
using DTOs;

namespace WebAPI
{
    public static class ComplejoEndpoints
    {
        public static void MapComplejoEndpoints(this WebApplication app)
        {
            app.MapGet("/complejos", async (IComplejoServicio complejoServicio) =>
            {
                var dto = await complejoServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/complejos/{id}", async (int id, IComplejoServicio complejoServicio) =>
            {
                ComplejoDTO? dto = await complejoServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/complejos", async (ComplejoDTO dto, IComplejoServicio complejoServicio) =>
            {
                try
                {
                    ComplejoDTO complejoDTO = await complejoServicio.AddAsync(dto);

                    return Results.Created($"/complejos/{complejoDTO.Id}", complejoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/complejos", async (ComplejoDTO dto, IComplejoServicio complejoServicio) =>
            {
                try
                {
                    var encontrado = await complejoServicio.UpdateAsync(dto);

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
            app.MapDelete("/complejos/{id}", async (int id, IComplejoServicio complejoServicio) =>
            {
                var deleted = await complejoServicio.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
        }
    }
}
