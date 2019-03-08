USE [HuntingAppDB]
GO

/****** Object:  Table [dbo].[Sightings]    Script Date: 3/1/2019 17:18:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sightings](
	[uuid] [uniqueidentifier] NOT NULL,
	[hunt_uuid] [uniqueidentifier] NOT NULL,
	[sight_dt] [datetime] NOT NULL,
	[bucks_seen] [int] NULL,
	[does_seen] [int] NULL,
	[unknown_seen] [int] NULL,
	[notes] [varchar](160) NULL,
 CONSTRAINT [PK_Sightings] PRIMARY KEY CLUSTERED 
(
	[uuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sightings]  WITH CHECK ADD  CONSTRAINT [FK_Sightings_Hunts] FOREIGN KEY([hunt_uuid])
REFERENCES [dbo].[Hunts] ([uuid])
GO

ALTER TABLE [dbo].[Sightings] CHECK CONSTRAINT [FK_Sightings_Hunts]
GO

