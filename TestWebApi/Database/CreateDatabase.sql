USE [master]
GO
/****** Object:  Database [PassOffice]    Script Date: 7/2/2014 11:17:51 PM ******/
CREATE DATABASE [PassOffice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PassOffice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PassOffice.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PassOffice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PassOffice_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PassOffice] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PassOffice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PassOffice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PassOffice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PassOffice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PassOffice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PassOffice] SET ARITHABORT OFF 
GO
ALTER DATABASE [PassOffice] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PassOffice] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PassOffice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PassOffice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PassOffice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PassOffice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PassOffice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PassOffice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PassOffice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PassOffice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PassOffice] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PassOffice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PassOffice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PassOffice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PassOffice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PassOffice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PassOffice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PassOffice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PassOffice] SET RECOVERY FULL 
GO
ALTER DATABASE [PassOffice] SET  MULTI_USER 
GO
ALTER DATABASE [PassOffice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PassOffice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PassOffice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PassOffice] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PassOffice]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 7/2/2014 11:17:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PassportData]    Script Date: 7/2/2014 11:17:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassportData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[Surname] [nchar](20) NOT NULL,
	[Patronymic] [nchar](20) NOT NULL,
	[PassportNumber] [nchar](10) NOT NULL,
	[Sex] [int] NOT NULL,
	[Birthday] [date] NOT NULL,
	[City] [int] NOT NULL,
	[Address] [nchar](100) NOT NULL,
	[IssuedBy] [nchar](100) NOT NULL,
	[DateOfIssue] [date] NOT NULL,
	[Code] [nchar](7) NOT NULL,
 CONSTRAINT [PK_PassportData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sex]    Script Date: 7/2/2014 11:17:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sex](
	[Id] [int] NOT NULL,
	[Gender] [nchar](3) NOT NULL,
 CONSTRAINT [PK_Sex] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAuthorization]    Script Date: 7/2/2014 11:17:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthorization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nchar](20) NOT NULL,
	[Password] [nchar](20) NOT NULL,
 CONSTRAINT [PK_UserAuthorization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[Passport]    Script Date: 7/2/2014 11:17:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Passport] as
select p.Name,p.Surname,p.Patronymic,p.PassportNumber, s.Gender as Sex,p.Birthday ,c.City, p.Address,p.IssuedBy,p.DateOfIssue,p.Code
from Cities c, Sex s, PassportData p
where p.Sex = s.Id and
	p.City = c.Id
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Cities] FOREIGN KEY([Id])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Cities]
GO
ALTER TABLE [dbo].[PassportData]  WITH CHECK ADD  CONSTRAINT [FK_PassportData_Cities] FOREIGN KEY([City])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[PassportData] CHECK CONSTRAINT [FK_PassportData_Cities]
GO
ALTER TABLE [dbo].[PassportData]  WITH CHECK ADD  CONSTRAINT [FK_PassportData_Sex] FOREIGN KEY([Sex])
REFERENCES [dbo].[Sex] ([Id])
GO
ALTER TABLE [dbo].[PassportData] CHECK CONSTRAINT [FK_PassportData_Sex]
GO
ALTER TABLE [dbo].[Sex]  WITH CHECK ADD  CONSTRAINT [FK_Sex_Sex] FOREIGN KEY([Id])
REFERENCES [dbo].[Sex] ([Id])
GO
ALTER TABLE [dbo].[Sex] CHECK CONSTRAINT [FK_Sex_Sex]
GO
USE [master]
GO
ALTER DATABASE [PassOffice] SET  READ_WRITE 
GO
