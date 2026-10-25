IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [PersonaFisicas] (
    [Dni] nvarchar(450) NOT NULL,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [FechaNacimiento] date NOT NULL,
    CONSTRAINT [PK_PersonaFisicas] PRIMARY KEY ([Dni])
);
GO

CREATE TABLE [PersonaJuridicas] (
    [Cuit] nvarchar(450) NOT NULL,
    [RazonSocial] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_PersonaJuridicas] PRIMARY KEY ([Cuit])
);
GO

CREATE TABLE [Provincias] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Provincias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoCanchas] (
    [Id] int NOT NULL IDENTITY,
    [Deporte] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TipoCanchas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoTurnos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TipoTurnos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoUsuarios] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TipoUsuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Localidades] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [CodigoPostal] nvarchar(max) NOT NULL,
    [ProvinciaId] int NOT NULL,
    CONSTRAINT [PK_Localidades] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Localidades_Provincias_ProvinciaId] FOREIGN KEY ([ProvinciaId]) REFERENCES [Provincias] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Telefono] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [TipoUsuarioId] int NOT NULL,
    [PersonaFisicaDni] nvarchar(450) NULL,
    [PersonaJuridicaCuit] nvarchar(450) NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_PersonaFisicas_PersonaFisicaDni] FOREIGN KEY ([PersonaFisicaDni]) REFERENCES [PersonaFisicas] ([Dni]),
    CONSTRAINT [FK_Usuarios_PersonaJuridicas_PersonaJuridicaCuit] FOREIGN KEY ([PersonaJuridicaCuit]) REFERENCES [PersonaJuridicas] ([Cuit]),
    CONSTRAINT [FK_Usuarios_TipoUsuarios_TipoUsuarioId] FOREIGN KEY ([TipoUsuarioId]) REFERENCES [TipoUsuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Complejos] (
    [Id] int NOT NULL IDENTITY,
    [Direccion] nvarchar(max) NOT NULL,
    [Nombre] nvarchar(max) NOT NULL,
    [LocalidadId] int NOT NULL,
    [EncargadoId] int NOT NULL,
    [DueñoId] int NOT NULL,
    CONSTRAINT [PK_Complejos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Complejos_Localidades_LocalidadId] FOREIGN KEY ([LocalidadId]) REFERENCES [Localidades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Complejos_Usuarios_DueñoId] FOREIGN KEY ([DueñoId]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Complejos_Usuarios_EncargadoId] FOREIGN KEY ([EncargadoId]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Canchas] (
    [Nro] int NOT NULL,
    [ComplejoId] int NOT NULL,
    [TipoCanchaId] int NOT NULL,
    CONSTRAINT [PK_Canchas] PRIMARY KEY ([ComplejoId], [Nro]),
    CONSTRAINT [FK_Canchas_Complejos_ComplejoId] FOREIGN KEY ([ComplejoId]) REFERENCES [Complejos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Canchas_TipoCanchas_TipoCanchaId] FOREIGN KEY ([TipoCanchaId]) REFERENCES [TipoCanchas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Horarios] (
    [ComplejoId] int NOT NULL,
    [NroDia] int NOT NULL,
    [HoraApertura] time NOT NULL,
    [HoraCierre] time NOT NULL,
    CONSTRAINT [PK_Horarios] PRIMARY KEY ([ComplejoId], [NroDia]),
    CONSTRAINT [FK_Horarios_Complejos_ComplejoId] FOREIGN KEY ([ComplejoId]) REFERENCES [Complejos] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Precios] (
    [FechaDesde] date NOT NULL,
    [ComplejoId] int NOT NULL,
    [CanchaNro] int NOT NULL,
    [Id] int NOT NULL,
    [PrecioBase] decimal(18,2) NOT NULL,
    [PrecioAdicional] decimal(18,2) NOT NULL,
    [PrecioSena] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Precios] PRIMARY KEY ([ComplejoId], [CanchaNro], [FechaDesde]),
    CONSTRAINT [FK_Precios_Canchas_ComplejoId_CanchaNro] FOREIGN KEY ([ComplejoId], [CanchaNro]) REFERENCES [Canchas] ([ComplejoId], [Nro]) ON DELETE CASCADE
);
GO

CREATE TABLE [Turnos] (
    [Id] int NOT NULL IDENTITY,
    [HoraInicio] time NOT NULL,
    [HoraFin] time NOT NULL,
    [Estado] nvarchar(max) NOT NULL,
    [MotivoCancelacion] nvarchar(max) NULL,
    [ClienteId] int NOT NULL,
    [TipoTurnoId] int NOT NULL,
    [ComplejoId] int NOT NULL,
    [CanchaNro] int NOT NULL,
    [Fecha] date NOT NULL,
    CONSTRAINT [PK_Turnos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Turnos_Canchas_ComplejoId_CanchaNro] FOREIGN KEY ([ComplejoId], [CanchaNro]) REFERENCES [Canchas] ([ComplejoId], [Nro]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Turnos_Complejos_ComplejoId] FOREIGN KEY ([ComplejoId]) REFERENCES [Complejos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Turnos_TipoTurnos_TipoTurnoId] FOREIGN KEY ([TipoTurnoId]) REFERENCES [TipoTurnos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Turnos_Usuarios_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Canchas_TipoCanchaId] ON [Canchas] ([TipoCanchaId]);
GO

CREATE INDEX [IX_Complejos_DueñoId] ON [Complejos] ([DueñoId]);
GO

CREATE UNIQUE INDEX [IX_Complejos_EncargadoId] ON [Complejos] ([EncargadoId]);
GO

CREATE INDEX [IX_Complejos_LocalidadId] ON [Complejos] ([LocalidadId]);
GO

CREATE INDEX [IX_Localidades_ProvinciaId] ON [Localidades] ([ProvinciaId]);
GO

CREATE INDEX [IX_Turnos_ClienteId] ON [Turnos] ([ClienteId]);
GO

CREATE INDEX [IX_Turnos_ComplejoId_CanchaNro] ON [Turnos] ([ComplejoId], [CanchaNro]);
GO

CREATE INDEX [IX_Turnos_TipoTurnoId] ON [Turnos] ([TipoTurnoId]);
GO

CREATE INDEX [IX_Usuarios_PersonaFisicaDni] ON [Usuarios] ([PersonaFisicaDni]);
GO

CREATE INDEX [IX_Usuarios_PersonaJuridicaCuit] ON [Usuarios] ([PersonaJuridicaCuit]);
GO

CREATE INDEX [IX_Usuarios_TipoUsuarioId] ON [Usuarios] ([TipoUsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260826222936_Inicial', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion') AND [object_id] = OBJECT_ID(N'[TipoUsuarios]'))
    SET IDENTITY_INSERT [TipoUsuarios] ON;
INSERT INTO [TipoUsuarios] ([Id], [Descripcion])
VALUES (1, N'Administrador'),
(2, N'Encargado'),
(3, N'Cliente');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion') AND [object_id] = OBJECT_ID(N'[TipoUsuarios]'))
    SET IDENTITY_INSERT [TipoUsuarios] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260831144810_SeedTipoUsuario', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Deporte') AND [object_id] = OBJECT_ID(N'[TipoCanchas]'))
    SET IDENTITY_INSERT [TipoCanchas] ON;
INSERT INTO [TipoCanchas] ([Id], [Deporte])
VALUES (1, N'Futbol 11'),
(2, N'Futbol 5'),
(3, N'Futbol 7'),
(4, N'Futsal'),
(5, N'Padel'),
(6, N'Tenis'),
(7, N'Ping Pong'),
(8, N'Hockey'),
(9, N'Basket'),
(10, N'Voley');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Deporte') AND [object_id] = OBJECT_ID(N'[TipoCanchas]'))
    SET IDENTITY_INSERT [TipoCanchas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'Nombre') AND [object_id] = OBJECT_ID(N'[TipoTurnos]'))
    SET IDENTITY_INSERT [TipoTurnos] ON;
INSERT INTO [TipoTurnos] ([Id], [Descripcion], [Nombre])
VALUES (1, N'Turno basico', N'Normal'),
(2, N'Turno reservado periodicamente', N'Fijo'),
(3, N'Turno reservado para un evento en particular', N'Evento');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'Nombre') AND [object_id] = OBJECT_ID(N'[TipoTurnos]'))
    SET IDENTITY_INSERT [TipoTurnos] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260831154718_SeedTipoCanchaTurno', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Provincias]'))
    SET IDENTITY_INSERT [Provincias] ON;
INSERT INTO [Provincias] ([Id], [Nombre])
VALUES (1, N'Buenos Aires'),
(2, N'Ciudad Autónoma de Buenos Aires'),
(3, N'Catamarca'),
(4, N'Chaco'),
(5, N'Chubut'),
(6, N'Córdoba'),
(7, N'Corrientes'),
(8, N'Entre Ríos'),
(9, N'Formosa'),
(10, N'Jujuy'),
(11, N'La Pampa'),
(12, N'La Rioja'),
(13, N'Mendoza'),
(14, N'Misiones'),
(15, N'Neuquén'),
(16, N'Río Negro'),
(17, N'Salta'),
(18, N'San Juan'),
(19, N'San Luis'),
(20, N'Santa Cruz'),
(21, N'Santa Fe'),
(22, N'Santiago del Estero'),
(23, N'Tierra del Fuego, Antártida e Islas del Atlántico Sur'),
(24, N'Tucumán');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre') AND [object_id] = OBJECT_ID(N'[Provincias]'))
    SET IDENTITY_INSERT [Provincias] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion') AND [object_id] = OBJECT_ID(N'[TipoUsuarios]'))
    SET IDENTITY_INSERT [TipoUsuarios] ON;
INSERT INTO [TipoUsuarios] ([Id], [Descripcion])
VALUES (4, N'Dueño');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion') AND [object_id] = OBJECT_ID(N'[TipoUsuarios]'))
    SET IDENTITY_INSERT [TipoUsuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CodigoPostal', N'Nombre', N'ProvinciaId') AND [object_id] = OBJECT_ID(N'[Localidades]'))
    SET IDENTITY_INSERT [Localidades] ON;
INSERT INTO [Localidades] ([Id], [CodigoPostal], [Nombre], [ProvinciaId])
VALUES (1, N'B1900', N'La Plata', 1),
(2, N'B7600', N'Mar del Plata', 1),
(3, N'B8000', N'Bahía Blanca', 1),
(4, N'B7000', N'Tandil', 1),
(5, N'B2900', N'San Nicolás de los Arroyos', 1),
(6, N'C1425', N'Palermo', 2),
(7, N'C1428', N'Belgrano', 2),
(8, N'C1405', N'Caballito', 2),
(9, N'C1063', N'San Telmo', 2),
(10, N'C1113', N'Recoleta', 2),
(11, N'K4700', N'San Fernando del Valle de Catamarca', 3),
(12, N'K4750', N'Belén', 3),
(13, N'K4740', N'Andalgalá', 3),
(14, N'K5340', N'Tinogasta', 3),
(15, N'K4139', N'Santa María', 3),
(16, N'H3500', N'Resistencia', 4),
(17, N'H3700', N'Presidencia Roque Sáenz Peña', 4),
(18, N'H3540', N'Villa Ángela', 4),
(19, N'H3732', N'General Pinedo', 4),
(20, N'H3730', N'Charata', 4),
(21, N'U9103', N'Rawson', 5),
(22, N'U9120', N'Puerto Madryn', 5),
(23, N'U9100', N'Trelew', 5),
(24, N'U9000', N'Comodoro Rivadavia', 5),
(25, N'U9200', N'Esquel', 5),
(26, N'X5000', N'Córdoba Capital', 6),
(27, N'X5152', N'Villa Carlos Paz', 6),
(28, N'X5800', N'Río Cuarto', 6),
(29, N'X5900', N'Villa María', 6),
(30, N'X2400', N'San Francisco', 6),
(31, N'W3400', N'Corrientes Capital', 7),
(32, N'W3450', N'Goya', 7),
(33, N'W3230', N'Paso de los Libres', 7),
(34, N'W3460', N'Curuzú Cuatiá', 7),
(35, N'W3470', N'Mercedes', 7),
(36, N'E3100', N'Paraná', 8),
(37, N'E3200', N'Concordia', 8),
(38, N'E2820', N'Gualeguaychú', 8),
(39, N'E3260', N'Concepción del Uruguay', 8),
(40, N'E3153', N'Victoria', 8),
(41, N'P3600', N'Formosa Capital', 9),
(42, N'P3610', N'Clorinda', 9);
INSERT INTO [Localidades] ([Id], [CodigoPostal], [Nombre], [ProvinciaId])
VALUES (43, N'P3606', N'Pirané', 9),
(44, N'P3603', N'El Colorado', 9),
(45, N'P3630', N'Las Lomitas', 9),
(46, N'Y4600', N'San Salvador de Jujuy', 10),
(47, N'Y4500', N'San Pedro de Jujuy', 10),
(48, N'Y4624', N'Tilcara', 10),
(49, N'Y4630', N'Humahuaca', 10),
(50, N'Y4650', N'La Quiaca', 10),
(51, N'L6300', N'Santa Rosa', 11),
(52, N'L6360', N'General Pico', 11),
(53, N'L6303', N'Toay', 11),
(54, N'L6200', N'Realicó', 11),
(55, N'L8200', N'General Acha', 11),
(56, N'F5300', N'La Rioja Capital', 12),
(57, N'F5360', N'Chilecito', 12),
(58, N'F5310', N'Aimogasta', 12),
(59, N'F5380', N'Chamical', 12),
(60, N'F5350', N'Villa Unión', 12),
(61, N'M5500', N'Mendoza Capital', 13),
(62, N'M5600', N'San Rafael', 13),
(63, N'M5501', N'Godoy Cruz', 13),
(64, N'M5515', N'Maipú', 13),
(65, N'M5613', N'Malargüe', 13),
(66, N'N3300', N'Posadas', 14),
(67, N'N3370', N'Puerto Iguazú', 14),
(68, N'N3360', N'Oberá', 14),
(69, N'N3380', N'Eldorado', 14),
(70, N'N3350', N'Apostoles', 14),
(71, N'Q8300', N'Neuquén Capital', 15),
(72, N'Q8370', N'San Martín de los Andes', 15),
(73, N'Q8407', N'Villa La Angostura', 15),
(74, N'Q8340', N'Zapala', 15),
(75, N'Q8322', N'Cutral Có', 15),
(76, N'R8500', N'Viedma', 16),
(77, N'R8400', N'San Carlos de Bariloche', 16),
(78, N'R8332', N'General Roca', 16),
(79, N'R8324', N'Cipolletti', 16),
(80, N'R8521', N'Las Grutas', 16),
(81, N'A4400', N'Salta Capital', 17),
(82, N'A4427', N'Cafayate', 17),
(83, N'A4530', N'San Ramón de la Nueva Orán', 17),
(84, N'A4560', N'Tartagal', 17);
INSERT INTO [Localidades] ([Id], [CodigoPostal], [Nombre], [ProvinciaId])
VALUES (85, N'A4432', N'General Güemes', 17),
(86, N'J5400', N'San Juan Capital', 18),
(87, N'J5425', N'Rawson', 18),
(88, N'J5413', N'Chimbas', 18),
(89, N'J5442', N'Caucete', 18),
(90, N'J5460', N'Jáchal', 18),
(91, N'D5700', N'San Luis Capital', 19),
(92, N'D5730', N'Villa Mercedes', 19),
(93, N'D5881', N'Merlo', 19),
(94, N'D5703', N'La Punta', 19),
(95, N'D5738', N'Justo Daract', 19),
(96, N'Z9400', N'Río Gallegos', 20),
(97, N'Z9405', N'El Calafate', 20),
(98, N'Z9011', N'Caleta Olivia', 20),
(99, N'Z9050', N'Puerto Deseado', 20),
(100, N'Z9301', N'El Chaltén', 20),
(101, N'S3000', N'Santa Fe Capital', 21),
(102, N'S2000', N'Rosario', 21),
(103, N'S2300', N'Rafaela', 21),
(104, N'S2600', N'Venado Tuerto', 21),
(105, N'S3500', N'Reconquista', 21),
(106, N'G4200', N'Santiago del Estero Capital', 22),
(107, N'G4200', N'La Banda', 22),
(108, N'G4220', N'Termas de Río Hondo', 22),
(109, N'G3760', N'Añatuya', 22),
(110, N'G4230', N'Frías', 22),
(111, N'V9410', N'Ushuaia', 23),
(112, N'V9420', N'Río Grande', 23),
(113, N'V9412', N'Tolhuin', 23),
(114, N'V9410', N'Puerto Almanza', 23),
(115, N'V9420', N'San Sebastián', 23),
(116, N'T4000', N'San Miguel de Tucumán', 24),
(117, N'T4107', N'Yerba Buena', 24),
(118, N'T4137', N'Tafí del Valle', 24),
(119, N'T4147', N'Concepción', 24),
(120, N'T4109', N'Banda del Río Salí', 24);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CodigoPostal', N'Nombre', N'ProvinciaId') AND [object_id] = OBJECT_ID(N'[Localidades]'))
    SET IDENTITY_INSERT [Localidades] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260831194213_SeedProvinciasYLocalidades', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Precios]') AND [c].[name] = N'Id');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Precios] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Precios] DROP COLUMN [Id];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260831214127_QuitarIdDePrecio', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Cuit', N'RazonSocial') AND [object_id] = OBJECT_ID(N'[PersonaJuridicas]'))
    SET IDENTITY_INSERT [PersonaJuridicas] ON;
INSERT INTO [PersonaJuridicas] ([Cuit], [RazonSocial])
VALUES (N'20123456789', N'Complejo Deportivo La Canchita');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Cuit', N'RazonSocial') AND [object_id] = OBJECT_ID(N'[PersonaJuridicas]'))
    SET IDENTITY_INSERT [PersonaJuridicas] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260907215751_SeedPersonaJuridica', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password', N'PersonaFisicaDni', N'PersonaJuridicaCuit', N'Telefono', N'TipoUsuarioId') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Email], [Password], [PersonaFisicaDni], [PersonaJuridicaCuit], [Telefono], [TipoUsuarioId])
VALUES (1, N'admin@gmail.com', N'admin', NULL, NULL, N'12345678', 1),
(2, N'dueño@gmail.com', N'dueño', NULL, N'20123456789', N'22446688', 4),
(3, N'encargado@gmail.com', N'encargado', NULL, NULL, N'987654321', 2),
(4, N'encargado2@gmail.com', N'encargado2', NULL, NULL, N'113355799', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password', N'PersonaFisicaDni', N'PersonaJuridicaCuit', N'Telefono', N'TipoUsuarioId') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direccion', N'DueñoId', N'EncargadoId', N'LocalidadId', N'Nombre') AND [object_id] = OBJECT_ID(N'[Complejos]'))
    SET IDENTITY_INSERT [Complejos] ON;
INSERT INTO [Complejos] ([Id], [Direccion], [DueñoId], [EncargadoId], [LocalidadId], [Nombre])
VALUES (1, N'Calle Falsa 123', 1, 3, 15, N'Complejo Deportivo La Canchita'),
(2, N'Avenida Siempre Viva 456', 1, 4, 15, N'Complejo Deportivo El Golazo');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Direccion', N'DueñoId', N'EncargadoId', N'LocalidadId', N'Nombre') AND [object_id] = OBJECT_ID(N'[Complejos]'))
    SET IDENTITY_INSERT [Complejos] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260907220535_SeedCredenciales', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$AlwmwydZgOtVAim4taaFnOVeuSkOwKCqWDUiWtGGlKyko.nZeTnCW'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$BDMfISYyMo0LgRNqQp1Xl.pJ6LRnwqZKg8kR2xIy8oTOEKV2nITny'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$2NnPNWqlDO.Q.oXyP.me9ew2bQQjl9XSJWJkdSVrKTwa0uC5z7yNK'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$23p8zZjfS6Jo3.2yTFp.k.jkyJ9rtnEUvokDGexDrHSkTrIoJJWTq'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260907221118_SeedCredencialesHasheadas', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$EAqjvEiH2cB0C/dKNh03wOM.E6CYSchYkc4Clnqh45VqkBcr.AhSm'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$OvvqI5/YCzZsVR2mOiRCVOz2wT67pTLkGzKFuWJW.uetJKyWYTyQa'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$ZL/WkCM9e5GTJhB8iL.sou3mwCSbjQywNpbYYkEBS.j7D93vJyIKe'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$yq2due8fURIT8yWQTyC3MOk2x6b.XYOg2H5VGMXn4GVvVD4gi1cAG'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260907222428_CorreccionId', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Complejos] SET [DueñoId] = 2
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Complejos] SET [DueñoId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$nbToVlWyDCWqbz.kzL9n8ONEKU0QXSXwmIEPp1GJ89SuxK1IVNLWO'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$ffGXzD1pY8Aw3Q4tpikSa.gHyd8A7zXHtTD0HDewIqG2b3J6yIvn2'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$wAxPtWlkZh//qsM0h0M6Aujxy58RZWmZAOib4ZjnhRavu2rCJOR5.'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$nCOULbax26.BO2tfpIDmEOO3q4jdZX.BuN2rQhotGr8OpWxzFJyFS'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260907222627_CorreccionId2.0', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$zl4GOSzveR7bq6Yl7Wd/U.jy2SW/Sofyr0C/WODRFa4DTqGGBRNwe'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$GTnfCLpOGQoqFgqMBkW8Ruj7CE4i3MM8nMGdx3RvqvDb7SMJu5NIe'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$ZUIPGkgfZrfsmDBWt7dUpepdW//yJwwi0kBUZSzpDLfI8lhye8E0e'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$2NF2MzRcz8cie87iRxStRuvyy8cH46DReWMUREY1ocx0JHmGonQym'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260928230740_AgregarSeedData', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$LbCwDAJv8bVMsm3p9ujXc.JM6bIoxuHC.9SzbSU9EZ0PuJKY.yCHS'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Email] = N'dueno@gmail.com', [Password] = N'$2a$11$Hi20PlP5cwmApDwQSOeHDOAJLVwJcxOb4MyhQQMgW5O/mjzl/o8oe'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$WaDsK4xFAlHy8.LaQxLS3OfTvErIuEi/hf7LBhMgssqy2gi2KKg0y'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$iFOJ8TwfqP1TIBIX.xdlqefdwT6UNfIP6m3IoF9slgXHCECAk7Jbi'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261022212048_CambioEmailDueno', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Canchas] ADD [Estado] nvarchar(max) NOT NULL DEFAULT N'';
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$jun95TTLoS5js710EgaZoeXX3tLSWxmyD3YLCN5EKYyQZ2p/Cx3pK'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$VLqd0K/bGUq21tC.tyVfZ.Jhp5QJZxGARAJSqMNS9YdMMDlH8AP8C'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$FY6yO2.rhgBfyHmijurc8.9xjbsaX.p6uy/nXRap23lEYYAr1IETO'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$iC0uyQgaESKPi4eqOhOVw.d8Tc8H.yPbGgeEqQ6rVo/JyozTFYdeG'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261022232923_EstadoEnCancha', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Turnos] ADD [ApellidoClienteExterno] nvarchar(max) NULL;
GO

ALTER TABLE [Turnos] ADD [NombreClienteExterno] nvarchar(max) NULL;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$kH39W0j5XNlg0FQgk.IuaeT/UoT.N86B9YvitLYKmh5YmOWB9oHda'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$eddZ9sRuNHx6iLJmEYfg0ee.HXW22wjs/xp8zhaOP7VCENKJ2JWUm'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$aJ1e1QQBZV4RH538Md8gZusOZcjuOkh2aCGCvFFLYeGeLjPOysTrq'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$0ILOhhn64UYaQF7BEMAW8OzbiiaTgO1mTwzxEVi/qiG0sXGcKcTb2'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261024193414_AgregarClienteExternoATurno', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Turnos]') AND [c].[name] = N'ClienteId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Turnos] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Turnos] ALTER COLUMN [ClienteId] int NULL;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$mkEKyzBLcKpbkfMD7upQ8OpcTPJYx.wNP23tlvPnUtsz0fL6xTqA6'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$mqoRFVCt81CTPJqNoaZbduxULn9rDfs5awIJr3h35wXV/O7UygJYK'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$SSnCxJZRR2rOHa.XnYgsL.PrD8jZBop656Oi2Zi9DnfsyvaQ0HAx2'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$3t348wTP.x9VdVQgod6aBeKdgSfh2fydZY3n/m3fZQobYHnBO0JSm'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261024195504_HacerClienteIdNullableEnTurnos', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$C7UQHHb5oGQECOMAS3seFet3qwYv0fsD2nzCHFDzVWkLgSrl.106q'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$E/bnUVOZFFAtWVzeutwAc.PA6DdCzWu35w9eVt97p8dXsKLBc8FHu'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$gE3SAVQ8/I.zlfnn9a3zk.HyrrmKmJf0tQhI9mz2Sh4Z1CP97Eqp2'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$yB73wcWT.TBsdYx2XY4kkeKElyoK0dsNBe80Ks1ofjad.mQ9myVty'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261024195725_HacerClienteIdNullableEnTurnos2', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$Pl4AP3kRG/zFeyGILUity.2CvfYDtumLW.HfFgfOQ0tf8IXna./HC'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$YRksxgUS9L5DqbfxbMpPIOw.FEMeJi0sjZdlLoZ7B/xwMZFkUvzlC'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$6bQ8AkerSV0AJn0B3aD7W.w0mvEFke2XWBs5P7ng9uhHk9WpeFzSm'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [Password] = N'$2a$11$fNwkSDFR8brqbEukZJDcPuvgASbV/oLNnTDxqVUU.Ky7hL.6RuR1i'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261024202014_AgregarClienteExternoCampos', N'8.0.30');
GO

COMMIT;
GO

