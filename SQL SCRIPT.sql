create database BotKZ
USE [BotKZ]
GO
/****** Object:  Table [dbo].[Autorize]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autorize](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login_a] [nvarchar](100) NULL,
	[password_a] [nvarchar](100) NULL,
	[fio] [nvarchar](200) NULL,
	[stat] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ban_list]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ban_list](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code_user] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groupp]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groupp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[connecting] [nvarchar](2000) NULL,
	[tipe] [nvarchar](100) NULL,
	[Callback_id] [nvarchar](100) NULL,
	[name_group] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groupp_les]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groupp_les](
	[num_group] [int] NOT NULL,
	[group_theme] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[num_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lesson]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lesson](
	[id_les] [int] IDENTITY(1,1) NOT NULL,
	[homework] [nvarchar](1000) NULL,
	[les_group] [int] NULL,
	[date_para] [datetime] NULL,
	[time_para] [nvarchar](1000) NULL,
	[les_prep] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_les] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[saved]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[saved](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login_a] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[id_stud] [int] IDENTITY(1,1) NOT NULL,
	[group_id] [int] NULL,
	[fio] [nvarchar](1000) NULL,
	[fio_par] [nvarchar](1000) NULL,
	[num_par] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_stud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[texts_avt]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[texts_avt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_inc] [datetime] NULL,
	[text_avt] [nvarchar](1000) NULL,
	[tipe] [nvarchar](100) NULL,
	[groupName] [nvarchar](1000) NULL,
	[stat] [nvarchar](1000) NULL,
	[socset] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[texts_ras]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[texts_ras](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_inc] [datetime] NULL,
	[text_ras] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users_track]    Script Date: 03.05.2023 20:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users_track](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_user] [datetime] NULL,
	[text_user] [nvarchar](1000) NULL,
	[code_user] [nvarchar](1000) NULL,
	[text_adm] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autorize] ON 

INSERT [dbo].[Autorize] ([id], [login_a], [password_a], [fio], [stat]) VALUES (1, N'Ludmila', N'1', N'Людмила', N'Admin')
INSERT [dbo].[Autorize] ([id], [login_a], [password_a], [fio], [stat]) VALUES (2, N'Admin', N'1', N'Асеев Денис Валерьевич', N'Admin')
INSERT [dbo].[Autorize] ([id], [login_a], [password_a], [fio], [stat]) VALUES (3, N'Gukov', N'Furry', N'Жуков Алексей Витальевич', N'Prepod')
SET IDENTITY_INSERT [dbo].[Autorize] OFF
GO
SET IDENTITY_INSERT [dbo].[groupp] ON 

INSERT [dbo].[groupp] ([id], [connecting], [tipe], [Callback_id], [name_group]) VALUES (1, N'vk1.a.avKxf8bQt3DTkaXM0fTiDP67RPdgClOIvdcDLuIGnXugVGtZOM9QTxjZ0qNsEy4kuGav2xyrPID0cnstXLcIo_YU_WnF8KTdEpYovH12qCbqm2UCe-BSa3KKTQuKu_sibix__p5HqLGlF8atUJOPXRQ76puUPMySl9Zi2IGkxcUe7OmTNw_CO34mZfNkbWIwJE-AGef4qw0ZJ5clShpxzQ', N'Vk', N'219286842', N'ТестДз')
SET IDENTITY_INSERT [dbo].[groupp] OFF
GO
INSERT [dbo].[groupp_les] ([num_group], [group_theme]) VALUES (1291, N'Взлом пентагона')
INSERT [dbo].[groupp_les] ([num_group], [group_theme]) VALUES (1292, N'c#')
GO
SET IDENTITY_INSERT [dbo].[lesson] ON 

INSERT [dbo].[lesson] ([id_les], [homework], [les_group], [date_para], [time_para], [les_prep]) VALUES (2, N'df', 1292, CAST(N'2023-04-10T00:00:00.000' AS DateTime), N'17:10', 2)
INSERT [dbo].[lesson] ([id_les], [homework], [les_group], [date_para], [time_para], [les_prep]) VALUES (3, NULL, 1292, CAST(N'2023-04-10T00:00:00.000' AS DateTime), N'15:05', 2)
INSERT [dbo].[lesson] ([id_les], [homework], [les_group], [date_para], [time_para], [les_prep]) VALUES (4, NULL, 1292, CAST(N'2023-04-15T00:00:00.000' AS DateTime), N'18:45', 3)
INSERT [dbo].[lesson] ([id_les], [homework], [les_group], [date_para], [time_para], [les_prep]) VALUES (5, NULL, 1292, CAST(N'2023-04-15T00:00:00.000' AS DateTime), N'18:45', 3)
INSERT [dbo].[lesson] ([id_les], [homework], [les_group], [date_para], [time_para], [les_prep]) VALUES (6, N'Сделать компьютер', 1292, CAST(N'2023-04-21T00:00:00.000' AS DateTime), N'10:31', 3)
INSERT [dbo].[lesson] ([id_les], [homework], [les_group], [date_para], [time_para], [les_prep]) VALUES (7, NULL, 1291, CAST(N'2023-04-17T00:00:00.000' AS DateTime), N'12:15', 1)
INSERT [dbo].[lesson] ([id_les], [homework], [les_group], [date_para], [time_para], [les_prep]) VALUES (8, N'ЧТО НИБУДЬ', 1292, CAST(N'2023-04-21T00:00:00.000' AS DateTime), N'9:40', 3)
SET IDENTITY_INSERT [dbo].[lesson] OFF
GO
SET IDENTITY_INSERT [dbo].[saved] ON 

INSERT [dbo].[saved] ([id], [login_a]) VALUES (1, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (2, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (3, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (4, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (5, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (6, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (7, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (8, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (9, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (10, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (11, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (12, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (13, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (14, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (15, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (16, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (17, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (18, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (19, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (20, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (21, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (22, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (23, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (24, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (25, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (26, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (27, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (28, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (29, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (30, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (31, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (32, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (33, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (34, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (35, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (36, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (37, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (38, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (39, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (40, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (41, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (42, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (43, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (44, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (45, N'Admin')
INSERT [dbo].[saved] ([id], [login_a]) VALUES (46, N'Admin')
SET IDENTITY_INSERT [dbo].[saved] OFF
GO
SET IDENTITY_INSERT [dbo].[student] ON 

INSERT [dbo].[student] ([id_stud], [group_id], [fio], [fio_par], [num_par]) VALUES (1, 1292, N'Егорыч', N'Антоныч', N'8935262632')
SET IDENTITY_INSERT [dbo].[student] OFF
GO
ALTER TABLE [dbo].[lesson]  WITH CHECK ADD FOREIGN KEY([les_group])
REFERENCES [dbo].[groupp_les] ([num_group])
GO
ALTER TABLE [dbo].[lesson]  WITH CHECK ADD FOREIGN KEY([les_prep])
REFERENCES [dbo].[Autorize] ([id])
GO
ALTER TABLE [dbo].[student]  WITH CHECK ADD FOREIGN KEY([group_id])
REFERENCES [dbo].[groupp_les] ([num_group])
GO
