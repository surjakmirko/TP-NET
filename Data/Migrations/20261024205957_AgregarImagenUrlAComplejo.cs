using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarImagenUrlAComplejo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Complejos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagenUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Complejos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagenUrl",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Complejos");

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
    }
}
