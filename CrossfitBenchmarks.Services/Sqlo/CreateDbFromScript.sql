
/****** Object:  Table [dbo].[User]    Script Date: 1/21/2013 8:45:45 PM ******/
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
/****** Object:  Table [dbo].[Workout]    Script Date: 1/21/2013 8:45:45 PM ******/
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
/****** Object:  Table [dbo].[WorkoutLog]    Script Date: 1/21/2013 8:45:45 PM ******/
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
 CONSTRAINT [PK_WorkoutLog] PRIMARY KEY CLUSTERED 
(
	[WorkoutLogId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[WorkoutType]    Script Date: 1/21/2013 8:45:45 PM ******/
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

GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [TimeZoneOffset], [Email], [IpName], [IpNameIdentifier], [IpEmail], [IdentityProvider], [PromoCode], [DateCreated], [LastActivityDate]) VALUES (3, N'Cedric', N'Bertolasio', -7, N'cbertolasio@gmail.com', N'Cedric Bertolasio', N'https://www.google.com/accounts/o8/id?id=AItOawmUwWQxLL3ZnXVCX0QU9cqIlsrOuLo7_WQ', N'cbertolasio@gmail.com', N'Google', NULL, CAST(0x070000000000A7360B AS DateTime2), CAST(0x070000000000A7360B AS DateTime2))
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [TimeZoneOffset], [Email], [IpName], [IpNameIdentifier], [IpEmail], [IdentityProvider], [PromoCode], [DateCreated], [LastActivityDate]) VALUES (4, N'Joe', N'Bloggs', -7, N'jbloggs@gmail.com', N'Joe Bloggs', N'unknown', N'jbloggs@gmail.com', N'Google', NULL, CAST(0x070000000000A5360B AS DateTime2), CAST(0x070000000000A7360B AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Workout] ON 

GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (1, N'Back Squat', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (2, N'Shoulder Press', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (3, N'Deadlift', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (4, N'Front Squat', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (5, N'Bench Press', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (6, N'Thruster', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (7, N'Push Press', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (8, N'Push Jerk', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (9, N'Jerk', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (11, N'Overhead Squat', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (12, N'Clean', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (13, N'Clean & Jerk', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (14, N'Snatch', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (15, N'Snatch Balance', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (16, N'Squat Clean', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (17, N'Pullups - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (18, N'Dips / Ring Dips - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (19, N'Muscle-Ups - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (20, N'Push-Ups - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (21, N'Tabata Squats - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (22, N'Sit-Ups (ME in 2 min.)', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (24, N'Squats (ME in 2 min.)', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (25, N'Hand Stand Hold - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (26, N'Hand Stand Push-Ups - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (27, N'L-Sit ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (28, N'500M Row', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (29, N'1000M Row', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (30, N'2000M Row', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (31, N'5k Row', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (32, N'400M Run', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (33, N'800M Run', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (34, N'1 Mile Run', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (35, N'5k', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (36, N'1/2 Marathon', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (37, N'Marathon', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (38, N'10k', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (39, N'Double Unders - ME', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (40, N'Single Unders', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (41, N'Burpees (ME in 2 min.)', N'B')
GO
INSERT [dbo].[Workout] ([WorkoutId], [Name], [WorkoutTypeId]) VALUES (43, N'Burpees (100 for time)', N'B')
GO
SET IDENTITY_INSERT [dbo].[Workout] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkoutLog] ON 

GO
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord]) VALUES (1, 4, 3, N'275', CAST(0x0700E80A7E8EA6360B5CFE AS DateTimeOffset), 1)
GO
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord]) VALUES (2, 4, 3, N'185', CAST(0x0700384D251971350B5CFE AS DateTimeOffset), 0)
GO
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord]) VALUES (3, 4, 3, N'205', CAST(0x070068C461080A360B5CFE AS DateTimeOffset), 0)
GO
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord]) VALUES (4, 1, 3, N'315', CAST(0x070068C46108A3360B5CFE AS DateTimeOffset), 0)
GO
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord]) VALUES (5, 1, 3, N'345', CAST(0x070068C4610896360B5CFE AS DateTimeOffset), 1)
GO
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord]) VALUES (6, 1, 4, N'220', CAST(0x070068C4610896360B5CFE AS DateTimeOffset), 1)
GO
INSERT [dbo].[WorkoutLog] ([WorkoutLogId], [WorkoutId], [UserId], [Score], [DateCreated], [IsAPersonalRecord]) VALUES (7, 4, 4, N'225', CAST(0x0700D85EAC3A94360B5CFE AS DateTimeOffset), 1)
GO
SET IDENTITY_INSERT [dbo].[WorkoutLog] OFF
GO
INSERT [dbo].[WorkoutType] ([WorkoutTypeId], [Name]) VALUES (N'B', N'Benchmark')
GO
INSERT [dbo].[WorkoutType] ([WorkoutTypeId], [Name]) VALUES (N'G', N'The Girls')
GO
INSERT [dbo].[WorkoutType] ([WorkoutTypeId], [Name]) VALUES (N'H', N'The Heros')
GO
/****** Object:  Index [PK_User]    Script Date: 1/21/2013 8:45:45 PM ******/
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
