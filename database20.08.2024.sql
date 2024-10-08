USE [master]
GO
/****** Object:  Database [Wolf.Data]    Script Date: 20.8.2024 г. 12:02:58 ******/
CREATE DATABASE [Wolf.Data]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Wolf.Data', FILENAME = N'/var/opt/mssql/data/Wolf.Data.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Wolf.Data_log', FILENAME = N'/var/opt/mssql/data/Wolf.Data_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Wolf.Data] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Wolf.Data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Wolf.Data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Wolf.Data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Wolf.Data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Wolf.Data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Wolf.Data] SET ARITHABORT OFF 
GO
ALTER DATABASE [Wolf.Data] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Wolf.Data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Wolf.Data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Wolf.Data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Wolf.Data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Wolf.Data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Wolf.Data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Wolf.Data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Wolf.Data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Wolf.Data] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Wolf.Data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Wolf.Data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Wolf.Data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Wolf.Data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Wolf.Data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Wolf.Data] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Wolf.Data] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Wolf.Data] SET RECOVERY FULL 
GO
ALTER DATABASE [Wolf.Data] SET  MULTI_USER 
GO
ALTER DATABASE [Wolf.Data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Wolf.Data] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Wolf.Data] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Wolf.Data] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Wolf.Data] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Wolf.Data] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Wolf.Data', N'ON'
GO
ALTER DATABASE [Wolf.Data] SET QUERY_STORE = OFF
GO
USE [Wolf.Data]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[ActivityId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL,
	[ActivityTypeID] [int] NOT NULL,
	[ExpectedDuration] [datetime2](7) NOT NULL,
	[ParentActivityId] [int] NULL,
	[ExecutantId] [int] NOT NULL,
	[employeePayment] [real] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activity_PlotRelashionships]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity_PlotRelashionships](
	[ActivityId] [int] NOT NULL,
	[PlotId] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Activity_PlotRelashionships] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC,
	[PlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[activityTypes]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[activityTypes](
	[ActivityTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityTypeName] [nvarchar](max) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_activityTypes] PRIMARY KEY CLUSTERED 
(
	[ActivityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_RequestRelashionships]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client_RequestRelashionships](
	[RequestId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[OwnershipType] [nvarchar](max) NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Client_RequestRelashionships] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ClientLegalType] [nvarchar](max) NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentOfOwnership_OwnerRelashionships]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentOfOwnership_OwnerRelashionships](
	[DocumentOwnerID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentID] [int] NOT NULL,
	[OwnerID] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_DocumentOfOwnership_OwnerRelashionships] PRIMARY KEY CLUSTERED 
(
	[DocumentOwnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[documentPlot_DocumentOwenerRelashionships]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[documentPlot_DocumentOwenerRelashionships](
	[DocumentPlotId] [int] NOT NULL,
	[DocumentOwnerID] [int] NOT NULL,
	[IdealParts] [real] NOT NULL,
	[WayOfAcquiring] [nvarchar](max) NOT NULL,
	[isDrob] [bit] NOT NULL,
	[PowerOfAttorneyId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_documentPlot_DocumentOwenerRelashionships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentsOfOwnership]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentsOfOwnership](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfDocument] [nvarchar](max) NOT NULL,
	[NumberOfDocument] [nvarchar](max) NOT NULL,
	[Issuer] [nvarchar](max) NOT NULL,
	[TOM] [int] NOT NULL,
	[register] [nvarchar](max) NOT NULL,
	[DocCase] [nvarchar](max) NOT NULL,
	[DateOfIssuing] [datetime2](7) NOT NULL,
	[DateOfRegistering] [datetime2](7) NOT NULL,
	[TypeOfOwnership] [nvarchar](max) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_DocumentsOfOwnership] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[SecondName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[files]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[files](
	[FileId] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[UploadedAt] [datetime2](7) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_files] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL,
	[Sum] [real] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[number] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[OwnerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[EGN] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[OwnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plot_DocumentOfOwnerships]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plot_DocumentOfOwnerships](
	[DocumentPlotId] [int] IDENTITY(1,1) NOT NULL,
	[PlotId] [int] NOT NULL,
	[DocumentOfOwnershipId] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Plot_DocumentOfOwnerships] PRIMARY KEY CLUSTERED 
(
	[DocumentPlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plots]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plots](
	[PlotId] [int] IDENTITY(1,1) NOT NULL,
	[PlotNumber] [nvarchar](max) NOT NULL,
	[RegulatedPlotNumber] [nvarchar](max) NULL,
	[neighborhood] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Municipality] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[StreetNumber] [int] NULL,
	[designation] [nvarchar](max) NOT NULL,
	[locality] [nvarchar](max) NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Plots] PRIMARY KEY CLUSTERED 
(
	[PlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[powerOfAttorneyDocuments]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[powerOfAttorneyDocuments](
	[PowerOfAttorneyId] [int] IDENTITY(1,1) NOT NULL,
	[number] [nvarchar](max) NOT NULL,
	[dateOfIssuing] [datetime2](7) NOT NULL,
	[Issuer] [nvarchar](max) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_powerOfAttorneyDocuments] PRIMARY KEY CLUSTERED 
(
	[PowerOfAttorneyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestName] [nvarchar](max) NOT NULL,
	[Price] [real] NOT NULL,
	[PaymentStatus] [nvarchar](max) NOT NULL,
	[Advance] [real] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Path] [nvarchar](max) NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[starRequest_EmployeeRelashionships]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[starRequest_EmployeeRelashionships](
	[RequestId] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_starRequest_EmployeeRelashionships] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[Duration] [time](7) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[ExecutantId] [int] NOT NULL,
	[ControlId] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[TaskTypeId] [int] NOT NULL,
	[CommentTax] [nvarchar](max) NOT NULL,
	[executantPayment] [real] NOT NULL,
	[tax] [real] NOT NULL,
	[FinishDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taskTypes]    Script Date: 20.8.2024 г. 12:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taskTypes](
	[TaskTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TaskTypeName] [nvarchar](max) NOT NULL,
	[ActivityTypeID] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_taskTypes] PRIMARY KEY CLUSTERED 
(
	[TaskTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240703130839_Initial', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704134112_Added isDrobColum', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240708062741_TypeOfOwnership Added', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240710153721_Files', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240711115115_PowerOfattorney', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240711140351_ActivityAndTaskUpdates', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240712085140_ActivityTaskDate', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240712105029_ChangedStatus', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240715103824_PlotOwnerPrimaryKey', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240718123230_RowVersion', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240725115216_ApplicationUserExtended', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240726094811_StarRequestModel', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240729131840_AddPath', N'6.0.29')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240730065306_InvoiceNumber', N'6.0.29')
GO
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (9, 11, 1, CAST(N'2024-08-09T08:26:04.9191301' AS DateTime2), NULL, 2, 0, CAST(N'2024-08-09T08:26:30.0441543' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (10, 13, 1, CAST(N'2024-08-12T06:22:03.9104303' AS DateTime2), NULL, 2, 0, CAST(N'2024-08-12T06:22:58.7496816' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (11, 15, 9, CAST(N'2024-08-12T06:39:58.5146421' AS DateTime2), NULL, 7, 200, CAST(N'2024-08-12T06:42:59.1399434' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (12, 18, 6, CAST(N'2024-08-12T06:54:22.1230500' AS DateTime2), NULL, 7, 0, CAST(N'2024-08-12T06:55:44.4626317' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (13, 17, 23, CAST(N'2024-08-12T06:52:44.6887570' AS DateTime2), NULL, 2, 0, CAST(N'2024-08-12T06:56:58.5192251' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (14, 17, 1, CAST(N'2024-08-12T06:58:05.0609536' AS DateTime2), NULL, 2, 0, CAST(N'2024-08-12T06:59:05.9503252' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (15, 19, 3, CAST(N'2024-08-12T06:58:59.8326040' AS DateTime2), NULL, 7, 120, CAST(N'2024-08-12T06:59:40.6628803' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (16, 16, 12, CAST(N'2024-08-12T06:46:30.5197599' AS DateTime2), NULL, 8, 250, CAST(N'2024-08-12T06:55:44.3879581' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (17, 16, 18, CAST(N'2024-08-12T06:56:03.2834883' AS DateTime2), NULL, 8, 1500, CAST(N'2024-08-12T06:57:31.4866950' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (19, 20, 6, CAST(N'2024-08-12T07:04:03.8450040' AS DateTime2), NULL, 7, 0, CAST(N'2024-08-12T07:05:19.3621665' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (20, 21, 14, CAST(N'2024-08-12T07:50:11.2060349' AS DateTime2), NULL, 8, 0, CAST(N'2024-08-12T07:56:11.1655875' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (21, 21, 5, CAST(N'2024-08-12T07:56:31.6658470' AS DateTime2), NULL, 8, 0, CAST(N'2024-08-12T07:57:50.8588393' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (22, 14, 23, CAST(N'2024-08-12T08:04:52.3266454' AS DateTime2), NULL, 2, 0, CAST(N'2024-08-12T08:05:12.4558371' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (23, 22, 4, CAST(N'2024-08-12T08:10:09.9300692' AS DateTime2), NULL, 8, 500, CAST(N'2024-08-12T08:11:43.0231242' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (24, 22, 5, CAST(N'2024-08-12T08:14:22.0541695' AS DateTime2), NULL, 8, 450, CAST(N'2024-08-12T08:16:01.2101396' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (26, 24, 25, CAST(N'2024-08-12T08:33:13.2094888' AS DateTime2), NULL, 8, 1, CAST(N'2024-08-12T08:34:53.4831595' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (27, 25, 12, CAST(N'2024-08-12T08:40:53.3673031' AS DateTime2), NULL, 8, 1, CAST(N'2024-08-12T08:42:16.2313842' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (28, 26, 7, CAST(N'2024-08-12T10:16:25.4325471' AS DateTime2), NULL, 8, 200, CAST(N'2024-08-12T10:17:24.1550044' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (29, 26, 1, CAST(N'2024-08-12T10:17:27.2036115' AS DateTime2), NULL, 8, 400, CAST(N'2024-08-12T10:18:55.2063899' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (30, 26, 23, CAST(N'2024-08-12T10:19:01.0317609' AS DateTime2), NULL, 8, 0, CAST(N'2024-08-12T10:20:03.1355007' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (31, 27, 23, CAST(N'2024-08-15T13:02:45.0000000' AS DateTime2), NULL, 8, 450, CAST(N'2024-08-12T13:04:01.6256218' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (32, 28, 2, CAST(N'2024-08-12T13:06:48.1382363' AS DateTime2), NULL, 8, 250, CAST(N'2024-08-12T13:07:49.5409247' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (33, 29, 5, CAST(N'2024-08-12T13:11:32.7185536' AS DateTime2), NULL, 8, 250, CAST(N'2024-08-12T13:12:04.4105014' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (34, 30, 3, CAST(N'2024-08-13T06:03:11.9695338' AS DateTime2), NULL, 7, 250, CAST(N'2024-08-13T06:03:43.4610739' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (35, 31, 18, CAST(N'2024-08-13T06:59:14.8675309' AS DateTime2), NULL, 8, 250, CAST(N'2024-08-13T07:00:18.5091837' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (36, 32, 4, CAST(N'2024-08-13T07:33:32.8213841' AS DateTime2), NULL, 7, 450, CAST(N'2024-08-13T07:34:05.8206683' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (37, 33, 4, CAST(N'2024-09-15T08:20:48.0000000' AS DateTime2), NULL, 7, 450, CAST(N'2024-08-13T08:22:08.4220411' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (40, 35, 23, CAST(N'2024-08-13T11:46:57.3574493' AS DateTime2), NULL, 2, 0, CAST(N'2024-08-13T11:48:44.2927850' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (43, 36, 23, CAST(N'2024-08-13T12:37:31.4846754' AS DateTime2), NULL, 2, 3300, CAST(N'2024-08-13T12:41:28.3118306' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (44, 34, 1, CAST(N'2024-08-13T12:44:54.1839062' AS DateTime2), NULL, 8, 0, CAST(N'2024-08-13T12:45:25.1114714' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (45, 37, 1, CAST(N'2024-08-13T13:41:22.3916445' AS DateTime2), NULL, 2, 650, CAST(N'2024-08-13T13:42:32.6446289' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (46, 40, 1, CAST(N'2024-08-13T13:58:12.7067830' AS DateTime2), NULL, 8, 0, CAST(N'2024-08-13T13:59:10.9374449' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (48, 45, 23, CAST(N'2024-08-14T07:06:49.2615035' AS DateTime2), NULL, 8, 450, CAST(N'2024-08-14T07:08:42.1734560' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (50, 46, 10, CAST(N'2024-08-14T08:32:22.1895412' AS DateTime2), NULL, 2, 100, CAST(N'2024-08-14T08:33:07.0786613' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (51, 47, 6, CAST(N'2024-08-14T08:48:38.9859102' AS DateTime2), NULL, 7, 0, CAST(N'2024-08-14T08:49:28.8864482' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (54, 49, 3, CAST(N'2024-08-14T09:02:37.8462994' AS DateTime2), NULL, 7, 200, CAST(N'2024-08-14T09:03:01.9159910' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (55, 50, 4, CAST(N'2024-08-14T12:35:37.6334667' AS DateTime2), NULL, 7, 450, CAST(N'2024-08-14T12:36:11.9392613' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (56, 51, 4, CAST(N'2024-08-14T12:39:48.4351750' AS DateTime2), NULL, 7, 450, CAST(N'2024-08-14T12:40:26.4038313' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (59, 52, 2, CAST(N'2024-08-16T07:59:41.1104825' AS DateTime2), NULL, 8, 250, CAST(N'2024-08-16T08:00:03.1328116' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (60, 53, 23, CAST(N'2024-09-06T09:37:10.0000000' AS DateTime2), NULL, 8, 3350, CAST(N'2024-08-16T09:37:51.0000000' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (61, 54, 1, CAST(N'2024-03-29T13:05:18.0000000' AS DateTime2), NULL, 8, 550, CAST(N'2024-03-29T10:08:25.0000000' AS DateTime2))
INSERT [dbo].[Activities] ([ActivityId], [RequestId], [ActivityTypeID], [ExpectedDuration], [ParentActivityId], [ExecutantId], [employeePayment], [StartDate]) VALUES (62, 54, 23, CAST(N'2024-07-09T10:14:02.0000000' AS DateTime2), NULL, 8, 30, CAST(N'2024-07-09T10:15:19.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Activities] OFF
GO
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (10, 3)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (37, 6)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (40, 8)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (40, 9)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (40, 10)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (44, 11)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (23, 12)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (43, 13)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (33, 14)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (48, 15)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (51, 16)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (11, 17)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (12, 18)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (19, 19)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (54, 20)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (55, 21)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (56, 22)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (36, 23)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (34, 24)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (15, 25)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (46, 26)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (59, 27)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (28, 28)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (16, 29)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (20, 30)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (27, 31)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (32, 32)
INSERT [dbo].[Activity_PlotRelashionships] ([ActivityId], [PlotId]) VALUES (60, 33)
GO
SET IDENTITY_INSERT [dbo].[activityTypes] ON 

INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (1, N'Проект за изменение на КК')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (2, N'Комбинирана скица')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (3, N'Трасиране на имот')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (4, N'Заснемане по чл.54а ЗКИР')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (5, N'Изработване на ССО')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (6, N'Снимка за проектиране')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (7, N'Заснемане на обект /ограда, сграда/ за проверка')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (8, N'Заснемоне по чл.116 ЗУТ / линейни обекти/')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (9, N'Заснемане на обект чл.159 ЗУТ /за съответствие/')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (10, N'Издаване на скица')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (11, N'Издаване на удостоверение с характеристики на имота')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (12, N'Заснемане на обект § 16 ПР ЗУТ /за търпимост/')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (13, N'Заснемане на обект чрез фотограметрия')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (14, N'Архитектурно заснемане на обект')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (15, N'Трасиране на сграда')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (16, N'Трасиране на линеен обект')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (17, N'Част геодезия към инвестиционен проект')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (18, N'Схема за монтаж')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (19, N'Трасировъчен план за допълващо застрояване')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (20, N'Трасировъчен план за оград')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (21, N'Изменение на КРНИ')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (22, N'Изготвяне на  оферта за услуги')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (23, N'Подробен устройствен план')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (24, N'Процедура по промяна на предназначение или препотвърждаване на изтекло решение по чл.17 ЗОЗЗ на имот с влязъл в сила ПУП')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (25, N'Изменение на ПНИ')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (26, N'Изработване на протокол за максимален наклон')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (27, N'Протокол за съборена сграда')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (28, N'Трасировъчен план за линеен обект /ЕЛ, ВиК проводи/')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (29, N'Схема за монтаж на обекти в АПП на морски плажове')
INSERT [dbo].[activityTypes] ([ActivityTypeID], [ActivityTypeName]) VALUES (30, N'Програма за водно спасителна дейност')
SET IDENTITY_INSERT [dbo].[activityTypes] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'admin', N'Admin', N'1')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'user', N'User', N'2')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'028d678a-c4c8-4737-9ee9-f7212beef1fc', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'424d85d9-97a8-433f-b87a-b27d85dd85d3', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'093a7adb-38f2-46cd-a0f3-2af2eb498a45', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'491f4f66-8c11-48d0-8681-6f2e1e6b8553', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5a4b766c-3dee-4fdc-855c-4f65c06940b2', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8c5b23cc-9e41-4be8-8926-bb160abb0c3d', N'2')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmployeeId]) VALUES (N'028d678a-c4c8-4737-9ee9-f7212beef1fc', N'damian', N'DAMIAN', N'damianpetkov@abv.bg', N'DAMIANPETKOV@ABV.BG', 1, N'AQAAAAEAACcQAAAAEOn0x3bAqn8XhwCc1uZ+gtd2e6mY2+OfXUJfB05BK0+NNqJMUxmCYp0khQ1MoZX3Tw==', N'IS63Z64NVDZPAHTB37WXN3R6H55JOP6N', N'ac89a47f-edd6-4957-9054-82ca69379f10', NULL, 0, 0, NULL, 1, 0, 3)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmployeeId]) VALUES (N'093a7adb-38f2-46cd-a0f3-2af2eb498a45', N'Dilyana', N'DILYANA', N'dilyna_kirova@abv.bg', N'DILYNA_KIROVA@ABV.BG', 1, N'AQAAAAEAACcQAAAAEEBJ+THMHSpBuulH0ug0MKtYRgyr/hWXQiLB5SYiT0cOBHvoOothhBt7iQpV/0AdzA==', N'J3UYZ4BFNM7MGIDXIRDD4KKJW3TB4TF7', N'1682137e-00bc-459a-9f86-112f8c5a160f', NULL, 0, 0, NULL, 1, 0, 8)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmployeeId]) VALUES (N'424d85d9-97a8-433f-b87a-b27d85dd85d3', N'Bozhidar', N'BOZHIDAR', N'BDDimitrov18@gmail.com', N'BDDIMITROV18@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEGSGiJ2IekBW29ZHASZ0KW1YdsGaWJa+QQsFGDfyxpe1OgJFysfXpBM21JCWjLPK1w==', N'IJZCQ6QNEOWB3C7WA7FMZFG5N7NQJ644', N'0706a5be-6e07-4bb4-9693-db6817c79dd5', NULL, 0, 0, NULL, 1, 0, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmployeeId]) VALUES (N'491f4f66-8c11-48d0-8681-6f2e1e6b8553', N'BAHKO_1', N'BAHKO_1', N'iv.nedyalkov@abv.bg', N'IV.NEDYALKOV@ABV.BG', 1, N'AQAAAAEAACcQAAAAEHYdAPACsTN7fdgLwZ3wenUZ1f+BjsdM1zGgvZNDXmV8iOieVMwTvLS7PqWikEGoAw==', N'2CUDSZZL5AL6RAKFUDJY6JPPBGXNHAL5', N'be80e4f0-f3a5-49ea-81cc-b164bb289c0a', NULL, 0, 0, NULL, 1, 0, 7)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmployeeId]) VALUES (N'5a4b766c-3dee-4fdc-855c-4f65c06940b2', N'Petar', N'PETAR', N'eng.ivanov.p@gmail.com', N'ENG.IVANOV.P@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAECqcmPLNjyR5HV/Zbd8va8jNohoYW8Z7qkSA4cU4hnJMp+InZI7tsalVt2LxSd1ARA==', N'HMY2BCPTO4J4XVBQ3KZ3IOPAPXAXHJBY', N'60561bf9-5f15-4cfb-a0bb-bdbbe6d5a046', NULL, 0, 0, NULL, 1, 0, 2)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmployeeId]) VALUES (N'8c5b23cc-9e41-4be8-8926-bb160abb0c3d', N'Pafko_1', N'PAFKO_1', N'pafkoni@abv.bg', N'PAFKONI@ABV.BG', 1, N'AQAAAAEAACcQAAAAEAVX0ap/oeGdKaGXh1W17Y1IzR2ggq+b/1kDJkvDGEnjFTrjNoEMhnMPrRzH8P4xwA==', N'JWHHMWBW62C6ZLHLA52NJAWON4UWRAII', N'25edc3c0-1128-4a26-9a9c-1992d1781aff', NULL, 0, 0, NULL, 1, 0, 6)
GO
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (11, 3, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (13, 4, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (14, 5, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (15, 6, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (16, 7, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (18, 8, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (19, 9, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (20, 10, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (21, 11, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (22, 12, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (24, 13, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (25, 14, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (26, 15, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (27, 16, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (28, 17, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (29, 19, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (30, 20, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (31, 21, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (32, 22, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (33, 21, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (34, 24, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (35, 23, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (36, 25, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (37, 26, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (38, 27, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (39, 27, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (39, 28, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (40, 27, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (45, 21, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (46, 29, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (47, 30, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (49, 31, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (50, 32, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (51, 33, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (52, 34, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (53, 35, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (53, 36, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (53, 37, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (53, 38, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (54, 39, NULL)
INSERT [dbo].[Client_RequestRelashionships] ([RequestId], [ClientId], [OwnershipType]) VALUES (54, 40, NULL)
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (1, N'mitko', N'mitko', N'mitko', N'123123123', N'asd@gmail.com', N'asd', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (2, N'Test', N'Test', N'Test', N'0877777777', N'test@gmail.com', N'test 12', N'Юридическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (3, N'Щилян', N'Стоянов', N'Стоянов', N'0896840785', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (4, N'Фросина', N'Митрева', N'Митрева', N'089995942', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (5, N'Стоян', N'Янакиев', N'Василев', N'0888506879', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (6, N'Марян', N'', N'Андонов', N'0882555055', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (7, N'Магда', N'Кирова', N'Пачеманова', N'0898606678', N'camping_breeze@abv.bg', N'р.Царево, ул.Бузлуджа №14', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (8, N'Кирчо', N'', N'Манолчев', N'0898506868', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (9, N'Пламен', N'', N'Петров', N'0888416026', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (10, N'арх. Никола', N'', N'Ликоманов', N'0896689866', N'bsaburgas@abv.bg', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (11, N'Кирчо', N'Георгиев', N'Манолчев', N'0898506868', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (12, N'Невена', N'Лазарова', N'Танева', N'0889429506', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (13, N'Мария', N'', N'Шушмилова', N'0877734449', N'', N'с.Писменово', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (14, N'Тончо ', N'', N'Димитров', N'0894849056', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (15, N'Кремена', N'Георгиева', N'Стоянова', N'0888104581', N'', N'гр.Бургас, ж-к-Меден Рудник, бл.102, вх.4, ет.6, ап.80', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (16, N'"АРАПЯ" ЕООД', N'', N'', N'', N'', N'', N'Юридическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (17, N'Иван', N'', N'Иванов', N'0899688571', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (18, N'ЖУКРИС-МОВИЛ', N'', N'', N'0899899002', N'', N'', N'Юридическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (19, N'Христо', N'', N'Добрев', N'0899899002', N'', N'', N'Юридическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (20, N'Калин', N'', N'Хинов', N'0886611218', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (21, N'Динко', N'Киров', N'Тодоров', N'0877941971', N'kontrolstroy2007@gmail.com', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (22, N'Пенчо', N'', N'Шейтанов', N'0888683799', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (23, N'Атанас', N'Христов', N'Шипков', N'0888206397', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (24, N'Ганчо', N'', N'', N'0889627193', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (25, N'Милчо', N'Коев', N'Жеков', N'0896316867', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (26, N'Иван', N'', N'', N'0897880614', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (27, N'Община Царево', N'', N'', N'', N'otdel.sg@abv.bg', N'гр.Царево, ул.Хан Аспарух 36', N'Общината')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (28, N'Община Царево', N'', N'', N'', N'otdel.sg@abv.bg', N'гр.Царево, ул.Хан Аспарух 36', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (29, N'Димитър', N'', N'Желев', N'0894318332', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (30, N'Петко', N'', N'Гечев', N'0888134705', N'p.p.g@abv.bg', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (31, N'Иван', N'', N'Иванов', N'0886227719', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (32, N'Пейо', N'', N'Баласов', N'0889354422', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (33, N'Ясен', N'', N'Михайлов', N'0899565490', N'', N'', N'Физическо лице')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (34, N'Василка ', N'', N'Григорова', N'0896734219', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (35, N'Бойчо ', N'Грудов', N'Петков', N'', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (36, N'Димо', N'Грудов ', N'Петков', N'', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (37, N'Елена ', N'Стойчева', N'Динкова', N'0886201040', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (38, N'Цвета', N'Стойчева ', N'Стамова', N'0878211844', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (39, N'Георги', N'Стефанов', N'Христов', N'0885723860', N'', N'', N'')
INSERT [dbo].[Clients] ([ClientId], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Address], [ClientLegalType]) VALUES (40, N'Донка ', N'Костова', N'Евтимова', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] ON 

INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] ([DocumentOwnerID], [DocumentID], [OwnerID]) VALUES (1, 1, 1)
INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] ([DocumentOwnerID], [DocumentID], [OwnerID]) VALUES (2, 2, 2)
INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] ([DocumentOwnerID], [DocumentID], [OwnerID]) VALUES (3, 3, 3)
INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] ([DocumentOwnerID], [DocumentID], [OwnerID]) VALUES (4, 4, 4)
INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] ([DocumentOwnerID], [DocumentID], [OwnerID]) VALUES (5, 5, 5)
INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] ([DocumentOwnerID], [DocumentID], [OwnerID]) VALUES (6, 6, 6)
SET IDENTITY_INSERT [dbo].[DocumentOfOwnership_OwnerRelashionships] OFF
GO
SET IDENTITY_INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ON 

INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ([DocumentPlotId], [DocumentOwnerID], [IdealParts], [WayOfAcquiring], [isDrob], [PowerOfAttorneyId], [Id]) VALUES (1, 1, 0.5, N'Дарение', 1, 1, 1)
INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ([DocumentPlotId], [DocumentOwnerID], [IdealParts], [WayOfAcquiring], [isDrob], [PowerOfAttorneyId], [Id]) VALUES (1, 1, 0.75, N'Дарение', 1, 1, 2)
INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ([DocumentPlotId], [DocumentOwnerID], [IdealParts], [WayOfAcquiring], [isDrob], [PowerOfAttorneyId], [Id]) VALUES (2, 2, 870, N'Покупко делба', 0, 2, 3)
INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ([DocumentPlotId], [DocumentOwnerID], [IdealParts], [WayOfAcquiring], [isDrob], [PowerOfAttorneyId], [Id]) VALUES (3, 3, 2124, N'Покупко делба', 0, 3, 4)
INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ([DocumentPlotId], [DocumentOwnerID], [IdealParts], [WayOfAcquiring], [isDrob], [PowerOfAttorneyId], [Id]) VALUES (4, 4, 297.5, N'Покупко делба', 0, 4, 5)
INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ([DocumentPlotId], [DocumentOwnerID], [IdealParts], [WayOfAcquiring], [isDrob], [PowerOfAttorneyId], [Id]) VALUES (5, 5, 1, N'Покупко-продажба', 1, 5, 6)
INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] ([DocumentPlotId], [DocumentOwnerID], [IdealParts], [WayOfAcquiring], [isDrob], [PowerOfAttorneyId], [Id]) VALUES (6, 6, 575, N'Дарение', 0, 6, 7)
SET IDENTITY_INSERT [dbo].[documentPlot_DocumentOwenerRelashionships] OFF
GO
SET IDENTITY_INSERT [dbo].[DocumentsOfOwnership] ON 

INSERT [dbo].[DocumentsOfOwnership] ([DocumentId], [TypeOfDocument], [NumberOfDocument], [Issuer], [TOM], [register], [DocCase], [DateOfIssuing], [DateOfRegistering], [TypeOfOwnership]) VALUES (1, N'нотариален акт', N'22', N'Агенция по Вписвания при РС ', 2, N'22', N'22', CAST(N'2024-08-07T13:57:08.6086538' AS DateTime2), CAST(N'2024-08-07T13:57:08.6086747' AS DateTime2), N'Няма Данни')
INSERT [dbo].[DocumentsOfOwnership] ([DocumentId], [TypeOfDocument], [NumberOfDocument], [Issuer], [TOM], [register], [DocCase], [DateOfIssuing], [DateOfRegistering], [TypeOfOwnership]) VALUES (2, N'нотариален акт', N'149', N'РС - Царево', 2, N'0', N'890', CAST(N'2024-08-09T06:43:44.7668957' AS DateTime2), CAST(N'2024-08-09T06:43:44.7669265' AS DateTime2), N'Частна')
INSERT [dbo].[DocumentsOfOwnership] ([DocumentId], [TypeOfDocument], [NumberOfDocument], [Issuer], [TOM], [register], [DocCase], [DateOfIssuing], [DateOfRegistering], [TypeOfOwnership]) VALUES (3, N'нотариален акт', N'124', N'', 35, N'12048', N'6876', CAST(N'2023-08-18T14:58:22.0000000' AS DateTime2), CAST(N'2023-08-18T14:58:22.0000000' AS DateTime2), N'Частна')
INSERT [dbo].[DocumentsOfOwnership] ([DocumentId], [TypeOfDocument], [NumberOfDocument], [Issuer], [TOM], [register], [DocCase], [DateOfIssuing], [DateOfRegistering], [TypeOfOwnership]) VALUES (4, N'нотариален акт', N'129', N'Агенция по Вписвания при РС ', 2, N'0', N'605', CAST(N'2024-08-13T12:47:51.1846112' AS DateTime2), CAST(N'2024-08-13T12:47:51.1847132' AS DateTime2), N'Частна')
INSERT [dbo].[DocumentsOfOwnership] ([DocumentId], [TypeOfDocument], [NumberOfDocument], [Issuer], [TOM], [register], [DocCase], [DateOfIssuing], [DateOfRegistering], [TypeOfOwnership]) VALUES (5, N'нотариален акт', N'98', N'Агенция по Вписвания при РС ', 11, N'3301', N'2450', CAST(N'2005-12-05T16:28:04.0000000' AS DateTime2), CAST(N'2005-12-05T16:28:04.0000000' AS DateTime2), N'Частна')
INSERT [dbo].[DocumentsOfOwnership] ([DocumentId], [TypeOfDocument], [NumberOfDocument], [Issuer], [TOM], [register], [DocCase], [DateOfIssuing], [DateOfRegistering], [TypeOfOwnership]) VALUES (6, N'нотариален акт', N'190', N'РС-гр.Царево', 1, N'498', N'404', CAST(N'1999-08-05T11:01:39.0000000' AS DateTime2), CAST(N'1999-08-05T11:01:39.0000000' AS DateTime2), N'Частна')
SET IDENTITY_INSERT [dbo].[DocumentsOfOwnership] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [SecondName], [LastName], [phone], [Email]) VALUES (1, N'Божидар', N'Дамянов', N'Димитров', N'0877139712', N'BDDimitrov18@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [SecondName], [LastName], [phone], [Email]) VALUES (2, N'Петър', N'Иванов', N'Иванов', N'0883323249', N'eng.ivanov.p@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [SecondName], [LastName], [phone], [Email]) VALUES (3, N'Дамян', N'Димитров', N'Петков', N'0878570517', N'damianpetkov@abv.bg')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [SecondName], [LastName], [phone], [Email]) VALUES (6, N'Павел', N'Пейчев', N'Димитров', N'0878474346', N'pafkoni@abv.bg')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [SecondName], [LastName], [phone], [Email]) VALUES (7, N'Иван', N'Диков', N'Недялков', N'0878583581', N'iv.nedyalkov@abv.bg')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [SecondName], [LastName], [phone], [Email]) VALUES (8, N'Диляна', N'Кирова', N'Йовкова', N'0879292080', N'dilyna_kirova@abv.bg')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[files] ON 

INSERT [dbo].[files] ([FileId], [FileName], [FilePath], [UploadedAt]) VALUES (1, N'molba-dopuskane (2).doc', N'/app/molba-dopuskane (2).doc', CAST(N'2024-08-07T14:22:25.5915351' AS DateTime2))
INSERT [dbo].[files] ([FileId], [FileName], [FilePath], [UploadedAt]) VALUES (2, N'molba-razglejdanePUP (1).doc', N'/app/molba-razglejdanePUP (1).doc', CAST(N'2024-08-07T14:27:21.7589743' AS DateTime2))
SET IDENTITY_INSERT [dbo].[files] OFF
GO
SET IDENTITY_INSERT [dbo].[Owners] ON 

INSERT [dbo].[Owners] ([OwnerID], [FirstName], [MiddleName], [LastName], [EGN], [Address]) VALUES (1, N'Test', N'test', N'test', N'123456789', N'asd')
INSERT [dbo].[Owners] ([OwnerID], [FirstName], [MiddleName], [LastName], [EGN], [Address]) VALUES (2, N'СТОЯН', N'СЛАВОВ', N'СТОЯНОВ', N'5903230800', N'гр. Приморско')
INSERT [dbo].[Owners] ([OwnerID], [FirstName], [MiddleName], [LastName], [EGN], [Address]) VALUES (3, N'АТАНАС', N'ХРИСТОВ', N'ШИПКОВ', N'6507230600', N'гр.Бургас, ж.к. Славейков бл. №82')
INSERT [dbo].[Owners] ([OwnerID], [FirstName], [MiddleName], [LastName], [EGN], [Address]) VALUES (4, N'МИЛЧО', N'КОЕВ', N'ЖЕКОВ', N'5606210469', N'гр.Приморско, ул. Стара планина №11')
INSERT [dbo].[Owners] ([OwnerID], [FirstName], [MiddleName], [LastName], [EGN], [Address]) VALUES (5, N'ЖУКРИС', N'МОВИЛ', N'ООД', N'102977394', N'гр.Приморско')
INSERT [dbo].[Owners] ([OwnerID], [FirstName], [MiddleName], [LastName], [EGN], [Address]) VALUES (6, N'Емил', N'Радославов', N'Григоров', N'2808200815', N'asd')
SET IDENTITY_INSERT [dbo].[Owners] OFF
GO
SET IDENTITY_INSERT [dbo].[Plot_DocumentOfOwnerships] ON 

INSERT [dbo].[Plot_DocumentOfOwnerships] ([DocumentPlotId], [PlotId], [DocumentOfOwnershipId]) VALUES (1, 1, 1)
INSERT [dbo].[Plot_DocumentOfOwnerships] ([DocumentPlotId], [PlotId], [DocumentOfOwnershipId]) VALUES (2, 2, 2)
INSERT [dbo].[Plot_DocumentOfOwnerships] ([DocumentPlotId], [PlotId], [DocumentOfOwnershipId]) VALUES (3, 8, 3)
INSERT [dbo].[Plot_DocumentOfOwnerships] ([DocumentPlotId], [PlotId], [DocumentOfOwnershipId]) VALUES (4, 13, 4)
INSERT [dbo].[Plot_DocumentOfOwnerships] ([DocumentPlotId], [PlotId], [DocumentOfOwnershipId]) VALUES (5, 14, 5)
INSERT [dbo].[Plot_DocumentOfOwnerships] ([DocumentPlotId], [PlotId], [DocumentOfOwnershipId]) VALUES (6, 27, 6)
SET IDENTITY_INSERT [dbo].[Plot_DocumentOfOwnerships] OFF
GO
SET IDENTITY_INSERT [dbo].[Plots] ON 

INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (1, N'12345.1234.1234', N'123456789', N'asd', N'asd', N'asd', N'asd', 22, N'урбанизирана', N'asd')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (2, N'58356.505.175', N'XIII', N'14', N'гр. Приморско, с.о. Узунджата', N'Приморско', N'Пета', 1, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (3, N'58356.506.281', N'XIII', N'14', N'гр. Приморско', N'Приморско', N'Пета', 1, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (4, N'48619.5.596', N'1', N'1', N'гр. Царево', N'Царево', N'1', 1, N'замеделска', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (5, N'33333.333.333', N'asd', N'22', N'asd', N'asd', N'', NULL, N'урбанизирана', N'asd')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (6, N'66528.2.253', N'', N'', N'с. Синеморец', N'Царево', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (7, N'52129.236.2', N'', N'', N'с. Ново Паничарево', N'Приморско', N'', NULL, N'горска територия', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (8, N'87655.501.696', N'IX', N'2', N'с. Ясна поляна', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (9, N'87655.501.695', N'IX', N'2', N'с. Ясна поляна', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (10, N'87655.501.697', N'IX', N'2', N'с. Ясна поляна', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (11, N'52129.236.637', N'', N'', N'с. Ново Паничарево', N'Приморско', N'', NULL, N'горска територия', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (12, N'58356.503.16', N'', N'', N'гр. Приморско', N'Приморско', N'', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (13, N'58356.63.12', N'X', N'36', N'гр. Приморско', N'Приморско', N'с.о. Узунджата', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (14, N'58356.506.75', N'XVIII', N'14', N'гр. Приморско', N'Приморско', N'', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (15, N'48619.505.104', N'', N'', N'гр. Царево', N'Царево', N'кв.Белият бряг', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (16, N'58356.506.605', N'XI', N'33', N'гр. Приморско', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (17, N'56513.501.225', N'VIII', N'4', N'с. Писменово', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (18, N'56513.501.42', N'XIII', N'10', N'с. Писменово', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (19, N'58356.501.396', N'II', N'42', N'гр. Приморско', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (20, N'58356.504.385', N'', N'', N'гр. Приморско', N'Приморско', N'С.О. Узунджата', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (21, N'37023.10.914', N'', N'', N'гр. Китен', N'Приморско', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (22, N'48619.505.877', N'', N'', N'гр. Царево', N'Царево', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (23, N'44094.1.209', N'', N'', N'с. Лозенец', N'Царево', N'Тарфа', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (24, N'62459.501.175', N'XI', N'2', N'с. Резово', N'Царево', N'', NULL, N'урбанизирана', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (25, N'10094.502.19', N'', N'', N'с. Варвара', N'Царево', N'', NULL, N'замеделска', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (26, N'48619.504.101', N'140', N'III', N'гр. Царево', N'Царево', N'LIDL', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (27, N'56513.20.70', N'', N'', N'с. Писменово', N'Приморско', N'ПНИ §4 Лозята', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (28, N'87655.501.59', N'VIII', N'6', N'с. Ясна поляна', N'Приморско', N'', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (29, N'48619.9.596', N'', N'', N'гр. Царево', N'Царево', N'', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (30, N'58356.506.210', N'IV', N'22', N'гр. Приморско', N'Приморско', N'', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (31, N'87655.501.377', N'', N'', N'с. Ясна поляна', N'Приморско', N'', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (32, N'80916.501.343', N'', N'', N'с. Черни връх', N'Камено', N'', NULL, N'', N'обл. Бургас')
INSERT [dbo].[Plots] ([PlotId], [PlotNumber], [RegulatedPlotNumber], [neighborhood], [City], [Municipality], [Street], [StreetNumber], [designation], [locality]) VALUES (33, N'58356.506.587', N'III', N'69', N'гр. Приморско', N'Приморско', N'', NULL, N'', N'обл. Бургас')
SET IDENTITY_INSERT [dbo].[Plots] OFF
GO
SET IDENTITY_INSERT [dbo].[powerOfAttorneyDocuments] ON 

INSERT [dbo].[powerOfAttorneyDocuments] ([PowerOfAttorneyId], [number], [dateOfIssuing], [Issuer]) VALUES (1, N'22', CAST(N'2024-08-07T13:56:50.2334454' AS DateTime2), N'Агенция по Вписвания при РС ')
INSERT [dbo].[powerOfAttorneyDocuments] ([PowerOfAttorneyId], [number], [dateOfIssuing], [Issuer]) VALUES (2, N'1', CAST(N'2024-08-09T06:39:39.5030600' AS DateTime2), N'')
INSERT [dbo].[powerOfAttorneyDocuments] ([PowerOfAttorneyId], [number], [dateOfIssuing], [Issuer]) VALUES (3, N'4228', CAST(N'2023-10-20T14:52:50.0000000' AS DateTime2), N'Община ')
INSERT [dbo].[powerOfAttorneyDocuments] ([PowerOfAttorneyId], [number], [dateOfIssuing], [Issuer]) VALUES (4, N'28', CAST(N'2023-01-30T15:45:47.0000000' AS DateTime2), N'Община ')
INSERT [dbo].[powerOfAttorneyDocuments] ([PowerOfAttorneyId], [number], [dateOfIssuing], [Issuer]) VALUES (5, N'', CAST(N'2024-08-13T13:26:53.2118595' AS DateTime2), N'')
INSERT [dbo].[powerOfAttorneyDocuments] ([PowerOfAttorneyId], [number], [dateOfIssuing], [Issuer]) VALUES (6, N'', CAST(N'2024-08-16T08:00:49.5250386' AS DateTime2), N'')
SET IDENTITY_INSERT [dbo].[powerOfAttorneyDocuments] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 

INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (11, N'Поправка на КК 58356.505.175 - Щилян', 600, N'Не платен', 0, N'', N'')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (13, N'Поправка на КК 58356.503.281 - Фросина Приморско', 650, N'Платен', 650, N'', N'Z:\primorsko_a\PRIMORSKO\kkodobrena\506.281')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (14, N'ПУП - ПРЗ + ПУР 58356.4.91 - Стоян Василев', 12670, N'Аванс', 3000, N'', N'Z:\primorsko_dwg\primorsko\pr4-91_PZ')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (15, N'Съответствие', 200, N'Не платен', 0, N'Писменово', N'Z:\съответствия\pis4viii_501.225_ss')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (16, N'Схема за монтаж в земеделска земя', 1500, N'Аванс', 550, N'Изработена схема. Публикувани уведомления в ЧФ и община Царево. Входирано в РИОСВ 09.08.2024г. - няма излязло становище.', N'Z:\carewo_dwg\arapia\ar9.596-shema\схема 2024')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (17, N'ПУП - ПРЗ - Тач Ризорт - Лозенец', 0, N'Платен', 0, N'ЧАСТ ПР КЪМ ПУП - ПРЗ И ПОПРАВКА НА КК, НИКОЛА ЛИКОМАНОВ, ТАЧ РИЗОРТ
ПИ I /ПИ 44094.502.298/, УПИ II /ПИ 44094.502.299/ и УПИ IV /ПИ 44094.502.278/, кв.5', N'Z:\carewo_dwg\lozenec\lz_502.299_s\ПУП-ПРЗ')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (18, N'Снимка за проектиране', 1, N'Не платен', 0, N'Писменово - за Геодезия - БСА', N'Z:\primorsko_dwg\pismenovo\pis10xiii_501.252_swt')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (19, N'Трасиране', 120, N'Платен', 120, N'Трасиране на 2 точки', N'Z:\carewo_dwg\warwara\war502-19-prz\var502.19_trasirane')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (20, N'Снимка за проектиране', 1, N'Не платен', 0, N'за заснемане в Приморско - Ликоманов', N'Z:\primorsko_dwg\primorsko\pr42ii_501.396_pz+rup\swt')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (21, N'Схеми на самостоятелни обекти', 1500, N'Не платен', 0, N'Извършено архитектурно заснемане. ', N'Z:\primorsko_a\PRIMORSKO\kkodobrena\506.210')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (22, N'чл.54а+ССО', 1050, N'Не платен', 0, N'Заснемане - готово. Схеми - подготвени. Изпраено на Кирякова за площообразуване 02.08.2024', N'Z:\primorsko_a\PRIMORSKO\kkodobrena\503.16 - северна секция')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (24, N'Проект за изменение на ПНИ', 1, N'Не платен', 0, N'За оферта и предложение', N'Z:\primorsko_a\pismenowo\paragraf\20.223')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (25, N'Заснeмане на търпимост', 450, N'Не платен', 0, N'За оферта към клиента. Очакваме отговор от Кирякова за другите части. Дали сме оферта от арх.Гечев по телефона и очакваме потвърждение от собственика.', N'Z:\primorsko_a\iasnapoliana\kkarta\501.377')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (26, N'ПУП ПРЗ', 3450, N'Аванс', 950, N'', N'Z:\primorsko_dwg\iasna_poliana\ip6viii_501.59_prz')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (27, N'ПУП ПРЗ', 2700, N'Не платен', 0, N'Поръчка от Динко в имейла от 12.07.2024г.', N'Z:\carewo_dwg\carewo\car_505.81_prz')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (28, N'Комбинирана скица', 250, N'Не платен', 0, N'Поръчка от нот.М.Анастасова в имейла от 09.08.2024', N'Z:\kameno\Черни връх\kkarta\501.343')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (29, N'Схеми на самостоятелни обекти', 250, N'Не платен', 0, N'Входиран проект в АГКК', N'Z:\primorsko_a\PRIMORSKO\kkodobrena\506.75\ССО')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (30, N'Трасиране', 250, N'Платен', 250, N'Резово', N'')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (31, N'Скица за обосабяване на ЗП за ОД"З"', 250, N'Не платен', 0, N'76025.76.20 ', N'Z:\carewo_a\fazanowo\kkodobrena\76.20')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (32, N'Снимка за кадастъра', 450, N'Не платен', 0, N'ПИ 44094.1.209', N'Z:\carewo_a\LOZENEC\kkloz\1.209')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (33, N'Снимка за кадастъра', 450, N'Не платен', 0, N'ПИ 66528.2.253', N'Z:\carewo_a\SINEMOREC\kksin\2.253\заснемане чл54а')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (34, N'Поправка на КК', 1, N'Не платен', 0, N'Дамян да го уточни с Ганчо', N'Z:\primorsko_a\nowopancarewo\kkarta\236.637 - Дуденово')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (35, N'ПУП ПРЗ Я.п. кв.2 IX - Шипков Ясна Поляна', 6640, N'Аванс', 1700, N'', N'Z:\primorsko_dwg\iasna_poliana\ip2IX_prz')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (36, N'ПУП ПЗ - Милчо - Узунджата кв.36 Х', 4200, N'Аванс', 1500, N'', N'Z:\primorsko_dwg\uzlundga\uz36x-63.12_prz')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (37, N'Поправка КК 58356.503.191 - Иван ', 650, N'Не платен', 0, N'', N'Z:\primorsko_a\PRIMORSKO\kkodobrena\503.191\popravka KK')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (38, N'Поправка КК', 1, N'Не платен', 0, N'Изпратен протокол от ОЕСУТ в имейла от 13.08.2024', N'Z:\carewo_a\carewo\kkcar\504.2-101-800_most LIDL')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (39, N'Поправка КК', 1, N'Не платен', 0, N'Изпратен протокол на ОЕСУТ в имейла от 13.08.2024', N'Z:\carewo_a\carewo\kkcar\504.2-101-800_most LIDL')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (40, N'Поправка КК', 1, N'Не платен', 0, N'Община Царево - Мост LIDL - Проекта е изпратен на 14.08.2024', N'Z:\carewo_a\carewo\kkcar\504.2-101-800_most LIDL')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (45, N'ПУП ПРЗ', 3200, N'Не платен', 0, N'Възложено по имейла на 13.08.2024', N'Z:\carewo_dwg\carewo\car_505.104_prz')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (46, N'БСкици 58356.502.177 и 58356.502.178', 100, N'Платен', 100, N'Бърза поръчка 14.08.2024', N'Z:\primorsko_a\PRIMORSKO\kkodobrena\502.177-178-skici\нови-скица')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (47, N'Снимка за проектиране', 1, N'Не платен', 0, N'Изпратена на Гечев', N'Z:\primorsko_dwg\primorsko\pr33vi_506.336_swt')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (49, N'Трасиране', 200, N'Платен', 200, N'Узунджата - военните', N'')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (50, N'Снимка за кадастъра', 450, N'Платен', 450, N'BAHKO', N'Z:\primorsko_a\KITEN\kkodobrena\10.914\pdf')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (51, N'Снимка за кадастъра', 450, N'Платен', 450, N'BAHKO', N'Z:\carewo_a\carewo\kkcar\505.877')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (52, N'Комбинирана скица', 250, N'Не платен', 0, N'20.70 §4 Писменово', N'Z:\primorsko_a\pismenowo\paragraf\20.70-комбинирана скица')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (53, N'ПУП ПРЗ', 3350, N'Не платен', 0, N'58356.506.587', N'Z:\primorsko_dwg\primorsko\pr69iii-506.392-393_pr')
INSERT [dbo].[Requests] ([RequestId], [RequestName], [Price], [PaymentStatus], [Advance], [Comments], [Path]) VALUES (54, N'ПУП ПРЗ', 3070, N'Аванс', 320, N'10731.501.527 - Танчето ГРАО', N'Z:\primorsko_dwg\veselie\ves37i_501.524_prz')
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
INSERT [dbo].[starRequest_EmployeeRelashionships] ([RequestId], [EmployeeID]) VALUES (18, 7)
INSERT [dbo].[starRequest_EmployeeRelashionships] ([RequestId], [EmployeeID]) VALUES (20, 7)
INSERT [dbo].[starRequest_EmployeeRelashionships] ([RequestId], [EmployeeID]) VALUES (32, 7)
INSERT [dbo].[starRequest_EmployeeRelashionships] ([RequestId], [EmployeeID]) VALUES (33, 7)
INSERT [dbo].[starRequest_EmployeeRelashionships] ([RequestId], [EmployeeID]) VALUES (34, 7)
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (11, 9, CAST(N'00:00:00' AS Time), CAST(N'2024-08-09T08:26:30.0751321' AS DateTime2), 2, NULL, N'', 166, N'', 0, 0, CAST(N'2024-08-09T08:26:04.9018719' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (12, 10, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:22:58.7860328' AS DateTime2), 2, NULL, N'', 1, N'', 0, 140, CAST(N'2024-08-12T08:19:21.3495457' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (13, 11, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:42:59.1790239' AS DateTime2), 7, NULL, N'', 48, N'без ДДС', 200, 200, CAST(N'2024-08-14T12:49:29.7141073' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (14, 12, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:55:44.5043769' AS DateTime2), 7, NULL, N'', 34, N'', 0, 0, CAST(N'2024-08-14T12:26:24.2955009' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (15, 13, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:56:58.6317552' AS DateTime2), 2, NULL, N'Ликоманов движи процедурата, изготвен ПР и ТП', 94, N'', 0, 0, CAST(N'2024-08-12T06:57:53.9739350' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (16, 14, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:59:05.9747852' AS DateTime2), 2, NULL, N'12.08 - Трябва да потвърдят дали всичко се прехвърля на ТАЧ, за да се пусне проекта със Скица проект', 1, N'', 0, 0, CAST(N'2024-08-12T06:58:05.0446055' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (17, 15, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:59:40.6882152' AS DateTime2), 7, NULL, N'', 16, N'без ДДС', 120, 120, CAST(N'2024-08-13T05:54:38.4079021' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (18, 16, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:55:44.4608373' AS DateTime2), 7, NULL, N'Обработено', 56, N'', 250, 0, CAST(N'2024-08-12T07:32:54.4540057' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (19, 17, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T06:57:31.5440956' AS DateTime2), 8, NULL, N'ПД 2266-09.08.2024г. / Код за проверка ETK7D2529C5 /
', 82, N'', 0, 0, CAST(N'2024-08-12T07:44:07.9603541' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (21, 19, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T07:05:19.3876161' AS DateTime2), 7, NULL, N'', 33, N'', 0, 0, CAST(N'2024-08-14T08:59:34.4218956' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (22, 17, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T07:31:14.8868407' AS DateTime2), 8, NULL, N'Тече съгласувка с РИОСВ', 81, N'', 0, 0, CAST(N'2024-08-12T08:13:10.7745253' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (24, 20, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T07:56:11.2825949' AS DateTime2), 7, NULL, N'', 66, N'', 0, 0, CAST(N'2024-08-12T07:50:11.1922878' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (25, 21, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T07:57:50.9772593' AS DateTime2), 8, NULL, N'', 26, N'', 0, 0, CAST(N'2024-08-12T07:56:31.6524196' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (26, 21, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T07:58:27.1992281' AS DateTime2), 8, NULL, N'изпратено на кирякова на .........', 27, N'', 0, 0, CAST(N'2024-08-12T07:57:56.3455587' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (27, 22, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:05:12.4796737' AS DateTime2), 2, NULL, N'', 98, N'', 0, 0, CAST(N'2024-08-12T08:05:37.5434852' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (28, 23, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:11:43.1402905' AS DateTime2), 7, NULL, N'обработено', 21, N'', 0, 0, CAST(N'2024-08-12T08:13:43.2301351' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (29, 10, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:18:55.5128417' AS DateTime2), 2, NULL, N'', 8, N'', 0, 0, CAST(N'2024-08-12T08:18:36.5865277' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (30, 10, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:19:10.7794451' AS DateTime2), 2, NULL, N'', 10, N'', 0, 0, CAST(N'2024-08-12T08:19:02.4207627' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (31, 24, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:16:01.3370683' AS DateTime2), 8, NULL, N'', 28, N'', 0, 0, CAST(N'2024-08-16T11:28:12.1799057' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (33, 24, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:19:05.8569874' AS DateTime2), 8, NULL, N'Изпратено на Кирякова 02.08.202 получено на 16.08.2024', 27, N'', 100, 0, CAST(N'2024-08-16T11:28:34.6264520' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (34, 26, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:34:53.5974643' AS DateTime2), 8, NULL, N'Да се предложи цена за разделяне и два варианта /1-на три основни дяла; 2-на 9 дяла/', 142, N'', 0, 0, CAST(N'2024-08-12T13:48:58.8142136' AS DateTime2), N'Оферта')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (35, 27, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T08:42:16.3021621' AS DateTime2), 8, NULL, N'Изпратено на Кирякова за цени на 09.08.2024г. Да определим обща цена и да я върнем на клиента', 55, N'', 0, 0, CAST(N'2024-08-14T11:42:39.0000000' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (36, 28, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T10:17:24.1880914' AS DateTime2), 7, 8, N'обработено', 37, N'', 0, 0, CAST(N'2024-08-12T10:23:35.8469549' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (37, 29, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T10:18:55.3758784' AS DateTime2), 8, NULL, N'Заповед №18-11608-02.11.2022', 6, N'', 0, 0, CAST(N'2024-08-12T10:17:27.1912598' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (38, 30, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T10:20:03.1753113' AS DateTime2), 8, NULL, N'получена 24.04.2024', 94, N'', 0, 0, CAST(N'2024-08-12T10:19:01.0191293' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (39, 30, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T10:21:36.4617117' AS DateTime2), 8, NULL, N'Заповед №543/19.07.2024', 98, N'', 0, 0, CAST(N'2024-08-12T10:20:10.3278775' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (40, 30, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T10:23:25.0000000' AS DateTime2), 8, NULL, N'разпечатан и вх. за ОЕСУТ вх.№94-00-3084-31.07.2024г.', 109, N'', 0, 0, CAST(N'2024-08-12T10:31:05.3306017' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (41, 30, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T10:30:32.1417128' AS DateTime2), 8, NULL, N'вх.№ПД-2163/30.07.2024г. /код за проверка BFG7CB7834A/', 101, N'', 0, 0, CAST(N'2024-08-29T13:28:58.0000000' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (42, 30, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T10:32:48.9195293' AS DateTime2), 8, NULL, N'вх.№01-446973/14.08.2024г.', 120, N'', 0, 0, CAST(N'2024-08-14T13:18:16.5824432' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (43, 31, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T13:04:01.6923893' AS DateTime2), 8, NULL, N'Възложено от Динко по имейла на 12.08.2024г. Изпратено на Динко на 13.08.2024', 98, N'', 0, 0, CAST(N'2024-08-13T10:43:25.2934042' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (44, 32, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T13:07:49.5598631' AS DateTime2), 8, NULL, N'Обаждане до клиента на 12.08.2024г. Очакваме да изпрати копие от ПР от община Камено.', 11, N'', 0, 0, CAST(N'2024-08-12T13:07:59.6218632' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (45, 33, CAST(N'00:00:00' AS Time), CAST(N'2024-08-12T13:12:04.4356004' AS DateTime2), 8, NULL, N'вх.01-444246-13.08.2024 за приемане на проект. Прикрепено платежно на 14.08.2024', 26, N'', 0, 0, CAST(N'2024-08-16T08:49:00.3869745' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (46, 34, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T06:03:43.4922607' AS DateTime2), 7, NULL, N'', 16, N'', 250, 250, CAST(N'2024-08-14T09:00:42.9773051' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (47, 35, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T07:00:18.5411857' AS DateTime2), 8, NULL, N'Разпечатано и изпратено на Динко на 13.08.2024г.', 80, N'', 0, 0, CAST(N'2024-08-13T06:59:14.8492376' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (48, 36, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T07:34:05.8504807' AS DateTime2), 7, NULL, N'', 22, N'', 450, 450, CAST(N'2024-08-13T07:33:32.7986679' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (49, 37, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T08:22:08.4660672' AS DateTime2), 7, NULL, N'', 21, N'', 0, 0, CAST(N'2024-08-13T08:26:28.3880847' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (52, 40, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T11:48:44.6012185' AS DateTime2), 2, NULL, N'', 98, N'', 0, 0, CAST(N'2024-08-13T12:02:53.3504859' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (54, 40, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T12:05:05.0886913' AS DateTime2), 2, NULL, N'Допуснат, чакаме да обработят съвета', 107, N'', 0, 150, CAST(N'2024-08-13T12:03:03.6184132' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (55, 40, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T12:06:49.2772312' AS DateTime2), 2, NULL, N'Получено становище за присъединяване 50кв', 99, N'Ново становище заради промяната и общинските имоти, вх. на 13.08', 0, 278, CAST(N'2024-09-02T15:05:14.0000000' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (60, 43, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T12:41:28.4838262' AS DateTime2), 2, NULL, N'', 118, N'', 0, 400, CAST(N'2024-08-13T12:37:31.4669596' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (64, 44, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T12:45:25.1336705' AS DateTime2), 8, NULL, N'', 6, N'', 0, 0, CAST(N'2024-08-13T12:44:54.1687516' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (65, 44, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T12:46:13.8986920' AS DateTime2), 7, NULL, N'', 168, N'', 0, 0, CAST(N'2024-08-13T12:45:33.8306978' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (66, 45, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T13:42:32.7662572' AS DateTime2), 2, NULL, N'2025010-13.08.2024', 3, N'', 0, 9, CAST(N'2024-08-13T13:41:22.3710665' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (67, 45, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T13:43:19.4976479' AS DateTime2), 2, 7, N'', 1, N'', 0, 0, CAST(N'2024-08-14T16:42:48.0000000' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (68, 45, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T13:44:42.7895387' AS DateTime2), 2, NULL, N'', 6, N'', 0, 0, CAST(N'2024-08-13T13:44:09.4210921' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (71, 46, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T13:59:10.9696615' AS DateTime2), 8, NULL, N'2025522-13.08.2024', 3, N'', 0, 0, CAST(N'2024-08-14T09:18:31.7138029' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (72, 46, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T14:00:29.8971158' AS DateTime2), 8, NULL, N'3 нови идентификатора вх.№01-444361-13.08.2024', 3, N'', 0, 0, CAST(N'2024-08-14T09:18:39.3555928' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (73, 46, CAST(N'00:00:00' AS Time), CAST(N'2024-08-13T14:01:07.9547008' AS DateTime2), 8, NULL, N'поправка чл.65 ', 6, N'', 0, 0, CAST(N'2024-08-14T12:50:29.0143116' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (75, 48, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T07:08:42.2487427' AS DateTime2), 8, NULL, N'Подготвено задание и предложение за едно УПИ. Оставено на Анито на 15.08.2024г.', 98, N'', 0, 0, CAST(N'2024-08-16T09:54:10.3351065' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (77, 50, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T08:33:07.1117130' AS DateTime2), 2, NULL, N'', 50, N'2х28', 100, 56, CAST(N'2024-08-14T08:32:22.1646029' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (78, 51, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T08:49:28.9128237' AS DateTime2), 7, NULL, N'', 33, N'', 0, 0, CAST(N'2024-08-14T08:48:38.9671503' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (79, 51, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T08:50:09.7128147' AS DateTime2), 7, NULL, N'', 35, N'', 0, 0, CAST(N'2024-08-14T08:49:37.7538552' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (82, 54, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T09:03:01.9399328' AS DateTime2), 7, NULL, N'', 17, N'', 200, 200, CAST(N'2024-08-14T09:03:09.2592998' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (83, 12, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T12:26:53.5291281' AS DateTime2), 7, NULL, N'изпратено на БСА', 35, N'', 0, 0, CAST(N'2024-08-14T12:59:20.4123927' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (84, 55, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T12:36:11.9681880' AS DateTime2), 7, NULL, N'', 25, N'', 450, 450, CAST(N'2024-08-14T12:35:37.6183526' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (85, 56, CAST(N'00:00:00' AS Time), CAST(N'2024-08-14T12:40:26.4238063' AS DateTime2), 7, NULL, N'', 25, N'', 450, 450, CAST(N'2024-08-14T12:39:48.4213732' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (88, 59, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T08:00:03.1694420' AS DateTime2), 8, NULL, N'', 11, N'', 0, 0, CAST(N'2024-08-16T07:59:41.0905109' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (89, 60, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T09:37:51.0576139' AS DateTime2), 8, NULL, N'', 94, N'', 0, 0, CAST(N'2024-09-02T12:38:36.0000000' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (90, 60, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T09:38:33.1550358' AS DateTime2), 8, NULL, N'вх.№01-450612-16.08.2024', 109, N'', 0, 0, CAST(N'2024-08-16T09:53:36.8002369' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (91, 61, CAST(N'00:00:00' AS Time), CAST(N'2024-03-29T10:08:25.0000000' AS DateTime2), 7, NULL, N'', 1, N'', 150, 0, CAST(N'2024-03-29T13:13:03.0000000' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (92, 61, CAST(N'00:00:00' AS Time), CAST(N'2024-03-29T10:08:59.0000000' AS DateTime2), 8, NULL, N'', 2, N'', 0, 0, CAST(N'2024-08-16T10:13:43.8591287' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (93, 61, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T10:10:24.4824169' AS DateTime2), 8, NULL, N'актуализирана на 03.07.2024г. в kais', 6, N'', 400, 45, CAST(N'2024-08-16T10:13:49.7579861' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (94, 62, CAST(N'00:00:00' AS Time), CAST(N'2024-07-09T10:15:20.0000000' AS DateTime2), 8, NULL, N'вх.№01-374044-09.07.2024', 94, N'', 0, 0, CAST(N'2024-07-09T13:16:24.0000000' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (95, 62, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T10:16:22.2759785' AS DateTime2), 8, NULL, N'Становище ПД-1940/1/-19.07.2024', 101, N'', 0, 0, CAST(N'2024-08-16T10:15:24.0029226' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (96, 62, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T10:17:58.0367572' AS DateTime2), 8, NULL, N'входиран за ОЕСУТ вх.№94-00-2845-09.07.2024г.', 109, N'', 1500, 200, CAST(N'2024-08-16T10:22:57.7068349' AS DateTime2), N'Завършена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (97, 62, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T10:19:50.2777545' AS DateTime2), 8, NULL, N'вх.№01-447166-14.08.2024г.', 120, N'', 350, 81, CAST(N'2024-08-28T13:20:33.0000000' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (98, 62, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T10:24:11.5762295' AS DateTime2), 8, NULL, N'входиран за ОЕСУТ вх.№94-00-2845-09.07.2024г. не са правени схеми. Приет с решение №2 от Протокол №2/10.05.2024г.', 118, N'', 0, 200, CAST(N'2024-08-16T10:23:21.1382350' AS DateTime2), N'Зададена')
INSERT [dbo].[Tasks] ([TaskId], [ActivityId], [Duration], [StartDate], [ExecutantId], [ControlId], [Comments], [TaskTypeId], [CommentTax], [executantPayment], [tax], [FinishDate], [Status]) VALUES (99, 23, CAST(N'00:00:00' AS Time), CAST(N'2024-08-16T11:29:20.6726581' AS DateTime2), 8, NULL, N'01-451014-16.08.2024', 23, N'', 0, 245, CAST(N'2024-09-02T14:28:43.0000000' AS DateTime2), N'Зададена')
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[taskTypes] ON 

INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (1, N'Трасиране правото на собственост', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (2, N'Протокол за трасиране', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (3, N'Заявка за cad файл от КК', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (4, N'Заверка на протокол със копие от действащ ПУП в общинска администрация', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (5, N'Комбинирана скица', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (6, N'Изработване на проект за измение на КК', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (7, N'Входиране на проекта в АГКК за приемане', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (8, N'Протокол за приемане на проекта', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (9, N'Издаване на скица след изменение ', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (10, N'предаване на клиент', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (11, N'Заявка за cad файл от КК', 2)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (12, N'Заявление за копие от  необходими планове в общинска администрация', 2)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (13, N'Изработване на комбинирана скица ', 2)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (14, N'Изпращане за съгласуване ', 2)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (15, N'предаване на клиент', 2)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (16, N'анализ на документите', 3)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (17, N'трасиране ', 3)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (18, N'Протокол за трасиране', 3)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (19, N'предаване на клиент', 3)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (20, N'анализ на документите', 4)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (21, N'геодезическо заснемане', 4)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (22, N'обработка на извършени измервания и изготвяне на проект за изменение на КК', 4)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (23, N'Входиране на проекта в АГКК за приемане', 4)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (24, N'Протокол за приемане на проекта', 4)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (25, N'предаване на клиент', 4)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (26, N'анализ на документите', 5)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (27, N'площообразуване', 5)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (28, N'изработване на проект за нанасяне на ССО', 5)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (29, N'Входиране на проекта в АГКК за приемане', 5)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (30, N'Протокол за приемане на проекта', 5)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (31, N'предаване на клиент', 5)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (32, N'анализ на документите', 6)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (33, N'геодезическо заснемане', 6)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (34, N'обработка на извършени измервания', 6)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (35, N'изпращане на водещия проектант на обекта', 6)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (36, N'анализ на документите', 7)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (37, N'геодезическо заснемане', 7)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (38, N'обработка на извършени измервания', 7)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (39, N'предаване на клиент на хартиен носител', 7)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (40, N'анализ на документите', 8)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (41, N'геодезическо заснемане', 8)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (42, N'обработка на извършени измервания', 8)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (43, N'Оформяне за предаване', 8)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (44, N'предаване ', 8)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (45, N'анализ на документите', 9)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (46, N'геодезическо заснемане', 9)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (47, N'обработка на извършени измервания', 9)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (48, N'Оформяне за предаване', 9)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (49, N'анализ на документите', 10)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (50, N'входиране на заявление в КК', 10)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (51, N'предаване на клиент', 10)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (52, N'анализ на документите', 11)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (53, N'входиране на заявление в КК', 11)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (54, N'предаване на клиент', 11)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (55, N'анализ на документите', 12)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (56, N'геодезическо заснемане', 12)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (57, N'обработка на извършени измервания', 12)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (58, N'изпращане на водещия проектант на обекта', 12)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (59, N'Оформяне за предаване', 12)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (60, N'анализ на документите', 13)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (61, N'полски дейности', 13)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (62, N'обработка на извършени измервания', 13)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (63, N'изпратена за преглед и потвърждение', 13)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (64, N'предаване на клиент', 13)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (65, N'анализ на документите', 14)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (66, N'полски дейности', 14)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (67, N'канцеларска обработка', 14)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (68, N'предаване на клиент', 14)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (69, N'анализ на документите', 15)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (70, N'подготовка на данни', 15)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (71, N'полски дейности', 15)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (72, N'анализ на документите', 16)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (73, N'подготовка на данни', 16)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (74, N'полски дейности', 16)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (75, N'анализ на файлове от водещия проектант', 17)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (76, N'изработване на проект ВП и ТП', 17)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (77, N'изпращане на водещия проектант за съгласуване', 17)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (78, N'Оформяне за предаване', 17)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (79, N'предаване на клиент', 17)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (80, N'анализ на документите', 18)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (81, N'изработване на схема за монтаж', 18)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (82, N'предаване на клиент', 18)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (83, N'анализ на документите', 19)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (84, N'изработване на ТП', 19)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (85, N'предаване на клиент', 19)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (86, N'анализ на документите', 20)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (87, N'изработване на ТП', 20)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (88, N'предаване на клиент', 20)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (89, N'входиране на заявление в КК', 21)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (90, N'анализ на документите', 22)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (91, N'изготвяне на оферта', 22)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (92, N'изготвяне на графично предложение', 22)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (93, N'изпращане на клиента', 22)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (94, N'Скица на имота', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (95, N'удостоверение с характеристика', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (96, N'удостоверение за УЗ по ОУП', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (97, N'Извадка от КК / ПР / ЗП', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (98, N'изработване на задание за проектиране и графично предложение по чл.135 ЗУТ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (99, N'Проучване за присъединяване с ЕВН', 23)
GO
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (100, N'Проучване за присъединяване с ВиК', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (101, N'Уведомление за план-програма до РИОСВ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (102, N'възлагане изработване на доклад за преценка от ЕО/ОВОС', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (103, N'получаване на доклад и входиране в РИОСВ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (104, N'Получаване на решение за преценка от РИОСВ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (105, N'Писмо за влязло в сила решение на РИОСВ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (106, N'Съгласуване с НИНКН', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (107, N'Входиране на искане за Допускане на ПУП', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (108, N'Получаване на заповед за Допускане на ПУП', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (109, N'Изработване на ПУП', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (110, N'възлагане на план схема ВиК', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (111, N'Получаване на план схема ВиК', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (112, N'Съгласуване на план схема ВиК', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (113, N'Възлагане на план схема ЕЛ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (114, N'Получаване на план схема ЕЛ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (115, N'Съгласуване на план схема ЕЛ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (116, N'Получаване на план схема озеленяване', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (117, N'Изработване на ПУП', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (118, N'Входиране на ПУП с план схеми за приемане на ОЕСУТ', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (119, N'подписване на уведомление в общинска администрация', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (120, N'Проект за съгласуване на ПУП с КК по чл.65 Наредба №РД-02-20-5-2016г.', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (121, N'Заповед за одобряване на ПУП', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (122, N'подписване на уведомление в общинска администрация', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (123, N'Получаване на преписката от общинска администрация', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (124, N'Скица проект от АГКК', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (125, N'Актуализация на проект в КК', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (126, N'предаване на клиент', 23)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (127, N'анализ на документите', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (128, N'Скица на имота', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (129, N'удостоверение с характеристика', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (130, N'удостоверение за УЗ по ОУП', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (131, N'инвестиционно намерение до РИОСВ', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (132, N'Удостоверение за поливност', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (133, N'Акт за категоризация', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (134, N'Съгласеване с НИНКН', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (135, N'Изработване и съгласуване на план-схема Вик при необходимост', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (136, N'Здравно заключение от РЗИ', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (137, N'Входиране на преписката в комисията по чл.17 ЗОЗЗ', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (138, N'Решение на комия по чл.17 ЗОЗЗ', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (139, N'заплащане на определената такса', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (140, N'получаване на преписката от ОДЗ', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (141, N'предаване на клиент', 24)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (142, N'анализ на документите', 25)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (143, N'получаване на изходна информация от общинска администрация /модел и поредни номера/', 25)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (144, N'изработване на проект за измение на ПНИ', 25)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (145, N'предаване на клиент', 25)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (146, N'изработване на протокол', 26)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (147, N'предаване на клиент', 26)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (148, N'анализ на документите', 27)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (149, N'проверка на терен', 27)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (150, N'изготвяне на протокол', 27)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (151, N'предаване на клиент', 27)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (152, N'анализ на документите и файлове от водещ проектант', 28)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (153, N'Изработванен на ТП', 28)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (154, N'Оформяне за предаване', 28)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (155, N'предаване на клиент', 28)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (156, N'анализ на документите', 29)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (157, N'изработване на схема за монтаж', 29)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (158, N'съгласуване с възложител', 29)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (159, N'Оформяне за предаване', 29)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (160, N'предаване на клиент', 29)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (161, N'анализ на документите', 30)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (162, N'изработване на протграмата', 30)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (163, N'съгласуване с възложител', 30)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (164, N'Оформяне за предаване', 30)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (165, N'предаване на клиент', 30)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (166, N'Анализ на Документи', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (167, N'заснемане на ограда', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (168, N'Заснемане на огради', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (169, N'Заснемане на огради', 1)
INSERT [dbo].[taskTypes] ([TaskTypeId], [TaskTypeName], [ActivityTypeID]) VALUES (170, N'Заснемане на огради', 1)
SET IDENTITY_INSERT [dbo].[taskTypes] OFF
GO
/****** Object:  Index [IX_Activities_ActivityTypeID]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Activities_ActivityTypeID] ON [dbo].[Activities]
(
	[ActivityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Activities_ExecutantId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Activities_ExecutantId] ON [dbo].[Activities]
(
	[ExecutantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Activities_ParentActivityId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Activities_ParentActivityId] ON [dbo].[Activities]
(
	[ParentActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Activities_RequestId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Activities_RequestId] ON [dbo].[Activities]
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Activity_PlotRelashionships_PlotId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Activity_PlotRelashionships_PlotId] ON [dbo].[Activity_PlotRelashionships]
(
	[PlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_EmployeeId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AspNetUsers_EmployeeId] ON [dbo].[AspNetUsers]
(
	[EmployeeId] ASC
)
WHERE ([EmployeeId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_RequestRelashionships_ClientId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Client_RequestRelashionships_ClientId] ON [dbo].[Client_RequestRelashionships]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DocumentOfOwnership_OwnerRelashionships_DocumentID]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_DocumentOfOwnership_OwnerRelashionships_DocumentID] ON [dbo].[DocumentOfOwnership_OwnerRelashionships]
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DocumentOfOwnership_OwnerRelashionships_OwnerID]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_DocumentOfOwnership_OwnerRelashionships_OwnerID] ON [dbo].[DocumentOfOwnership_OwnerRelashionships]
(
	[OwnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_documentPlot_DocumentOwenerRelashionships_DocumentOwnerID]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_documentPlot_DocumentOwenerRelashionships_DocumentOwnerID] ON [dbo].[documentPlot_DocumentOwenerRelashionships]
(
	[DocumentOwnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_documentPlot_DocumentOwenerRelashionships_DocumentPlotId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_documentPlot_DocumentOwenerRelashionships_DocumentPlotId] ON [dbo].[documentPlot_DocumentOwenerRelashionships]
(
	[DocumentPlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_documentPlot_DocumentOwenerRelashionships_PowerOfAttorneyId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_documentPlot_DocumentOwenerRelashionships_PowerOfAttorneyId] ON [dbo].[documentPlot_DocumentOwenerRelashionships]
(
	[PowerOfAttorneyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoices_RequestId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Invoices_RequestId] ON [dbo].[Invoices]
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Plot_DocumentOfOwnerships_DocumentOfOwnershipId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Plot_DocumentOfOwnerships_DocumentOfOwnershipId] ON [dbo].[Plot_DocumentOfOwnerships]
(
	[DocumentOfOwnershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Plot_DocumentOfOwnerships_PlotId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Plot_DocumentOfOwnerships_PlotId] ON [dbo].[Plot_DocumentOfOwnerships]
(
	[PlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_starRequest_EmployeeRelashionships_EmployeeID]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_starRequest_EmployeeRelashionships_EmployeeID] ON [dbo].[starRequest_EmployeeRelashionships]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_ActivityId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_ActivityId] ON [dbo].[Tasks]
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_ControlId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_ControlId] ON [dbo].[Tasks]
(
	[ControlId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_ExecutantId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_ExecutantId] ON [dbo].[Tasks]
(
	[ExecutantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_TaskTypeId]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_TaskTypeId] ON [dbo].[Tasks]
(
	[TaskTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_taskTypes_ActivityTypeID]    Script Date: 20.8.2024 г. 12:02:59 ******/
CREATE NONCLUSTERED INDEX [IX_taskTypes_ActivityTypeID] ON [dbo].[taskTypes]
(
	[ActivityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0)) FOR [ExecutantId]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT (CONVERT([real],(0))) FOR [employeePayment]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [StartDate]
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isDrob]
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships] ADD  DEFAULT ((0)) FOR [PowerOfAttorneyId]
GO
ALTER TABLE [dbo].[DocumentsOfOwnership] ADD  DEFAULT (N'') FOR [TypeOfOwnership]
GO
ALTER TABLE [dbo].[Invoices] ADD  DEFAULT (N'') FOR [number]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (N'') FOR [CommentTax]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (CONVERT([real],(0))) FOR [executantPayment]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (CONVERT([real],(0))) FOR [tax]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FinishDate]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (N'') FOR [Status]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Activities_ParentActivityId] FOREIGN KEY([ParentActivityId])
REFERENCES [dbo].[Activities] ([ActivityId])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Activities_ParentActivityId]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_activityTypes_ActivityTypeID] FOREIGN KEY([ActivityTypeID])
REFERENCES [dbo].[activityTypes] ([ActivityTypeID])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_activityTypes_ActivityTypeID]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Employees_ExecutantId] FOREIGN KEY([ExecutantId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Employees_ExecutantId]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Requests_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Requests] ([RequestId])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Requests_RequestId]
GO
ALTER TABLE [dbo].[Activity_PlotRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_Activity_PlotRelashionships_Activities_ActivityId] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activities] ([ActivityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Activity_PlotRelashionships] CHECK CONSTRAINT [FK_Activity_PlotRelashionships_Activities_ActivityId]
GO
ALTER TABLE [dbo].[Activity_PlotRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_Activity_PlotRelashionships_Plots_PlotId] FOREIGN KEY([PlotId])
REFERENCES [dbo].[Plots] ([PlotId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Activity_PlotRelashionships] CHECK CONSTRAINT [FK_Activity_PlotRelashionships_Plots_PlotId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Client_RequestRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_Client_RequestRelashionships_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Client_RequestRelashionships] CHECK CONSTRAINT [FK_Client_RequestRelashionships_Clients_ClientId]
GO
ALTER TABLE [dbo].[Client_RequestRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_Client_RequestRelashionships_Requests_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Requests] ([RequestId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Client_RequestRelashionships] CHECK CONSTRAINT [FK_Client_RequestRelashionships_Requests_RequestId]
GO
ALTER TABLE [dbo].[DocumentOfOwnership_OwnerRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_DocumentOfOwnership_OwnerRelashionships_DocumentsOfOwnership_DocumentID] FOREIGN KEY([DocumentID])
REFERENCES [dbo].[DocumentsOfOwnership] ([DocumentId])
GO
ALTER TABLE [dbo].[DocumentOfOwnership_OwnerRelashionships] CHECK CONSTRAINT [FK_DocumentOfOwnership_OwnerRelashionships_DocumentsOfOwnership_DocumentID]
GO
ALTER TABLE [dbo].[DocumentOfOwnership_OwnerRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_DocumentOfOwnership_OwnerRelashionships_Owners_OwnerID] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Owners] ([OwnerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocumentOfOwnership_OwnerRelashionships] CHECK CONSTRAINT [FK_DocumentOfOwnership_OwnerRelashionships_Owners_OwnerID]
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_documentPlot_DocumentOwenerRelashionships_DocumentOfOwnership_OwnerRelashionships_DocumentOwnerID] FOREIGN KEY([DocumentOwnerID])
REFERENCES [dbo].[DocumentOfOwnership_OwnerRelashionships] ([DocumentOwnerID])
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships] CHECK CONSTRAINT [FK_documentPlot_DocumentOwenerRelashionships_DocumentOfOwnership_OwnerRelashionships_DocumentOwnerID]
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_documentPlot_DocumentOwenerRelashionships_Plot_DocumentOfOwnerships_DocumentPlotId] FOREIGN KEY([DocumentPlotId])
REFERENCES [dbo].[Plot_DocumentOfOwnerships] ([DocumentPlotId])
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships] CHECK CONSTRAINT [FK_documentPlot_DocumentOwenerRelashionships_Plot_DocumentOfOwnerships_DocumentPlotId]
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId] FOREIGN KEY([PowerOfAttorneyId])
REFERENCES [dbo].[powerOfAttorneyDocuments] ([PowerOfAttorneyId])
GO
ALTER TABLE [dbo].[documentPlot_DocumentOwenerRelashionships] CHECK CONSTRAINT [FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Requests_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Requests] ([RequestId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Requests_RequestId]
GO
ALTER TABLE [dbo].[Plot_DocumentOfOwnerships]  WITH CHECK ADD  CONSTRAINT [FK_Plot_DocumentOfOwnerships_DocumentsOfOwnership_DocumentOfOwnershipId] FOREIGN KEY([DocumentOfOwnershipId])
REFERENCES [dbo].[DocumentsOfOwnership] ([DocumentId])
GO
ALTER TABLE [dbo].[Plot_DocumentOfOwnerships] CHECK CONSTRAINT [FK_Plot_DocumentOfOwnerships_DocumentsOfOwnership_DocumentOfOwnershipId]
GO
ALTER TABLE [dbo].[Plot_DocumentOfOwnerships]  WITH CHECK ADD  CONSTRAINT [FK_Plot_DocumentOfOwnerships_Plots_PlotId] FOREIGN KEY([PlotId])
REFERENCES [dbo].[Plots] ([PlotId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Plot_DocumentOfOwnerships] CHECK CONSTRAINT [FK_Plot_DocumentOfOwnerships_Plots_PlotId]
GO
ALTER TABLE [dbo].[starRequest_EmployeeRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_starRequest_EmployeeRelashionships_Employees_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[starRequest_EmployeeRelashionships] CHECK CONSTRAINT [FK_starRequest_EmployeeRelashionships_Employees_EmployeeID]
GO
ALTER TABLE [dbo].[starRequest_EmployeeRelashionships]  WITH CHECK ADD  CONSTRAINT [FK_starRequest_EmployeeRelashionships_Requests_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Requests] ([RequestId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[starRequest_EmployeeRelashionships] CHECK CONSTRAINT [FK_starRequest_EmployeeRelashionships_Requests_RequestId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Activities_ActivityId] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activities] ([ActivityId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Activities_ActivityId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Employees_ControlId] FOREIGN KEY([ControlId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Employees_ControlId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Employees_ExecutantId] FOREIGN KEY([ExecutantId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Employees_ExecutantId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_taskTypes_TaskTypeId] FOREIGN KEY([TaskTypeId])
REFERENCES [dbo].[taskTypes] ([TaskTypeId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_taskTypes_TaskTypeId]
GO
ALTER TABLE [dbo].[taskTypes]  WITH CHECK ADD  CONSTRAINT [FK_taskTypes_activityTypes_ActivityTypeID] FOREIGN KEY([ActivityTypeID])
REFERENCES [dbo].[activityTypes] ([ActivityTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[taskTypes] CHECK CONSTRAINT [FK_taskTypes_activityTypes_ActivityTypeID]
GO
USE [master]
GO
ALTER DATABASE [Wolf.Data] SET  READ_WRITE 
GO
