USE [master]
GO
/****** Object:  Database [IdentificationBd]    Script Date: 17-06-2023 22:49:28 ******/
CREATE DATABASE [IdentificationBd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IdentificationBd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\IdentificationBd.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IdentificationBd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\IdentificationBd_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IdentificationBd] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IdentificationBd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IdentificationBd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IdentificationBd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IdentificationBd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IdentificationBd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IdentificationBd] SET ARITHABORT OFF 
GO
ALTER DATABASE [IdentificationBd] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IdentificationBd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IdentificationBd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IdentificationBd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IdentificationBd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IdentificationBd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IdentificationBd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IdentificationBd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IdentificationBd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IdentificationBd] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IdentificationBd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IdentificationBd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IdentificationBd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IdentificationBd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IdentificationBd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IdentificationBd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IdentificationBd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IdentificationBd] SET RECOVERY FULL 
GO
ALTER DATABASE [IdentificationBd] SET  MULTI_USER 
GO
ALTER DATABASE [IdentificationBd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IdentificationBd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IdentificationBd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IdentificationBd] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IdentificationBd', N'ON'
GO
USE [IdentificationBd]
GO
/****** Object:  Table [dbo].[App]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App](
	[IdApp] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[EsActivo] [bit] NOT NULL,
 CONSTRAINT [PK_App] PRIMARY KEY CLUSTERED 
(
	[IdApp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autenticacion]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autenticacion](
	[IdAutenticacion] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Contrasena] [varchar](200) NOT NULL,
	[Rol] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Autenticacion] PRIMARY KEY CLUSTERED 
(
	[IdAutenticacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IdMenu] [int] IDENTITY(1,1) NOT NULL,
	[IdApp] [int] NOT NULL,
	[Padre] [int] NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Url] [varchar](150) NOT NULL,
	[UrlFriend] [varchar](150) NOT NULL,
	[EsActivo] [bit] NOT NULL,
	[EsPadre] [bit] NOT NULL,
	[TieneHijos] [bit] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuPerfil]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuPerfil](
	[IdMenuPerfil] [int] IDENTITY(1,1) NOT NULL,
	[IdMenu] [int] NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[EsActivo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_MenuPerfil] PRIMARY KEY CLUSTERED 
(
	[IdMenuPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[EsActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Rut] [int] NOT NULL,
	[Dv] [varchar](2) NOT NULL,
	[Username] [varchar](50) NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ApellidoPaterno] [varchar](100) NOT NULL,
	[ApellidoMaterno] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[EsActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPerfil](
	[IdUsuarioPerfil] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[EsActivo] [bit] NOT NULL,
 CONSTRAINT [PK_UsuarioPerfil] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_App] FOREIGN KEY([IdApp])
REFERENCES [dbo].[App] ([IdApp])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_App]
GO
ALTER TABLE [dbo].[MenuPerfil]  WITH CHECK ADD  CONSTRAINT [FK_MenuPerfil_Menu] FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([IdMenu])
GO
ALTER TABLE [dbo].[MenuPerfil] CHECK CONSTRAINT [FK_MenuPerfil_Menu]
GO
ALTER TABLE [dbo].[MenuPerfil]  WITH CHECK ADD  CONSTRAINT [FK_MenuPerfil_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[MenuPerfil] CHECK CONSTRAINT [FK_MenuPerfil_Perfil]
GO
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPerfil_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_UsuarioPerfil_Perfil]
GO
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPerfil_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_UsuarioPerfil_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[pr_s_InfoUsuario]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_s_InfoUsuario]
	@User	varchar(20)
AS
BEGIN
	SELECT [IdUsuario]
      ,[Rut]
      ,[Dv]
      ,Username
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[FechaNacimiento]
      ,[Correo]
      ,[Telefono]
      ,[EsActivo] FROM dbo.Usuario
	WHERE Username = @User
END
GO
/****** Object:  StoredProcedure [dbo].[pr_s_MenuUsuario]    Script Date: 17-06-2023 22:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_s_MenuUsuario]
(
	@Rut			INT,
	@IdApp			INT
)
AS 
BEGIN
	--BEGIN  SET STORE PROCEDURE
		SET NOCOUNT ON
		SET DATEFORMAT DMY
	--END  SET STORE PROCEDURE

	SELECT DISTINCT
				 ME.IdMenu
				,ME.IdApp
				,ME.Padre
				,ME.Nombre
				,ME.Url
				,ME.UrlFriend
				,ME.EsActivo
				,ME.EsPadre
				,ME.TieneHijos
			FROM  dbo.Menu ME 
				INNER JOIN dbo.MenuPerfil MP ON MP.IdMenu = ME.IdMenu
				INNER JOIN dbo.UsuarioPerfil UP ON UP.IdPerfil = MP.IdPerfil
				INNER JOIN dbo.Usuario U ON U.IdUsuario = UP.IdUsuario
				
			WHERE U.Rut = @Rut
			AND ME.IdApp = @IdApp
			AND MP.EsActivo = 1

END

	 

		
			SELECT DISTINCT
				 ME.IdMenu
				,ME.IdApp
				,ME.Padre
				,ME.Nombre
				,ME.Url
				,ME.UrlFriend
				,ME.EsActivo
				,ME.EsPadre
				,ME.TieneHijos
			FROM  dbo.Menu ME 
				INNER JOIN dbo.MenuPerfil MP ON MP.IdMenu = ME.IdMenu
				INNER JOIN dbo.UsuarioPerfil UP ON UP.IdPerfil = MP.IdPerfil
				INNER JOIN dbo.Usuario U ON U.IdUsuario = UP.IdUsuario
				
			WHERE U.Rut = @Rut
			AND ME.IdApp = @IdApp
			AND MP.EsActivo = 1

			--	select getdate()




GO
USE [master]
GO
ALTER DATABASE [IdentificationBd] SET  READ_WRITE 
GO
