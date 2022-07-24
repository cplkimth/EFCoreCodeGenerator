USE [master]
GO
/****** Object:  Database [Chinook]    Script Date: 2022-07-24 오후 5:13:41 ******/
CREATE DATABASE [Chinook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Chinook', FILENAME = N'd:\MSSQL15.MSSQLSERVER\MSSQL\DATA\Chinook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Chinook_log', FILENAME = N'd:\MSSQL15.MSSQLSERVER\MSSQL\DATA\Chinook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Chinook] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Chinook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Chinook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Chinook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Chinook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Chinook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Chinook] SET ARITHABORT OFF 
GO
ALTER DATABASE [Chinook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Chinook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Chinook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Chinook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Chinook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Chinook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Chinook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Chinook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Chinook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Chinook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Chinook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Chinook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Chinook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Chinook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Chinook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Chinook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Chinook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Chinook] SET RECOVERY FULL 
GO
ALTER DATABASE [Chinook] SET  MULTI_USER 
GO
ALTER DATABASE [Chinook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Chinook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Chinook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Chinook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Chinook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Chinook] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Chinook', N'ON'
GO
ALTER DATABASE [Chinook] SET QUERY_STORE = OFF
GO
USE [Chinook]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NULL,
	[CompanyId] [int] NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](160) NOT NULL,
	[ArtistId] [int] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AlbumView]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AlbumView]
AS
SELECT dbo.Album.AlbumId, dbo.Album.Title, dbo.Album.ArtistId, dbo.Artist.Name
FROM  dbo.Album INNER JOIN
            dbo.Artist ON dbo.Album.ArtistId = dbo.Artist.ArtistId
GO
/****** Object:  Table [dbo].[Company]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[PlaylistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistTrack]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistTrack](
	[PlaylistId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
	[Dummy] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistTrackHistory]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistTrackHistory](
	[PlaylistId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
	[WrittenAt] [datetime] NOT NULL,
 CONSTRAINT [PK_PlaylistTrackHistory] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC,
	[TrackId] ASC,
	[WrittenAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[TrackId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[AlbumId] [int] NULL,
	[BitCol] [bit] NOT NULL,
	[BitColNull] [bit] NULL,
	[TinyIntCol] [tinyint] NOT NULL,
	[TinyIntColNull] [tinyint] NULL,
	[SmallIntCol] [smallint] NOT NULL,
	[SmallIntColNull] [smallint] NULL,
	[BigIntCol] [bigint] NOT NULL,
	[BigIntColNull] [bigint] NULL,
	[CharCol] [char](10) NOT NULL,
	[CharColNull] [char](10) NULL,
	[VarCharCol] [varchar](50) NOT NULL,
	[VarCharColNull] [varchar](50) NULL,
	[NcharCol] [nchar](10) NOT NULL,
	[NcharColNull] [nchar](10) NULL,
	[NvarCharCol] [nvarchar](50) NOT NULL,
	[NvarCharColNull] [nvarchar](50) NOT NULL,
	[BinaryCol] [binary](50) NOT NULL,
	[BinaryColNull] [binary](50) NULL,
	[DateCol] [date] NOT NULL,
	[DateColNull] [date] NULL,
	[DateTimeCol] [datetime] NOT NULL,
	[DateTimeColNull] [datetime] NULL,
	[SmallDateTimeCol] [smalldatetime] NOT NULL,
	[SmallDateTimeColNull] [smalldatetime] NULL,
	[DecimalCol] [decimal](18, 2) NOT NULL,
	[DecimalColNull] [decimal](18, 2) NULL,
	[FloatCol] [float] NOT NULL,
	[FloatColNull] [float] NULL,
	[RealCol] [real] NOT NULL,
	[RealColNull] [real] NULL,
	[SmallMoneyCol] [smallmoney] NOT NULL,
	[SmallMoneyColNull] [smallmoney] NULL,
	[TimeStampCol] [timestamp] NOT NULL,
	[TimeCol] [time](7) NOT NULL,
	[TimeColNull] [time](7) NULL,
	[GuidCol] [uniqueidentifier] NOT NULL,
	[GuidColNull] [uniqueidentifier] NULL,
	[VarBinaryCol] [varbinary](50) NOT NULL,
	[VarBinaryColNull] [varbinary](50) NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Album] ON 
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId]) VALUES (1, N'For Those About To Rock We Salute You', 1)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId]) VALUES (2, N'Let There Be Rock', 1)
GO
SET IDENTITY_INSERT [dbo].[Album] OFF
GO
SET IDENTITY_INSERT [dbo].[Artist] ON 
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CompanyId]) VALUES (1, N'AC/DC', NULL)
GO
SET IDENTITY_INSERT [dbo].[Artist] OFF
GO
SET IDENTITY_INSERT [dbo].[Playlist] ON 
GO
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (1, N'Music')
GO
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (2, N'Movies')
GO
SET IDENTITY_INSERT [dbo].[Playlist] OFF
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId], [Dummy]) VALUES (1, 1, NULL)
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId], [Dummy]) VALUES (1, 2, NULL)
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId], [Dummy]) VALUES (2, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Track] ON 
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (1, N'For Those About To Rock (We Salute You)', 1, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'd690c744-a440-4507-8b6e-de3aa0f105d1', NULL, 0x00000000, NULL)
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (2, N'Put The Finger On You', 1, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'ad0974d1-6d70-40e0-8795-c6a4bb29b37c', NULL, 0x00000000, NULL)
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (3, N'Go Down', 2, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'2f390af1-410e-46b0-868e-9622e37bd6ae', NULL, 0x00000000, NULL)
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (4, N'Dog Eat Dog', 2, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'802fb877-f790-4d35-8b76-f7fad47c9407', NULL, 0x00000000, NULL)
GO
SET IDENTITY_INSERT [dbo].[Track] OFF
GO
/****** Object:  Index [IFK_AlbumArtistId]    Script Date: 2022-07-24 오후 5:13:41 ******/
CREATE NONCLUSTERED INDEX [IFK_AlbumArtistId] ON [dbo].[Album]
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_PlaylistTrack]    Script Date: 2022-07-24 오후 5:13:41 ******/
ALTER TABLE [dbo].[PlaylistTrack] ADD  CONSTRAINT [PK_PlaylistTrack] PRIMARY KEY NONCLUSTERED 
(
	[PlaylistId] ASC,
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IFK_PlaylistTrackTrackId]    Script Date: 2022-07-24 오후 5:13:41 ******/
CREATE NONCLUSTERED INDEX [IFK_PlaylistTrackTrackId] ON [dbo].[PlaylistTrack]
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IFK_TrackAlbumId]    Script Date: 2022-07-24 오후 5:13:41 ******/
CREATE NONCLUSTERED INDEX [IFK_TrackAlbumId] ON [dbo].[Track]
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_BitCol]  DEFAULT ((0)) FOR [BitCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_TinyIntCol]  DEFAULT ((0)) FOR [TinyIntCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_SmallIntCol]  DEFAULT ((0)) FOR [SmallIntCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_BigIntCol]  DEFAULT ((0)) FOR [BigIntCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_CharCol]  DEFAULT ('') FOR [CharCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_VarCharCol]  DEFAULT ('') FOR [VarCharCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_NCharCol]  DEFAULT ('') FOR [NcharCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_NVarCharCol]  DEFAULT ('') FOR [NvarCharCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_NVarCharCol1]  DEFAULT ('') FOR [NvarCharColNull]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_BinaryCol]  DEFAULT ((0)) FOR [BinaryCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_DateCol]  DEFAULT (getdate()) FOR [DateCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_DateTimeCol]  DEFAULT (getdate()) FOR [DateTimeCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_SmallDateTimeCol]  DEFAULT (getdate()) FOR [SmallDateTimeCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_DecimalCol]  DEFAULT ((0)) FOR [DecimalCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_FloatCol]  DEFAULT ((0)) FOR [FloatCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_RealCol]  DEFAULT ((0)) FOR [RealCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_SmallMoneyCol]  DEFAULT ((0)) FOR [SmallMoneyCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_TimeCol]  DEFAULT (getdate()) FOR [TimeCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_GuidCol]  DEFAULT (newid()) FOR [GuidCol]
GO
ALTER TABLE [dbo].[Track] ADD  CONSTRAINT [DF_Track_VarBinaryCol]  DEFAULT ((0)) FOR [VarBinaryCol]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_AlbumArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_AlbumArtistId]
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Company]
GO
ALTER TABLE [dbo].[PlaylistTrack]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrackPlaylistId] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlist] ([PlaylistId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistTrack] CHECK CONSTRAINT [FK_PlaylistTrackPlaylistId]
GO
ALTER TABLE [dbo].[PlaylistTrack]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrackTrackId] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([TrackId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistTrack] CHECK CONSTRAINT [FK_PlaylistTrackTrackId]
GO
ALTER TABLE [dbo].[PlaylistTrackHistory]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrackHistory_PlaylistTrack] FOREIGN KEY([PlaylistId], [TrackId])
REFERENCES [dbo].[PlaylistTrack] ([PlaylistId], [TrackId])
GO
ALTER TABLE [dbo].[PlaylistTrackHistory] CHECK CONSTRAINT [FK_PlaylistTrackHistory_PlaylistTrack]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_TrackAlbumId] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_TrackAlbumId]
GO
/****** Object:  StoredProcedure [dbo].[Album_Search]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Album_Search]
	@ArtistId int,
	@Title nvarchar(50)
AS
select AlbumId, Title, ArtistId from Album 
where 
	ArtistId = @ArtistId and 
	Title like '%' + @Title + '%'
GO
/****** Object:  StoredProcedure [dbo].[Initialize]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Initialize]
AS

	delete PlaylistTrack
	delete Playlist
	delete Track
	delete Album
	delete Artist

	SET IDENTITY_INSERT [dbo].[Artist] ON 
	INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (1, N'AC/DC')
	SET IDENTITY_INSERT [dbo].[Artist] OFF
	SET IDENTITY_INSERT [dbo].[Album] ON 
	INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId]) VALUES (1, N'For Those About To Rock We Salute You', 1)
	INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId]) VALUES (2, N'Let There Be Rock', 1)
	SET IDENTITY_INSERT [dbo].[Album] OFF
	SET IDENTITY_INSERT [dbo].[Track] ON 
	INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (1, N'For Those About To Rock (We Salute You)', 1, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'd690c744-a440-4507-8b6e-de3aa0f105d1', NULL, 0x00000000, NULL)
	INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (2, N'Put The Finger On You', 1, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'ad0974d1-6d70-40e0-8795-c6a4bb29b37c', NULL, 0x00000000, NULL)
	INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (3, N'Go Down', 2, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'2f390af1-410e-46b0-868e-9622e37bd6ae', NULL, 0x00000000, NULL)
	INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull]) VALUES (4, N'Dog Eat Dog', 2, 0, NULL, 0, NULL, 0, NULL, 0, NULL, N'          ', NULL, N'', NULL, N'          ', NULL, N'', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2019-07-12' AS Date), NULL, CAST(N'2019-07-12T09:34:23.643' AS DateTime), NULL, CAST(N'2019-07-12T09:34:00' AS SmallDateTime), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, 0, NULL, 0.0000, NULL, CAST(N'09:34:23.6433333' AS Time), NULL, N'802fb877-f790-4d35-8b76-f7fad47c9407', NULL, 0x00000000, NULL)
	SET IDENTITY_INSERT [dbo].[Track] OFF
	SET IDENTITY_INSERT [dbo].[Playlist] ON 
	INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (1, N'Music')
	INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (2, N'Movies')
	SET IDENTITY_INSERT [dbo].[Playlist] OFF
	INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId], [Dummy]) VALUES (1, 1, null)
	INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId], [Dummy]) VALUES (1, 2, null)
	INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId], [Dummy]) VALUES (2, 1, null)
GO
/****** Object:  StoredProcedure [dbo].[Track_Search]    Script Date: 2022-07-24 오후 5:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Track_Search]
	@Name nvarchar(50),
	@ArtistId int
AS

select TrackId, Name, t.AlbumId from Track t
join Album a on t.AlbumId = a.AlbumId
where 
	a.ArtistId = @ArtistId and 
	t.Name like '%' + @Name + '%'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Album"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Artist"
            Begin Extent = 
               Top = 7
               Left = 262
               Bottom = 126
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AlbumView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AlbumView'
GO
USE [master]
GO
ALTER DATABASE [Chinook] SET  READ_WRITE 
GO
