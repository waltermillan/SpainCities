USE [SpainCitiesDb]
GO

/****** Object:  Table [dbo].[Pictures]    Script Date: 3/1/2025 00:54:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pictures](
	[id] [int] NOT NULL,
	[RegionId] [int] NOT NULL,
	[imageBase64] [varchar](max) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Regions] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO

ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Regions]
GO

