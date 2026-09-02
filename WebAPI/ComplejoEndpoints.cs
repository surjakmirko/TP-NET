using DTOs;
using Modelo.Dominio;
using Servicios;

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

            app.MapPost("/complejos", async (ComplejoCrearDTO dto, IComplejoServicio complejoServicio) =>
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
                    HorarioDTO horarioDTO = await horarioServicio.AddAsync(dto,idComplejo);
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
                    var encontrado = await horarioServicio.UpdateAsync(dto,idComplejo,numDia);

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

            ///Canchas

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
                    CanchaDTO canchaDTO = await canchaServicio.AddAsync(dto,idComplejo);
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
                    // Llamamos al servicio enviando el DTO, el ID del complejo y el número original de la URL
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

            app.MapGet("/complejos/{idComplejo}/canchas/{nroCancha}/precios/{fechaDesde}", async (int idComplejo, int nroCancha, DateOnly fechaDesde, IPrecioServicio precioServicio) =>
            {
                PrecioDTO? dto = await precioServicio.GetAsync(idComplejo, nroCancha, fechaDesde);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            });

            app.MapPost("/complejos/{idComplejo}/canchas/{nroCancha}/precios", async (int idComplejo, int nroCancha, PrecioCrearDTO dto, IPrecioServicio precioServicio) =>
            {
                try
                {
                    PrecioDTO precioDTO = await precioServicio.AddAsync(dto, idComplejo,nroCancha);
                    return Results.Created($"/complejos/{idComplejo}/canchas/{nroCancha}/precios/{precioDTO.FechaDesde:yyyy-MM-dd}", precioDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
        }
    }
}
