namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/usuarios", () => "Obtener todos los usuarios");
            app.MapGet("/usuarios/{id}", (int id) => $"Obtener usuario con ID {id}");
            app.MapPost("/usuarios", () => "Crear un nuevo usuario");
            app.MapPut("/usuarios/{id}", (int id) => $"Actualizar usuario con ID {id}");
            app.MapDelete("/usuarios/{id}", (int id) => $"Eliminar usuario con ID {id}");
        }
    }
}