using Servicios;
using DTOs;

namespace WebAPI
{
    public static class ProvinciaEndpoints
    {
        public static void MapProvinciaEndpoints(this WebApplication app)
        {
            app.MapGet("/provincias", async (IProvinciaServicio ProvinciaServicio) =>
            {
                var dto = await ProvinciaServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/provincias/{id}", async (int id, IProvinciaServicio ProvinciaServicio) =>
            {
                ProvinciaDTO? dto = await ProvinciaServicio.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });
        }
    }
}
