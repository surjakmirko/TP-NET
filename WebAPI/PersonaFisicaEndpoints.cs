using DTOs;
using Servicios;

namespace WebAPI
{
    public static class PersonaFisicaEndpoints
    {
        public static void MapPersonaFisicaEndpoints(this WebApplication app)
        {
            app.MapGet("/personasfisicas", async (IPersonaFisicaServicio personaFisicaServicio) =>
            {
                var dto = await personaFisicaServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/personasfisicas/{dni}", async (string dni, IPersonaFisicaServicio personaFisicaServicio) =>
            {
                PersonaFisicaDTO? dto = await personaFisicaServicio.GetAsync(dni);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/personasfisicas", async (PersonaFisicaDTO dto, IPersonaFisicaServicio personaFisicaServicio) =>
            {
                try
                {
                    PersonaFisicaDTO personaFisicaDTO = await personaFisicaServicio.AddAsync(dto);
                    return Results.Created($"/personasfisicas/{personaFisicaDTO.Dni}", personaFisicaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/personasfisicas", async (PersonaFisicaDTO dto, IPersonaFisicaServicio personaFisicaServicio) =>
            {
                try
                {
                    var encontrado = await personaFisicaServicio.UpdateAsync(dto);
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
            app.MapDelete("/personasfisicas/{dni}", async (string dni, IPersonaFisicaServicio personaFisicaServicio) =>
            {
                var deleted = await personaFisicaServicio.DeleteAsync(dni);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
        }
    }
}