USE [Juega]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
	[Correo] [nvarchar](100) NULL,
	[Telefonos] [nvarchar](100) NULL,
	[Confirmado] [bit] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[Valoracion] [int] NULL,
	[EsEspectador] [bit] NULL,
	[EsAdminCancha] [bit] NULL,
	[EsAdminEquipo] [bit] NULL,
	[EsJugador] [bit] NULL,
	[FechaNacimiento] [datetime] NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComplejoDeportivo]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComplejoDeportivo](
	[IdComplejoDeportivo] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Telefonos] [nvarchar](100) NULL,
	[Coodernadas] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComplejoDeportivo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Solicitud_AdminCancha]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Solicitud_AdminCancha](
	[IdUsuario_Solicitud_AdminCancha] [bigint] IDENTITY(1,1) NOT NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario_Solicitud_AdminCancha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Registro_Acceso]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Registro_Acceso](
	[IdUsuario_Registro_Acceso] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario_Registro_Acceso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Foto]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Foto](
	[IdUsuario_Foto] [bigint] IDENTITY(1,1) NOT NULL,
	[Foto] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario_Foto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Valoracion]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Valoracion](
	[IdUsuario_Valoracion] [bigint] IDENTITY(1,1) NOT NULL,
	[Valoracion] [int] NULL,
	[TipoValoracion] [int] NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario_Valoracion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Token]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[IdToken] [bigint] IDENTITY(1,1) NOT NULL,
	[TokenConfirmacion] [nvarchar](100) NULL,
	[Correo] [nvarchar](100) NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdToken] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo](
	[IdEquipo] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Valoracion] [int] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEquipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha](
	[IdCancha] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[NumEspectadores] [int] NULL,
	[Largo] [int] NULL,
	[Ancho] [int] NULL,
	[Valoracion] [int] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdComplejoDeportivo] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCancha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo_Foto]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo_Foto](
	[IdEquipo_Foto] [bigint] IDENTITY(1,1) NOT NULL,
	[Foto] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdEquipo] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEquipo_Foto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Solicitud_Equipo]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Solicitud_Equipo](
	[IdUsuario_Solicitud_Equipo] [bigint] IDENTITY(1,1) NOT NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
	[IdEquipo] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario_Solicitud_Equipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo_Valoracion]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo_Valoracion](
	[IdEquipo_Valoracion] [bigint] IDENTITY(1,1) NOT NULL,
	[Valoracion] [int] NULL,
	[Comentario] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdEquipo] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEquipo_Valoracion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo_Tecnico]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo_Tecnico](
	[IdEquipo_Tecnico] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaDesde] [datetime] NULL,
	[FechaHasta] [datetime] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
	[IdEquipo] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEquipo_Tecnico] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo_Jugador]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo_Jugador](
	[IdEquipo_Jugador] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaDesde] [datetime] NULL,
	[FechaHasta] [datetime] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
	[IdEquipo] [bigint] NULL,
	[IdUsuario_Solicitud_Equipo] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEquipo_Jugador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha_Valoracion]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha_Valoracion](
	[IdCancha_Valoracion] [bigint] IDENTITY(1,1) NOT NULL,
	[Valoracion] [int] NULL,
	[Comentario] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdCancha] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCancha_Valoracion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Denuncia]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Denuncia](
	[IdDenuncia] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdUsuario] [bigint] NULL,
	[IdCancha] [bigint] NULL,
	[IdEquipo] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDenuncia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha_Horario_Dia]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha_Horario_Dia](
	[IdCancha_Horario_Dia] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdCancha] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCancha_Horario_Dia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha_Foto]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha_Foto](
	[IdCancha_Foto] [bigint] IDENTITY(1,1) NOT NULL,
	[Foto] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdCancha] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCancha_Foto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha_Horario_Dia_Hora]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha_Horario_Dia_Hora](
	[IdCancha_Horario_Dia_Hora] [bigint] IDENTITY(1,1) NOT NULL,
	[HoraDesde] [datetime] NULL,
	[HoraHasta] [datetime] NULL,
	[Precio] [decimal](19, 5) NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdCancha_Horario_Dia] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCancha_Horario_Dia_Hora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha_Reservacion]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha_Reservacion](
	[IdCancha_Reservacion] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaReservacion] [datetime] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdCancha_Horario_Dia_Hora] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCancha_Reservacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reto]    Script Date: 05/26/2015 22:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reto](
	[IdReto] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaReto] [datetime] NULL,
	[ResultadoEquipoRetador] [int] NULL,
	[ResultadoEquipoRetada] [int] NULL,
	[TipoEstado] [nvarchar](100) NULL,
	[FechaCreo] [datetime] NULL,
	[FechaElimino] [datetime] NULL,
	[Activo] [bit] NULL,
	[IdEquipo] [bigint] NULL,
	[IdCancha_Reservacion] [bigint] NULL,
	[IdUsuario] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK76644D7F1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [FK76644D7F1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [FK76644D7F1862B0F6]
GO
/****** Object:  ForeignKey [FK76644D7FE55E9EAC]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [FK76644D7FE55E9EAC] FOREIGN KEY([IdComplejoDeportivo])
REFERENCES [dbo].[ComplejoDeportivo] ([IdComplejoDeportivo])
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [FK76644D7FE55E9EAC]
GO
/****** Object:  ForeignKey [FK7033D3A1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Foto]  WITH CHECK ADD  CONSTRAINT [FK7033D3A1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cancha_Foto] CHECK CONSTRAINT [FK7033D3A1862B0F6]
GO
/****** Object:  ForeignKey [FK7033D3AF771FF35]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Foto]  WITH CHECK ADD  CONSTRAINT [FK7033D3AF771FF35] FOREIGN KEY([IdCancha])
REFERENCES [dbo].[Cancha] ([IdCancha])
GO
ALTER TABLE [dbo].[Cancha_Foto] CHECK CONSTRAINT [FK7033D3AF771FF35]
GO
/****** Object:  ForeignKey [FK1E2394DD1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Horario_Dia]  WITH CHECK ADD  CONSTRAINT [FK1E2394DD1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cancha_Horario_Dia] CHECK CONSTRAINT [FK1E2394DD1862B0F6]
GO
/****** Object:  ForeignKey [FK1E2394DDF771FF35]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Horario_Dia]  WITH CHECK ADD  CONSTRAINT [FK1E2394DDF771FF35] FOREIGN KEY([IdCancha])
REFERENCES [dbo].[Cancha] ([IdCancha])
GO
ALTER TABLE [dbo].[Cancha_Horario_Dia] CHECK CONSTRAINT [FK1E2394DDF771FF35]
GO
/****** Object:  ForeignKey [FK9137113A1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora]  WITH CHECK ADD  CONSTRAINT [FK9137113A1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora] CHECK CONSTRAINT [FK9137113A1862B0F6]
GO
/****** Object:  ForeignKey [FK9137113AC7910A3A]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora]  WITH CHECK ADD  CONSTRAINT [FK9137113AC7910A3A] FOREIGN KEY([IdCancha_Horario_Dia])
REFERENCES [dbo].[Cancha_Horario_Dia] ([IdCancha_Horario_Dia])
GO
ALTER TABLE [dbo].[Cancha_Horario_Dia_Hora] CHECK CONSTRAINT [FK9137113AC7910A3A]
GO
/****** Object:  ForeignKey [FK9CC16DB1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Reservacion]  WITH CHECK ADD  CONSTRAINT [FK9CC16DB1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cancha_Reservacion] CHECK CONSTRAINT [FK9CC16DB1862B0F6]
GO
/****** Object:  ForeignKey [FK9CC16DB559FCD51]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Reservacion]  WITH CHECK ADD  CONSTRAINT [FK9CC16DB559FCD51] FOREIGN KEY([IdCancha_Horario_Dia_Hora])
REFERENCES [dbo].[Cancha_Horario_Dia_Hora] ([IdCancha_Horario_Dia_Hora])
GO
ALTER TABLE [dbo].[Cancha_Reservacion] CHECK CONSTRAINT [FK9CC16DB559FCD51]
GO
/****** Object:  ForeignKey [FK3FBA4BEB1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Valoracion]  WITH CHECK ADD  CONSTRAINT [FK3FBA4BEB1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cancha_Valoracion] CHECK CONSTRAINT [FK3FBA4BEB1862B0F6]
GO
/****** Object:  ForeignKey [FK3FBA4BEBF771FF35]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Cancha_Valoracion]  WITH CHECK ADD  CONSTRAINT [FK3FBA4BEBF771FF35] FOREIGN KEY([IdCancha])
REFERENCES [dbo].[Cancha] ([IdCancha])
GO
ALTER TABLE [dbo].[Cancha_Valoracion] CHECK CONSTRAINT [FK3FBA4BEBF771FF35]
GO
/****** Object:  ForeignKey [FK5F4FA4051862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[ComplejoDeportivo]  WITH CHECK ADD  CONSTRAINT [FK5F4FA4051862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[ComplejoDeportivo] CHECK CONSTRAINT [FK5F4FA4051862B0F6]
GO
/****** Object:  ForeignKey [FK3BBAF2251862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Denuncia]  WITH CHECK ADD  CONSTRAINT [FK3BBAF2251862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Denuncia] CHECK CONSTRAINT [FK3BBAF2251862B0F6]
GO
/****** Object:  ForeignKey [FK3BBAF225A62E925C]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Denuncia]  WITH CHECK ADD  CONSTRAINT [FK3BBAF225A62E925C] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([IdEquipo])
GO
ALTER TABLE [dbo].[Denuncia] CHECK CONSTRAINT [FK3BBAF225A62E925C]
GO
/****** Object:  ForeignKey [FK3BBAF225F771FF35]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Denuncia]  WITH CHECK ADD  CONSTRAINT [FK3BBAF225F771FF35] FOREIGN KEY([IdCancha])
REFERENCES [dbo].[Cancha] ([IdCancha])
GO
ALTER TABLE [dbo].[Denuncia] CHECK CONSTRAINT [FK3BBAF225F771FF35]
GO
/****** Object:  ForeignKey [FK323934421862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo]  WITH CHECK ADD  CONSTRAINT [FK323934421862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Equipo] CHECK CONSTRAINT [FK323934421862B0F6]
GO
/****** Object:  ForeignKey [FK7932B0101862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Foto]  WITH CHECK ADD  CONSTRAINT [FK7932B0101862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Equipo_Foto] CHECK CONSTRAINT [FK7932B0101862B0F6]
GO
/****** Object:  ForeignKey [FK7932B010A62E925C]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Foto]  WITH CHECK ADD  CONSTRAINT [FK7932B010A62E925C] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([IdEquipo])
GO
ALTER TABLE [dbo].[Equipo_Foto] CHECK CONSTRAINT [FK7932B010A62E925C]
GO
/****** Object:  ForeignKey [FK7DE04BD41862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Jugador]  WITH CHECK ADD  CONSTRAINT [FK7DE04BD41862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Equipo_Jugador] CHECK CONSTRAINT [FK7DE04BD41862B0F6]
GO
/****** Object:  ForeignKey [FK7DE04BD44586AA08]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Jugador]  WITH CHECK ADD  CONSTRAINT [FK7DE04BD44586AA08] FOREIGN KEY([IdUsuario_Solicitud_Equipo])
REFERENCES [dbo].[Usuario_Solicitud_Equipo] ([IdUsuario_Solicitud_Equipo])
GO
ALTER TABLE [dbo].[Equipo_Jugador] CHECK CONSTRAINT [FK7DE04BD44586AA08]
GO
/****** Object:  ForeignKey [FK7DE04BD4A62E925C]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Jugador]  WITH CHECK ADD  CONSTRAINT [FK7DE04BD4A62E925C] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([IdEquipo])
GO
ALTER TABLE [dbo].[Equipo_Jugador] CHECK CONSTRAINT [FK7DE04BD4A62E925C]
GO
/****** Object:  ForeignKey [FK399306991862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Tecnico]  WITH CHECK ADD  CONSTRAINT [FK399306991862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Equipo_Tecnico] CHECK CONSTRAINT [FK399306991862B0F6]
GO
/****** Object:  ForeignKey [FK39930699A62E925C]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Tecnico]  WITH CHECK ADD  CONSTRAINT [FK39930699A62E925C] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([IdEquipo])
GO
ALTER TABLE [dbo].[Equipo_Tecnico] CHECK CONSTRAINT [FK39930699A62E925C]
GO
/****** Object:  ForeignKey [FK3F406CE31862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Valoracion]  WITH CHECK ADD  CONSTRAINT [FK3F406CE31862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Equipo_Valoracion] CHECK CONSTRAINT [FK3F406CE31862B0F6]
GO
/****** Object:  ForeignKey [FK3F406CE3A62E925C]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Equipo_Valoracion]  WITH CHECK ADD  CONSTRAINT [FK3F406CE3A62E925C] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([IdEquipo])
GO
ALTER TABLE [dbo].[Equipo_Valoracion] CHECK CONSTRAINT [FK3F406CE3A62E925C]
GO
/****** Object:  ForeignKey [FK903403341862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Reto]  WITH CHECK ADD  CONSTRAINT [FK903403341862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Reto] CHECK CONSTRAINT [FK903403341862B0F6]
GO
/****** Object:  ForeignKey [FK903403348204A257]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Reto]  WITH CHECK ADD  CONSTRAINT [FK903403348204A257] FOREIGN KEY([IdCancha_Reservacion])
REFERENCES [dbo].[Cancha_Reservacion] ([IdCancha_Reservacion])
GO
ALTER TABLE [dbo].[Reto] CHECK CONSTRAINT [FK903403348204A257]
GO
/****** Object:  ForeignKey [FK90340334A62E925C]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Reto]  WITH CHECK ADD  CONSTRAINT [FK90340334A62E925C] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([IdEquipo])
GO
ALTER TABLE [dbo].[Reto] CHECK CONSTRAINT [FK90340334A62E925C]
GO
/****** Object:  ForeignKey [FK7786F1A31862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Token]  WITH CHECK ADD  CONSTRAINT [FK7786F1A31862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Token] CHECK CONSTRAINT [FK7786F1A31862B0F6]
GO
/****** Object:  ForeignKey [FK9E8FB9FD1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK9E8FB9FD1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK9E8FB9FD1862B0F6]
GO
/****** Object:  ForeignKey [FK817CBD8E1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Usuario_Foto]  WITH CHECK ADD  CONSTRAINT [FK817CBD8E1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario_Foto] CHECK CONSTRAINT [FK817CBD8E1862B0F6]
GO
/****** Object:  ForeignKey [FKA981D5251862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Usuario_Registro_Acceso]  WITH CHECK ADD  CONSTRAINT [FKA981D5251862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario_Registro_Acceso] CHECK CONSTRAINT [FKA981D5251862B0F6]
GO
/****** Object:  ForeignKey [FK550739B71862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Usuario_Solicitud_AdminCancha]  WITH CHECK ADD  CONSTRAINT [FK550739B71862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario_Solicitud_AdminCancha] CHECK CONSTRAINT [FK550739B71862B0F6]
GO
/****** Object:  ForeignKey [FK312DCDED1862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Usuario_Solicitud_Equipo]  WITH CHECK ADD  CONSTRAINT [FK312DCDED1862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario_Solicitud_Equipo] CHECK CONSTRAINT [FK312DCDED1862B0F6]
GO
/****** Object:  ForeignKey [FK312DCDEDA62E925C]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Usuario_Solicitud_Equipo]  WITH CHECK ADD  CONSTRAINT [FK312DCDEDA62E925C] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([IdEquipo])
GO
ALTER TABLE [dbo].[Usuario_Solicitud_Equipo] CHECK CONSTRAINT [FK312DCDEDA62E925C]
GO
/****** Object:  ForeignKey [FK66723AB21862B0F6]    Script Date: 05/26/2015 22:45:03 ******/
ALTER TABLE [dbo].[Usuario_Valoracion]  WITH CHECK ADD  CONSTRAINT [FK66723AB21862B0F6] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario_Valoracion] CHECK CONSTRAINT [FK66723AB21862B0F6]
GO
