USE [master]
GO
/****** Object:  Database [FBV.FBVDatabaseContext]    Script Date: 6/5/2017 11:14:27 AM ******/
CREATE DATABASE [FBV.FBVDatabaseContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FBV.FBVDatabaseContext', FILENAME = N'C:\Users\Russell\FBV.FBVDatabaseContext.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FBV.FBVDatabaseContext_log', FILENAME = N'C:\Users\Russell\FBV.FBVDatabaseContext_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FBV.FBVDatabaseContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET  MULTI_USER 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FBV.FBVDatabaseContext]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[doorNumber] [nvarchar](max) NULL,
	[buildingName] [nvarchar](max) NULL,
	[streetNumber] [nvarchar](max) NULL,
	[streetName] [nvarchar](max) NULL,
	[addressLine2] [nvarchar](max) NULL,
	[addressLine3] [nvarchar](max) NULL,
	[town] [nvarchar](max) NULL,
	[region] [nvarchar](max) NULL,
	[postalCode] [nvarchar](max) NULL,
	[country] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[customerName] [nvarchar](max) NULL,
	[address_AddressID] [int] NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LineItems]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineItems](
	[orderItemID] [int] NOT NULL,
	[PurchaseOrder_purchaseOrderID] [int] NULL,
	[shortDescription] [nvarchar](max) NULL,
	[fullDescription] [nvarchar](max) NULL,
	[unitPrice] [decimal](18, 2) NOT NULL,
	[orderItemType] [int] NOT NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NOT NULL,
	[lineItemID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.LineItems] PRIMARY KEY CLUSTERED 
(
	[lineItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MembershipEntries]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipEntries](
	[MembershipEntryID] [int] IDENTITY(1,1) NOT NULL,
	[customerID] [int] NOT NULL,
	[expiryDate] [datetime] NOT NULL,
	[bookClubMembership] [bit] NOT NULL,
	[videoClubMembership] [bit] NOT NULL,
	[lineItemID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MembershipEntries] PRIMARY KEY CLUSTERED 
(
	[MembershipEntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[orderItemID] [int] IDENTITY(1,1) NOT NULL,
	[shortDescription] [nvarchar](max) NULL,
	[fullDescription] [nvarchar](max) NULL,
	[unitPrice] [decimal](18, 2) NOT NULL,
	[orderType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderItems] PRIMARY KEY CLUSTERED 
(
	[orderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrders](
	[purchaseOrderID] [int] IDENTITY(1,1) NOT NULL,
	[timeOrderPlaced] [datetime] NOT NULL,
	[customerID] [int] NOT NULL,
	[purchaseOrderStatus] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PurchaseOrders] PRIMARY KEY CLUSTERED 
(
	[purchaseOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShippingSlips]    Script Date: 6/5/2017 11:14:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingSlips](
	[shippingSlipID] [int] IDENTITY(1,1) NOT NULL,
	[shippingName] [nvarchar](max) NULL,
	[purchaseOrderID] [int] NOT NULL,
	[shippingAddress_AddressID] [int] NULL,
 CONSTRAINT [PK_dbo.ShippingSlips] PRIMARY KEY CLUSTERED 
(
	[shippingSlipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_address_AddressID]    Script Date: 6/5/2017 11:14:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_address_AddressID] ON [dbo].[Customers]
(
	[address_AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrder_purchaseOrderID]    Script Date: 6/5/2017 11:14:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_purchaseOrderID] ON [dbo].[LineItems]
(
	[PurchaseOrder_purchaseOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_customerID]    Script Date: 6/5/2017 11:14:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_customerID] ON [dbo].[MembershipEntries]
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_shippingAddress_AddressID]    Script Date: 6/5/2017 11:14:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_shippingAddress_AddressID] ON [dbo].[ShippingSlips]
(
	[shippingAddress_AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LineItems] ADD  DEFAULT ((0)) FOR [unitPrice]
GO
ALTER TABLE [dbo].[LineItems] ADD  DEFAULT ((0)) FOR [orderItemType]
GO
ALTER TABLE [dbo].[LineItems] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [startDate]
GO
ALTER TABLE [dbo].[LineItems] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [endDate]
GO
ALTER TABLE [dbo].[MembershipEntries] ADD  DEFAULT ((0)) FOR [lineItemID]
GO
ALTER TABLE [dbo].[OrderItems] ADD  DEFAULT ((0)) FOR [orderType]
GO
ALTER TABLE [dbo].[PurchaseOrders] ADD  DEFAULT ((0)) FOR [customerID]
GO
ALTER TABLE [dbo].[PurchaseOrders] ADD  DEFAULT ((0)) FOR [purchaseOrderStatus]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Customers_dbo.Addresses_address_AddressID] FOREIGN KEY([address_AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_dbo.Customers_dbo.Addresses_address_AddressID]
GO
ALTER TABLE [dbo].[LineItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PurchaseOrderItems_dbo.PurchaseOrders_PurchaseOrder_purchaseOrderID] FOREIGN KEY([PurchaseOrder_purchaseOrderID])
REFERENCES [dbo].[PurchaseOrders] ([purchaseOrderID])
GO
ALTER TABLE [dbo].[LineItems] CHECK CONSTRAINT [FK_dbo.PurchaseOrderItems_dbo.PurchaseOrders_PurchaseOrder_purchaseOrderID]
GO
ALTER TABLE [dbo].[MembershipEntries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MembershipEntries_dbo.Customers_customerID] FOREIGN KEY([customerID])
REFERENCES [dbo].[Customers] ([customerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MembershipEntries] CHECK CONSTRAINT [FK_dbo.MembershipEntries_dbo.Customers_customerID]
GO
ALTER TABLE [dbo].[ShippingSlips]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShippingSlips_dbo.Addresses_shippingAddress_AddressID] FOREIGN KEY([shippingAddress_AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[ShippingSlips] CHECK CONSTRAINT [FK_dbo.ShippingSlips_dbo.Addresses_shippingAddress_AddressID]
GO
USE [master]
GO
ALTER DATABASE [FBV.FBVDatabaseContext] SET  READ_WRITE 
GO
