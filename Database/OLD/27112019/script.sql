USE [master]
GO
/****** Object:  Database [OnlineShop]    Script Date: 11/27/2019 11:50:09 PM ******/
CREATE DATABASE [OnlineShop]
 CONTAINMENT = NONE
GO
ALTER DATABASE [OnlineShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineShop] SET RECOVERY FULL 
GO
ALTER DATABASE [OnlineShop] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineShop] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OnlineShop', N'ON'
GO
ALTER DATABASE [OnlineShop] SET QUERY_STORE = OFF
GO
USE [OnlineShop]
GO
/****** Object:  Table [dbo].[About]    Script Date: 11/27/2019 11:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[Detail] [ntext] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nchar](250) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisplayOrder] [int] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nchar](250) NULL,
	[Status] [bit] NULL,
	[ShowOnHome] [bit] NULL,
	[Language] [varchar](2) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[CategoryID] [bigint] NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[TopHot] [datetime] NULL,
	[ViewCount] [int] NULL,
	[Tags] [nvarchar](500) NULL,
	[Language] [varchar](2) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentTag]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentTag](
	[ContentID] [bigint] NOT NULL,
	[TagID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ContentTag] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credential]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credential](
	[UserGroupID] [varchar](20) NOT NULL,
	[RoleID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Credential] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Content] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[ID] [varchar](50) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[ID] [varchar](2) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[Link] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Target] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_MenuType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CustomerID] [bigint] NULL,
	[ShipName] [nvarchar](50) NULL,
	[ShipMobile] [varchar](50) NULL,
	[ShipAddress] [nvarchar](50) NULL,
	[ShipEmail] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ProductID] [bigint] NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Code] [varchar](10) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[MoreImages] [xml] NULL,
	[Price] [decimal](18, 0) NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[IncludedVAT] [bit] NULL,
	[Quantity] [int] NOT NULL,
	[CategoryID] [bigint] NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nchar](250) NULL,
	[Status] [bit] NULL,
	[TopHot] [datetime] NULL,
	[ViewCount] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisplayOrder] [int] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nchar](250) NULL,
	[Status] [bit] NULL,
	[ShowOnHome] [bit] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Link] [nvarchar](250) NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](32) NULL,
	[GroupID] [varchar](20) NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[ProvinceID] [int] NULL,
	[DistrictID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 11/27/2019 11:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[ID] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'ADMIN', N'ADD_CONTENT')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'ADMIN', N'ADD_USER')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'ADMIN', N'DEL_USER')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'ADMIN', N'EDIT_CONTENT')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'ADMIN', N'EDIT_USER')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'ADMIN', N'VIEW_USER')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'MOD', N'EDIT_USER')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'MOD', N'VIEW_USER')
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (1, N'Trang chủ', N'/', 1, N'_blank', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (2, N'Giới thiệu', N'/gioi-thieu', 2, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (3, N'Tin tức', N'/tin-tuc', 3, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (4, N'Sản phẩm', N'/san-pham', 4, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (5, N'Liên hệ', N'/lien-he', 5, N'_self', 1, 1)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuType] ON 

INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (1, N'Menu Client Chính')
INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (2, N'Menu Client Top')
SET IDENTITY_INSERT [dbo].[MenuType] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [IncludedVAT], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescriptions], [Status], [TopHot], [ViewCount]) VALUES (1, N'Iphone 11 Pro Max', NULL, NULL, NULL, N'https://cdn.tgdd.vn/Products/Images/42/200533/iphone-11-pro-max-green-400x460.png', NULL, CAST(28000000 AS Decimal(18, 0)), CAST(26000000 AS Decimal(18, 0)), 1, 100, 2, NULL, NULL, CAST(N'2019-11-25T16:36:37.707' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, NULL, 0)
INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [IncludedVAT], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescriptions], [Status], [TopHot], [ViewCount]) VALUES (2, N'Điện thoại Samsung Galaxy S10+ (512GB)', NULL, NULL, NULL, N'https://cdn.tgdd.vn/Products/Images/42/198986/sieu-pham-galaxy-s-moi-2-512gb-black-400x460.png', NULL, CAST(0 AS Decimal(18, 0)), NULL, NULL, 0, 3, NULL, NULL, CAST(N'2019-11-25T16:58:10.057' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, NULL, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescriptions], [Status], [ShowOnHome]) VALUES (1, N'Điện thoại', N'dien-thoai', NULL, 0, NULL, CAST(N'2019-11-25T11:08:08.257' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescriptions], [Status], [ShowOnHome]) VALUES (2, N'Iphone', N'iphone', 1, 0, NULL, CAST(N'2019-11-25T13:20:38.557' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescriptions], [Status], [ShowOnHome]) VALUES (3, N'Samsung', N'samsung', 1, 0, NULL, CAST(N'2019-11-25T13:27:13.050' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescriptions], [Status], [ShowOnHome]) VALUES (4, N'GamePad', N'gamepad', NULL, 0, NULL, CAST(N'2019-11-25T13:59:08.133' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescriptions], [Status], [ShowOnHome]) VALUES (5, N'Xbox Controller', N'xbox-controller', 4, 0, NULL, CAST(N'2019-11-25T14:00:24.407' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'ACTIVE_USER', N'Kích hoạt tài khoản')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'ADD_CONTENT', N'Thêm tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'ADD_USER', N'Thêm người dùng')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'DEL_USER', N'Xóa User')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'EDIT_CONTENT', N'Chỉnh sửa tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'EDIT_USER', N'Chỉnh sửa User')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'VIEW_USER', N'Xem danh sách User')
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (1, N'assets/client/images/banner/banner-1.jpg', 1, NULL, N'XBOX one mới', CAST(N'2019-11-27T22:33:26.793' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Slide] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (2, N'assets/client/images/banner/banner-2.jpg', 2, NULL, N'IPhone 11', CAST(N'2019-11-27T22:44:12.340' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Slide] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (3, N'assets/client/images/banner/banner-3.jpg', 3, NULL, N'Mac Book', CAST(N'2019-11-27T22:47:44.750' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Slide] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Address], [Email], [Phone], [ProvinceID], [DistrictID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (1, N'admin', N'admin', N'ADMIN', N'Quy', N'TD', N'quy@gmail.com', N'0123456789', 69, 1, CAST(N'2019-11-24T23:34:44.880' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Address], [Email], [Phone], [ProvinceID], [DistrictID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (3, N'mem', N'mem', N'MEMBER', N'Sáng', N'Q9', N'sang@gmail.com', N'0987654321', 96, 2, CAST(N'2019-11-24T23:35:34.557' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Address], [Email], [Phone], [ProvinceID], [DistrictID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (4, N'tester', N'tester', N'MOD', N'tester', N'tester', NULL, N'0123456789', NULL, NULL, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'ADMIN', N'Quản trị')
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'DEFAULT', N'Chưa phân nhóm')
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'MEMBER', N'Thành viên')
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'MOD', N'Quản lí')
ALTER TABLE [dbo].[About] ADD  CONSTRAINT [DF_About_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[About] ADD  CONSTRAINT [DF_About_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_ShowOnHome]  DEFAULT ((0)) FOR [ShowOnHome]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_ViewCount]  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Language] ADD  CONSTRAINT [DF_Language_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_OrderDetail_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ViewCount]  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_ShowOnHome]  DEFAULT ((0)) FOR [ShowOnHome]
GO
ALTER TABLE [dbo].[Slide] ADD  CONSTRAINT [DF_Slide_DisplayOrder]  DEFAULT ((1)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Slide] ADD  CONSTRAINT [DF_Slide_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_GroupID]  DEFAULT ('MEMBER') FOR [GroupID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
USE [master]
GO
ALTER DATABASE [OnlineShop] SET  READ_WRITE 
GO
