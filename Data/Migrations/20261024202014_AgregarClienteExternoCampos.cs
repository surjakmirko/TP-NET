using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarClienteExternoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Pl4AP3kRG/zFeyGILUity.2CvfYDtumLW.HfFgfOQ0tf8IXna./HC");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$YRksxgUS9L5DqbfxbMpPIOw.FEMeJi0sjZdlLoZ7B/xwMZFkUvzlC");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$6bQ8AkerSV0AJn0B3aD7W.w0mvEFke2XWBs5P7ng9uhHk9WpeFzSm");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$fNwkSDFR8brqbEukZJDcPuvgASbV/oLNnTDxqVUU.Ky7hL.6RuR1i");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$C7UQHHb5oGQECOMAS3seFet3qwYv0fsD2nzCHFDzVWkLgSrl.106q");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$E/bnUVOZFFAtWVzeutwAc.PA6DdCzWu35w9eVt97p8dXsKLBc8FHu");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$gE3SAVQ8/I.zlfnn9a3zk.HyrrmKmJf0tQhI9mz2Sh4Z1CP97Eqp2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$yB73wcWT.TBsdYx2XY4kkeKElyoK0dsNBe80Ks1ofjad.mQ9myVty");
        }
    }
}
