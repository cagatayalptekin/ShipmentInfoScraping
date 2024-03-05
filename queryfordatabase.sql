USE [Shipment]
GO

/****** Object:  Table [dbo].[Shipment]    Script Date: 3/5/2024 4:21:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TakipNumarasi] [nvarchar](100) NULL,
	[GondericiAd] [nvarchar](100) NULL,
	[GondericiFirma] [nvarchar](100) NULL,
	[AliciAd] [nvarchar](100) NULL,
	[AliciSehir] [nvarchar](100) NULL,
	[AliciFirma] [nvarchar](100) NULL,
	[BilgiCekimTarihi] [nvarchar](100) NULL,
	[GonderiTarihi] [nvarchar](100) NULL,
	[AliciUlke] [nvarchar](100) NULL,
	[GondericiUlke] [nvarchar](100) NULL,
	[KargoFirmasi] [nvarchar](100) NULL,
 CONSTRAINT [PK_Shipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


