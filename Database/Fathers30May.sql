USE [master]
GO
/****** Object:  Database [Fathers30May]    Script Date: 10-Jun-19 10:01:15 AM ******/
CREATE DATABASE [Fathers30May]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fathers30May', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Fathers30May.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fathers30May_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Fathers30May_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Fathers30May] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fathers30May].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fathers30May] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fathers30May] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fathers30May] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fathers30May] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fathers30May] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fathers30May] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fathers30May] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fathers30May] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fathers30May] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fathers30May] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fathers30May] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fathers30May] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fathers30May] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fathers30May] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fathers30May] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fathers30May] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fathers30May] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fathers30May] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fathers30May] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fathers30May] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fathers30May] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fathers30May] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fathers30May] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Fathers30May] SET  MULTI_USER 
GO
ALTER DATABASE [Fathers30May] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fathers30May] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fathers30May] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fathers30May] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fathers30May] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fathers30May] SET QUERY_STORE = OFF
GO
USE [Fathers30May]
GO
/****** Object:  Table [dbo].[ArchiveFields]    Script Date: 10-Jun-19 10:01:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchiveFields](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.ArchiveFields] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArchiveFieldValues]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchiveFieldValues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FieldId] [int] NOT NULL,
	[FieldValue] [nvarchar](max) NOT NULL,
	[ParentFieldId] [int] NULL,
	[Fieldname] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ArchiveFieldValues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArchiveUsers]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchiveUsers](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ArchiveUsers] PRIMARY KEY CLUSTERED 
(
	[Username] ASC,
	[Password] ASC,
	[IsAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CommunityId] [int] NULL,
	[PlaceId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
	[DistrictId] [int] NULL,
	[DocumentCategoryId] [int] NULL,
	[DocumentSubCategoryId] [int] NULL,
	[Year] [int] NULL,
	[DocumentName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_dbo.Document] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentContent]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [int] NULL,
	[Filename] [nvarchar](200) NULL,
	[ArchivedFile] [uniqueidentifier] NULL,
	[FileContent] [varbinary](max) NULL,
	[FileMIMEtype] [varchar](2000) NOT NULL,
	[FileExtension] [varchar](5) NOT NULL,
	[Filesendtime] [date] NOT NULL,
	[CommunityName] [nvarchar](max) NULL,
	[Place] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[DocumentCategory] [nvarchar](max) NULL,
	[DocumentSubCategory] [nvarchar](max) NULL,
	[Year] [nvarchar](50) NULL,
	[Filesentdate] [datetime] NULL,
 CONSTRAINT [PK_dbo.DocumentContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentFields]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentFields](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CommunityName] [nvarchar](200) NULL,
	[Place] [nvarchar](200) NULL,
	[State] [nvarchar](200) NULL,
	[City] [nvarchar](200) NULL,
	[District] [nvarchar](200) NULL,
	[DocumentCategory] [nvarchar](200) NULL,
	[DocumentSubCategory] [nvarchar](200) NULL,
	[Year] [int] NULL,
	[DocumentName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_dbo.DocumentFields] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralateDoc]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralateDoc](
	[GeneralDoc] [nvarchar](50) NOT NULL,
	[DocumentName] [nvarchar](150) NULL,
	[Title] [nvarchar](150) NULL,
	[Date] [datetime] NULL,
	[File] [nvarchar](150) NULL,
 CONSTRAINT [PK_GeneralateDoc] PRIMARY KEY CLUSTERED 
(
	[GeneralDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralateDocument]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralateDocument](
	[GeneralLetter] [nvarchar](150) NULL,
	[GenCounncilReport] [nvarchar](150) NULL,
	[LettertoGeneral] [nvarchar](150) NULL,
	[Generalid] [nvarchar](50) NOT NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_GeneralateDocument] PRIMARY KEY CLUSTERED 
(
	[Generalid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InboxEmail]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InboxEmail](
	[EmailUid] [nvarchar](max) NOT NULL,
	[FromAddress] [nvarchar](max) NOT NULL,
	[ToAddress] [nvarchar](max) NOT NULL,
	[CCAddress] [nvarchar](max) NULL,
	[BCCAddress] [nvarchar](max) NULL,
	[EmailDate] [datetime] NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [varbinary](max) NULL,
	[MailType] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[asciiBody] [nvarchar](max) NULL,
	[utfBody] [nvarchar](max) NULL,
	[utfsBody] [nvarchar](max) NULL,
 CONSTRAINT [PK_InboxEmail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InboxEmailAttachment]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InboxEmailAttachment](
	[InboxEmailID] [uniqueidentifier] NOT NULL,
	[Filename] [nvarchar](250) NULL,
	[Attachment] [varbinary](max) NULL,
	[ID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_InboxEmailAttachment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PArchiveFields]    Script Date: 10-Jun-19 10:01:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PArchiveFields](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.PArchiveFields] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PArchiveFieldValues]    Script Date: 10-Jun-19 10:01:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PArchiveFieldValues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FieldId] [int] NOT NULL,
	[FieldValue] [nvarchar](max) NOT NULL,
	[ParentFieldId] [int] NULL,
	[Fieldname] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PArchiveFieldValues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalDetail]    Script Date: 10-Jun-19 10:01:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](200) NOT NULL,
	[Username] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_PersonalDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalDocumentContent]    Script Date: 10-Jun-19 10:01:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalDocumentContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [nvarchar](200) NULL,
	[ArchivedFile] [uniqueidentifier] NULL,
	[FileContent] [varbinary](max) NULL,
	[FileMIMEtype] [varchar](2000) NOT NULL,
	[FileExtension] [varchar](5) NOT NULL,
	[Filesendtime] [date] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Adhar No] [nvarchar](max) NULL,
	[FileSentdate] [datetime] NULL,
	[PANCopy] [nvarchar](max) NULL,
	[MemberID] [nchar](10) NULL,
	[PDocumentCategory] [nvarchar](50) NULL,
	[PDocumentSubCategory] [nvarchar](50) NULL,
	[PYear] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.PersonalDocumentContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProDocument]    Script Date: 10-Jun-19 10:01:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProDocument](
	[Document id] [nchar](22) NOT NULL,
	[DocumentName] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Date] [datetime] NULL,
	[File] [nvarchar](150) NULL,
 CONSTRAINT [PK_ProDocument] PRIMARY KEY CLUSTERED 
(
	[Document id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincial]    Script Date: 10-Jun-19 10:01:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincial](
	[ID] [int] NOT NULL,
	[DName] [nvarchar](300) NULL,
	[Letters] [nvarchar](300) NULL,
	[Circulars] [nvarchar](300) NULL,
	[Messgs] [nvarchar](300) NULL,
	[Nihil] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Academy]    Script Date: 10-Jun-19 10:01:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Academy](
	[acaid] [int] IDENTITY(1,1) NOT NULL,
	[title] [nchar](10) NULL,
	[course] [nchar](10) NULL,
	[degree] [nchar](10) NULL,
	[university] [nchar](10) NULL,
	[fromdate] [nchar](10) NULL,
	[todate] [nchar](10) NULL,
	[classo] [nchar](10) NULL,
	[medium] [nchar](10) NULL,
	[adress] [nchar](10) NULL,
	[remark] [nchar](10) NULL,
	[doc] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Academy] PRIMARY KEY CLUSTERED 
(
	[acaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Appointment]    Script Date: 10-Jun-19 10:01:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Appointment](
	[apointid] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[date] [nvarchar](50) NULL,
	[remark] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Appointment] PRIMARY KEY CLUSTERED 
(
	[apointid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Bank_Details]    Script Date: 10-Jun-19 10:01:17 AM ******/
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
/****** Object:  Table [dbo].[tbl_BookOfAccountsDoc]    Script Date: 10-Jun-19 10:01:17 AM ******/
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
 CONSTRAINT [PK_tbl_BookOfAccountsDoc] PRIMARY KEY CLUSTERED 
(
	[BookOfAccountsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CandidatesInformationDoc]    Script Date: 10-Jun-19 10:01:17 AM ******/
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
 CONSTRAINT [PK_CandidatesInformationDoc] PRIMARY KEY CLUSTERED 
(
	[CandidatesInformationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommonDataList]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CommonDataList](
	[CDLId] [int] IDENTITY(1,1) NOT NULL,
	[DataListName] [varchar](500) NULL,
	[Status] [varchar](10) NULL,
	[Spare1] [varchar](35) NULL,
	[Spare2] [varchar](35) NULL,
	[Spare3] [varchar](35) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommonDataListItems]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CommonDataListItems](
	[CDLITId] [int] IDENTITY(1,1) NOT NULL,
	[DataListName] [varchar](500) NULL,
	[DataListItemName] [varchar](500) NULL,
	[Status] [varchar](10) NULL,
	[Spare1] [varchar](35) NULL,
	[Spare2] [varchar](35) NULL,
	[Spare3] [varchar](35) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommunicationOfficeDoc]    Script Date: 10-Jun-19 10:01:18 AM ******/
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
 CONSTRAINT [PK_CommunicationOfficeId] PRIMARY KEY CLUSTERED 
(
	[CommunicationOfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CommunitiesSocialCentresDoc]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CommunitiesSocialCentresDoc](
	[CommunityId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityName] [nvarchar](50) NULL,
	[EstablishDate] [nvarchar](50) NULL,
	[Place] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_CommunitiesCentresDoc] PRIMARY KEY CLUSTERED 
(
	[CommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Complaint]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Complaint](
	[ComplaintID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[ComplaintFrom] [nvarchar](70) NULL,
	[ComplaintDATE] [nvarchar](256) NULL,
	[ComplaintNATURE] [varchar](700) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](256) NULL,
	[Decesion] [nvarchar](300) NULL,
	[Document] [nvarchar](1000) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK__tbl_Comp__740D89AF4A05EDC3] PRIMARY KEY CLUSTERED 
(
	[ComplaintID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ConfreresDoc]    Script Date: 10-Jun-19 10:01:18 AM ******/
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
 CONSTRAINT [PK_tbl_ConfreresDoc] PRIMARY KEY CLUSTERED 
(
	[ConfreresId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_DailySms]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DailySms](
	[SmsId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[BirthDate] [nvarchar](10) NULL,
	[OrdinationDate] [nvarchar](10) NULL,
	[FeastDate] [nvarchar](10) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Status] [nvarchar](10) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
 CONSTRAINT [PK_tbl_DailySms] PRIMARY KEY CLUSTERED 
(
	[SmsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_EmailAttachement]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EmailAttachement](
	[attchedfilename] [varchar](2000) NOT NULL,
	[FileContent] [varbinary](max) NULL,
	[FileMIMEtype] [varchar](2000) NOT NULL,
	[FileExtension] [varchar](5) NOT NULL,
	[Filesendtime] [date] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[FileUniqueId] [uniqueidentifier] NOT NULL,
	[EmailUniqueId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_EmailFile] PRIMARY KEY CLUSTERED 
(
	[FileUniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Emaildata]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Emaildata](
	[EmailSubject] [nvarchar](2000) NOT NULL,
	[EmailBody] [nvarchar](max) NOT NULL,
	[ToAddress] [nvarchar](2000) NOT NULL,
	[Admin] [nvarchar](2000) NOT NULL,
	[Emailsentdate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[EmailUniqueId] [uniqueidentifier] NOT NULL,
	[CCAddress] [nvarchar](2000) NULL,
	[BCCAddress] [nvarchar](2000) NULL,
	[IsImportant] [bit] NULL,
 CONSTRAINT [PK_tbl_Emaildata] PRIMARY KEY CLUSTERED 
(
	[EmailUniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_EmergencyContact]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EmergencyContact](
	[EmergencyContactId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Relationship] [nvarchar](200) NOT NULL,
	[Mobile] [nvarchar](20) NULL,
	[Landline] [nvarchar](20) NULL,
	[EmailID] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Name] [nvarchar](200) NULL,
	[SirName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmergencyContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Entry]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Entry](
	[EntryId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
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
	[Name] [nvarchar](200) NULL,
	[SirName] [nvarchar](max) NULL,
	[Docs] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_EntryLife]    Script Date: 10-Jun-19 10:01:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EntryLife](
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
	[Name] [nvarchar](200) NULL,
	[SirName] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[EntryLifeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_EntryLife1]    Script Date: 10-Jun-19 10:01:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EntryLife1](
	[EntryLifeId] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK__tbl_Entr__8CE371BF5BE2A6F2] PRIMARY KEY CLUSTERED 
(
	[EntryLifeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FinancialGuidelineDoc]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
 CONSTRAINT [PK_tbl_FinanceDoc] PRIMARY KEY CLUSTERED 
(
	[FinancialDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FinancialReportDoc]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
 CONSTRAINT [PK_tbl_FinancialReportDoc] PRIMARY KEY CLUSTERED 
(
	[FinancialReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FomDoc]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
 CONSTRAINT [PK_tbl_FomDoc] PRIMARY KEY CLUSTERED 
(
	[FormationDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_formationsDetails]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_formationsDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_FormationTypes]    Script Date: 10-Jun-19 10:01:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_FormationTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FortmationType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_FormationTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FormatorsMeetDoc]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
 CONSTRAINT [PK_tbl_FormatorsMeetDoc] PRIMARY KEY CLUSTERED 
(
	[FormatorsMeetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_FundRaisingCommiteeDoc]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
 CONSTRAINT [PK_tbl_FundRaisingCommiteeDoc] PRIMARY KEY CLUSTERED 
(
	[FundRaisingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GeneralateDoc]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
 CONSTRAINT [PK_tbl_GeneralateDoc] PRIMARY KEY CLUSTERED 
(
	[GeneralateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GeneralMattersDoc]    Script Date: 10-Jun-19 10:01:19 AM ******/
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
 CONSTRAINT [PK_GeneralMattersDoc] PRIMARY KEY CLUSTERED 
(
	[GeneralMattersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Health]    Script Date: 10-Jun-19 10:01:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Health](
	[HealthId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Complaint] [nvarchar](150) NOT NULL,
	[FromDate] [nvarchar](10) NOT NULL,
	[ToDate] [nvarchar](10) NULL,
	[Diagnosis] [nvarchar](100) NOT NULL,
	[Hospital] [nvarchar](150) NOT NULL,
	[Doctor] [nvarchar](100) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[HealthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_HomeLiveAndHomeVisit]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_HomeLiveAndHomeVisit](
	[HomeliveId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[DepartureDate] [nvarchar](10) NULL,
	[ArrivalDate] [nvarchar](10) NULL,
	[NoOfDays] [int] NULL,
	[Purpose] [nvarchar](200) NULL,
	[Place] [nvarchar](200) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[ColName] [nvarchar](500) NULL,
	[Institute] [nvarchar](max) NULL,
	[SirName] [nvarchar](50) NULL,
	[Docs] [nvarchar](50) NULL,
	[TransferLetter] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HomeliveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Institution]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Institution](
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
 CONSTRAINT [PK_tbl_Institution] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_institution123]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_institution123](
	[InstitutionId] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](50) NULL,
	[FromDate] [nvarchar](50) NULL,
	[Closingdate] [nvarchar](50) NULL,
	[NameOfInstitution] [nvarchar](50) NULL,
	[TypeOfInstitution] [nvarchar](50) NULL,
	[NameOfDiocese] [nvarchar](50) NULL,
	[OwenedBy] [nvarchar](50) NULL,
	[MaintainedBy] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Telephone] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[WebSite] [nvarchar](50) NULL,
	[spare1] [nvarchar](50) NULL,
	[spare2] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_institution123_1] PRIMARY KEY CLUSTERED 
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_InstitutionFinal]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_InstitutionFinal](
	[InstitutionId] [int] NULL,
	[INSTID] [nchar](10) NULL,
	[InstName] [nchar](10) NULL,
	[InstType] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Jubilee]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Jubilee](
	[JubileeID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Profession] [nvarchar](256) NULL,
	[FirstProfession] [varchar](10) NULL,
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
	[SirName] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[JubileeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_KnownLanguages]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_KnownLanguages](
	[KnownLanguagesId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[ToRead] [nvarchar](20) NULL,
	[ToWrite] [nvarchar](20) NULL,
	[ToSpeak] [nvarchar](20) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[LanguageName] [nvarchar](100) NULL,
	[Name] [nvarchar](200) NULL,
	[SirName] [nchar](10) NULL,
 CONSTRAINT [PK__tbl_Know__53CD144AA802F807] PRIMARY KEY CLUSTERED 
(
	[KnownLanguagesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_LandDocuments]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
	[Year] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](50) NULL,
	[Place] [nvarchar](200) NULL,
	[Tital] [nvarchar](100) NULL,
 CONSTRAINT [PK_Tbl_LandDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LivingOutsideTheCongregation]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
	[SirName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[LivingOutsideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MinistryDoc]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
 CONSTRAINT [PK_tbl_MinistryDoc] PRIMARY KEY CLUSTERED 
(
	[MinistryDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MissionDoc]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
 CONSTRAINT [PK_MissionDoc] PRIMARY KEY CLUSTERED 
(
	[MissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OngoingFormationDoc]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
 CONSTRAINT [PK_OngoingFormationDoc] PRIMARY KEY CLUSTERED 
(
	[OngoingFormationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OVCDoc]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
 CONSTRAINT [PK_tbl_OVCDoc] PRIMARY KEY CLUSTERED 
(
	[OvcDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Paris]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
 CONSTRAINT [PK_Tbl_Paris] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_ParisInstitutionDetails]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
 CONSTRAINT [PK_Tbl_ParisInstitutionDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Passed]    Script Date: 10-Jun-19 10:01:20 AM ******/
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
	[ville] [nvarchar](256) NULL,
	[obituary] [nvarchar](256) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PersonalDetails]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PersonalDetails](
	[PersonalDetailsId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[NameBaptismial] [nvarchar](200) NULL,
	[EmailID] [nvarchar](200) NULL,
	[SirName] [nvarchar](200) NULL,
	[Image] [varbinary](max) NULL,
	[MotherTongue] [nvarchar](100) NULL,
	[BloodGroup] [nvarchar](20) NULL,
	[DOB] [nvarchar](10) NULL,
	[VillageTown] [nvarchar](100) NULL,
	[District] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[NameasinAadharCard] [nvarchar](50) NULL,
	[FatherName] [nvarchar](200) NULL,
	[FeastDays] [nvarchar](50) NULL,
	[MotherName] [nvarchar](200) NULL,
	[Spare1] [nvarchar](256) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](256) NULL,
	[FMobile] [nvarchar](20) NULL,
	[MMobile] [nvarchar](20) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Pincode] [nvarchar](20) NULL,
	[AadharNo] [nvarchar](20) NULL,
	[NoOfBrother] [nvarchar](20) NULL,
	[NoOfSister] [nvarchar](20) NULL,
	[PlaceintheFamily] [nvarchar](20) NULL,
	[Will] [nvarchar](50) NULL,
	[DateofJoining] [nvarchar](50) NULL,
	[NameofDioceses] [nvarchar](200) NULL,
	[Parish] [nvarchar](200) NULL,
	[FBaptism] [nvarchar](max) NULL,
	[MBaptism] [nvarchar](max) NULL,
	[Parish1] [nvarchar](max) NULL,
	[Provincial] [nvarchar](500) NULL,
	[Provincial1] [nvarchar](500) NULL,
	[DName] [nvarchar](50) NULL,
	[Tittle] [nvarchar](50) NULL,
	[msgs] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__tbl_Pers__0CF04B3841148D12] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Primarydetails]    Script Date: 10-Jun-19 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Primarydetails](
	[Primaryid] [int] IDENTITY(1,1) NOT NULL,
	[MemberId1] [nvarchar](50) NOT NULL,
	[Knowname] [nvarchar](50) NULL,
	[Baptismialname] [nvarchar](50) NULL,
	[DOB] [nvarchar](50) NULL,
	[DOB1] [nvarchar](50) NULL,
	[Feastday] [nvarchar](50) NULL,
	[Bloodgroup] [nvarchar](50) NULL,
	[emailid] [nvarchar](50) NULL,
	[mobilenumber] [nvarchar](50) NULL,
	[whatsappnumber] [nvarchar](50) NULL,
	[facebookid] [nvarchar](50) NULL,
	[twitterid] [nvarchar](50) NULL,
	[blog] [nvarchar](50) NULL,
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
 CONSTRAINT [PK_tbl_Primarydetails] PRIMARY KEY CLUSTERED 
(
	[Primaryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ProvincialDoc]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
 CONSTRAINT [PK_tbl_ProvincialDoc] PRIMARY KEY CLUSTERED 
(
	[ProvincialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ReligiousEducation]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ReligiousEducation](
	[ReligiousId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[DegreeName] [nvarchar](100) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[University] [nvarchar](300) NULL,
	[Address] [nvarchar](500) NULL,
	[ClassObtained] [nvarchar](35) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Remarks] [varchar](300) NULL,
	[Name] [nvarchar](200) NULL,
	[SirName] [nvarchar](max) NULL,
	[Certificate] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ReligiousId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Retirement]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Retirement](
	[RetirementId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[DOR] [nvarchar](10) NULL,
	[Reason] [nvarchar](200) NULL,
	[Community] [nvarchar](200) NULL,
	[Remarks] [nvarchar](75) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Age] [nvarchar](20) NULL,
	[SirName] [nvarchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[RetirementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SCTDoc]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
 CONSTRAINT [PK_tbl_SCTDoc] PRIMARY KEY CLUSTERED 
(
	[SctDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SecularEducation]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SecularEducation](
	[SecularId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[DegreeName] [nvarchar](100) NULL,
	[FromDate] [nvarchar](10) NULL,
	[ToDate] [nvarchar](10) NULL,
	[University] [nvarchar](35) NULL,
	[Address] [nvarchar](35) NULL,
	[ClassObtained] [nvarchar](35) NULL,
	[Medium] [nvarchar](35) NULL,
	[Title] [nvarchar](35) NULL,
	[Course] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[Remarks] [varchar](300) NULL,
	[Name] [nvarchar](200) NULL,
	[SirName] [nvarchar](max) NULL,
	[Certificate] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SecularId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Seminar]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
	[SirName] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeminarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SeperationFromTheCongregation]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SeperationFromTheCongregation](
	[SeperationId] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberID] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[SeperationDate] [nvarchar](10) NULL,
	[Purpose] [nvarchar](256) NULL,
	[NatureOfSeperation] [nvarchar](256) NULL,
	[DispensationLetter] [nvarchar](50) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL,
	[SirName] [nvarchar](35) NULL,
 CONSTRAINT [PK__tbl_Sepe__5A5AF07A06CD04F7] PRIMARY KEY CLUSTERED 
(
	[SeperationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ServiceInTheCongregation]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
	[DepartureDate] [nvarchar](10) NULL,
	[ArrivalDate] [nvarchar](10) NULL,
	[NoOfDays] [int] NULL,
	[Purpose] [nvarchar](200) NULL,
	[Place] [nvarchar](200) NULL,
	[TransferLetter] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SMSContent]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SMSContent](
	[ContentId] [int] IDENTITY(1,1) NOT NULL,
	[Feast] [nvarchar](100) NULL,
	[Content] [nvarchar](256) NULL,
	[Status] [nvarchar](10) NULL,
	[Spare] [nvarchar](35) NULL,
 CONSTRAINT [PK_tbl_SMSContent] PRIMARY KEY CLUSTERED 
(
	[ContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Soc_Addminstration]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
	[FCRANo] [nvarchar](50) NULL,
	[ANo] [nvarchar](50) NULL,
	[GNo] [nvarchar](50) NULL,
	[Spare] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Soc_Addminstration] PRIMARY KEY CLUSTERED 
(
	[SocityAdministrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SocialInstitutionDoc]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
 CONSTRAINT [PK_tbl_SocialInstitutionDoc] PRIMARY KEY CLUSTERED 
(
	[SocialInstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_SocietyDetails]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_SocietyDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SocieryName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Tbl_SocietyDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SpiritualCommunityDoc]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
 CONSTRAINT [PK_SpiritualCommunityDoc] PRIMARY KEY CLUSTERED 
(
	[SpiritualCommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_StCamillusProvincialateDoc]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
 CONSTRAINT [PK_tbl_StCamillusProvincialateDoc] PRIMARY KEY CLUSTERED 
(
	[StCamillusProvincialateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TravelRecord]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
PRIMARY KEY CLUSTERED 
(
	[TravelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_unknow]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_unknow](
	[memid] [int] IDENTITY(1,1) NOT NULL,
	[Knowname] [nchar](10) NULL,
	[Baptismialname] [nchar](10) NULL,
	[DOB] [nchar](10) NULL,
	[DOB1] [nchar](10) NULL,
	[Feastday] [nchar](10) NULL,
	[Bloodgroup] [nchar](10) NULL,
	[emailid] [nchar](10) NULL,
	[mobilenumber] [nchar](10) NULL,
	[whatsappnumber] [nchar](10) NULL,
	[facebookid] [nchar](10) NULL,
	[twitterid] [nchar](10) NULL,
	[blog] [nchar](10) NULL,
	[house] [nchar](10) NULL,
	[city] [nchar](10) NULL,
	[district] [nchar](10) NULL,
	[state] [nchar](10) NULL,
	[pin] [nchar](10) NULL,
	[adhar] [nchar](10) NULL,
	[pan] [nchar](10) NULL,
	[passport] [nchar](10) NULL,
	[nameonadhar] [nchar](10) NULL,
	[nameonpan] [nchar](10) NULL,
	[nameonpassport] [nchar](10) NULL,
	[File1] [nchar](10) NULL,
	[File2] [nchar](10) NULL,
	[File3] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_unknow] PRIMARY KEY CLUSTERED 
(
	[memid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserLogin]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserLogin](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](200) NULL,
	[UserPassword] [nvarchar](200) NULL,
	[UserRole] [nvarchar](200) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserModuleLogin]    Script Date: 10-Jun-19 10:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserModuleLogin](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](200) NULL,
	[UserPassword] [nvarchar](200) NULL,
	[UserRole] [nvarchar](200) NULL,
	[Spare1] [nvarchar](35) NULL,
	[Spare2] [nvarchar](35) NULL,
	[Spare3] [nvarchar](35) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_VocationalTrainingDoc]    Script Date: 10-Jun-19 10:01:21 AM ******/
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
 CONSTRAINT [PK_tbl_VocationalTrainingDoc] PRIMARY KEY CLUSTERED 
(
	[VocationalTrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_VocationPromotionDoc]    Script Date: 10-Jun-19 10:01:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_VocationPromotionDoc](
	[VocationPromotionId] [int] IDENTITY(1,1) NOT NULL,
	[DoccumentName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[File] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_VocationPromotionDoc] PRIMARY KEY CLUSTERED 
(
	[VocationPromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Academy] ON 

INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (1, N'fdg       ', N'fdg       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (2, N'fdg       ', N'fdg       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (3, N'ffb       ', N'fb        ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (4, N'fb        ', N'fb        ', N'khk       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (5, N':L        ', N';''lgh     ', N'hjk       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (6, N'knmkl     ', N'uihi      ', N'uijh      ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (7, N'fgh       ', N'fgn       ', N'fgnj      ', N'fgj       ', N'fgj       ', N'fgj       ', N'fgj       ', N'fgj       ', N'fgj       ', N'fgj       ', N'fgj')
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (19, N'ghvk      ', N'ghk       ', N'ghk       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (20, N'ghk       ', N'hgk       ', N'ghk       ', N'hgk       ', N'ghk       ', N'hgk       ', N'ghk       ', N'ghk       ', N'ghk       ', N'ghk       ', N'ghk')
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (29, N'B.E       ', N'hkj       ', N'hjk       ', N'hjk       ', N'12/01/2015', N'ytjh      ', N'hgj       ', N'gh        ', N'gh        ', N'bachler   ', NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (30, N'Master    ', NULL, NULL, NULL, N'13/06/2015', NULL, NULL, NULL, NULL, N'master    ', NULL)
INSERT [dbo].[tbl_Academy] ([acaid], [title], [course], [degree], [university], [fromdate], [todate], [classo], [medium], [adress], [remark], [doc]) VALUES (31, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'jkl       ', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Academy] OFF
SET IDENTITY_INSERT [dbo].[tbl_Appointment] ON 

INSERT [dbo].[tbl_Appointment] ([apointid], [title], [date], [remark]) VALUES (1, N'director of schoool', N'15/06/2008', N'st. joseph school')
INSERT [dbo].[tbl_Appointment] ([apointid], [title], [date], [remark]) VALUES (2, N'NULminister of schooolL', N'19/06/2008', N'apointed st. jose school')
SET IDENTITY_INSERT [dbo].[tbl_Appointment] OFF
SET IDENTITY_INSERT [dbo].[tbl_CommonDataList] ON 

INSERT [dbo].[tbl_CommonDataList] ([CDLId], [DataListName], [Status], [Spare1], [Spare2], [Spare3]) VALUES (70, N'Doccuments Of the Province', N'1', NULL, NULL, NULL)
INSERT [dbo].[tbl_CommonDataList] ([CDLId], [DataListName], [Status], [Spare1], [Spare2], [Spare3]) VALUES (72, N'Spiritual and Community Life', N'1', NULL, NULL, NULL)
INSERT [dbo].[tbl_CommonDataList] ([CDLId], [DataListName], [Status], [Spare1], [Spare2], [Spare3]) VALUES (73, N'Ministry', N'1', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_CommonDataList] OFF
SET IDENTITY_INSERT [dbo].[tbl_CommonDataListItems] ON 

INSERT [dbo].[tbl_CommonDataListItems] ([CDLITId], [DataListName], [DataListItemName], [Status], [Spare1], [Spare2], [Spare3]) VALUES (71, N'Doccuments Of the Province', N'Constitute', N'1', NULL, NULL, NULL)
INSERT [dbo].[tbl_CommonDataListItems] ([CDLITId], [DataListName], [DataListItemName], [Status], [Spare1], [Spare2], [Spare3]) VALUES (73, N'Spiritual and Community Life', N'dfsvgsg', N'1', NULL, NULL, NULL)
INSERT [dbo].[tbl_CommonDataListItems] ([CDLITId], [DataListName], [DataListItemName], [Status], [Spare1], [Spare2], [Spare3]) VALUES (74, N'Ministry', N'afsF', N'1', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_CommonDataListItems] OFF
SET IDENTITY_INSERT [dbo].[tbl_Complaint] ON 

INSERT [dbo].[tbl_Complaint] ([ComplaintID], [MemberID], [Name], [ComplaintFrom], [ComplaintDATE], [ComplaintNATURE], [Spare1], [Spare2], [Spare3], [Decesion], [Document], [SirName]) VALUES (1, N'OFM002', N'AF', N'09/01/2019', N'04/01/2019', N'dj', NULL, NULL, N'OFM002.png', N'dj', NULL, N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_Complaint] OFF
SET IDENTITY_INSERT [dbo].[tbl_EmergencyContact] ON 

INSERT [dbo].[tbl_EmergencyContact] ([EmergencyContactId], [MemberID], [Relationship], [Mobile], [Landline], [EmailID], [Address], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (1, N'OFM002', N'ASVASV', N'3567457', N'6574', N'DH', N'DJDJ', NULL, NULL, NULL, N'AF', N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_EmergencyContact] OFF
SET IDENTITY_INSERT [dbo].[tbl_Entry] ON 

INSERT [dbo].[tbl_Entry] ([EntryId], [MemberID], [DateOfBaptism], [ChurchName1], [Minister1], [Place1], [DateOfConfirmation], [ChurchName2], [Minister2], [Place2], [Spare1], [Spare2], [Spare3], [Name], [SirName], [Docs]) VALUES (1, N'OFM002', N'01/01/2019', N'DJ', N'DJ', N'DJ', NULL, N'DJDJ', NULL, NULL, NULL, NULL, NULL, N'AF', N'AFD', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Entry] OFF
SET IDENTITY_INSERT [dbo].[tbl_EntryLife] ON 

INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (1, N'OFM002', N'08/01/2019', N'DH', N'DZSH', N'DZH', N'DZH', N'DSHSDXH', NULL, NULL, NULL, N'AF', N'AFD       ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (30, N'CPB004', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'wqewqweqwe', NULL, N'qs        ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (31, N'CPB004', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'sdfsdfsdfsdfsdfsdfsd', NULL, N'qs        ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (65, N'CPB026', N'jgm', N'hm', N'hmj', N'jh', N'ghm', N'jh', NULL, NULL, N'mj', NULL, N'gfm       ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (67, N'CPB026', N'ghk', N'hgk', NULL, NULL, N'gk', NULL, NULL, NULL, N'uk', NULL, N'gfm       ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (68, N'CPB026', N'ghk', N'hgk', NULL, NULL, N'gk', NULL, NULL, NULL, N'uk', NULL, N'gfm       ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (73, N'CPB005', N'10/01/2019', N'ygk', N'gk', N'gyki', N'ulh', N'gvkh', NULL, NULL, N'yfuk', NULL, N'ee        ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (74, N'CPB005', N'10/01/2019', N'ygk', N'gk', N'gyki', N'ulh', N'gvkh', NULL, NULL, N'yfuk', NULL, N'ee        ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (78, N'CPB003', N'10/01/2018', N'yuk', N'yuk', N'novitiate', N'yuk', N'uyk', NULL, NULL, N'Formator', NULL, N'sgd       ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (79, N'CPB003', N'10/02/2018', N'fg', N'fgnj', N'Prest Council', N'fgh', N'rt', NULL, NULL, N'Post novitiate', NULL, N'sgd       ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (80, N'CPB004', N'hf', N'hg', N'fhg', N'f', N'gfg', N'fhg', NULL, NULL, N'gf', NULL, N'qs        ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (81, N'CPB004', N'hf', N'hg', N'fhg', N'f', N'gfg', N'fhg', NULL, NULL, N'gf', NULL, N'qs        ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (82, N'CPB004', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'qs        ')
INSERT [dbo].[tbl_EntryLife] ([EntryLifeId], [MemberID], [EntryDate], [Place], [Director], [Minister], [OngoingFormation], [ColName], [Spare1], [Spare2], [Spare3], [Name], [SirName]) VALUES (83, N'CPB004', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'qs        ')
SET IDENTITY_INSERT [dbo].[tbl_EntryLife] OFF
SET IDENTITY_INSERT [dbo].[tbl_FinancialGuidelineDoc] ON 

INSERT [dbo].[tbl_FinancialGuidelineDoc] ([FinancialDocId], [DoccumentName], [Title], [Date], [Phonenumber], [Address], [Email], [File], [Photo]) VALUES (5, N'WRHWHg', N'WEHRDH', N'02/01/2019', N'35435346346', N'DHHDS', N'DHHDS', N'10cf5830-3f72-4eb2-808c-c6b02cbae8bf.png', N'c6736b1d-6031-4250-ac0c-24b588edc561.png')
SET IDENTITY_INSERT [dbo].[tbl_FinancialGuidelineDoc] OFF
SET IDENTITY_INSERT [dbo].[Tbl_formationsDetails] ON 

INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [Description]) VALUES (1, N'1', N'sfsdfsdf', N'sdfsdfs22', N'fsdf', N'kj', N'hkj', N'h', N'kj ', N'h', N'jkh', N'hjk', N'jkhkjh')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [Description]) VALUES (2, N'4', N'sdfsd', N'h', N'g', N'jh', N'gjh', N'g', N'jhg ', N'jh', N'g', N'jhg', N'jhghj')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [Description]) VALUES (4, N'1', N'22/11/2019', N'Joing CSC Title', N'jiwali university Gwalior', NULL, NULL, NULL, NULL, NULL, NULL, N'Vocation Facilitotor ', N'Description text')
INSERT [dbo].[Tbl_formationsDetails] ([Id], [StageOfFormation], [Date], [Title], [Institution], [Superior], [Formators], [Novisemaster], [Place], [Receivedby], [Conferredby], [VocationFacilitator], [Description]) VALUES (6, N'5', N'sfdfgfdg', N'dfgfdg', N'dgdfgdf', N'gfdgfdg', N'fdgdfgd', NULL, NULL, NULL, NULL, NULL, N'gdfgdfg')
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

INSERT [dbo].[tbl_Health] ([HealthId], [MemberID], [Name], [Complaint], [FromDate], [ToDate], [Diagnosis], [Hospital], [Doctor], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (1, N'OFM002', N'AF', N'djr', N'01/01/2019', N'05/01/2019', N'drj', N'dfj', N'drj', NULL, NULL, NULL, N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_Health] OFF
SET IDENTITY_INSERT [dbo].[tbl_HomeLiveAndHomeVisit] ON 

INSERT [dbo].[tbl_HomeLiveAndHomeVisit] ([HomeliveId], [MemberID], [Name], [DepartureDate], [ArrivalDate], [NoOfDays], [Purpose], [Place], [Spare1], [Spare2], [Spare3], [ColName], [Institute], [SirName], [Docs], [TransferLetter]) VALUES (1, N'OFM002', N'AFWE', N'01/01/2019', N'12/01/2019', NULL, NULL, N'WF', N'1', NULL, N'FWF', N'WWF', NULL, N'AFD', NULL, N'OFM002_province Logo TIFF-p1d21rs29cu221iuv6091pjq9c7.png.png')
SET IDENTITY_INSERT [dbo].[tbl_HomeLiveAndHomeVisit] OFF
SET IDENTITY_INSERT [dbo].[tbl_Institution] ON 

INSERT [dbo].[tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (6, N'lucd62780', N'sdfjhsgj', N'hg', N'jhg', N'jhg', N'gjh', N'g', NULL, NULL, N'04/14/2019', NULL)
INSERT [dbo].[tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (7, N'lucd62780', N'jlh', N'kjh', N'kjh', N'jkh', N'kjh', N'jkh', NULL, NULL, N'04/29/2019', N'kjh')
INSERT [dbo].[tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (8, N'lucd62780', N'yghj2dfgdfg', N'gjh2dfgfdgd', N'gjh2dfgdfg', N'gjh2', N'jhgjh2', N'ghj2', N'g2', NULL, NULL, NULL)
INSERT [dbo].[tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (9, N'lucd62780', N'hg', N'hg', N'h', N'gh', N'hg', N'khg', N'k', N'Bac1.jpeg', NULL, NULL)
INSERT [dbo].[tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (1006, N'lucd7624', N'3022', N'testINst', N'gwaliro', N'noida', N'fgfd', N'dfds', N'dsg', NULL, N'08/37/2019', NULL)
INSERT [dbo].[tbl_Institution] ([Id], [MyId], [YearOfEstablacement], [InstitutionName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate], [Telephone]) VALUES (1007, N'lucd7624', N'3022', N'testINst', N'gwaliro', N'noida', N'Tital ', N'date', N'des', NULL, N'08/34/2019', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Institution] OFF
SET IDENTITY_INSERT [dbo].[tbl_institution123] ON 

INSERT [dbo].[tbl_institution123] ([InstitutionId], [MemberID], [FromDate], [Closingdate], [NameOfInstitution], [TypeOfInstitution], [NameOfDiocese], [OwenedBy], [MaintainedBy], [Address], [Telephone], [EmailID], [WebSite], [spare1], [spare2]) VALUES (1, NULL, N'safsdfsfdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_institution123] ([InstitutionId], [MemberID], [FromDate], [Closingdate], [NameOfInstitution], [TypeOfInstitution], [NameOfDiocese], [OwenedBy], [MaintainedBy], [Address], [Telephone], [EmailID], [WebSite], [spare1], [spare2]) VALUES (2, NULL, N'y', N'y', N'y', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_institution123] OFF
SET IDENTITY_INSERT [dbo].[tbl_Jubilee] ON 

INSERT [dbo].[tbl_Jubilee] ([JubileeID], [MemberID], [Name], [Profession], [FirstProfession], [SilverJubilee], [GoldenJubilee], [PlatinumJubilee], [DiamondJubilee], [FPPlace], [SJPlace], [GJPlace], [PJPlace], [DJPlace], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (1, N'OFM002', N'AF', N'First Profession', N'01/01/2019', N'01/01/2044', N'01/01/2069', N'01/01/2094', N'01/01/2119', N'jdf', N'dj', N'jd', N'dj', N'djx', NULL, NULL, NULL, N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_Jubilee] OFF
SET IDENTITY_INSERT [dbo].[tbl_KnownLanguages] ON 

INSERT [dbo].[tbl_KnownLanguages] ([KnownLanguagesId], [MemberID], [ToRead], [ToWrite], [ToSpeak], [Spare1], [Spare2], [Spare3], [LanguageName], [Name], [SirName]) VALUES (1, N'OFM002', N'seg', N'egh', N'g', NULL, NULL, NULL, N'gse', N'AF', N'AFD       ')
SET IDENTITY_INSERT [dbo].[tbl_KnownLanguages] OFF
SET IDENTITY_INSERT [dbo].[Tbl_LandDocuments] ON 

INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (2, NULL, N'Pucd35860', N'RajeshParis', N'hkjg', N'khg', N'hg', N'jh', N'gj', N'gjhg', N'2bddbe83-7d2e-4e51-b0c7-14a9c9fa2d99 (1).jpg', N'pexels-photo-132472.jpeg', N'pexels-photo-268832.jpeg', N'pexels-photo-132472.jpeg', N'WhatsApp Image 2019-03-24 at 10.50.59 PM.jpeg', N'20193', N'07/06/2019', N'sttree', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (3, NULL, N'Pucd35860', N'RajeshParis', N'Field', N'sdfhkg', N'kjh', N'kj', N'hjk', N'h', NULL, NULL, NULL, NULL, NULL, N'555', NULL, N'hkj', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (4, N'Institution', N'lucd62780', N'RajeshIns', N'kj', N'hkjh', N'kj', N'hkjh', N'kjh', N'kjh', N'pexels-photo-268832.jpeg', N'pexels-photo-459277.jpeg', N'pexels-photo-459277.jpeg', N'pexels-photo-459277.jpeg', N'WhatsApp Image 2019-03-24 at 10.50.59 PM.jpeg', N'2022', N'07/06/2019', N'kjh', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (5, N'Institution', N'lucd62780', N'RajeshIns', N'jh', N'g', N'jhg', N'jh', N'g', N'gjh', NULL, NULL, NULL, NULL, NULL, N'4343', N'07/06/2019', N'jh', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (6, N'Institution', N'lucd62780', N'RajeshIns', N'kjhk', N'jhkj', N'hk', N'jh', N'jkh', N'kj', N'Bac1.jpeg', N'Bac1.jpeg', N'Bac1.jpeg', N'Bac1.jpeg', N'Bac1.jpeg', N'5050', N'07/06/2019', N'kjh', NULL)
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (1003, N'Paris', N'Pucd35860', N'RajeshParis', N'gj', N'hg', N'jh', N'g', N'jh', N'g', NULL, NULL, NULL, NULL, NULL, N'jhgjg', N'08/06/2019', N'ghj', N'jh')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (1004, N'Paris', N'Pucd5994', N'TestParis', N'fhgf', N'gdf', N'f', N'gd', N'g', N'fgf', NULL, NULL, NULL, NULL, NULL, N'fgf', N'08/06/2019', N'gd', N'sf')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (1005, N'Institution', N'lucd7624', N'testINst', N'sdg', N'sfg', N'sdg', N'dsg', N'fdg', N'sdf', NULL, NULL, NULL, NULL, NULL, N'zcxfdgfd', N'08/06/2019', N'dsg', N'gfgf')
INSERT [dbo].[Tbl_LandDocuments] ([Id], [Type], [MyId], [ParisInstitutionName], [DocumentCategory], [SubCategory], [Khasara], [SurveyNo], [Date], [Description], [RegistryDocumentFile], [TaxbillFile], [PavathiFile], [MapFile], [KhasaraFile], [Year], [CreatedDate], [Place], [Tital]) VALUES (1006, N'Institution', N'lucd7624', N'testINst', N'Document category', N'Sub Category', N'Khasara', N'Survey ', N'date', N'description', NULL, NULL, NULL, NULL, NULL, N'2011', N'08/06/2019', N'place', N'Tital')
SET IDENTITY_INSERT [dbo].[Tbl_LandDocuments] OFF
SET IDENTITY_INSERT [dbo].[tbl_LivingOutsideTheCongregation] ON 

INSERT [dbo].[tbl_LivingOutsideTheCongregation] ([LivingOutsideId], [MemberID], [Name], [FromDate], [ToDate], [Place], [Purpose], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (1, N'OFM002', N'AF', N'09/01/2019', N'08/01/2019', N'sdeh', N'she', NULL, NULL, NULL, N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_LivingOutsideTheCongregation] OFF
SET IDENTITY_INSERT [dbo].[tbl_MinistryDoc] ON 

INSERT [dbo].[tbl_MinistryDoc] ([MinistryDocId], [DoccumentName], [SubDoccument], [Title], [Date], [Phonenumber], [Address], [File], [Photo]) VALUES (5, N'Acsgh', N'afsF', N'SCca', N'02/01/2019', N'2542435', N'sg', N'920eb1a3-daf1-4cb8-a88d-43d6c8d02812.png', N'd8dbe548-52d8-486e-b107-8fe916517798.jpg')
SET IDENTITY_INSERT [dbo].[tbl_MinistryDoc] OFF
SET IDENTITY_INSERT [dbo].[tbl_MissionDoc] ON 

INSERT [dbo].[tbl_MissionDoc] ([MissionId], [DoccumentName], [Title], [Date], [File], [Immage]) VALUES (11, N'AAHEDH', N'SHE', N'01/01/2019', N'8b2020ab-b469-43b3-823b-bfe890c65ce0.png', N'290a16e8-e121-4f33-9a62-98a9e683548d.png')
SET IDENTITY_INSERT [dbo].[tbl_MissionDoc] OFF
SET IDENTITY_INSERT [dbo].[tbl_OVCDoc] ON 

INSERT [dbo].[tbl_OVCDoc] ([OvcDocId], [DoccumentName], [Title], [Date], [Phonenumber], [Address], [File], [Photo]) VALUES (4, N'eagfgg', N'agae', N'01/01/2019', N'45645745', N'7gcjgkf', N'958a8549-6487-4204-bd72-eb75913744ea.png', N'fc11f045-340f-4f96-8d5c-53934e8a72f0.png')
SET IDENTITY_INSERT [dbo].[tbl_OVCDoc] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Paris] ON 

INSERT [dbo].[Tbl_Paris] ([Id], [MyId], [YearOfEstablacement], [ParisName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate]) VALUES (23, N'Pucd35860', N'hg2', N'hg', N'hjg', N'jh', N'gjh', N'gjh', N'ghg', N'pexels-photo-268832.jpeg', NULL)
INSERT [dbo].[Tbl_Paris] ([Id], [MyId], [YearOfEstablacement], [ParisName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate]) VALUES (24, N'Pucd35860', N'dfdfd', N'd', N'f', N'f', N'dfF', N'FQW', N'F', NULL, N'06/06/2019')
INSERT [dbo].[Tbl_Paris] ([Id], [MyId], [YearOfEstablacement], [ParisName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate]) VALUES (1003, N'Pucd5994', N'3323', N'TestParis', N'Gwallior', N'noidda', N'xfgfg', N'xfgfd', N'vgfdg', NULL, N'08/06/2019')
INSERT [dbo].[Tbl_Paris] ([Id], [MyId], [YearOfEstablacement], [ParisName], [Place], [Address], [Tial], [Date], [Description], [FileName], [CreatedDate]) VALUES (1004, N'Pucd5994', N'3323', N'TestParis', N'Gwallior', N'noidda', N'gfdfhgfyyt', N'tyry', N'ytr', NULL, N'08/06/2019')
SET IDENTITY_INSERT [dbo].[Tbl_Paris] OFF
SET IDENTITY_INSERT [dbo].[Tbl_ParisInstitutionDetails] ON 

INSERT [dbo].[Tbl_ParisInstitutionDetails] ([Id], [MyId], [Name], [Place], [Type], [YearOfEstablacement], [Address], [FileName], [ParisId], [SocietyId], [Telephone]) VALUES (2008, N'Pucd19746', N'RajehParis', N'Gwalior', N'Paris', N'2012', N'Noida', NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ParisInstitutionDetails] ([Id], [MyId], [Name], [Place], [Type], [YearOfEstablacement], [Address], [FileName], [ParisId], [SocietyId], [Telephone]) VALUES (2009, N'Pucd923716', N'RajeshParis2', N'Gwalior2', N'Paris', N'2012', N'noida2', NULL, NULL, NULL, N'9685869586')
INSERT [dbo].[Tbl_ParisInstitutionDetails] ([Id], [MyId], [Name], [Place], [Type], [YearOfEstablacement], [Address], [FileName], [ParisId], [SocietyId], [Telephone]) VALUES (2010, N'lucd945115', N'RajeshIns2', N'Gwalior', N'Institution', N'2022', N'noida', NULL, N'Pucd19746', NULL, N'9685869586')
SET IDENTITY_INSERT [dbo].[Tbl_ParisInstitutionDetails] OFF
SET IDENTITY_INSERT [dbo].[tbl_Passed] ON 

INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [ville], [obituary], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (1, N'OFM002', N'AF', N'FE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'a959a7c1-1e9a-409e-8bed-8b412500718f.png', NULL, NULL, NULL, N'AFD')
INSERT [dbo].[tbl_Passed] ([PassedId], [MemberID], [Name], [LastCommunity], [Cause], [Date], [Time], [InstitutionPlace], [LastNatureRites], [LastPlaceRites], [ville], [obituary], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (2, N'OFM002', N'AF', N'fjgfk', N'fkg', N'02/01/2019', N'57', N'jfjgc', N'fgj', N'fj', NULL, N'12c82972-a487-450a-8d28-88689ba57983.png', NULL, NULL, NULL, N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_Passed] OFF
SET IDENTITY_INSERT [dbo].[tbl_PersonalDetails] ON 

INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (7, N'CPB003', N'sg', NULL, NULL, N'sgd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (8, N'CPB004', N'sq', NULL, NULL, N'qs', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (9, N'CPB005', N'agag', NULL, NULL, N'ee', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (10, N'CPB006', N'uiyiyu', NULL, NULL, N'yui', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (11, N'CPB007', N'ef', NULL, NULL, N'ef', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (12, N'CPB008', N'fb', NULL, NULL, N'fb', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (14, N'CPB010', N'w', NULL, NULL, N'ww', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (15, N'CPB011', N'ss', NULL, NULL, N'sd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (16, N'CPB012', N'agag', NULL, NULL, N'sgd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (17, N'CPB013', N'ASS', NULL, NULL, N'ASDSD', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (18, N'CPB014', N'fe', NULL, NULL, N'def', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (19, N'CPB015', N'xd', NULL, NULL, N'xd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (20, N'CPB016', N'sa', NULL, NULL, N'sac', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (21, N'CPB017', N'kl', NULL, NULL, N'kl', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (22, N'CPB018', N'fh', NULL, NULL, N'fdh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (23, N'CPB019', N'q', NULL, NULL, N'qq', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (25, N'CPB021', N'm,', NULL, NULL, N'vgfd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (26, N'CPB022', N'hgvjh', NULL, NULL, N'jhb', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (27, N'CPB023', N'agag', NULL, NULL, N'sgd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (28, N'CPB024', N'a', NULL, NULL, N'a', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (29, N'CPB025', N'raj', NULL, NULL, N'rrr', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (30, N'CPB026', N'hjm', NULL, NULL, N'gfm', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (31, N'CPB027', N'agag', NULL, NULL, N'sgd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (32, N'CPB028', N'Rajesh', NULL, NULL, N'Panda', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (33, N'CPB029', N'Ramya', NULL, NULL, N'Raj', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (34, N'CPB030', N'bf', NULL, NULL, N'tbh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (35, N'CPB031', N'kj,.', NULL, NULL, N'jk.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (36, N'CPB032', N'bdfh', NULL, NULL, N'fdnh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (37, N'CPB033', N'bdfh', NULL, NULL, N'fdnh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (38, N'CPB034', N'fnh', NULL, NULL, N'fgj', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (39, N'CPB035', N'sgd', NULL, NULL, N'sdg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (40, N'CPB036', N'agagdfgdfgf', NULL, NULL, N'sgdsdfddfd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (43, N'CPB066', N'Rajesh', NULL, NULL, N'Rajput', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (4, N'OFM001', N'dggdgd', N'shshe', NULL, N'gdg', NULL, NULL, NULL, NULL, N'e', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'shesh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tbl_PersonalDetails] ([PersonalDetailsId], [MemberID], [Name], [NameBaptismial], [EmailID], [SirName], [Image], [MotherTongue], [BloodGroup], [DOB], [VillageTown], [District], [State], [Country], [NameasinAadharCard], [FatherName], [FeastDays], [MotherName], [Spare1], [Spare2], [Spare3], [FMobile], [MMobile], [Mobile], [Pincode], [AadharNo], [NoOfBrother], [NoOfSister], [PlaceintheFamily], [Will], [DateofJoining], [NameofDioceses], [Parish], [FBaptism], [MBaptism], [Parish1], [Provincial], [Provincial1], [DName], [Tittle], [msgs], [IsDeleted]) VALUES (6, N'OFM002', N'AF', N'AF', NULL, N'AFD', NULL, NULL, NULL, NULL, N'2', N'srhrhs', N'ASV', N'esg', N'ADV', NULL, NULL, NULL, N'AF', NULL, NULL, NULL, N'SVA', NULL, N'ASV', N'SV', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SAV', NULL, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[tbl_PersonalDetails] OFF
SET IDENTITY_INSERT [dbo].[tbl_ProvincialDoc] ON 

INSERT [dbo].[tbl_ProvincialDoc] ([ProvincialId], [DoccumentName], [Title], [Date], [File]) VALUES (9, N'SEHG', N'SEH', N'02/01/2019', N'bf35c6ef-9e59-4c09-a199-0b440bf4cefb.jpg')
SET IDENTITY_INSERT [dbo].[tbl_ProvincialDoc] OFF
SET IDENTITY_INSERT [dbo].[tbl_ReligiousEducation] ON 

INSERT [dbo].[tbl_ReligiousEducation] ([ReligiousId], [MemberID], [DegreeName], [FromDate], [ToDate], [University], [Address], [ClassObtained], [Spare1], [Spare2], [Spare3], [Remarks], [Name], [SirName], [Certificate]) VALUES (1, N'OFM002', N'FWF', N'01/01/2019', N'05/01/2019', N'wf', N'WF', N'wf', NULL, NULL, NULL, N'F', N'AF', N'AFD', N'st_francis2-e1446233924958.png.png')
SET IDENTITY_INSERT [dbo].[tbl_ReligiousEducation] OFF
SET IDENTITY_INSERT [dbo].[tbl_Retirement] ON 

INSERT [dbo].[tbl_Retirement] ([RetirementId], [MemberID], [Name], [DOR], [Reason], [Community], [Remarks], [Spare1], [Spare2], [Spare3], [Age], [SirName]) VALUES (1, N'OFM002', N'AF', N'08/01/2019', N'kvgh', N'kfk', N'fgk', NULL, NULL, NULL, N'767', N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_Retirement] OFF
SET IDENTITY_INSERT [dbo].[tbl_SCTDoc] ON 

INSERT [dbo].[tbl_SCTDoc] ([SctDocId], [DoccumentName], [Title], [Date], [Phonenumber], [Address], [File], [Photo]) VALUES (7, N'weagwe', N'weg', N'07/01/2019', N'4645747', N'hfgh', N'5e182d4d-a434-4756-a920-d286c6de0ae7.png', N'6b59ff57-5fc6-437c-b556-95ad57bc9b8d.png')
SET IDENTITY_INSERT [dbo].[tbl_SCTDoc] OFF
SET IDENTITY_INSERT [dbo].[tbl_Seminar] ON 

INSERT [dbo].[tbl_Seminar] ([SeminarId], [MemberID], [Community], [Name], [FromDate], [ToDate], [SeminarName], [Place], [Institute], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (1, N'OFM002', N'wqf', N'AF', N'02/01/2019', N'01/01/2019', NULL, N'qf', N'fqw', NULL, NULL, NULL, N'AFD       ')
SET IDENTITY_INSERT [dbo].[tbl_Seminar] OFF
SET IDENTITY_INSERT [dbo].[tbl_SeperationFromTheCongregation] ON 

INSERT [dbo].[tbl_SeperationFromTheCongregation] ([SeperationId], [MemberID], [Name], [SeperationDate], [Purpose], [NatureOfSeperation], [DispensationLetter], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (1, N'OFM002', N'AF', N'09/01/2019', N'rhe', N'rh', N'cd28a6f3-fb4a-426d-857c-5e03649785be.png', NULL, NULL, NULL, N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_SeperationFromTheCongregation] OFF
SET IDENTITY_INSERT [dbo].[tbl_Soc_Addminstration] ON 

INSERT [dbo].[tbl_Soc_Addminstration] ([SocityAdministrationId], [SocityName], [Date], [RegNo], [PanNo], [FCRANo], [ANo], [GNo], [Spare]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Soc_Addminstration] OFF
SET IDENTITY_INSERT [dbo].[Tbl_SocietyDetails] ON 

INSERT [dbo].[Tbl_SocietyDetails] ([Id], [SocieryName]) VALUES (1, N'Global')
SET IDENTITY_INSERT [dbo].[Tbl_SocietyDetails] OFF
SET IDENTITY_INSERT [dbo].[tbl_StCamillusProvincialateDoc] ON 

INSERT [dbo].[tbl_StCamillusProvincialateDoc] ([StCamillusProvincialateId], [DoccumentName], [SubDoccument], [Title], [Date], [File]) VALUES (4, N'SJ[', N'SHSH', N'JIP', N'01/01/2019', N'e0eabf66-fe97-45ab-9ffd-1533954d1c41.png')
SET IDENTITY_INSERT [dbo].[tbl_StCamillusProvincialateDoc] OFF
SET IDENTITY_INSERT [dbo].[tbl_TravelRecord] ON 

INSERT [dbo].[tbl_TravelRecord] ([TravelId], [MemberID], [Name], [FromDate], [ToDate], [Place], [Purpose], [Spare1], [Spare2], [Spare3], [SirName]) VALUES (1, N'OFM002', N'AF', N'07/01/2019', N'09/01/2019', N'ftj', N'dj', NULL, NULL, NULL, N'AFD')
SET IDENTITY_INSERT [dbo].[tbl_TravelRecord] OFF
SET IDENTITY_INSERT [dbo].[tbl_unknow] ON 

INSERT [dbo].[tbl_unknow] ([memid], [Knowname], [Baptismialname], [DOB], [DOB1], [Feastday], [Bloodgroup], [emailid], [mobilenumber], [whatsappnumber], [facebookid], [twitterid], [blog], [house], [city], [district], [state], [pin], [adhar], [pan], [passport], [nameonadhar], [nameonpan], [nameonpassport], [File1], [File2], [File3]) VALUES (50, N'tfh       ', N'fgjc      ', N'fgjc      ', N'fgj       ', N'fgj       ', N'fjg       ', N'fgj       ', N'gfj       ', N'gfj       ', N'fgj       ', N'fgj       ', N'gjfx      ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_unknow] OFF
SET IDENTITY_INSERT [dbo].[tbl_UserLogin] ON 

INSERT [dbo].[tbl_UserLogin] ([LoginId], [Username], [UserPassword], [UserRole], [Spare1], [Spare2], [Spare3]) VALUES (1, N'admin', N'admin', N'admin', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_UserLogin] OFF
SET IDENTITY_INSERT [dbo].[tbl_VocationPromotionDoc] ON 

INSERT [dbo].[tbl_VocationPromotionDoc] ([VocationPromotionId], [DoccumentName], [Title], [Date], [File]) VALUES (2, N'Formation', N'gew', N'02/01/2019', N'754158f1-7693-4c64-840c-4080d7497a4e.png')
SET IDENTITY_INSERT [dbo].[tbl_VocationPromotionDoc] OFF
/****** Object:  Index [UQ__tbl_Pers__63B46EE7D0226489]    Script Date: 10-Jun-19 10:01:23 AM ******/
ALTER TABLE [dbo].[tbl_PersonalDetails] ADD  CONSTRAINT [UQ__tbl_Pers__63B46EE7D0226489] UNIQUE NONCLUSTERED 
(
	[PersonalDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DocumentContent] ADD  CONSTRAINT [DF_DocumentContent_Filesentdate]  DEFAULT (getdate()) FOR [Filesentdate]
GO
ALTER TABLE [dbo].[InboxEmail] ADD  CONSTRAINT [DF__InboxEmai__IsDel__76619304]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PersonalDocumentContent] ADD  CONSTRAINT [DF_PersonalDocumentContent_FileSentdate]  DEFAULT (getdate()) FOR [FileSentdate]
GO
ALTER TABLE [dbo].[tbl_EmailAttachement] ADD  CONSTRAINT [DF__tbl_Email__Files__6477ECF3]  DEFAULT (getdate()) FOR [Filesendtime]
GO
ALTER TABLE [dbo].[tbl_EmailAttachement] ADD  CONSTRAINT [DF_tbl_EmailAttachement_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_EmailAttachement] ADD  CONSTRAINT [DF_tbl_EmailAttachement_FileUniqueId]  DEFAULT (newid()) FOR [FileUniqueId]
GO
ALTER TABLE [dbo].[tbl_Emaildata] ADD  CONSTRAINT [DF__tbl_Email__Email__619B8048]  DEFAULT (getdate()) FOR [Emailsentdate]
GO
ALTER TABLE [dbo].[tbl_Emaildata] ADD  CONSTRAINT [DF_tbl_Emaildata_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Emaildata] ADD  CONSTRAINT [DF_tbl_Emaildata_IsImportant]  DEFAULT ((0)) FOR [IsImportant]
GO
ALTER TABLE [dbo].[InboxEmailAttachment]  WITH CHECK ADD  CONSTRAINT [FK_EmailAttachment_Email] FOREIGN KEY([InboxEmailID])
REFERENCES [dbo].[InboxEmail] ([ID])
GO
ALTER TABLE [dbo].[InboxEmailAttachment] CHECK CONSTRAINT [FK_EmailAttachment_Email]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__534D60F1] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__534D60F1]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5441852A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5441852A]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5535A963] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5535A963]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5629CD9C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5629CD9C]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__571DF1D5] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__571DF1D5]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5812160E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5812160E]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__59063A47] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__59063A47]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__59FA5E80] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__59FA5E80]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5AEE82B9] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5AEE82B9]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5BE2A6F2] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5BE2A6F2]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5CD6CB2B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5CD6CB2B]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5DCAEF64] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5DCAEF64]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5EBF139D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5EBF139D]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__5FB337D6] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__5FB337D6]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__60A75C0F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__60A75C0F]
GO
ALTER TABLE [dbo].[tbl_Complaint]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Compl__Membe__619B8048] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Complaint] CHECK CONSTRAINT [FK__tbl_Compl__Membe__619B8048]
GO
ALTER TABLE [dbo].[tbl_EmailAttachement]  WITH CHECK ADD  CONSTRAINT [FK_tbl_EmailAttachement_tbl_EmailAttachement1] FOREIGN KEY([EmailUniqueId])
REFERENCES [dbo].[tbl_Emaildata] ([EmailUniqueId])
GO
ALTER TABLE [dbo].[tbl_EmailAttachement] CHECK CONSTRAINT [FK_tbl_EmailAttachement_tbl_EmailAttachement1]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6383C8BA] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6383C8BA]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6477ECF3] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6477ECF3]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__656C112C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__656C112C]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__66603565] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__66603565]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6754599E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6754599E]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__68487DD7] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__68487DD7]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__693CA210] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__693CA210]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6A30C649] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6A30C649]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6B24EA82] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6B24EA82]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6C190EBB] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6C190EBB]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6D0D32F4] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6D0D32F4]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6E01572D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6E01572D]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6EF57B66] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6EF57B66]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__6FE99F9F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__6FE99F9F]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__70DDC3D8] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__70DDC3D8]
GO
ALTER TABLE [dbo].[tbl_EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Emerg__Membe__71D1E811] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EmergencyContact] CHECK CONSTRAINT [FK__tbl_Emerg__Membe__71D1E811]
GO
ALTER TABLE [dbo].[tbl_Entry]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__54CB950F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Entry] CHECK CONSTRAINT [FK__tbl_Entry__Membe__54CB950F]
GO
ALTER TABLE [dbo].[tbl_Entry]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__55BFB948] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Entry] CHECK CONSTRAINT [FK__tbl_Entry__Membe__55BFB948]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__02084FDA] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__02084FDA]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__02FC7413] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__02FC7413]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__03F0984C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__03F0984C]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__04E4BC85] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__04E4BC85]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__05D8E0BE] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__05D8E0BE]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__06CD04F7] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__06CD04F7]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__07C12930] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__07C12930]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__08B54D69] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__08B54D69]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__09A971A2] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__09A971A2]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__0A9D95DB] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__0A9D95DB]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__0B91BA14] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__0B91BA14]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__0C85DE4D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__0C85DE4D]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__0D7A0286] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__0D7A0286]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__0E6E26BF] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__0E6E26BF]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__0F624AF8] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__0F624AF8]
GO
ALTER TABLE [dbo].[tbl_EntryLife]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__10566F31] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife] CHECK CONSTRAINT [FK__tbl_Entry__Membe__10566F31]
GO
ALTER TABLE [dbo].[tbl_EntryLife1]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__114A936A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife1] CHECK CONSTRAINT [FK__tbl_Entry__Membe__114A936A]
GO
ALTER TABLE [dbo].[tbl_EntryLife1]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Entry__Membe__123EB7A3] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_EntryLife1] CHECK CONSTRAINT [FK__tbl_Entry__Membe__123EB7A3]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__1332DBDC] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__1332DBDC]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__14270015] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__14270015]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__151B244E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__151B244E]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__160F4887] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__160F4887]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__17036CC0] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__17036CC0]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__17F790F9] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__17F790F9]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__18EBB532] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__18EBB532]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__19DFD96B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__19DFD96B]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__1AD3FDA4] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__1AD3FDA4]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__1BC821DD] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__1BC821DD]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__1CBC4616] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__1CBC4616]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__1DB06A4F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__1DB06A4F]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__1EA48E88] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__1EA48E88]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__1F98B2C1] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__1F98B2C1]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__208CD6FA] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__208CD6FA]
GO
ALTER TABLE [dbo].[tbl_Health]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Healt__Membe__2180FB33] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Health] CHECK CONSTRAINT [FK__tbl_Healt__Membe__2180FB33]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__22751F6C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__22751F6C]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__236943A5] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__236943A5]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__245D67DE] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__245D67DE]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__25518C17] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__25518C17]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2645B050] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2645B050]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2739D489] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2739D489]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__282DF8C2] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__282DF8C2]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__29221CFB] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__29221CFB]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2A164134] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2A164134]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2B0A656D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2B0A656D]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2BFE89A6] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2BFE89A6]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2CF2ADDF] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2CF2ADDF]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2DE6D218] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2DE6D218]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2EDAF651] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2EDAF651]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__2FCF1A8A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__2FCF1A8A]
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit]  WITH CHECK ADD  CONSTRAINT [FK__tbl_HomeL__Membe__30C33EC3] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_HomeLiveAndHomeVisit] CHECK CONSTRAINT [FK__tbl_HomeL__Membe__30C33EC3]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__31B762FC] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__31B762FC]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__32AB8735] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__32AB8735]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__339FAB6E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__339FAB6E]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3493CFA7] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3493CFA7]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3587F3E0] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3587F3E0]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__367C1819] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__367C1819]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__37703C52] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__37703C52]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3864608B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3864608B]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__395884C4] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__395884C4]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3A4CA8FD] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3A4CA8FD]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3B40CD36] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3B40CD36]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3C34F16F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3C34F16F]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3D2915A8] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3D2915A8]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3E1D39E1] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3E1D39E1]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__3F115E1A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__3F115E1A]
GO
ALTER TABLE [dbo].[tbl_Jubilee]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Jubil__Membe__40058253] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Jubilee] CHECK CONSTRAINT [FK__tbl_Jubil__Membe__40058253]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__40F9A68C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__40F9A68C]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__41EDCAC5] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__41EDCAC5]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__42E1EEFE] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__42E1EEFE]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__43D61337] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__43D61337]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__44CA3770] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__44CA3770]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__45BE5BA9] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__45BE5BA9]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__46B27FE2] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__46B27FE2]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__47A6A41B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__47A6A41B]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__489AC854] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__489AC854]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__498EEC8D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__498EEC8D]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__4A8310C6] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__4A8310C6]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__4B7734FF] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__4B7734FF]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__4C6B5938] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__4C6B5938]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__4D5F7D71] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__4D5F7D71]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__4E53A1AA] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__4E53A1AA]
GO
ALTER TABLE [dbo].[tbl_KnownLanguages]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Known__Membe__4F47C5E3] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_KnownLanguages] CHECK CONSTRAINT [FK__tbl_Known__Membe__4F47C5E3]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__503BEA1C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__503BEA1C]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__51300E55] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__51300E55]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__5224328E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__5224328E]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__531856C7] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__531856C7]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__540C7B00] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__540C7B00]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__55009F39] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__55009F39]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__55F4C372] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__55F4C372]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__56E8E7AB] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__56E8E7AB]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__57DD0BE4] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__57DD0BE4]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__58D1301D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__58D1301D]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__59C55456] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__59C55456]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__5AB9788F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__5AB9788F]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__5BAD9CC8] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__5BAD9CC8]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__5CA1C101] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__5CA1C101]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__5D95E53A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__5D95E53A]
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Livin__Membe__5E8A0973] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_LivingOutsideTheCongregation] CHECK CONSTRAINT [FK__tbl_Livin__Membe__5E8A0973]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__5F7E2DAC] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__5F7E2DAC]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__607251E5] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__607251E5]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__6166761E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__6166761E]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__625A9A57] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__625A9A57]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__634EBE90] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__634EBE90]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__6442E2C9] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__6442E2C9]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__65370702] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__65370702]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__662B2B3B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__662B2B3B]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__671F4F74] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__671F4F74]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__681373AD] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__681373AD]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__690797E6] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__690797E6]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__69FBBC1F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__69FBBC1F]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__6AEFE058] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__6AEFE058]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__6BE40491] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__6BE40491]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__6CD828CA] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__6CD828CA]
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Relig__Membe__6DCC4D03] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ReligiousEducation] CHECK CONSTRAINT [FK__tbl_Relig__Membe__6DCC4D03]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__6EC0713C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__6EC0713C]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__6FB49575] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__6FB49575]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__70A8B9AE] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__70A8B9AE]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__719CDDE7] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__719CDDE7]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__72910220] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__72910220]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__73852659] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__73852659]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__74794A92] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__74794A92]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__756D6ECB] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__756D6ECB]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__76619304] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__76619304]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__7755B73D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__7755B73D]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__7849DB76] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__7849DB76]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__793DFFAF] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__793DFFAF]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__7A3223E8] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__7A3223E8]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__7B264821] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__7B264821]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__7C1A6C5A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__7C1A6C5A]
GO
ALTER TABLE [dbo].[tbl_Retirement]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Retir__Membe__7D0E9093] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Retirement] CHECK CONSTRAINT [FK__tbl_Retir__Membe__7D0E9093]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__0D44F85C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__0D44F85C]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__0E391C95] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__0E391C95]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__0F2D40CE] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__0F2D40CE]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__10216507] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__10216507]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__11158940] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__11158940]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__1209AD79] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__1209AD79]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__12FDD1B2] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__12FDD1B2]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__13F1F5EB] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__13F1F5EB]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__14E61A24] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__14E61A24]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__15DA3E5D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__15DA3E5D]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__16CE6296] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__16CE6296]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__17C286CF] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__17C286CF]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__18B6AB08] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__18B6AB08]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__19AACF41] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__19AACF41]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__1A9EF37A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__1A9EF37A]
GO
ALTER TABLE [dbo].[tbl_Seminar]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Semin__Membe__1B9317B3] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_Seminar] CHECK CONSTRAINT [FK__tbl_Semin__Membe__1B9317B3]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__1C873BEC] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__1C873BEC]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__1D7B6025] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__1D7B6025]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__1E6F845E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__1E6F845E]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__1F63A897] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__1F63A897]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__2057CCD0] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__2057CCD0]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__214BF109] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__214BF109]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__22401542] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__22401542]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__2334397B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__2334397B]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__24285DB4] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__24285DB4]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__251C81ED] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__251C81ED]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__2610A626] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__2610A626]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__2704CA5F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__2704CA5F]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__27F8EE98] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__27F8EE98]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__28ED12D1] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__28ED12D1]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__29E1370A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__29E1370A]
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Seper__Membe__2AD55B43] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_SeperationFromTheCongregation] CHECK CONSTRAINT [FK__tbl_Seper__Membe__2AD55B43]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__2BC97F7C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__2BC97F7C]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__2CBDA3B5] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__2CBDA3B5]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__2DB1C7EE] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__2DB1C7EE]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__2EA5EC27] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__2EA5EC27]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__2F9A1060] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__2F9A1060]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__308E3499] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__308E3499]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__318258D2] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__318258D2]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__32767D0B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__32767D0B]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__336AA144] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__336AA144]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__345EC57D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__345EC57D]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__3552E9B6] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__3552E9B6]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__36470DEF] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__36470DEF]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__373B3228] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__373B3228]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__382F5661] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__382F5661]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__39237A9A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__39237A9A]
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Servi__Membe__3A179ED3] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_ServiceInTheCongregation] CHECK CONSTRAINT [FK__tbl_Servi__Membe__3A179ED3]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__3B0BC30C] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__3B0BC30C]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__3BFFE745] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__3BFFE745]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__3CF40B7E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__3CF40B7E]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__3DE82FB7] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__3DE82FB7]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__3EDC53F0] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__3EDC53F0]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__3FD07829] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__3FD07829]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__40C49C62] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__40C49C62]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__41B8C09B] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__41B8C09B]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__42ACE4D4] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__42ACE4D4]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__43A1090D] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__43A1090D]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__44952D46] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__44952D46]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__4589517F] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__4589517F]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__467D75B8] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__467D75B8]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__477199F1] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__477199F1]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__4865BE2A] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__4865BE2A]
GO
ALTER TABLE [dbo].[tbl_TravelRecord]  WITH CHECK ADD  CONSTRAINT [FK__tbl_Trave__Membe__4959E263] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tbl_PersonalDetails] ([MemberID])
GO
ALTER TABLE [dbo].[tbl_TravelRecord] CHECK CONSTRAINT [FK__tbl_Trave__Membe__4959E263]
GO
/****** Object:  StoredProcedure [dbo].[addAttachment]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addAttachment]
@FileName varchar(2000),
@FileContent varbinary(max),
@FileMIMEtype varchar(2000),
@FileExtension varchar(5),
@EmailUniqueId uniqueidentifier
as
BEGIN
DECLARE @filecreatedDate datetime = GetDate()
insert into tbl_EmailAttachement(attchedfilename,FileContent,FileMIMEtype,FileExtension,Filesendtime,EmailUniqueId)values(@FileName,@FileContent,@FileMIMEtype,@FileExtension,@filecreatedDate,@EmailUniqueId)
END
GO
/****** Object:  StoredProcedure [dbo].[AddEmailData]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddEmailData]
@EmailUniqueId uniqueidentifier,
@EmailSubject nvarchar(2000),
@EmailBody nvarchar(2000),
@ToAddress nvarchar(2000),
@CCAddress nvarchar(2000),
@BCCAddress nvarchar(2000),
@Admin nvarchar(2000),
@IsImportant bit =0

   
as
BEGIN
DECLARE @createdDate datetime = GetDate()
Insert into tbl_Emaildata(EmailUniqueId,EmailSubject,EmailBody,ToAddress,CCAddress,BCCAddress,Emailsentdate,[Admin],IsImportant)values(@EmailUniqueId,@EmailSubject,@EmailBody,@ToAddress,@CCAddress,@BCCAddress,@createdDate,@Admin,@IsImportant)


END
GO
/****** Object:  StoredProcedure [dbo].[addSMSContent]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[addSMSContent]
@Feast varchar(1000),
@Content nvarchar(256),
@Status nvarchar(10),
@Spare nvarchar(35)
as 
BEGIN
INSERT INTO [dbo].[tbl_SMSContent](Feast,Content,[Status],Spare)VALUES(@Feast,@Content,@Status,@Spare)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteByEmailId]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteByEmailId]
@EmailUniqueId uniqueidentifier
as
begin
declare @count int
select @count=count(*) from tbl_EmailAttachement where EmailUniqueId=@EmailUniqueId
if(@count>0)
begin
--delete from tbl_EmailAttachement where EmailId=@EmailId
update tbl_EmailAttachement set IsDeleted=1 where  EmailUniqueId=@EmailUniqueId
end


--delete from tbl_Emaildata where tbl_Emaildata.EmailId=@EmailId
update tbl_Emaildata set IsDeleted=1 where  EmailUniqueId=@EmailUniqueId

end
GO
/****** Object:  StoredProcedure [dbo].[deleteSMSContent]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[deleteSMSContent]
@ContentId int
AS
BEGIN
delete from  tbl_SMSContent where [ContentId]=@ContentId
END
GO
/****** Object:  StoredProcedure [dbo].[GetDataByMailId]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetDataByMailId](
@EmailUniqueId uniqueidentifier)
as
BEGIN
declare @count int
select  @count=count(EmailUniqueId) from tbl_Emaildata where EmailUniqueId=@EmailUniqueId
if(@count>0)
Select ROW_NUMBER() OVER(order by e.EmailUniqueId desc) as Slno,e.EmailUniqueId,ROW_NUMBER() over(partition by t.EmailUniqueId order by e.Emailsentdate) as FileSlno,(select count(*) from tbl_EmailAttachement where EmailUniqueId=t.EmailUniqueId) as FileCount,e.EmailSubject,e.EmailBody,e.ToAddress,e.[Admin],t.FileUniqueId,t.attchedfilename,t.FileContent,t.FileExtension,t.FileMIMEtype,t.Filesendtime from tbl_Emaildata e join tbl_EmailAttachement t on e.EmailUniqueId=t.EmailUniqueId  where e.EmailUniqueId=@EmailUniqueId order by e.Emailsentdate desc
END


--/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT TOP 1000 [EmailId]
--      ,[EmailSubject]
--      ,[EmailBody]
--      ,[ToAddress]
--      ,[Admin]
--      ,[Emailsentdate]
--      ,[IsDeleted]
--      ,[EmailUniqueId]
--      ,[CCAddress]
--      ,[BCCAddress]
--      ,[IsImportant]
--  FROM [Fathers].[dbo].[tbl_Emaildata]
GO
/****** Object:  StoredProcedure [dbo].[GetEmailWithFileCount]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetEmailWithFileCount]
as
BEGIN
Select ROW_NUMBER() OVER(order by Emailsentdate desc) as Slno,*,(select count(*) from tbl_EmailAttachement where EmailUniqueId=tbl_Emaildata.EmailUniqueId and IsDeleted=0) as FileCount from tbl_Emaildata where IsDeleted=0 order by Slno asc
END
GO
/****** Object:  StoredProcedure [dbo].[GetFileDataByFileId]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFileDataByFileId]
 @FileUniqueId uniqueidentifier
as
BEGIN
SELECT * FROM tbl_EmailAttachement where FileUniqueId=@FileUniqueId and IsDeleted=0
END
GO
/****** Object:  StoredProcedure [dbo].[GetInboxByMailId]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[GetInboxByMailId](
@InboxEmailID uniqueidentifier)
as
BEGIN
select  ROW_NUMBER() OVER(order by e.EmailDate desc) as Slno,ROW_NUMBER() over(partition by t.InboxEmailID order by e.EmailDate) as FileSlno,(select count(t.InboxEmailID) from [InboxEmailAttachment] t where t.InboxEmailID =@InboxEmailID) as FileCount,e.*,t.InboxEmailID,t.Attachment,t.[Filename],t.ID as FileId from InboxEmail e join InboxEmailAttachment  t on t.InboxEmailID =e.ID where t.InboxEmailID=@InboxEmailID and e.IsDeleted=0 order by e.EmailDate
END
GO
/****** Object:  StoredProcedure [dbo].[updateSMSContent]    Script Date: 10-Jun-19 10:01:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[updateSMSContent]
@ContentId int,
@Feast varchar(1000),
@Content nvarchar(256),
@Status nvarchar(10),
@Spare nvarchar(35)
AS
BEGIN
update tbl_SMSContent set Feast=@Feast,Content=@Content,[Status]=@Status,Spare=@Spare where [ContentId]=@ContentId
END
GO
USE [master]
GO
ALTER DATABASE [Fathers30May] SET  READ_WRITE 
GO
