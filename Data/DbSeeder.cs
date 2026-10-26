using Microsoft.EntityFrameworkCore;
using Modelo.Dominio;

namespace Data
{
    /// <summary>
    /// Carga datos de prueba (personas, usuarios, complejos, horarios, canchas, precios y turnos).
    /// Es idempotente: si ya existe el cliente01@example.com no vuelve a ejecutarse.
    /// Todos los CUIT, DNI, mails y telefonos son ficticios.
    /// </summary>
    public static class DbSeeder
    {
        // Configuracion de cada complejo: tipos de cancha (Nro = posicion + 1), cancha inactiva (0 = ninguna),
        // horarios (hora de apertura/cierre para semana, sabado y domingo) y factor de precio por zona.
        private sealed record Cfg(
            int[] Tipos, int NroInactiva,
            int ApSem, int CiSem, int ApSab, int CiSab, int ApDom, int CiDom,
            decimal Factor);

        // Precio base por hora segun TipoCancha.Id (en pesos)
        private static readonly Dictionary<int, decimal> PrecioBasePorTipo = new()
        {
            [1] = 150000m, // Futbol 11
            [2] = 45000m,  // Futbol 5
            [3] = 70000m,  // Futbol 7
            [4] = 40000m,  // Futsal
            [5] = 36000m,  // Padel
            [6] = 25000m,  // Tenis
            [7] = 10000m,  // Ping Pong
            [8] = 80000m,  // Hockey
            [9] = 40000m,  // Basket
            [10] = 35000m  // Voley
        };

        // 1 = lunes ... 7 = domingo (ajustar si en tu app la convencion es otra)
        private static int NroDia(DateOnly f) => ((int)f.DayOfWeek + 6) % 7 + 1;

        public static async Task SeedAsync(AplicacionDbContext db)
        {
            if (await db.Usuarios.AnyAsync(u => u.Email == "cliente01@example.com"))
                return;

            var rnd = new Random(2026); // semilla fija: siempre los mismos datos
            var hoy = DateOnly.FromDateTime(DateTime.Now);

            var hashCliente = BCrypt.Net.BCrypt.HashPassword("cliente123");
            var hashEncargado = BCrypt.Net.BCrypt.HashPassword("encargado123");
            var hashDueno = BCrypt.Net.BCrypt.HashPassword("dueno123");

            // ------------------------------------------------------------------
            // 1. PERSONAS JURIDICAS + DUEÑOS (TipoUsuarioId = 4)
            // ------------------------------------------------------------------
            var juridicas = new[]
            {
                new PersonaJuridica("30712345674", "Deportes del Litoral S.R.L."),
                new PersonaJuridica("30698765432", "Sport Centro Argentina S.A."),
                new PersonaJuridica("30711122233", "Grupo Cancha Viva S.A.")
            };
            db.PersonaJuridicas.AddRange(juridicas);

            var duenos = juridicas
                .Select((pj, i) => new Usuario($"dueno{i + 1}@example.com", $"34155510{i:00}", hashDueno, 4, null, pj.Cuit))
                .ToList();

            // ------------------------------------------------------------------
            // 2. ENCARGADOS (TipoUsuarioId = 2) con su PersonaFisica. Uno por cada complejo nuevo.
            // ------------------------------------------------------------------
            var encNombres = new[]
            {
                ("Marcelo", "Giménez"), ("Laura", "Paredes"), ("Sergio", "Acosta"),
                ("Natalia", "Benítez"), ("Hernán", "Villalba"), ("Julieta", "Roldán")
            };
            var encPersonas = encNombres
                .Select((n, i) => new PersonaFisica(n.Item1, n.Item2, (27_100_000 + i * 531_117).ToString(),
                                                    new DateOnly(1980 + i * 2, 3 + i, 10 + i)))
                .ToList();
            var encargados = encPersonas
                .Select((p, i) => new Usuario($"encargado.nuevo{i + 1}@example.com", $"34155520{i:00}", hashEncargado, 2, p.Dni))
                .ToList();

            // ------------------------------------------------------------------
            // 3. CLIENTES (TipoUsuarioId = 3) con su PersonaFisica
            // ------------------------------------------------------------------
            string[] nombres = { "Lucas", "Martina", "Joaquín", "Valentina", "Santiago", "Camila", "Mateo", "Sofía",
                                 "Nicolás", "Agustina", "Tomás", "Florencia", "Franco", "Milagros", "Bruno" };
            string[] apellidos = { "Fernández", "Rodríguez", "González", "López", "Martínez", "Pérez", "Sánchez", "Romero",
                                   "Díaz", "Álvarez", "Torres", "Ruiz", "Domínguez", "Gutiérrez", "Castro" };

            var clientePersonas = new List<PersonaFisica>();
            var clientes = new List<Usuario>();
            for (int i = 0; i < 30; i++)
            {
                var n = nombres[i % nombres.Length];
                var a = apellidos[(i * 7 + 3 + i / 15) % apellidos.Length];
                var dni = (35_000_000 + i * 417_311).ToString();
                clientePersonas.Add(new PersonaFisica(n, a, dni, new DateOnly(1985 + i % 20, 1 + i % 12, 1 + i % 28)));
                clientes.Add(new Usuario($"cliente{i + 1:00}@example.com", $"34156{i:000000}", hashCliente, 3, dni));
            }

            db.PersonaFisicas.AddRange(encPersonas);
            db.PersonaFisicas.AddRange(clientePersonas);
            db.Usuarios.AddRange(duenos);
            db.Usuarios.AddRange(encargados);
            db.Usuarios.AddRange(clientes);
            await db.SaveChangesAsync(); // aca se generan los Id de los usuarios

            // ------------------------------------------------------------------
            // 4. COMPLEJOS NUEVOS (los Id 1 y 2 ya vienen del HasData)
            // ------------------------------------------------------------------
            var nuevos = new (string Nombre, string Dir, int Loc, int Dueno, Cfg Cfg)[]
            {
                ("Complejo Los Pinos",      "Av. Pellegrini 2450",     102, 0, new Cfg(new[] { 2, 2, 2, 3, 5, 5 }, 0,  9, 23,  9, 23, 10, 22, 1.00m)), // Rosario
                ("Club La Redonda",         "Bv. Gálvez 1830",         101, 0, new Cfg(new[] { 1, 3, 3, 5, 6 },    5, 10, 23, 10, 23, 10, 22, 0.90m)), // Santa Fe Capital
                ("Cordobés Sport",          "Av. Colón 3120",           26, 1, new Cfg(new[] { 2, 3, 5, 5, 5 },    0,  8, 23,  9, 23, 10, 21, 0.95m)), // Córdoba
                ("Arena Cuyo",              "Av. San Martín 980",       61, 1, new Cfg(new[] { 2, 2, 3, 5, 10 },   0, 10, 23, 10, 23, 11, 22, 0.95m)), // Mendoza
                ("Palermo Fútbol Club",     "Honduras 4650",             6, 2, new Cfg(new[] { 2, 2, 2, 2, 3 },    0, 12, 23, 10, 23, 10, 22, 1.30m)), // CABA
                ("Costa Sport",             "Av. Independencia 2210",    2, 2, new Cfg(new[] { 2, 3, 5, 5, 9 },    0, 10, 23, 10, 23, 10, 22, 1.10m)), // Mar del Plata
            };

            var complejosNuevos = nuevos
                .Select((c, i) => new Complejo(c.Dir, c.Nombre, duenos[c.Dueno].Id, encargados[i].Id, c.Loc))
                .ToList();
            db.Complejos.AddRange(complejosNuevos);
            await db.SaveChangesAsync(); // genera los Id de los complejos

            // Mapa Id de complejo -> configuracion (incluye los 2 complejos del HasData si existen)
            var configs = new Dictionary<int, Cfg>();
            var existentes = new Dictionary<int, Cfg>
            {
                [1] = new Cfg(new[] { 2, 2, 3, 5 }, 0, 9, 23, 9, 23, 10, 22, 0.85m),
                [2] = new Cfg(new[] { 2, 2, 3, 3, 4 }, 5, 9, 23, 9, 23, 10, 22, 0.85m), // la cancha 5 (Futsal) queda inactiva
            };
            foreach (var kv in existentes)
                if (await db.Complejos.AnyAsync(c => c.Id == kv.Key))
                    configs[kv.Key] = kv.Value;
            for (int i = 0; i < complejosNuevos.Count; i++)
                configs[complejosNuevos[i].Id] = nuevos[i].Cfg;

            // ------------------------------------------------------------------
            // 5. HORARIOS, CANCHAS Y PRECIOS
            // ------------------------------------------------------------------
            var horarios = new Dictionary<(int Complejo, int Dia), (TimeOnly Ap, TimeOnly Ci)>();
            var mult = new[] { 1.00m, 1.20m, 1.40m };
            var fechasPrecio = new[] { hoy.AddMonths(-8), hoy.AddMonths(-4), hoy.AddMonths(-1) }; // siempre <= hoy

            foreach (var (cid, cfg) in configs)
            {
                for (int dia = 1; dia <= 7; dia++)
                {
                    var (ap, ci) = dia <= 5 ? (cfg.ApSem, cfg.CiSem)
                                 : dia == 6 ? (cfg.ApSab, cfg.CiSab)
                                            : (cfg.ApDom, cfg.CiDom);
                    var apertura = new TimeOnly(ap, 0);
                    var cierre = new TimeOnly(ci, 0);
                    horarios[(cid, dia)] = (apertura, cierre);
                    db.Horarios.Add(new Horario(cid, dia, apertura, cierre));
                }

                for (int i = 0; i < cfg.Tipos.Length; i++)
                {
                    int nro = i + 1;
                    int tipo = cfg.Tipos[i];
                    var estado = nro == cfg.NroInactiva ? "Inactiva" : "Activa";
                    db.Canchas.Add(new Cancha(nro, tipo, cid, estado));

                    for (int p = 0; p < 3; p++)
                    {
                        var baseP = Math.Round(PrecioBasePorTipo[tipo] * cfg.Factor * mult[p] / 500m) * 500m;
                        var sena = Math.Round(baseP * 0.30m / 100m) * 100m;
                        var adicional = Math.Round(baseP * 0.10m / 100m) * 100m;
                        db.Precios.Add(new Precio(baseP, adicional, sena, fechasPrecio[p], cid, nro));
                    }
                }
            }
            await db.SaveChangesAsync();

            // ------------------------------------------------------------------
            // 6. TURNOS (sin solapamientos, dentro del horario y solo en canchas activas)
            // ------------------------------------------------------------------
            var clienteIds = clientes.Select(c => c.Id).ToList();
            var externos = new[]
            {
                ("Matías", "Ferreyra"), ("Gonzalo", "Medina"), ("Rocío", "Quiroga"), ("Ezequiel", "Sosa"),
                ("Carolina", "Herrera"), ("Pablo", "Navarro"), ("Lucía", "Cabrera"), ("Diego", "Molina"),
                ("Andrea", "Ríos"), ("Facundo", "Luna")
            };
            var motivos = new[]
            {
                "El cliente avisó que no puede asistir", "Cancelado por lluvia",
                "Cancha en mantenimiento", "Falta de jugadores"
            };

            var ocupados = new Dictionary<(int, int, DateOnly), List<(TimeOnly Ini, TimeOnly Fin)>>();

            bool TryReservar(int cid, int nro, DateOnly f, TimeOnly ini, TimeOnly fin)
            {
                var h = horarios[(cid, NroDia(f))];
                if (fin <= ini || ini < h.Ap || fin > h.Ci) return false;
                var key = (cid, nro, f);
                if (!ocupados.TryGetValue(key, out var lista))
                    ocupados[key] = lista = new();
                if (lista.Any(x => ini < x.Fin && x.Ini < fin)) return false;
                lista.Add((ini, fin));
                return true;
            }

            Turno NuevoTurno(int? clienteId, (string N, string A) ext, TimeOnly ini, TimeOnly fin,
                             int tipo, int cid, int nro, DateOnly f)
                => clienteId.HasValue
                    ? new Turno(ini, fin, clienteId, tipo, cid, nro, f)
                    : new Turno(ini, fin, ext.N, ext.A, tipo, cid, nro, f);

            var turnos = new List<Turno>();

            foreach (var (cid, cfg) in configs)
            {
                var activas = Enumerable.Range(1, cfg.Tipos.Length).Where(n => n != cfg.NroInactiva).ToArray();
                int creados = 0, intentos = 0;

                while (creados < 22 && intentos++ < 1000)
                {
                    var nro = activas[rnd.Next(activas.Length)];
                    var fecha = hoy.AddDays(rnd.Next(-21, 29));
                    var h = horarios[(cid, NroDia(fecha))];
                    var r = rnd.NextDouble();
                    int? clienteId = rnd.NextDouble() < 0.7 ? clienteIds[rnd.Next(clienteIds.Count)] : null;
                    var ext = externos[rnd.Next(externos.Length)];

                    if (r < 0.75) // Normal: 1 hora
                    {
                        var ini = new TimeOnly(rnd.Next(h.Ap.Hour, h.Ci.Hour), 0);
                        var fin = ini.AddHours(1);
                        if (!TryReservar(cid, nro, fecha, ini, fin)) continue;

                        var t = NuevoTurno(clienteId, ext, ini, fin, 1, cid, nro, fecha);
                        if (rnd.NextDouble() < 0.10)
                            t.Cancelar(motivos[rnd.Next(motivos.Length)]);
                        turnos.Add(t);
                        creados++;
                    }
                    else if (r < 0.90) // Fijo: mismo dia y hora durante 4 semanas
                    {
                        var primera = hoy.AddDays(rnd.Next(-14, 1));
                        var ini = new TimeOnly(rnd.Next(18, h.Ci.Hour), 0);
                        var fin = ini.AddHours(1);
                        for (int k = 0; k < 4; k++)
                        {
                            var f = primera.AddDays(7 * k);
                            if (!TryReservar(cid, nro, f, ini, fin)) continue;
                            turnos.Add(NuevoTurno(clienteId, ext, ini, fin, 2, cid, nro, f));
                            creados++;
                        }
                    }
                    else // Evento: 3 horas, solo fin de semana
                    {
                        if (fecha.DayOfWeek != DayOfWeek.Saturday && fecha.DayOfWeek != DayOfWeek.Sunday) continue;
                        var ini = new TimeOnly(rnd.Next(h.Ap.Hour, h.Ci.Hour - 2), 0);
                        var fin = ini.AddHours(3);
                        if (!TryReservar(cid, nro, fecha, ini, fin)) continue;
                        turnos.Add(NuevoTurno(clienteId, ext, ini, fin, 3, cid, nro, fecha));
                        creados++;
                    }
                }
            }

            db.Turnos.AddRange(turnos);
            await db.SaveChangesAsync();

            Console.WriteLine($"[Seed] Complejos: {configs.Count} | Clientes: {clientes.Count} | Turnos: {turnos.Count}");
        }
    }
}
