using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$EAqjvEiH2cB0C/dKNh03wOM.E6CYSchYkc4Clnqh45VqkBcr.AhSm");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$OvvqI5/YCzZsVR2mOiRCVOz2wT67pTLkGzKFuWJW.uetJKyWYTyQa");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZL/WkCM9e5GTJhB8iL.sou3mwCSbjQywNpbYYkEBS.j7D93vJyIKe");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$yq2due8fURIT8yWQTyC3MOk2x6b.XYOg2H5VGMXn4GVvVD4gi1cAG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
