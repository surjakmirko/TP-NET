using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionId20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueñoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueñoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$nbToVlWyDCWqbz.kzL9n8ONEKU0QXSXwmIEPp1GJ89SuxK1IVNLWO");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$ffGXzD1pY8Aw3Q4tpikSa.gHyd8A7zXHtTD0HDewIqG2b3J6yIvn2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$wAxPtWlkZh//qsM0h0M6Aujxy58RZWmZAOib4ZjnhRavu2rCJOR5.");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$nCOULbax26.BO2tfpIDmEOO3q4jdZX.BuN2rQhotGr8OpWxzFJyFS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueñoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueñoId",
                value: 1);

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
    }
}
