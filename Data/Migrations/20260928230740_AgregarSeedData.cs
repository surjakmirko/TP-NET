using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zl4GOSzveR7bq6Yl7Wd/U.jy2SW/Sofyr0C/WODRFa4DTqGGBRNwe");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$GTnfCLpOGQoqFgqMBkW8Ruj7CE4i3MM8nMGdx3RvqvDb7SMJu5NIe");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZUIPGkgfZrfsmDBWt7dUpepdW//yJwwi0kBUZSzpDLfI8lhye8E0e");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$2NF2MzRcz8cie87iRxStRuvyy8cH46DReWMUREY1ocx0JHmGonQym");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
