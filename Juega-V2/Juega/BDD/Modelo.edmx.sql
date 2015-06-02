
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2015 16:10:50
-- Generated from EDMX file: C:\ProyectoDS\Juega-V2\Juega\BDD\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Juega];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FK1E2394DD1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Horario_Dia] DROP CONSTRAINT [FK_FK1E2394DD1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK1E2394DDF771FF35]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Horario_Dia] DROP CONSTRAINT [FK_FK1E2394DDF771FF35];
GO
IF OBJECT_ID(N'[dbo].[FK_FK312DCDED1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Solicitud_Equipo] DROP CONSTRAINT [FK_FK312DCDED1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK312DCDEDA62E925C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Solicitud_Equipo] DROP CONSTRAINT [FK_FK312DCDEDA62E925C];
GO
IF OBJECT_ID(N'[dbo].[FK_FK323934421862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo] DROP CONSTRAINT [FK_FK323934421862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK399306991862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Tecnico] DROP CONSTRAINT [FK_FK399306991862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK39930699A62E925C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Tecnico] DROP CONSTRAINT [FK_FK39930699A62E925C];
GO
IF OBJECT_ID(N'[dbo].[FK_FK3BBAF2251862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Denuncia] DROP CONSTRAINT [FK_FK3BBAF2251862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK3BBAF225A62E925C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Denuncia] DROP CONSTRAINT [FK_FK3BBAF225A62E925C];
GO
IF OBJECT_ID(N'[dbo].[FK_FK3BBAF225F771FF35]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Denuncia] DROP CONSTRAINT [FK_FK3BBAF225F771FF35];
GO
IF OBJECT_ID(N'[dbo].[FK_FK3F406CE31862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Valoracion] DROP CONSTRAINT [FK_FK3F406CE31862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK3F406CE3A62E925C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Valoracion] DROP CONSTRAINT [FK_FK3F406CE3A62E925C];
GO
IF OBJECT_ID(N'[dbo].[FK_FK3FBA4BEB1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Valoracion] DROP CONSTRAINT [FK_FK3FBA4BEB1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK3FBA4BEBF771FF35]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Valoracion] DROP CONSTRAINT [FK_FK3FBA4BEBF771FF35];
GO
IF OBJECT_ID(N'[dbo].[FK_FK550739B71862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Solicitud_AdminCancha] DROP CONSTRAINT [FK_FK550739B71862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK5F4FA4051862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComplejoDeportivo] DROP CONSTRAINT [FK_FK5F4FA4051862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK66723AB21862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Valoracion] DROP CONSTRAINT [FK_FK66723AB21862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7033D3A1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Foto] DROP CONSTRAINT [FK_FK7033D3A1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7033D3AF771FF35]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Foto] DROP CONSTRAINT [FK_FK7033D3AF771FF35];
GO
IF OBJECT_ID(N'[dbo].[FK_FK76644D7F1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha] DROP CONSTRAINT [FK_FK76644D7F1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK76644D7FE55E9EAC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha] DROP CONSTRAINT [FK_FK76644D7FE55E9EAC];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7786F1A31862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Token] DROP CONSTRAINT [FK_FK7786F1A31862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7932B0101862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Foto] DROP CONSTRAINT [FK_FK7932B0101862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7932B010A62E925C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Foto] DROP CONSTRAINT [FK_FK7932B010A62E925C];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7DE04BD41862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Jugador] DROP CONSTRAINT [FK_FK7DE04BD41862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7DE04BD44586AA08]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Jugador] DROP CONSTRAINT [FK_FK7DE04BD44586AA08];
GO
IF OBJECT_ID(N'[dbo].[FK_FK7DE04BD4A62E925C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipo_Jugador] DROP CONSTRAINT [FK_FK7DE04BD4A62E925C];
GO
IF OBJECT_ID(N'[dbo].[FK_FK817CBD8E1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Foto] DROP CONSTRAINT [FK_FK817CBD8E1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK903403341862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reto] DROP CONSTRAINT [FK_FK903403341862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK903403348204A257]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reto] DROP CONSTRAINT [FK_FK903403348204A257];
GO
IF OBJECT_ID(N'[dbo].[FK_FK90340334A62E925C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reto] DROP CONSTRAINT [FK_FK90340334A62E925C];
GO
IF OBJECT_ID(N'[dbo].[FK_FK9137113A1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora] DROP CONSTRAINT [FK_FK9137113A1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK9137113AC7910A3A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora] DROP CONSTRAINT [FK_FK9137113AC7910A3A];
GO
IF OBJECT_ID(N'[dbo].[FK_FK9CC16DB1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Reservacion] DROP CONSTRAINT [FK_FK9CC16DB1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FK9CC16DB559FCD51]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancha_Reservacion] DROP CONSTRAINT [FK_FK9CC16DB559FCD51];
GO
IF OBJECT_ID(N'[dbo].[FK_FK9E8FB9FD1862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_FK9E8FB9FD1862B0F6];
GO
IF OBJECT_ID(N'[dbo].[FK_FKA981D5251862B0F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Registro_Acceso] DROP CONSTRAINT [FK_FKA981D5251862B0F6];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cancha]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cancha];
GO
IF OBJECT_ID(N'[dbo].[Cancha_Foto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cancha_Foto];
GO
IF OBJECT_ID(N'[dbo].[Cancha_Horario_Dia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cancha_Horario_Dia];
GO
IF OBJECT_ID(N'[dbo].[Cancha_Horario_Dia_Hora]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cancha_Horario_Dia_Hora];
GO
IF OBJECT_ID(N'[dbo].[Cancha_Reservacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cancha_Reservacion];
GO
IF OBJECT_ID(N'[dbo].[Cancha_Valoracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cancha_Valoracion];
GO
IF OBJECT_ID(N'[dbo].[ComplejoDeportivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComplejoDeportivo];
GO
IF OBJECT_ID(N'[dbo].[Denuncia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Denuncia];
GO
IF OBJECT_ID(N'[dbo].[Equipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipo];
GO
IF OBJECT_ID(N'[dbo].[Equipo_Foto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipo_Foto];
GO
IF OBJECT_ID(N'[dbo].[Equipo_Jugador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipo_Jugador];
GO
IF OBJECT_ID(N'[dbo].[Equipo_Tecnico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipo_Tecnico];
GO
IF OBJECT_ID(N'[dbo].[Equipo_Valoracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipo_Valoracion];
GO
IF OBJECT_ID(N'[dbo].[Reto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reto];
GO
IF OBJECT_ID(N'[dbo].[Token]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Token];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Usuario_Foto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario_Foto];
GO
IF OBJECT_ID(N'[dbo].[Usuario_Registro_Acceso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario_Registro_Acceso];
GO
IF OBJECT_ID(N'[dbo].[Usuario_Solicitud_AdminCancha]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario_Solicitud_AdminCancha];
GO
IF OBJECT_ID(N'[dbo].[Usuario_Solicitud_Equipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario_Solicitud_Equipo];
GO
IF OBJECT_ID(N'[dbo].[Usuario_Valoracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario_Valoracion];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cancha'
CREATE TABLE [dbo].[Cancha] (
    [IdCancha] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NULL,
    [NumEspectadores] int  NULL,
    [Largo] int  NULL,
    [Ancho] int  NULL,
    [Valoracion] int  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdComplejoDeportivo] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Cancha_Foto'
CREATE TABLE [dbo].[Cancha_Foto] (
    [IdCancha_Foto] bigint IDENTITY(1,1) NOT NULL,
    [Foto] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdCancha] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Cancha_Horario_Dia'
CREATE TABLE [dbo].[Cancha_Horario_Dia] (
    [IdCancha_Horario_Dia] bigint IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdCancha] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Cancha_Horario_Dia_Hora'
CREATE TABLE [dbo].[Cancha_Horario_Dia_Hora] (
    [IdCancha_Horario_Dia_Hora] bigint IDENTITY(1,1) NOT NULL,
    [HoraDesde] datetime  NULL,
    [HoraHasta] datetime  NULL,
    [Precio] decimal(19,5)  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdCancha_Horario_Dia] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Cancha_Reservacion'
CREATE TABLE [dbo].[Cancha_Reservacion] (
    [IdCancha_Reservacion] bigint IDENTITY(1,1) NOT NULL,
    [FechaReservacion] datetime  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdCancha_Horario_Dia_Hora] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Cancha_Valoracion'
CREATE TABLE [dbo].[Cancha_Valoracion] (
    [IdCancha_Valoracion] bigint IDENTITY(1,1) NOT NULL,
    [Valoracion] int  NULL,
    [Comentario] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdCancha] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'ComplejoDeportivo'
CREATE TABLE [dbo].[ComplejoDeportivo] (
    [IdComplejoDeportivo] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NULL,
    [Direccion] nvarchar(100)  NULL,
    [Telefonos] nvarchar(100)  NULL,
    [Coodernadas] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Denuncia'
CREATE TABLE [dbo].[Denuncia] (
    [IdDenuncia] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(100)  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL,
    [IdCancha] bigint  NULL,
    [IdEquipo] bigint  NULL
);
GO

-- Creating table 'Equipo'
CREATE TABLE [dbo].[Equipo] (
    [IdEquipo] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NULL,
    [Valoracion] int  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Equipo_Foto'
CREATE TABLE [dbo].[Equipo_Foto] (
    [IdEquipo_Foto] bigint IDENTITY(1,1) NOT NULL,
    [Foto] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdEquipo] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Equipo_Jugador'
CREATE TABLE [dbo].[Equipo_Jugador] (
    [IdEquipo_Jugador] bigint IDENTITY(1,1) NOT NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL,
    [IdEquipo] bigint  NULL,
    [IdUsuario_Solicitud_Equipo] bigint  NULL
);
GO

-- Creating table 'Equipo_Tecnico'
CREATE TABLE [dbo].[Equipo_Tecnico] (
    [IdEquipo_Tecnico] bigint IDENTITY(1,1) NOT NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL,
    [IdEquipo] bigint  NULL
);
GO

-- Creating table 'Equipo_Valoracion'
CREATE TABLE [dbo].[Equipo_Valoracion] (
    [IdEquipo_Valoracion] bigint IDENTITY(1,1) NOT NULL,
    [Valoracion] int  NULL,
    [Comentario] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdEquipo] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Reto'
CREATE TABLE [dbo].[Reto] (
    [IdReto] bigint IDENTITY(1,1) NOT NULL,
    [FechaReto] datetime  NULL,
    [ResultadoEquipoRetador] int  NULL,
    [ResultadoEquipoRetada] int  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdEquipo] bigint  NULL,
    [IdCancha_Reservacion] bigint  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Token'
CREATE TABLE [dbo].[Token] (
    [IdToken] bigint IDENTITY(1,1) NOT NULL,
    [TokenConfirmacion] nvarchar(100)  NULL,
    [Correo] nvarchar(100)  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [IdUsuario] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NULL,
    [Apellido] nvarchar(100)  NULL,
    [Correo] nvarchar(100)  NULL,
    [Telefonos] nvarchar(100)  NULL,
    [Confirmado] bit  NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [Valoracion] int  NULL,
    [EsEspectador] bit  NULL,
    [EsAdminCancha] bit  NULL,
    [EsAdminEquipo] bit  NULL,
    [EsJugador] bit  NULL,
    [FechaNacimiento] datetime  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL
);
GO

-- Creating table 'Usuario_Foto'
CREATE TABLE [dbo].[Usuario_Foto] (
    [IdUsuario_Foto] bigint IDENTITY(1,1) NOT NULL,
    [Foto] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Usuario_Registro_Acceso'
CREATE TABLE [dbo].[Usuario_Registro_Acceso] (
    [IdUsuario_Registro_Acceso] bigint IDENTITY(1,1) NOT NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Usuario_Solicitud_AdminCancha'
CREATE TABLE [dbo].[Usuario_Solicitud_AdminCancha] (
    [IdUsuario_Solicitud_AdminCancha] bigint IDENTITY(1,1) NOT NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- Creating table 'Usuario_Solicitud_Equipo'
CREATE TABLE [dbo].[Usuario_Solicitud_Equipo] (
    [IdUsuario_Solicitud_Equipo] bigint IDENTITY(1,1) NOT NULL,
    [TipoEstado] nvarchar(100)  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL,
    [IdEquipo] bigint  NULL
);
GO

-- Creating table 'Usuario_Valoracion'
CREATE TABLE [dbo].[Usuario_Valoracion] (
    [IdUsuario_Valoracion] bigint IDENTITY(1,1) NOT NULL,
    [Valoracion] int  NULL,
    [TipoValoracion] int  NULL,
    [FechaCreo] datetime  NULL,
    [FechaElimino] datetime  NULL,
    [Activo] bit  NULL,
    [IdUsuario] bigint  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCancha] in table 'Cancha'
ALTER TABLE [dbo].[Cancha]
ADD CONSTRAINT [PK_Cancha]
    PRIMARY KEY CLUSTERED ([IdCancha] ASC);
GO

-- Creating primary key on [IdCancha_Foto] in table 'Cancha_Foto'
ALTER TABLE [dbo].[Cancha_Foto]
ADD CONSTRAINT [PK_Cancha_Foto]
    PRIMARY KEY CLUSTERED ([IdCancha_Foto] ASC);
GO

-- Creating primary key on [IdCancha_Horario_Dia] in table 'Cancha_Horario_Dia'
ALTER TABLE [dbo].[Cancha_Horario_Dia]
ADD CONSTRAINT [PK_Cancha_Horario_Dia]
    PRIMARY KEY CLUSTERED ([IdCancha_Horario_Dia] ASC);
GO

-- Creating primary key on [IdCancha_Horario_Dia_Hora] in table 'Cancha_Horario_Dia_Hora'
ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora]
ADD CONSTRAINT [PK_Cancha_Horario_Dia_Hora]
    PRIMARY KEY CLUSTERED ([IdCancha_Horario_Dia_Hora] ASC);
GO

-- Creating primary key on [IdCancha_Reservacion] in table 'Cancha_Reservacion'
ALTER TABLE [dbo].[Cancha_Reservacion]
ADD CONSTRAINT [PK_Cancha_Reservacion]
    PRIMARY KEY CLUSTERED ([IdCancha_Reservacion] ASC);
GO

-- Creating primary key on [IdCancha_Valoracion] in table 'Cancha_Valoracion'
ALTER TABLE [dbo].[Cancha_Valoracion]
ADD CONSTRAINT [PK_Cancha_Valoracion]
    PRIMARY KEY CLUSTERED ([IdCancha_Valoracion] ASC);
GO

-- Creating primary key on [IdComplejoDeportivo] in table 'ComplejoDeportivo'
ALTER TABLE [dbo].[ComplejoDeportivo]
ADD CONSTRAINT [PK_ComplejoDeportivo]
    PRIMARY KEY CLUSTERED ([IdComplejoDeportivo] ASC);
GO

-- Creating primary key on [IdDenuncia] in table 'Denuncia'
ALTER TABLE [dbo].[Denuncia]
ADD CONSTRAINT [PK_Denuncia]
    PRIMARY KEY CLUSTERED ([IdDenuncia] ASC);
GO

-- Creating primary key on [IdEquipo] in table 'Equipo'
ALTER TABLE [dbo].[Equipo]
ADD CONSTRAINT [PK_Equipo]
    PRIMARY KEY CLUSTERED ([IdEquipo] ASC);
GO

-- Creating primary key on [IdEquipo_Foto] in table 'Equipo_Foto'
ALTER TABLE [dbo].[Equipo_Foto]
ADD CONSTRAINT [PK_Equipo_Foto]
    PRIMARY KEY CLUSTERED ([IdEquipo_Foto] ASC);
GO

-- Creating primary key on [IdEquipo_Jugador] in table 'Equipo_Jugador'
ALTER TABLE [dbo].[Equipo_Jugador]
ADD CONSTRAINT [PK_Equipo_Jugador]
    PRIMARY KEY CLUSTERED ([IdEquipo_Jugador] ASC);
GO

-- Creating primary key on [IdEquipo_Tecnico] in table 'Equipo_Tecnico'
ALTER TABLE [dbo].[Equipo_Tecnico]
ADD CONSTRAINT [PK_Equipo_Tecnico]
    PRIMARY KEY CLUSTERED ([IdEquipo_Tecnico] ASC);
GO

-- Creating primary key on [IdEquipo_Valoracion] in table 'Equipo_Valoracion'
ALTER TABLE [dbo].[Equipo_Valoracion]
ADD CONSTRAINT [PK_Equipo_Valoracion]
    PRIMARY KEY CLUSTERED ([IdEquipo_Valoracion] ASC);
GO

-- Creating primary key on [IdReto] in table 'Reto'
ALTER TABLE [dbo].[Reto]
ADD CONSTRAINT [PK_Reto]
    PRIMARY KEY CLUSTERED ([IdReto] ASC);
GO

-- Creating primary key on [IdToken] in table 'Token'
ALTER TABLE [dbo].[Token]
ADD CONSTRAINT [PK_Token]
    PRIMARY KEY CLUSTERED ([IdToken] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [IdUsuario_Foto] in table 'Usuario_Foto'
ALTER TABLE [dbo].[Usuario_Foto]
ADD CONSTRAINT [PK_Usuario_Foto]
    PRIMARY KEY CLUSTERED ([IdUsuario_Foto] ASC);
GO

-- Creating primary key on [IdUsuario_Registro_Acceso] in table 'Usuario_Registro_Acceso'
ALTER TABLE [dbo].[Usuario_Registro_Acceso]
ADD CONSTRAINT [PK_Usuario_Registro_Acceso]
    PRIMARY KEY CLUSTERED ([IdUsuario_Registro_Acceso] ASC);
GO

-- Creating primary key on [IdUsuario_Solicitud_AdminCancha] in table 'Usuario_Solicitud_AdminCancha'
ALTER TABLE [dbo].[Usuario_Solicitud_AdminCancha]
ADD CONSTRAINT [PK_Usuario_Solicitud_AdminCancha]
    PRIMARY KEY CLUSTERED ([IdUsuario_Solicitud_AdminCancha] ASC);
GO

-- Creating primary key on [IdUsuario_Solicitud_Equipo] in table 'Usuario_Solicitud_Equipo'
ALTER TABLE [dbo].[Usuario_Solicitud_Equipo]
ADD CONSTRAINT [PK_Usuario_Solicitud_Equipo]
    PRIMARY KEY CLUSTERED ([IdUsuario_Solicitud_Equipo] ASC);
GO

-- Creating primary key on [IdUsuario_Valoracion] in table 'Usuario_Valoracion'
ALTER TABLE [dbo].[Usuario_Valoracion]
ADD CONSTRAINT [PK_Usuario_Valoracion]
    PRIMARY KEY CLUSTERED ([IdUsuario_Valoracion] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCancha] in table 'Cancha_Horario_Dia'
ALTER TABLE [dbo].[Cancha_Horario_Dia]
ADD CONSTRAINT [FK_FK1E2394DDF771FF35]
    FOREIGN KEY ([IdCancha])
    REFERENCES [dbo].[Cancha]
        ([IdCancha])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK1E2394DDF771FF35'
CREATE INDEX [IX_FK_FK1E2394DDF771FF35]
ON [dbo].[Cancha_Horario_Dia]
    ([IdCancha]);
GO

-- Creating foreign key on [IdCancha] in table 'Denuncia'
ALTER TABLE [dbo].[Denuncia]
ADD CONSTRAINT [FK_FK3BBAF225F771FF35]
    FOREIGN KEY ([IdCancha])
    REFERENCES [dbo].[Cancha]
        ([IdCancha])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK3BBAF225F771FF35'
CREATE INDEX [IX_FK_FK3BBAF225F771FF35]
ON [dbo].[Denuncia]
    ([IdCancha]);
GO

-- Creating foreign key on [IdCancha] in table 'Cancha_Valoracion'
ALTER TABLE [dbo].[Cancha_Valoracion]
ADD CONSTRAINT [FK_FK3FBA4BEBF771FF35]
    FOREIGN KEY ([IdCancha])
    REFERENCES [dbo].[Cancha]
        ([IdCancha])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK3FBA4BEBF771FF35'
CREATE INDEX [IX_FK_FK3FBA4BEBF771FF35]
ON [dbo].[Cancha_Valoracion]
    ([IdCancha]);
GO

-- Creating foreign key on [IdCancha] in table 'Cancha_Foto'
ALTER TABLE [dbo].[Cancha_Foto]
ADD CONSTRAINT [FK_FK7033D3AF771FF35]
    FOREIGN KEY ([IdCancha])
    REFERENCES [dbo].[Cancha]
        ([IdCancha])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7033D3AF771FF35'
CREATE INDEX [IX_FK_FK7033D3AF771FF35]
ON [dbo].[Cancha_Foto]
    ([IdCancha]);
GO

-- Creating foreign key on [IdUsuario] in table 'Cancha'
ALTER TABLE [dbo].[Cancha]
ADD CONSTRAINT [FK_FK76644D7F1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK76644D7F1862B0F6'
CREATE INDEX [IX_FK_FK76644D7F1862B0F6]
ON [dbo].[Cancha]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdComplejoDeportivo] in table 'Cancha'
ALTER TABLE [dbo].[Cancha]
ADD CONSTRAINT [FK_FK76644D7FE55E9EAC]
    FOREIGN KEY ([IdComplejoDeportivo])
    REFERENCES [dbo].[ComplejoDeportivo]
        ([IdComplejoDeportivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK76644D7FE55E9EAC'
CREATE INDEX [IX_FK_FK76644D7FE55E9EAC]
ON [dbo].[Cancha]
    ([IdComplejoDeportivo]);
GO

-- Creating foreign key on [IdUsuario] in table 'Cancha_Foto'
ALTER TABLE [dbo].[Cancha_Foto]
ADD CONSTRAINT [FK_FK7033D3A1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7033D3A1862B0F6'
CREATE INDEX [IX_FK_FK7033D3A1862B0F6]
ON [dbo].[Cancha_Foto]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Cancha_Horario_Dia'
ALTER TABLE [dbo].[Cancha_Horario_Dia]
ADD CONSTRAINT [FK_FK1E2394DD1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK1E2394DD1862B0F6'
CREATE INDEX [IX_FK_FK1E2394DD1862B0F6]
ON [dbo].[Cancha_Horario_Dia]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdCancha_Horario_Dia] in table 'Cancha_Horario_Dia_Hora'
ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora]
ADD CONSTRAINT [FK_FK9137113AC7910A3A]
    FOREIGN KEY ([IdCancha_Horario_Dia])
    REFERENCES [dbo].[Cancha_Horario_Dia]
        ([IdCancha_Horario_Dia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK9137113AC7910A3A'
CREATE INDEX [IX_FK_FK9137113AC7910A3A]
ON [dbo].[Cancha_Horario_Dia_Hora]
    ([IdCancha_Horario_Dia]);
GO

-- Creating foreign key on [IdUsuario] in table 'Cancha_Horario_Dia_Hora'
ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora]
ADD CONSTRAINT [FK_FK9137113A1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK9137113A1862B0F6'
CREATE INDEX [IX_FK_FK9137113A1862B0F6]
ON [dbo].[Cancha_Horario_Dia_Hora]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdCancha_Horario_Dia_Hora] in table 'Cancha_Reservacion'
ALTER TABLE [dbo].[Cancha_Reservacion]
ADD CONSTRAINT [FK_FK9CC16DB559FCD51]
    FOREIGN KEY ([IdCancha_Horario_Dia_Hora])
    REFERENCES [dbo].[Cancha_Horario_Dia_Hora]
        ([IdCancha_Horario_Dia_Hora])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK9CC16DB559FCD51'
CREATE INDEX [IX_FK_FK9CC16DB559FCD51]
ON [dbo].[Cancha_Reservacion]
    ([IdCancha_Horario_Dia_Hora]);
GO

-- Creating foreign key on [IdCancha_Reservacion] in table 'Reto'
ALTER TABLE [dbo].[Reto]
ADD CONSTRAINT [FK_FK903403348204A257]
    FOREIGN KEY ([IdCancha_Reservacion])
    REFERENCES [dbo].[Cancha_Reservacion]
        ([IdCancha_Reservacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK903403348204A257'
CREATE INDEX [IX_FK_FK903403348204A257]
ON [dbo].[Reto]
    ([IdCancha_Reservacion]);
GO

-- Creating foreign key on [IdUsuario] in table 'Cancha_Reservacion'
ALTER TABLE [dbo].[Cancha_Reservacion]
ADD CONSTRAINT [FK_FK9CC16DB1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK9CC16DB1862B0F6'
CREATE INDEX [IX_FK_FK9CC16DB1862B0F6]
ON [dbo].[Cancha_Reservacion]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Cancha_Valoracion'
ALTER TABLE [dbo].[Cancha_Valoracion]
ADD CONSTRAINT [FK_FK3FBA4BEB1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK3FBA4BEB1862B0F6'
CREATE INDEX [IX_FK_FK3FBA4BEB1862B0F6]
ON [dbo].[Cancha_Valoracion]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'ComplejoDeportivo'
ALTER TABLE [dbo].[ComplejoDeportivo]
ADD CONSTRAINT [FK_FK5F4FA4051862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK5F4FA4051862B0F6'
CREATE INDEX [IX_FK_FK5F4FA4051862B0F6]
ON [dbo].[ComplejoDeportivo]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Denuncia'
ALTER TABLE [dbo].[Denuncia]
ADD CONSTRAINT [FK_FK3BBAF2251862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK3BBAF2251862B0F6'
CREATE INDEX [IX_FK_FK3BBAF2251862B0F6]
ON [dbo].[Denuncia]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdEquipo] in table 'Denuncia'
ALTER TABLE [dbo].[Denuncia]
ADD CONSTRAINT [FK_FK3BBAF225A62E925C]
    FOREIGN KEY ([IdEquipo])
    REFERENCES [dbo].[Equipo]
        ([IdEquipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK3BBAF225A62E925C'
CREATE INDEX [IX_FK_FK3BBAF225A62E925C]
ON [dbo].[Denuncia]
    ([IdEquipo]);
GO

-- Creating foreign key on [IdEquipo] in table 'Usuario_Solicitud_Equipo'
ALTER TABLE [dbo].[Usuario_Solicitud_Equipo]
ADD CONSTRAINT [FK_FK312DCDEDA62E925C]
    FOREIGN KEY ([IdEquipo])
    REFERENCES [dbo].[Equipo]
        ([IdEquipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK312DCDEDA62E925C'
CREATE INDEX [IX_FK_FK312DCDEDA62E925C]
ON [dbo].[Usuario_Solicitud_Equipo]
    ([IdEquipo]);
GO

-- Creating foreign key on [IdUsuario] in table 'Equipo'
ALTER TABLE [dbo].[Equipo]
ADD CONSTRAINT [FK_FK323934421862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK323934421862B0F6'
CREATE INDEX [IX_FK_FK323934421862B0F6]
ON [dbo].[Equipo]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdEquipo] in table 'Equipo_Tecnico'
ALTER TABLE [dbo].[Equipo_Tecnico]
ADD CONSTRAINT [FK_FK39930699A62E925C]
    FOREIGN KEY ([IdEquipo])
    REFERENCES [dbo].[Equipo]
        ([IdEquipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK39930699A62E925C'
CREATE INDEX [IX_FK_FK39930699A62E925C]
ON [dbo].[Equipo_Tecnico]
    ([IdEquipo]);
GO

-- Creating foreign key on [IdEquipo] in table 'Equipo_Valoracion'
ALTER TABLE [dbo].[Equipo_Valoracion]
ADD CONSTRAINT [FK_FK3F406CE3A62E925C]
    FOREIGN KEY ([IdEquipo])
    REFERENCES [dbo].[Equipo]
        ([IdEquipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK3F406CE3A62E925C'
CREATE INDEX [IX_FK_FK3F406CE3A62E925C]
ON [dbo].[Equipo_Valoracion]
    ([IdEquipo]);
GO

-- Creating foreign key on [IdEquipo] in table 'Equipo_Foto'
ALTER TABLE [dbo].[Equipo_Foto]
ADD CONSTRAINT [FK_FK7932B010A62E925C]
    FOREIGN KEY ([IdEquipo])
    REFERENCES [dbo].[Equipo]
        ([IdEquipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7932B010A62E925C'
CREATE INDEX [IX_FK_FK7932B010A62E925C]
ON [dbo].[Equipo_Foto]
    ([IdEquipo]);
GO

-- Creating foreign key on [IdEquipo] in table 'Equipo_Jugador'
ALTER TABLE [dbo].[Equipo_Jugador]
ADD CONSTRAINT [FK_FK7DE04BD4A62E925C]
    FOREIGN KEY ([IdEquipo])
    REFERENCES [dbo].[Equipo]
        ([IdEquipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7DE04BD4A62E925C'
CREATE INDEX [IX_FK_FK7DE04BD4A62E925C]
ON [dbo].[Equipo_Jugador]
    ([IdEquipo]);
GO

-- Creating foreign key on [IdEquipo] in table 'Reto'
ALTER TABLE [dbo].[Reto]
ADD CONSTRAINT [FK_FK90340334A62E925C]
    FOREIGN KEY ([IdEquipo])
    REFERENCES [dbo].[Equipo]
        ([IdEquipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK90340334A62E925C'
CREATE INDEX [IX_FK_FK90340334A62E925C]
ON [dbo].[Reto]
    ([IdEquipo]);
GO

-- Creating foreign key on [IdUsuario] in table 'Equipo_Foto'
ALTER TABLE [dbo].[Equipo_Foto]
ADD CONSTRAINT [FK_FK7932B0101862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7932B0101862B0F6'
CREATE INDEX [IX_FK_FK7932B0101862B0F6]
ON [dbo].[Equipo_Foto]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Equipo_Jugador'
ALTER TABLE [dbo].[Equipo_Jugador]
ADD CONSTRAINT [FK_FK7DE04BD41862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7DE04BD41862B0F6'
CREATE INDEX [IX_FK_FK7DE04BD41862B0F6]
ON [dbo].[Equipo_Jugador]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario_Solicitud_Equipo] in table 'Equipo_Jugador'
ALTER TABLE [dbo].[Equipo_Jugador]
ADD CONSTRAINT [FK_FK7DE04BD44586AA08]
    FOREIGN KEY ([IdUsuario_Solicitud_Equipo])
    REFERENCES [dbo].[Usuario_Solicitud_Equipo]
        ([IdUsuario_Solicitud_Equipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7DE04BD44586AA08'
CREATE INDEX [IX_FK_FK7DE04BD44586AA08]
ON [dbo].[Equipo_Jugador]
    ([IdUsuario_Solicitud_Equipo]);
GO

-- Creating foreign key on [IdUsuario] in table 'Equipo_Tecnico'
ALTER TABLE [dbo].[Equipo_Tecnico]
ADD CONSTRAINT [FK_FK399306991862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK399306991862B0F6'
CREATE INDEX [IX_FK_FK399306991862B0F6]
ON [dbo].[Equipo_Tecnico]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Equipo_Valoracion'
ALTER TABLE [dbo].[Equipo_Valoracion]
ADD CONSTRAINT [FK_FK3F406CE31862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK3F406CE31862B0F6'
CREATE INDEX [IX_FK_FK3F406CE31862B0F6]
ON [dbo].[Equipo_Valoracion]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Reto'
ALTER TABLE [dbo].[Reto]
ADD CONSTRAINT [FK_FK903403341862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK903403341862B0F6'
CREATE INDEX [IX_FK_FK903403341862B0F6]
ON [dbo].[Reto]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Token'
ALTER TABLE [dbo].[Token]
ADD CONSTRAINT [FK_FK7786F1A31862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK7786F1A31862B0F6'
CREATE INDEX [IX_FK_FK7786F1A31862B0F6]
ON [dbo].[Token]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Usuario_Solicitud_Equipo'
ALTER TABLE [dbo].[Usuario_Solicitud_Equipo]
ADD CONSTRAINT [FK_FK312DCDED1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK312DCDED1862B0F6'
CREATE INDEX [IX_FK_FK312DCDED1862B0F6]
ON [dbo].[Usuario_Solicitud_Equipo]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Usuario_Solicitud_AdminCancha'
ALTER TABLE [dbo].[Usuario_Solicitud_AdminCancha]
ADD CONSTRAINT [FK_FK550739B71862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK550739B71862B0F6'
CREATE INDEX [IX_FK_FK550739B71862B0F6]
ON [dbo].[Usuario_Solicitud_AdminCancha]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Usuario_Valoracion'
ALTER TABLE [dbo].[Usuario_Valoracion]
ADD CONSTRAINT [FK_FK66723AB21862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK66723AB21862B0F6'
CREATE INDEX [IX_FK_FK66723AB21862B0F6]
ON [dbo].[Usuario_Valoracion]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Usuario_Foto'
ALTER TABLE [dbo].[Usuario_Foto]
ADD CONSTRAINT [FK_FK817CBD8E1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FK817CBD8E1862B0F6'
CREATE INDEX [IX_FK_FK817CBD8E1862B0F6]
ON [dbo].[Usuario_Foto]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_FK9E8FB9FD1862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdUsuario] in table 'Usuario_Registro_Acceso'
ALTER TABLE [dbo].[Usuario_Registro_Acceso]
ADD CONSTRAINT [FK_FKA981D5251862B0F6]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuario]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKA981D5251862B0F6'
CREATE INDEX [IX_FK_FKA981D5251862B0F6]
ON [dbo].[Usuario_Registro_Acceso]
    ([IdUsuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------