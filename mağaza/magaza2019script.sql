USE [master]
GO
/****** Object:  Database [magazalar]    Script Date: 31.5.2022 19:55:53 ******/
CREATE DATABASE [magazalar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'magazalar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\magazalar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'magazalar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\magazalar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [magazalar] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [magazalar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [magazalar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [magazalar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [magazalar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [magazalar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [magazalar] SET ARITHABORT OFF 
GO
ALTER DATABASE [magazalar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [magazalar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [magazalar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [magazalar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [magazalar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [magazalar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [magazalar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [magazalar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [magazalar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [magazalar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [magazalar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [magazalar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [magazalar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [magazalar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [magazalar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [magazalar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [magazalar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [magazalar] SET RECOVERY FULL 
GO
ALTER DATABASE [magazalar] SET  MULTI_USER 
GO
ALTER DATABASE [magazalar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [magazalar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [magazalar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [magazalar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [magazalar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [magazalar] SET QUERY_STORE = OFF
GO
USE [magazalar]
GO
/****** Object:  User [HP_\RÜKNA]    Script Date: 31.5.2022 19:55:53 ******/
CREATE USER [HP_\RÜKNA] FOR LOGIN [HP_\RÜKNA] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_datareader] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [HP_\RÜKNA]
GO
/****** Object:  Table [dbo].[bolumler]    Script Date: 31.5.2022 19:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bolumler](
	[bolumno] [int] IDENTITY(1,1) NOT NULL,
	[sorumluno] [int] NULL,
	[bolumadi] [varchar](50) NULL,
	[bolumurunsayisi] [int] NULL,
 CONSTRAINT [PK_bolumler] PRIMARY KEY CLUSTERED 
(
	[bolumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanicilar]    Script Date: 31.5.2022 19:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanicilar](
	[kullanicino] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciadi] [varchar](50) NULL,
	[sifre] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
	[telefon] [char](15) NULL,
 CONSTRAINT [PK_kullanicilar] PRIMARY KEY CLUSTERED 
(
	[kullanicino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[magaza]    Script Date: 31.5.2022 19:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[magaza](
	[magazano] [int] IDENTITY(1,1) NOT NULL,
	[magazaadi] [varchar](50) NULL,
	[magazaciro] [varchar](50) NULL,
	[magazaadres] [varchar](50) NULL,
	[sevkiyattarih] [varchar](50) NULL,
	[sevkiyatgunu] [varchar](50) NULL,
 CONSTRAINT [PK_magaza] PRIMARY KEY CLUSTERED 
(
	[magazano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[malzeme]    Script Date: 31.5.2022 19:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[malzeme](
	[malzemeno] [int] IDENTITY(1,1) NOT NULL,
	[magazano] [int] NULL,
	[malzemeadi] [varchar](50) NULL,
	[malzemeadet] [int] NULL,
	[malzemebirimfiyat] [money] NULL,
	[malzemekod] [varchar](50) NULL,
	[malzemeaciklama] [varchar](50) NULL,
 CONSTRAINT [PK_malzeme] PRIMARY KEY CLUSTERED 
(
	[malzemeno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sorumlu]    Script Date: 31.5.2022 19:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sorumlu](
	[sorumluno] [int] IDENTITY(1,1) NOT NULL,
	[magazano] [int] NULL,
	[sorumluadi] [varchar](50) NULL,
	[sorumlumaas] [money] NULL,
	[sorumluprim] [money] NULL,
	[sorumluvardiya] [varchar](50) NULL,
 CONSTRAINT [PK_sorumlu] PRIMARY KEY CLUSTERED 
(
	[sorumluno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bolumler] ON 

INSERT [dbo].[bolumler] ([bolumno], [sorumluno], [bolumadi], [bolumurunsayisi]) VALUES (1, 1, N'Satın Alma', 3)
INSERT [dbo].[bolumler] ([bolumno], [sorumluno], [bolumadi], [bolumurunsayisi]) VALUES (2, 2, N'Giyim', 5)
INSERT [dbo].[bolumler] ([bolumno], [sorumluno], [bolumadi], [bolumurunsayisi]) VALUES (3, 3, N'Muhasebe', 2)
INSERT [dbo].[bolumler] ([bolumno], [sorumluno], [bolumadi], [bolumurunsayisi]) VALUES (4, 4, N'Halkla İlişkiler', 2)
INSERT [dbo].[bolumler] ([bolumno], [sorumluno], [bolumadi], [bolumurunsayisi]) VALUES (5, 5, N'Lojistik ', 5)
SET IDENTITY_INSERT [dbo].[bolumler] OFF
GO
SET IDENTITY_INSERT [dbo].[kullanicilar] ON 

INSERT [dbo].[kullanicilar] ([kullanicino], [kullaniciadi], [sifre], [mail], [telefon]) VALUES (3, N'rükna', N'1234', N'rukna@gmail.com', N'5698989589     ')
INSERT [dbo].[kullanicilar] ([kullanicino], [kullaniciadi], [sifre], [mail], [telefon]) VALUES (2007, N'Rükna', N'1234', N'kavrasrukna@gmail.com', N'(535) 986-9659 ')
SET IDENTITY_INSERT [dbo].[kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[magaza] ON 

INSERT [dbo].[magaza] ([magazano], [magazaadi], [magazaciro], [magazaadres], [sevkiyattarih], [sevkiyatgunu]) VALUES (1, N'defacto', N'10000', N'sancaktepe', N'01.02.2022', N'03.02.2022')
INSERT [dbo].[magaza] ([magazano], [magazaadi], [magazaciro], [magazaadres], [sevkiyattarih], [sevkiyatgunu]) VALUES (2, N'lc waikiki', N'20000', N'ümraniye', N'02.02.2022', N'04.03.2022')
INSERT [dbo].[magaza] ([magazano], [magazaadi], [magazaciro], [magazaadres], [sevkiyattarih], [sevkiyatgunu]) VALUES (3, N'koton', N'25000', N'üsküdar', N'01.01.2021', N'03.02.2022')
INSERT [dbo].[magaza] ([magazano], [magazaadi], [magazaciro], [magazaadres], [sevkiyattarih], [sevkiyatgunu]) VALUES (4, N'zara', N'30000', N'maltepe', N'3 Şubat 2020 Pazartesi', N'04.02.2022')
SET IDENTITY_INSERT [dbo].[magaza] OFF
GO
SET IDENTITY_INSERT [dbo].[malzeme] ON 

INSERT [dbo].[malzeme] ([malzemeno], [magazano], [malzemeadi], [malzemeadet], [malzemebirimfiyat], [malzemekod], [malzemeaciklama]) VALUES (1, 1, N'kazak', 10, 60.0000, N'k1', N'yünlü ve boğazlı')
INSERT [dbo].[malzeme] ([malzemeno], [magazano], [malzemeadi], [malzemeadet], [malzemebirimfiyat], [malzemekod], [malzemeaciklama]) VALUES (2, 1, N'pantolon', 5, 120.0000, N'p1', N'kumaş ve  havuç kesim')
INSERT [dbo].[malzeme] ([malzemeno], [magazano], [malzemeadi], [malzemeadet], [malzemebirimfiyat], [malzemekod], [malzemeaciklama]) VALUES (3, 2, N'elbise', 30, 95.0000, N'e1', N'midi boy')
INSERT [dbo].[malzeme] ([malzemeno], [magazano], [malzemeadi], [malzemeadet], [malzemebirimfiyat], [malzemekod], [malzemeaciklama]) VALUES (4, 3, N'gömlek', 45, 100.0000, N'g1', N'viskon')
INSERT [dbo].[malzeme] ([malzemeno], [magazano], [malzemeadi], [malzemeadet], [malzemebirimfiyat], [malzemekod], [malzemeaciklama]) VALUES (5, 4, N'ceket', 55, 250.0000, N'c1', N'deri')
SET IDENTITY_INSERT [dbo].[malzeme] OFF
GO
SET IDENTITY_INSERT [dbo].[sorumlu] ON 

INSERT [dbo].[sorumlu] ([sorumluno], [magazano], [sorumluadi], [sorumlumaas], [sorumluprim], [sorumluvardiya]) VALUES (1, 1, N'rükna kavraş', 12000.0000, 2000.0000, N'güzdüz')
INSERT [dbo].[sorumlu] ([sorumluno], [magazano], [sorumluadi], [sorumlumaas], [sorumluprim], [sorumluvardiya]) VALUES (2, 2, N'kübra şahin', 10000.0000, 1500.0000, N'gündüz')
INSERT [dbo].[sorumlu] ([sorumluno], [magazano], [sorumluadi], [sorumlumaas], [sorumluprim], [sorumluvardiya]) VALUES (3, 3, N'şevval çelik', 7500.0000, 1500.0000, N'gece')
INSERT [dbo].[sorumlu] ([sorumluno], [magazano], [sorumluadi], [sorumlumaas], [sorumluprim], [sorumluvardiya]) VALUES (4, 3, N'ayşe uğuz', 8500.0000, 1200.0000, N'gece')
INSERT [dbo].[sorumlu] ([sorumluno], [magazano], [sorumluadi], [sorumlumaas], [sorumluprim], [sorumluvardiya]) VALUES (5, 4, N'mehmet öztürk', 9000.0000, 1200.0000, N'gündüz')
SET IDENTITY_INSERT [dbo].[sorumlu] OFF
GO
ALTER TABLE [dbo].[bolumler]  WITH CHECK ADD  CONSTRAINT [FK_bolumler_sorumlu] FOREIGN KEY([sorumluno])
REFERENCES [dbo].[sorumlu] ([sorumluno])
GO
ALTER TABLE [dbo].[bolumler] CHECK CONSTRAINT [FK_bolumler_sorumlu]
GO
ALTER TABLE [dbo].[malzeme]  WITH CHECK ADD  CONSTRAINT [FK_malzeme_magaza] FOREIGN KEY([magazano])
REFERENCES [dbo].[magaza] ([magazano])
GO
ALTER TABLE [dbo].[malzeme] CHECK CONSTRAINT [FK_malzeme_magaza]
GO
ALTER TABLE [dbo].[sorumlu]  WITH CHECK ADD  CONSTRAINT [FK_sorumlu_magaza] FOREIGN KEY([magazano])
REFERENCES [dbo].[magaza] ([magazano])
GO
ALTER TABLE [dbo].[sorumlu] CHECK CONSTRAINT [FK_sorumlu_magaza]
GO
/****** Object:  StoredProcedure [dbo].[kullanicigiris]    Script Date: 31.5.2022 19:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kullanicigiris](
@kullaniciadi varchar(50),
@sifre varchar(50)
)
as 
begin
select * from kullanicilar where kullaniciadi=@kullaniciadi and sifre=@sifre
end
GO
USE [master]
GO
ALTER DATABASE [magazalar] SET  READ_WRITE 
GO
