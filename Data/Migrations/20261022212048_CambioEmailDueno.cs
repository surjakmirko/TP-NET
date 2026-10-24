using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CambioEmailDueno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$LbCwDAJv8bVMsm3p9ujXc.JM6bIoxuHC.9SzbSU9EZ0PuJKY.yCHS");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "dueno@gmail.com", "$2a$11$Hi20PlP5cwmApDwQSOeHDOAJLVwJcxOb4MyhQQMgW5O/mjzl/o8oe" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$WaDsK4xFAlHy8.LaQxLS3OfTvErIuEi/hf7LBhMgssqy2gi2KKg0y");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$iFOJ8TwfqP1TIBIX.xdlqefdwT6UNfIP6m3IoF9slgXHCECAk7Jbi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Email", "Password" },
                values: new object[] { "dueño@gmail.com", "$2a$11$GTnfCLpOGQoqFgqMBkW8Ruj7CE4i3MM8nMGdx3RvqvDb7SMJu5NIe" });

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
    }
}
