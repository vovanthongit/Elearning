USE [master]
GO
/****** Object:  Database [ELearning]    Script Date: 2/20/2020 5:46:29 PM ******/
CREATE DATABASE [ELearning]
 GO
ALTER DATABASE [ELearning] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ELearning].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ELearning] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ELearning] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ELearning] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ELearning] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ELearning] SET ARITHABORT OFF 
GO
ALTER DATABASE [ELearning] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ELearning] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ELearning] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ELearning] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ELearning] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ELearning] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ELearning] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ELearning] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ELearning] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ELearning] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ELearning] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ELearning] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ELearning] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ELearning] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ELearning] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ELearning] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ELearning] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ELearning] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ELearning] SET  MULTI_USER 
GO
ALTER DATABASE [ELearning] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ELearning] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ELearning] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ELearning] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ELearning] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ELearning] SET QUERY_STORE = OFF
GO
USE [ELearning]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content_Comment] [varchar](5000) NULL,
	[Time] [datetime] NULL,
	[Deleted] [varchar](5000) NULL,
	[Username] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [varchar](2) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Image] [varchar](250) NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Benefits] [nvarchar](1000) NULL,
	[Requirements] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[TopHot] [bit] NOT NULL,
 CONSTRAINT [PK__Course__3214EC07BB439447] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[UrlDocument] [varchar](5000) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Document__3214EC0700AF9B37] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecture]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[UrlVideo] [varchar](250) NOT NULL,
	[TimeVideo] [float] NOT NULL,
 CONSTRAINT [PK__Lecture__3214EC079BB7B8DD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Point] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[CourseId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTest]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileAnswer] [varchar](250) NULL,
	[ReplyFile] [varchar](250) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Point] [int] NULL,
	[Email] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Image] [varchar](250) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[NumberStudent] [int] NOT NULL,
	[MaxStudent] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__Subject__3214EC07B64CE5AB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[StartTime] [date] NOT NULL,
	[FinishTime] [date] NULL,
 CONSTRAINT [PK__TeacherS__3214EC07440C7747] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/20/2020 5:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Phone] [varchar](50) NULL,
	[IsLocked] [bit] NOT NULL,
	[LinkAvata] [varchar](250) NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [bit] NOT NULL,
 CONSTRAINT [PK__User__536C85E5221358BB] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Teacher')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Student')
INSERT [dbo].[User] ([Username], [Password], [Status], [RoleId], [FullName], [Email], [Phone], [IsLocked], [LinkAvata], [DateOfBirth], [Gender]) VALUES (N'admin', N'QUbfHrxLK0muGx2imsJH9vdbeEHDvmlS', 1, 1, N'Thuỳ Linh', N'a@gmail.com', N'012345678', 0, NULL, CAST(N'1997-05-05' AS Date), 0)
INSERT [dbo].[User] ([Username], [Password], [Status], [RoleId], [FullName], [Email], [Phone], [IsLocked], [LinkAvata], [DateOfBirth], [Gender]) VALUES (N'phucnd', N'QUbfHrxLK0muGx2imsJH9vdbeEHDvmlS', 1, 1, N'Đình Phúc', N'uim89127@zzrgg.com', N'0973642632', 0, N'/FileUploads/images/28618678.png', CAST(N'1997-08-18' AS Date), 0)
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK__Document__Subject__300424B4] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK__Document__Subject__300424B4]
GO
ALTER TABLE [dbo].[Lecture]  WITH CHECK ADD  CONSTRAINT [FK__Lecture__Subject__32E0915F] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Lecture] CHECK CONSTRAINT [FK__Lecture__Subject__32E0915F]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK__Rating__CourseId__38996AB5] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK__Rating__CourseId__38996AB5]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK__StudentCo__Cours__3D5E1FD2] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK__StudentCo__Cours__3D5E1FD2]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_User] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_User]
GO
ALTER TABLE [dbo].[StudentTest]  WITH CHECK ADD  CONSTRAINT [FK__StudentTe__Subje__35BCFE0A] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[StudentTest] CHECK CONSTRAINT [FK__StudentTe__Subje__35BCFE0A]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Course]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK__TeacherSu__Subje__403A8C7D] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK__TeacherSu__Subje__403A8C7D]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_User] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_User]
GO
USE [master]
GO
ALTER DATABASE [ELearning] SET  READ_WRITE 
GO
