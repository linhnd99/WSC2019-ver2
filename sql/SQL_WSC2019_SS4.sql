use master

go
drop database WSC2019_SS4

go
create database WSC2019_SS4

go
use WSC2019_SS4

go
create table Suppliers (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Suppliers values 
	(N'Supply 1'),
	(N'Supply 2'),
	(N'Supply 3'),
	(N'Supply 4')
go
create table Parts(
	ID int primary key identity(1,1),
	Name nvarchar(100),
	EffectiveLife int,
	BatchNumerHasRequired bit,
	MinimumAmount float
)
insert into Parts values
	(N'Part 1',100,1,0),
	(N'Part 2',100,0,0),
	(N'Part 3',100,1,0),
	(N'Part 4',100,0,0)

go
create table Warehouses(
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Warehouses values 
	(N'Warehouse 1'),
	(N'Warehouse 2'),
	(N'Warehouse 3'),
	(N'Warehouse 4')

go
create table TransactionTypes (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into TransactionTypes values
	(N'Purchase Order'),
	(N'Warehouse')

go
create table Orders(
	ID int primary key identity(1,1),
	TransactionTypeID int foreign key references TransactionTypes(ID),
	SupplierID int foreign key references Suppliers(ID),
	SourceWarehouseID int foreign key references Warehouses(ID),
	DestinationWarehouseID int foreign key references Warehouses(ID),
	Date date
)
insert into Orders values 
	(1,1,1,1,'2011-08-13'),
	(2,2,2,2,'2012-08-13'),
	(1,3,3,3,'2013-08-13'),
	(2,4,4,4,'2014-08-13')

go
create table OrderItems (
	ID int primary key identity(1,1),
	OrderID int foreign key references Orders(ID),
	PartID int foreign key references Parts(ID),
	BatchNumber nvarchar(100),
	Amount float
)
insert into OrderItems values 
	(1,1,N'abcXYZ',100),
	(2,2,N'abcXYZ',200),
	(3,3,N'abcXYZ',300),
	(4,4,N'abcXYZ',400) 
