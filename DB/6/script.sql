USE [master]
GO
/****** Object:  Database [ELearning]    Script Date: 2/25/2020 8:35:27 AM ******/
CREATE DATABASE [ELearning]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ELearning', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ELearning.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ELearning_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ELearning_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[Comment]    Script Date: 2/25/2020 8:35:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[LectureId] [int] NOT NULL,
	[ReplyId] [int] NULL,
 CONSTRAINT [PK__Comment__3214EC077DFCA5EC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[Document]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[Lecture]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[Rating]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[StudentSubject]    Script Date: 2/25/2020 8:35:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ApproveName] [nvarchar](250) NULL,
 CONSTRAINT [PK__StudentSubject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTest]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 2/25/2020 8:35:28 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 2/25/2020 8:35:28 AM ******/
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
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (1, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (2, N'Hay cái cứt', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'phucnd2', 1, 1)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (3, N'Ừ đúng thế', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'phucnd', 1, 1)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (4, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (5, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (6, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (7, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (8, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (9, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (10, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
INSERT [dbo].[Comment] ([Id], [Content], [Time], [Status], [Username], [LectureId], [ReplyId]) VALUES (11, N'Ui hay quá', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1, N'trangchoooo', 1, NULL)
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (1, N'vi', N'Khóa học lập trình nâng cao', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'<p>Sau loạt b&agrave;i học javascript căn bản th&igrave; m&igrave;nh xin giới thiệu với c&aacute;c bạn series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>, đ&acirc;y l&agrave; series rất quan trọng bởi khi bạn muốn&nbsp;<a href="https://freetuts.net/hoc-nodejs" title="học nodejs">học nodejs</a>&nbsp;hoặc c&aacute;c Javascript Framework th&igrave; đ&acirc;y l&agrave; những kiến thức bắt buộc.</p>

<p><img alt="" src="https://freetuts.net/upload/tut_series/images/2016/03/09/76/javascript-nang-cao.gif" /></p>

<p>V&igrave; kiến thức c&oacute; hạn n&ecirc;n những chia sẻ của m&igrave;nh c&oacute; tham khảo t&agrave;i liệu tr&ecirc;n mạng, sau đ&oacute; tổng hợp v&agrave; viết lại theo lời văn của m&igrave;nh. Ngo&agrave;i ra m&igrave;nh cũng sẽ bổ sung những kinh nghiệm ri&ecirc;ng khi l&agrave;m việc với Javascript.</p>
', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-22T14:39:18.127' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T14:40:16.170' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (26, N'vi', N'Khóa học lập trình nâng cao 1', N'/FileUploads/images/lg1.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'1', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-22T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (27, N'vi', N'Khóa học lập trình nâng cao 2', N'/FileUploads/images/lg2.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'2', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-23T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-23T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (28, N'vi', N'Khóa học lập trình nâng cao 3', N'/FileUploads/images/lg3.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'3', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-24T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-24T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (29, N'vi', N'Khóa học lập trình nâng cao 4', N'/FileUploads/images/lg4.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'4', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-25T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-25T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (30, N'vi', N'Khóa học lập trình nâng cao 5', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'5', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-26T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-26T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (31, N'vi', N'Khóa học lập trình nâng cao 6', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'6', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-27T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-27T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (32, N'vi', N'Khóa học lập trình nâng cao 7', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'7', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-28T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-28T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (33, N'vi', N'Khóa học lập trình nâng cao 8', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'8', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-02-29T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-02-29T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (34, N'vi', N'Khóa học lập trình nâng cao 9', N'/FileUploads/images/9.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'9', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (35, N'vi', N'Khóa học lập trình nâng cao 10', N'/FileUploads/images/8.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'10', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-02T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-02T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (36, N'vi', N'Khóa học lập trình nâng cao 11', N'/FileUploads/images/7.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'11', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-03T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-03T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (37, N'vi', N'Khóa học lập trình nâng cao 12', N'/FileUploads/images/6.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'12', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-04T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-04T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (38, N'vi', N'Khóa học lập trình nâng cao 13', N'/FileUploads/images/5.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'13', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-05T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-05T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (39, N'vi', N'Khóa học lập trình nâng cao 14', N'/FileUploads/images/lg4.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'14', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-06T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-06T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (40, N'vi', N'Khóa học lập trình nâng cao 15', N'/FileUploads/images/lg3.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'15', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-07T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-07T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (41, N'vi', N'Khóa học lập trình nâng cao 16', N'/FileUploads/images/lg2.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'16', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-08T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-08T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
INSERT [dbo].[Course] ([Id], [LanguageId], [Name], [Image], [Description], [Content], [Benefits], [Requirements], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [TopHot]) VALUES (42, N'vi', N'Khóa học lập trình nâng cao 17', N'/FileUploads/images/lg1.jpg', N'Trong phần này bạn sẽ được học kiến thức liên quan đến Javascript nâng cao nằm trong chuyên mục Javascript, nếu có vấn đề thắc mắc thì hãy liên hệ admin để được hướng dẫn.', N'17', N'Vì kiến thức có hạn nên những chia sẻ của mình có tham khảo tài liệu trên mạng, sau đó tổng hợp', N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú pháp của ES6 để khỏi bị tụt hậu', CAST(N'2020-03-09T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-03-09T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 0)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Lecture] ON 

INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (1, N' Bài 1: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (2, N' Bài 2: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (3, N' Bài 3: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (4, N' Bài 4: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (5, N' Bài 5: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (6, N' Bài 6: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (7, N' Bài 7: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (8, N' Bài 8: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (9, N' Bài 9: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (10, N' Bài 10: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (11, N' Bài 11: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (12, N' Bài 12: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (13, N' Bài 14: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (14, N' Bài 15: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (15, N' Bài 16: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
INSERT [dbo].[Lecture] ([Id], [Name], [SubjectId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [UrlVideo], [TimeVideo]) VALUES (16, N' Bài 17: Tạo chương trình javascript đầu tiên', 1, CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T17:25:22.960' AS DateTime), N'Thùy Linh', N'/FileUploads/files/2020-02-10_18-40-46.mp4', 17.368526)
SET IDENTITY_INSERT [dbo].[Lecture] OFF
SET IDENTITY_INSERT [dbo].[StudentSubject] ON 

INSERT [dbo].[StudentSubject] ([Id], [Username], [SubjectId], [Status], [CreatedDate], [ApproveName]) VALUES (1, N'phucnd', 1, 1, CAST(N'2019-01-01T00:00:00.000' AS DateTime), N'Thùy Linh')
INSERT [dbo].[StudentSubject] ([Id], [Username], [SubjectId], [Status], [CreatedDate], [ApproveName]) VALUES (2, N'phucnd', 7, 1, CAST(N'2020-02-22T23:42:44.323' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[StudentSubject] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (1, N'Javascript nâng cao', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>
', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-02-22T14:51:51.033' AS DateTime), N'Thùy Linh', CAST(N'2020-02-22T14:51:51.037' AS DateTime), N'Thùy Linh', 0, 200, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (6, N'Javascript nâng cao 2', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-02T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-02T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 201, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (7, N'Javascript nâng cao 3', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-03T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-03T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 202, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (8, N'Javascript nâng cao 4', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-04T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-04T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 203, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (9, N'Javascript nâng cao 5', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-05T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-05T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 204, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (10, N'Javascript nâng cao 6', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 205, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (11, N'Javascript nâng cao 7', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-07T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-07T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 206, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (12, N'Javascript nâng cao 8', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-08T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-08T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 207, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (13, N'Javascript nâng cao 9', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-09T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-09T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 208, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
INSERT [dbo].[Subject] ([Id], [Name], [Content], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [NumberStudent], [MaxStudent], [CourseId], [Status], [Description]) VALUES (14, N'Javascript nâng cao 10', N'<p>ES6 l&agrave; một chuẩn Javascript mới được đưa ra v&agrave;o năm 2015&nbsp;với nhiều quy tắc v&agrave; c&aacute;ch sử dụng kh&aacute;c nhau với nhiều c&uacute; ph&aacute;p mới v&agrave; n&acirc;ng cao hơn nhằm gi&uacute;p lập tr&igrave;nh vi&ecirc;n đa dạng h&oacute;a c&aacute;c m&atilde; code để đạt hiệu xuất cao. V&igrave; vậy trong series học&nbsp;<strong>Javascript n&acirc;ng cao</strong>&nbsp;n&agrave;y m&igrave;nh cũng sẽ giới thiệu đến c&aacute;c bạn c&uacute; ph&aacute;p của ES6 để khỏi bị tụt hậu</p>', N'/FileUploads/images/mon-hoc-lap-trinh-vien-javascript.png', CAST(N'2020-01-10T00:00:00.000' AS DateTime), N'Thùy Linh', CAST(N'2020-01-10T00:00:00.000' AS DateTime), N'Thùy Linh', 1, 209, 1, 1, N'ES6 là một chuẩn Javascript mới được đưa ra vào năm 2015 với nhiều quy tắc và cách sử dụng khác nhau với nhiều cú pháp mới và nâng cao hơn nhằm giúp lập trình viên đa dạng hóa các mã code để đạt hiệu xuất cao. Vì vậy trong series học Javascript nâng cao này mình cũng sẽ giới thiệu đến các bạn cú phá')
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[TeacherSubject] ON 

INSERT [dbo].[TeacherSubject] ([Id], [Username], [SubjectId], [StartTime], [FinishTime]) VALUES (1, N'trangcho', 1, CAST(N'2020-01-01' AS Date), CAST(N'2020-01-02' AS Date))
SET IDENTITY_INSERT [dbo].[TeacherSubject] OFF
INSERT [dbo].[User] ([Username], [Password], [Status], [RoleId], [FullName], [Email], [Phone], [IsLocked], [LinkAvata], [DateOfBirth], [Gender]) VALUES (N'admin', N'QUbfHrxLK0muGx2imsJH9vdbeEHDvmlS', 1, 1, N'Thùy Linh', N'link@gmail.com', N'0973652652', 0, NULL, CAST(N'1997-01-01' AS Date), 0)
INSERT [dbo].[User] ([Username], [Password], [Status], [RoleId], [FullName], [Email], [Phone], [IsLocked], [LinkAvata], [DateOfBirth], [Gender]) VALUES (N'phucnd', N'QUbfHrxLK0muGx2imsJH9vdbeEHDvmlS', 1, 3, N'Đình Phúc', N'link@gmail.com', N'0973652652', 0, N'/Content/images/team/2.png', CAST(N'1997-01-01' AS Date), 1)
INSERT [dbo].[User] ([Username], [Password], [Status], [RoleId], [FullName], [Email], [Phone], [IsLocked], [LinkAvata], [DateOfBirth], [Gender]) VALUES (N'phucnd2', N'QUbfHrxLK0muGx2imsJH9vdbeEHDvmlS', 1, 3, N'Đình Phúc', N'link@gmail.com', N'0973652652', 0, N'/Content/images/team/2.png', CAST(N'1997-01-01' AS Date), 1)
INSERT [dbo].[User] ([Username], [Password], [Status], [RoleId], [FullName], [Email], [Phone], [IsLocked], [LinkAvata], [DateOfBirth], [Gender]) VALUES (N'trangcho', N'QUbfHrxLK0muGx2imsJH9vdbeEHDvmlS', 1, 2, N'Trang chó', N'uim89127@zzrgg.com', N'0973642632', 0, N'/FileUploads/images/28618678.png', CAST(N'1997-10-13' AS Date), 0)
INSERT [dbo].[User] ([Username], [Password], [Status], [RoleId], [FullName], [Email], [Phone], [IsLocked], [LinkAvata], [DateOfBirth], [Gender]) VALUES (N'trangchoooo', N'QUbfHrxLK0muGx2imsJH9vdbeEHDvmlS', 1, 3, N'Trang cực chó', N'link@gmail.com', N'0973652652', 0, N'/Content/images/team/2.png', CAST(N'1997-01-01' AS Date), 1)
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK__Comment__Lecture__7B5B524B] FOREIGN KEY([LectureId])
REFERENCES [dbo].[Lecture] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK__Comment__Lecture__7B5B524B]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK__Comment__Usernam__7A672E12] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK__Comment__Usernam__7A672E12]
GO
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
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_User] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentCourse_User]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Subject]
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
