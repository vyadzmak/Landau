USE [master]
GO
/****** Object:  Database [LandauDoc]    Script Date: 04/03/2016 23:11:48 ******/
CREATE DATABASE [LandauDoc] ON  PRIMARY 
( NAME = N'LandauDoc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\LandauDoc.mdf' , SIZE = 46080KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LandauDoc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\LandauDoc_log.ldf' , SIZE = 321088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LandauDoc] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LandauDoc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LandauDoc] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [LandauDoc] SET ANSI_NULLS OFF
GO
ALTER DATABASE [LandauDoc] SET ANSI_PADDING OFF
GO
ALTER DATABASE [LandauDoc] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [LandauDoc] SET ARITHABORT OFF
GO
ALTER DATABASE [LandauDoc] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [LandauDoc] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [LandauDoc] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [LandauDoc] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [LandauDoc] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [LandauDoc] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [LandauDoc] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [LandauDoc] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [LandauDoc] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [LandauDoc] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [LandauDoc] SET  DISABLE_BROKER
GO
ALTER DATABASE [LandauDoc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [LandauDoc] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [LandauDoc] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [LandauDoc] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [LandauDoc] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [LandauDoc] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [LandauDoc] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [LandauDoc] SET  READ_WRITE
GO
ALTER DATABASE [LandauDoc] SET RECOVERY SIMPLE
GO
ALTER DATABASE [LandauDoc] SET  MULTI_USER
GO
ALTER DATABASE [LandauDoc] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [LandauDoc] SET DB_CHAINING OFF
GO
USE [LandauDoc]
GO
/****** Object:  User [landauadmin]    Script Date: 04/03/2016 23:11:48 ******/
CREATE USER [landauadmin] FOR LOGIN [landauadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[SourceDocumentStates]    Script Date: 04/03/2016 23:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceDocumentStates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_SourceDocumentStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeAnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeAnalyticData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TypeAnalyticData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableGroups]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartGroup] [int] NOT NULL,
	[EndGroup] [int] NOT NULL,
	[SheetId] [int] NOT NULL,
	[HorizontalGroup] [bit] NOT NULL,
 CONSTRAINT [PK_TableGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SettingsName] [nvarchar](50) NOT NULL,
	[SettingsValue] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Row]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Row](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[BodyId] [int] NOT NULL,
 CONSTRAINT [PK_Row] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportDocumentTypeCatalog]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportDocumentTypeCatalog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ReportDocumentTypeCatalog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportCellTypeCatalog]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportCellTypeCatalog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[IsClassificator] [bit] NULL,
 CONSTRAINT [PK_ReportCellTypeCatalog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViewTypes]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViewTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ViewTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModalView]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModalView](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ModalView] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTable]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LogTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineType]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_LineType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentInfo]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentInfo](
	[Id] [int] NOT NULL,
	[DocumentType] [nvarchar](250) NULL,
	[DocumentVersion] [nvarchar](32) NULL,
	[AccountNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_DocumentInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoveCategories]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoveCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_MoveCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectStates]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ProjectStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PieChart]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieChart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnalyticDataId] [int] NOT NULL,
	[Description] [nvarchar](70) NULL,
 CONSTRAINT [PK_PieChart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationType]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_OperationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationState]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateDescription] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_OperationState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[RegistrationNumber] [int] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[IsClient] [bit] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellStyleTemplates]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellStyleTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FontWeight] [nvarchar](50) NOT NULL,
	[BackgroundColor] [nvarchar](50) NOT NULL,
	[FontColor] [nvarchar](50) NOT NULL,
	[CellType] [nvarchar](50) NULL,
	[Align] [nvarchar](50) NULL,
	[DFM] [nvarchar](50) NULL,
	[Height] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[FontFamily] [nvarchar](50) NULL,
	[FontStyle] [nvarchar](50) NOT NULL,
	[DecorLine] [nvarchar](50) NULL,
	[Indent] [int] NOT NULL,
	[FontSize] [int] NOT NULL,
	[CellDataFormat] [nvarchar](50) NULL,
	[Calculation] [bit] NULL,
 CONSTRAINT [PK_CellStyleTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellStyles]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellStyles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FontWeight] [nvarchar](50) NULL,
	[FontSize] [int] NULL,
	[BackgroundColor] [nvarchar](50) NULL,
	[FontColor] [nvarchar](50) NULL,
	[CellType] [nvarchar](50) NULL,
	[CellDataFormat] [nvarchar](50) NULL,
	[Align] [nvarchar](50) NULL,
	[DFM] [nvarchar](150) NULL,
	[CellId] [int] NOT NULL,
	[Height] [int] NULL,
	[Width] [int] NULL,
	[FontFamily] [nvarchar](50) NULL,
	[Calc] [bit] NULL,
	[DecorLine] [nvarchar](20) NULL,
	[FontStyle] [nvarchar](50) NULL,
	[Indent] [int] NULL,
 CONSTRAINT [PK_CellStyles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HtmlForms]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HtmlForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Html] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HtmlForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentTypes]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](20) NULL,
 CONSTRAINT [PK_DocumentTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentState]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_DocumentState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Body]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Body](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SheetId] [int] NOT NULL,
 CONSTRAINT [PK_Body] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorderPosition]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorderPosition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_BorderPosition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellComments]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](150) NULL,
	[CellId] [int] NOT NULL,
 CONSTRAINT [PK_CellComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cell]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cell](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Value] [nvarchar](150) NULL,
	[RowId] [int] NOT NULL,
	[ModalViewId] [int] NULL,
	[CellStyleId] [int] NULL,
	[ReportCellType] [int] NULL,
	[ReportDocumentType] [int] NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
	[SourceDocumentRowNumber] [int] NULL,
	[SourceDocumentHash] [nvarchar](150) NULL,
 CONSTRAINT [PK_Cell] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorderStyle]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorderStyle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SheetId] [int] NOT NULL,
	[StartRowNum] [int] NOT NULL,
	[StartColNum] [int] NOT NULL,
	[EndRowNum] [int] NOT NULL,
	[EndColNum] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[LineTypeId] [int] NOT NULL,
	[Width] [int] NULL,
	[Color] [nvarchar](25) NULL,
 CONSTRAINT [PK_BorderStyle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operations]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeAddToQueue] [datetime] NOT NULL,
	[ClientId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationType] [int] NULL,
	[OperationState] [int] NULL,
	[OperationCommand] [nvarchar](max) NULL,
 CONSTRAINT [PK_Operations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ClientId] [int] NOT NULL,
	[State] [int] NOT NULL,
	[ProjectName] [nvarchar](250) NULL,
	[SourceDocumentsIsLoaded] [bit] NOT NULL,
	[Period] [nvarchar](450) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PieChartElement]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieChartElement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PieChartId] [int] NOT NULL,
	[Value] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_PieChartId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModalViewRow]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModalViewRow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModalViewId] [int] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_ModalViewRow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[SecondName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
	[Roles] [int] NOT NULL,
	[Rights] [nvarchar](50) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelationCells]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelationCells](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CellId] [int] NULL,
	[SourceFileHash] [nvarchar](150) NULL,
	[RowNumber] [int] NULL,
 CONSTRAINT [PK_RelationCells] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceDocuments]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[FileSize] [float] NOT NULL,
	[FilePath] [nvarchar](255) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Extension] [nvarchar](10) NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[DocumentType] [nvarchar](50) NULL,
	[Version] [int] NULL,
	[Year] [nvarchar](50) NULL,
	[Quarter] [nvarchar](50) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[State] [int] NULL,
	[ProjectId] [int] NULL,
	[UserId] [int] NULL,
	[Hash] [nvarchar](150) NULL,
 CONSTRAINT [PK_SourceDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[IsLocked] [bit] NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModalViewCell]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModalViewCell](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowId] [int] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_ModalViewCell_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[DocumentType] [int] NOT NULL,
	[State] [int] NOT NULL,
	[ServerPath] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](60) NOT NULL,
	[FileSize] [nvarchar](50) NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[CRC] [nvarchar](64) NOT NULL,
	[UserId] [int] NOT NULL,
	[ViewType] [int] NOT NULL,
	[DocumentInfoId] [int] NULL,
	[IsReaded] [bit] NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [int] NOT NULL,
	[UserIdSend] [int] NOT NULL,
	[UserIdGet] [int] NOT NULL,
	[Data] [nvarchar](4000) NOT NULL,
	[Date] [datetime] NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnalyticData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[ModalViewCellId] [int] NULL,
 CONSTRAINT [PK_AnalyticData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentControlVersion]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentControlVersion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocId] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentControlVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sheet]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[DocumentId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceDocumentSheet]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceDocumentSheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceDocumentId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_SourceDocumentSheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableModal]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableModal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnalyticDataId] [int] NOT NULL,
	[Description] [nvarchar](150) NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_TableModal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StackedBarchart]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StackedBarchart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[AnalyticDataId] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_StackedBarchart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceDocumentRow]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceDocumentRow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceDocumentSheetId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[ClassifierType] [int] NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_SourceDocumentRow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NonStackedBarChart]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NonStackedBarChart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[AnalyticDataId] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_NonStackedBarChart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineChart]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineChart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnalyticDataId] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Type] [nvarchar](50) NULL,
	[Title] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LineChart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoveTable]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoveTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AnalyticDataId] [int] NOT NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_MoveTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BarChart]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BarChart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnalyticDataId] [int] NOT NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_BarChart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BodyModal]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BodyModal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableModalId] [int] NOT NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_BodyModal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BarChartElement]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BarChartElement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionY] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](150) NULL,
	[BarChartId] [int] NOT NULL,
 CONSTRAINT [PK_BarChartElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineChartElement]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineChartElement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LineChartId] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_LineChartElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoveTableRow]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoveTableRow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[MoveTableId] [int] NOT NULL,
	[MoveCategoryId] [int] NULL,
 CONSTRAINT [PK_MoveTableRow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceDocumentCell]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceDocumentCell](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceDocumentRowId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ValueType] [nvarchar](250) NOT NULL,
	[DocumentType] [int] NULL,
	[AnalyticDataType] [int] NULL,
 CONSTRAINT [PK_SourceDocumentCell] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NonStackedBarChartColumn]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NonStackedBarChartColumn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionX] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[NonStackedBarchartId] [int] NOT NULL,
 CONSTRAINT [PK_NonStackedBarChartColumn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StackedBarchartColumn]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StackedBarchartColumn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionX] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[StackedBarChartId] [int] NOT NULL,
 CONSTRAINT [PK_StackedBarchartColumn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StackedBarchartElement]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StackedBarchartElement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Value] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](250) NOT NULL,
	[BarchartColumnId] [int] NOT NULL,
 CONSTRAINT [PK_StackedBarchartElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RowModal]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RowModal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModalBodyId] [int] NOT NULL,
	[Number] [int] NULL,
 CONSTRAINT [PK_RowModal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoveTableCell]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoveTableCell](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[MoveTableRowId] [int] NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](150) NULL,
 CONSTRAINT [PK_MoveTableCell] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NonStackedBarChartElement]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NonStackedBarChartElement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Value] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](250) NOT NULL,
	[NonStackedBarchartColumnId] [int] NOT NULL,
 CONSTRAINT [PK_NonStackedBarChartElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineChartPoint]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineChartPoint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionX] [nvarchar](50) NOT NULL,
	[PositionY] [nvarchar](50) NOT NULL,
	[LineChartElementId] [int] NOT NULL,
	[Category] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LineChartPoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellModal]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellModal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowModalId] [int] NOT NULL,
	[Value] [nvarchar](150) NOT NULL,
	[IsHyperLink] [bit] NOT NULL,
	[Number] [int] NOT NULL,
	[ModalViewId] [int] NULL,
 CONSTRAINT [PK_CellModal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellModalStyle]    Script Date: 04/03/2016 23:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellModalStyle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FontSize] [int] NULL,
	[FontFamily] [nvarchar](50) NULL,
	[FontStyle] [nvarchar](50) NULL,
	[Align] [nvarchar](50) NULL,
	[LinkColor] [nvarchar](50) NULL,
	[FontColor] [nvarchar](50) NULL,
	[BackgroundColor] [nvarchar](50) NULL,
	[CellModalId] [int] NOT NULL,
 CONSTRAINT [PK_CellModalStyle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_ReportCellTypeCatalog_IsClassificator]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[ReportCellTypeCatalog] ADD  CONSTRAINT [DF_ReportCellTypeCatalog_IsClassificator]  DEFAULT ((1)) FOR [IsClassificator]
GO
/****** Object:  Default [DF_Projects_SourceDocumentsIsLoaded]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_SourceDocumentsIsLoaded]  DEFAULT ((0)) FOR [SourceDocumentsIsLoaded]
GO
/****** Object:  Default [DF_Documents_ProjectId]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Documents] ADD  CONSTRAINT [DF_Documents_ProjectId]  DEFAULT (NULL) FOR [ProjectId]
GO
/****** Object:  Default [DF_Documents_IsReaded]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Documents] ADD  CONSTRAINT [DF_Documents_IsReaded]  DEFAULT ((0)) FOR [IsReaded]
GO
/****** Object:  ForeignKey [FK_MoveCategories_MoveCategories]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[MoveCategories]  WITH CHECK ADD  CONSTRAINT [FK_MoveCategories_MoveCategories] FOREIGN KEY([Id])
REFERENCES [dbo].[MoveCategories] ([Id])
GO
ALTER TABLE [dbo].[MoveCategories] CHECK CONSTRAINT [FK_MoveCategories_MoveCategories]
GO
/****** Object:  ForeignKey [FK_CellStyleTemplates_CellStyleTemplates]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[CellStyleTemplates]  WITH CHECK ADD  CONSTRAINT [FK_CellStyleTemplates_CellStyleTemplates] FOREIGN KEY([Id])
REFERENCES [dbo].[CellStyleTemplates] ([Id])
GO
ALTER TABLE [dbo].[CellStyleTemplates] CHECK CONSTRAINT [FK_CellStyleTemplates_CellStyleTemplates]
GO
/****** Object:  ForeignKey [FK_Cell_ReportCellTypeCatalog]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Cell]  WITH CHECK ADD  CONSTRAINT [FK_Cell_ReportCellTypeCatalog] FOREIGN KEY([ReportCellType])
REFERENCES [dbo].[ReportCellTypeCatalog] ([Id])
GO
ALTER TABLE [dbo].[Cell] CHECK CONSTRAINT [FK_Cell_ReportCellTypeCatalog]
GO
/****** Object:  ForeignKey [FK_Cell_ReportDocumentTypeCatalog]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Cell]  WITH CHECK ADD  CONSTRAINT [FK_Cell_ReportDocumentTypeCatalog] FOREIGN KEY([ReportDocumentType])
REFERENCES [dbo].[ReportDocumentTypeCatalog] ([Id])
GO
ALTER TABLE [dbo].[Cell] CHECK CONSTRAINT [FK_Cell_ReportDocumentTypeCatalog]
GO
/****** Object:  ForeignKey [FK_Cell_Row]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Cell]  WITH CHECK ADD  CONSTRAINT [FK_Cell_Row] FOREIGN KEY([CellStyleId])
REFERENCES [dbo].[CellStyleTemplates] ([Id])
GO
ALTER TABLE [dbo].[Cell] CHECK CONSTRAINT [FK_Cell_Row]
GO
/****** Object:  ForeignKey [FK_BorderStyle_BorderPosition]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[BorderStyle]  WITH CHECK ADD  CONSTRAINT [FK_BorderStyle_BorderPosition] FOREIGN KEY([PositionId])
REFERENCES [dbo].[BorderPosition] ([Id])
GO
ALTER TABLE [dbo].[BorderStyle] CHECK CONSTRAINT [FK_BorderStyle_BorderPosition]
GO
/****** Object:  ForeignKey [FK_BorderStyle_LineType]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[BorderStyle]  WITH CHECK ADD  CONSTRAINT [FK_BorderStyle_LineType] FOREIGN KEY([LineTypeId])
REFERENCES [dbo].[LineType] ([Id])
GO
ALTER TABLE [dbo].[BorderStyle] CHECK CONSTRAINT [FK_BorderStyle_LineType]
GO
/****** Object:  ForeignKey [FK_Operations_OperationState]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Operations]  WITH CHECK ADD  CONSTRAINT [FK_Operations_OperationState] FOREIGN KEY([OperationState])
REFERENCES [dbo].[OperationState] ([Id])
GO
ALTER TABLE [dbo].[Operations] CHECK CONSTRAINT [FK_Operations_OperationState]
GO
/****** Object:  ForeignKey [FK_Operations_OperationType]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Operations]  WITH CHECK ADD  CONSTRAINT [FK_Operations_OperationType] FOREIGN KEY([OperationType])
REFERENCES [dbo].[OperationType] ([Id])
GO
ALTER TABLE [dbo].[Operations] CHECK CONSTRAINT [FK_Operations_OperationType]
GO
/****** Object:  ForeignKey [FK_Projects_Clients]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Clients]
GO
/****** Object:  ForeignKey [FK_Projects_ProjectStates]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectStates] FOREIGN KEY([State])
REFERENCES [dbo].[ProjectStates] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectStates]
GO
/****** Object:  ForeignKey [FK_PieChartElement_PieChart]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[PieChartElement]  WITH CHECK ADD  CONSTRAINT [FK_PieChartElement_PieChart] FOREIGN KEY([PieChartId])
REFERENCES [dbo].[PieChart] ([Id])
GO
ALTER TABLE [dbo].[PieChartElement] CHECK CONSTRAINT [FK_PieChartElement_PieChart]
GO
/****** Object:  ForeignKey [FK_ModalViewRow_ModalView]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[ModalViewRow]  WITH CHECK ADD  CONSTRAINT [FK_ModalViewRow_ModalView] FOREIGN KEY([ModalViewId])
REFERENCES [dbo].[ModalView] ([Id])
GO
ALTER TABLE [dbo].[ModalViewRow] CHECK CONSTRAINT [FK_ModalViewRow_ModalView]
GO
/****** Object:  ForeignKey [FK_Users_Clients]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Clients]
GO
/****** Object:  ForeignKey [FK_Users_UserRoles]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([Roles])
REFERENCES [dbo].[UserRoles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRoles]
GO
/****** Object:  ForeignKey [FK_RelationCells_Cell]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[RelationCells]  WITH CHECK ADD  CONSTRAINT [FK_RelationCells_Cell] FOREIGN KEY([CellId])
REFERENCES [dbo].[Cell] ([Id])
GO
ALTER TABLE [dbo].[RelationCells] CHECK CONSTRAINT [FK_RelationCells_Cell]
GO
/****** Object:  ForeignKey [FK_SourceDocuments_Projects]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocuments]  WITH CHECK ADD  CONSTRAINT [FK_SourceDocuments_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[SourceDocuments] CHECK CONSTRAINT [FK_SourceDocuments_Projects]
GO
/****** Object:  ForeignKey [FK_SourceDocuments_SourceDocumentStates1]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocuments]  WITH NOCHECK ADD  CONSTRAINT [FK_SourceDocuments_SourceDocumentStates1] FOREIGN KEY([State])
REFERENCES [dbo].[SourceDocumentStates] ([Id])
GO
ALTER TABLE [dbo].[SourceDocuments] CHECK CONSTRAINT [FK_SourceDocuments_SourceDocumentStates1]
GO
/****** Object:  ForeignKey [FK_SourceDocuments_Users]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocuments]  WITH CHECK ADD  CONSTRAINT [FK_SourceDocuments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SourceDocuments] CHECK CONSTRAINT [FK_SourceDocuments_Users]
GO
/****** Object:  ForeignKey [FK_UserLogins_Users1]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users1]
GO
/****** Object:  ForeignKey [FK_ModalViewCell_RowModal]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[ModalViewCell]  WITH CHECK ADD  CONSTRAINT [FK_ModalViewCell_RowModal] FOREIGN KEY([RowId])
REFERENCES [dbo].[ModalViewRow] ([Id])
GO
ALTER TABLE [dbo].[ModalViewCell] CHECK CONSTRAINT [FK_ModalViewCell_RowModal]
GO
/****** Object:  ForeignKey [FK_Documents_DocumentInfo]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_DocumentInfo] FOREIGN KEY([DocumentInfoId])
REFERENCES [dbo].[DocumentInfo] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_DocumentInfo]
GO
/****** Object:  ForeignKey [FK_Documents_DocumentState]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_DocumentState] FOREIGN KEY([State])
REFERENCES [dbo].[DocumentState] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_DocumentState]
GO
/****** Object:  ForeignKey [FK_Documents_DocumentTypes]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_DocumentTypes] FOREIGN KEY([DocumentType])
REFERENCES [dbo].[DocumentTypes] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_DocumentTypes]
GO
/****** Object:  ForeignKey [FK_Documents_Projects]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_Projects]
GO
/****** Object:  ForeignKey [FK_Documents_ViewTypes]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_ViewTypes] FOREIGN KEY([ViewType])
REFERENCES [dbo].[ViewTypes] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_ViewTypes]
GO
/****** Object:  ForeignKey [FK_Comments_Documents]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Documents] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Documents] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Documents]
GO
/****** Object:  ForeignKey [FK_AnalyticData_ModalViewCell]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[AnalyticData]  WITH CHECK ADD  CONSTRAINT [FK_AnalyticData_ModalViewCell] FOREIGN KEY([ModalViewCellId])
REFERENCES [dbo].[ModalViewCell] ([Id])
GO
ALTER TABLE [dbo].[AnalyticData] CHECK CONSTRAINT [FK_AnalyticData_ModalViewCell]
GO
/****** Object:  ForeignKey [FK_AnalyticData_TypeAnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[AnalyticData]  WITH CHECK ADD  CONSTRAINT [FK_AnalyticData_TypeAnalyticData] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TypeAnalyticData] ([Id])
GO
ALTER TABLE [dbo].[AnalyticData] CHECK CONSTRAINT [FK_AnalyticData_TypeAnalyticData]
GO
/****** Object:  ForeignKey [FK_DocumentControlVersion_Documents]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[DocumentControlVersion]  WITH CHECK ADD  CONSTRAINT [FK_DocumentControlVersion_Documents] FOREIGN KEY([DocId])
REFERENCES [dbo].[Documents] ([Id])
GO
ALTER TABLE [dbo].[DocumentControlVersion] CHECK CONSTRAINT [FK_DocumentControlVersion_Documents]
GO
/****** Object:  ForeignKey [FK_DocumentControlVersion_Users]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[DocumentControlVersion]  WITH CHECK ADD  CONSTRAINT [FK_DocumentControlVersion_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DocumentControlVersion] CHECK CONSTRAINT [FK_DocumentControlVersion_Users]
GO
/****** Object:  ForeignKey [FK_Sheet_Documents]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[Sheet]  WITH CHECK ADD  CONSTRAINT [FK_Sheet_Documents] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Documents] ([Id])
GO
ALTER TABLE [dbo].[Sheet] CHECK CONSTRAINT [FK_Sheet_Documents]
GO
/****** Object:  ForeignKey [FK_SourceDocumentSheet_SourceDocuments]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocumentSheet]  WITH CHECK ADD  CONSTRAINT [FK_SourceDocumentSheet_SourceDocuments] FOREIGN KEY([SourceDocumentId])
REFERENCES [dbo].[SourceDocuments] ([Id])
GO
ALTER TABLE [dbo].[SourceDocumentSheet] CHECK CONSTRAINT [FK_SourceDocumentSheet_SourceDocuments]
GO
/****** Object:  ForeignKey [FK_TableModal_AnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[TableModal]  WITH CHECK ADD  CONSTRAINT [FK_TableModal_AnalyticData] FOREIGN KEY([AnalyticDataId])
REFERENCES [dbo].[AnalyticData] ([Id])
GO
ALTER TABLE [dbo].[TableModal] CHECK CONSTRAINT [FK_TableModal_AnalyticData]
GO
/****** Object:  ForeignKey [FK_StackedBarchart_AnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[StackedBarchart]  WITH CHECK ADD  CONSTRAINT [FK_StackedBarchart_AnalyticData] FOREIGN KEY([AnalyticDataId])
REFERENCES [dbo].[AnalyticData] ([Id])
GO
ALTER TABLE [dbo].[StackedBarchart] CHECK CONSTRAINT [FK_StackedBarchart_AnalyticData]
GO
/****** Object:  ForeignKey [FK_SourceDocumentRow_SourceDocumentSheet]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocumentRow]  WITH CHECK ADD  CONSTRAINT [FK_SourceDocumentRow_SourceDocumentSheet] FOREIGN KEY([SourceDocumentSheetId])
REFERENCES [dbo].[SourceDocumentSheet] ([Id])
GO
ALTER TABLE [dbo].[SourceDocumentRow] CHECK CONSTRAINT [FK_SourceDocumentRow_SourceDocumentSheet]
GO
/****** Object:  ForeignKey [FK_NonStackedBarChart_AnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[NonStackedBarChart]  WITH CHECK ADD  CONSTRAINT [FK_NonStackedBarChart_AnalyticData] FOREIGN KEY([AnalyticDataId])
REFERENCES [dbo].[AnalyticData] ([Id])
GO
ALTER TABLE [dbo].[NonStackedBarChart] CHECK CONSTRAINT [FK_NonStackedBarChart_AnalyticData]
GO
/****** Object:  ForeignKey [FK_LineChart_AnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[LineChart]  WITH CHECK ADD  CONSTRAINT [FK_LineChart_AnalyticData] FOREIGN KEY([AnalyticDataId])
REFERENCES [dbo].[AnalyticData] ([Id])
GO
ALTER TABLE [dbo].[LineChart] CHECK CONSTRAINT [FK_LineChart_AnalyticData]
GO
/****** Object:  ForeignKey [FK_MoveTable_AnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[MoveTable]  WITH CHECK ADD  CONSTRAINT [FK_MoveTable_AnalyticData] FOREIGN KEY([AnalyticDataId])
REFERENCES [dbo].[AnalyticData] ([Id])
GO
ALTER TABLE [dbo].[MoveTable] CHECK CONSTRAINT [FK_MoveTable_AnalyticData]
GO
/****** Object:  ForeignKey [FK_BarChart_AnalyticData]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[BarChart]  WITH CHECK ADD  CONSTRAINT [FK_BarChart_AnalyticData] FOREIGN KEY([AnalyticDataId])
REFERENCES [dbo].[AnalyticData] ([Id])
GO
ALTER TABLE [dbo].[BarChart] CHECK CONSTRAINT [FK_BarChart_AnalyticData]
GO
/****** Object:  ForeignKey [FK_BodyModal_TableModal]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[BodyModal]  WITH CHECK ADD  CONSTRAINT [FK_BodyModal_TableModal] FOREIGN KEY([TableModalId])
REFERENCES [dbo].[TableModal] ([Id])
GO
ALTER TABLE [dbo].[BodyModal] CHECK CONSTRAINT [FK_BodyModal_TableModal]
GO
/****** Object:  ForeignKey [FK_BarChartElement_BarChart]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[BarChartElement]  WITH CHECK ADD  CONSTRAINT [FK_BarChartElement_BarChart] FOREIGN KEY([BarChartId])
REFERENCES [dbo].[BarChart] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BarChartElement] CHECK CONSTRAINT [FK_BarChartElement_BarChart]
GO
/****** Object:  ForeignKey [FK_LineChartElement_LineChart]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[LineChartElement]  WITH CHECK ADD  CONSTRAINT [FK_LineChartElement_LineChart] FOREIGN KEY([LineChartId])
REFERENCES [dbo].[LineChart] ([Id])
GO
ALTER TABLE [dbo].[LineChartElement] CHECK CONSTRAINT [FK_LineChartElement_LineChart]
GO
/****** Object:  ForeignKey [FK_MoveTableRow_MoveCategories]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[MoveTableRow]  WITH CHECK ADD  CONSTRAINT [FK_MoveTableRow_MoveCategories] FOREIGN KEY([MoveCategoryId])
REFERENCES [dbo].[MoveCategories] ([Id])
GO
ALTER TABLE [dbo].[MoveTableRow] CHECK CONSTRAINT [FK_MoveTableRow_MoveCategories]
GO
/****** Object:  ForeignKey [FK_MoveTableRow_MoveTable]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[MoveTableRow]  WITH CHECK ADD  CONSTRAINT [FK_MoveTableRow_MoveTable] FOREIGN KEY([MoveTableId])
REFERENCES [dbo].[MoveTable] ([Id])
GO
ALTER TABLE [dbo].[MoveTableRow] CHECK CONSTRAINT [FK_MoveTableRow_MoveTable]
GO
/****** Object:  ForeignKey [FK_SourceDocumentCell_ReportCellTypeCatalog]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocumentCell]  WITH CHECK ADD  CONSTRAINT [FK_SourceDocumentCell_ReportCellTypeCatalog] FOREIGN KEY([AnalyticDataType])
REFERENCES [dbo].[ReportCellTypeCatalog] ([Id])
GO
ALTER TABLE [dbo].[SourceDocumentCell] CHECK CONSTRAINT [FK_SourceDocumentCell_ReportCellTypeCatalog]
GO
/****** Object:  ForeignKey [FK_SourceDocumentCell_ReportDocumentTypeCatalog]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocumentCell]  WITH CHECK ADD  CONSTRAINT [FK_SourceDocumentCell_ReportDocumentTypeCatalog] FOREIGN KEY([DocumentType])
REFERENCES [dbo].[ReportDocumentTypeCatalog] ([Id])
GO
ALTER TABLE [dbo].[SourceDocumentCell] CHECK CONSTRAINT [FK_SourceDocumentCell_ReportDocumentTypeCatalog]
GO
/****** Object:  ForeignKey [FK_SourceDocumentCell_SourceDocumentRow]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[SourceDocumentCell]  WITH CHECK ADD  CONSTRAINT [FK_SourceDocumentCell_SourceDocumentRow] FOREIGN KEY([SourceDocumentRowId])
REFERENCES [dbo].[SourceDocumentRow] ([Id])
GO
ALTER TABLE [dbo].[SourceDocumentCell] CHECK CONSTRAINT [FK_SourceDocumentCell_SourceDocumentRow]
GO
/****** Object:  ForeignKey [FK_NonStackedBarChartColumn_NonStackedBarChart]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[NonStackedBarChartColumn]  WITH CHECK ADD  CONSTRAINT [FK_NonStackedBarChartColumn_NonStackedBarChart] FOREIGN KEY([NonStackedBarchartId])
REFERENCES [dbo].[NonStackedBarChart] ([Id])
GO
ALTER TABLE [dbo].[NonStackedBarChartColumn] CHECK CONSTRAINT [FK_NonStackedBarChartColumn_NonStackedBarChart]
GO
/****** Object:  ForeignKey [FK_StackedBarchartColumn_StackedBarchart]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[StackedBarchartColumn]  WITH CHECK ADD  CONSTRAINT [FK_StackedBarchartColumn_StackedBarchart] FOREIGN KEY([StackedBarChartId])
REFERENCES [dbo].[StackedBarchart] ([Id])
GO
ALTER TABLE [dbo].[StackedBarchartColumn] CHECK CONSTRAINT [FK_StackedBarchartColumn_StackedBarchart]
GO
/****** Object:  ForeignKey [FK_StackedBarchartElement_StackedBarchartColumn]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[StackedBarchartElement]  WITH CHECK ADD  CONSTRAINT [FK_StackedBarchartElement_StackedBarchartColumn] FOREIGN KEY([BarchartColumnId])
REFERENCES [dbo].[StackedBarchartColumn] ([Id])
GO
ALTER TABLE [dbo].[StackedBarchartElement] CHECK CONSTRAINT [FK_StackedBarchartElement_StackedBarchartColumn]
GO
/****** Object:  ForeignKey [FK_RowModal_BodyModal]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[RowModal]  WITH CHECK ADD  CONSTRAINT [FK_RowModal_BodyModal] FOREIGN KEY([ModalBodyId])
REFERENCES [dbo].[BodyModal] ([Id])
GO
ALTER TABLE [dbo].[RowModal] CHECK CONSTRAINT [FK_RowModal_BodyModal]
GO
/****** Object:  ForeignKey [FK_MoveTableCell_MoveTableRow]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[MoveTableCell]  WITH CHECK ADD  CONSTRAINT [FK_MoveTableCell_MoveTableRow] FOREIGN KEY([MoveTableRowId])
REFERENCES [dbo].[MoveTableRow] ([Id])
GO
ALTER TABLE [dbo].[MoveTableCell] CHECK CONSTRAINT [FK_MoveTableCell_MoveTableRow]
GO
/****** Object:  ForeignKey [FK_NonStackedBarChartElement_NonStackedBarChartColumn]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[NonStackedBarChartElement]  WITH CHECK ADD  CONSTRAINT [FK_NonStackedBarChartElement_NonStackedBarChartColumn] FOREIGN KEY([NonStackedBarchartColumnId])
REFERENCES [dbo].[NonStackedBarChartColumn] ([Id])
GO
ALTER TABLE [dbo].[NonStackedBarChartElement] CHECK CONSTRAINT [FK_NonStackedBarChartElement_NonStackedBarChartColumn]
GO
/****** Object:  ForeignKey [FK_LineChartPoint_LineChartElement]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[LineChartPoint]  WITH CHECK ADD  CONSTRAINT [FK_LineChartPoint_LineChartElement] FOREIGN KEY([LineChartElementId])
REFERENCES [dbo].[LineChartElement] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LineChartPoint] CHECK CONSTRAINT [FK_LineChartPoint_LineChartElement]
GO
/****** Object:  ForeignKey [FK_CellModal_RowModal]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[CellModal]  WITH CHECK ADD  CONSTRAINT [FK_CellModal_RowModal] FOREIGN KEY([RowModalId])
REFERENCES [dbo].[RowModal] ([Id])
GO
ALTER TABLE [dbo].[CellModal] CHECK CONSTRAINT [FK_CellModal_RowModal]
GO
/****** Object:  ForeignKey [FK_CellModalStyle_CellModal]    Script Date: 04/03/2016 23:11:49 ******/
ALTER TABLE [dbo].[CellModalStyle]  WITH CHECK ADD  CONSTRAINT [FK_CellModalStyle_CellModal] FOREIGN KEY([CellModalId])
REFERENCES [dbo].[CellModal] ([Id])
GO
ALTER TABLE [dbo].[CellModalStyle] CHECK CONSTRAINT [FK_CellModalStyle_CellModal]
GO
