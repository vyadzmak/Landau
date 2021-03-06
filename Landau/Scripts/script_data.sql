USE [LandauDoc]
GO
/****** Object:  Table [dbo].[MoveCategories]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[MoveCategories] ON
INSERT [dbo].[MoveCategories] ([Id], [Name], [Description]) VALUES (1, N'Красное', N'Если красное')
INSERT [dbo].[MoveCategories] ([Id], [Name], [Description]) VALUES (2, N'Зеленое', N'Если зеленое')
INSERT [dbo].[MoveCategories] ([Id], [Name], [Description]) VALUES (3, N'Синее', N'Если синее')
INSERT [dbo].[MoveCategories] ([Id], [Name], [Description]) VALUES (4, N'Желтое', N'Если желтое')
SET IDENTITY_INSERT [dbo].[MoveCategories] OFF
/****** Object:  Table [dbo].[LineType]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[LineType] ON
INSERT [dbo].[LineType] ([Id], [Name]) VALUES (1, N'dashed')
INSERT [dbo].[LineType] ([Id], [Name]) VALUES (2, N'dotted')
INSERT [dbo].[LineType] ([Id], [Name]) VALUES (3, N'solid')
SET IDENTITY_INSERT [dbo].[LineType] OFF
/****** Object:  Table [dbo].[DocumentTypes]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[DocumentTypes] ON
INSERT [dbo].[DocumentTypes] ([Id], [Type]) VALUES (1, N'doc')
INSERT [dbo].[DocumentTypes] ([Id], [Type]) VALUES (2, N'excel')
INSERT [dbo].[DocumentTypes] ([Id], [Type]) VALUES (3, N'pdf')
INSERT [dbo].[DocumentTypes] ([Id], [Type]) VALUES (4, N'image')
INSERT [dbo].[DocumentTypes] ([Id], [Type]) VALUES (5, N'txt')
SET IDENTITY_INSERT [dbo].[DocumentTypes] OFF
/****** Object:  Table [dbo].[DocumentState]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[DocumentState] ON
INSERT [dbo].[DocumentState] ([Id], [State]) VALUES (1, N'Загружен')
INSERT [dbo].[DocumentState] ([Id], [State]) VALUES (2, N'Подтвержден')
INSERT [dbo].[DocumentState] ([Id], [State]) VALUES (3, N'Прочтен')
INSERT [dbo].[DocumentState] ([Id], [State]) VALUES (4, N'В обработке')
INSERT [dbo].[DocumentState] ([Id], [State]) VALUES (5, N'Готово')
INSERT [dbo].[DocumentState] ([Id], [State]) VALUES (6, N'Ошибка')
SET IDENTITY_INSERT [dbo].[DocumentState] OFF
/****** Object:  Table [dbo].[Clients]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1087, N'ASD', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1088, N'Нетвикс', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1089, N'ASD', 333, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1090, N'Банк', 101, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1091, N'123', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1092, N'123', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1093, N'987', 987, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1094, N'1234', 12345, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1095, N'123', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1096, N'555', 555, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1097, N'555', 555, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1098, N'444', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1099, N'777', 777, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1100, N'123', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1101, N'ASD', 11, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1102, N'123', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1103, N'Тест', 1234567, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1104, N'Mjkj jkjhkjh', 123, 0, 1)
INSERT [dbo].[Clients] ([Id], [Name], [RegistrationNumber], [IsLocked], [IsClient]) VALUES (1105, N'Тестовый банк', 402023040, 0, 1)
SET IDENTITY_INSERT [dbo].[Clients] OFF
/****** Object:  Table [dbo].[CellStyleTemplates]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[CellStyleTemplates] ON
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (1, N'BoldBlue', N'bold', N'#DAEEF3', N'#000000', N'', N'right', N'', 20, 80, N'', N'normal', N'', 0, 12, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (2, N'NormalBlue', N'normal', N'#DAEEF3', N'#000000', N'', N'right', N'', 20, 80, N'', N'normal', N'', 0, 12, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (3, N'BoldWhite', N'bold', N'#FFFFFF', N'#000000', N'', N'right', N'', 20, 80, N'', N'normal', N'', 0, 12, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (4, N'NormalWhite', N'normal', N'#FFFFFF', N'#000000', N'', N'right', N'', 20, 80, N'', N'normal', N'', 0, 12, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (5, N'4', N'normal', N'white', N'black', NULL, N'right', NULL, 20, 80, N'times', N'normal', NULL, 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (6, N'4', N'normal', N'white', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (7, N'4', N'bold', N'white', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (8, N'4', N'normal', N'#4BACC6', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (9, N'4', N'normal', N'#4BACC6', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (10, N'4', N'normal', N'#4BACC6', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (11, N'4', N'normal', N'#4F81BD', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (12, N'4', N'normal', N'#B7DDE8', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (13, N'4', N'normal', N'#F79646', N'black', N'', N'right', N'', 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (14, N'4', N'normal', N'#C0504D', N'black', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (15, N'4', N'normal', N'white', N'black', N'', N'right', NULL, 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (16, N'4', N'bold', N'white', N'black', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (17, N'4', N'normal', N'white', N'black', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 24, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (18, N'4', N'normal', N'#C0504D', N'black', N'', N'right', NULL, 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (19, N'Баланс', N'normal', N'#DAEEF3', N'#000000', N'', N'right', NULL, 20, 80, N'', N'normal', N'', 0, 12, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (20, N'4', N'normal', N'white', N'#000000', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (21, N'4', N'normal', N'#C0504D', N'#000000', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (22, N'Баланс', N'normal', N'white', N'black', N'', NULL, NULL, 20, 243, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (23, N'Баланс', N'normal', N'white', N'black', N'', NULL, NULL, 20, 108, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (24, N'Баланс', N'normal', N'white', N'black', N'', NULL, NULL, 20, 360, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (25, N'Баланс', N'normal', N'white', N'black', N'', NULL, NULL, 20, 99, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (26, N'Баланс', N'normal', N'white', N'black', N'', NULL, NULL, 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (27, N'4', N'normal', N'white', N'black', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (28, N'4', N'normal', N'white', N'black', N'', NULL, NULL, 0, 0, N'times', N'normal', N'underline', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (29, N'4', N'normal', N'#000000', N'black', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (30, N'ОПиУ', N'normal', N'white', N'black', N'', NULL, NULL, 20, 270, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (31, N'ОПиУ', N'normal', N'white', N'black', N'', NULL, NULL, 20, 135, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (32, N'ОДДС', N'normal', N'white', N'black', N'', NULL, NULL, 20, 216, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (33, N'ОДДС', N'normal', N'white', N'black', N'', NULL, NULL, 20, 90, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (34, N'4', N'normal', N'#4BACC6', N'black', N'', N'right', NULL, 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (35, N'4', N'normal', N'white', N'black', N'', NULL, NULL, 20, 67, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (36, N'4', N'normal', N'white', N'black', N'', NULL, NULL, 20, 22, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (37, N'4', N'normal', N'white', N'black', N'', N'right', NULL, 20, 80, N'Tahoma', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (38, N'4', N'normal', N'white', N'black', N'', NULL, NULL, 20, 7, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (39, N'4', N'normal', N'#008000', N'black', N'', NULL, NULL, 0, 0, N'times', N'normal', N'', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (40, N'4', N'normal', N'white', N'black', N'', NULL, NULL, 0, 0, N'Arial', N'normal', N'', 0, 10, NULL, NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (41, N'4', N'normal', N'white', N'black', N'', N'right', NULL, 20, 80, N'times', N'normal', N'line-through', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (42, N'4', N'normal', N'white', N'black', N'', N'right', NULL, 20, 80, N'times', N'normal', N'underline', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (43, N'4', N'bold', N'white', N'black', N'', N'right', NULL, 20, 80, N'times', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (44, N'969654b2-f08c-46d4-9a98-81f538dff50a', N'normal', N'#ffffff', N'#000000', N'', N'right', NULL, 20, 80, N'', N'normal', N'', 0, 10, N'', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (45, N'5321f8ff-cfb7-4aed-a3ca-91e261f04a97', N'normal', N'#DAEEF3', N'#000000', N'null', N'right', NULL, 20, 80, N'null', N'normal', N'null', 0, 12, N'null', NULL)
INSERT [dbo].[CellStyleTemplates] ([Id], [Name], [FontWeight], [BackgroundColor], [FontColor], [CellType], [Align], [DFM], [Height], [Width], [FontFamily], [FontStyle], [DecorLine], [Indent], [FontSize], [CellDataFormat], [Calculation]) VALUES (46, N'0bcb1bd1-6337-42e3-817e-848b8690f322', N'normal', N'#FFFFFF', N'#000000', N'null', N'right', NULL, 20, 80, N'null', N'normal', N'null', 0, 12, N'null', NULL)
SET IDENTITY_INSERT [dbo].[CellStyleTemplates] OFF
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[UserRoles] ON
INSERT [dbo].[UserRoles] ([Id], [UserRole]) VALUES (1, N'Бухгалтер')
INSERT [dbo].[UserRoles] ([Id], [UserRole]) VALUES (2, N'Кредитный офицер')
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
/****** Object:  Table [dbo].[ViewTypes]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[ViewTypes] ON
INSERT [dbo].[ViewTypes] ([Id], [Description]) VALUES (1, N'Загруженный документ')
INSERT [dbo].[ViewTypes] ([Id], [Description]) VALUES (2, N'Прочтенный документ')
INSERT [dbo].[ViewTypes] ([Id], [Description]) VALUES (3, N'Отчет')
SET IDENTITY_INSERT [dbo].[ViewTypes] OFF
/****** Object:  Table [dbo].[TypeAnalyticData]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[TypeAnalyticData] ON
INSERT [dbo].[TypeAnalyticData] ([Id], [Description]) VALUES (1, N'Pie')
INSERT [dbo].[TypeAnalyticData] ([Id], [Description]) VALUES (2, N'Line')
INSERT [dbo].[TypeAnalyticData] ([Id], [Description]) VALUES (3, N'Bar')
INSERT [dbo].[TypeAnalyticData] ([Id], [Description]) VALUES (4, N'Table')
INSERT [dbo].[TypeAnalyticData] ([Id], [Description]) VALUES (5, N'Stacked barchart')
INSERT [dbo].[TypeAnalyticData] ([Id], [Description]) VALUES (1005, N'Non stacked barchart')
INSERT [dbo].[TypeAnalyticData] ([Id], [Description]) VALUES (1006, N'MoveTable')
SET IDENTITY_INSERT [dbo].[TypeAnalyticData] OFF
/****** Object:  Table [dbo].[Settings]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[Settings] ON
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (1, N'UploadFolder', N'c:/Landau/Uploads')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (3, N'WordFile', N'App_Data/Settings/wordfile.png')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (4, N'ExcelFile', N'App_Data/Settings/excelfile.png')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (5, N'PdfFile', N'App_Data/Settings/pdffile.png')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (8, N'TxtFile', N'App_Data/Settings/txt.png')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (9, N'ImageFile', N'App_Data/Settings/image.png')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (11, N'TemplateFile', N'c:/Landau/Templates/test_card.txt')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (12, N'AnalyticalTemplateFile', N'c:/Landau/Templates/test_opiu.txt')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (13, N'DetectorPath', N'c:\Landau\Services\Console\Detectors\Detector.txt')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (14, N'SchemasFolder', N'c:\Landau\Services\Console\Schemas\')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (16, N'PixCodeProjectConfig', N'c:\Landau\Services\Console\Sources\config.pxd')
INSERT [dbo].[Settings] ([Id], [SettingsName], [SettingsValue]) VALUES (17, N'MainPath', N'd:\Projects\Landau\LandauSmart\LandauSmart\LandauSmart\LandauTestConsole\LandauTestConsole\bin\Debug\')
SET IDENTITY_INSERT [dbo].[Settings] OFF
/****** Object:  Table [dbo].[ReportDocumentTypeCatalog]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[ReportDocumentTypeCatalog] ON
INSERT [dbo].[ReportDocumentTypeCatalog] ([Id], [Description], [Title]) VALUES (1, N'Balance', N'Баланс')
INSERT [dbo].[ReportDocumentTypeCatalog] ([Id], [Description], [Title]) VALUES (2, N'Opiu', N'ОПиУ')
INSERT [dbo].[ReportDocumentTypeCatalog] ([Id], [Description], [Title]) VALUES (3, N'ODDS', N'ОДДС')
SET IDENTITY_INSERT [dbo].[ReportDocumentTypeCatalog] OFF
/****** Object:  Table [dbo].[ReportCellTypeCatalog]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[ReportCellTypeCatalog] ON
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (1, N'Revenue6010', N'Выручка 6010', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (2, N'CostPrice7010', N'Себестоимость 7010', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (3, N'Margin', N'Маржа', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (4, N'GrossProfit', N'Валовая прибыль', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (6, N'Salary', N'Зарплата', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (7, N'Taxes', N'Налоги', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (8, N'Rent', N'Аренда', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (9, N'MaterialCost', N'Материальные затраты', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (10, N'TravelExpenses', N'Командировочные расходы', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (11, N'FutureExpenses', N'Расходы будующих периодов', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (12, N'FFP', N'Вознаграждения, пени, штрафы', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (14, N'DepricationAmortization', N'Амортизация и износ', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (15, N'DistributionCost', N'Расходы по реализации', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (16, N'AdministrativeExpenses', N'Административные расходы', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (17, N'OperationRent', N'Расходы по операционной аренде', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (18, N'EBITDA', N'EBITDA', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (19, N'KPN', N'КПН', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (20, N'Reward', N'Вознаграждения', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (21, N'ClearProfit', N'Чистая прибыль', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (22, N'ClearResidue', N'Чистый остаток', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (23, N'Revenue', N'Выручка', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (24, N'Refunds', N'Возвраты', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (25, N'AnotherBudgetPayment', N'Прочие платежи в бюджет', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (26, N'BankServicePayment', N'Банковские услуги', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (27, N'Percents', N'Проценты', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (28, N'BusinessExpenses', N'Расходы по бизнесу', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (29, N'BusinessProfit', N'Прибыль от бизнеса', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (33, N'EBITDAMargin', N'Маржа по EBITDA', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (34, N'InterestIncome', N'Доходы по вознаграждениям', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (35, N'OtherIncome', N'Прочие доходы', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (36, N'Income74', N'Доходы по 74 счетам', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (37, N'Income7576', N'Доходы по 75-76 счетам', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (38, N'ClearODDSRevenue', N'Чистая выручка по ОДДС', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (40, N'ClearTotalODDSCosts', N'Чистые расходы по ОДДС', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (41, N'CashLess103', N'Чистая выручка по 103', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (42, N'Cash101', N'Чистая выруска по 101*', 0)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (43, N'Income621', N'Доход от выбытия активов 6210', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (44, N'Income625', N'Доходы от курсовой разницы 6250', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (45, N'Income628', N'Прочие доходы 6280', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (46, N'Expenses741', N'Расходы по выбытию активов 7410', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (47, N'Expenses743', N'Расходы по курсовой разнице 7430', 1)
INSERT [dbo].[ReportCellTypeCatalog] ([Id], [Description], [Title], [IsClassificator]) VALUES (48, N'Expenses747', N'Прочие расходы 7470', 1)
SET IDENTITY_INSERT [dbo].[ReportCellTypeCatalog] OFF
/****** Object:  Table [dbo].[ProjectStates]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[ProjectStates] ON
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (1, N'Создан')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (2, N'Загрузка данных')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (3, N'Анализ данных')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (4, N'Анализ завершен')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (5, N'Ошибка анализа')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (6, N'Построение связей')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (7, N'Проект завершен')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (8, N'Анализ завершен. Исходники загружены')
INSERT [dbo].[ProjectStates] ([Id], [Description]) VALUES (9, N'Ошибка построения связей')
SET IDENTITY_INSERT [dbo].[ProjectStates] OFF
/****** Object:  Table [dbo].[OperationType]    Script Date: 04/03/2016 23:13:56 ******/
/****** Object:  Table [dbo].[OperationState]    Script Date: 04/03/2016 23:13:56 ******/
/****** Object:  Table [dbo].[Operations]    Script Date: 04/03/2016 23:13:56 ******/
/****** Object:  Table [dbo].[Users]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1083, N'Иван', N'POP', N'ASD', N'aaa', 1, N'bbb', 1087, N'alexkuchik.ak@gmail.com', N'+123')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1084, N'Иван', N'Александрович', N'QWE', N'aaa', 1, N'bbb', 1088, N'andrei_kuchik@mail.ru', N'+321312')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1085, N'POP', N'POP', N'QWE', N'aaa', 1, N'bbb', 1089, N'4546@mial.ru', N'+3213')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1091, N'Арнольд', N'Арнольдович', N'Шлеиензон', N'aaa', 2, N'bbb', 1090, N'1@mail.ru', N'+76765')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1092, N'RE', N'Ку', N'Re', N'aaa', 1, N'bbb', 1091, N'3@mail.ru', N'+3213')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1093, N'Ыв', N'ВЫа', N'Аы', N'aaa', 1, N'bbb', 1092, N'22@mail.com', N'+432')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1094, N'Fr', N'Fr', N'Fr', N'aaa', 1, N'bbb', 1093, N'44@mail.ru', N'+123')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1095, N'OI', N'OI', N'Oi', N'aaa', 1, N'bbb', 1094, N'oi@mail.ru', N'+123')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1096, N'Fd', N'Fd', N'Fd', N'aaa', 1, N'bbb', 1095, N'0909@mail.ru', N'+3213')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1097, N'Александр', N'Александрович', N'Кучик', N'aaa', 1, N'bbb', 1096, N'333@MAIL.RU', N'+375298285174')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1098, N'Петр', N'Петрович', N'Петров', N'aaa', 1, N'bbb', 1097, N'444@mail.ru', N'+123123')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1099, N'Андрей', N'Александрович', N'Кучик', N'aaa', 1, N'bbb', 1098, N'99@mail.tu', N'+123')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1100, N'Андрей', N'Александрович', N'Петров', N'aaa', 1, N'bbb', 1099, N'4444@maul.nn', N'+375298285174')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1101, N'Андрей', N'Петрович', N'Кучик', N'aaa', 1, N'bbb', 1101, N'asd@miki.co', N'+123')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1102, N'Андрей', N'Ав', N'Gds', N'aaa', 1, N'bbb', 1102, N'11@mail.ru', N'+375298285174')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1103, N'asd', N'ASDasd', N'Ilyushchenia-Iiasidj', N'aaa', 1, N'bbb', 1104, N'd.ilyushchenia@gmail.com', N'375291231806')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1105, N'Искандер', N'Максимович', N'Мутышев', N'нет', 2, N'нет', 1105, N'imutyshev@gmail.com', N'+7777999050')
INSERT [dbo].[Users] ([Id], [FirstName], [SecondName], [LastName], [Department], [Roles], [Rights], [ClientId], [Email], [PhoneNumber]) VALUES (1106, N'Иванов', N'Иван', N'Иванович', N'нет', 1, N'нет', 1105, N'ivanov@gmail.com', N'+1234')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[UserLogins]    Script Date: 04/03/2016 23:13:56 ******/
SET IDENTITY_INSERT [dbo].[UserLogins] ON
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1080, 1083, N'alexkuchik.ak@gmail.com', N'kc4r+cUFGjmFw5uxpv1Cgw==', CAST(0x0000A52F009E3015 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1081, 1084, N'andrei_kuchik@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A5D80103170F AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1082, 1085, N'4546@mial.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A53F00F72825 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1087, 1091, N'1@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A5DD016445A9 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1088, 1092, N'3@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A54E013180D7 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1089, 1093, N'22@mail.com', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A54400B278B0 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1090, 1094, N'44@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A54400B49A22 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1091, 1095, N'oi@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A54400B5756C AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1092, 1096, N'0909@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A54400B61CCF AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1093, 1097, N'333@MAIL.RU', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A5490104963F AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1094, 1098, N'444@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A5490106D08F AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1095, 1099, N'99@mail.tu', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A5490108C4BD AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1096, 1100, N'4444@maul.nn', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A549010F139A AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1098, 1101, N'asd@miki.co', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A549011B258E AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1099, 1102, N'11@mail.ru', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A54B00D230E3 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1100, 1103, N'd.ilyushchenia@gmail.com', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A56B00DCD630 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1104, 1105, N'imutyshev@gmail.com', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A5870099E3A7 AS DateTime), 0)
INSERT [dbo].[UserLogins] ([Id], [UserId], [Login], [Password], [LastLoginDate], [IsLocked]) VALUES (1105, 1106, N'ivanov@gmail.com', N'pvwBu6I01neX7cPg1Gcr8Q==', CAST(0x0000A5870097D924 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UserLogins] OFF
