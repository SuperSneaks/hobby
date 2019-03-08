USE [HuntingAppDB]
GO

/****** Object:  Table [dbo].[Hunts]    Script Date: 3/1/2019 16:33:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hunts](
	[uuid] [uniqueidentifier] NOT NULL,
	[user_uuid] [uniqueidentifier] NOT NULL,
	[stand_uuid] [uniqueidentifier] NOT NULL,
	[hunt_start] [datetime] NOT NULL,
	[hunt_end] [datetime] NOT NULL,
	[bucks_seen] [int] NULL,
	[does_seen] [int] NULL,
	[unknown_seen] [int] NULL,
	[sight_details] [nvarchar](max) NULL,
	[notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hunts] PRIMARY KEY CLUSTERED 
(
	[uuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Hunts]  WITH CHECK ADD  CONSTRAINT [FK_Hunts_Stands] FOREIGN KEY([stand_uuid])
REFERENCES [dbo].[Stands] ([uuid])
GO

ALTER TABLE [dbo].[Hunts] CHECK CONSTRAINT [FK_Hunts_Stands]
GO

ALTER TABLE [dbo].[Hunts]  WITH CHECK ADD  CONSTRAINT [FK_Hunts_User] FOREIGN KEY([uuid])
REFERENCES [dbo].[Users] ([uuid])
GO

ALTER TABLE [dbo].[Hunts] CHECK CONSTRAINT [FK_Hunts_User]
GO

