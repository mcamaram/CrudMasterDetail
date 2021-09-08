USE [master]
GO
/****** Object:  Database [AlbumMasterDetail]    Script Date: 08/09/2021 04:37:08 p. m. ******/
CREATE DATABASE [AlbumMasterDetail]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AlbumMasterDetail', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLSERVER16\MSSQL\DATA\AlbumMasterDetail.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AlbumMasterDetail_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLSERVER16\MSSQL\DATA\AlbumMasterDetail_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AlbumMasterDetail] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AlbumMasterDetail].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AlbumMasterDetail] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET ARITHABORT OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AlbumMasterDetail] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AlbumMasterDetail] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AlbumMasterDetail] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AlbumMasterDetail] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AlbumMasterDetail] SET  MULTI_USER 
GO
ALTER DATABASE [AlbumMasterDetail] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AlbumMasterDetail] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AlbumMasterDetail] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AlbumMasterDetail] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AlbumMasterDetail] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AlbumMasterDetail] SET QUERY_STORE = OFF
GO
USE [AlbumMasterDetail]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AlbumMasterDetail]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 08/09/2021 04:37:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Author] [varchar](50) NULL,
	[ReleaseDate] [date] NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 08/09/2021 04:37:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[Id] [uniqueidentifier] NOT NULL,
	[AlbumId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[Minutes] [smallint] NULL,
 CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Songs] ADD  CONSTRAINT [DF_Songs_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Songs] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Songs]
GO
/****** Object:  StoredProcedure [dbo].[spInsertAlbum]    Script Date: 08/09/2021 04:37:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertAlbum] 
	-- Add the parameters for the stored procedure here
@Id uniqueidentifier,
@Name varchar(50),
@Author varchar(50),
@ReleaseDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Album(Id,Name,Author,ReleaseDate)VALUES(@Id,@Name,@Author, @ReleaseDate);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertSong]    Script Date: 08/09/2021 04:37:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertSong] 
	-- Add the parameters for the stored procedure here
@AlbumId uniqueidentifier,
@Name varchar(50),
@Minutes smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Songs(AlbumId,Name,Minutes)VALUES(@AlbumId,@Name,@Minutes);
END
GO
USE [master]
GO
ALTER DATABASE [AlbumMasterDetail] SET  READ_WRITE 
GO
