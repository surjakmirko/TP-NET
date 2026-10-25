using DTOs;
using Modelo.Dominio;
using Servicios;
using System.IO;

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

            app.MapGet("/complejos/dueno/{idDueno}", async (int idDueno, IComplejoServicio complejoServicio) =>
            {
                var dto = await complejoServicio.GetByDuenoAsync(idDueno);
                if (dto == null || dto.Count() == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            });

            app.MapGet("/complejos/encargado/{idEncargado}", async (int idEncargado, IComplejoServicio complejoServicio) =>
            {
                var dto = await complejoServicio.GetByEncargadoAsync(idEncargado);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            });

            app.MapGet("/complejos/ranking-localidades", async (IComplejoServicio complejoServicio) =>
            {
                var ranking = await complejoServicio.GetRankingLocalidadesAsync();
                return Results.Ok(ranking);
            });

            app.MapPost("/complejos", async (ComplejoCrearDTO dto, IComplejoServicio complejoServicio) =>
            {
                Console.WriteLine(dto);
                try
                {
                    ComplejoDTO complejoDTO = await complejoServicio.AddAsync(dto);

                    return Results.Created($"/complejos/{complejoDTO.Id}", complejoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapPost("/complejos/{id}/imagen", async (int id, IFormFile imagen, IComplejoServicio complejoServicio) =>
            {
                try
                {
                    if (imagen == null || imagen.Length == 0)
                    {
                        return Results.BadRequest(new { error = "No se envió ninguna imagen" });
                    }

                    // Validar tipo de archivo
                    var allowedTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/webp" };
                    if (!allowedTypes.Contains(imagen.ContentType.ToLower()))
                    {
                        return Results.BadRequest(new { error = "Formato de imagen no permitido. Use JPG, PNG o WebP." });
                    }

                    // Validar tamaño (2MB max)
                    if (imagen.Length > 2 * 1024 * 1024)
                    {
                        return Results.BadRequest(new { error = "La imagen no puede superar 2MB" });
                    }

                    // Verificar que el complejo existe
                    var complejo = await complejoServicio.GetAsync(id);
                    if (complejo == null)
                    {
                        return Results.NotFound(new { error = "Complejo no encontrado" });
                    }

                    // Generar nombre único
                    var extension = Path.GetExtension(imagen.FileName).ToLower();
                    var fileName = $"complejo-{id}-{Guid.NewGuid()}{extension}";
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "complejos");

                    // Crear directorio si no existe
                    Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, fileName);

                    // Guardar archivo
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imagen.CopyToAsync(stream);
                    }

                    // URL pública
                    var imagenUrl = $"/images/complejos/{fileName}";

                    complejo.ImagenUrl = imagenUrl;
                    await complejoServicio.UpdateAsync(complejo);

                    return Results.Ok(new { imagenUrl });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).DisableAntiforgery();

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

            //HORARIOS

            app.MapGet("/complejos/{idComplejo}/horarios", async (int idComplejo, IHorarioServicio horarioServicio) =>
            {
                var horarios = await horarioServicio.GetAllAsync(idComplejo);
                return Results.Ok(horarios);
            });

            app.MapGet("/complejos/{idComplejo}/horarios/{numDia}", async (int idComplejo, int numDia, IHorarioServicio horarioServicio) =>
            {
                HorarioDTO? dto = await horarioServicio.GetAsync(idComplejo, numDia);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/complejos/{idComplejo}/horarios", async (int idComplejo, HorarioCrearDTO dto, IHorarioServicio horarioServicio) =>
            {
                try
                {
                    HorarioDTO horarioDTO = await horarioServicio.AddAsync(dto, idComplejo);
                    return Results.Created($"/complejos/{idComplejo}/horarios/{horarioDTO.NroDia}", horarioDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapPut("/complejos/{idComplejo}/horarios/{numDia}", async (int idComplejo, int numDia, HorarioEditarDTO dto, IHorarioServicio horarioServicio) =>
            {
                try
                {
                    var encontrado = await horarioServicio.UpdateAsync(dto, idComplejo, numDia);

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

            app.MapDelete("/complejos/{idComplejo}/horarios/{numDia}", async (int idComplejo, int numDia, IHorarioServicio horarioServicio) =>
            {
                var deleted = await horarioServicio.DeleteAsync(idComplejo, numDia);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });

            //CANCHAS

            app.MapGet("/complejos/{idComplejo}/canchas", async (int idComplejo, ICanchaServicio canchaServicio) =>
            {
                var canchas = await canchaServicio.GetAllAsync(idComplejo);
                return Results.Ok(canchas);
            });

            app.MapGet("/complejos/{idComplejo}/canchas/{nro}", async (int idComplejo, int nro, ICanchaServicio canchaServicio) =>
            {
                CanchaDTO? dto = await canchaServicio.GetAsync(idComplejo, nro);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/complejos/{idComplejo}/canchas", async (int idComplejo, CanchaCrearDTO dto, ICanchaServicio canchaServicio) =>
            {
                try
                {
                    CanchaDTO canchaDTO = await canchaServicio.AddAsync(dto, idComplejo);
                    return Results.Created($"/complejos/{idComplejo}/canchas/{canchaDTO.Nro}", canchaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapPut("/complejos/{idComplejo}/canchas/{nro}", async (int idComplejo, int nro, CanchaCrearDTO dto, ICanchaServicio canchaServicio) =>
            {
                try
                {
                    var encontrado = await canchaServicio.UpdateAsync(dto, idComplejo, nro);

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

            app.MapPatch("/complejos/{idComplejo}/canchas/{nro}/inactivar", async (int idComplejo, int nro, ICanchaServicio canchaServicio) =>
            {
                var inactivada = await canchaServicio.InactivoAsync(idComplejo, nro);

                if (!inactivada)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });

            app.MapDelete("/complejos/{idComplejo}/canchas/{nro}", async (int idComplejo, int nro, ICanchaServicio canchaServicio) =>
            {
                var deleted = await canchaServicio.DeleteAsync(idComplejo, nro);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });

            //Precios

            app.MapGet("/complejos/{idComplejo}/canchas/{nroCancha}/precios", async (int idComplejo, int nroCancha, IPrecioServicio precioServicio) =>
            {
                var precios = await precioServicio.GetAllAsync(idComplejo, nroCancha);
                return Results.Ok(precios);
            });
            app.MapGet("/complejos/{idComplejo}/canchas/{nroCancha}/precio", async (int idComplejo, int nroCancha, IPrecioServicio precioServicio) =>
            {
                PrecioDTO? precio = await precioServicio.GetUltimoPrecioAsync(idComplejo, nroCancha);
                if (precio == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(precio);
            });

            app.MapPost("/complejos/{idComplejo}/canchas/{nroCancha}/precios", async (int idComplejo, int nroCancha, PrecioCrearDTO dto, IPrecioServicio precioServicio) =>
            {
                try
                {
                    PrecioDTO precioDTO = await precioServicio.AddAsync(dto, idComplejo, nroCancha);
                    return Results.Created($"/complejos/{idComplejo}/canchas/{nroCancha}/precios/{precioDTO.FechaDesde:yyyy-MM-dd}", precioDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            app.MapGet("/complejos/{idComplejo}/canchas/{nroCancha}/precios/{fechaDesde}", async (int idComplejo, int nroCancha, DateOnly fechaDesde, IPrecioServicio precioServicio) =>
            {
                bool exists = await precioServicio.FechaDesdeExistsAsync(idComplejo, nroCancha, fechaDesde);

                return Results.Ok(exists);
            });
            app.MapGet("/complejos/buscar", async (string? ciudad, string? deporte, string? fecha, string? hora, decimal? min, decimal? max, IComplejoServicio complejoServicio) =>
            {
                var dtos = await complejoServicio.BuscarAsync(ciudad, deporte, fecha, hora, min, max);
                return Results.Ok(dtos);
            });
        }
    }
}