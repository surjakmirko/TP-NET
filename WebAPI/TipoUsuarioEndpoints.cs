namespace WebAPI
{
    public static class TipoUsuarioEndpoints
    {
        public static void MapTipoUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/tipos-usuario", () => "Obtener todos los tipos de usuario");
            app.MapGet("/tipos-usuario/{id}", (int id) => $"Obtener tipo de usuario con ID {id}");
            app.MapPost("/tipos-usuario", () => "Crear un nuevo tipo de usuario");
            app.MapPut("/tipos-usuario/{id}", (int id) => $"Actualizar tipo de usuario con ID {id}");
            app.MapDelete("/tipos-usuario/{id}", (int id) => $"Eliminar tipo de usuario con ID {id}");
        }
    }
}