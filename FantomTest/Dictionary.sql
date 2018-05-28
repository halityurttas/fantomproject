USE [FantomDB]
GO

/****** Object:  Table [dbo].[FantomDictionary]    Script Date: 06/06/2014 15:45:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FantomDictionary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Culture] [varchar](10) NULL,
	[Group] [varchar](50) NULL,
	[Key] [varchar](50) NULL,
	[Value] [text] NULL,
 CONSTRAINT [PK_fantomDict] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

