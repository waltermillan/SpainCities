USE [SpainCitiesDb]
GO

/****** Object:  Table [dbo].[Provinces]    Script Date: 3/1/2025 00:53:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Provinces](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Provinces]  WITH CHECK ADD  CONSTRAINT [FK_Province_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO

ALTER TABLE [dbo].[Provinces] CHECK CONSTRAINT [FK_Province_Region]
GO

