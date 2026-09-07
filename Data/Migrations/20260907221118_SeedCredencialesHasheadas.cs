using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCredencialesHasheadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$AlwmwydZgOtVAim4taaFnOVeuSkOwKCqWDUiWtGGlKyko.nZeTnCW");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$BDMfISYyMo0LgRNqQp1Xl.pJ6LRnwqZKg8kR2xIy8oTOEKV2nITny");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$2NnPNWqlDO.Q.oXyP.me9ew2bQQjl9XSJWJkdSVrKTwa0uC5z7yNK");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$23p8zZjfS6Jo3.2yTFp.k.jkyJ9rtnEUvokDGexDrHSkTrIoJJWTq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "dueño");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "encargado");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "encargado2");
        }
    }
}
