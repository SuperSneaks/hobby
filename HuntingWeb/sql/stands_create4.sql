USE [HuntingAppDB]
GO

/****** Object:  Table [dbo].[Stands]    Script Date: 3/1/2019 16:34:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stands](
	[uuid] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[property_uuid] [uniqueidentifier] NOT NULL,
	[front_img] [image] NULL,
	[back_img] [image] NULL,
	[left_img] [image] NULL,
	[right_img] [image] NULL,
	[location] [geography] NULL,
 CONSTRAINT [PK_Stands] PRIMARY KEY CLUSTERED 
(
	[uuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Stands]  WITH CHECK ADD  CONSTRAINT [FK_Stands_Property] FOREIGN KEY([property_uuid])
REFERENCES [dbo].[Properties] ([uuid])
GO

ALTER TABLE [dbo].[Stands] CHECK CONSTRAINT [FK_Stands_Property]
GO

