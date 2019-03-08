USE [HuntingAppDB]
GO

/****** Object:  Table [dbo].[Properties]    Script Date: 3/1/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Properties](
	[uuid] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nchar](10) NULL,
	[city] [nchar](10) NULL,
	[state] [nchar](10) NULL,
	[zip] [nchar](10) NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[uuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

