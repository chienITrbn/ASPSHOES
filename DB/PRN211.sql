USE [master]
GO
/****** Object:  Database [PRN211_HS160974]    Script Date: 7/1/2023 10:51:24 PM ******/
CREATE DATABASE [PRN211_HS160974]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN211_HS160974', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRN211_HS160974.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN211_HS160974_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRN211_HS160974_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PRN211_HS160974] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN211_HS160974].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN211_HS160974] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN211_HS160974] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN211_HS160974] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRN211_HS160974] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN211_HS160974] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET RECOVERY FULL 
GO
ALTER DATABASE [PRN211_HS160974] SET  MULTI_USER 
GO
ALTER DATABASE [PRN211_HS160974] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN211_HS160974] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN211_HS160974] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN211_HS160974] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN211_HS160974] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN211_HS160974] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN211_HS160974', N'ON'
GO
ALTER DATABASE [PRN211_HS160974] SET QUERY_STORE = OFF
GO
USE [PRN211_HS160974]
GO
/****** Object:  Table [dbo].[Account_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_HS160974](
	[accountID] [int] IDENTITY(1,1) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[phonenumber] [nvarchar](11) NOT NULL,
	[role] [int] NOT NULL,
	[active] [bit] NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Account_HS160974] PRIMARY KEY CLUSTERED 
(
	[accountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand_HS160974](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Brand_HS160974] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_HS160974](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Category_HS160974] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers_HS160974](
	[accountID] [int] NOT NULL,
	[fullName] [nvarchar](30) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[customerId] [int] IDENTITY(1,1) NOT NULL,
	[phoneNumber] [int] NOT NULL,
 CONSTRAINT [PK_Customers_HS160974_1] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails_HS160974](
	[OrderId] [int] NOT NULL,
	[sizeID] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails_HS160974] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[sizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders_HS160974](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[total_money] [decimal](18, 2) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Orders_HS160974] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_HS160974](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[category_id] [int] NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[brand_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NULL,
	[image] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Product_HS160974] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size_HS160974]    Script Date: 7/1/2023 10:51:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size_HS160974](
	[sizeID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NOT NULL,
	[sizeName] [float] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_Size_HS160974] PRIMARY KEY CLUSTERED 
(
	[sizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account_HS160974] ON 

INSERT [dbo].[Account_HS160974] ([accountID], [password], [name], [phonenumber], [role], [active], [email], [address]) VALUES (1, N'123', N'chien nguyen', N'0373661632', 1, 1, N'achienvk789@gmail.com', N'me linh,ha noi')
INSERT [dbo].[Account_HS160974] ([accountID], [password], [name], [phonenumber], [role], [active], [email], [address]) VALUES (3, N'123aA@', N'chien nguyen', N'0373661632', 1, 1, N'chienjobmkt@gmail.com', N'Văn Khê Mê Linh')
INSERT [dbo].[Account_HS160974] ([accountID], [password], [name], [phonenumber], [role], [active], [email], [address]) VALUES (4, N'admin', N'admin', N'admin', 0, 1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Account_HS160974] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand_HS160974] ON 

INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (1, N'Nike')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (2, N'Puma')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (3, N'Dior')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (4, N'Reebok')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (5, N'New balance')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (6, N'MLB')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (7, N'Adidas')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (8, N'Gucci')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (9, N'Fendi')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (10, N'Balenciaga')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (11, N'DOLCE&GABBANA')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (12, N'BAPE')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (13, N'Vans')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (14, N'Fila')
INSERT [dbo].[Brand_HS160974] ([id], [name]) VALUES (15, N'Prada')
SET IDENTITY_INSERT [dbo].[Brand_HS160974] OFF
GO
SET IDENTITY_INSERT [dbo].[Category_HS160974] ON 

INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (1, N'Sneaker')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (2, N'Moccasins')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (3, N'Boots')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (4, N'Combat Boots')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (5, N'Platform Shoes')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (6, N'Saddle Shoes')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (7, N'Sandals')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (8, N'Running Shoe')
INSERT [dbo].[Category_HS160974] ([id], [name]) VALUES (10, N'Motorcycle Boots')
SET IDENTITY_INSERT [dbo].[Category_HS160974] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers_HS160974] ON 

INSERT [dbo].[Customers_HS160974] ([accountID], [fullName], [address], [customerId], [phoneNumber]) VALUES (3, N'chien nguyen', N'Văn Khê Mê Linh', 2, 0)
SET IDENTITY_INSERT [dbo].[Customers_HS160974] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_HS160974] ON 

INSERT [dbo].[Product_HS160974] ([ProductId], [name], [description], [category_id], [price], [brand_id], [created_at], [updated_at], [image]) VALUES (1, N'Nike Zoom Fly 4 Premiummm', N'Feel unbeatable, from the tee box to the final putt. Inspired by one of the most iconic sneakers of all time, the Air Jordan 1 G is an instant classic on the course. With Air cushioning underfoot, a Wings logo on the heel and an integrated traction pattern to help you power through your swing, it delivers all the clubhouse cool of the original AJ1—plus everything you need to play 18 holes in comfort.', 1, CAST(3900000.00 AS Decimal(18, 2)), 4, CAST(N'2023-03-04T00:00:00.000' AS DateTime), NULL, N'/image/nikezoom4.png')
INSERT [dbo].[Product_HS160974] ([ProductId], [name], [description], [category_id], [price], [brand_id], [created_at], [updated_at], [image]) VALUES (2, N'Air Jordan 1 Low G', N'Feel unbeatable, from the tee box to the final putt. Inspired by one of the most iconic sneakers of all time, the Air Jordan 1 G is an instant classic on the course. With Air cushioning underfoot, a Wings logo on the heel and an integrated traction pattern to help you power through your swing, it delivers all the clubhouse cool of the original AJ1—plus everything you need to play 18 holes in comfort.', 2, CAST(2530000.00 AS Decimal(18, 2)), 3, CAST(N'2023-03-04T00:00:00.000' AS DateTime), NULL, N'/image/jordan1.png')
INSERT [dbo].[Product_HS160974] ([ProductId], [name], [description], [category_id], [price], [brand_id], [created_at], [updated_at], [image]) VALUES (3, N'Nike Air Max 90 G', N'When the sun''s beating down your back and your drive just landed in the bunker, lean into the Roshe 2, a design that can help you find your peace when your round isn''t going your way. It''s inherently simple and stylish, breathable and comfortable, perfect for playing in those sizzling-hot months. A full mesh upper and a soft, lightweight foam midsole form a cushioned combination to help maintain your internal calm, even if your game goes in the gutter.', 3, CAST(2499000.00 AS Decimal(18, 2)), 2, CAST(N'2023-02-14T00:00:00.000' AS DateTime), NULL, N'/image/roshe.png')
INSERT [dbo].[Product_HS160974] ([ProductId], [name], [description], [category_id], [price], [brand_id], [created_at], [updated_at], [image]) VALUES (4, N'SUPERSTAR SHOES', N'Originally made for basketball courts in the ''70s. Celebrated by hip hop royalty in the ''80s. The adidas Superstar shoe is now a lifestyle staple for streetwear enthusiasts. The world-famous shell toe feature remains, providing style and protection. Just like it did on the B-ball courts back in the day', 1, CAST(2600000.00 AS Decimal(18, 2)), 7, CAST(N'2023-02-09T00:00:00.000' AS DateTime), NULL, N'/image/supper.png')
INSERT [dbo].[Product_HS160974] ([ProductId], [name], [description], [category_id], [price], [brand_id], [created_at], [updated_at], [image]) VALUES (7, N'Nike Air Max 90 G', N'When', 5, CAST(2213123.00 AS Decimal(18, 2)), 4, CAST(N'2023-02-09T00:00:00.000' AS DateTime), NULL, N'/image/dawnse.png')
INSERT [dbo].[Product_HS160974] ([ProductId], [name], [description], [category_id], [price], [brand_id], [created_at], [updated_at], [image]) VALUES (8, N'SUPERSTAR SHOES', N'Ok', 2, CAST(21312312.00 AS Decimal(18, 2)), 2, CAST(N'2023-06-29T00:00:00.000' AS DateTime), NULL, N'/image/90se.png')
INSERT [dbo].[Product_HS160974] ([ProductId], [name], [description], [category_id], [price], [brand_id], [created_at], [updated_at], [image]) VALUES (10, N'Olivia Thomass', N'san pham nay rat tot nen mua nhe cac ban oi ok ok', 3, CAST(22222222.00 AS Decimal(18, 2)), 14, CAST(N'2023-07-01T12:29:56.267' AS DateTime), CAST(N'2023-07-01T22:50:41.287' AS DateTime), N'blog2_phu3.png')
SET IDENTITY_INSERT [dbo].[Product_HS160974] OFF
GO
SET IDENTITY_INSERT [dbo].[Size_HS160974] ON 

INSERT [dbo].[Size_HS160974] ([sizeID], [pid], [sizeName], [quantity]) VALUES (1, 1, 36.5, 20)
INSERT [dbo].[Size_HS160974] ([sizeID], [pid], [sizeName], [quantity]) VALUES (2, 1, 37, 22)
INSERT [dbo].[Size_HS160974] ([sizeID], [pid], [sizeName], [quantity]) VALUES (3, 1, 37.5, 25)
INSERT [dbo].[Size_HS160974] ([sizeID], [pid], [sizeName], [quantity]) VALUES (4, 1, 42, 21)
INSERT [dbo].[Size_HS160974] ([sizeID], [pid], [sizeName], [quantity]) VALUES (5, 2, 36.5, 26)
INSERT [dbo].[Size_HS160974] ([sizeID], [pid], [sizeName], [quantity]) VALUES (6, 2, 37, 16)
SET IDENTITY_INSERT [dbo].[Size_HS160974] OFF
GO
ALTER TABLE [dbo].[Customers_HS160974]  WITH CHECK ADD  CONSTRAINT [FK_Customers_HS160974_Account_HS160974] FOREIGN KEY([accountID])
REFERENCES [dbo].[Account_HS160974] ([accountID])
GO
ALTER TABLE [dbo].[Customers_HS160974] CHECK CONSTRAINT [FK_Customers_HS160974_Account_HS160974]
GO
ALTER TABLE [dbo].[OrderDetails_HS160974]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_HS160974_Orders_HS160974] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders_HS160974] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails_HS160974] CHECK CONSTRAINT [FK_OrderDetails_HS160974_Orders_HS160974]
GO
ALTER TABLE [dbo].[OrderDetails_HS160974]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_HS160974_Size_HS160974] FOREIGN KEY([sizeID])
REFERENCES [dbo].[Size_HS160974] ([sizeID])
GO
ALTER TABLE [dbo].[OrderDetails_HS160974] CHECK CONSTRAINT [FK_OrderDetails_HS160974_Size_HS160974]
GO
ALTER TABLE [dbo].[Orders_HS160974]  WITH CHECK ADD  CONSTRAINT [FK_Orders_HS160974_Customers_HS160974] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers_HS160974] ([customerId])
GO
ALTER TABLE [dbo].[Orders_HS160974] CHECK CONSTRAINT [FK_Orders_HS160974_Customers_HS160974]
GO
ALTER TABLE [dbo].[Product_HS160974]  WITH CHECK ADD  CONSTRAINT [FK_Product_HS160974_Brand_HS160974] FOREIGN KEY([brand_id])
REFERENCES [dbo].[Brand_HS160974] ([id])
GO
ALTER TABLE [dbo].[Product_HS160974] CHECK CONSTRAINT [FK_Product_HS160974_Brand_HS160974]
GO
ALTER TABLE [dbo].[Product_HS160974]  WITH CHECK ADD  CONSTRAINT [FK_Product_HS160974_Category_HS160974] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category_HS160974] ([id])
GO
ALTER TABLE [dbo].[Product_HS160974] CHECK CONSTRAINT [FK_Product_HS160974_Category_HS160974]
GO
ALTER TABLE [dbo].[Size_HS160974]  WITH CHECK ADD  CONSTRAINT [FK_Size_HS160974_Product_HS160974] FOREIGN KEY([pid])
REFERENCES [dbo].[Product_HS160974] ([ProductId])
GO
ALTER TABLE [dbo].[Size_HS160974] CHECK CONSTRAINT [FK_Size_HS160974_Product_HS160974]
GO
USE [master]
GO
ALTER DATABASE [PRN211_HS160974] SET  READ_WRITE 
GO
