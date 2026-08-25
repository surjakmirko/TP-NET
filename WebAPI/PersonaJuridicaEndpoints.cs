using Servicios;
using DTOs;

namespace WebAPI
{
    public static class PersonaJuridicaEndpoints
    {
        public static void MapPersonaJuridicaEndpoints(this WebApplication app)
        {
            app.MapGet("/personasjuridicas", async (IPersonaJuridicaServicio personaJuridicaServicio) =>
            {
                var dto = await personaJuridicaServicio.GetAllAsync();
                return Results.Ok(dto);
            });

            app.MapGet("/personasjuridicas/{cuit}", async (string cuit, IPersonaJuridicaServicio personaJuridicaServicio) =>
            {
                PersonaJuridicaDTO? dto = await personaJuridicaServicio.GetAsync(cuit);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/personasjuridicas", async (PersonaJuridicaDTO dto, IPersonaJuridicaServicio personaJuridicaServicio) =>
            {
                try
                {
                    PersonaJuridicaDTO personaJuridicaDTO = await personaJuridicaServicio.AddAsync(dto);
                    return Results.Created($"/personasjuridicas/{personaJuridicaDTO.Cuit}", personaJuridicaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/personasjuridicas", async (PersonaJuridicaDTO dto, IPersonaJuridicaServicio personaJuridicaServicio) =>
            {
                try
                {
                    var encontrado = await personaJuridicaServicio.UpdateAsync(dto);
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
            app.MapDelete("/personasjuridicas/{cuit}", async (string cuit, IPersonaJuridicaServicio personaJuridicaServicio) =>
            {
                var deleted = await personaJuridicaServicio.DeleteAsync(cuit);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
        }
    }
}