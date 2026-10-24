using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class EstadoEnCancha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Canchas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Canchas");

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
                column: "Password",
                value: "$2a$11$Hi20PlP5cwmApDwQSOeHDOAJLVwJcxOb4MyhQQMgW5O/mjzl/o8oe");

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
    }
}
