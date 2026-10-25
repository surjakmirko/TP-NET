using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarImagenUrlComplejo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$S17lj6sQd/nGwj0ml6u0v.VPyonCGUNtIIw4UbFzlmxlnimJzq0EW");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$EoQLvpFirFXvczgmc5ZQCezC8tbTinvzOQoVmOYphZ/l01eTgb0ri");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ssXeZC.f5TYRqRRnK0CiPO1MhfloxAlq4cajj3KBpSudOVPhEsG8i");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$smm4h1bmUq4zuoW/5xyKyuqWvzckEIHDG7LeRovTfdCkkvfUDyn32");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$AiN56IlZuwc.d7G.Pz53Q.KBnroIZcfbmD5eLni60CqNUyKDqCCii");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$SG2mpiM.FRkmT/tkRsqEmeMVGar2A7i4VFuTRLY3gxArKkAJO340u");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$q38uyHD86tgI6UhBPjMceuSq0K//H2jbJqyP7cf3qVwcJb6CeWqoG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Gh4UE0ULkavr1K6MgyHNveiJJb1RTfwfNkSqjwLs5pZQaUISPg0wm");
        }
    }
}
