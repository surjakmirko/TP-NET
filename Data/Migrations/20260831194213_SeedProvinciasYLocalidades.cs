using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProvinciasYLocalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Ciudad Autónoma de Buenos Aires" },
                    { 3, "Catamarca" },
                    { 4, "Chaco" },
                    { 5, "Chubut" },
                    { 6, "Córdoba" },
                    { 7, "Corrientes" },
                    { 8, "Entre Ríos" },
                    { 9, "Formosa" },
                    { 10, "Jujuy" },
                    { 11, "La Pampa" },
                    { 12, "La Rioja" },
                    { 13, "Mendoza" },
                    { 14, "Misiones" },
                    { 15, "Neuquén" },
                    { 16, "Río Negro" },
                    { 17, "Salta" },
                    { 18, "San Juan" },
                    { 19, "San Luis" },
                    { 20, "Santa Cruz" },
                    { 21, "Santa Fe" },
                    { 22, "Santiago del Estero" },
                    { 23, "Tierra del Fuego, Antártida e Islas del Atlántico Sur" },
                    { 24, "Tucumán" }
                });

            migrationBuilder.InsertData(
                table: "TipoUsuarios",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 4, "Dueño" });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "CodigoPostal", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, "B1900", "La Plata", 1 },
                    { 2, "B7600", "Mar del Plata", 1 },
                    { 3, "B8000", "Bahía Blanca", 1 },
                    { 4, "B7000", "Tandil", 1 },
                    { 5, "B2900", "San Nicolás de los Arroyos", 1 },
                    { 6, "C1425", "Palermo", 2 },
                    { 7, "C1428", "Belgrano", 2 },
                    { 8, "C1405", "Caballito", 2 },
                    { 9, "C1063", "San Telmo", 2 },
                    { 10, "C1113", "Recoleta", 2 },
                    { 11, "K4700", "San Fernando del Valle de Catamarca", 3 },
                    { 12, "K4750", "Belén", 3 },
                    { 13, "K4740", "Andalgalá", 3 },
                    { 14, "K5340", "Tinogasta", 3 },
                    { 15, "K4139", "Santa María", 3 },
                    { 16, "H3500", "Resistencia", 4 },
                    { 17, "H3700", "Presidencia Roque Sáenz Peña", 4 },
                    { 18, "H3540", "Villa Ángela", 4 },
                    { 19, "H3732", "General Pinedo", 4 },
                    { 20, "H3730", "Charata", 4 },
                    { 21, "U9103", "Rawson", 5 },
                    { 22, "U9120", "Puerto Madryn", 5 },
                    { 23, "U9100", "Trelew", 5 },
                    { 24, "U9000", "Comodoro Rivadavia", 5 },
                    { 25, "U9200", "Esquel", 5 },
                    { 26, "X5000", "Córdoba Capital", 6 },
                    { 27, "X5152", "Villa Carlos Paz", 6 },
                    { 28, "X5800", "Río Cuarto", 6 },
                    { 29, "X5900", "Villa María", 6 },
                    { 30, "X2400", "San Francisco", 6 },
                    { 31, "W3400", "Corrientes Capital", 7 },
                    { 32, "W3450", "Goya", 7 },
                    { 33, "W3230", "Paso de los Libres", 7 },
                    { 34, "W3460", "Curuzú Cuatiá", 7 },
                    { 35, "W3470", "Mercedes", 7 },
                    { 36, "E3100", "Paraná", 8 },
                    { 37, "E3200", "Concordia", 8 },
                    { 38, "E2820", "Gualeguaychú", 8 },
                    { 39, "E3260", "Concepción del Uruguay", 8 },
                    { 40, "E3153", "Victoria", 8 },
                    { 41, "P3600", "Formosa Capital", 9 },
                    { 42, "P3610", "Clorinda", 9 },
                    { 43, "P3606", "Pirané", 9 },
                    { 44, "P3603", "El Colorado", 9 },
                    { 45, "P3630", "Las Lomitas", 9 },
                    { 46, "Y4600", "San Salvador de Jujuy", 10 },
                    { 47, "Y4500", "San Pedro de Jujuy", 10 },
                    { 48, "Y4624", "Tilcara", 10 },
                    { 49, "Y4630", "Humahuaca", 10 },
                    { 50, "Y4650", "La Quiaca", 10 },
                    { 51, "L6300", "Santa Rosa", 11 },
                    { 52, "L6360", "General Pico", 11 },
                    { 53, "L6303", "Toay", 11 },
                    { 54, "L6200", "Realicó", 11 },
                    { 55, "L8200", "General Acha", 11 },
                    { 56, "F5300", "La Rioja Capital", 12 },
                    { 57, "F5360", "Chilecito", 12 },
                    { 58, "F5310", "Aimogasta", 12 },
                    { 59, "F5380", "Chamical", 12 },
                    { 60, "F5350", "Villa Unión", 12 },
                    { 61, "M5500", "Mendoza Capital", 13 },
                    { 62, "M5600", "San Rafael", 13 },
                    { 63, "M5501", "Godoy Cruz", 13 },
                    { 64, "M5515", "Maipú", 13 },
                    { 65, "M5613", "Malargüe", 13 },
                    { 66, "N3300", "Posadas", 14 },
                    { 67, "N3370", "Puerto Iguazú", 14 },
                    { 68, "N3360", "Oberá", 14 },
                    { 69, "N3380", "Eldorado", 14 },
                    { 70, "N3350", "Apostoles", 14 },
                    { 71, "Q8300", "Neuquén Capital", 15 },
                    { 72, "Q8370", "San Martín de los Andes", 15 },
                    { 73, "Q8407", "Villa La Angostura", 15 },
                    { 74, "Q8340", "Zapala", 15 },
                    { 75, "Q8322", "Cutral Có", 15 },
                    { 76, "R8500", "Viedma", 16 },
                    { 77, "R8400", "San Carlos de Bariloche", 16 },
                    { 78, "R8332", "General Roca", 16 },
                    { 79, "R8324", "Cipolletti", 16 },
                    { 80, "R8521", "Las Grutas", 16 },
                    { 81, "A4400", "Salta Capital", 17 },
                    { 82, "A4427", "Cafayate", 17 },
                    { 83, "A4530", "San Ramón de la Nueva Orán", 17 },
                    { 84, "A4560", "Tartagal", 17 },
                    { 85, "A4432", "General Güemes", 17 },
                    { 86, "J5400", "San Juan Capital", 18 },
                    { 87, "J5425", "Rawson", 18 },
                    { 88, "J5413", "Chimbas", 18 },
                    { 89, "J5442", "Caucete", 18 },
                    { 90, "J5460", "Jáchal", 18 },
                    { 91, "D5700", "San Luis Capital", 19 },
                    { 92, "D5730", "Villa Mercedes", 19 },
                    { 93, "D5881", "Merlo", 19 },
                    { 94, "D5703", "La Punta", 19 },
                    { 95, "D5738", "Justo Daract", 19 },
                    { 96, "Z9400", "Río Gallegos", 20 },
                    { 97, "Z9405", "El Calafate", 20 },
                    { 98, "Z9011", "Caleta Olivia", 20 },
                    { 99, "Z9050", "Puerto Deseado", 20 },
                    { 100, "Z9301", "El Chaltén", 20 },
                    { 101, "S3000", "Santa Fe Capital", 21 },
                    { 102, "S2000", "Rosario", 21 },
                    { 103, "S2300", "Rafaela", 21 },
                    { 104, "S2600", "Venado Tuerto", 21 },
                    { 105, "S3500", "Reconquista", 21 },
                    { 106, "G4200", "Santiago del Estero Capital", 22 },
                    { 107, "G4200", "La Banda", 22 },
                    { 108, "G4220", "Termas de Río Hondo", 22 },
                    { 109, "G3760", "Añatuya", 22 },
                    { 110, "G4230", "Frías", 22 },
                    { 111, "V9410", "Ushuaia", 23 },
                    { 112, "V9420", "Río Grande", 23 },
                    { 113, "V9412", "Tolhuin", 23 },
                    { 114, "V9410", "Puerto Almanza", 23 },
                    { 115, "V9420", "San Sebastián", 23 },
                    { 116, "T4000", "San Miguel de Tucumán", 24 },
                    { 117, "T4107", "Yerba Buena", 24 },
                    { 118, "T4137", "Tafí del Valle", 24 },
                    { 119, "T4147", "Concepción", 24 },
                    { 120, "T4109", "Banda del Río Salí", 24 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "TipoUsuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
