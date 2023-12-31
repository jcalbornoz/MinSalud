USE [master]
GO
/****** Object:  Database [DemoSeguimiento]    Script Date: 24/08/2023 9:50:38 a. m. ******/
CREATE DATABASE [DemoSeguimiento]

GO
ALTER DATABASE [DemoSeguimiento] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DemoSeguimiento].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DemoSeguimiento] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET ARITHABORT OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DemoSeguimiento] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DemoSeguimiento] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DemoSeguimiento] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DemoSeguimiento] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET RECOVERY FULL 
GO
ALTER DATABASE [DemoSeguimiento] SET  MULTI_USER 
GO
ALTER DATABASE [DemoSeguimiento] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DemoSeguimiento] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DemoSeguimiento] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DemoSeguimiento] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DemoSeguimiento] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DemoSeguimiento] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DemoSeguimiento', N'ON'
GO
ALTER DATABASE [DemoSeguimiento] SET QUERY_STORE = ON
GO
ALTER DATABASE [DemoSeguimiento] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DemoSeguimiento]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 24/08/2023 9:50:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[TipoIdentificacion] [varchar](2) NOT NULL,
	[NroIdentificacion] [varchar](17) NOT NULL,
	[PrimerNombre] [varchar](60) NOT NULL,
	[SegundoNombre] [varchar](60) NULL,
	[PrimerApellido] [varchar](60) NOT NULL,
	[SegundoApellido] [varchar](60) NULL,
	[Sexo] [varchar](2) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[CodMpioResidencia] [varchar](5) NOT NULL,
	[CodAsegurador] [varchar](6) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguimiento]    Script Date: 24/08/2023 9:50:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguimiento](
	[IdSeguimiento] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[EstadoVital] [int] NOT NULL,
	[FechaDefuncion] [date] NULL,
	[UbicacionDefuncion] [int] NULL,
	[CodLugarAtencion] [varchar](12) NOT NULL,
	[FechaAtencion] [datetime] NOT NULL,
	[PesoKg] [decimal](5, 2) NOT NULL,
	[TallaCm] [smallint] NOT NULL,
	[CodClasificacionNutricional] [varchar](2) NOT NULL,
	[CodManejoActual] [varchar](2) NOT NULL,
	[DesManejo] [varchar](250) NOT NULL,
	[CodUbicacion] [varchar](2) NOT NULL,
	[DesUbicacion] [varchar](250) NOT NULL,
	[CodTratamiento] [varchar](2) NOT NULL,
	[TotalSobresFTLC] [smallint] NOT NULL,
	[OtroTratamiento] [varchar](256) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Seguimiento] PRIMARY KEY CLUSTERED 
(
	[IdSeguimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([IdPersona], [TipoIdentificacion], [NroIdentificacion], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [Sexo], [FechaNacimiento], [CodMpioResidencia], [CodAsegurador], [Created], [Updated]) VALUES (2, N'CC', N'1234', N'Prueba', NULL, N'Demo', NULL, N'M', CAST(N'1978-01-01' AS Date), N'5', N'5', CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Persona] ([IdPersona], [TipoIdentificacion], [NroIdentificacion], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [Sexo], [FechaNacimiento], [CodMpioResidencia], [CodAsegurador], [Created], [Updated]) VALUES (3, N'CC', N'123456', N'Prueba', N'One', N'Swagger', N'One', N'F', CAST(N'1991-08-23' AS Date), N'5', N'100', CAST(N'2023-08-23T09:18:54.967' AS DateTime), CAST(N'2023-08-23T09:18:55.667' AS DateTime))
INSERT [dbo].[Persona] ([IdPersona], [TipoIdentificacion], [NroIdentificacion], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [Sexo], [FechaNacimiento], [CodMpioResidencia], [CodAsegurador], [Created], [Updated]) VALUES (4, N'CC', N'654321', N'Prueba', N'Apple', N'Swagger', N'Apple', N'M', CAST(N'1991-08-23' AS Date), N'5', N'100', CAST(N'2023-08-23T09:24:42.437' AS DateTime), CAST(N'2023-08-23T09:24:42.437' AS DateTime))
INSERT [dbo].[Persona] ([IdPersona], [TipoIdentificacion], [NroIdentificacion], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [Sexo], [FechaNacimiento], [CodMpioResidencia], [CodAsegurador], [Created], [Updated]) VALUES (5, N'RC', N'1234', N'Aiulyn', N'Sebastian', N'Demostra', N'Tivo', N'M', CAST(N'2020-01-28' AS Date), N'5', N'100', CAST(N'2023-08-23T15:56:16.243' AS DateTime), CAST(N'2023-08-23T15:56:16.243' AS DateTime))
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Seguimiento] ON 

INSERT [dbo].[Seguimiento] ([IdSeguimiento], [IdPersona], [EstadoVital], [FechaDefuncion], [UbicacionDefuncion], [CodLugarAtencion], [FechaAtencion], [PesoKg], [TallaCm], [CodClasificacionNutricional], [CodManejoActual], [DesManejo], [CodUbicacion], [DesUbicacion], [CodTratamiento], [TotalSobresFTLC], [OtroTratamiento], [Created], [Updated]) VALUES (1, 4, 1, NULL, NULL, N'5', CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(75.00 AS Decimal(5, 2)), 179, N'1', N'1', N'1', N'1', N'1', N'1', 5, N'NO', CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Seguimiento] ([IdSeguimiento], [IdPersona], [EstadoVital], [FechaDefuncion], [UbicacionDefuncion], [CodLugarAtencion], [FechaAtencion], [PesoKg], [TallaCm], [CodClasificacionNutricional], [CodManejoActual], [DesManejo], [CodUbicacion], [DesUbicacion], [CodTratamiento], [TotalSobresFTLC], [OtroTratamiento], [Created], [Updated]) VALUES (6, 4, 3, NULL, NULL, N'05010', CAST(N'2023-08-23T21:37:45.917' AS DateTime), CAST(75.00 AS Decimal(5, 2)), 179, N'05', N'05', N'Aislamiento recomendado', N'05', N'Casa', N'05', 10, N'Se revisa en casa al menor.', CAST(N'2023-08-23T16:42:04.940' AS DateTime), CAST(N'2023-08-23T16:42:04.940' AS DateTime))
SET IDENTITY_INSERT [dbo].[Seguimiento] OFF
GO
ALTER TABLE [dbo].[Seguimiento]  WITH CHECK ADD  CONSTRAINT [FK_Seguimiento_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Seguimiento] CHECK CONSTRAINT [FK_Seguimiento_Persona]
GO
USE [master]
GO
ALTER DATABASE [DemoSeguimiento] SET  READ_WRITE 
GO
