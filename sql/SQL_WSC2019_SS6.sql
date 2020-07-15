use master

go
create database WSC2019_SS6

go
use WSC2019_SS6

go
create table Departments (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Departments values
	(N'Department 1'),
	(N'Department 2'),
	(N'Department 3'),
	(N'Department 4')

go
create table Locations (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Locations values
	(N'Location 1'),
	(N'Location 2'),
	(N'Location 3'),
	(N'Location 4')

go
create table DepartmentLocations(
	ID int primary key identity(1,1),
	DepartmentID int foreign key references Departments(ID),
	LocationID int foreign key references Locations(ID),
	StartDate date,
	EndDate date
)
insert into DepartmentLocations values
	(1,1,'2011-11-30','2011-12-31'),
	(2,2,'2012-11-30','2012-12-31'),
	(3,3,'2013-11-30','2013-12-31'),
	(4,4,'2014-11-30','2014-12-31')

go
create table Assets (
	ID int primary key identity(1,1),
	AssetSN nvarchar(100),
	AssetName nvarchar(100),
	DepartmentLocationID int foreign key references DepartmentLocations(ID),
	EmployeeID int,
	AssetGroupID int,
	Description nvarchar(100),
	WarrantyDate int
)
insert into Assets values 
	(N'AssetSN 01',N'Asset name 1',1,1,1,N'',100),
	(N'AssetSN 02',N'Asset name 2',2,2,2,N'',200),
	(N'AssetSN 03',N'Asset name 3',3,3,3,N'',300),
	(N'AssetSN 04',N'Asset name 4',4,4,4,N'',400)

go
create table EmergencyMaintenances (
	ID int primary key identity(1,1),
	AssetID int foreign key references Assets(ID),
	PriorityID int,
	DescriptionEmergency nvarchar(100),
	OtherConsiderations nvarchar(100),
	EMRequestDate date,
	EMStartDate date,
	EMEndDate date,
	EMTechnicianNote nvarchar(100)
)
insert into EmergencyMaintenances values
	(1,1,N'',N'','2011-01-01','2011-02-02','2011-03-30',N''),
	(2,2,N'',N'','2012-01-01','2012-02-02','2012-03-30',N''),
	(3,3,N'',N'','2013-01-01','2013-02-02','2013-03-30',N''),
	(4,4,N'',N'','2014-01-01','2014-02-02','2014-03-30',N'')

go 
create table Parts(
	ID int primary key identity(1,1),
	Name nvarchar(100),
	EffectiveLife int,
	MinimumQuantity int,
	BatchNumberHasRequired bit
)
insert into Parts values
	(N'Part 1',100,100,0),
	(N'Part 2',200,200,0),
	(N'Part 3',300,300,0),
	(N'Part 4',400,400,0)

go
create table Suppliers (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Suppliers values 
	(N'Supplier 1'),
	(N'Supplier 2'),
	(N'Supplier 3'),
	(N'Supplier 4')

go
create table TransactionTypes (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into TransactionTypes values
	(N'Transaction type 1'),
	(N'Transaction type 2'),
	(N'Transaction type 3'),
	(N'Transaction type 4')

go
create table Warehouses (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Warehouses values
	(N'Warehouse 1'),
	(N'Warehouse 2'),
	(N'Warehouse 3'),
	(N'Warehouse 4')

go
create table Orders (
	ID int primary key identity(1,1),
	TransactionTypeID int foreign key references TransactionTypes(ID),
	SupplierID int foreign key references Suppliers(ID),
	EmergencyMaintenancesID int foreign key references EmergencyMaintenances(ID),
	SourceWarehouseID int foreign key references Warehouses(ID),
	DestinationWarehouseID int foreign key references Warehouses(ID),
	Date date,
	Time time
)
insert into Orders values
	(1,1,1,1,1,'2011-05-05','13:00:00'),
	(2,2,2,2,2,'2011-05-05','13:00:00'),
	(3,3,3,3,3,'2011-05-05','13:00:00'),
	(4,4,4,4,4,'2011-05-05','13:00:00')

go
create table OrderItems (
	ID int primary key identity(1,1),
	OrderID int foreign key references Orders(ID),
	PartID int foreign key references Parts(ID),
	Amount float,
	UnitPrice nvarchar(100),
	BatchNumber nvarchar(100),
	Stock nvarchar(100)
)
insert into OrderItems values 
	(1,1,100,N'dollar',N'batchXYZ',N'stock'),
	(2,2,200,N'dollar',N'batchXYZ',N'stock'),
	(3,3,300,N'dollar',N'batchXYZ',N'stock'),
	(4,4,400,N'dollar',N'batchXYZ',N'stock')