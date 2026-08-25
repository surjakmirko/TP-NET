using Servicios;
using DTOs;

namespace WebAPI
{
    public static class LocalidadEndpoints
    {
        public static void MapLocalidadEndpoints(this WebApplication app)
        {
            app.MapGet("/localidades", async (ILocalidadServicio LocalidadServicio) =>
            {
                var dto = await LocalidadServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/localidades/{id}", async (int id, ILocalidadServicio LocalidadServicio) =>
            {
                LocalidadDTO? dto = await LocalidadServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });
        }
    }
}
