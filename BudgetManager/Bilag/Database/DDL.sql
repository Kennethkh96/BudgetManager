CREATE DATABASE BudgetManager
GO
USE BudgetManager
GO
CREATE TABLE Visibility
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(100),
	[Description] NVARCHAR(255)
)
CREATE TABLE Interval
(
	IntervalTitle NVARCHAR(100) PRIMARY KEY,
	IntervalValue INT
)

CREATE TABLE Budgets
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Purpose NVARCHAR(255),
	AccountYear NVARCHAR(4),
	Fk_VisbilityId INT NOT NULL,
	BudgetTitle NVARCHAR(100),
	FK_IntervalTitle NVARCHAR(100),

	FOREIGN KEY (Fk_VisbilityId) REFERENCES Visibility(Id),
	FOREIGN KEY (FK_IntervalTitle) REFERENCES Interval(IntervalTitle),
)

insert into Visibility 
	(Title, [Description])
		VALUES 
			('Public', 'Everybody can see this'), ('Private', 'Only you can see this');
insert into Interval
	(IntervalTitle, IntervalValue)
		VALUES
			('Monthly', 1), ('Quarter', 3)