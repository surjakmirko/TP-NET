using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarClienteExternoATurno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApellidoClienteExterno",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreClienteExterno",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoClienteExterno",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "NombreClienteExterno",
                table: "Turnos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$jun95TTLoS5js710EgaZoeXX3tLSWxmyD3YLCN5EKYyQZ2p/Cx3pK");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$VLqd0K/bGUq21tC.tyVfZ.Jhp5QJZxGARAJSqMNS9YdMMDlH8AP8C");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$FY6yO2.rhgBfyHmijurc8.9xjbsaX.p6uy/nXRap23lEYYAr1IETO");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$iC0uyQgaESKPi4eqOhOVw.d8Tc8H.yPbGgeEqQ6rVo/JyozTFYdeG");
        }
    }
}
