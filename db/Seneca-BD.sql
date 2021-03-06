USE [master]
GO
/****** Object:  Database [seneca]    Script Date: 21/02/2021 12:43:24 ******/
CREATE DATABASE [seneca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'seneca', FILENAME = N'D:\Programas\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\seneca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'seneca_log', FILENAME = N'D:\Programas\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\seneca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [seneca] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [seneca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [seneca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [seneca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [seneca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [seneca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [seneca] SET ARITHABORT OFF 
GO
ALTER DATABASE [seneca] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [seneca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [seneca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [seneca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [seneca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [seneca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [seneca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [seneca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [seneca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [seneca] SET  ENABLE_BROKER 
GO
ALTER DATABASE [seneca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [seneca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [seneca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [seneca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [seneca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [seneca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [seneca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [seneca] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [seneca] SET  MULTI_USER 
GO
ALTER DATABASE [seneca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [seneca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [seneca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [seneca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [seneca] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [seneca] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [seneca] SET QUERY_STORE = OFF
GO
USE [seneca]
GO
/****** Object:  Table [dbo].[alumnos]    Script Date: 21/02/2021 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnos](
	[id_alumno] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [char](50) NOT NULL,
	[apellidos] [char](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[dni_alumno] [char](9) NULL,
	[direccion] [char](50) NOT NULL,
	[telefono_emergencia] [int] NOT NULL,
 CONSTRAINT [PK_alumnos] PRIMARY KEY CLUSTERED 
(
	[id_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[asignaturas]    Script Date: 21/02/2021 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignaturas](
	[cod_asignatura] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [char](50) NOT NULL,
	[descripcion] [text] NOT NULL,
	[id_profesor] [int] NOT NULL,
 CONSTRAINT [PK_asignaturas] PRIMARY KEY CLUSTERED 
(
	[cod_asignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clases]    Script Date: 21/02/2021 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clases](
	[cod_clase] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [char](20) NOT NULL,
 CONSTRAINT [PK_clases] PRIMARY KEY CLUSTERED 
(
	[cod_clase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clases_alumnos]    Script Date: 21/02/2021 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clases_alumnos](
	[cod_clase] [int] NOT NULL,
	[id_alumno] [int] NOT NULL,
 CONSTRAINT [PK_clases_alumnos] PRIMARY KEY CLUSTERED 
(
	[cod_clase] ASC,
	[id_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clases_asignaturas]    Script Date: 21/02/2021 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clases_asignaturas](
	[cod_clase] [int] NOT NULL,
	[cod_asignatura] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notas_alumnos]    Script Date: 21/02/2021 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notas_alumnos](
	[id_alumno] [int] NOT NULL,
	[cod_asignatura] [int] NOT NULL,
	[nota] [decimal](4, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profesores]    Script Date: 21/02/2021 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profesores](
	[id_profesores] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [char](50) NOT NULL,
	[apellidos] [char](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[dni_profesor] [char](9) NOT NULL,
	[password] [char](100) NOT NULL,
	[direccion] [char](100) NOT NULL,
 CONSTRAINT [PK_Profesores_ID] PRIMARY KEY CLUSTERED 
(
	[id_profesores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [PK_alumnos_DNI]    Script Date: 21/02/2021 12:43:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [PK_alumnos_DNI] ON [dbo].[alumnos]
(
	[id_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_clases_nombre]    Script Date: 21/02/2021 12:43:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [PK_clases_nombre] ON [dbo].[clases]
(
	[cod_clase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_profesores_DNI]    Script Date: 21/02/2021 12:43:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [PK_profesores_DNI] ON [dbo].[profesores]
(
	[id_profesores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_profesores_asignaturas] FOREIGN KEY([id_profesor])
REFERENCES [dbo].[profesores] ([id_profesores])
GO
ALTER TABLE [dbo].[asignaturas] CHECK CONSTRAINT [FK_profesores_asignaturas]
GO
ALTER TABLE [dbo].[clases_alumnos]  WITH CHECK ADD  CONSTRAINT [FK_clases_alumnos_alumnos] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[alumnos] ([id_alumno])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[clases_alumnos] CHECK CONSTRAINT [FK_clases_alumnos_alumnos]
GO
ALTER TABLE [dbo].[clases_alumnos]  WITH CHECK ADD  CONSTRAINT [FK_clases_alumnos_clases] FOREIGN KEY([cod_clase])
REFERENCES [dbo].[clases] ([cod_clase])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[clases_alumnos] CHECK CONSTRAINT [FK_clases_alumnos_clases]
GO
ALTER TABLE [dbo].[clases_asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_clases_asignaturas_clases] FOREIGN KEY([cod_asignatura])
REFERENCES [dbo].[asignaturas] ([cod_asignatura])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[clases_asignaturas] CHECK CONSTRAINT [FK_clases_asignaturas_clases]
GO
ALTER TABLE [dbo].[clases_asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_clases_clases] FOREIGN KEY([cod_clase])
REFERENCES [dbo].[clases] ([cod_clase])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[clases_asignaturas] CHECK CONSTRAINT [FK_clases_clases]
GO
ALTER TABLE [dbo].[notas_alumnos]  WITH CHECK ADD  CONSTRAINT [FK_notas_alumnos_alumnos1] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[alumnos] ([id_alumno])
GO
ALTER TABLE [dbo].[notas_alumnos] CHECK CONSTRAINT [FK_notas_alumnos_alumnos1]
GO
ALTER TABLE [dbo].[notas_alumnos]  WITH CHECK ADD  CONSTRAINT [FK_notas_alumnos_asignaturas1] FOREIGN KEY([cod_asignatura])
REFERENCES [dbo].[asignaturas] ([cod_asignatura])
GO
ALTER TABLE [dbo].[notas_alumnos] CHECK CONSTRAINT [FK_notas_alumnos_asignaturas1]
GO
USE [master]
GO
ALTER DATABASE [seneca] SET  READ_WRITE 
GO
