use master

go
create database WSC2019_SS1

go
use WSC2019_SS1

go
create table AssetGroups (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into AssetGroups values 
	(N'Asset Group 1'),
	(N'Asset Group 2'),
	(N'Asset Group 3'),
	(N'Asset Group 4')

go
create table Employees(
	ID int primary key identity(1,1),
	FirstName nvarchar(100),
	LastName nvarchar(100),
	Phone nvarchar(100)
)
insert into Employees values
	(N'Employee 1',N'Employee 1',N'0123456789001'),
	(N'Employee 2',N'Employee 2',N'0123456789002'),
	(N'Employee 3',N'Employee 3',N'0123456789003'),
	(N'Employee 4',N'Employee 4',N'0123456789004')

go
create table Locations(
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Locations values
	(N'Location 1'),
	(N'Location 2'),
	(N'Location 3'),
	(N'Location 4')

go 
create table Departments( 
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Departments values
	(N'Department 1'),
	(N'Department 2'),
	(N'Department 3'),
	(N'Department 4')

go
create table DepartmentLocations(
	ID int primary key identity(1,1),
	DepartmentID int foreign key references Departments(ID),
	LocationID int foreign key references Locations(ID),
	StartDate date,
	EndDate date,
)
insert into DepartmentLocations values
	(1,1,'2019-01-01','2020-01-01'),
	(2,2,'2019-02-02','2020-02-02'),
	(3,3,'2019-03-03','2020-03-03'),
	(4,4,'2019-04-04','2020-04-04')

go
create table Assets (
	ID int primary key identity(1,1),
	AssetSN nvarchar(100),
	AssetName nvarchar(100),
	Description nvarchar(100),
	WarrantyDate int,
	DepartmentLocationID int foreign key references DepartmentLocations(ID),
	EmployeeID int foreign key references Employees(ID),
	AssetGroupID int foreign key references AssetGroups(ID)
)
insert into Assets values
	(N'AssetSN 1',N'Asset name 1',N'abcxyz',1000,1,1,1),
	(N'AssetSN 2',N'Asset name 2',N'abcxyz',1000,2,2,2),
	(N'AssetSN 3',N'Asset name 3',N'abcxyz',1000,3,3,3),
	(N'AssetSN 4',N'Asset name 4',N'abcxyz',1000,4,4,4)

go
create table AssetPhotos(
	ID int primary key identity(1,1),
	AssetID int foreign key references Assets(ID),
	AssetPhoto nvarchar(100)
)
insert into AssetPhotos values
	(1,N'zzz'),
	(2,N'zzz'),
	(3,N'zzz'),
	(4,N'zzz')

go
create table AssetTransferLogs(
	ID int primary key identity(1,1),
	AssetID int foreign key references AssetTransferLogs(ID),
	FromAssetSN nvarchar(100),
	ToAssetSN nvarchar(100),
	FromDepartmentLocationID int foreign key references DepartmentLocations(ID),
	ToDepartmentLocationID int foreign key references DepartmentLocations(ID),
	TransferDate date
)
insert into AssetTransferLogs values
	(1,N'AssetSN 1',N'AssetSN 2',1,2,'2020-01-18')
