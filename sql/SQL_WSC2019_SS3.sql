use master

go
create database WSC2019_SS3

go
use WSC2019_SS3

go
create table Assets (
	ID int primary key identity(1,1),
	AssetSN nvarchar(100),
	AssetName nvarchar(100),
	DepartmentLocationID int,
	EmployeeID int,
	AssetGroupID int,
	Description nvarchar(100),
	WarrantyDate int
)
insert into Assets values 
	(N'AssetSN 01',N'Asset name 01',1,1,1,N'',100),
	(N'AssetSN 02',N'Asset name 02',1,1,1,N'',100),
	(N'AssetSN 03',N'Asset name 03',1,1,1,N'',100),
	(N'AssetSN 04',N'Asset name 04',1,1,1,N'',100)

go
create table AssetOdometers (
	ID int primary key identity(1,1),
	AssetID int foreign key references Assets(ID),
	ReadDate date,
	OdometerAmount float
)
insert into AssetOdometers values 
	(1,'2011-06-15',10),
	(2,'2012-06-15',20),
	(3,'2013-06-15',30),
	(4,'2014-06-15',40)

go
create table PMScheduleTypes(
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into PMScheduleTypes values 
	(N'Schedule type 1'),
	(N'Schedule type 2'),
	(N'Schedule type 3'),
	(N'Schedule type 4')

go
create table PMScheduleModels(
	ID int primary key identity(1,1),
	Name nvarchar(100),
	PMScheduleTypeID int foreign key references PMScheduleTypes(ID)
)
insert into PMScheduleModels values
	(N'Schedule Model 1',1),
	(N'Schedule Model 1',2),
	(N'Schedule Model 1',3),
	(N'Schedule Model 1',4)

go
create table Tasks(
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into Tasks values
	(N'Task 1'),
	(N'Task 2'),
	(N'Task 3'),
	(N'Task 4')

go
create table PMTasks (
	ID int primary key identity(1,1),
	AssetID int foreign key references Assets(ID),
	TaskID int foreign key references Tasks(ID),
	PMScheduleTypeID int foreign key references PMScheduleTypes(ID),
	ScheduleDate date,
	ScheduleKilometer int,
	TaskDone bit
)
insert into PMTasks values
	(1,1,1,'2011-09-15',100,1),
	(2,2,2,'2012-09-15',200,0),
	(3,3,3,'2013-09-15',300,0),
	(4,4,4,'2014-09-15',400,0)