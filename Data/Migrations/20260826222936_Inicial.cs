using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonaFisicas",
                columns: table => new
                {
                    Dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaFisicas", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "PersonaJuridicas",
                columns: table => new
                {
                    Cuit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaJuridicas", x => x.Cuit);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCanchas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deporte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCanchas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTurnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTurnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    PersonaFisicaDni = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonaJuridicaCuit = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_PersonaFisicas_PersonaFisicaDni",
                        column: x => x.PersonaFisicaDni,
                        principalTable: "PersonaFisicas",
                        principalColumn: "Dni");
                    table.ForeignKey(
                        name: "FK_Usuarios_PersonaJuridicas_PersonaJuridicaCuit",
                        column: x => x.PersonaJuridicaCuit,
                        principalTable: "PersonaJuridicas",
                        principalColumn: "Cuit");
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complejos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadId = table.Column<int>(type: "int", nullable: false),
                    EncargadoId = table.Column<int>(type: "int", nullable: false),
                    DueñoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complejos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complejos_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complejos_Usuarios_DueñoId",
                        column: x => x.DueñoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complejos_Usuarios_EncargadoId",
                        column: x => x.EncargadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Canchas",
                columns: table => new
                {
                    Nro = table.Column<int>(type: "int", nullable: false),
                    ComplejoId = table.Column<int>(type: "int", nullable: false),
                    TipoCanchaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canchas", x => new { x.ComplejoId, x.Nro });
                    table.ForeignKey(
                        name: "FK_Canchas_Complejos_ComplejoId",
                        column: x => x.ComplejoId,
                        principalTable: "Complejos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Canchas_TipoCanchas_TipoCanchaId",
                        column: x => x.TipoCanchaId,
                        principalTable: "TipoCanchas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    ComplejoId = table.Column<int>(type: "int", nullable: false),
                    NroDia = table.Column<int>(type: "int", nullable: false),
                    HoraApertura = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraCierre = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => new { x.ComplejoId, x.NroDia });
                    table.ForeignKey(
                        name: "FK_Horarios_Complejos_ComplejoId",
                        column: x => x.ComplejoId,
                        principalTable: "Complejos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precios",
                columns: table => new
                {
                    FechaDesde = table.Column<DateOnly>(type: "date", nullable: false),
                    ComplejoId = table.Column<int>(type: "int", nullable: false),
                    CanchaNro = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PrecioBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioAdicional = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioSena = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precios", x => new { x.ComplejoId, x.CanchaNro, x.FechaDesde });
                    table.ForeignKey(
                        name: "FK_Precios_Canchas_ComplejoId_CanchaNro",
                        columns: x => new { x.ComplejoId, x.CanchaNro },
                        principalTable: "Canchas",
                        principalColumns: new[] { "ComplejoId", "Nro" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoCancelacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoTurnoId = table.Column<int>(type: "int", nullable: false),
                    ComplejoId = table.Column<int>(type: "int", nullable: false),
                    CanchaNro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_Canchas_ComplejoId_CanchaNro",
                        columns: x => new { x.ComplejoId, x.CanchaNro },
                        principalTable: "Canchas",
                        principalColumns: new[] { "ComplejoId", "Nro" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Complejos_ComplejoId",
                        column: x => x.ComplejoId,
                        principalTable: "Complejos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turnos_TipoTurnos_TipoTurnoId",
                        column: x => x.TipoTurnoId,
                        principalTable: "TipoTurnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_TipoCanchaId",
                table: "Canchas",
                column: "TipoCanchaId");

            migrationBuilder.CreateIndex(
                name: "IX_Complejos_DueñoId",
                table: "Complejos",
                column: "DueñoId");

            migrationBuilder.CreateIndex(
                name: "IX_Complejos_EncargadoId",
                table: "Complejos",
                column: "EncargadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complejos_LocalidadId",
                table: "Complejos",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ClienteId",
                table: "Turnos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ComplejoId_CanchaNro",
                table: "Turnos",
                columns: new[] { "ComplejoId", "CanchaNro" });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_TipoTurnoId",
                table: "Turnos",
                column: "TipoTurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaFisicaDni",
                table: "Usuarios",
                column: "PersonaFisicaDni");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaJuridicaCuit",
                table: "Usuarios",
                column: "PersonaJuridicaCuit");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Canchas");

            migrationBuilder.DropTable(
                name: "TipoTurnos");

            migrationBuilder.DropTable(
                name: "Complejos");

            migrationBuilder.DropTable(
                name: "TipoCanchas");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "PersonaFisicas");

            migrationBuilder.DropTable(
                name: "PersonaJuridicas");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}
