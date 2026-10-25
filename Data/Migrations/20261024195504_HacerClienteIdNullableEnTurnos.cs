using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class HacerClienteIdNullableEnTurnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Turnos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$kH39W0j5XNlg0FQgk.IuaeT/UoT.N86B9YvitLYKmh5YmOWB9oHda");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$eddZ9sRuNHx6iLJmEYfg0ee.HXW22wjs/xp8zhaOP7VCENKJ2JWUm");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$aJ1e1QQBZV4RH538Md8gZusOZcjuOkh2aCGCvFFLYeGeLjPOysTrq");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$0ILOhhn64UYaQF7BEMAW8OzbiiaTgO1mTwzxEVi/qiG0sXGcKcTb2");
        }
    }
}
