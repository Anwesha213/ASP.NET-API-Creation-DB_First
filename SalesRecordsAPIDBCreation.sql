SE [SalesRecordsAPI]
GO

/****** Object:  Table [dbo].[SalesRecords]    Script Date: 21-04-2023 20:20:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesRecords](
	[Region] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Item_Type] [nvarchar](50) NOT NULL,
	[Sales_Channel] [nvarchar](50) NOT NULL,
	[Order_Priority] [nvarchar](50) NOT NULL,
	[Order_Date] [date] NOT NULL,
	[Order_ID] [int] NOT NULL,
	[Ship_Date] [date] NOT NULL,
	[Units_Sold] [int] NOT NULL,
	[Unit_Price] [float] NOT NULL,
	[Unit_Cost] [float] NOT NULL,
	[Total_Revenue] [float] NOT NULL,
	[Total_Cost] [float] NOT NULL,
	[Total_Profit] [float] NOT NULL
) ON [PRIMARY]
GO