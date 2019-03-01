USE [HuntingApp]
GO

/****** Object:  Table [dbo].[PropertyAccess]    Script Date: 3/1/2019 16:34:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PropertyAccess](
	[users_uuid] [uniqueidentifier] NOT NULL,
	[property_uuid] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PropertyAccess]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAccess_Property] FOREIGN KEY([property_uuid])
REFERENCES [dbo].[Properties] ([uuid])
GO

ALTER TABLE [dbo].[PropertyAccess] CHECK CONSTRAINT [FK_PropertyAccess_Property]
GO

ALTER TABLE [dbo].[PropertyAccess]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAccess_User] FOREIGN KEY([users_uuid])
REFERENCES [dbo].[Users] ([uuid])
GO

ALTER TABLE [dbo].[PropertyAccess] CHECK CONSTRAINT [FK_PropertyAccess_User]
GO

