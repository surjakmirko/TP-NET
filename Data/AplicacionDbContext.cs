using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;


namespace Data
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<TipoUsuario> TipoUsuarios => Set<TipoUsuario>();
        public DbSet<PersonaFisica> PersonaFisicas => Set<PersonaFisica>();
        public DbSet<PersonaJuridica> PersonaJuridicas => Set<PersonaJuridica>();
        public DbSet<Complejo> Complejos => Set<Complejo>();
        public DbSet<Cancha> Canchas => Set<Cancha>();
        public DbSet<Horario> Horarios => Set<Horario>();
        public DbSet<Precio> Precios => Set<Precio>();
        public DbSet<TipoCancha> TipoCanchas => Set<TipoCancha>();
        public DbSet<Provincia> Provincias => Set<Provincia>();
        public DbSet<Localidad> Localidades => Set<Localidad>();
        public DbSet<Turno> Turnos => Set<Turno>();
        public DbSet<TipoTurno> TipoTurnos => Set<TipoTurno>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PERSONAS 
            modelBuilder.Entity<PersonaFisica>()
                .HasKey(pf => pf.Dni);

            modelBuilder.Entity<PersonaJuridica>()
                .HasKey(pj => pj.Cuit);

            //USUARIO
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.TipoUsuario)
                .WithMany(tp => tp.Usuarios)
                .HasForeignKey(u => u.TipoUsuarioId);
            
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.PersonaFisica)
                .WithMany(pf => pf.Usuarios)
                .HasForeignKey(u => u.PersonaFisicaDni);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.PersonaJuridica)
                .WithMany(pj => pj.Usuarios)
                .HasForeignKey(u => u.PersonaJuridicaCuit);

            modelBuilder.Entity<TipoUsuario>()
                .HasKey(tp => tp.Id);

            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario(1, "Administrador"),
                new TipoUsuario(2, "Encargado"),
                new TipoUsuario(3, "Cliente"),
                new TipoUsuario(4, "Dueño")

            );

            modelBuilder.Entity<TipoCancha>()
                .HasKey(tc => tc.Id);

            modelBuilder.Entity<TipoCancha>().HasData(
                new TipoCancha(1, "Futbol 11"),
                new TipoCancha(2, "Futbol 5"),
                new TipoCancha(3, "Futbol 7"),
                new TipoCancha(4, "Futsal"),
                new TipoCancha(5, "Padel"),
                new TipoCancha(6, "Tenis"),
                new TipoCancha(7, "Ping Pong"),
                new TipoCancha(8, "Hockey"),
                new TipoCancha(9, "Basket"),
                new TipoCancha(10, "Voley")
            );

            modelBuilder.Entity<TipoTurno>()
                .HasKey(tt => tt.Id);

            modelBuilder.Entity<TipoTurno>().HasData(
                new TipoTurno(1,"Normal","Turno basico"),
                new TipoTurno(2, "Fijo", "Turno reservado periodicamente"),
                new TipoTurno(3, "Evento", "Turno reservado para un evento en particular")

            );




            //COMPLEJO
            modelBuilder.Entity<Complejo>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Complejo>()
                .HasOne(c => c.Localidad)
                .WithMany(l => l.Complejos)
                .HasForeignKey(c => c.LocalidadId);

            modelBuilder.Entity<Complejo>()
                .HasOne(c => c.Encargado)
                .WithOne(e => e.Complejo)
                .HasForeignKey<Complejo>(c => c.EncargadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Complejo>()
                .HasOne(c => c.Dueño)
                .WithMany(d => d.Complejos)
                .HasForeignKey(c => c.DueñoId)
                .OnDelete(DeleteBehavior.Restrict);

            //HORARIO
            modelBuilder.Entity<Horario>()
                .HasKey(h => new { h.ComplejoId, h.NroDia });

            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Complejo)
                .WithMany(c => c.Horarios)
                .HasForeignKey(h => h.ComplejoId);

            //CANCHA
            modelBuilder.Entity<Cancha>()
                .HasKey(c => new { c.ComplejoId, c.Nro });

            modelBuilder.Entity<Cancha>()
                .HasOne(c => c.Complejo)
                .WithMany(comp => comp.Canchas)
                .HasForeignKey(c => c.ComplejoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cancha>()
                .HasOne(c => c.TipoCancha)
                .WithMany(tc => tc.Canchas)
                .HasForeignKey(c => c.TipoCanchaId);

            modelBuilder.Entity<TipoCancha>()
                .HasKey(tp => tp.Id);

            //PRECIO
            modelBuilder.Entity<Precio>()
                .HasKey(p => new { p.ComplejoId, p.CanchaNro, p.FechaDesde });

            modelBuilder.Entity<Precio>()
                .HasOne(p => p.Cancha)
                .WithMany(c => c.Precios)
                .HasForeignKey(p => new { p.ComplejoId, p.CanchaNro });

            
            modelBuilder.Entity<Precio>(p =>
            {
                p.Property(x => x.PrecioBase).HasPrecision(18, 2);
                p.Property(x => x.PrecioSena).HasPrecision(18, 2);
                p.Property(x => x.PrecioAdicional).HasPrecision(18, 2);
            });

            // LOCALIDAD Y PROVINCIA
            modelBuilder.Entity<Provincia>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Provincia>().HasData(
                new { Id = 1, Nombre = "Buenos Aires" },
                new { Id = 2, Nombre = "Ciudad Autónoma de Buenos Aires" },
                new { Id = 3, Nombre = "Catamarca" },
                new { Id = 4, Nombre = "Chaco" },
                new { Id = 5, Nombre = "Chubut" },
                new { Id = 6, Nombre = "Córdoba" },
                new { Id = 7, Nombre = "Corrientes" },
                new { Id = 8, Nombre = "Entre Ríos" },
                new { Id = 9, Nombre = "Formosa" },
                new { Id = 10, Nombre = "Jujuy" },
                new { Id = 11, Nombre = "La Pampa" },
                new { Id = 12, Nombre = "La Rioja" },
                new { Id = 13, Nombre = "Mendoza" },
                new { Id = 14, Nombre = "Misiones" },
                new { Id = 15, Nombre = "Neuquén" },
                new { Id = 16, Nombre = "Río Negro" },
                new { Id = 17, Nombre = "Salta" },
                new { Id = 18, Nombre = "San Juan" },
                new { Id = 19, Nombre = "San Luis" },
                new { Id = 20, Nombre = "Santa Cruz" },
                new { Id = 21, Nombre = "Santa Fe" },
                new { Id = 22, Nombre = "Santiago del Estero" },
                new { Id = 23, Nombre = "Tierra del Fuego, Antártida e Islas del Atlántico Sur" },
                new { Id = 24, Nombre = "Tucumán" }
            );

            modelBuilder.Entity<Localidad>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Localidad>()
                .HasOne(l => l.Provincia)
                .WithMany(p => p.Localidades)
                .HasForeignKey(l => l.ProvinciaId);

            modelBuilder.Entity<Localidad>().HasData(
                new { Id = 1, Nombre = "La Plata", CodigoPostal = "B1900", ProvinciaId = 1 },
                new { Id = 2, Nombre = "Mar del Plata", CodigoPostal = "B7600", ProvinciaId = 1 },
                new { Id = 3, Nombre = "Bahía Blanca", CodigoPostal = "B8000", ProvinciaId = 1 },
                new { Id = 4, Nombre = "Tandil", CodigoPostal = "B7000", ProvinciaId = 1 },
                new { Id = 5, Nombre = "San Nicolás de los Arroyos", CodigoPostal = "B2900", ProvinciaId = 1 },

                new { Id = 6, Nombre = "Palermo", CodigoPostal = "C1425", ProvinciaId = 2 },
                new { Id = 7, Nombre = "Belgrano", CodigoPostal = "C1428", ProvinciaId = 2 },
                new { Id = 8, Nombre = "Caballito", CodigoPostal = "C1405", ProvinciaId = 2 },
                new { Id = 9, Nombre = "San Telmo", CodigoPostal = "C1063", ProvinciaId = 2 },
                new { Id = 10, Nombre = "Recoleta", CodigoPostal = "C1113", ProvinciaId = 2 },

                new { Id = 11, Nombre = "San Fernando del Valle de Catamarca", CodigoPostal = "K4700", ProvinciaId = 3 },
                new { Id = 12, Nombre = "Belén", CodigoPostal = "K4750", ProvinciaId = 3 },
                new { Id = 13, Nombre = "Andalgalá", CodigoPostal = "K4740", ProvinciaId = 3 },
                new { Id = 14, Nombre = "Tinogasta", CodigoPostal = "K5340", ProvinciaId = 3 },
                new { Id = 15, Nombre = "Santa María", CodigoPostal = "K4139", ProvinciaId = 3 },

                new { Id = 16, Nombre = "Resistencia", CodigoPostal = "H3500", ProvinciaId = 4 },
                new { Id = 17, Nombre = "Presidencia Roque Sáenz Peña", CodigoPostal = "H3700", ProvinciaId = 4 },
                new { Id = 18, Nombre = "Villa Ángela", CodigoPostal = "H3540", ProvinciaId = 4 },
                new { Id = 19, Nombre = "General Pinedo", CodigoPostal = "H3732", ProvinciaId = 4 },
                new { Id = 20, Nombre = "Charata", CodigoPostal = "H3730", ProvinciaId = 4 },

                new { Id = 21, Nombre = "Rawson", CodigoPostal = "U9103", ProvinciaId = 5 },
                new { Id = 22, Nombre = "Puerto Madryn", CodigoPostal = "U9120", ProvinciaId = 5 },
                new { Id = 23, Nombre = "Trelew", CodigoPostal = "U9100", ProvinciaId = 5 },
                new { Id = 24, Nombre = "Comodoro Rivadavia", CodigoPostal = "U9000", ProvinciaId = 5 },
                new { Id = 25, Nombre = "Esquel", CodigoPostal = "U9200", ProvinciaId = 5 },

                new { Id = 26, Nombre = "Córdoba Capital", CodigoPostal = "X5000", ProvinciaId = 6 },
                new { Id = 27, Nombre = "Villa Carlos Paz", CodigoPostal = "X5152", ProvinciaId = 6 },
                new { Id = 28, Nombre = "Río Cuarto", CodigoPostal = "X5800", ProvinciaId = 6 },
                new { Id = 29, Nombre = "Villa María", CodigoPostal = "X5900", ProvinciaId = 6 },
                new { Id = 30, Nombre = "San Francisco", CodigoPostal = "X2400", ProvinciaId = 6 },

                new { Id = 31, Nombre = "Corrientes Capital", CodigoPostal = "W3400", ProvinciaId = 7 },
                new { Id = 32, Nombre = "Goya", CodigoPostal = "W3450", ProvinciaId = 7 },
                new { Id = 33, Nombre = "Paso de los Libres", CodigoPostal = "W3230", ProvinciaId = 7 },
                new { Id = 34, Nombre = "Curuzú Cuatiá", CodigoPostal = "W3460", ProvinciaId = 7 },
                new { Id = 35, Nombre = "Mercedes", CodigoPostal = "W3470", ProvinciaId = 7 },

                new { Id = 36, Nombre = "Paraná", CodigoPostal = "E3100", ProvinciaId = 8 },
                new { Id = 37, Nombre = "Concordia", CodigoPostal = "E3200", ProvinciaId = 8 },
                new { Id = 38, Nombre = "Gualeguaychú", CodigoPostal = "E2820", ProvinciaId = 8 },
                new { Id = 39, Nombre = "Concepción del Uruguay", CodigoPostal = "E3260", ProvinciaId = 8 },
                new { Id = 40, Nombre = "Victoria", CodigoPostal = "E3153", ProvinciaId = 8 },

                new { Id = 41, Nombre = "Formosa Capital", CodigoPostal = "P3600", ProvinciaId = 9 },
                new { Id = 42, Nombre = "Clorinda", CodigoPostal = "P3610", ProvinciaId = 9 },
                new { Id = 43, Nombre = "Pirané", CodigoPostal = "P3606", ProvinciaId = 9 },
                new { Id = 44, Nombre = "El Colorado", CodigoPostal = "P3603", ProvinciaId = 9 },
                new { Id = 45, Nombre = "Las Lomitas", CodigoPostal = "P3630", ProvinciaId = 9 },

                new { Id = 46, Nombre = "San Salvador de Jujuy", CodigoPostal = "Y4600", ProvinciaId = 10 },
                new { Id = 47, Nombre = "San Pedro de Jujuy", CodigoPostal = "Y4500", ProvinciaId = 10 },
                new { Id = 48, Nombre = "Tilcara", CodigoPostal = "Y4624", ProvinciaId = 10 },
                new { Id = 49, Nombre = "Humahuaca", CodigoPostal = "Y4630", ProvinciaId = 10 },
                new { Id = 50, Nombre = "La Quiaca", CodigoPostal = "Y4650", ProvinciaId = 10 },

                new { Id = 51, Nombre = "Santa Rosa", CodigoPostal = "L6300", ProvinciaId = 11 },
                new { Id = 52, Nombre = "General Pico", CodigoPostal = "L6360", ProvinciaId = 11 },
                new { Id = 53, Nombre = "Toay", CodigoPostal = "L6303", ProvinciaId = 11 },
                new { Id = 54, Nombre = "Realicó", CodigoPostal = "L6200", ProvinciaId = 11 },
                new { Id = 55, Nombre = "General Acha", CodigoPostal = "L8200", ProvinciaId = 11 },

                new { Id = 56, Nombre = "La Rioja Capital", CodigoPostal = "F5300", ProvinciaId = 12 },
                new { Id = 57, Nombre = "Chilecito", CodigoPostal = "F5360", ProvinciaId = 12 },
                new { Id = 58, Nombre = "Aimogasta", CodigoPostal = "F5310", ProvinciaId = 12 },
                new { Id = 59, Nombre = "Chamical", CodigoPostal = "F5380", ProvinciaId = 12 },
                new { Id = 60, Nombre = "Villa Unión", CodigoPostal = "F5350", ProvinciaId = 12 },

                new { Id = 61, Nombre = "Mendoza Capital", CodigoPostal = "M5500", ProvinciaId = 13 },
                new { Id = 62, Nombre = "San Rafael", CodigoPostal = "M5600", ProvinciaId = 13 },
                new { Id = 63, Nombre = "Godoy Cruz", CodigoPostal = "M5501", ProvinciaId = 13 },
                new { Id = 64, Nombre = "Maipú", CodigoPostal = "M5515", ProvinciaId = 13 },
                new { Id = 65, Nombre = "Malargüe", CodigoPostal = "M5613", ProvinciaId = 13 },

                new { Id = 66, Nombre = "Posadas", CodigoPostal = "N3300", ProvinciaId = 14 },
                new { Id = 67, Nombre = "Puerto Iguazú", CodigoPostal = "N3370", ProvinciaId = 14 },
                new { Id = 68, Nombre = "Oberá", CodigoPostal = "N3360", ProvinciaId = 14 },
                new { Id = 69, Nombre = "Eldorado", CodigoPostal = "N3380", ProvinciaId = 14 },
                new { Id = 70, Nombre = "Apostoles", CodigoPostal = "N3350", ProvinciaId = 14 },

                new { Id = 71, Nombre = "Neuquén Capital", CodigoPostal = "Q8300", ProvinciaId = 15 },
                new { Id = 72, Nombre = "San Martín de los Andes", CodigoPostal = "Q8370", ProvinciaId = 15 },
                new { Id = 73, Nombre = "Villa La Angostura", CodigoPostal = "Q8407", ProvinciaId = 15 },
                new { Id = 74, Nombre = "Zapala", CodigoPostal = "Q8340", ProvinciaId = 15 },
                new { Id = 75, Nombre = "Cutral Có", CodigoPostal = "Q8322", ProvinciaId = 15 },

                new { Id = 76, Nombre = "Viedma", CodigoPostal = "R8500", ProvinciaId = 16 },
                new { Id = 77, Nombre = "San Carlos de Bariloche", CodigoPostal = "R8400", ProvinciaId = 16 },
                new { Id = 78, Nombre = "General Roca", CodigoPostal = "R8332", ProvinciaId = 16 },
                new { Id = 79, Nombre = "Cipolletti", CodigoPostal = "R8324", ProvinciaId = 16 },
                new { Id = 80, Nombre = "Las Grutas", CodigoPostal = "R8521", ProvinciaId = 16 },

                new { Id = 81, Nombre = "Salta Capital", CodigoPostal = "A4400", ProvinciaId = 17 },
                new { Id = 82, Nombre = "Cafayate", CodigoPostal = "A4427", ProvinciaId = 17 },
                new { Id = 83, Nombre = "San Ramón de la Nueva Orán", CodigoPostal = "A4530", ProvinciaId = 17 },
                new { Id = 84, Nombre = "Tartagal", CodigoPostal = "A4560", ProvinciaId = 17 },
                new { Id = 85, Nombre = "General Güemes", CodigoPostal = "A4432", ProvinciaId = 17 },

                new { Id = 86, Nombre = "San Juan Capital", CodigoPostal = "J5400", ProvinciaId = 18 },
                new { Id = 87, Nombre = "Rawson", CodigoPostal = "J5425", ProvinciaId = 18 },
                new { Id = 88, Nombre = "Chimbas", CodigoPostal = "J5413", ProvinciaId = 18 },
                new { Id = 89, Nombre = "Caucete", CodigoPostal = "J5442", ProvinciaId = 18 },
                new { Id = 90, Nombre = "Jáchal", CodigoPostal = "J5460", ProvinciaId = 18 },

                new { Id = 91, Nombre = "San Luis Capital", CodigoPostal = "D5700", ProvinciaId = 19 },
                new { Id = 92, Nombre = "Villa Mercedes", CodigoPostal = "D5730", ProvinciaId = 19 },
                new { Id = 93, Nombre = "Merlo", CodigoPostal = "D5881", ProvinciaId = 19 },
                new { Id = 94, Nombre = "La Punta", CodigoPostal = "D5703", ProvinciaId = 19 },
                new { Id = 95, Nombre = "Justo Daract", CodigoPostal = "D5738", ProvinciaId = 19 },

                new { Id = 96, Nombre = "Río Gallegos", CodigoPostal = "Z9400", ProvinciaId = 20 },
                new { Id = 97, Nombre = "El Calafate", CodigoPostal = "Z9405", ProvinciaId = 20 },
                new { Id = 98, Nombre = "Caleta Olivia", CodigoPostal = "Z9011", ProvinciaId = 20 },
                new { Id = 99, Nombre = "Puerto Deseado", CodigoPostal = "Z9050", ProvinciaId = 20 },
                new { Id = 100, Nombre = "El Chaltén", CodigoPostal = "Z9301", ProvinciaId = 20 },

                new { Id = 101, Nombre = "Santa Fe Capital", CodigoPostal = "S3000", ProvinciaId = 21 },
                new { Id = 102, Nombre = "Rosario", CodigoPostal = "S2000", ProvinciaId = 21 },
                new { Id = 103, Nombre = "Rafaela", CodigoPostal = "S2300", ProvinciaId = 21 },
                new { Id = 104, Nombre = "Venado Tuerto", CodigoPostal = "S2600", ProvinciaId = 21 },
                new { Id = 105, Nombre = "Reconquista", CodigoPostal = "S3500", ProvinciaId = 21 },

                new { Id = 106, Nombre = "Santiago del Estero Capital", CodigoPostal = "G4200", ProvinciaId = 22 },
                new { Id = 107, Nombre = "La Banda", CodigoPostal = "G4200", ProvinciaId = 22 },
                new { Id = 108, Nombre = "Termas de Río Hondo", CodigoPostal = "G4220", ProvinciaId = 22 },
                new { Id = 109, Nombre = "Añatuya", CodigoPostal = "G3760", ProvinciaId = 22 },
                new { Id = 110, Nombre = "Frías", CodigoPostal = "G4230", ProvinciaId = 22 },

                new { Id = 111, Nombre = "Ushuaia", CodigoPostal = "V9410", ProvinciaId = 23 },
                new { Id = 112, Nombre = "Río Grande", CodigoPostal = "V9420", ProvinciaId = 23 },
                new { Id = 113, Nombre = "Tolhuin", CodigoPostal = "V9412", ProvinciaId = 23 },
                new { Id = 114, Nombre = "Puerto Almanza", CodigoPostal = "V9410", ProvinciaId = 23 },
                new { Id = 115, Nombre = "San Sebastián", CodigoPostal = "V9420", ProvinciaId = 23 },

                new { Id = 116, Nombre = "San Miguel de Tucumán", CodigoPostal = "T4000", ProvinciaId = 24 },
                new { Id = 117, Nombre = "Yerba Buena", CodigoPostal = "T4107", ProvinciaId = 24 },
                new { Id = 118, Nombre = "Tafí del Valle", CodigoPostal = "T4137", ProvinciaId = 24 },
                new { Id = 119, Nombre = "Concepción", CodigoPostal = "T4147", ProvinciaId = 24 },
                new { Id = 120, Nombre = "Banda del Río Salí", CodigoPostal = "T4109", ProvinciaId = 24 }
            );

            //TURNO 
            modelBuilder.Entity<TipoTurno>()
                .HasKey(tt => tt.Id);

            modelBuilder.Entity<Turno>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Cliente)
                .WithMany(u => u.Turnos)
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Cancha)
                .WithMany(c => c.Turnos)
                .HasForeignKey(t => new { t.ComplejoId, t.CanchaNro })
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.TipoTurno)
                .WithMany(tt => tt.Turnos)
                .HasForeignKey(t => t.TipoTurnoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}