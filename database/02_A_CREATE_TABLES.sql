USE [SpainCitiesDb]
GO

/****** Object:  Table [dbo].[Regions]    Script Date: 3/1/2025 00:52:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Regions](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Population] [int] NULL,
	[Capital] [varchar](100) NULL,
	[Surface] [int] NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

