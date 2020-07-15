use master

go
create database WSC2019_SS2

go
use WSC2019_SS2

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
create table DepartmentLocations(
	ID int primary key identity(1,1),
	DepartmentID int foreign key references Departments(ID),
	LocationID int foreign key references Locations(ID),
	StartDate date,
	EndDate date
)
insert into DepartmentLocations values
	(1,1,'2019-01-01','2020-01-01'),
	(2,2,'2019-02-02','2020-02-02'),
	(3,3,'2019-03-03','2020-03-03'),
	(4,4,'2019-04-04','2020-04-04')

go
create table AssetGroups(
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
	Phone nvarchar(100),
	isAdmin bit,
	Username nvarchar(100),
	Password nvarchar(100)
)
insert into Employees values
	(N'Employee 1',N'Employee 1',N'0123456789001',1,N'admin',N'123'),
	(N'Employee 2',N'Employee 2',N'0123456789002',0,N'user1',N'123'),
	(N'Employee 3',N'Employee 3',N'0123456789003',0,N'user2',N'123'),
	(N'Employee 4',N'Employee 4',N'0123456789004',0,N'user3',N'123')


go
create table Assets(
	ID int primary key identity(1,1),
	AssetSN nvarchar(100),
	AssetName nvarchar(100),
	DepartmentLocationID int foreign key references DepartmentLocations(ID),
	EmployeeID int foreign key references Employees(ID),
	AssetGroupID int foreign key references AssetGroups(ID),
	WarrantyDate int
)
insert into Assets values
	(N'AssetSN 1',N'Asset name 1',1,1,1,100),
	(N'AssetSN 2',N'Asset name 2',2,2,2,200),
	(N'AssetSN 3',N'Asset name 3',3,3,3,300),
	(N'AssetSN 4',N'Asset name 4',4,4,4,400)

go
create table Parts(
	ID int primary key identity(1,1),
	Name nvarchar(100),
	EffectiveLife int
)
insert into Parts values
	(N'Part 1',10),
	(N'Part 2',20),
	(N'Part 3',30),
	(N'Part 4',40)

go
create table Priorities(
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Priorities values
	(N'Priority 1'),
	(N'Priority 2'),
	(N'Priority 3'),
	(N'Priority 4')

go
create table EmergencyMaintenances(
	ID int primary key identity(1,1),
	AssetID int foreign key references Assets(ID),
	PriorityID int foreign key references Priorities(ID),
	DescriptionEmergency nvarchar(100),
	OtherConsiderations nvarchar(100),
	EMReportDate date,
	EMStartDate date,
	EMEndDate date,
	EMTechinicianNote nvarchar(100)
)
insert into EmergencyMaintenances values
	(1,1,N'aaa',N'bbb','2011-01-01','2011-02-02','2011-03-03',N''),
	(2,2,N'aaa',N'bbb','2012-01-01','2012-02-02','2012-03-03',N''),
	(3,3,N'aaa',N'bbb','2013-01-01','2013-02-02','2013-03-03',N''),
	(4,4,N'aaa',N'bbb','2014-01-01','2014-02-02','2014-03-03',N'')

go
create table ChangedParts (
	ID int primary key identity(1,1),
	EmergencyMaintenanceID int foreign key references EmergencyMaintenances(ID),
	PartID int foreign key references Parts(ID),
	Amount float
)
insert into ChangedParts values 
	(1,1,10),
	(2,2,20),
	(3,3,30),
	(4,4,40)
