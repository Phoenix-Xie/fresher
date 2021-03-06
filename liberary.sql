USE [master]
GO
/****** Object:  Database [Liberary]    Script Date: 2017/11/12 16:55:47 ******/
CREATE DATABASE [Liberary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Liberary', FILENAME = N'D:\分离后的数据库\Liberary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Liberary_log', FILENAME = N'D:\分离后的数据库\Liberary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Liberary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Liberary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Liberary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Liberary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Liberary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Liberary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Liberary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Liberary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Liberary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Liberary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Liberary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Liberary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Liberary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Liberary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Liberary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Liberary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Liberary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Liberary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Liberary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Liberary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Liberary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Liberary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Liberary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Liberary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Liberary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Liberary] SET RECOVERY FULL 
GO
ALTER DATABASE [Liberary] SET  MULTI_USER 
GO
ALTER DATABASE [Liberary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Liberary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Liberary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Liberary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Liberary', N'ON'
GO
USE [Liberary]
GO
/****** Object:  Table [dbo].[books]    Script Date: 2017/11/12 16:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_name] [nvarchar](50) NOT NULL,
	[book_author_name] [nvarchar](50) NOT NULL,
	[book_class] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[comments]    Script Date: 2017/11/12 16:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_name] [nvarchar](50) NOT NULL,
	[people_name] [nvarchar](50) NOT NULL,
	[comment] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[secret]    Script Date: 2017/11/12 16:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[secret](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[secretName] [nvarchar](50) NOT NULL,
	[secretPwd] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_secret] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[secretkeypwd]    Script Date: 2017/11/12 16:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[secretkeypwd](
	[keypwd] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_book_relation]    Script Date: 2017/11/12 16:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_book_relation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[book_name_borrow] [nvarchar](50) NOT NULL,
	[book_borrow_start_days] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_user_book_relation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 2017/11/12 16:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[userPwd] [nvarchar](50) NOT NULL,
	[userQuestion] [nvarchar](50) NOT NULL,
	[userAnswer] [nvarchar](50) NOT NULL,
	[userCollege] [nvarchar](50) NOT NULL,
 CONSTRAINT [user_name_unique] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[books] ON 

INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (0, N'python2', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (1, N'C程序语言设计', N'谭浩强', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (2, N'电工学', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (3, N'高等数学习题全解指南         ', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (4, N'高等数学第六版 ', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (5, N'环球科学', N'hello', N'computer', N'已借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (8, N'python', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (9, N'java', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (11, N'JavaScript', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (12, N'C', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (13, N'C++', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (14, N'C#', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (15, N'Ruby', N'hello', N'computer', N'未借出')
INSERT [dbo].[books] ([id], [book_name], [book_author_name], [book_class], [status]) VALUES (16, N'perl', N'hello', N'computer', N'未借出')
SET IDENTITY_INSERT [dbo].[books] OFF
SET IDENTITY_INSERT [dbo].[comments] ON 

INSERT [dbo].[comments] ([id], [book_name], [people_name], [comment]) VALUES (1, N'python2', N'张鸿儒', N'很好看')
INSERT [dbo].[comments] ([id], [book_name], [people_name], [comment]) VALUES (8, N'python2', N'1', N'还可以')
INSERT [dbo].[comments] ([id], [book_name], [people_name], [comment]) VALUES (9, N'C程序语言设计', N'高冷学姐', N'玄学')
INSERT [dbo].[comments] ([id], [book_name], [people_name], [comment]) VALUES (10, N'JavaScript', N'zhang', N'zswdgbnm')
SET IDENTITY_INSERT [dbo].[comments] OFF
SET IDENTITY_INSERT [dbo].[secret] ON 

INSERT [dbo].[secret] ([id], [secretName], [secretPwd]) VALUES (1, N'123', N'灭读书')
INSERT [dbo].[secret] ([id], [secretName], [secretPwd]) VALUES (2, N'abc', N'abc')
SET IDENTITY_INSERT [dbo].[secret] OFF
SET IDENTITY_INSERT [dbo].[user_book_relation] ON 

INSERT [dbo].[user_book_relation] ([id], [user_name], [book_name_borrow], [book_borrow_start_days]) VALUES (25, N'1', N'环球科学', N'2017/11/12')
SET IDENTITY_INSERT [dbo].[user_book_relation] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [userName], [userPwd], [userQuestion], [userAnswer], [userCollege]) VALUES (9, N'1', N'灭读书aA@', N'小时候最喜欢的人的名字', N'123', N'信息科学与工程学院')
SET IDENTITY_INSERT [dbo].[users] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [book_name_unique]    Script Date: 2017/11/12 16:55:47 ******/
CREATE UNIQUE NONCLUSTERED INDEX [book_name_unique] ON [dbo].[books]
(
	[book_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_user]    Script Date: 2017/11/12 16:55:47 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_user] ON [dbo].[users]
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [comments_of_books] FOREIGN KEY([book_name])
REFERENCES [dbo].[books] ([book_name])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [comments_of_books]
GO
ALTER TABLE [dbo].[user_book_relation]  WITH CHECK ADD  CONSTRAINT [book_name] FOREIGN KEY([book_name_borrow])
REFERENCES [dbo].[books] ([book_name])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[user_book_relation] CHECK CONSTRAINT [book_name]
GO
ALTER TABLE [dbo].[user_book_relation]  WITH CHECK ADD  CONSTRAINT [FK_user_book_relation_users] FOREIGN KEY([user_name])
REFERENCES [dbo].[users] ([userName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[user_book_relation] CHECK CONSTRAINT [FK_user_book_relation_users]
GO
USE [master]
GO
ALTER DATABASE [Liberary] SET  READ_WRITE 
GO
