USE [master]
GO
/****** Object:  Database [OnlineShopping]    Script Date: 9/23/2019 7:25:23 PM ******/
CREATE DATABASE [OnlineShopping]
 CONTAINMENT = NONE
GO
ALTER DATABASE [OnlineShopping] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineShopping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineShopping] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineShopping] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineShopping] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineShopping] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineShopping] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineShopping] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineShopping] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineShopping] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineShopping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineShopping] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineShopping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineShopping] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineShopping] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineShopping] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineShopping] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineShopping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineShopping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineShopping] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineShopping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineShopping] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineShopping] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineShopping] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineShopping] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineShopping] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineShopping] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineShopping] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineShopping] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineShopping] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineShopping] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineShopping] SET QUERY_STORE = OFF
GO
USE [OnlineShopping]
GO
/****** Object:  Table [ActionInFunctions]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ActionInFunctions](
	[FunctionId] [int] IDENTITY(1,1) NOT NULL,
	[ActionId] [int] NOT NULL,
 CONSTRAINT [PK_ActionInFunctions] PRIMARY KEY CLUSTERED 
(
	[FunctionId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Actions]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Actions](
	[Id] [int] NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AdvertisementPages]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AdvertisementPages](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AdvertisementPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AdvertisementPositions]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AdvertisementPositions](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PageId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AdvertisementPositions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Advertisements]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Advertisements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PositionId] [varchar](50) NOT NULL,
	[PageId] [varchar](50) NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
	[Video] [nvarchar](250) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[ClickCount] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Advertisements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Attributes]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Attributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AttributeValues]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AttributeValues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NULL,
	[Name] [nvarchar](128) NULL,
 CONSTRAINT [PK_AttributeValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Catalogs]    Script Date: 9/23/2019 7:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Catalogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[SeoAlias] [varchar](128) NULL,
	[SiteTitle] [nvarchar](128) NULL,
	[MetaKeywords] [nvarchar](158) NULL,
	[MetaDescription] [nvarchar](158) NULL,
	[ParentId] [int] NULL,
	[SortOrder] [int] NULL,
	[Visibility] [bit] NOT NULL,
 CONSTRAINT [PK_Catalog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Categories]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ParentId] [int] NULL,
	[SortOrder] [int] NULL,
	[ShowInMenu] [bit] NULL,
	[ShowInHome] [bit] NULL,
	[Thumbnail] [nvarchar](250) NULL,
	[SeoAlias] [varchar](128) NULL,
	[SiteTitle] [nvarchar](128) NULL,
	[MetaKeywords] [nvarchar](158) NULL,
	[MetaDescription] [nvarchar](158) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Comments]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [bit] NULL,
	[Report] [int] NULL,
	[PostId] [int] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Customers]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customers](
	[Id] [int] NOT NULL,
	[CustomerName] [nvarchar](128) NULL,
	[CustomerPhone] [nvarchar](128) NULL,
	[CustomerEmail] [nvarchar](128) NULL,
	[CustomerAddress] [nvarchar](128) NULL,
	[CustomerCity] [nvarchar](128) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Footers]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Footers](
	[Id] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Footers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Functions]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Functions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
	[SortOrder] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [OrderItems]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [OrderItems](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quanity] [int] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Orders]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrdersDate] [datetime] NULL,
	[Status] [int] NOT NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Pages]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[SeoAlias] [nvarchar](250) NULL,
	[Content] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[SiteTitle] [nvarchar](128) NULL,
	[MetaKeywords] [nvarchar](158) NULL,
	[MetaDescription] [nvarchar](158) NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Permissions]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Permissions](
	[UserId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[FunctionId] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ActionId] ASC,
	[FunctionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [PostInCategories]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PostInCategories](
	[PostId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_PostInCategories] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [PostInTags]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PostInTags](
	[PostId] [int] NOT NULL,
	[TagId] [varchar](250) NOT NULL,
 CONSTRAINT [PK_PostInTags] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Posts]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Content] [ntext] NULL,
	[Thumbnail] [nvarchar](250) NULL,
	[Image] [nvarchar](250) NULL,
	[ImageCaption] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[PublishedDate] [datetime] NULL,
	[Source] [nvarchar](250) NULL,
	[Status] [int] NOT NULL,
	[SeoAlias] [nvarchar](250) NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[SeoMetaKeywords] [nvarchar](158) NULL,
	[SeoMetaDescription] [nvarchar](158) NULL,
	[HotDate] [datetime] NULL,
	[NewDate] [datetime] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [ProductAttributes]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ProductAttributes](
	[ProductId] [int] NOT NULL,
	[AttributeValueId] [int] NOT NULL,
 CONSTRAINT [PK_ProductAttributes] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[AttributeValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ProductLinks]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ProductLinks](
	[Id] [int] NOT NULL,
	[ProductId] [int] NULL,
	[LinkedProductId] [int] NULL,
 CONSTRAINT [PK_ProductLinks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Products]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NULL,
	[CatalogId] [int] NULL,
	[Description] [nvarchar](128) NULL,
	[Content] [ntext] NULL,
	[Price] [decimal](18, 2) NULL,
	[PromotionPrice] [decimal](18, 2) NULL,
	[Image] [nvarchar](128) NULL,
	[ThumbImage] [nvarchar](128) NULL,
	[ImageList] [nvarchar](max) NULL,
	[SiteTitle] [nvarchar](128) NULL,
	[MetaKeywords] [nvarchar](158) NULL,
	[MetaDescription] [nvarchar](158) NULL,
	[ViewCount] [int] NULL,
	[Warranty] [int] NULL,
	[Video] [nvarchar](128) NULL,
	[DateCreated] [datetime] NULL,
	[UserCreated] [int] NULL,
	[DateModified] [datetime] NULL,
	[UserModified] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Roles]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Roles](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Settings]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Settings](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValueNumber] [int] NULL,
	[ValueBit] [bit] NULL,
	[ValueString] [nvarchar](50) NULL,
	[ValueDate] [date] NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Slides]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Slides](
	[Id] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[SortOrder] [int] NULL,
	[Url] [varchar](250) NULL,
	[Target] [varchar](10) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Status] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Tags]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tags](
	[Id] [varchar](250) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [UserRoles]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [UserRoles](
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Users]    Script Date: 9/23/2019 7:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](250) NULL,
	[RegisteredDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [ActionInFunctions]  WITH CHECK ADD  CONSTRAINT [FK_ActionInFunctions_Actions] FOREIGN KEY([ActionId])
REFERENCES [Actions] ([Id])
GO
ALTER TABLE [ActionInFunctions] CHECK CONSTRAINT [FK_ActionInFunctions_Actions]
GO
ALTER TABLE [ActionInFunctions]  WITH CHECK ADD  CONSTRAINT [FK_ActionInFunctions_Functions] FOREIGN KEY([FunctionId])
REFERENCES [Functions] ([Id])
GO
ALTER TABLE [ActionInFunctions] CHECK CONSTRAINT [FK_ActionInFunctions_Functions]
GO
ALTER TABLE [AdvertisementPositions]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementPositions_AdvertisementPages] FOREIGN KEY([PageId])
REFERENCES [AdvertisementPages] ([Id])
GO
ALTER TABLE [AdvertisementPositions] CHECK CONSTRAINT [FK_AdvertisementPositions_AdvertisementPages]
GO
ALTER TABLE [Advertisements]  WITH CHECK ADD  CONSTRAINT [FK_Advertisements_AdvertisementPages] FOREIGN KEY([PageId])
REFERENCES [AdvertisementPages] ([Id])
GO
ALTER TABLE [Advertisements] CHECK CONSTRAINT [FK_Advertisements_AdvertisementPages]
GO
ALTER TABLE [Advertisements]  WITH CHECK ADD  CONSTRAINT [FK_Advertisements_AdvertisementPositions] FOREIGN KEY([PositionId])
REFERENCES [AdvertisementPositions] ([Id])
GO
ALTER TABLE [Advertisements] CHECK CONSTRAINT [FK_Advertisements_AdvertisementPositions]
GO
ALTER TABLE [AttributeValues]  WITH CHECK ADD  CONSTRAINT [FK_AttributeValues_Attributes] FOREIGN KEY([AttributeId])
REFERENCES [Attributes] ([Id])
GO
ALTER TABLE [AttributeValues] CHECK CONSTRAINT [FK_AttributeValues_Attributes]
GO
ALTER TABLE [Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ParentId])
REFERENCES [Categories] ([Id])
GO
ALTER TABLE [Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts] FOREIGN KEY([PostId])
REFERENCES [Posts] ([Id])
GO
ALTER TABLE [Comments] CHECK CONSTRAINT [FK_Comments_Posts]
GO
ALTER TABLE [Functions]  WITH CHECK ADD  CONSTRAINT [FK_Functions_Functions] FOREIGN KEY([ParentId])
REFERENCES [Functions] ([Id])
GO
ALTER TABLE [Functions] CHECK CONSTRAINT [FK_Functions_Functions]
GO
ALTER TABLE [OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId])
REFERENCES [Orders] ([Id])
GO
ALTER TABLE [OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]
GO
ALTER TABLE [OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Products] FOREIGN KEY([ProductId])
REFERENCES [Products] ([Id])
GO
ALTER TABLE [OrderItems] CHECK CONSTRAINT [FK_OrderItems_Products]
GO
ALTER TABLE [Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [Customers] ([Id])
GO
ALTER TABLE [Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Actions] FOREIGN KEY([ActionId])
REFERENCES [Actions] ([Id])
GO
ALTER TABLE [Permissions] CHECK CONSTRAINT [FK_Permissions_Actions]
GO
ALTER TABLE [Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Functions] FOREIGN KEY([FunctionId])
REFERENCES [Functions] ([Id])
GO
ALTER TABLE [Permissions] CHECK CONSTRAINT [FK_Permissions_Functions]
GO
ALTER TABLE [Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Users] FOREIGN KEY([UserId])
REFERENCES [Users] ([Id])
GO
ALTER TABLE [Permissions] CHECK CONSTRAINT [FK_Permissions_Users]
GO
ALTER TABLE [PostInCategories]  WITH CHECK ADD  CONSTRAINT [FK_PostInCategories_Categories] FOREIGN KEY([CategoryId])
REFERENCES [Categories] ([Id])
GO
ALTER TABLE [PostInCategories] CHECK CONSTRAINT [FK_PostInCategories_Categories]
GO
ALTER TABLE [PostInCategories]  WITH CHECK ADD  CONSTRAINT [FK_PostInCategories_Posts] FOREIGN KEY([PostId])
REFERENCES [Posts] ([Id])
GO
ALTER TABLE [PostInCategories] CHECK CONSTRAINT [FK_PostInCategories_Posts]
GO
ALTER TABLE [PostInTags]  WITH CHECK ADD  CONSTRAINT [FK_PostInTags_Posts] FOREIGN KEY([PostId])
REFERENCES [Posts] ([Id])
GO
ALTER TABLE [PostInTags] CHECK CONSTRAINT [FK_PostInTags_Posts]
GO
ALTER TABLE [PostInTags]  WITH CHECK ADD  CONSTRAINT [FK_PostInTags_Tags] FOREIGN KEY([TagId])
REFERENCES [Tags] ([Id])
GO
ALTER TABLE [PostInTags] CHECK CONSTRAINT [FK_PostInTags_Tags]
GO
ALTER TABLE [ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_AttributeValues] FOREIGN KEY([ProductId])
REFERENCES [AttributeValues] ([Id])
GO
ALTER TABLE [ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_AttributeValues]
GO
ALTER TABLE [ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_Products] FOREIGN KEY([ProductId])
REFERENCES [Products] ([Id])
GO
ALTER TABLE [ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_Products]
GO
ALTER TABLE [ProductLinks]  WITH CHECK ADD  CONSTRAINT [FK_ProductLinks_Products] FOREIGN KEY([ProductId])
REFERENCES [Products] ([Id])
GO
ALTER TABLE [ProductLinks] CHECK CONSTRAINT [FK_ProductLinks_Products]
GO
ALTER TABLE [ProductLinks]  WITH CHECK ADD  CONSTRAINT [FK_ProductLinks_Products1] FOREIGN KEY([LinkedProductId])
REFERENCES [Products] ([Id])
GO
ALTER TABLE [ProductLinks] CHECK CONSTRAINT [FK_ProductLinks_Products1]
GO
ALTER TABLE [Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Catalogs] FOREIGN KEY([CatalogId])
REFERENCES [Catalogs] ([Id])
GO
ALTER TABLE [Products] CHECK CONSTRAINT [FK_Products_Catalogs]
GO
ALTER TABLE [UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [Roles] ([Id])
GO
ALTER TABLE [UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [Users] ([Id])
GO
ALTER TABLE [UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
USE [master]
GO
ALTER DATABASE [OnlineShopping] SET  READ_WRITE 
GO
