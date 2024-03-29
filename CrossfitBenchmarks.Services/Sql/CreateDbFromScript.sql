/****** Object:  User [crossfitBenchmarks]    Script Date: 1/26/2013 5:36:28 PM ******/
CREATE USER [crossfitBenchmarks] FOR LOGIN [crossfitBenchmarks] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [appFabricUser]    Script Date: 1/26/2013 5:36:28 PM ******/
CREATE USER [appFabricUser] FOR LOGIN [appFabricUser] WITH DEFAULT_SCHEMA=[dbo]
GO
sys.sp_addrolemember @rolename = N'db_datareader', @membername = N'crossfitBenchmarks'
GO
sys.sp_addrolemember @rolename = N'db_datawriter', @membername = N'crossfitBenchmarks'
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'appFabricUser'
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/26/2013 5:36:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[TimeZoneOffset] [int] NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[IpName] [nvarchar](255) NULL,
	[IpNameIdentifier] [varchar](255) NULL,
	[IpEmail] [nvarchar](100) NULL,
	[IdentityProvider] [varchar](100) NULL,
	[PromoCode] [varchar](50) NULL,
	[DateCreated] [datetime2](7) NULL,
	[LastActivityDate] [datetime2](7) NULL,
 CONSTRAINT [IX_User] UNIQUE CLUSTERED 
(
	[IpNameIdentifier] ASC,
	[IdentityProvider] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Workout]    Script Date: 1/26/2013 5:36:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workout](
	[WorkoutId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[WorkoutTypeId] [char](1) NOT NULL,
 CONSTRAINT [PK_Workout] PRIMARY KEY CLUSTERED 
(
	[WorkoutId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[WorkoutLog]    Script Date: 1/26/2013 5:36:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutLog](
	[WorkoutLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[WorkoutId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Score] [nvarchar](50) NULL,
	[DateCreated] [datetimeoffset](7) NULL,
	[IsAPersonalRecord] [bit] NOT NULL,
	[Note] [nvarchar](1024) NULL,
 CONSTRAINT [PK_WorkoutLog] PRIMARY KEY CLUSTERED 
(
	[WorkoutLogId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[WorkoutType]    Script Date: 1/26/2013 5:36:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutType](
	[WorkoutTypeId] [char](1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkoutType] PRIMARY KEY CLUSTERED 
(
	[WorkoutTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [TimeZoneOffset], [Email], [IpName], [IpNameIdentifier], [IpEmail], [IdentityProvider], [PromoCode], [DateCreated], [LastActivityDate]) VALUES (3, N'Cedric', N'Bertolasio', -7, N'cbertolasio@gmail.com', N'Cedric Bertolasio', N'https://www.google.com/accounts/o8/id?id=AItOawmUwWQxLL3ZnXVCX0QU9cqIlsrOuLo7_WQ', N'cbertolasio@gmail.com', N'Google', NULL, CAST(0x070000000000A7360B AS DateTime2), CAST(0x070000000000A7360B AS DateTime2))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [TimeZoneOffset], [Email], [IpName], [IpNameIdentifier], [IpEmail], [IdentityProvider], [PromoCode], [DateCreated], [LastActivityDate]) VALUES (4, N'Joe', N'Bloggs', -7, N'jbloggs@gmail.com', N'Joe Bloggs', N'unknown', N'jbloggs@gmail.com', N'Google', NULL, CAST(0x070000000000A5360B AS DateTime2), CAST(0x070000000000A7360B AS DateTime2))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Workout] ON 

INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (1, N'Back Squat', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (2, N'Shoulder Press', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (3, N'Deadlift', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (4, N'Front Squat', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (5, N'Bench Press', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (6, N'Thruster', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (7, N'Push Press', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (8, N'Push Jerk', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (9, N'Jerk', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (11, N'Overhead Squat', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (12, N'Clean', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (13, N'Clean & Jerk', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (14, N'Snatch', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (15, N'Snatch Balance', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (16, N'Squat Clean', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (17, N'Pullups - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (18, N'Dips / Ring Dips - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (19, N'Muscle-Ups - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (20, N'Push-Ups - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (21, N'Tabata Squats - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (22, N'Sit-Ups (ME in 2 min.)', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (24, N'Squats (ME in 2 min.)', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (25, N'Hand Stand Hold - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (26, N'Hand Stand Push-Ups - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (27, N'L-Sit ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (28, N'500M Row', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (29, N'1000M Row', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (30, N'2000M Row', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (31, N'5k Row', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (32, N'400M Run', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (33, N'800M Run', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (34, N'1 Mile Run', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (35, N'5k', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (36, N'1/2 Marathon', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (37, N'Marathon', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (38, N'10k', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (39, N'Double Unders - ME', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (40, N'Single Unders', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (41, N'Burpees (ME in 2 min.)', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (43, N'Burpees (100 for time)', N'B')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (44, N'Annie', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (45, N'Angie', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (46, N'Barbara', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (47, N'Chelsea', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (48, N'Cindy', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (49, N'Diane', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (50, N'Elizabeth', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (51, N'Fran', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (52, N'Frelen', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (53, N'Grace', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (54, N'Helen', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (55, N'Isabel', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (56, N'Jackie', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (57, N'Karen', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (58, N'Kelly', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (59, N'Linda', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (60, N'Lynne', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (61, N'Mary', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (62, N'Nancy', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (63, N'Nasty Girls', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (64, N'Nicole', N'G')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (65, N'Adam Brown', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (66, N'Arnie', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (67, N'Badger', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (68, N'Blake', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (69, N'Brenton', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (70, N'Bulger', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (71, N'Bull', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (72, N'Coe', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (73, N'Collin', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (74, N'Daniel', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (75, N'Danny', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (77, N'DT', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (78, N'Erin', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (79, N'Forrest', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (80, N'Garrett', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (81, N'Griff', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (82, N'Hansen', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (83, N'Helton', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (84, N'Holbrook', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (85, N'Jack', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (86, N'Jason', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (87, N'Jerry', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (88, N'John Runkle', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (89, N'Johnson', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (90, N'Josh', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (91, N'Joshie', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (92, N'JT', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (93, N'Ledesma', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (94, N'Luce', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (96, N'Lumberjack 20', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (97, N'McGhee', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (98, N'Michael', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (99, N'Mr. Joshua', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (100, N'Murph', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (101, N'Nate', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (102, N'Nutts', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (103, N'Paul', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (104, N'Randy', N'H')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (105, N'RJ', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (106, N'Roy', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (107, N'Ryan', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (108, N'Severin', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (109, N'Stephen', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (111, N'The Seven', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (112, N'Thompson', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (113, N'Tommy V', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (114, N'Tyler', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (115, N'War Frank', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (116, N'Whitten', N'H')
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (117, N'Wittman', N'H')
SET IDENTITY_INSERT [dbo].[Workout] OFF
SET IDENTITY_INSERT [dbo].[WorkoutLog] ON 

INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord], [Note]) VALUES (1, 4, 3, N'275', CAST(0x0700E80A7E8EA6360B5CFE AS DateTimeOffset), 1, NULL)
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord], [Note]) VALUES (2, 4, 3, N'185', CAST(0x0700384D251971350B5CFE AS DateTimeOffset), 0, NULL)
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord], [Note]) VALUES (3, 4, 3, N'205', CAST(0x070068C461080A360B5CFE AS DateTimeOffset), 0, NULL)
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord], [Note]) VALUES (4, 1, 3, N'315', CAST(0x070068C46108A3360B5CFE AS DateTimeOffset), 0, NULL)
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord], [Note]) VALUES (5, 1, 3, N'345', CAST(0x070068C4610896360B5CFE AS DateTimeOffset), 1, NULL)
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord], [Note]) VALUES (6, 1, 4, N'220', CAST(0x070068C4610896360B5CFE AS DateTimeOffset), 1, NULL)
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord], [Note]) VALUES (7, 4, 4, N'225', CAST(0x0700D85EAC3A94360B5CFE AS DateTimeOffset), 1, NULL)
SET IDENTITY_INSERT [dbo].[WorkoutLog] OFF
INSERT [dbo].[WorkoutType] ([WorkoutTypeId], [Name]) VALUES (N'B', N'Benchmark')
INSERT [dbo].[WorkoutType] ([WorkoutTypeId], [Name]) VALUES (N'G', N'The Girls')
INSERT [dbo].[WorkoutType] ([WorkoutTypeId], [Name]) VALUES (N'H', N'The Heros')
/****** Object:  Index [PK_User]    Script Date: 1/26/2013 5:36:28 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [PK_User] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF)
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[WorkoutLog] ADD  CONSTRAINT [DF_WorkoutLog_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Workout]  WITH NOCHECK ADD  CONSTRAINT [FK_Workout_WorkoutType] FOREIGN KEY([WorkoutTypeId])
REFERENCES [dbo].[WorkoutType] ([WorkoutTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Workout] CHECK CONSTRAINT [FK_Workout_WorkoutType]
GO
ALTER TABLE [dbo].[WorkoutLog]  WITH NOCHECK ADD  CONSTRAINT [FK_WorkoutLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkoutLog] CHECK CONSTRAINT [FK_WorkoutLog_User]
GO
ALTER TABLE [dbo].[WorkoutLog]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutLog_Workout] FOREIGN KEY([WorkoutId])
REFERENCES [dbo].[Workout] ([WorkoutId])
GO
ALTER TABLE [dbo].[WorkoutLog] CHECK CONSTRAINT [FK_WorkoutLog_Workout]
GO
