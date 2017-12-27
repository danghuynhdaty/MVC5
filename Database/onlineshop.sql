-- TẠO DATABASE 

USE master
IF	EXISTS(SELECT * FROM sys.databases  WHERE name='OnlineShop')
DROP DATABASE OnlineShop
CREATE DATABASE OnlineShop
ON   
( NAME = OnlineShop_Data,  
    FILENAME = 'D:\Projects\Web\OnlineShop\Database\OnlineShopData.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = OnlineShop_Log,  
    FILENAME = 'D:\Projects\Web\OnlineShop\Database\OnlineShopLog.ldf',   
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB ) 
GO
  
USE OnlineShop 
GO  

-- TẠO CÁC BẢNG TRONG DATABASE
CREATE TABLE ProductCategory(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(250),
	MetaTitle VARCHAR(250),
	ParentID BIGINT,
	DisplayOrder INT DEFAULT 0,
	SeoTitle NVARCHAR(250),
	CreatedDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(250),
	ModifiedDate DATETIME,
	ModifiedBy DATETIME,
	MetaKeyWords NVARCHAR(250),
	MetaDescription VARCHAR(250),
	Status BIT DEFAULT 1,
	ShowOnHome BIT DEFAULT 0
)
GO

CREATE TABLE Product(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(250),
	Code VARCHAR(20),
	MetaTitle VARCHAR(250),
	Description VARCHAR(500),
	Image NVARCHAR(250),
	Images XML,
	Price DECIMAL DEFAULT 0,
	PromotionPrice DECIMAL, -- giá khuyến mãi
	IncludeVAT BIT , -- đã có vat thì k tính thêm vat cho sản phẩm
	Quantity INT DEFAULT 0,
	CategoryID BIGINT NOT NULL,
	Detail NTEXT,
	Warranty INT, -- số tháng bảo hành
	SeoTitle NVARCHAR(250),
	CreatedDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(250),
	ModifiedDate DATETIME,
	ModifiedBy DATETIME,
	MetaKeyWords NVARCHAR(250),
	MetaDescription VARCHAR(250),
	Status BIT DEFAULT 1,
	TopMost DATETIME,
	ViewCount INT DEFAULT 0,
)
GO


-- CategoryNews
CREATE TABLE CategoryNews(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(250),
	MetaTitle VARCHAR(250),
	ParentID BIGINT,
	DisplayOrder INT DEFAULT 0,
	SeoTitle NVARCHAR(250),
	CreatedDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(250),
	ModifiedDate DATETIME,
	ModifiedBy DATETIME,
	MetaKeyWords NVARCHAR(250),
	MetaDescription VARCHAR(250),
	Status BIT DEFAULT 1,
	ShowOnHome BIT DEFAULT 0
)
GO

-- Content dành cho nội dung của tin tức

CREATE TABLE Content(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(250),
	MetaTitle VARCHAR(250),
	Description VARCHAR(500),
	Image NVARCHAR(250),
	CategoryID BIGINT NOT NULL,
	Detail NTEXT,
	SeoTitle NVARCHAR(250),
	CreatedDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(250),
	ModifiedDate DATETIME,
	ModifiedBy DATETIME,
	MetaKeyWords NVARCHAR(250),
	MetaDescription VARCHAR(250),
	Status BIT DEFAULT 1,
	TopMost DATETIME,
	ViewCount INT DEFAULT 0,
	Tags NVARCHAR(500), -- tag dùng cho seo
)
GO

--Tag
CREATE TABLE Tag(
	ID VARCHAR(50) PRIMARY KEY,
	Name NVARCHAR(50)
)
GO

--ContentTag
CREATE TABLE ContentTag(
	ContentID BIGINT NOT NULL,
	TagID VARCHAR(50) NOT NULL,
	PRIMARY KEY(ContentID,TagID)
)
GO

-- About --
CREATE TABLE About(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(250),
	MetaTitle VARCHAR(250),
	Description VARCHAR(500),
	Image NVARCHAR(250),
	Detail NTEXT,
	CreatedDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(250),
	ModifiedDate DATETIME,
	ModifiedBy DATETIME,
	MetaKeyWords NVARCHAR(250),
	MetaDescription VARCHAR(250),
	Status BIT DEFAULT 1,
	
)
GO

--Contact
CREATE TABLE Contact(
	ID INT PRIMARY KEY IDENTITY,
	ContactContent NTEXT,
	Status INT DEFAULT 1, 
)
GO 

--feedback
CREATE TABLE FeedBack(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50),
	Phone NVARCHAR(50),
	Email NVARCHAR(50),
	Address NVARCHAR(50),
	FbContent NTEXT,
	CreatedDate DATETIME DEFAULT GETDATE(),
	Status BIT DEFAULT 0, -- trạng thái đã đọc hay chưa
)
GO 

--Slide
CREATE  TABLE Slide(
	ID INT PRIMARY KEY IDENTITY,
	Image NVARCHAR(250),
	DisplayOrder INT, 
	Link NVARCHAR(250),
	Description NVARCHAR(50),
	Status BIT DEFAULT 1,
	CreatedDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(250),
	ModifiedDate DATETIME,
	ModifiedBy DATETIME,
)
GO 

--MenuType
CREATE TABLE MenuType(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50),
)

--Menu
CREATE TABLE Menu(
	ID INT PRIMARY KEY IDENTITY,
	Text NVARCHAR(50),
	Link NVARCHAR(250),
	DisplayOrder INT,
	Target NVARCHAR(50),
	Status BIT DEFAULT 1,
	TypeID INT NOT NULL,
)

--Footer
CREATE TABLE Footer(
	ID VARCHAR(50) PRIMARY KEY ,
	FooterContent NTEXT,
	Status BIT DEFAULT 1,
)

--SystemConfig
CREATE TABLE SystemConfig(
	ID VARCHAR( 50) PRIMARY KEY,
	Name NVARCHAR(50),
	Type NVARCHAR(50),
	Value NVARCHAR(50),
	Status BIT DEFAULT 1,
)
GO 

CREATE TABLE Account(
	ID INT PRIMARY KEY IDENTITY,
	UserName VARCHAR(50),
	PassWord VARCHAR(32),
	Name NVARCHAR(50),
	Address NVARCHAR(250),
	Email NVARCHAR(50),
	Phone NVARCHAR(50) ,
	Status BIT DEFAULT 1 NOT NULL,
	CreatedDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(250),
	ModifiedDate DATETIME,
	ModifiedBy BIGINT,
)
GO

INSERT INTO dbo.Account
        ( UserName ,
          PassWord ,
          Name ,
          Address ,
          Email ,
          Phone ,
          Status ,
          CreatedDate ,
          CreatedBy ,
          ModifiedDate ,
          ModifiedBy
        )
VALUES  ( 'daty' , -- UserName - varchar(50)
          'c4ca4238a0b923820dcc509a6f75849b' , -- PassWord - varchar(32)
          N'Đặng Huỳnh Đạt Ý' , -- Name - nvarchar(50)
          N'Bình Định' , -- Address - nvarchar(250)
          N'dhatyit.sgu@gmail.com' , -- Email - nvarchar(50)
          N'0972165976' , -- Phone - nvarchar(50)
          1 , -- Status - bit
          GETDATE() , -- CreatedDate - datetime
          '' , -- CreatedBy - varchar(250)
           '', -- ModifiedDate - datetime
          1  -- ModifiedBy - bigint
        )


GO

DECLARE @i INT = 51;
WHILE @i < 5000
BEGIN
	INSERT INTO dbo.Account
	        ( UserName ,
	          PassWord ,
	          Name ,
	          Address ,
	          Email ,
	          Phone ,
	          Status ,
	          CreatedDate ,
	          CreatedBy ,
	          ModifiedDate ,
	          ModifiedBy
	        )
	VALUES  ( 'admin'+CAST(@i AS NVARCHAR(10)) , -- UserName - varchar(50)
	          'c4ca4238a0b923820dcc509a6f75849b' , -- PassWord - varchar(32)
	          N'' , -- Name - nvarchar(50)
	          N'' , -- Address - nvarchar(250)
	          N'' , -- Email - nvarchar(50)
	          N'' , -- Phone - nvarchar(50)
	          1 , -- Status - bit
	          GETDATE() , -- CreatedDate - datetime
	          '' , -- CreatedBy - varchar(250)
	          GETDATE() , -- ModifiedDate - datetime
	          0  -- ModifiedBy - bigint
	        )
			SET @i += 1
END
GO

SELECT * FROM dbo.Account
GO


