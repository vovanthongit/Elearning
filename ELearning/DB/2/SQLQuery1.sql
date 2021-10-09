Create database ELearning
Go
USE [ELearning]
GO
CREATE TABLE [dbo].[User](
	[Username] [varchar](50) NOT NULL PRIMARY KEY,
	[Password] [varchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Phone] [varchar](50) NULL,
	[IsLocked] [bit] NOT NULL,
) 
go
CREATE TABLE [dbo].[Comment](
	[Id] [int]  IDENTITY(1,1) NOT NULL PRIMARY KEY ,
	[Content_Comment] [varchar](5000) NULL,
	[Time] [datetime] NULL,
	[Deleted] [varchar](5000) NULL,
	[Username] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
)
go
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[LanguageId] [varchar](2) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Image] [varchar](250) NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[NumberStudent] [int] NOT NULL,
	[MaxStudent] [int] NOT NULL,
	[Benefits] [nvarchar](1000) NULL,
	[Author] [nvarchar](100) NOT NULL,
	[Requirements] [nvarchar](1000) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[Status] bit NOT NULL,
	[TopHot] bit NOT NULL
) 
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	[Name] [nvarchar](250) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Images] [varchar](250) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	NumberStudent	int	 NOT NULL,
	MaxStudent	int	 NOT NULL,
 )  
GO 
CREATE TABLE [dbo].[CourseSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CourseId] [int] NOT NULL FOREIGN KEY REFERENCES Course (Id) ,
	[SubjectId] [int] NOT NULL  FOREIGN KEY REFERENCES [Subject] (Id)
 ) 
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Url_Document] [varchar](5000) NULL,
	[CourseId] [int] NOT NULL  FOREIGN KEY REFERENCES Course (Id),
  )  
GO
CREATE TABLE [dbo].[Lecture](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ,
	[Name] [nvarchar](250) NOT NULL,
	[SubjectId] [int] NOT NULL  FOREIGN KEY REFERENCES [Subject] (Id),
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[UrlVideo] [varchar](250) NOT NULL,
	[TimeVideo] [bigint] NOT NULL,
  )  
GO
CREATE TABLE [dbo].StudentTest(
	[Id] [int] IDENTITY(1,1) NOT NULL   PRIMARY KEY , 
	[FileAnswer] [varchar](250) NULL,
	[ReplyFile] [varchar](250) NOT NULL,
	[SubjectId] [int] NOT NULL FOREIGN KEY REFERENCES [Subject] (Id),
	Point int,
	Email varchar(250) NOT NULL
 ) 
GO
CREATE TABLE [dbo].[Rating](
	[Id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	[Point] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CourseId] [int] NOT NULL FOREIGN KEY REFERENCES Course (Id),
  ) 
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](255) NOT NULL,
  ) 
GO
CREATE TABLE [dbo].[StudentCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL   PRIMARY KEY ,
	[Username] [varchar](50) NOT NULL,
	[CourseId] [int] NOT NULL  FOREIGN KEY REFERENCES Course (Id),
 ) 
GO

CREATE TABLE [dbo].[TeacherSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY,
	[Username] [varchar](50) NOT NULL,
	[SubjectId] [int] NOT NULL  FOREIGN KEY REFERENCES [subject] (Id)
 )  
GO
