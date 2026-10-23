using Servicios;

namespace WebAPI
{
    public static class DashboardEndpoints
    {
        public static void MapDashboardEndpoints(this WebApplication app)
        {
            app.MapGet("/complejos/dueno/{idDueno}/dashboard", async (
                int idDueno,
                DateOnly? fecha,
                IDashboardServicio dashboardServicio) =>
            {
                var dia = fecha ?? DateOnly.FromDateTime(DateTime.Today);
                var dto = await dashboardServicio.ObtenerMetricasDuenoAsync(idDueno, dia);

                return Results.Ok(dto);
            });
        }
    }
}
