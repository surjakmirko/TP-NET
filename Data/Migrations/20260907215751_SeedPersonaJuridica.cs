using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPersonaJuridica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonaJuridicas",
                columns: new[] { "Cuit", "RazonSocial" },
                values: new object[] { "20123456789", "Complejo Deportivo La Canchita" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonaJuridicas",
                keyColumn: "Cuit",
                keyValue: "20123456789");
        }
    }
}
