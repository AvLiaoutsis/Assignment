USE [master]
GO
/****** Object:  Database [Cite_Assignment]    Script Date: 4/6/2020 20:56:27 ******/
CREATE DATABASE [Cite_Assignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cite_Assignment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Cite_Assignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cite_Assignment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Cite_Assignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Cite_Assignment] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cite_Assignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cite_Assignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cite_Assignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cite_Assignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cite_Assignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cite_Assignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cite_Assignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cite_Assignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cite_Assignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cite_Assignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cite_Assignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cite_Assignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cite_Assignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cite_Assignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cite_Assignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cite_Assignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cite_Assignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cite_Assignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cite_Assignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cite_Assignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cite_Assignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cite_Assignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cite_Assignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cite_Assignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cite_Assignment] SET  MULTI_USER 
GO
ALTER DATABASE [Cite_Assignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cite_Assignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cite_Assignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cite_Assignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cite_Assignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cite_Assignment] SET QUERY_STORE = OFF
GO
USE [Cite_Assignment]
GO
/****** Object:  User [Lincoln14]    Script Date: 4/6/2020 20:56:27 ******/
CREATE USER [Lincoln14] FOR LOGIN [Lincoln14] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 4/6/2020 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[ATTR_ID] [uniqueidentifier] NOT NULL,
	[ATTR_Name] [nvarchar](50) NOT NULL,
	[ATTR_Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[ATTR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/6/2020 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EMP_ID] [uniqueidentifier] NOT NULL,
	[EMP_Name] [nvarchar](100) NOT NULL,
	[EMP_DateOfHire] [datetime] NOT NULL,
	[EMP_Supervisor] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAttribute]    Script Date: 4/6/2020 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAttribute](
	[EMPATTR_EmployeeID] [uniqueidentifier] NOT NULL,
	[EMPATTR_AttributeID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EmployeeAttribute] PRIMARY KEY CLUSTERED 
(
	[EMPATTR_EmployeeID] ASC,
	[EMPATTR_AttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeSpecial]    Script Date: 4/6/2020 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSpecial](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[Name] [nvarchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[HasCar] [bit] NOT NULL,
	[StreetAddress] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmployeeSpecial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeSpecialAttribute]    Script Date: 4/6/2020 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSpecialAttribute](
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[AttributeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EmployeeSpecialAttribute] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Attribute] ([ATTR_ID], [ATTR_Name], [ATTR_Value]) VALUES (N'58663d97-fde2-40a6-00a2-08d806b67011', N'Height', N'Dwarf')
INSERT [dbo].[Attribute] ([ATTR_ID], [ATTR_Name], [ATTR_Value]) VALUES (N'70c311f5-b2b0-4118-a069-3ab9c3ac65e1', N'Height', N'Short')
INSERT [dbo].[Attribute] ([ATTR_ID], [ATTR_Name], [ATTR_Value]) VALUES (N'4f8eac6b-8b29-4716-a597-c8cde3a3996d', N'Weight', N'Heavy')
INSERT [dbo].[Attribute] ([ATTR_ID], [ATTR_Name], [ATTR_Value]) VALUES (N'f27b9c58-fd9e-4eb1-9b09-e01ff7032cc8', N'Weight', N'Thin')
INSERT [dbo].[Employee] ([EMP_ID], [EMP_Name], [EMP_DateOfHire], [EMP_Supervisor]) VALUES (N'82d58d49-72a2-42b0-a250-471e5c10d7d9', N'Greg', CAST(N'2020-06-01T15:05:20.853' AS DateTime), NULL)
INSERT [dbo].[Employee] ([EMP_ID], [EMP_Name], [EMP_DateOfHire], [EMP_Supervisor]) VALUES (N'7012f5c7-33ad-4839-a092-4fa6e1448a5d', N'Aura', CAST(N'2020-06-01T15:05:20.857' AS DateTime), N'82d58d49-72a2-42b0-a250-471e5c10d7d9')
INSERT [dbo].[Employee] ([EMP_ID], [EMP_Name], [EMP_DateOfHire], [EMP_Supervisor]) VALUES (N'8cee7a83-a9eb-4170-b7e8-5d4f0440c074', N'Oleg', CAST(N'2020-06-01T15:05:20.857' AS DateTime), N'82d58d49-72a2-42b0-a250-471e5c10d7d9')
INSERT [dbo].[Employee] ([EMP_ID], [EMP_Name], [EMP_DateOfHire], [EMP_Supervisor]) VALUES (N'28106345-435b-4215-aecf-7c226c071e11', N'Paul', CAST(N'2020-06-01T15:05:20.857' AS DateTime), N'82d58d49-72a2-42b0-a250-471e5c10d7d9')
INSERT [dbo].[Employee] ([EMP_ID], [EMP_Name], [EMP_DateOfHire], [EMP_Supervisor]) VALUES (N'2e3074e7-8ffb-4c5f-83ae-962812f93d08', N'Phil', CAST(N'2020-06-01T15:05:20.857' AS DateTime), N'82d58d49-72a2-42b0-a250-471e5c10d7d9')
INSERT [dbo].[Employee] ([EMP_ID], [EMP_Name], [EMP_DateOfHire], [EMP_Supervisor]) VALUES (N'561e2d88-a747-460f-99e1-cfb1d3d8ca5c', N'Pete', CAST(N'2020-06-01T15:05:20.857' AS DateTime), N'8cee7a83-a9eb-4170-b7e8-5d4f0440c074')
INSERT [dbo].[EmployeeSpecial] ([Id], [EmployeeId], [Name], [BirthDate], [HasCar], [StreetAddress]) VALUES (N'b4d0d41f-5cd6-4401-8eff-08d8070fbebf', N'00000000-0000-0000-0000-000000000000', N'Zico', CAST(N'1984-12-31T00:00:00.000' AS DateTime), 1, N'37.920354048834334,23.740256914272106')
INSERT [dbo].[EmployeeSpecial] ([Id], [EmployeeId], [Name], [BirthDate], [HasCar], [StreetAddress]) VALUES (N'bd1d7334-5304-4847-862d-08d8086bea28', N'00000000-0000-0000-0000-000000000000', N'Avraam', CAST(N'1995-10-14T00:00:00.000' AS DateTime), 0, N'37.97140615814149,23.72482125663792')
INSERT [dbo].[EmployeeSpecial] ([Id], [EmployeeId], [Name], [BirthDate], [HasCar], [StreetAddress]) VALUES (N'b919cf54-c43a-4fdd-862e-08d8086bea28', N'00000000-0000-0000-0000-000000000000', N'Alex Pico', CAST(N'2003-06-04T00:00:00.000' AS DateTime), 1, N'38.011447295091905,23.726441378268532')
INSERT [dbo].[EmployeeSpecialAttribute] ([EmployeeId], [AttributeId]) VALUES (N'b4d0d41f-5cd6-4401-8eff-08d8070fbebf', N'4f8eac6b-8b29-4716-a597-c8cde3a3996d')
INSERT [dbo].[EmployeeSpecialAttribute] ([EmployeeId], [AttributeId]) VALUES (N'bd1d7334-5304-4847-862d-08d8086bea28', N'4f8eac6b-8b29-4716-a597-c8cde3a3996d')
INSERT [dbo].[EmployeeSpecialAttribute] ([EmployeeId], [AttributeId]) VALUES (N'b919cf54-c43a-4fdd-862e-08d8086bea28', N'58663d97-fde2-40a6-00a2-08d806b67011')
INSERT [dbo].[EmployeeSpecialAttribute] ([EmployeeId], [AttributeId]) VALUES (N'b919cf54-c43a-4fdd-862e-08d8086bea28', N'4f8eac6b-8b29-4716-a597-c8cde3a3996d')
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([EMP_Supervisor])
REFERENCES [dbo].[Employee] ([EMP_ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[EmployeeAttribute]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAttribute_Attribute] FOREIGN KEY([EMPATTR_AttributeID])
REFERENCES [dbo].[Attribute] ([ATTR_ID])
GO
ALTER TABLE [dbo].[EmployeeAttribute] CHECK CONSTRAINT [FK_EmployeeAttribute_Attribute]
GO
ALTER TABLE [dbo].[EmployeeAttribute]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAttribute_Employee] FOREIGN KEY([EMPATTR_EmployeeID])
REFERENCES [dbo].[Employee] ([EMP_ID])
GO
ALTER TABLE [dbo].[EmployeeAttribute] CHECK CONSTRAINT [FK_EmployeeAttribute_Employee]
GO
ALTER TABLE [dbo].[EmployeeSpecialAttribute]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSpecialAttribute_Attribute] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attribute] ([ATTR_ID])
GO
ALTER TABLE [dbo].[EmployeeSpecialAttribute] CHECK CONSTRAINT [FK_EmployeeSpecialAttribute_Attribute]
GO
ALTER TABLE [dbo].[EmployeeSpecialAttribute]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSpecialAttribute_EmployeeSpecial] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeSpecial] ([Id])
GO
ALTER TABLE [dbo].[EmployeeSpecialAttribute] CHECK CONSTRAINT [FK_EmployeeSpecialAttribute_EmployeeSpecial]
GO
/****** Object:  StoredProcedure [dbo].[CreateTeam]    Script Date: 4/6/2020 20:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE  PROCEDURE [dbo].[CreateTeam]
(
    @id uniqueidentifier
)
AS
BEGIN
		INSERT INTO dbo.Attribute VALUES( NEWID(),'TEAM',@id)

		DECLARE @attr varchar(50);         
		SELECT @attr =  ATTR_ID    from dbo.Attribute where attr_name ='TEAM' AND attr_value =@id;

		INSERT INTO dbo.EmployeeAttribute
		SELECT EMP_ID,@attr
		FROM 
		dbo.Employee As employee
		LEFT JOIN dbo.EmployeeAttribute as jointable
		ON jointable.EMPATTR_EmployeeID = employee.EMP_ID
		WHERE EMPATTR_AttributeId  != @attr AND EMP_Supervisor = @id
END

exec CreateTeam '82D58D49-72A2-42B0-A250-471E5C10D7D9'
GO
USE [master]
GO
ALTER DATABASE [Cite_Assignment] SET  READ_WRITE 
GO
