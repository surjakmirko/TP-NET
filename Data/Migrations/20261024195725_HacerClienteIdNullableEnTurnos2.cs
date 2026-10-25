using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class HacerClienteIdNullableEnTurnos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$mkEKyzBLcKpbkfMD7upQ8OpcTPJYx.wNP23tlvPnUtsz0fL6xTqA6");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$mqoRFVCt81CTPJqNoaZbduxULn9rDfs5awIJr3h35wXV/O7UygJYK");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$SSnCxJZRR2rOHa.XnYgsL.PrD8jZBop656Oi2Zi9DnfsyvaQ0HAx2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$3t348wTP.x9VdVQgod6aBeKdgSfh2fydZY3n/m3fZQobYHnBO0JSm");
        }
    }
}
