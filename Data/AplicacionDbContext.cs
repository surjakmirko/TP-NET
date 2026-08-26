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

            modelBuilder.Entity<Localidad>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Localidad>()
                .HasOne(l => l.Provincia)
                .WithMany(p => p.Localidades)
                .HasForeignKey(l => l.ProvinciaId);

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