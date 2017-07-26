create database ShopInternetCiclum;
use ShopInternetCiclum;

create table Product(
Id int identity primary key,
Name varchar(150),
ImageUrl varchar(MAX),
Price varchar(100),
Descriptions varchar(MAX));

create table HistoryRefreshPrice(
Id int identity primary key,
RefreshDate datetime,
Price varchar(100),
ProductId int,
foreign key (ProductId) references Product(Id));



create table ProductTags(
Id int identity primary key,
TagCatalog varchar(80),
TagName varchar(80),
TagParentImage varchar(80),
TagPrice varchar(80),
TagDescription varchar(80));


create table UrlShop(
Id int identity primary key,
Url varchar(100),
ProductTagsId int,
foreign key (ProductTagsId) references ProductTags(Id));



select * from UrlShop;
select * from Product;
select * from ProductTags;
select * from HistoryRefreshPrice;

delete from UrlShop;
DBCC CHECKIDENT (UrlShop, RESEED, 0);

delete from ProductTags;
DBCC CHECKIDENT (ProductTags, RESEED, 0);

delete from HistoryRefreshPrice;
DBCC CHECKIDENT (HistoryRefreshPrice, RESEED, 0);

delete from Product;
DBCC CHECKIDENT (Product, RESEED, 0);

