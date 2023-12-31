USE [master]
GO
/****** Object:  Database [GeneralateFathers3]    Script Date: 11/4/2019 10:08:24 PM ******/
CREATE DATABASE [GeneralateFathers3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GeneralateFathers3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GeneralateFathers3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GeneralateFathers3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GeneralateFathers3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GeneralateFathers3] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GeneralateFathers3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GeneralateFathers3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET ARITHABORT OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GeneralateFathers3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GeneralateFathers3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GeneralateFathers3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GeneralateFathers3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GeneralateFathers3] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GeneralateFathers3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GeneralateFathers3] SET  MULTI_USER 
GO
ALTER DATABASE [GeneralateFathers3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GeneralateFathers3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GeneralateFathers3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GeneralateFathers3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GeneralateFathers3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GeneralateFathers3] SET QUERY_STORE = OFF
GO
USE [GeneralateFathers3]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [nvarchar](15) NULL,
	[Title] [nvarchar](15) NULL,
	[Date] [nvarchar](15) NULL,
	[EffectedDate] [nvarchar](15) NULL,
	[ToDate] [nvarchar](15) NULL,
	[doc] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[AppointmentType] [nvarchar](150) NULL,
	[drpNameType] [nvarchar](15) NULL,
	[DesignationType] [nvarchar](15) NULL,
	[InstitutionType] [nvarchar](15) NULL,
	[CommunityType] [nvarchar](15) NULL,
	[Superior] [nvarchar](15) NULL,
 CONSTRAINT [PK_dbo.Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongDatas]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongDatas](
	[id] [uniqueidentifier] NOT NULL,
	[CongId] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[File1] [nvarchar](50) NULL,
	[File2] [nvarchar](50) NULL,
	[File3] [nvarchar](50) NULL,
	[File4] [nvarchar](50) NULL,
	[File5] [nvarchar](50) NULL,
	[other1] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CongDatas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CounCircCommis]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CounCircCommis](
	[id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Describtion] [nvarchar](50) NULL,
	[Doc] [nvarchar](50) NULL,
	[FileName] [nvarchar](max) NULL,
	[EntryLifeId] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CounCircCommis] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataListItems]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataListItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataListName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Designation] [nvarchar](50) NULL,
	[Institution] [nvarchar](50) NULL,
	[Community] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_dbo.DataListItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataLists]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.DataLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyDetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[Relationship] [nvarchar](50) NULL,
	[YearOfBirth] [nvarchar](50) NULL,
	[YearOfDeath] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[EmergencyContact] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.FamilyDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sacraments]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sacraments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Sacrament] [nvarchar](50) NULL,
	[Minister] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[ChurchName] [nvarchar](50) NULL,
	[Remarks] [nvarchar](100) NULL,
	[MemberId] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Sacraments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocietyDatas]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocietyDatas](
	[id] [uniqueidentifier] NOT NULL,
	[SocId] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[File1] [nvarchar](50) NULL,
	[File2] [nvarchar](50) NULL,
	[File3] [nvarchar](50) NULL,
	[File4] [nvarchar](50) NULL,
	[File5] [nvarchar](50) NULL,
	[other1] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SocietyDatas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Societys]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Societys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [nvarchar](50) NULL,
	[PanNumber] [nvarchar](100) NULL,
	[NameOfTheSocity] [nvarchar](200) NULL,
	[FCRANumber] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Number12A] [nvarchar](50) NULL,
	[RegistrationNumber] [nvarchar](50) NULL,
	[Number80G] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Telno] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Societys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocInsPages]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocInsPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Describtion] [nvarchar](max) NULL,
	[Doc] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SocInsPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Academy]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Academy](
	[acaid] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[course] [nvarchar](50) NULL,
	[degree] [nvarchar](50) NULL,
	[university] [nvarchar](50) NULL,
	[fromdate] [nvarchar](50) NULL,
	[todate] [nvarchar](50) NULL,
	[classo] [nvarchar](50) NULL,
	[medium] [nvarchar](50) NULL,
	[adress] [nvarchar](200) NULL,
	[remark] [nvarchar](500) NULL,
	[doc] [nvarchar](max) NULL,
	[MemberId] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_Academy] PRIMARY KEY CLUSTERED 
(
	[acaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Bank_Details]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Bank_Details](
	[BankId] [bigint] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](100) NULL,
	[AccNum] [nvarchar](100) NULL,
	[IFCS] [nvarchar](10) NULL,
	[Branch] [nvarchar](10) NULL,
 CONSTRAINT [PK_dbo.tbl_Bank_Details] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_BookOfAccountsDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_BookOfAccountsDoc](
	[BookOfAccountsId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Place] [nvarchar](50) NULL,
	[Ammount] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_BookOfAccountsDoc] PRIMARY KEY CLUSTERED 
(
	[BookOfAccountsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CandidatesInformationDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CandidatesInformationDoc](
	[CandidatesInformationId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_CandidatesInformationDoc] PRIMARY KEY CLUSTERED 
(
	[CandidatesInformationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Comm]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Comm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommunityName] [nvarchar](100) NULL,
	[CongregationName] [nvarchar](max) NULL,
	[Place] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[CreatedDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tbl_Comm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommonDataList]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CommonDataList](
	[CDLId] [int] IDENTITY(1,1) NOT NULL,
	[DataListName] [nvarchar](500) NULL,
	[Status] [nvarchar](10) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_CommonDataList] PRIMARY KEY CLUSTERED 
(
	[CDLId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommonDataListItems]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CommonDataListItems](
	[CDLITId] [int] IDENTITY(1,1) NOT NULL,
	[DataListName] [nvarchar](500) NULL,
	[DataListItemName] [nvarchar](500) NULL,
	[Status] [nvarchar](10) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_CommonDataListItems] PRIMARY KEY CLUSTERED 
(
	[CDLITId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommunicationOfficeDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CommunicationOfficeDoc](
	[CommunicationOfficeId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_CommunicationOfficeDoc] PRIMARY KEY CLUSTERED 
(
	[CommunicationOfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommunitiesSocialCentresDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CommunitiesSocialCentresDoc](
	[CommunityId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityName] [nvarchar](50) NULL,
	[EstablishDate] [nvarchar](50) NULL,
	[Place] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](500) NULL,
	[Website] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_CommunitiesSocialCentresDoc] PRIMARY KEY CLUSTERED 
(
	[CommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Complains]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Complains](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Discription] [nvarchar](500) NULL,
	[NatureofTheComplaint] [nvarchar](100) NULL,
	[ComplaintReceived] [nvarchar](100) NULL,
	[Decision] [nvarchar](200) NULL,
	[InvolvedIn] [nvarchar](max) NULL,
	[FileName] [nvarchar](50) NULL,
	[MemberId] [nvarchar](50) NULL,
	[MemberName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Tbl_Complains] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Complaint]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Complaint](
	[ComplaintID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[ComplaintFrom] [nvarchar](70) NULL,
	[ComplaintDATE] [nvarchar](max) NULL,
	[ComplaintNATURE] [nvarchar](700) NULL,
	[Decesion] [nvarchar](300) NULL,
	[Document] [nvarchar](max) NULL,
	[Spare1] [nvarchar](255) NULL,
	[Spare2] [nvarchar](352) NULL,
	[Spare3] [nvarchar](350) NULL,
	[SirName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_Complaint] PRIMARY KEY CLUSTERED 
(
	[ComplaintID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ConfreresDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ConfreresDoc](
	[ConfreresId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_ConfreresDoc] PRIMARY KEY CLUSTERED 
(
	[ConfreresId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Cong]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Cong](
	[Id] [uniqueidentifier] NOT NULL,
	[CongregationName] [nvarchar](max) NULL,
	[Place] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[CreatedDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tbl_Cong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_EmergencyContact]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EmergencyContact](
	[EmergencyContactId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Relationship] [nvarchar](200) NOT NULL,
	[Mobile] [nvarchar](max) NULL,
	[Landline] [nvarchar](max) NULL,
	[EmailID] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_EmergencyContact] PRIMARY KEY CLUSTERED 
(
	[EmergencyContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Entry]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Entry](
	[EntryId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[DateOfBaptism] [nvarchar](10) NULL,
	[ChurchName1] [nvarchar](200) NULL,
	[Minister1] [nvarchar](500) NULL,
	[Place1] [nvarchar](500) NULL,
	[DateOfConfirmation] [nvarchar](10) NULL,
	[ChurchName2] [nvarchar](200) NULL,
	[Minister2] [nvarchar](500) NULL,
	[Place2] [nvarchar](500) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_Entry] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_EntryLife]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EntryLife](
	[EntryLifeId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[EntryDate] [nvarchar](10) NULL,
	[Place] [nvarchar](500) NULL,
	[Director] [nvarchar](200) NULL,
	[Minister] [nvarchar](500) NULL,
	[OngoingFormation] [nvarchar](200) NULL,
	[ColName] [nvarchar](500) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_EntryLife] PRIMARY KEY CLUSTERED 
(
	[EntryLifeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_EntryLife1]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EntryLife1](
	[EntryLifeId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[EntryDate] [nvarchar](10) NULL,
	[Place] [nvarchar](500) NULL,
	[Director] [nvarchar](200) NULL,
	[Minister] [nvarchar](500) NULL,
	[OngoingFormation] [nvarchar](200) NULL,
	[ColName] [nvarchar](500) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_EntryLife1] PRIMARY KEY CLUSTERED 
(
	[EntryLifeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FinancialGuidelineDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_FinancialGuidelineDoc](
	[FinancialDocId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Phonenumber] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
	[Photo] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_FinancialGuidelineDoc] PRIMARY KEY CLUSTERED 
(
	[FinancialDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FinancialReportDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_FinancialReportDoc](
	[FinancialReportId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_FinancialReportDoc] PRIMARY KEY CLUSTERED 
(
	[FinancialReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FomDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_FomDoc](
	[FormationDocId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_FomDoc] PRIMARY KEY CLUSTERED 
(
	[FormationDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_formationsDetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_formationsDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StageOfFormation] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Institution] [nvarchar](50) NULL,
	[Superior] [nvarchar](50) NULL,
	[Formators] [nvarchar](50) NULL,
	[Novisemaster] [nvarchar](50) NULL,
	[Place] [nvarchar](max) NULL,
	[Receivedby] [nvarchar](50) NULL,
	[Conferredby] [nvarchar](50) NULL,
	[VocationFacilitator] [nvarchar](50) NULL,
	[MemberId] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tbl_formationsDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_FormationTypes]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_FormationTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FortmationType] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Tbl_FormationTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FormatorsMeetDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_FormatorsMeetDoc](
	[FormatorsMeetId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_FormatorsMeetDoc] PRIMARY KEY CLUSTERED 
(
	[FormatorsMeetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FundRaisingCommiteeDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_FundRaisingCommiteeDoc](
	[FundRaisingId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_FundRaisingCommiteeDoc] PRIMARY KEY CLUSTERED 
(
	[FundRaisingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GeneralateDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GeneralateDoc](
	[GeneralateId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_GeneralateDoc] PRIMARY KEY CLUSTERED 
(
	[GeneralateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GeneralMattersDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GeneralMattersDoc](
	[GeneralMattersId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_GeneralMattersDoc] PRIMARY KEY CLUSTERED 
(
	[GeneralMattersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Health]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Health](
	[HealthId] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NULL,
	[Name] [nvarchar](256) NULL,
	[Complaint] [nvarchar](150) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[Diagnosis] [nvarchar](100) NULL,
	[Hospital] [nvarchar](150) NULL,
	[Doctor] [nvarchar](100) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_Health] PRIMARY KEY CLUSTERED 
(
	[HealthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_HomeLiveAndHomeVisit]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_HomeLiveAndHomeVisit](
	[HomeliveId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[DepartureDate] [nvarchar](max) NULL,
	[ArrivalDate] [nvarchar](max) NULL,
	[ColName] [nvarchar](500) NULL,
	[Purpose] [nvarchar](200) NULL,
	[Place] [nvarchar](200) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Institute] [nvarchar](40) NULL,
	[TransferLetter] [nvarchar](max) NULL,
	[SirName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbl_HomeLiveAndHomeVisit] PRIMARY KEY CLUSTERED 
(
	[HomeliveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Inst]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Inst](
	[InstitutionId] [int] IDENTITY(1,1) NOT NULL,
	[INSTID] [nvarchar](15) NOT NULL,
	[InstName] [nvarchar](256) NULL,
 CONSTRAINT [PK_dbo.tbl_Inst] PRIMARY KEY CLUSTERED 
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_InstDetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_InstDetails](
	[Instid] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](20) NULL,
	[Tital] [nvarchar](20) NULL,
	[Catogory] [nvarchar](20) NULL,
	[Remark] [nvarchar](20) NULL,
	[File] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_InstDetails] PRIMARY KEY CLUSTERED 
(
	[Instid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Institution]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Institution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MyId] [nvarchar](50) NULL,
	[YearOfEstablacement] [nvarchar](50) NULL,
	[InstitutionName] [nvarchar](50) NULL,
	[Place] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Tial] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[FileName] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[Telephone] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Tbl_Institution] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_institution123]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_institution123](
	[InstitutionId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NULL,
	[FromDate] [nvarchar](20) NULL,
	[Closingdate] [nvarchar](20) NULL,
	[NameOfInstitution] [nvarchar](20) NULL,
	[TypeOfInstitution] [nvarchar](20) NULL,
	[NameOfDiocese] [nvarchar](35) NULL,
	[OwenedBy] [nvarchar](35) NULL,
	[MaintainedBy] [nvarchar](35) NULL,
	[Address] [nvarchar](100) NULL,
	[Telephone] [nvarchar](100) NULL,
	[EmailID] [nvarchar](35) NULL,
	[WebSite] [nvarchar](35) NULL,
	[spare1] [nvarchar](100) NULL,
	[Spare2] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.tbl_institution123] PRIMARY KEY CLUSTERED 
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_InstitutionFinal]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_InstitutionFinal](
	[InstitutionId] [int] IDENTITY(1,1) NOT NULL,
	[INSTID] [nvarchar](max) NULL,
	[InstName] [nvarchar](max) NULL,
	[InstType] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbl_InstitutionFinal] PRIMARY KEY CLUSTERED 
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Jubilee]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Jubilee](
	[JubileeID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Profession] [nvarchar](256) NULL,
	[FirstProfession] [nvarchar](10) NULL,
	[SilverJubilee] [nvarchar](10) NULL,
	[GoldenJubilee] [nvarchar](10) NULL,
	[PlatinumJubilee] [nvarchar](10) NULL,
	[DiamondJubilee] [nvarchar](10) NULL,
	[FPPlace] [nvarchar](50) NULL,
	[SJPlace] [nvarchar](50) NULL,
	[GJPlace] [nvarchar](50) NULL,
	[PJPlace] [nvarchar](50) NULL,
	[DJPlace] [nvarchar](50) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_Jubilee] PRIMARY KEY CLUSTERED 
(
	[JubileeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_KnownLanguages]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_KnownLanguages](
	[KnownLanguagesId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[ToRead] [nvarchar](20) NULL,
	[ToWrite] [nvarchar](20) NULL,
	[ToSpeak] [nvarchar](20) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[LanguageName] [nvarchar](100) NULL,
	[SirName] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.tbl_KnownLanguages] PRIMARY KEY CLUSTERED 
(
	[KnownLanguagesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LandDetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LandDetails](
	[Landid] [bigint] IDENTITY(1,1) NOT NULL,
	[RegDate] [nvarchar](20) NULL,
	[RegNo] [nvarchar](20) NULL,
	[SurveNo] [nvarchar](20) NULL,
	[DocCatogery] [nvarchar](20) NULL,
	[Discreption] [nvarchar](35) NULL,
	[File] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_LandDetails] PRIMARY KEY CLUSTERED 
(
	[Landid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_LandDocuments]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_LandDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[MyId] [nvarchar](50) NULL,
	[ParisInstitutionName] [nvarchar](50) NULL,
	[DocumentCategory] [nvarchar](50) NULL,
	[SubCategory] [nvarchar](50) NULL,
	[Khasara] [nvarchar](50) NULL,
	[SurveyNo] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[RegistryDocumentFile] [nvarchar](100) NULL,
	[TaxbillFile] [nvarchar](100) NULL,
	[PavathiFile] [nvarchar](100) NULL,
	[MapFile] [nvarchar](100) NULL,
	[KhasaraFile] [nvarchar](100) NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[Year] [nvarchar](50) NULL,
	[Place] [nvarchar](200) NULL,
	[Tital] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.Tbl_LandDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LivingOutsideTheCongregation]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LivingOutsideTheCongregation](
	[LivingOutsideId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[Place] [nvarchar](256) NULL,
	[Purpose] [nvarchar](256) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_LivingOutsideTheCongregation] PRIMARY KEY CLUSTERED 
(
	[LivingOutsideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MinistryDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MinistryDoc](
	[MinistryDocId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[SubDoccument] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Phonenumber] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[File] [nvarchar](50) NULL,
	[Photo] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_MinistryDoc] PRIMARY KEY CLUSTERED 
(
	[MinistryDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MissionDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MissionDoc](
	[MissionId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
	[Immage] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_MissionDoc] PRIMARY KEY CLUSTERED 
(
	[MissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OngoingFormationDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OngoingFormationDoc](
	[OngoingFormationId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_OngoingFormationDoc] PRIMARY KEY CLUSTERED 
(
	[OngoingFormationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OVCDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OVCDoc](
	[OvcDocId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Phonenumber] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[File] [nvarchar](50) NULL,
	[Photo] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_OVCDoc] PRIMARY KEY CLUSTERED 
(
	[OvcDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Paris]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Paris](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MyId] [nvarchar](50) NULL,
	[YearOfEstablacement] [nvarchar](50) NULL,
	[ParisName] [nvarchar](50) NULL,
	[Place] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Tial] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[FileName] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Tbl_Paris] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_ParisInstitutionDetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_ParisInstitutionDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MyId] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Place] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[YearOfEstablacement] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[FileName] [nvarchar](100) NULL,
	[ParisId] [nvarchar](100) NULL,
	[SocietyId] [nvarchar](100) NULL,
	[Telephone] [nvarchar](100) NULL,
	[InstitutionType] [nvarchar](20) NULL,
	[RegistrationNo] [nvarchar](100) NULL,
	[DiscCode] [nvarchar](50) NULL,
	[TypeCode] [nvarchar](50) NULL,
	[RegIdCode] [nvarchar](50) NULL,
	[BEORegCode] [nvarchar](50) NULL,
	[CertificationCode] [nvarchar](50) NULL,
	[OtherDoc] [nvarchar](50) NULL,
	[Doc1] [nvarchar](50) NULL,
	[Doc2] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[Tial] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Tbl_ParisInstitutionDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Passed]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Passed](
	[PassedId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[LastCommunity] [nvarchar](256) NULL,
	[Cause] [nvarchar](50) NULL,
	[Date] [nvarchar](10) NULL,
	[Time] [nvarchar](7) NULL,
	[InstitutionPlace] [nvarchar](50) NULL,
	[LastNatureRites] [nvarchar](256) NULL,
	[LastPlaceRites] [nvarchar](256) NULL,
	[DeathCertificate] [nvarchar](max) NULL,
	[obituary] [nvarchar](max) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
	[Description] [nvarchar](500) NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_Passed] PRIMARY KEY CLUSTERED 
(
	[PassedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PersonalDetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PersonalDetails](
	[MemberID] [nvarchar](15) NOT NULL,
	[PersonalDetailsId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[NameBaptismial] [nvarchar](200) NULL,
	[EmailID] [nvarchar](200) NULL,
	[SirName] [nvarchar](200) NULL,
	[Image] [varbinary](max) NULL,
	[MotherTongue] [nvarchar](100) NULL,
	[Mobile] [nvarchar](max) NULL,
	[BloodGroup] [nvarchar](20) NULL,
	[DOB] [nvarchar](50) NULL,
	[FeastDays] [nvarchar](10) NULL,
	[VillageTown] [nvarchar](100) NULL,
	[District] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[Pincode] [nvarchar](max) NULL,
	[AadharNo] [nvarchar](max) NULL,
	[NameasinAadharCard] [nvarchar](50) NULL,
	[FatherName] [nvarchar](200) NULL,
	[FMobile] [nvarchar](max) NULL,
	[MotherName] [nvarchar](200) NULL,
	[MMobile] [nvarchar](max) NULL,
	[NoOfBrother] [nvarchar](max) NULL,
	[NoOfSister] [nvarchar](max) NULL,
	[PlaceintheFamily] [nvarchar](max) NULL,
	[Spare1] [nvarchar](256) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](256) NULL,
	[Parish1] [nvarchar](256) NULL,
	[FBaptism] [nvarchar](256) NULL,
	[MBaptism] [nvarchar](256) NULL,
	[Will] [nvarchar](40) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.tbl_PersonalDetails] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Primarydetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Primarydetails](
	[Primaryid] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [nvarchar](50) NULL,
	[Knowname] [nvarchar](50) NULL,
	[Baptismialname] [nvarchar](50) NULL,
	[DOB] [nvarchar](50) NULL,
	[DOB1] [nvarchar](50) NULL,
	[Feastday] [nvarchar](50) NULL,
	[Bloodgroup] [nvarchar](50) NULL,
	[emailid] [nvarchar](50) NULL,
	[mobilenumber] [nvarchar](50) NULL,
	[placeofbirth] [nvarchar](50) NULL,
	[noofbrother] [nvarchar](50) NULL,
	[noofsisters] [nvarchar](50) NULL,
	[placeinfamily] [nvarchar](50) NULL,
	[homediocese] [nvarchar](50) NULL,
	[homeparish] [nvarchar](50) NULL,
	[house] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[district] [nvarchar](50) NULL,
	[state] [nvarchar](50) NULL,
	[pin] [nvarchar](50) NULL,
	[adhar] [nvarchar](50) NULL,
	[pan] [nvarchar](50) NULL,
	[passport] [nvarchar](50) NULL,
	[nameonadhar] [nvarchar](50) NULL,
	[nameonpan] [nvarchar](50) NULL,
	[nameonpassport] [nvarchar](50) NULL,
	[File1] [nvarchar](max) NULL,
	[File2] [nvarchar](max) NULL,
	[File3] [nvarchar](max) NULL,
	[Ordination] [nvarchar](50) NULL,
	[UploadPhoto] [nvarchar](max) NULL,
	[country] [nvarchar](50) NULL,
	[mothertounge] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_Primarydetails] PRIMARY KEY CLUSTERED 
(
	[Primaryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ProvincialDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ProvincialDoc](
	[ProvincialId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_ProvincialDoc] PRIMARY KEY CLUSTERED 
(
	[ProvincialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ReligiousEducation]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ReligiousEducation](
	[ReligiousId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[DegreeName] [nvarchar](100) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[University] [nvarchar](300) NULL,
	[Address] [nvarchar](500) NULL,
	[ClassObtained] [nvarchar](35) NULL,
	[Remarks] [nvarchar](35) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Certificate] [nvarchar](max) NULL,
	[SirName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbl_ReligiousEducation] PRIMARY KEY CLUSTERED 
(
	[ReligiousId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Retirement]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Retirement](
	[RetirementId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[DOR] [nvarchar](10) NULL,
	[Age] [nvarchar](max) NULL,
	[Reason] [nvarchar](200) NULL,
	[Community] [nvarchar](200) NULL,
	[Remarks] [nvarchar](75) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_Retirement] PRIMARY KEY CLUSTERED 
(
	[RetirementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SCTDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SCTDoc](
	[SctDocId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Phonenumber] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[File] [nvarchar](50) NULL,
	[Photo] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_SCTDoc] PRIMARY KEY CLUSTERED 
(
	[SctDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SecularEducation]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SecularEducation](
	[SecularId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NULL,
	[Name] [nvarchar](100) NULL,
	[DegreeName] [nvarchar](100) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[University] [nvarchar](35) NULL,
	[Address] [nvarchar](35) NULL,
	[ClassObtained] [nvarchar](35) NULL,
	[Medium] [nvarchar](35) NULL,
	[Remarks] [nvarchar](300) NULL,
	[Title] [nvarchar](35) NULL,
	[Course] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Certificate] [nvarchar](max) NULL,
	[SirName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbl_SecularEducation] PRIMARY KEY CLUSTERED 
(
	[SecularId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Seminar]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Seminar](
	[SeminarId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Community] [nvarchar](256) NULL,
	[Name] [nvarchar](256) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[SeminarName] [nvarchar](256) NULL,
	[Place] [nvarchar](256) NULL,
	[Institute] [nvarchar](256) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_Seminar] PRIMARY KEY CLUSTERED 
(
	[SeminarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SeperationFromTheCongregation]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SeperationFromTheCongregation](
	[SeperationId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[SeperationDate] [nvarchar](10) NULL,
	[Title] [nvarchar](35) NULL,
	[Describtion] [nvarchar](35) NULL,
	[File] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_SeperationFromTheCongregation] PRIMARY KEY CLUSTERED 
(
	[SeperationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ServiceInTheCongregation]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ServiceInTheCongregation](
	[ServiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[Address] [nvarchar](1024) NULL,
	[Community] [nvarchar](100) NULL,
	[Office] [nvarchar](50) NULL,
	[Other] [nvarchar](150) NULL,
	[superiorName] [nvarchar](100) NULL,
	[EmailId] [nvarchar](200) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Certificate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbl_ServiceInTheCongregation] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Soc_Addminstration]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Soc_Addminstration](
	[SocityAdministrationId] [int] IDENTITY(1,1) NOT NULL,
	[SocityName] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[RegNo] [nvarchar](50) NULL,
	[PanNo] [nvarchar](50) NULL,
	[FCRANo] [nvarchar](500) NULL,
	[ANo] [nvarchar](50) NULL,
	[GNo] [nvarchar](50) NULL,
	[Spare] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_Soc_Addminstration] PRIMARY KEY CLUSTERED 
(
	[SocityAdministrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SocialInstitutionDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SocialInstitutionDoc](
	[SocialInstitutionId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityName] [nvarchar](50) NULL,
	[InstitutionName] [nvarchar](50) NULL,
	[EstablishDate] [nvarchar](50) NULL,
	[Place] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_SocialInstitutionDoc] PRIMARY KEY CLUSTERED 
(
	[SocialInstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_SocietyDetails]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_SocietyDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SocietyName] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.Tbl_SocietyDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Socityadd]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Socityadd](
	[SocitydetailsID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Catogery] [nvarchar](50) NULL,
	[Remark] [nvarchar](250) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_Socityadd] PRIMARY KEY CLUSTERED 
(
	[SocitydetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SpiritualCommunityDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SpiritualCommunityDoc](
	[SpiritualCommunityId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[SubDoccument] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_SpiritualCommunityDoc] PRIMARY KEY CLUSTERED 
(
	[SpiritualCommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_StCamillusProvincialateDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_StCamillusProvincialateDoc](
	[StCamillusProvincialateId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[SubDoccument] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_StCamillusProvincialateDoc] PRIMARY KEY CLUSTERED 
(
	[StCamillusProvincialateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TravelRecord]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TravelRecord](
	[TravelId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[FromDate] [nvarchar](256) NULL,
	[ToDate] [nvarchar](256) NULL,
	[Place] [nvarchar](256) NULL,
	[Purpose] [nvarchar](256) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK_dbo.tbl_TravelRecord] PRIMARY KEY CLUSTERED 
(
	[TravelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_unknow]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_unknow](
	[memid] [int] IDENTITY(1,1) NOT NULL,
	[Knowname] [nvarchar](max) NULL,
	[Baptismialname] [nvarchar](max) NULL,
	[DOB] [nvarchar](max) NULL,
	[DOB1] [nvarchar](max) NULL,
	[Feastday] [nvarchar](max) NULL,
	[Bloodgroup] [nvarchar](max) NULL,
	[emailid] [nvarchar](max) NULL,
	[mobilenumber] [nvarchar](max) NULL,
	[whatsappnumber] [nvarchar](max) NULL,
	[facebookid] [nvarchar](max) NULL,
	[twitterid] [nvarchar](max) NULL,
	[blog] [nvarchar](max) NULL,
	[house] [nvarchar](max) NULL,
	[city] [nvarchar](max) NULL,
	[district] [nvarchar](max) NULL,
	[state] [nvarchar](max) NULL,
	[pin] [nvarchar](max) NULL,
	[adhar] [nvarchar](max) NULL,
	[pan] [nvarchar](max) NULL,
	[nameonadhar] [nvarchar](max) NULL,
	[File1] [nvarchar](max) NULL,
	[File2] [nvarchar](max) NULL,
	[nameonpan] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbl_unknow] PRIMARY KEY CLUSTERED 
(
	[memid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_UserLogins]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_UserLogins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[UserPassword] [nvarchar](max) NOT NULL,
	[UserRole] [nvarchar](max) NULL,
	[Spare1] [nvarchar](max) NULL,
	[Spare2] [nvarchar](max) NULL,
	[Spare3] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tbl_UserLogins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserModuleLogin]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserModuleLogin](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[UserPassword] [nvarchar](max) NOT NULL,
	[UserRole] [nvarchar](max) NULL,
	[Spare1] [nvarchar](max) NULL,
	[Spare2] [nvarchar](max) NULL,
	[Spare3] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbl_UserModuleLogin] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_VocationalTrainingDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_VocationalTrainingDoc](
	[VocationalTrainingId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Phonenumber] [nvarchar](50) NULL,
	[Activities] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_VocationalTrainingDoc] PRIMARY KEY CLUSTERED 
(
	[VocationalTrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_VocationPromotionDoc]    Script Date: 11/4/2019 10:08:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_VocationPromotionDoc](
	[VocationPromotionId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Phonenumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_VocationPromotionDoc] PRIMARY KEY CLUSTERED 
(
	[VocationPromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201910261822526_initial', N'Generalate.Migrations.Configuration', 0x1F8B0800000000000400ED7D5B73DC38B2E6FB46EC7F70E86977638E65C9ED33733AEC73422A596E754B2A8554EDDE79EA80485415C224518764C9ADD8D85FB60FFB93F62F2CC04B91C48D000A605DCC98980E0B972F41546622914824FEDFFFF9BF1FFFE3AF387AF302D30CE1E4D3C9D9DB77276F6012E010258B4F27EB7CFE2FFF38F98F7FFFAFFFE5E3E730FEEBCDD7BADD7BDA8EF44CB24F27CB3C5FFD7C7A9A054B1883EC6D8C821467789EBF0D707C0A427C7AFEEEDDBF9D9E9D9D42027142B0DEBCF9F8B84E7214C3E20FF2E70427015CE56B10DDE1104659554E6A9E0AD437F72086D90A04F0D3C91798C0144420876FCBC6276F2E2204C8409E60343F79039204E72027C3FCF9F70C3EE5294E164F2B5200A2D9EB0A9276731065B01AFECF4D73DD2F79774EBFE4B4E9584305EB2CC7B121E0D9FB6A6A4ED9EE56137CB2993A32799FC924E7AFF4AB8B09FC7472B15A6194E4314C72326D2CC19F27514A1B0BE6F86DBBE7DFDE34F57FDBF004611DFABFBFBD99ACA37C9DC24F095CE7A4D1DFDE3CAC9F2314FC065F67F81B4C3E25EB286A0F930C94D4750A48D1438A5730CD5F1FE1BC1AFC4D78F2E6B4DBEF94EDB8E9D6EA537ED24D92BF3F3F79734F8883E7086EB8A0F5F94F394E61F969390C1F409EC334A118B098478E3A43EB0EC6CF306D2812D6234274F2E60EFC750B9345BE24E2F5E1E4CD35FA0B8675413588DF1344448EF4C9D335ECA3334379047D13B92253E09BC6E7F91C0664A687A035C343500971A020F1E19D8B1F0666418A56A582909222FF7440AB25F4949272F65C7C5B98AEE83F7A69B99946B4480AB91F82DC4D921115B21E8ADC04C7F13AA974BF6F624F6BF217C2A95B3A1F4F9BD54BB9A611DB6141641B98AD6775AF1DAD65C8622D439B95E5CB9AFEDBE352466747B990B951656A8D3CA0BAFCF0EE9D0B62D7288267BEBF8812391F82C8FB2188FC3404910FBE89E07C0953EFBFFC2485A0DF5CB259FA0D94ED3A99A034A00B0C32D5B8ADAEA3DA1591A2FFF5CD4479CFEEE1C034FB73AF667741CABF594FD554CFCFEFC6A627229DBEDEA239ECDF1AF7ECA8D4A6A55735442DB75B94E537398C0D1D199DAEA3274326BEC51C0DA18F86A0D1DAECF926D5DAE8793707EA4D9E6F42176198C22C539039B7309F8D85DD52D04721B712BC339F3FE9358851F47A05738022C39FB5D375FC6985B4343CD16E8C892194F7238C8A49C99668E59BD63F2148A7F34B94E6CB61485D911D9D775277F819F9B7F93FC7442277BF147D70E2C9F91CC3740193E07582931C04B9DBEFD2D6934F204881C5695DD36FD490425A7D67684E9875F32B78177094104307AA3CF007B3AD9F2CD769B01C66618941FA4DA54B6C6C20ABD5D8AB0EC10182F9ABF91149ABE3E8AE13CA370EC64392F190643C24190F49441AD7D466AB7A8D169B90969F5594A7F30092FB3525E5DD2EA0FF9DCE674B487F79A517CFC6BD2610F2C9E345EFA71DCC9A557EC9D9F9857F3371418CEBB460E261A6AFA4F28F775FF66137ED22F60E46093E0AF7C31FF03943AE79DB645DB949B207B080C62B4BD56F5C5BA49AD8BBAFD4834562EED770F4295A47EF8E6829CFDEBDDA71F973F4E745004218BF9A095CABE38E240E04C066F35C751B4AEE06894509F03ACDBC5309E12285DEA9AC13545CD5F17FE63B4F711C0E60C6E578082A4104B2CCBB0912C310AD63DF54808FC3789E4C5A7847BD1FB4A86F4CB8594276EC80A5ABC12548BEFD6975DECDF6DED18242876063C6D5FD364BCABFFEE47549A1F43C443608F64E4170AF147637646EAE274F4A220E685CA6200954A7D01654CCA403E36FD3399951BC4EF2ACB0F88C458485D8959C74C66125311CC260617F3808D6F4BC7288D3B7414E608770443D4420F04EE4228E293B0C710EB0C35572029210517B30BB49E6388D0BAEB6520732A41D6905E1706C94831468D411FBAC23762857332A0D388ECD64A8EE353A0CC56258875E0F626AD2DB98295C94271043B82AFB963447B7CB7B4F1F1C7DCD1227FEBF660FCE9DF34A68C94A57C5BE5B2C9C9DFEBB5A2EAF6EAD16C7B2DB604BA1EE2D1927B18464CC6B75AC9A0B2A2B902A8373DE3B491840A9A8A273DC515185E75850D942142DAEAA4940762894335BB19C1DAD60B67F9A51138C9A40A60988B91814DC3D9DCF5100ED76B5429C5DE9037E3056DA410C33EE67C7FD6C9F3CE5086634760E4413F20392BDC436422502DBAD64E5AF5BC853D979DFF6C36E22BDB29C7C06CA96C7E3DD1D260EAFBACBA611C4B8B7B1727BA58A2A27D92A02283134ED3B5D47279B90D610E23DCC8A8C34AFD738092AA7BC82E7B325ACF94B756AE4CA4159517A8401442F509902D5CDAE0B062853CFA79B30989BE40547E48B6EFC473A6AA40072735B74A09B14251DF75F646A2AD642606118965D77670696F46FAEACCCC0A6F3501ABBE2AC2B95F8EB6DB50D7351F530D9F9877F75A9E5AE53AC0AFCF9BB53957A7531FBECFFF0A2A6767F31FBFD5145EFEFAED437EC51DFEFDD10C2E5EEDEFB0CF6FACBCE3F0CE4303B1FC663E6C4C98876BF3C24F314DABB0E9ADE3B5B24AA21D8F90A5A9D478FDBE87113CA49B957A504CD77B8C9E22037B78324D81E433AC6900E9D358ACF4565BA4EB1083B9249761836322AC218EA6EC1DE6E6F9C98CA9A79F67489197E626F8E3A37227D0B92304203E88EE23ABA9255DCFC6A4325C41BE301DC6F6EECC8DC8317541A0EEC554AA2E91F882EC709883657CDDA52FDA978214DB822FC29EC4C1D1D8F3892AC43A23E7F3EE1755A181AD8B0E30C9036F916CB24377AD3559201D8D122D92C32A64BE3CE962766E2865C921DAD8C16EBF12558E5288B1150251D71A3E3875A4BFA3596A33395B848615252B94409485FF556E03E138226189B919DD55AF50D8E923A0E63AF5C4618875F52BC569B642E9C18D34BEF3E0C08B2FC0ABC7A0F5EFC8A88382FE00C7F5779981D9D44D2E450489921D80D211AF7E99FAFE92B3D79AA4A2FE186CE03A28FCC0EE09100E112A4F7AADC0F6E08D1FF820C2525C10948BD9FAF5E03AAEF06D1D8D703A9BB52850FF24977037DD23D9ECE2FD3E2BB06A1F5D49709DAA13F1125E4B3CA0719F6E180CDC521EF9EEC40DD7CCC034851B6F43F69D79531EC9DD0DD5084FE20168482C84F4ECCE0EC0A46306FA2A52E31D93283A4673B62E63B2E1773638731EDB62B2F31A56DE51AAE3B8EFE6057A79A64E9EA153827167B93F55FA9ADDCACFCD56B09EA54D4CE82C7FD93297F297A988FAA8C10C3FD5CAAA5D2EDCFA54EE7EEECE7F24F6674A5EF852BDD7C1DA5AF665AAEA5B4EB2ED7D3FAC14FAB35957B2D745C57B7F1E6D229ED892970A2A4FBAF2EB9F17FA53020BFF760EB80F72F9A260B4C90AF71FF62EAE6CB2638EA8D851B179EA359789C9DE1D6BA59EBF056D5587C6AABECB1F571ED06FE6C8B25F56C5C53F77D4D1D97BB71B91B97BB3D5DEEDCAE4367460B91B0B57A251277D97A29BA46094868E6071AF60D6978A0D56D1021CC8E16A8CD58AECA370A4DD728B6FF7839641BE79C6F1A45387C32C8DB54C33DC03CC0734EEE2FD5087F9BDCF1CB1376CAED11AE709A6FA7D93618BB566BE540B6D26C0DC4A8DCF659B9ED38D7D4358EED64A6E8B72B3969A53CB71212A6FF2821A384082584DEF2DCE4A1CFAC42EF851007796BD4BF7C3CE56001A7739DBDFAC170EF2062789364647ED743CCD9D39AFC85941E2237525F30014EBDA78DBBC72F288331E8F5461DCC35E53A4DD5B3F767F46850064CD321487DC5650ED56B10A008E540EDA43CA84C52E57BA37D09D4DCF08646162EAF37BE6785ED58E9775A6EB19C76FB8F6BA94C7FE6CD2CED74875129F23B082DF7E70CC24E771DD530ECB71D2D8071DFB1CF96DBAE77E6EB247C0428237469FE6194434BBFBD10675732D40CC64A82BADD47F919E5472A3F0D7F5B894DA7FB8EA4A5216A232CDDDEA3AC8CB2D2272B77C58F6D972C9083D8ADCC54E3D8426E5A08A3EC8CB223959D5F2088F2A5B9C094FD76242525711BE9687A0E2515EE62FBB60B8F779B6559F9354EC422C5F1108189333C04952B041609CE903AB9860B4ABFE06C857265DE1B373F10D1F66A27A6A3C41A639CE09E84C51B2EC0AE9E9218EE750EBD8CA276C2E32496B35CBC74E238E52D85319C8AE65BC76FFE8263788B5EE04512D27F7E4519B248922A42D995F141E847642856E647ABEFD15F2E18C422B98244A9D2DFD94322604180659AA217221C43D01A2A12FF619DAE70A6FCA5DC5DE0F64E65B4174CA9D4D117AADFC6494A95590A926C0ED35B980F9104A9DF0EB2A4E3662D172C685A2BBB663FF13AAFDB79EB559F3295F92A4F7BEDEA40BC8941B23A1BEF761FCAB97073FF34DBC1CA4EBFD6C3EA6ECC61D6D9845B9D77C96FB68C36A0F5D863EA38C96E3AEB715838213201395E6065F24C27741E610CD26FBEA9F4788D7D665C9955F2B389D8340D806A751EA39F84B4EE5EFD87EDFD1382743A2F9F6B268679CF3B6CAEE37C8738223AA6D7A167EA54E60773DAA5EBCF1B2656D44D14B147B721CB053082AB9ED7957C1F18A24688CFCEDF9B9B5EDDFEC765ED1F8C276FEBB33737265984692C5C380029FADFE95CEFA2891B9B96A00F4AB0FCC22B8403A874E639F1194DBF13260E2F55C6B4133A77F4AC99FC7F085AFD2BB99B232D1D25EE8652FFD3244E26EE0FF8FC849422EC844CD6E7D97578E0AC72EDDA9031F66C544A83DE878FECDC1B6D84E35A6577ED5373E39ED6F0A1B923D47389C6EB9D29CA90BFAEE9730ED09C93AB8E3B62E08ABACD7B5FADAE871769B68F07BDE4CF39599E7B2C29372F26A034CBB5E839090E7B42D10B4C3722E297D8171C11761A88D8033DFA4AD6F140E4AE108871120E44EDFA611007D3D3AF8390F9320C998761C85C0D43660C3630D7757B9CB3B7521C3AC7F08AA6C2937755FBAD0FDB7F4BF0F7E416248B355898DE48E7FBEFC8D6EA0EC266BFC0231C9E63CE754E7C2711F28F10A88EA31C51F923553B111C91795A41E0FD78765C184CA9D472DBC3D18E7C3CBDAB9077270F7DEBDE3A7CA5D57947DA9A8EC0267CA5EE3794667E848B214E320819E52BA66E94CA3A7D81FEC95CE1A0889581FE6365AE5016A4B0EF34D8897ED971C04C21B1B8BC1E6B9133A8D37D0C9A11D2EAF171BAC9A93540604EF12EE8C0A132356F11C1873D41728ED2F03D0F45EAB725C8400AFC7F1151CEAF4AED7C64413A6E4E27C8CA49DF687FAD39B0474F3B3A82057F91ED783408AD07F002F2251A84D61D580D42A792A941680D185E454322771D94E8E616545F44B5FFED0D7A2134A7EB3C43219C2DE104278B142E8079C4701FDAAE3640ED21D998461CC00FEFAC727376775479237AB5859BA3D5FE1BA04EE88C5EB1A33A2E5169659D3314D3FEC283156390AD4F5BCAB7DF0A8BD57C256B75DED1C2D51A81CDB2C5741F6A733F686E31B23BDDD0F37FB1E348F2981DE133573FC20B5477A88871B2546675DF9DE9B26200767A6CD3F52875D8D1E8952184F0268EC1C231152329649F79B5124701C88EE4921D898D808A304649FDB124D54C86BE4EECC4A6E8B72B4979092C0DF1A6E72815FB2C15A35D7C7076313D712F4E61CD0FEA8B6EE301BD90D69166B5287EF22154E298CF62FFB4FB98CFC2A7FE6D45C158BF5E2A011A75F4CE74F4D1E8CA2122CE76B0A0F52F016E427F34149AAB101CAA02547CED28AC1C0708E66A093AB41C122DCDD9C3EEAE02A9E9F152A1CB94C1748ED2CBA32C9890D643688A21E890E9BB09872074F9794A680D416942FE8DE6A87C3E770882D37C09D3C293E43DE656150BE18A862A1262BFEDC571D7E0D761FA00B20C86E60ED3B2DF8E0CE892B88D19DDF41C23ED5C4473DD822CA74FB2AE93622A3C539B80B532426D08D97713388894BFCDDFDDDA6C83EC832827DC032AEE8F2887AA8D833BCE2B3E6C187257647D5B3666886A3ADD6C8CF033F9F580F26A8C1B426340A63195611ED71AF2D92B3F276D4E224CCB255B279654DE521835AA68BE757CE8438A6222BCA1EDE5EE6EFF5D9959E5206CAE78B7BA0EE6B52C0D2DEF9ECB22C3C800DECB4B40443F8BC96E67086A57D3CB014878DFEB5E43621684C0FB85D2CB08E37091E2F5CA372548F3B722EF5C1D639A9B689810851535DBF0FC19A5F4D161BFB4124C08A598BA73862095A18CBEB83DC80CA2640E621479E7F5258E61D89B52DA19A91575D47BE78B251E602B19A837C54E6884D4558E02EF0742593E804F6C85BC9FA08370E9FF82EF0A78FF8E15B15E5738F5FEBB53E38398C643CC5A496A80B9AB090D3383F4885365F8B83B4855EDAFDD5151EDAFDD5099A6214AC010F134BFAF220CC2BE3843375F15E07592FBCF751217C64E4E88EDF4360319D50B4A02B27DB10AC8EE74DFD9FEB71E83D55143A7F7189FBDCF67713BBEB5F00823B440C422FD1CAE03CBF4183CC68EA46633101BA1E974FEE18FE8DC84B7C0450A8789B13AAEBC1BA4F10B151AE51EEEBD93891BEAD2C6242236EFF4B97C4DC9F7F945F908AAEAA3DC9DF98CE75756D1542A197274BAB8D70FB0F38BA6CE39935E2FE1999366D7ADCF9F1E618ED22A50D8DC92A8FBEECC82A807606742B47BFFF036849BE887E9A3EFD5F642B95B75A38C1E21C87A1E6174B2CAEA044439A1D4BFC4FE7D5C628F2944C4D1AA576B48BDD54ED55AB2CA29BB6CBDBA3D4D66564EA5B2DF8E56B5A720B7BCE5DFF41CBD48FBEC451A6FF9DB4EDB4EB35F3DC1601D81740BDF1B8BB02B0D530EC34AC5345D0FCF62DECA407674876C74B2F974B20DF3B4B71BE7CA902EB63B18A275BC078EBC418290DDFC3EC45E5546FE1CD02EE3F01D79860B758C121A8662BE3E171D77B62C17D4ED96E54DD7C35B960D1D59C35D231BC465765CCB74C58883CCDC30F9EEEBFB71FE298DDEB3A3F29E55A2A0E33A533415FACD54EDB7779AC1152C736AD0416EFD1C8B126E672B6D3D26BBC5B6DDFBE8D7DB41747933A7C35CAB1E6003515ECB7C3ECCF72ADD294185F4EBA946430089C2344571A046D31714C09BC481061523ED4C7996C3B1D29C9BAEA3DA1C370FE69EB7B377E73F0D74F0EEC6093B9DCF91FF9C1AD39E6B8B676E6E76ADC95F08FB780D9D27F6995E67555ED2761319316EBAF6CA99E8C8E8102F987AF6867E5F89A96100B0BD9581833F89DA24DBC1AC4A8468615F7018BBB22C30BD087B4147B2C9EB6865664870868A8A28E90F11123144B4C2235CF87FA9FA01A83378BAB9BD3379BCE8A1E2C48CF1FF255FFC932816935D465BE0E24A5C2B17B7552497006587DAAD33145BD5C6810CA5D73666F310AAADF58D43902B9366A36C394800D8BE3CCEE0268A39C94190DF0F12CFF6077CCED051DFF39C555A0BE6AFD6CF1874FB8FAF17485529ECD56536BB59E3752E7F05A1456EDD4DD79DDAEB55EE39EA62B333D45B0083C52D0F927F7A8070E509C8F102FA4F1651867629FD9907AE770B815AA19466538D36968E9DD12982D9958C7263B1323B85284779CB607CCFFB00E5369FD00C77D13A7BD82453215F6D27BC52AC5D49B0784056622C871A657994E5BD90E5590A5E60F408039C5A98C4EDDE3B92D7720836E2D9F41C4FC7073A1D7743A8F778FC90025E1FD6E90A2B6F3E8CE1AE63B82B77E8DAD6BC3A07AD7DED8587ABBD9DB63E505D27DF12FCDD7CE129FBED68C989616C937CBFEA3694E9A79110DFCD1524ED8CF86EC8A953E23BA331406AD8FEA4F88E7E209DACF86E48F5A7C5774347332FBE1B62DF9720CFC06A3510B939313B9E31FE36C034E6DF11D52A03507A8EF0C23B91BEECF16EA8F4A48F774344237FBC1B427D09E4DD505167907743A32F19BAA32F51E641774383AEA3FDC9DD1DAD42479406BD9C37F7BF90D169F2EF194C6FF102251627C94DDFF11459488B4E50CFA64CF7073674A150CAF469B2EF85A36C17D4E9BECC7F3E813E37814332FE1542AFA3C0AB36C82B892602BE8E6021D7E63B5D0660477AA1A06DA31C361D87D4108EF6A1A3861835847F0DF11597D9C940344B014A087DAB835421CC8EB4053F161BD5214639CA93D3A339CD1C32D76290A3179423E52BD3C770445BCB0119558CAD43F345283B560F9BA16CA31D3A20A37218954379BF80FAA18F472F5C6419BD894259B7A5183EC7305DC02478ADEE0408CF01BB5FF03909DF34E77B3A00CDC160F99DF50124DB977C3A511768451404F9804F27FF839B3D0BDAF5F922439B3BEBEC923E3B6175D034B98211CCE11BBA681015773201590042FE1726F31F764B88DA8229D50A341AB3B8B289929CD77134BA6B0522CB0F64F0845AB3091E3965C99F6EE8B33557700513AAD42C7FF56D07B6A1CF4C73DFAC7E3C6DB1BC8624D017FC6ED11C9A8B80AAA794F7EB4EC64CAFA476D0DCAEF365C3B2B9CE2F7B68FC7D66CFE0C2AEBD1C7E66CDE2627A47C1E3CA4FDB0D932B7FDD03E1F25F2088F2A53187CBBBC9B8BBEC61CAD90A3A765CFDEEEDDB338EA63577F60F6F50CEECFF550E852B710C6FD10BBC4842FACFAF2843E696B62E88946305FD8DF957770C87ACA34D3F72589930E4820391905FD73418CBDCF656F493C941D5C594F555940E99DB35BE6B5006D7F8450F84A78998A264315DE7190AA14E622B15FB9982C9B85F85632A12C6633A6439B1FDD84185C7964B0E44A2E8D13814DF5550F1A9BC9B4C4ACA1EA6F2A0A073C89CDFFF5983F278FFAF7920DCACF944B18AE34CDF2BEE721FDFDB94E30D1F3D3E44EE37FBC44125C1ECD73F18A9503E61AAE646BDF74C5929681ED436E57EADC7500F93EB753E6D606ED7F9750F84CB554F8DA8584EEBDD912EBF6DDED632636E9D174B0E91B335BE6B50B6D6F8450F86A757862F47A8F9CF104DCEFF0A2073A9301DD561CB8AE5D70E2C41969C72307265901C5DCDBC3699D25969923D92622A481649D70F5386CC3F7460F131E78A03919CDE0C172A0ED54F77D1E5CA6E3A2433A9D0CE96718892A0FB718372BFEEAFBC771C5F467916F17728816935842A18FBEA9256C0BF724190F7EF19ACE2BCB32A7E94E5480AFC04F33A487EB5C2644C74E34518AB092EADD8AF5BCD7177178BEA972B9003014E53D58BB14E26280D68624B2404EAD4F7A05192B728CB6F72188B3E8FA9D7445321F5A35CD3947F4D2E690E89A9EF417B02410A64BF5EBBB20FA74A512DFEF93AB57A48C2F16CAAFA316E92EC012CA0186553D9834345FE826ABEF85500D4A9D540BA04C9B73FE53F1CDF440713E36FD3F9451010BECEB3E2E28618986FA7813E0149884290C3EC2699E334069BDB214222F2E63DB466B4339148016E53A5335ED2B07872B29025D9289946C6B8326D206DA949619DA0D2515BBE32A6986749637D3AF45653F9F6C48488770A159CA3ECA1F7BBAE2250642B90FDB875BDDEF88BD68A1FB7AED7424BE629ECF9FC7613ADEFA5D734249F4AAB34C6C5DF7D108E8D6FA681CD59834268AE95CEA869ACA86CA8659D2E4A19FB2E472AEB4DD0CEFAE0F8484911DE354A409167F7CB1A853022C6959C75246D4DA83CC2154E730D12AD863AF838566056951ABCBE51F2999C9B24ED34D0AFEB5E85392A81661B697D3DED82D3EC0E42D5DC72CD74B0D749F808508692456162E650C52092C61A749A7B957278A68D3EEA5D715D51A11405ED34D0EBA86821645DA983238C5515A30A9B6AD0A0CF154930CB2A4D0CB596EDB4D044AC1E51928843A78506226ADA9F9DBF970C936D643652AAA322C504749B69606F623485909B5A0DA42285E52D48166BB21B90FD486C230D5CD23A54FFF29D161ABAB0688FCB3BC13255C8B4D119A732DE4F3C7065170D9A77E52B8EAF72EDD269A1859865CA7D49BB8106DE345960F28DD7FD1B1E614B1D0A5F270AD0AA52832B1E408A64DC50D5E9A2B4DFD453AEE5D2D63AB6671539273639AB4A1D9C14C520AD5F1A92E1318DB470EB6714E43F0FD3460355144925841635D4C26F625424B84D030DBCA7C94CFEF975A50E0E0CD61148FBBE9A6FA6855DC52D4820AB5A2D24E509B0045FD9478BAAECA44C4250D65C8796E05161311541433D7CC1D39E320A82A61A3A8A7D424FA89AD8469A63AF9E6B930EB8AAD741133F38254616B7D5A1A2781E474C4AD141835EF7CC4A48A1DB4403B3CECB2E44AB2B35F8A29D0C53C813ED061AE3E2D2E90907C8B5D24096A4E112E24BDA1A50E9E6F25112E9366568B4CE97D42E2AF11B01ADEE0ABF55FFE92B77166A945964335132EF1A7722B7452A1186589F23EDB43BC3BAB3AFCC47219B76FD2416FC1468A5B160275AE6AA3384DFCDD48A5321F4CDAD460205F9D7AB5328C86697F35C9A1218747E1597F02573AB7B6D9FFB6C8D8BFBCC278BBD5026C0C3CEA5EED571D9CC5A5D3DE7A7C3F4F2393BEB1A5E3A7BA283FE22AAABCA921F41FB763337053AF79B99AF9678C78CA0079D50E37BB29259DEEEBE2D373FD6376E99493371A76D3F88417F39C57D4CC96FA47B83939B088D3B9CEC270B9D4D26C083CEA5E66D40C9BCDADC25E4A6C2F03621332DFDAE2D5B8203FF0ECAFB67D2F9D7BFB5269806AD7B6BDC7CCB5C7EA604069D5FD5CD27C9E46A5F96E23E5CE7BA14F3D512C7A211F4C0136A7AED463ACD5BDDDF11CC90ED0D1EEE2731F0C53A18C6C03F9FC1ED0EE92F677B4344305B167744B8DF4BCF95BD1DF1417FA5FEB732C5BF8CD90D046E42B4EF203093A072D69A13713ED3758EE24DF4FAA6EEE3E953B08431A80A3E9E9226015C51277A9988BCAEB803AB15B18CB3A66755F2E6690502F265937F793A79F3571C25D9A793659EAF7E3E3DCD0AE8EC6D8C821467789EBF0D707C0A427C7AFEEEDDBF9D9E9D9DC625C669D0F961D858FB0DA51CA76001995A1AA11EC26B9466390D127D063461F3248CB9665CACBEC4F75B931384E3F33F6CED05AE3BD17F77AE06B472BAABA09A09BD26DF489B149F0B5B3CA0EE4E009E02422E153CF534C1D13A4E9ABF590695F7AEAE5830184DA93ED2AC4C89DE86A98AF431CA8CE76D88B2441FE1F37C0E831C863C52B7C6E0BB308F5597E9A384F4A0A00D11F22707CA99815990A255A9F53B13D4AED0C76BF11AE5E82E265769F09DE98AFE83C7EC54187D375A249B6845EEDBBB95FAB8ADF3541E97ABD4C7DD9C4CF2A84C953EE6D39AFC8570DA856B4A79A48FA78CAE61F5DA29A7D898A58655965AAA7473E5683B352A83D150A1F2AEB2C9458CEAE35F9156FFDCE50B38DDDF59F4B68E0A657BB5E75A3D542F50B691AA22338C731EE3DC14E33D8FC10554F661FCC463FC648AF181C7F8608281F3254C9949ADCB0C382E8540B8BE752AF64825B42F0F6EAB1714585ACA41D9DF8F86A0FFEDF62F4BF41172DEB0CA8737AC4A45F22CD330CFA61AE68A358804A114AAFE54FCF8B96D4A0D4CC6FAA49755E49D0A0383915BF9650BFE8E64B27BD56E3B99546269C8644F7F3F9B9E9A28CF3FDD9A21A5BC65CB4A8D5C4B03576ADC5A19B612A3D668F3118629CC3266D35117EE9D9CB892916DE46330D9D0E7E41DFD2ADDCBFADBFD324A2C8D5FA7A7FFBEBB6CB6D75A8F302A2F292ED1AA8BD4ADD147FC2704E9747E89521A53D406EC5498E25D11DB5888575518CC3E7E46AC39569719D81CE55B781D6BA32CF2A745E56361633BBBC3EA8BFCDC992668E5DAD84E0DC881347480AAB31F05E0C2D3BA1935E3546A8A0D44A2B87C0619FF54533AE43665B25CA7C192576CED7213F51683F45BC66AB6AAD0A7CADE9548B5B2CE6C295372241DA152F5F6B351A7396E1880AA6874E48D8EBC1FDE91B74924E5442D582DB4D2AEFB6E673F80E4BE7A62B90DD52A36B3D9A7F3D91296D7EC78F3BD5369201893C70BD120DBE5432AC292E6D9F905F3854DB1C932BE40F5F54CD1378AEA4D47FA8F775F44232D8A87B7E967304A3063229645C3EE51FE80CF1962596153B84FCAADCE6FB7B57A9300E9293869E75D3B7BFC09BA93B8911D1D4EEC885D69B0589D45713B7E55206930ACB2B76C6E41005843BD2A1AF6482CC0EB346340EA32837817B848211BEA5295E9A3AC13F402D38C5BCFDBE5FA68F314C72127974DA9C13C631EA72E3398E9086419B31AD565FA28310CD13AEEA2D465FA2840B0BE02E3E5352D5C005D94BA6CB898B083F12A503DD149D3BABDD252C1696A2E35846CD2692F76CAEB32FD9F8EF6E017DFA6D4C0620C827B562CEA3283D3C2EBC91363481425065F948224605CEC75D97E312297D6D70137F661EAB2643F8E74FE3B5D390EE56A8D8CA132411ACFB04CD5A1050B3F44206020AA2203F98B633AA78C00D685668E29DE2FB567B223CD56BDBD08E9426B4A923E9CD43F2742E0623D658D46F13A00969E3D5789D2B7635F198C06ABCABBFAD9F06FC275786663AACC62A0EB8B652258B67660FDECC8A3F6B0C4093B96B2E8685DFEF93397F9DF819E5702EA6AF71E10E90F7075CB69F0B26897C1834F39C8D70C87D66506282B90B2477D759921CAB900C5E8B4AFE8F15E80223CEFDB1BF6761110AB896AC5E88641B294B567227E9FED9AE3DB1F24476D6A47593A1059123CB1E2469CFA810D244A07ACC7826AF7E72F80099B8C5B8203D812B45844F87C8F336ED6413763693DC4DE9D81849BCB8ADDEE343E6739788E50B614DCEEEE561DE61EA30AB11585283055FE4EE00F5672ABAD74F53096931DBD184B7F5B2FEBEF676FBF2747F14816C088AC0218EF89ED96423C2F32D86C1E2AEB862C885A1869AAB2D3230C207A81BCFE63AB4D0213029409A212EA5293FB5C2F3822D46FB8EB5C4DB99934F38AD9E6F6A4BB28B9B20F3FAA76F9DE689BFCB9FD709E13AB408CA56F03C8FAF7F23D7D6057C8F1A297777B39E14AC80946483C0F98FB24AB4FA029CA245F575659605E5DCC3E4B30CB2A0BCCFB8BD9EF8F32D4BAD248EF40A1DE81A67AA77E1D89DB86AC4DAF891CEEA65A8A8204EA6A53B867BAAAF526A70B752587D3D6582A0885895CF612645D692AC6ADF6C118ECC9C289ADCEC3689BE9A2AEBE4EDFC69332CD993ABC9332EEA2ECF65AB60F5253D3F6C3481D2E4C4F2E438AA0FE300D46F717D9DD5C14A70F54D26790BB384DA9E1750E76B23785C3AB89D11CDCA1B27AE8CD9A6BAAAB7A103555552F8A7F5DC20C81557982EA21F514FDEF2558E5288B118878AC76DDF0BAC15402A466564C2F41752DADB2C844FFD22BB9336254AD392DDCAE195AA35F4618875F52BC66D69976B9C13E617AC96C136881C12E01029A56F995D1E7AD627DACAF288AC88F34C3DF19BF43A7C2C8959CA7884D48D2949A4505B05C999B6696A011BD2997FEAA2A34D02F280988DA64B44A5D68B00E837009D27BE65E4D536AA653408692B2EF04A421AF57D87A030E0354DA78B5D02E37401309E1B5B914963A801F55BBDC004DA81ACC47758FA7F3CBB41802F313B42BCCF09E04B959DAE5869B4C9490419479AF04FBCD4EED8F6C0B164F7E2F994FDA141AF07BB5A0330CBF2935E05121D29D05D21F449D33E7C94589C1FA9E5DC108E6EC515BAB78AFACE5CF858E77B09F17E1E86EE2C57DA5161D6D2E4C687AB87B74EAF4216A50C4C64C95C1AABEC90BC5C86AA7C260BEAAAC570C5AABD850DFB22AA42A339D35EA1E47D5FD14D1D475EB6DE6EF5C367F46DAB79EA873F1FC19611573752E983FF3F5E0A8D6A603F2537CDE3C87EC48FB8AB04C34B0B8BF520B3B4C2DBD4FDAB8F80441205E533CECF1C5154A6190B3AF6434A5E63A48AC824C90A6C90253B6C242CDCBD79AEC4623FE27DC148EDAEDB0B4DB994BF5C68199EA3701C0E129B8513DF5238DEAC99F7ADAA15AB9460948E83D802F6B44D4034A1CDDC3D1C2D554369A5852B748DDFD8ACFDACAD68DC14055004622CA41D9AE18FE10D8458E41FD4027C5ECE4989B975CE844DF07B97E842B9CE68E855A0A6A2AD10AA05E712EFB4A25BAA91E85FA0022FC0AB6C0B123461502E932A7A4B3746A5B2963386E64EA46563C0056A4A19E9B043D999BB0172D4C0D06D5C4911EA66C1593FA9483059CCE257B00BE7648AE72C1DBAEDFC1327F8C55AD6370CA865E34C52607BD2F28A36F710B8E7ADB35C3EE79EB1B73CFCC5171BBDC287A7A0ED39487EB541884ABE0F286FE3508508472C06DCE850D8C7D190E6EC6F97814825F8254B7FF76A8B537BA8762BB50D96A404D7DDD07E2475913AA794396D31B9DBABDF911F3CD7411A57607A1AB8D4B0FA4B665D807D3ABBF694FB191D8AA1CADC403B0120B865827E1234019292D1E0ACEA12BF79916B02EDB6A82497F8AA63FC7BADDAA91710F84711BAE73C3AF4A3C4D36EDC190CD77D38D65CE6ECDC89B87C59B772027DB104777907B31CD785485D3C3A7555709AFB66A477E3D107EFD0582285F3A605231902667CA3ACBA6B66CCFB261537A98814692B43F56B97E68CE0F9E859B520361C23C4E5D661215001609CE10E3036A15EB63FD82B315CAD94B614DA991F2E12315B0699CC2E19EDD4B511C5D6F73A2881DFB840EF0C6FD2F3886B7E8055E2421FDE757B2657171EB5E075657816B41C9053A8611E9CD29F456F961AAF42B48648F666D139813DD2A83908434452F20E2113B15C387303DACD315661F1ADB140EEB903F3E955C9FE2B0B7859B6203B59C82249BC3F416E6DC310A5B7794F1A874D61C2850118CA6C21477D538DBE3FCEADD2A0386BA7F9AB14AB22E33634BFE576F4AF7EE67779708428166C004E6A7E0F4071731C1F0395459137C666A7F4F408E1798BB6BBE29353981E51F2A7C347EA8F020B6ECEDF3FCED0F0915689A27844A043FC78377DC8DCF3BC3EB9EFF84209DCECB64DAC4B6E0133F0A1B58456388D563A77258E3C8D9DBDB5C629699613A96EDB5D0EE23065CEF33A5B30D23B8E233CEB58AF74A4BA186C7CFCEDF3B586ED5809A2B6E1FC8900698BB7DAA3B67DF24C2F438947F0CB95361B6839ECEA5A169826A0381200CA3C016549B8EFB0AE100B23B5AA6CAE012D277C2D7E12563EC34A5069C43BDC1E4FF3C5AB766074B8285929261B9CAD5F5077C7E123D0CF164F8304426F029649E7D0AFB6166D26B0991A31D930AD260DBA486F911F6D12A243E68AE29DD2B26FB754D3347B9487A2041D26429696FD92C571DD81FBE557C980E6BF2E79CE87C6E356D979B58D36996CB20B94A135763F402D3FA47631C8E9D2A7DCC2F380A6122C464AA8C766B394AD6B11095AB343A4D8D71120A61D93A835FEB41B0BBDC141AFC3ABF0A70368506BF8808E78B39CE8308E7C11CE74A8473658E737C871307E4FAFF2DC1DF935B902CD660B175947D3FA0E6FAD307229BF86E3FD6A6E16B0F73519AE14708986FABCB4C50FE48B97DC0A6D004E76905C13716A72AFC91D540CD6AFC2FDEAD394AC54253D5BB3B5C52A069AA142582E2170CD9C3A5BACCE43066C1BBA3368546386CDADFAAC88083D6E90B6451368546A162C5B914644FAB3A1526265C16A450F67C20B4725CEFF5D1D5ACE6C9EA452D1737DC94789AC7573D187E0EB0F80DBA6C73EEEF08AC48D2AB3CA712B7309299625A897C40FE9897AF3591EA673168A7421FEFB725C8400A18F3A92E34D436AF4275F36AA86FF6EE688CA85E9A91FEB5FEDD788D236E612015E02FB2698D78E04E850987BF807C8978BC4E8589DF7DC5636D0A8DB98DC7EA54ECEEA8919E7DF3A7E1431F539B0498ECD2EE432FA460BACE3314C2E269DEE675331786A001BCAE656804293515DB28EC5AC4551EE6C673DF6E51B8102B5761BAC7B77D3DA0CD669904B358691DE818059AA64A51224825BDE9C4D9B2DD2A2393D3F9754262536EFA72D666AB66E07B31479B2BF187C97378878A932F57422C03D3966139805C848B3EBCF86E8A772BBAFB2168DB33F44D2C7A284EF652DC0E599ACDA5EC86B7355035995C0B49F62BB09D59B617D58FFC7F00BEC98233BE4E1C31AB1048973F259DA52CF91208CCA7A67464BFD1CEA91076E7F62FFCC80EDCFD421C4D37BFA4AF1FF7FEFEDF4F29A68397F456F17827655F1CEFBBBF93B26BDDD13A837297D15813D944BFE8A0EDABC6D9DE5BEAC4E9BFF5C1A86FCDE972F57723D525EBB1CFB7D785067E2E1C2098738CD42ADECD459096548903DB3B95C6079AC5564D1067D2A9330BEC9870EF5E37A566B2C02335A5465F7A13F250AD627DACCBCF53D28F076B971BAC48E4DF688ECAFCD33CA8A05A1F7B4A5F91A6BBA9EEDE68536AB437624E3ACA122384730EC1E88CC3F97DD203B69476E8267800590643076E023190A69B40D659BE44D0F6FC1A51971EE6F1EC2DC8729A14789D90B96183163B55066206D6ECE1685534A460CC103B376589D5A229B0CBF85AB359BF073473D523CA61C6CF7BA7D20CB7188C04B65D67A26240BE6C9611F677E16AF591F1339941C006A035A5E351BAFE51FA505B691387E42E179914C584874267E1E46A40DD45A70744BAF894FDD8B8F256B1F1F2E3E0AD91E2720CC7A34DA981450C081F6631B19E783CB6CE80F5A7970CCBD302A3FEACCD5A9418EC5021D1BA2160145C536A304311C6E122C5EB15333BAD727D34487300B0DCB429D4C78931BD22293A18E8D6E823AEE81285E7CF28CD975DC46E8D3E628249A714D33D4B17B05361869715EFE7663CDEA6C2F08B513207318A5E059FDC54E9632E710C4351EA8D4E8519DE8ABA43963C5C5D6E82C6198855913E46C0D9AB81A1991A52EF040A18D75653AA8F94E59C5554151970016296E7A240BF3F08976CC47155643006C08E01188D61453643F4D14D16A42E359031F25F9C08BEA953618AC77D5FABD81C4BF4AD6C9D992F93596CAA22338C731EC3C878A51DDEF31846A6EB340D51227A25BC55AE8FF6FB2AC220149CD3762A0C34075ED387DD19E551179AAC7D74E5C8494736ACA85BB36766317E41F58BD74EAC62059EB651ACC490DBC47537CE29D3A919E3370E247CE8114668818821F0395C07AE2E7FF4836A72A90E90FCF0A0EACB726AA7E2303D8857709142C1315CBBDC8051F7ECBAC8EF097A21F63C676CB6CB873FF89C44C4C2983E9769EA184F6BB7CAE4808BA6FACD58FEAC0A7F644F9CD4F569E9F53CA04B328F30476979BEEF4215CBC0B455B01C40CED6751F5EF7B66B0E54F94E1F5907D5A39142624DD70BB1C52A9F5D90B1567E5D662060E20328ABC3A7518D1D81DA799ACCDC6C4FC4409AEA46D6593AC1412E08246F4AC78DC818485E21EC50B460B0268377B9C5EA83D415B75E18A9E0953D39C96B8A0F74751FB75647B1B5BA83215AC72C479565C35B362E1682095EA75C8C4F55366ECF0654E6314A40EA44870B91B455B7A4B75C63171D788DBD29DE85C676B90FD95EFBEF9BBEAE7E1C816CB42B0C0C2607771D5C3EE937EEF876AAC9C8C00BB38F32B8FB1C5046F8DA5ACF08532E57350CAF0EDB358769C336DFC0EB20B66EE0CD6C11FFF82C0B8C7C3EBAF4A125CFA62F288037890F11D383D6962E5D3839EB95089C546D8A0F53A4F6CD3070B6F572687E4DE7C4F067BEAC2E3340E18306A7A6E182D99AFC85B06025EED6E823960F38315CBD29FC910D1EDBADE02E15320EFE24B212D367F55267AAB8175457096B00497F524C23322F68E7CD3D50D1C558511B03C6291004666EAB7C4807B78B84EB0F80BB4C5B15192C1293C70B16A42E3350ED2C8461FF2F6CFF2F86A9E7A90A106885FD13621A6CD64A5DE0E6F44A03565F9035A05442D6E92D9263AE81C5CACFCB315365EE1A70FD7C7099F500654B5E573055C3BA42DC5961490E82FC5E7046C754E963FE019F33D1FB9199E1BB317BBFC59A55A206F357775956D4801A0A4007442A465BE554A9A88A97672817EA1DEBF2FC15842E2EA84BB10CB4B6A4BFDA1EAA2E18B2FB55AE7248CBC8C9B993F0FD189BC763CA8333D161DA5129A4828B5628A537AAA3CD5AEAC83CD1C1D5E5743D2CB99DC876E72C14618BDD86E41C6B56ECC3908A7C42AF5546EBACB92E42BED391686883EBCA8701A094DDC4189CA4C89B8DE2F2C38ACB2C052F307A84014E5D58462A384D915043487FF2A217CBF34DE9782430BEB2B2EF6EEE033AD75F27DF12FCDD81C2100369AA0A5967D904C7306693635445FA3FD2981CA50F614C8E62EA47FBBE047946F85D84C9D6E9A3CE89627EC6F81BFBC9ED727DB4FC3BCA7398B260AD627DACE7082FBA3065893EC2986A84C73886542354DB61870942F625FD46397CB344253BF475FF9EC1F4162F50E2C2CF2D07D3F471AB00FCF8B72945DE146B4ACD906832D1EF7437C3A1353566888F98DD5A36A53F8205BD43CB974E3461EE75040B96746002F7206ADAC2BD28B2992F9A73AF94D685667CC91BB24DE928333FACCC7CC5E5D53F10CD52801252E9C61DAB85AB293F9A58B2DF82EFCE8A94B8C56E5DAFFBE128757E7938C8D10BCA119B2AB95D7E646EDC9AB9C8D863EC2E524907D650BED4507DE2B5E92D93AE4E8351B8DC0B5711902C88513E4091AA2B8BF82744F89F6DB2A15E956CFECEEA02CAE960014B9169FA3D054B1883E26BB31508208DB10AE1354AB39CFC7EE01964B06C72F2A6388C0B614A96EED72C87F15BDAE0EDD37F46930815C75E75833B90A039CCF219FE06934F27E7EFCE88B170112190D1BB0FD1FCE4CD5F7194643F07EB2CC73148129C1712F1E96499E7AB9F4F4FB38262F63646418A333CCFDF06383E05213E2558EF4FCFCE4E61189FB2DD2B582D9477FF56A3645918B5A5BBA57B6A25BD5A6194E4F43765B6751F7F83AFECCF5C33D0239CB73678A7CC6FCD76FCF8C06F0AE9103E9D203AB3859A2A155F0EC307401D59096D058BC19EBCB95F4711788E0A9F59C43B9758F826D776492479016950382CEEC05FB73059E4CB4F27671FDAB879BAEE85AD948653CC528B3885FC3C9FC360F3DA8ADB19C01E4043FAD08D02F1C33BE3496D67DEEF22FFB718FCF5DF4DF15A22523EE0A4FC7EE3E186E98AFE4303DA6222D0A2CC08EB019D7BD7CA29FA268EC803F6537533682BD8F692A7D4B0F4761D5D4C6CB42BEFCFEFD7AE68A3F8C8FCFDE71AA2428FCE11B52F5CAB5AFA6D3D8AD6427EFB94CCEE5542E5BC763AC6CA99ED1CF3BD07CC9F3C607E708C59648976FD23759E32336624039DB14E26280DA81644C7A838CA4D9CD39F26EFB5CFF648153D8B54D1B6C8CE2DA9E6AD4F073AF333CD007F4BF64E8CF96FC839227BC0A5E8D1A5FA1665F90DD9041ECB8EA8FE260F52E701B265B63A466E99ACAED785E616BD53DCCD0D33052AD9F03BE6FD63E1FB5EE63C733675D7C52342C2FB5F073B7D32478A95FAF7A0281E615468896C89568EA1CB27B82FCBC7B03C2017CF3A3A46BE2BC2DE1C83564EE5C195DA873EC9140D15A60B9804AFD545DAAD46AD2DF84F2048C131B94FFBFD9CE6BFF866925CB37C91D802AA3D397B61F64F966B02E3450956294AB759E62C9DE8EE84A8BA3E7DA46EB2A73243F9BEF3E8E825738B397AC9FC7AC92AAD712C0BAF1395CBC3D2DC46557881DB2582FE773A9F2D6199F760BB3DAA80DB693AA5FE81EF85E62CC779767EE17C715F6C127779998B12F41FEFBEECC4C4373E808651820F6083B3C9BD3390ED7493640F60018F440F3AF3385BAE3F9A5B22BB21C9BDFF7678BCCFDFE50A4B23062F0210C2F8D586B940006C4CF3AA9B4716F3715614540F3438050D8BB7481C83AE5B4F8038059EA7380EDDAFAE39F6001AD0E7465C2F2671F5EC885350E0E00880474DAB6C4C6E7D7082682E2BBD36ACFB81AAB94B907CFB730BFF3DED6FB398D6FDCAEF7C460B2F0A8F52D9FE344460E705C17D0FC35BA0DE5C4F9E7A304D212F5390046A8F7B1FA8193B61FC6D3A27D3435F3ECFB8207B4D9EEA8058711787E0F398B91BA2EFD6F43F8CE88E2A0D8BDBBD541CD35FCF83336938ED3A014988E82A9EDD24739CC64078F5444F2A845836C221051A65C4A78C0CC779F4D63A8DCC38928D3193ACD9ED9ADB7E04C4D90E5CA80EED82F0C50E25BB51D12B574E90067274E7151F172FF914113A567AF3EAD64A4B96DDF6233CCDFCE43907F9BAEF74D418B4BA69AE007D6F7E2BA1BA78EE1E547DB6D507BA05975AC750529E9BD932EBEC80D9B53D73A3381C85389015BBBC135D3E90646BF4F24856F22186190DDEE330785B3C47F32B94EF864CC8E413DB693BC61325F4D666B7B2F35E58C6160784DD6747F6DF5DE0E5E895799CC4EDAAE4E2BC740FF699AB0870C9D10E76B3E981DBBDA86B248D59DB962BEF89A994423C2F5EC82C7F5CB513CE6AD75D013FC200A217D893B4C0C2A08401CAFA26C7E2F8E82679C11119EF8DBB50410FBADB53485509BBF5784D97F58A05ED16F1B2339F395D6B116F3AFB8F7FBB528BC00763DCDEDFE9FCC3BF5ACB2D4D02AF04FFBBBD4EB8BA987D76E3A6AA11EF2F66BF3F7298CC786D740CECD531EF2D7071FDE6848339D0D8A49E7FF0B34B3DF7B24D35DFA6A3C15556324FE1365B8FAABFDDD6A3D579DCDF1EC7FEB634B493C5F036F630B954C60398FD3D80E1AE175AF0208B61C393220CBFC14372C38CCD52F7F34D12C2BF3E9DFCAFA2E7CF6F6EFEE79F75E7BFBD99A6214C7F7EF3EECDFFF66FD1991B1BDA9789196CBD19145ECDB5E2F85B90841172243EE5B3F66A8BDB622E3D5DF0FDA1CE19ECEC37A7A7170F30CD68A2E42DA22265EF75F5AB395FBB41E6A3FC6B4F5365A50DDA3C4EE45A7E3DA9051D06B67145C5F4EE4B054A309F5102D257BBB0E3E23AE48C58626BE701360ED780E2E1A52FE5C34BCAB934DE1CD047AADCEE0DE87B5357E0D5F599F357445A2FE00C7F57BB1D6C5CA69B8783DCE23EE5BDD9536D1CC86B9A57CB35EC034A021C3ADA3914CF05DD73772DACD3C8800C2525E804A4AE7DBBD780AA001F7AEADAA1062815958F51DE391CE53D9ECE2FD362A8CEF09E84093FEC37C764CD5FC2327BD3707E46637FF3AEAC548BA13E8014654BE733705D993BAE71EF3CE1FE41162825E64FE6864E76052398C396C9DA973FD1CCC351AC24366E0DDAD1CA975177DC950363FFFC10D49545B4A606539A1B4D4D12A21EF1B45836AA4C4C7DA944EC42649CA396B34CCF085075EFC3DB54ABB5F61653AD06B69D6AE7A8A3D76658AFCD26CFAEB526AF93F45A69F36E86DFD125BD8D1B86CE67FF931B5EA20E2D76CD290CF29E4715B6D076AEC73B4D16983E688475F4BFC5B82738D238111EB5E9A168D3B3519D0EA84E47D537AABE1F5AF51929A96B9480845EF5F8B24621A4A7C39611571BA0AB3263A9A9CA62FB8F71573EE3AE3A4F473A45F696A1DB7DAEBDAD83CF84F39A6F9719CA4E7A1FE10AA7F9B6A25BA26C25BD0DC428C0C7113859F0198E6D79AB95B1C58AB198FE23571D0757D170DC4DE29CECB81E3F79CAC1024EE77A46F25EFCEE3ED8D3DF8B495A8F705A307FF17BE1D4F5FDD77BFC8232FAE2B2FBD726DCC568D797089F5D27F6A40725304D3D20D70FC65F83004528077DDBE8BDB903E8E3B104D19AE5328C7D5658019542A3E5C7A2ACC947E5B1DE43C78E4DAA4ADBDC41686DB8B731ECADAB16C0685E1D87795570D83A091F01CA50B2281E83CDA1B56FA741B2E2B26EF791C78E87C7CADF2E229F61C95A0D800D67757B8F8C75748C7557FC72B6B780BB205B30580B6164B2E361B25F2088F2A50D67953D6D38AAE9E99193863C94D50DBD771D25AB9958C78207531C7B383F9E610FA057082C129C21E78F38FE82B315D953AB8F5C2C2697E8B8BE7DBACDFD981FE97C5700EA20B4C566C9B04A2AE52DE996E242BFC72504C7F016BDC08B24A4FFFC4A763956D7FB69E788E0582D29ADBE3F58B08F8F85E50A1219A5F9DB9C3D027691A6E80544CEF03C45C93CACD315EE7987CA22A6A73F70CAE642F08FADF1EBC315F5BC9ADF139AA520C9E630BD85B9ABAB7292C5C9758E153A23562EE9E698CACA3BDDEDEED1A6BFB97F9AB9BF8744C7BFBD1235FEA5B639F0A5336EFB4B795F217BAD0FF39BF5B35E3BDC1C730272BCC03D97BFCD611FFB5F863307EDF509380B889C55DC591F5B1FC709D7DDABF313CC7F42904EE7657A6BB2B88B322DBA8B1EF0E00D3B9CE4D9B3BE1C2D7BE1B6D3DFD5B93ADBDE362AC1D15E51F083C108AE4449EAFCED4151232B67E7EFF7C508DAA31BD9CEBC7E160B6D84E9B967EF2BB4E6C8F4BFD3B96E949585D941C07CE297E3BF4238803D7B4EF3EDD1F43BE1B7F0526DDE98C3DE517733F9BF07689DD5C3C2DDA6A78D2C8075F27C99CFC21FF0F9A9EF350773D4ACDF5760EB73563B0B7A518DF74D9528D270FB685F14FD80BB5D2B07846C8B6B0D260A1473EDCEF8754D5329595DC4AFBADA644E6C753D92D3C99D7991C99F73A2D07BD74D8B744628CD724D788B17D950F402D39AFDDC627FC111E1193FD80F34076FB28EFDA05F2110E324F4037EFDE0633FFAF4AB0FD42F5E501FBCA05E7941FDC14F1E064FA3F05B82BF27B72059ACC1C22EEABC8B6063F7F0087BB7C775956AC63CACE51102B57FD106F48FB46F1F6083FAB482C0B57BFA07D707B554F4B296CD164B43D7B8DD63D114F95B9C4DD1EE366753753FBF5AE5112E3C78B8082A9FA0775B995AA72FD039EA150E8A732FE8FCDCAB784A10F6FBBFCDC56BD8C3AF82FDABA7B38EE5829768B7BEEDBD40F7276A45EA5BBF875EF50F4B6400F69EFDDADCCA7DF684FCDB12642005CEC74B74CC6B8F92D9F7D335CBBBBE0B9AA7FEB566885E1D63E378067F91AD72E403FA01BC807C897C40DF81950FD88A817D40FB3BC8A467FC831FBB5B4402F687C7383611D10B4A16D3759EA110160FFC368FAF59D98C6D3C9BF59303D8D5DEF488BCB78774074443AA2CDCD73AB1C0968F11FCB89BE5C19D67651EC862A9B77A83ABE96EA39998EE1E8D7C9F57278961BB81771EDD7510B7320F2E5BE0E167F6BB43C5E19EB5DC16BDED6476D3F540E5F54084CA038FDEC4EDF7ECFC33299B0DD8925B59181BB615618CFCBBD7FC6BC66A5F27B6DCF512589A2F4DCF919346F3E268CC0BEAE82FDCCD47E2E03FC8FB2DC50FE041E4C79B2DE3CD9661B3206CD449EBF4EAB8F2F97A50300722F91ECE4EFDAB5689BA729A5A75FB332C2A306AAEB20998C10182791FBBEED33D9296D2E86536ABD814EA802C76843D27BD76AF7D0713C153D70E84CE032C998B9BD003EEE5E72981F6003C21FF4673542679F6803FA58F4BD34DA5F3308BBE37472D20D5C71B7B7501F687B2EB8C9C180F20CB60686315953D6D6CA3A6E7782CBCF5F1E52DC8729A4B799D1453E4167C02D63D07AE1E24C7E20C1BF5CCEBDFB7B0017C18B1F447BB0734A1D723CAA17A1B6BC913C5B0BDA05F1135BD6C56426E6EACAC5AFC4CA61BF0717A76F99DC623FD6D8FF4B7599E76E014365BF3521413560BED3D0215824D5C7DABAB4FFF809F67428A4B47EEFD049780B05516132BCD03F8D5F4D23DA26B73FA1A12951D02D761CA9711C6E122C5EB95636048732D20D7EC15637A97D5CBB1CB8A2E8778FE8CD27CE9183AC10437C574EBE601392B1ECD75EDE92EA603257310A3C835D32D710C438D1C2A76C82BEAA672FD132EB17B3B37E8B3C7CD2143EA3942816BEF6496BBDFCCAE90EBC309102E9D477FAF80EB51AEC8DE963E37EA5A1390FFE2C4C71494C8EE27A2C6F5321DD407CE2DC1D6DE74CEA8B746E22C792BA4691AA2C4C7338DBFAF220C42E1B9BED54003BCA62FDB3BB702E8529A13EC2103C7C8205E50FDDAB7DD9EA006B0F289757A8FC13DC71326F60823B440C4C0F81CAE03EB2B391B141BE6EA741E7DAE5BDFEFBA828B147A39843DA44B3EBF27E885EC4CFACCDCF7E6B3E029466E12116B64FA5CA64B74EC1D2BD34CAB876CE91EFC711D99AE9DCC03E5FD7F84394ACB30122B4D5FF7B653F5EDDEA3AEDFFEB463FAE8586F5EF066ADE59D7990F5A6C03557927A6789E6C03A1AF2EFA3861CFEA8C748B73D4D6696FBA3A720B7BCF4D0F41CF745E3A507971B39E11C0C79A7F20906EB08A45B6D0D2B0C2BC96ABAEECA5490AEF84E6296AD9E031C3777FA9B3B2F59E52D760A1EB776773044EB7817FB451F911416738BD7A9F3E710C6FD627B118851423EDE4AF7175DED74FFA6EB0FB64DF4162EE963FF79488B46C5523EA6C14B4621BD272BC79C42FBBF2B852B585EA9A1E2E220035A0368A75ADBBD7F30EDEA43FA9B09F5123DEEDE662A83659F0F3AFB6E2958E90B0AE04DE244A64A2C2B81DA741DA5E9873229F41E213BFFC98F9BDB62933F9D930D886BAFD4B437B8F4CC22EC6F4DFE42D8413E7B1EBB7C8BADEF0D067303F3C7B6ABB6DBDF9A297E1CFC49642FA60F79A6F62A1FD328D80B0AB3B9F46CA5FF25381ECF034A921E0E033C38EEFBDF3BB0C906D3773DDD22F06AF278D10B6ABE44381FE717E788853A18F05801179184ADEC279667762C8EADF072201E2577B3B47B105EBFCF2194294850B6F471B8B7B32C4C162108490E82FCDEC749E41FF039EB7BC6699F234A679574C3FCF5B8321A551FB5BD316AAC28F357105A6540283B57D7486DDE36E5007CC637F848ABE13EAC41EB35241B0B891EB7F56CA4F758EC0B5E5DA1945E928F360B9CEDAACE01592DEB4294038DD01913AA0FCCCBF9845E3D8DD6D9C3E6E20BF9265B8616A35971B51C6A64ED91B535587B968217183DC200A7565645D9DF86779B9EA3937C1827B905AE86977C5F8EC7C707778EE2707C9D7C4BF0771B5514C3D826C54DD5CDE37A29CB436315E5A5CE3E630529C839638BE3E89ABB24BF8CDD8449B3CA58C14972C95861A932C858017E5F823C03AB9543C83951D5CF187F73F4C9F97744C5C911DA7384174E80842955ECB20C084E69AD8064E953ACC0844953AC9004A952AC7084D941EC46C46703B1C2A1FA5492B5C43AC5C6BEA5FD28BFD16EC68CBCBEBF6730BDC5C4A23F168F2FFD209125C44D9C361A4D2CFB9D6EBB9C213E627EEBE83025A53D941BE6151BB8AE6309E844DEE1701DC1827FAD5EA4A51DAD5EA2AD3B7A66642DD37164E4C366E4AFB8BCA507A2590A50829285A5C39207B2E16D31CA81BA290FC497E8F18E6C90A31794A39E84CDFBEEFEAC99920C22C65B849E7038DB484807641490C3149022A6F45064E322CB68D813E5B996707C8E61BA8049F05A85B8FC59649E83694695B8389EE37312BEA18B7709C0B6AD86FE04A3F95B61FDDD3ACAD12A427413FDE9E4EC8415BC6972052398C33754FDE0841EC0670108F98923DF19AA46C67E1A3734BE41776CFF83234994014CA924D233E6220E95082DAF39E821DD0A448A5962FA08F54D73A871CA9238DDD0606BAEE00A265459A826625BEA1B22CC0FD2373D1F4F5B4CA8C19B3495E32D9AC36362CAFA9B786E6C6A8E940D371F7868FC77768C0C7826E7C0B3A367416E82F795077F8120CA9743F3DFBBB76FCFB89FBC4BA11C18075C171F27FF545F7728BC8363788B5EE04512D27F7E45193A26FB4EF4793C3F0A1B1D29778ABEF54078F5D7353D263D264BAFFA226E449BF2E364C2FAF30E84EF88BCA064315DE7190A2173A5FC889851F599DC30D58D8F936D95DF7C20BC5CBE6279445C5B3D05CA0DA82A3E4E4E14BD7FBABF3CC7BF257044FC277828811D9CA8C971F265DFAB11FBCCA37506F2A3E2CD4D4A779E279BAA63E545713EFBFDE5C12A11DD1131609D23921DD1A6FC38594F981A739FF96E25CF437754DCA8F84E018F2A5B1F2BE7AA3EFA60F8599CFEEDA8585992E18EE76259C36365609DD47FFBCBBBED7B9847C4AF9DEBA5ECB0BA95C7C997F2FBB5FBC08B65345011FA811298564398E0105EA334CBAF400E9E410639E6A3BD9E605EC702AE569810A42637E1AD26C2A8FAA9BBD54FC112C6E0D349F84CB35695814ADD16DCD162971A956E3A3001A5A64A44A5AED521B14E26280D68AE0824A4D3A917136B35E9A748C7758BB2FC2687B1680E997A1145A689264115B11E42FD44AE8B07BB375A8723C4D48B88314D7A083E812005323E6C578A48B5EBFBE854398DC46CD8A915526A1A68D3127ED1A64A41458BC24D923D00FAD29788C6A65242A5AAEF274415E2055D47E25701A54EAD8854A78106A94B907CFB53CE7D7C1319D16E2B1DCA187F9BCE2F82E2C9E18CC6144BC8F3EDA463E09B6A0C64029210852087D94D32C7690CEA1867F178E4CD65C392F7E8191DBD244695A360244D95886A53ABF3FDA4619186BBD058B2AF661A49BF9569674C5FA6DDA52DF546A2A7F1EB7EEB04952EDA32F7AF8219248D558312B5D71F17BD4E50E65F9C10359C4285E4287BF48C50DC498F5F5711A0771AA54C5BD72B38B76EA2372F456B05E7D6F58A6FAE9B68114CE629EC99F9761339D9762BADB94D16D269A555F219A5B51ADFC687740BBF8F6F26FB46BEA5C628B8BD9870105C2BD918B8863A1341231D655F5FD6493FB9ACD62552862CCB0995F54A6265131382677D14CF34488A421C799AD7280145D2AD2F6B14C288ECA1E47223692B1B89A4B9C9A01EE10AA7B9C6885A0D7B87D36AAB33161C2BE85795529A55BD86F6D8981E995CAE24ED647A45D0546320D7752F4A58360AB6916C086C3BAD09A75D709ADD41A8FAE9B966F21F816DA9338A75123E0294A164516C8073A8120C4963E98824ED35C6555E9EAB73F78987C3B4918D8269A64FFCAEB8B7A7586005ED7A06D16EAA31903A0E5B48BDAE9491ACEB75E808E36BC554854DA56310B6D618114D882D19415925A358D66A52502FED9D162A7A266AA795E95BA2733A2D640AA7D348E36B51D3FEECFCBDE483D946B26F66DB69CE76D5852E509162CABBCD54F3DE6DA9318A4DD4AE90F8A6564673D3408354914AEC16248B75E9701152641BC908B3ED34E893D6A19ABD3B2D64943B8D34D8BB688FCBCBCAB2459569236371A699CE372B435EC593A0EC229D15652F8D91DE950F8EBCCAD7964E0BD9383A8DB4C86699D2ADD46E2027DAB4D1A0394D16984CD675BF4F4BD852360A61639DE17C9D284650554A8956F51A82F00052241380AA4EC6F855B52E91F6731C4A935ADA5A391051079DDD7315DE2BDE345795D2BD7255AF4327453148EB64F7327A4C23295DA69D16FD3A9DB39CAD983672EA9D661AC44571ABC211881ACA86216AAB3596265E513286A6819C76D34683E6D364269FF5BA5246ABAED7A153BE67DF37CB7C33296DAEA5D628AA983C09F1AA564EB36AA0454A195A251980B28F7C58CA6E5A839545D048C6296B2E1FA2AC87CEE8F817CF24E31234948E48D0566F2CFCFB4DD2D1089A2AC62368ADB182316FCE88172EB6916CBD62DB69CE48F9508B7C1AAA7AD5B7574D74080A5FDB901017B7950E44DC5C6750F2671324235374900E4FD147638CDD1824E1A8BA4D64E3E8B6D2A05C25BA16D3AC2B65D4EA7A0D596865E214CB41BB814C06DA6D34BE8DCDA128FE48AE95EC6BB9861A431067BF130F44D256361C4973834175D28DA9C7D46DDA37A46E6B6644AD2030F5C9983000F14DABBBE2B8AC3F78B13F7C7133755A675C1C9EECA06F03D87B7077DA9D2ADD6954E62492CD9F7E2223FF13C79ED93533263D8ADB72AAC4E973FAE64A23E9CE709375269F2DFE14D16EBA14995E2453A59B1BC6FB34750F1B3630926304CBE9D14D66229B2CAB6428FEA74E717ED24CA4CE5988DDB4AAF26E4866523B5587F7C9639CF21B1C99B7DD6E8A8C534448E66DBB5413DE2753C705BE01377263DB4DBB229B81648275F31F789FCAAE07B38111FB26EDA647F3E2BD64AA6CAEED7B9F36B94F7203A9E161B49D4EE51D71E934EADF2C1F60FA58376A6BDAA4CE51BBE9525D6796CC95F60D68EF13C5784337383237A7ED1499DEBC954EDC56577807984E0D8F6F6B924D9CB6B6536F7049543AEBB6174D079870B5D7BA35D79ADE67BB69EEBDCF28995AB37B90DEA753E41EDC80295D7EF269AB93706FAEDD6DEA3E9E96FE9DAA80FC99E3142CE01D0E619415A51F4F1FD7A4775CA6EFFE780533B468203E12CC04069D6B7E9B36F482467DDF901951DD847B3A330721C8C1459AA3390872521DC08C06DE9DBCF90AA235A469CE9F617893106B6FB5CEC927C3F839EA0408D35B8B2AFA1F4FB9317F9CAE8AB84B179F4086595C4F9926976B14859B715FF309F26510F43A6495759FFE96F464042E5E3748F738D104AAA66F738B730669687E0EB369F24438C9666CBF67F096086EF05A38BF439AC55E06D2FF4374A7FDE315028B14C45985D1F4277F121E0EE3BFFEFDFF03AAAF1F2B6ECE0400, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (1, N'CPB101', N'wewework1111', N'06/10/2019', N'18/10/2019', N'09/10/2019', NULL, N'updatingfggghh', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (3, N'CPB101', N'jhkjh', N'17/10/2019', N'23/10/2019', NULL, NULL, N'SS', N'Designation', NULL, NULL, NULL, NULL, N'BB')
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (4, N'CPB101', N' cbc', N'24/10/2019', N'23/10/2019', NULL, NULL, N'CChjghjg', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (7, N'CPB102', N'lkjlkj', N'24/10/2019', N'23/10/2019', N'15/10/2019', NULL, N'fref', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (8, N'CPB102', N'hho', N'23/10/2019', N'18/10/2019', N'24/10/2019', NULL, N'yy', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (9, N'CPB102', N'dsad', N'04/10/2019', NULL, N'22/10/2019', NULL, N's', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (10, N'CPB102', N'jhkjh', N'08/10/2019', N'21/10/2019', N'29/10/2019', NULL, N'z', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (11, N'CPB102', N'cd', N'23/10/2019', N'18/10/2019', N'08/10/2019', NULL, N'x', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (13, N'CPB101', N'vbc', N'23/10/2019', N'29/10/2019', NULL, NULL, N'vg', NULL, NULL, N'Des', N'32', NULL, NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (14, N'CPB101', N'a', N'22/10/2019', N'22/10/2019', N'23/10/2019', NULL, N'd', NULL, NULL, N'Java', N'2', N'7', NULL)
INSERT [dbo].[Appointments] ([Id], [MemberId], [Title], [Date], [EffectedDate], [ToDate], [doc], [Description], [AppointmentType], [drpNameType], [DesignationType], [InstitutionType], [CommunityType], [Superior]) VALUES (16, N'CPB101', N'abc', N'22/10/2019', N'23/10/2019', N'23/10/2019', N'sumi.jpg', N'goood', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'd7a54509-d9e4-e911-a750-0c96e61585be', N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'09/10/2019', N'bv bv', NULL, NULL, NULL, NULL, NULL, N'rt', N'02/24/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'ab5e1f06-e6e4-e911-a750-0c96e61585be', N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'24/10/2019', N'dddggghhhh', NULL, NULL, NULL, NULL, NULL, N'Fcc', N'02/57/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'012a5875-10e5-e911-a750-0c96e61585be', N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'17/10/2019', N'hgytgh', NULL, NULL, NULL, NULL, NULL, N'kk', N'02/00/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'b11c81a1-15e5-e911-a750-0c96e61585be', N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'12/10/2019', N'gggggg', NULL, NULL, NULL, NULL, NULL, N'vvvv', N'02/37/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'5e6cf542-b4e5-e911-a750-0c96e61585be', N'4a31826c-39d5-e911-a747-0c96e61585be', N'16/10/2019', N'hhhh', NULL, NULL, NULL, NULL, NULL, N'ggg', N'03/33/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'd318d3ed-f3e6-e911-a752-0c96e61585be', N'3ff9382a-dce4-e911-a750-0c96e61585be', N'24/10/2019', N'aadas', NULL, NULL, NULL, NULL, NULL, N'ff', N'05/41/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'071d80fc-f3e6-e911-a752-0c96e61585be', N'745a3e8a-d0e5-e911-a750-0c96e61585be', N'25/10/2019', N'kk', NULL, NULL, NULL, NULL, NULL, N'hh', N'05/42/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'33305d08-f4e6-e911-a752-0c96e61585be', N'42a51e62-d1e5-e911-a750-0c96e61585be', N'16/10/2019', N'oo', NULL, NULL, NULL, NULL, NULL, N'll', N'05/42/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'a1271b16-f4e6-e911-a752-0c96e61585be', N'e617b898-88ae-e911-841e-2047470da27b', N'23/10/2019', N'ff', NULL, NULL, NULL, NULL, NULL, N'ccc', N'05/42/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'cb44834f-70ee-e911-a754-0c96e61585be', NULL, N'16/10/2019', N'GG', NULL, NULL, NULL, NULL, NULL, N'HH', N'14/19/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'c7261dd6-24f4-e911-8452-2047470da27b', N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'21/10/2019', N'suuuuuuuuuuuuu', N'anil.jpg', NULL, NULL, NULL, NULL, N'sumiiiiiiiiii', N'21/44/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'e40516d3-25f4-e911-8452-2047470da27b', N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'22/10/2019', N'abccccccc', N'anil.jpg', NULL, NULL, NULL, NULL, N'abs', N'21/41/2019')
INSERT [dbo].[CongDatas] ([id], [CongId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'c05c754e-28f4-e911-8452-2047470da27b', N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'23/10/2019', N'ccfffffffffff', N'anil.jpg', NULL, NULL, NULL, NULL, N'sumiiiiiiiiii', N'21/58/2019')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'5ebbab35-65db-e911-a74a-0c96e61585be', N'raj', N'jj', N'11/11/2910', N'djfzhbz hgf hg', N'hgjh', N'gjh', 22, N'sfsd')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'990fd92e-69db-e911-a74a-0c96e61585be', N'nvbn', NULL, N'03/09/2019', NULL, NULL, NULL, 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'1392a7ea-6adb-e911-a74a-0c96e61585be', N'nvbn', NULL, N'02/09/2019', NULL, NULL, NULL, 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'b17b0e37-6cdb-e911-a74a-0c96e61585be', N'Ujjain', NULL, N'06/09/2019', NULL, NULL, NULL, 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'915fccd8-6cdb-e911-a74a-0c96e61585be', N'KKK', NULL, N'01/09/2019', NULL, NULL, NULL, 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'efab94ac-8bdb-e911-a74a-0c96e61585be', N'Ujjain', NULL, N'05/09/2019', NULL, NULL, NULL, 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'aa420b24-8fdb-e911-a74a-0c96e61585be', N'yyyyyyyy', NULL, N'02/09/2019', NULL, NULL, N'Capture.PNG', 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'8a55bb15-91db-e911-a74a-0c96e61585be', N'varma', NULL, N'18/09/2019', NULL, NULL, N'Capture.PNG', 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'380e192a-91db-e911-a74a-0c96e61585be', N'archana', NULL, N'16/09/2019', NULL, NULL, N'Capture.PNG', 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'ab52f218-92db-e911-a74a-0c96e61585be', N'nvbn', N'jhkjh', N'03/09/2019', N'gftg', NULL, NULL, 0, NULL)
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'1f000575-e4db-e911-a74a-0c96e61585be', N'Ujjain', NULL, N'19/09/2019', NULL, NULL, NULL, 0, N'Paris')
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'783d1089-e4db-e911-a74a-0c96e61585be', N'fdgdcf', N' cbc', N'05/09/2019', N'gftg', NULL, NULL, 0, NULL)
INSERT [dbo].[CounCircCommis] ([id], [Name], [title], [Date], [Describtion], [Doc], [FileName], [EntryLifeId], [Type]) VALUES (N'1ea6d71d-93de-e911-a74d-0c96e61585be', N'nvbn', NULL, NULL, NULL, NULL, NULL, 0, N'Paris')
SET IDENTITY_INSERT [dbo].[DataListItems] ON 

INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3004, N'Dioceses', N'Ujjain', N'Parish priest', N'St. John', N'fdvgdf', N'bhjbhj')
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3005, N'other salary2', N'nvbn', N'Parish priest', N'kjh', N'fdvgdf', N'bhjbhj')
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3006, N'other salary', N'fc', N'bh', N'gh', N'j', N'h')
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3007, N'Designation', N'Parish Priest', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3008, N'Designation', N'Secertry', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3009, N'Designation', N'priest', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3013, N'Designation', N'Principal', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3014, N'Designation', N'Coll', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3017, N'Designation', N'Director', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3018, N'Designation', N'PRAYER SECTERY', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3019, N'Designation', N'nvbn', NULL, NULL, NULL, NULL)
INSERT [dbo].[DataListItems] ([Id], [DataListName], [Name], [Designation], [Institution], [Community], [Address]) VALUES (3020, N'Designation', N'dddddd', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DataListItems] OFF
SET IDENTITY_INSERT [dbo].[DataLists] ON 

INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (1, N'other salary')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2, N'other salary2')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (1002, N'test')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2002, N'Dioceses')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2003, N'our congress')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2004, N'other cong')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2005, N'Test')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2006, N'vermakantics123@gmail.com')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2007, N'ttttttttttt')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2008, N'uuuuuu')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2009, N'Designation')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2010, N'ttttttttttt')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2011, N'Institution')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2012, N'Community')
INSERT [dbo].[DataLists] ([Id], [Name]) VALUES (2013, N'Designation')
SET IDENTITY_INSERT [dbo].[DataLists] OFF
SET IDENTITY_INSERT [dbo].[FamilyDetails] ON 

INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (2, N'CPB003', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (3, N'CPB003', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (4, N'CPB003', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (5, N'CPB005', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (6, N'CPB005', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (7, N'CPB005', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (8, N'CPB005', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (9, N'CPB005', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (10, N'CPB005', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (11, N'CPB005', N'ygjhg', N'jh', N'gjh', N'g', N'jh', N'gjh@gmail.com', N'g', N'gjh')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (12, N'MEM12', N'jh', N'kj', N'hkj', N'h', N'kj', N'hkj@gmail.com', N'h', N'9585848448')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (14, N'CPB102', N'nvbn', N'nhbn12', N'56', N'5656', N'6878980990', N'vermakanti@gmail.com', N'jmnm njk,  k jk hgcvh vghvghjvgjghjgh', NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (15, N'CPB103', N'nvbn', N'nhbn', N'56', N'5656', N'6878980990', N'vermakanti@gmail.com', N'dc vxxxxv', NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (17, N'CPB102', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (18, N'CPB106', N' bbv', N'nhbn', N'ttt', N'5656', N'6878980990', N'vermakanti@gmail.com', N'gb cb', NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (19, N'CPB102', N'rtrt', NULL, NULL, NULL, N'6556767', N'vermakantics@gmail.com', N'cbv', NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (20, N'CPB101', N'deatils1', N'swad1', N'2012', N'5656', N'435', N'vermakantics@gmail.com', N'cbv1', N'43545555')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (23, N'CPB101', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (25, NULL, N'gfg g', N'bgb', N'56', N'5656', N'6556767', N'vermakantics@gmail.com', N'cbv', NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (26, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (28, N'CPB101', N'shivi', N'dfgfd', N'fgfg', N'fgdgdf', N'fgdfd', N'fgdfgd@gmail.com', N'fghgfh', N'dfg65656')
INSERT [dbo].[FamilyDetails] ([Id], [MemberId], [Name], [Relationship], [YearOfBirth], [YearOfDeath], [Mobile], [Email], [Address], [EmergencyContact]) VALUES (29, N'CPB101', N'ddd', N'ddddd', N'2000', N'2019', N'53254', N'dddddd@gmail.com', N'dddddddd', NULL)
SET IDENTITY_INSERT [dbo].[FamilyDetails] OFF
SET IDENTITY_INSERT [dbo].[Sacraments] ON 

INSERT [dbo].[Sacraments] ([Id], [Title], [Sacrament], [Minister], [Date], [ChurchName], [Remarks], [MemberId]) VALUES (3, N'gbcfd', NULL, N'f', NULL, N'gfb', N'gbv', N'CPB102')
INSERT [dbo].[Sacraments] ([Id], [Title], [Sacrament], [Minister], [Date], [ChurchName], [Remarks], [MemberId]) VALUES (9, N'cf', NULL, N'bfvb', N'07/10/2019', N'ff', N'fvfcv', NULL)
INSERT [dbo].[Sacraments] ([Id], [Title], [Sacrament], [Minister], [Date], [ChurchName], [Remarks], [MemberId]) VALUES (19, N'dddd111', NULL, N'cccc11', N'23/10/2019', N'gggggg1111', N'vvvvvvvv', N'CPB101')
SET IDENTITY_INSERT [dbo].[Sacraments] OFF
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'88e73320-67db-e911-a74a-0c96e61585be', N'1', N'11/09/2019', N'ljljljlj', NULL, NULL, NULL, NULL, NULL, N'ljljlj', N'20/55/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'f81671cf-6ddb-e911-a74a-0c96e61585be', N'2', N'02/09/2019', N' GF', NULL, NULL, NULL, NULL, NULL, N'HGTH', N'20/43/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'683a5820-7ae3-e911-a750-0c96e61585be', N'1', N'05/09/2019', N'fdbhghkgvfhkvb', NULL, NULL, NULL, NULL, NULL, N'rentel ', N'30/32/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'71db3d30-7ae3-e911-a750-0c96e61585be', N'1', N'18/09/2019', N'fdbhgchj', NULL, NULL, NULL, NULL, NULL, N'Tax', N'30/32/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'b4a75341-bbe5-e911-a750-0c96e61585be', N'2', N'14/10/2019', N'ddd', NULL, NULL, NULL, NULL, NULL, N'ss', N'03/23/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'fbb3fd49-bbe5-e911-a750-0c96e61585be', N'2', N'21/10/2019', N' fc ', NULL, NULL, NULL, NULL, NULL, N'jjj', N'03/23/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'22562154-bbe5-e911-a750-0c96e61585be', N'3', N'29/10/2019', N'cf fcv', NULL, NULL, NULL, NULL, NULL, N'gg', N'03/23/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'00a535a3-bbe5-e911-a750-0c96e61585be', N'6', N'14/10/2019', N'ff', NULL, NULL, NULL, NULL, NULL, N'ttttt', N'03/26/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'8abe660c-45ef-e911-a754-0c96e61585be', N'2', N'15/10/2019', N'tttt', NULL, NULL, NULL, NULL, NULL, N'ttttt', N'15/42/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'5176ccf1-9bfd-e911-9a21-10bf480486d4', N'1005', N'07/11/2019', N'sdfsdf sdfdsfsdfsd', N'bg-3.jpg', NULL, NULL, NULL, NULL, N'sub socier', N'02/39/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'728816af-66fe-e911-9a21-10bf480486d4', N'1005', N'14/11/2019', N'sdf kjgh fdkjghdjfk hkj', N'bg-3.jpg', NULL, NULL, NULL, NULL, N'sub society 2', N'03/50/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'32636787-14f4-e911-8452-2047470da27b', N'5', N'10/10/2019', N'dddddddddddddddddddfff', NULL, NULL, NULL, NULL, NULL, N'fgfg', N'21/37/2019')
INSERT [dbo].[SocietyDatas] ([id], [SocId], [Date], [Description], [File1], [File2], [File3], [File4], [File5], [other1], [CreatedDate]) VALUES (N'd0331734-19f4-e911-8452-2047470da27b', N'5', N'22/10/2019', N'vvdjjsksddddddd', N'anil.jpg', NULL, NULL, NULL, NULL, N'hjjjkkffff', N'21/08/2019')
SET IDENTITY_INSERT [dbo].[Societys] ON 

INSERT [dbo].[Societys] ([Id], [MemberId], [PanNumber], [NameOfTheSocity], [FCRANumber], [Date], [Number12A], [RegistrationNumber], [Number80G], [Address], [Telno], [Email], [Website]) VALUES (5, NULL, N'7789999', N'nhvgnggggggggggggg', N'98978899', NULL, N'88888888', N'54455456666', N'77777777', NULL, NULL, NULL, NULL)
INSERT [dbo].[Societys] ([Id], [MemberId], [PanNumber], [NameOfTheSocity], [FCRANumber], [Date], [Number12A], [RegistrationNumber], [Number80G], [Address], [Telno], [Email], [Website]) VALUES (8, NULL, N'324', N'society', N'788', N'13/10/2004', N'897', N'544554', N'77', NULL, NULL, NULL, NULL)
INSERT [dbo].[Societys] ([Id], [MemberId], [PanNumber], [NameOfTheSocity], [FCRANumber], [Date], [Number12A], [RegistrationNumber], [Number80G], [Address], [Telno], [Email], [Website]) VALUES (1005, NULL, N'233', N'name scoeruty', N'32423', NULL, N'12312', N'1234', N'803', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Societys] OFF
SET IDENTITY_INSERT [dbo].[tbl_Academy] ON 

INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc], [MemberId]) VALUES (1, N'hnkk', N'bnhhjj', N'kmjjkk', N'kmmkkj', N'03/09/2019', NULL, N'kkk', N'yhtt', N'cbv', N'43988', NULL, N'CPB101')
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc], [MemberId]) VALUES (2, N'ee', N'rr', N'ee', N'r', N'15/10/2019', N'10/10/2019', N'ff', N'ff', N'g', N'44', NULL, N'CPB102')
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc], [MemberId]) VALUES (3, N'abc1', N'abc1', N'abc1', N'abccc1', N'22/10/2019', NULL, N'abc1', N'abc1', N'abc1', N'abc1', N'sumi.jpg', N'CPB101')
SET IDENTITY_INSERT [dbo].[tbl_Academy] OFF
SET IDENTITY_INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ON 

INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ([CommunityId], [CommunityName], [EstablishDate], [Place], [Address], [ContactNumber], [Website], [File]) VALUES (5, N'huii', NULL, N'hjkioo', N'gfttyyu', N'4589654', NULL, NULL)
INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ([CommunityId], [CommunityName], [EstablishDate], [Place], [Address], [ContactNumber], [Website], [File]) VALUES (6, N'Nirmala Convent', NULL, N'Rajgarh', N'PremNagar', N'23651248', NULL, NULL)
INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ([CommunityId], [CommunityName], [EstablishDate], [Place], [Address], [ContactNumber], [Website], [File]) VALUES (7, N'St mary Convent', NULL, N'Indore', N'vijayanagar', NULL, NULL, NULL)
INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ([CommunityId], [CommunityName], [EstablishDate], [Place], [Address], [ContactNumber], [Website], [File]) VALUES (12, N'Shivi', NULL, N'Indore', N'Ujjain', NULL, NULL, NULL)
INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ([CommunityId], [CommunityName], [EstablishDate], [Place], [Address], [ContactNumber], [Website], [File]) VALUES (13, N'fdfdx', NULL, N'vfdfg', N'xdvfxd', NULL, NULL, NULL)
INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ([CommunityId], [CommunityName], [EstablishDate], [Place], [Address], [ContactNumber], [Website], [File]) VALUES (16, N'community', NULL, N'Indore', N'ujjain', N'2345', NULL, NULL)
INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] ([CommunityId], [CommunityName], [EstablishDate], [Place], [Address], [ContactNumber], [Website], [File]) VALUES (17, N'htyh', NULL, N'gyhgh', N'ghfnjghj', N'hgjh', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_CommunitiesSocialCentresDoc] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Complains] ON 

INSERT [dbo].[Tbl_Complains] ([Id], [Date], [Title], [Discription], [NatureofTheComplaint], [ComplaintReceived], [Decision], [InvolvedIn], [FileName], [MemberId], [MemberName]) VALUES (1, NULL, N'ssumiyyyy', N'njjkkk', N'njjjbghju', N'nbhgyuuu', N'kioo', N'rah rajput', NULL, N'CPB101', N'rah rajput')
INSERT [dbo].[Tbl_Complains] ([Id], [Date], [Title], [Discription], [NatureofTheComplaint], [ComplaintReceived], [Decision], [InvolvedIn], [FileName], [MemberId], [MemberName]) VALUES (2, NULL, N'abc', N'abc', N'abc', N'abc', N'abcc', N'rah rajput', N'sumi.jpg', N'CPB101', N'rah rajput')
SET IDENTITY_INSERT [dbo].[Tbl_Complains] OFF
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'be8a5b63-2cbf-e911-a737-0c96e61585be', N'vghnvb', N'bgjhnbh', N' jmbh', N'bhh', N'15/44/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'4a31826c-39d5-e911-a747-0c96e61585be', N'bbbbbbbbbb', N'ccccccccccc', N'zzzzzzzzzz', N'4345', N'12/13/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'3ff9382a-dce4-e911-a750-0c96e61585be', N'SABS', N'UJJAIN', N'Agar Road', N'6556767', N'02/46/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'745a3e8a-d0e5-e911-a750-0c96e61585be', N'fdrf', N'f', N'cbv', N'6556767', N'03/55/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'42a51e62-d1e5-e911-a750-0c96e61585be', N'ttt', N'ggg', N'jjj', N'5435654', N'03/01/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'7aaf308b-ffeb-e911-a754-0c96e61585be', N'SABS', N'Ujjain', N'nav jyoti', N'43434543', N'11/47/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'b8bcc5df-ffeb-e911-a754-0c96e61585be', N'cmc', N'ff', N'ffg b', N'7676', N'11/49/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'aa6eb127-00ec-e911-a754-0c96e61585be', N'dd', N'd', N'dd', N'5456667', N'11/51/2019')
INSERT [dbo].[Tbl_Cong] ([Id], [CongregationName], [Place], [Address], [Phone], [CreatedDate]) VALUES (N'e617b898-88ae-e911-841e-2047470da27b', N'Cong Name1', N'con place2', N'cong address3', N'586786786', N'02/03/2019')
SET IDENTITY_INSERT [dbo].[tbl_FinancialGuidelineDoc] ON 

INSERT [dbo].[tbl_FinancialGuidelineDoc] ([FinancialDocId], [DoccumentName], [Title], [Date], [Phonenumber], [Address], [Email], [File], [Photo]) VALUES (5, N'WRHWHg', N'WEHRDH', N'02/01/2019', N'35435346346', N'DHHDS', N'DHHDS', N'10cf5830-3f72-4eb2-808c-c6b02cbae8bf.png', N'c6736b1d-6031-4250-ac0c-24b588edc561.png')
SET IDENTITY_INSERT [dbo].[tbl_FinancialGuidelineDoc] OFF
SET IDENTITY_INSERT [dbo].[Tbl_formationsDetails] ON 

INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1, N'1', N'sfsdfsdf', N'sdfsdfs22', N'fsdf', N'kj', N'hkj', N'h', N'kj ', N'h', N'jkh', N'hjk', N'CPB003', N'jkhkjh', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2, N'4', N'sdfsd', N'h', N'g', N'jh', N'gjh', N'g', N'jhg ', N'jh', N'g', N'jhg', N'CPB003', N'jhghj', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (4, N'1', N'22/11/2019', N'Joing CSC Title', N'jiwali university Gwalior', NULL, NULL, NULL, NULL, NULL, NULL, N'Vocation Facilitotor ', N'CPB003', N'Description text', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (6, N'5', N'sfdfgfdg', N'dfgfdg', N'dgdfgdf', N'gfdgfdg', N'fdgdfgd', NULL, NULL, NULL, NULL, NULL, N'CPB003', N'gdfgdfg', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1006, N'1', N'11/12/2019', N'title dkfj k k', N'kjdfk jf skdfj skf', NULL, NULL, NULL, N' ', NULL, NULL, N'sdkfj skfsd fks', N'CPB003', N'xgffdg gdfgdfg', N'Bac1.jpeg')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1008, N'1', NULL, N'sdfkjhkjh', N'kj', NULL, NULL, NULL, N' ', NULL, NULL, N'hjk', N'CPB003', N'h', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1009, N'7', NULL, N'serfre', NULL, NULL, NULL, NULL, N'erter tert rt ertert', NULL, N'ert ertert ert ', NULL, NULL, N'er tertert erte', N'anil.jpg')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1010, N'1', N'24/07/2019', N'kjhkj', N'hkj', NULL, NULL, NULL, N' ', NULL, NULL, N'hkj', NULL, N'kjh', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1011, N'1', NULL, N'sdfsdfdsfsdfs', N'fsdfsdfsdfsdf', NULL, NULL, NULL, N' ', NULL, NULL, N'sfdsdf', NULL, N'sdfsdf', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1012, N'1', N'17/07/2019', N'sdfsdfsdf', N'sdfsdfsdf', NULL, NULL, NULL, N' ', NULL, NULL, N'sdfsdf', NULL, N'sdfsdfsdfsdfsd', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1013, N'1', N'17/07/2019', N'sdfsdfsdf', N'sdfsdfsdf', NULL, NULL, NULL, N' ', NULL, NULL, N'sdfsdf', NULL, N'sdfsdfsdfsdfsd', N'anil.jpg')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (1014, N'1', N'17/07/2019', N'kjhk', N'jhkj', NULL, NULL, NULL, N' ', NULL, NULL, N'hkj', NULL, N'hk', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2009, N'1', N'17/07/2019', N'khgkj', N'hkjh', NULL, NULL, NULL, NULL, NULL, NULL, N'kj', N'MEM12', N'kjhsdfdskjh', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2010, N'3', N'03/09/2019', N'hh', N'jj', NULL, N'kk', N'll', NULL, NULL, NULL, NULL, N'CPB103', N'gfhfv', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2011, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CPB103', NULL, NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2012, N'3', NULL, N' cbc', N'kjh', N'op[', N'ddd', NULL, NULL, NULL, NULL, NULL, N'CPB102', NULL, NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2013, N'1', N'01/09/2019', N'aa', N'ff', NULL, NULL, NULL, NULL, NULL, NULL, N'gg', N'CPB102', N'hh', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2014, N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CPB102', NULL, NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2015, N'1', NULL, NULL, NULL, NULL, NULL, NULL, N' ', NULL, NULL, NULL, N'CPB102', NULL, NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2016, N'1', NULL, NULL, NULL, NULL, NULL, NULL, N' ', NULL, NULL, NULL, N'CPB103', NULL, NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2017, N'4', NULL, N'jhkjh', NULL, NULL, NULL, NULL, N'gn vn', N'nhmjh', NULL, NULL, N'CPB106', N'nmj', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2019, N'6', N'09/10/2019', N'mnmnmbhhj', NULL, NULL, NULL, NULL, N'jghfdfdsfd', N'mmhnjj', NULL, NULL, N'CPB101', N'asdfghhfdszdxf', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2020, N'5', NULL, N'uuuuuuuuuuuuu', N'ii', N'ii', N'p', NULL, NULL, NULL, NULL, NULL, N'CPB101', NULL, NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2021, N'1', N'04/09/2019', N'dsa', N'xs', NULL, NULL, NULL, N' ', NULL, NULL, N'xs', N'CPB101', N'sds', N'Capture.PNG')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2022, N'1', NULL, NULL, NULL, NULL, NULL, NULL, N' ', NULL, NULL, NULL, N'CPB101', N'cxdddfffffffffffffffffggg
xcd  bvbvb     gbvc bvxcvbgnhvgn vbhgnj', NULL)
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2023, N'4', N'22/10/2019', N'abc', NULL, NULL, NULL, NULL, N'abc', N'abc', NULL, NULL, N'CPB101', N'nice look', N'sumi2.jpg')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [MemberId], [Description], [FileName]) VALUES (2024, N'4', N'22/10/2019', N'abc1', NULL, NULL, NULL, NULL, N'abc1', N'abc1', NULL, NULL, N'CPB101', N'nice look1', NULL)
SET IDENTITY_INSERT [dbo].[Tbl_formationsDetails] OFF
SET IDENTITY_INSERT [dbo].[Tbl_FormationTypes] ON 

INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (1, N'Joining CSC')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (2, N'Pre-novitiate')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (3, N'Novitiate')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (4, N'First profession')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (5, N'Post novitiate')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (6, N'Per p. profession')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (7, N'Diaconate ordination')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (8, N'Diaconate ministry')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (9, N'Priestly Ordination')
INSERT [dbo].[Tbl_FormationTypes] ([Id], [FortmationType]) VALUES (10, N'Other Enries')
SET IDENTITY_INSERT [dbo].[Tbl_FormationTypes] OFF
SET IDENTITY_INSERT [dbo].[tbl_FundRaisingCommiteeDoc] ON 

INSERT [dbo].[tbl_FundRaisingCommiteeDoc] ([FundRaisingId], [DoccumentName], [Title], [Date], [File]) VALUES (2, N'WSH', N'SH', N'01/01/2019', N'4b54baf1-3c71-4342-914f-6f4d1ddf263a.png')
SET IDENTITY_INSERT [dbo].[tbl_FundRaisingCommiteeDoc] OFF
SET IDENTITY_INSERT [dbo].[tbl_Health] ON 

INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName], [Title], [Description], [CreatedDate]) VALUES (3, N'CPB101', N'rah', N'dfghsss', NULL, NULL, N'werty', N'amiis', N'xcvbh', N'sumi.jpg', NULL, NULL, NULL, N'ty yfrtcss', NULL, N'23/32/2019')
INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName], [Title], [Description], [CreatedDate]) VALUES (4, NULL, NULL, N'gh', N'08/10/2019', N'08/10/2019', N'jj', N'jj', N'hh', NULL, NULL, N'Directory-Indore-2019.pdf', NULL, N'tgfrg', N'ttoop', N'17/50/2019')
INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName], [Title], [Description], [CreatedDate]) VALUES (5, NULL, NULL, N'gdhgyj', N'09/10/2019', N'08/10/2019', N'ghjhj', N'hjhjk', N'ghjhj', NULL, NULL, N'Directory-Indore-2019.pdf', NULL, N'yhyuhjj', N'jhkhjkj', N'17/57/2019')
INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName], [Title], [Description], [CreatedDate]) VALUES (6, NULL, NULL, N'kj', N'16/10/2019', N'05/10/2019', N'jyhj', N'jyu', N'cfbgcf', NULL, NULL, N'Directory-Indore-2019.pdf', NULL, N'fgfg', N'gfhghh', N'17/58/2019')
INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName], [Title], [Description], [CreatedDate]) VALUES (7, N'CPB101', N'rah', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'17/14/2019')
INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName], [Title], [Description], [CreatedDate]) VALUES (8, N'CPB101', N'rah', N'cfvb', N'09/10/2019', N'09/10/2019', N'bc', N'b', N'cvb', NULL, NULL, N'Directory-Indore-2019.pdf', NULL, N'fxdf', N'bvbb', N'17/15/2019')
INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName], [Title], [Description], [CreatedDate]) VALUES (9, N'CPB101', N'rah', N'dddddd', NULL, NULL, N'bbbbbbbbbbbb', N'cvb', N'vvvvv', N'sumi.jpg', NULL, NULL, NULL, N'abc', NULL, N'23/30/2019')
SET IDENTITY_INSERT [dbo].[tbl_Health] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Institution] ON 

INSERT [dbo].[Tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (2008, N'lucd629538', N'lkjh', N'ins', N'esfiukjh', N'lkj', N'ins 33', N'10/10/2019', N'sdfjk h22v', NULL, NULL, NULL)
INSERT [dbo].[Tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (2009, N'lucd629538', N'lkjh', N'ins', N'esfiukjh', N'lkj', N'ins sub 2', N'20/11/2019', N'wewewe wewewe', N'download (1).jpg', N'03/51/2019', NULL)
INSERT [dbo].[Tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (2010, N'lucd629538', N'lkjh', N'ins', N'esfiukjh', N'lkj', N'zzzz', N'15/11/2019', N'arf sfsfsfsdfsd', N'download (1).jpg', N'03/46/2019', NULL)
SET IDENTITY_INSERT [dbo].[Tbl_Institution] OFF
SET IDENTITY_INSERT [dbo].[tbl_institution123] ON 

INSERT [dbo].[tbl_institution123] ([InstitutionId], [MemberID], [FromDate], [Closingdate], [NameOfInstitution], [TypeOfInstitution], [NameOfDiocese], [OwenedBy], [MaintainedBy], [Address], [Telephone], [EmailID], [WebSite], [spare1], [Spare2]) VALUES (1, NULL, N'safsdfsfdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_institution123] ([InstitutionId], [MemberID], [FromDate], [Closingdate], [NameOfInstitution], [TypeOfInstitution], [NameOfDiocese], [OwenedBy], [MaintainedBy], [Address], [Telephone], [EmailID], [WebSite], [spare1], [Spare2]) VALUES (2, NULL, N'y', N'y', N'y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_institution123] OFF
SET IDENTITY_INSERT [dbo].[Tbl_LandDocuments] ON 

INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (2, NULL, N'Pucd35860', N'RajeshParis', N'hkjg', N'khg', N'hg', N'jh', N'gj', N'gjhg', N'2bddbe83-7d2e-4e51-b0c7-14a9c9fa2d99 (1).jpg', N'pexels-photo-132472.jpeg', N'pexels-photo-268832.jpeg', N'pexels-photo-132472.jpeg', N'WhatsApp Image 2019-03-24 at 10.50.59 PM.jpeg', N'07/06/2019', N'20193', N'sttree', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (3, NULL, N'Pucd35860', N'RajeshParis', N'Field', N'sdfhkg', N'kjh', N'kj', N'hjk', N'h', NULL, NULL, NULL, NULL, NULL, NULL, N'555', N'hkj', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (4, N'Institution', N'lucd62780', N'RajeshIns', N'kj', N'hkjh', N'kj', N'hkjh', N'kjh', N'kjh', N'pexels-photo-268832.jpeg', N'pexels-photo-459277.jpeg', N'pexels-photo-459277.jpeg', N'pexels-photo-459277.jpeg', N'WhatsApp Image 2019-03-24 at 10.50.59 PM.jpeg', N'07/06/2019', N'2022', N'kjh', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (5, N'Institution', N'lucd62780', N'RajeshIns', N'jh', N'g', N'jhg', N'jh', N'g', N'gjh', NULL, NULL, NULL, NULL, NULL, N'07/06/2019', N'4343', N'jh', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (6, N'Institution', N'lucd62780', N'RajeshIns', N'kjhk', N'jhkj', N'hk', N'jh', N'jkh', N'kj', N'Bac1.jpeg', N'Bac1.jpeg', N'Bac1.jpeg', N'Bac1.jpeg', N'Bac1.jpeg', N'07/06/2019', N'5050', N'kjh', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1003, N'Paris', N'Pucd35860', N'RajeshParis', N'gj', N'hg', N'jh', N'g', N'jh', N'g', NULL, NULL, NULL, NULL, NULL, N'08/06/2019', N'jhgjg', N'ghj', N'jh')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1004, N'Paris', N'Pucd5994', N'TestParis', N'fhgf', N'gdf', N'f', N'gd', N'g', N'fgf', NULL, NULL, NULL, NULL, NULL, N'08/06/2019', N'fgf', N'gd', N'sf')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1005, N'Institution', N'lucd7624', N'testINst', N'sdg', N'sfg', N'sdg', N'dsg', N'fdg', N'sdf', NULL, NULL, NULL, NULL, NULL, N'08/06/2019', N'zcxfdgfd', N'dsg', N'gfgf')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1006, N'Institution', N'lucd7624', N'testINst', N'Document category', N'Sub Category', N'Khasara', N'Survey ', N'date', N'description', NULL, NULL, NULL, NULL, NULL, N'08/06/2019', N'2011', N'place', N'Tital')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1007, N'Paris', N'Pucd19746', N'RajehParis', N'hkj', N'hkj', N'hkj', N'hkj', NULL, N'hkj', NULL, NULL, NULL, NULL, N'anil.jpg', N'25/07/2019', N'kjhkjhkj', N'hkj', N'hkj')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1008, N'Paris', N'Pucd905530', N'uuuuu', N'rt', N'rt', N't', N'44', N'16/10/2019', N'gg54rtegfgfgfgfgfgfgfgfgbbbbbbbbbbbb', NULL, NULL, NULL, NULL, NULL, N'01/10/2019', N'2012', NULL, N'gbb')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1009, N'Paris', N'Pucd988386276906', N'xx', N'asddfff', N'cfg3445', N'sdfg', N'11111111', N'25/10/2019', N'ssdd', N'Happy-Diwali-Wallpapers-Mega-Collection.jpg', N'dp3.png', N'Diwali-Photo-Frames.jpg', NULL, N'dp2.jpg', N'25/10/2019', N'2015', N'dfghj', N'dsajd hkajsd h')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (1010, N'Paris', N'Pucd988386276906', N'xx', N'testing', N'sub category', N'khasra', N'123456', NULL, N'desd hfhjfj hfjgf', N'78869.jpg', N'B.A. B.Sc. B.COM  (COMPUTER  APPLICATION) EXAM 2017.pdf', N'back_repeat.jpg', N'download (2).jpg', N'download.jpg', N'27/10/2019', N'2019', N'1234place', N'134567')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (2003, N'Institution', N'lucd471114', N'jhgjh', N'jh', N'kj', N'hkjl', N'h', NULL, N'ljh', NULL, NULL, NULL, NULL, NULL, N'27/10/2019', N'drtgdiu', N'hk', N'lkjh')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (2004, N'Institution', N'lucd629538', N'ins demo', N'testing', N'kjhjkhk', N'jhjhkjh', N'kjh', NULL, N'kjhkjhkj', NULL, NULL, NULL, NULL, NULL, N'27/10/2019', N'2019', N'kjh', N'hkjh')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [CreatedDate], [Year], [Place], [Tital]) VALUES (2005, N'Paris', N'Pucd988386941035', N'paris demo', N'jhg', N'hjg', N'jhg', N'jhg', N'20/11/2019', N'gj', NULL, NULL, NULL, NULL, NULL, N'02/11/2019', N'sjfhghjg', N'gjh', N'hg')
SET IDENTITY_INSERT [dbo].[Tbl_LandDocuments] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Paris] ON 

INSERT [dbo].[Tbl_Paris] ([Id], [MyId], [YearOfEstablacement], [ParisName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate]) VALUES (1001, N'Pucd988386941035', N'gj', N'paris demo', N'ujhgkjh', N'hghjg', N'paris 1', N'16/10/2019', N'sadf sgdfgdfg', N'download (1).jpg', N'27/10/2019')
INSERT [dbo].[Tbl_Paris] ([Id], [MyId], [YearOfEstablacement], [ParisName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate]) VALUES (1002, N'Pucd988386941035', N'gj', N'paris demo', N'ujhgkjh', N'hghjg', N'sub paris 22', N'13/11/2019', N'sedrfgthyj edfhg dfghv', N'78869.jpg', N'03/11/2019')
SET IDENTITY_INSERT [dbo].[Tbl_Paris] OFF
SET IDENTITY_INSERT [dbo].[Tbl_ParisInstitutionDetails] ON 

INSERT [dbo].[Tbl_ParisInstitutionDetails] ([Id], [MyId], [Name], [Place], [Type], [YearOfEstablacement], [Address], [FileName], [ParisId], [SocietyId], [Telephone], [InstitutionType], [RegistrationNo], [DiscCode], [TypeCode], [RegIdCode], [BEORegCode], [CertificationCode], [OtherDoc], [Doc1], [Doc2], [CreatedDate], [Tial], [Date], [Description]) VALUES (1024, N'Pucd988386941035', N'paris demo', N'ujhgkjh', N'Paris', N'gj', N'hghjg', NULL, NULL, NULL, N'gkjh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'27/40/2019', NULL, NULL, NULL)
INSERT [dbo].[Tbl_ParisInstitutionDetails] ([Id], [MyId], [Name], [Place], [Type], [YearOfEstablacement], [Address], [FileName], [ParisId], [SocietyId], [Telephone], [InstitutionType], [RegistrationNo], [DiscCode], [TypeCode], [RegIdCode], [BEORegCode], [CertificationCode], [OtherDoc], [Doc1], [Doc2], [CreatedDate], [Tial], [Date], [Description]) VALUES (1025, N'lucd629538', N'ins demo', N'esfiukjh', N'Institution', N'lkjh', N'lkj', NULL, N'Pucd988386941035', N'5', N'h', N'School', N'jklh', N'jk', N'h', N'jk', N'h', N'jklhkj', NULL, NULL, NULL, N'27/41/2019', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_ParisInstitutionDetails] OFF
SET IDENTITY_INSERT [dbo].[tbl_Passed] ON 

INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [DeathCertificate], [obituary], [Spare1], [Spare2], [Spare3], [SirName], [Description], [Title]) VALUES (1, N'CPB101', N'rah', N'dfff', N'dddddd', N'06/09/2019', NULL, NULL, NULL, NULL, N'System.Web.HttpPostedFileWrapper', N'System.Web.HttpPostedFileWrapper', N'socail.jpg', NULL, NULL, N'rajput', N'efres', N'ssssss')
INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [DeathCertificate], [obituary], [Spare1], [Spare2], [Spare3], [SirName], [Description], [Title]) VALUES (2, N'CPB101', N'rah', NULL, NULL, N'04/09/2019', N'gt', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Capture.PNG', N'rajput', N'gth', N'gf')
INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [DeathCertificate], [obituary], [Spare1], [Spare2], [Spare3], [SirName], [Description], [Title]) VALUES (3, N'CPB101', N'rah', NULL, NULL, N'02/10/2019', N'c', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'rajput', N'v', N'fd')
INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [DeathCertificate], [obituary], [Spare1], [Spare2], [Spare3], [SirName], [Description], [Title]) VALUES (4, N'CPB101', N'AAAA', N'FFDGF', N'xcxv', N'09/10/2019', N'fgc', N'ghg', N'xvx', N'xv', NULL, N'fg', NULL, NULL, N'Directory-Indore-2019.pdf', N'SSS', N'fvxdvfdfgb', N'vbv ')
INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [DeathCertificate], [obituary], [Spare1], [Spare2], [Spare3], [SirName], [Description], [Title]) VALUES (5, N'CPB101', N'shivi', N'Hindu', N'nil', N'02/10/2019', N'3', N'dxd', N'dxdfcdd', N'xdcxdc', N'System.Web.HttpPostedFileWrapper', N'xdc', NULL, NULL, N'Directory-Indore-2019.pdf', N'padihar', N'xddc', N'nil')
INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [DeathCertificate], [obituary], [Spare1], [Spare2], [Spare3], [SirName], [Description], [Title]) VALUES (6, N'CPB101', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [DeathCertificate], [obituary], [Spare1], [Spare2], [Spare3], [SirName], [Description], [Title]) VALUES (7, N'CPB101', N'fgfgh', N'ghjhgj', N'ghfjhg', N'05/09/2019', N'03:45', N'nmmnb', N'nmbmn', N'nbm', N'System.Web.HttpPostedFileWrapper', N'mnn', NULL, NULL, N'Directory-Indore-2019.pdf', N'fghgh', N'nbmmbn', N'ghjgh')
SET IDENTITY_INSERT [dbo].[tbl_Passed] OFF
SET IDENTITY_INSERT [dbo].[tbl_PersonalDetails] ON 

INSERT [dbo].[tbl_PersonalDetails] ([MemberID], [PersonalDetailsId], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [Mobile], [BloodGroup], [DOB], [FeastDays], [VillageTown], [District], [State], [Country], [Pincode], [AadharNo], [NameasinAadharCard], [FatherName], [FMobile], [MotherName], [MMobile], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Spare1], [Spare2], [Spare3], [Parish1], [FBaptism], [MBaptism], [Will], [IsDeleted]) VALUES (N'CPB101', 1, N'rah', NULL, NULL, N'rajput', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([MemberID], [PersonalDetailsId], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [Mobile], [BloodGroup], [DOB], [FeastDays], [VillageTown], [District], [State], [Country], [Pincode], [AadharNo], [NameasinAadharCard], [FatherName], [FMobile], [MotherName], [MMobile], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Spare1], [Spare2], [Spare3], [Parish1], [FBaptism], [MBaptism], [Will], [IsDeleted]) VALUES (N'CPB102', 2, N'loi', NULL, NULL, N'kjjjkk', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([MemberID], [PersonalDetailsId], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [Mobile], [BloodGroup], [DOB], [FeastDays], [VillageTown], [District], [State], [Country], [Pincode], [AadharNo], [NameasinAadharCard], [FatherName], [FMobile], [MotherName], [MMobile], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Spare1], [Spare2], [Spare3], [Parish1], [FBaptism], [MBaptism], [Will], [IsDeleted]) VALUES (N'CPB103', 3, N'yyyyyy', NULL, NULL, N'mnjb ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[tbl_PersonalDetails] OFF
SET IDENTITY_INSERT [dbo].[tbl_Primarydetails] ON 

INSERT [dbo].[tbl_Primarydetails] ([Primaryid], [MemberId], [Knowname], [Baptismialname], [DOB], [DOB1], [Feastday], [Bloodgroup], [emailid], [mobilenumber], [placeofbirth], [noofbrother], [noofsisters], [placeinfamily], [homediocese], [homeparish], [house], [city], [district], [state], [pin], [adhar], [pan], [passport], [nameonadhar], [nameonpan], [nameonpassport], [File1], [File2], [File3], [Ordination], [UploadPhoto], [country], [mothertounge]) VALUES (16, N'CPB101', N'primary11', N'Details', N'02/10/2019', NULL, N'18 MAY', N'A++', N'a@gmail.com', N'476879', NULL, NULL, NULL, NULL, NULL, NULL, N'barnagar', N'ujjain', N'ujjain', N'madhya pradesh', N'456771', N'343456', N'654655', N'4654', N'Primary Aadhar', N'Primary Pan', N'Primary Passport', NULL, NULL, NULL, N'16/10/2019', NULL, NULL, NULL)
INSERT [dbo].[tbl_Primarydetails] ([Primaryid], [MemberId], [Knowname], [Baptismialname], [DOB], [DOB1], [Feastday], [Bloodgroup], [emailid], [mobilenumber], [placeofbirth], [noofbrother], [noofsisters], [placeinfamily], [homediocese], [homeparish], [house], [city], [district], [state], [pin], [adhar], [pan], [passport], [nameonadhar], [nameonpan], [nameonpassport], [File1], [File2], [File3], [Ordination], [UploadPhoto], [country], [mothertounge]) VALUES (17, N'CPB101', N'primary22', N'Details', N'02/10/2019', NULL, N'18 MAY', N'A++', N'a@gmail.com', N'476879', NULL, NULL, NULL, NULL, NULL, NULL, N'barnagar', N'ujjain', N'ujjain', N'madhya pradesh', N'456771', N'343456', N'654655', N'4654', N'Primary Aadhar', N'Primary Pan', N'Primary Passport', NULL, NULL, NULL, N'16/10/2019', NULL, NULL, NULL)
INSERT [dbo].[tbl_Primarydetails] ([Primaryid], [MemberId], [Knowname], [Baptismialname], [DOB], [DOB1], [Feastday], [Bloodgroup], [emailid], [mobilenumber], [placeofbirth], [noofbrother], [noofsisters], [placeinfamily], [homediocese], [homeparish], [house], [city], [district], [state], [pin], [adhar], [pan], [passport], [nameonadhar], [nameonpan], [nameonpassport], [File1], [File2], [File3], [Ordination], [UploadPhoto], [country], [mothertounge]) VALUES (18, N'CPB101', N'acb', N'cd', N'07/10/2015', NULL, N'18 MAY', N'b', N'fgh@gmail.com', N'325698', N'cvb', N'2', N'2', N'5', N'ddd', N'sdf', N'cc', N'dd', N'dd', N'ddd', N'213654', N'343456', N'545555', N'4654', N'dddd', N'sssss', N'ddddddd', N'shr.jpg', N'rahul_shravan.jpg', N'System.Web.HttpPostedFileWrapper', N'16/10/2019', N'sumi.jpg', N'dddddd', N'english')
SET IDENTITY_INSERT [dbo].[tbl_Primarydetails] OFF
SET IDENTITY_INSERT [dbo].[tbl_SeperationFromTheCongregation] ON 

INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (1, N'CPB101', N'rah', NULL, N'dsa', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (2, N'CPB101', N'rah', NULL, N'jgvh', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (3, N'CPB101', N'rah', NULL, N'dcf', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (4, N'CPB101', N'rah', NULL, N'ee', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (5, N'CPB101', N'rah', NULL, N'frdf', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (6, N'CPB101', N'rah', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (7, N'CPB101', N'rah', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (8, N'CPB101', N'rah', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (9, N'CPB101', N'rah', NULL, NULL, NULL, N'Capture.PNG')
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (10, N'CPB101', N'rah', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (11, N'CPB101', NULL, NULL, N'kanti', NULL, N'Capture.PNG')
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (12, N'CPB101', NULL, NULL, N'jhkjh', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (13, N'CPB101', NULL, NULL, N'fgf', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (14, N'CPB101', NULL, NULL, N'dee', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (15, N'CPB101', NULL, NULL, N'e', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (16, N'CPB101', NULL, NULL, N'lkjlkj', NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (17, N'CPB101', NULL, NULL, N'f', NULL, N'Directory-Indore-2019.pdf')
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (18, N'CPB101', NULL, NULL, N'ffff', N'h', N'Directory-Indore-2019.pdf')
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (19, N'CPB101', NULL, N'15/10/2019', N'xzc', N'xz', N'Directory-Indore-2019.pdf')
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (20, N'CPB101', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Title], [Describtion], [File]) VALUES (21, N'CPB101', NULL, N'15/10/2019', N'b cvb ', N'm nm', N'Directory-Indore-2019.pdf')
SET IDENTITY_INSERT [dbo].[tbl_SeperationFromTheCongregation] OFF
SET IDENTITY_INSERT [dbo].[Tbl_UserLogins] ON 

INSERT [dbo].[Tbl_UserLogins] ([Id], [UserName], [UserPassword], [UserRole], [Spare1], [Spare2], [Spare3]) VALUES (1, N'admin', N'admin', N'admin', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_UserLogins] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_EmergencyContact]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_EntryLife]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_EntryLife1]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_Health]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_HomeLiveAndHomeVisit]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_Jubilee]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_LivingOutsideTheCongregation]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_Passed]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_ReligiousEducation]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_Retirement]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_Seminar]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_SeperationFromTheCongregation]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_ServiceInTheCongregation]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MemberID]    Script Date: 11/4/2019 10:08:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_MemberID] ON [dbo].[tbl_TravelRecord]
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CongDatas] ADD  DEFAULT (newsequentialid()) FOR [id]
GO
ALTER TABLE [dbo].[CounCircCommis] ADD  DEFAULT (newsequentialid()) FOR [id]
GO
ALTER TABLE [dbo].[SocietyDatas] ADD  DEFAULT (newsequentialid()) FOR [id]
GO
ALTER TABLE [dbo].[Tbl_Cong] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_EmergencyContact_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK_dbo.tbl_EmergencyContact_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_EntryLife_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK_dbo.tbl_EntryLife_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_EntryLife1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_EntryLife1_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_EntryLife1] CHECK CONSTRAINT [FK_dbo.tbl_EntryLife1_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_Health_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK_dbo.tbl_Health_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_HomeLiveAndHomeVisit_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK_dbo.tbl_HomeLiveAndHomeVisit_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_Jubilee_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK_dbo.tbl_Jubilee_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_LivingOutsideTheCongregation_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK_dbo.tbl_LivingOutsideTheCongregation_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_Passed]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_Passed_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Passed] CHECK CONSTRAINT [FK_dbo.tbl_Passed_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_ReligiousEducation_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK_dbo.tbl_ReligiousEducation_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_Retirement_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK_dbo.tbl_Retirement_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_Seminar_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK_dbo.tbl_Seminar_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_SeperationFromTheCongregation_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK_dbo.tbl_SeperationFromTheCongregation_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_ServiceInTheCongregation_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK_dbo.tbl_ServiceInTheCongregation_dbo.tbl_PersonalDetails_MemberID]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbl_TravelRecord_dbo.tbl_PersonalDetails_MemberID] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK_dbo.tbl_TravelRecord_dbo.tbl_PersonalDetails_MemberID]
GO
USE [master]
GO
ALTER DATABASE [GeneralateFathers3] SET  READ_WRITE 
GO
