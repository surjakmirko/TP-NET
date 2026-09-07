using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCredenciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Password", "PersonaFisicaDni", "PersonaJuridicaCuit", "Telefono", "TipoUsuarioId" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "admin", null, null, "12345678", 1 },
                    { 2, "dueño@gmail.com", "dueño", null, "20123456789", "22446688", 4 },
                    { 3, "encargado@gmail.com", "encargado", null, null, "987654321", 2 },
                    { 4, "encargado2@gmail.com", "encargado2", null, null, "113355799", 2 }
                });

            migrationBuilder.InsertData(
                table: "Complejos",
                columns: new[] { "Id", "Direccion", "DueñoId", "EncargadoId", "LocalidadId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", 1, 3, 15, "Complejo Deportivo La Canchita" },
                    { 2, "Avenida Siempre Viva 456", 1, 4, 15, "Complejo Deportivo El Golazo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
