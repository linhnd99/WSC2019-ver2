use master

go
create database WSC2019_SS5

go
use WSC2019_SS5

go
create table RockTypes (
	ID int primary key identity(1,1),
	Name nvarchar(100),
	BackgroundColor nvarchar(100)
)
insert into RockTypes values 
	(N'Rock type 1',N'red'),
	(N'Rock type 2',N'red'),
	(N'Rock type 3',N'red'),
	(N'Rock type 4',N'red')

go
create table WellTypes (
	ID int primary key identity(1,1),
	Name nvarchar(100)
)
insert into WellTypes values 
	(N'Well type 1'),
	(N'Well type 2'),
	(N'Well type 3'),
	(N'Well type 4')

go
create table Wells(
	ID int primary key identity(1,1),
	WellTypeID int foreign key references WellTypes(ID),
	WellName nvarchar(100),
	GasOilDepth nvarchar(100),
	Capacity int
)
insert into Wells values 
	(1,N'well name 1',N'GasOilDepth',10),
	(2,N'well name 2',N'GasOilDepth',20),
	(3,N'well name 3',N'GasOilDepth',30),
	(4,N'well name 4',N'GasOilDepth',40)

go
create table WellPlayers (
	ID int primary key identity(1,1),
	WellID int foreign key references Wells(ID),
	RockTypeID int foreign key references RockTypes(ID),
	StartPoint int,
	EndPoint int
)

insert into WellPlayers values
	(1,1,1,10),
	(2,2,2,20),
	(3,3,3,30),
	(4,4,4,40)