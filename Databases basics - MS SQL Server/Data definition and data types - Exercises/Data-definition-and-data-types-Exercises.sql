--Problem 1. Create Database
CREATE DATABASE Minions

USE Minions

--Problem 2. Create Tables
CREATE TABLE Minions (
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
Age INT
)

CREATE TABLE Towns (
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

--Problem 3. Alter Minions Table
ALTER TABLE MINIONS
ADD TownID INT FOREIGN KEY REFERENCES Towns(ID)

--Problem 4. Insert Records in Both Tables
SET IDENTITY_INSERT Towns ON

INSERT INTO Towns (ID, [Name])
VALUES (1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')

SET IDENTITY_INSERT Towns OFF

SET IDENTITY_INSERT MInions ON

INSERT INTO Minions (ID, [Name], Age, TownID)
VALUES (1, 'Kevin', 22, 1),
		(2, 'Bob', 15, 3),
		(3, 'Steward', NULL, 2)

SET IDENTITY_INSERT Minions OFF

--Problem 5. Truncate Table Minions
TRUNCATE TABLE Minions

--Problem 6. Drop All Tables
DROP TABLE Minions
DROP TABLE Towns

--Problem 7. Create Table People
CREATE TABLE People (
	ID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) CHECK(Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate)
VALUES ('Boyan',  1.78, 73.70, 'm', CONVERT(datetime, '12-02-2018', 103)),
		('Mariya', 1.63, 58.55, 'f', CONVERT(datetime, '23-07-2018', 103)),
		('Gosho', 1.70, 65.35, 'm', CONVERT(datetime, '13-08-2018', 103)),
		('Ginka', 1.57, 52.76, 'f', CONVERT(datetime, '12-04-2018', 103)),
		('Misho', 1.81, 76.30, 'm', CONVERT(datetime, '16-09-2018', 103))


--Problem 8. Create Table Users
CREATE TABLE Users (
  ID BIGINT UNIQUE IDENTITY NOT NULL,
  Username VARCHAR(30) NOT NULL UNIQUE,
  [Password] VARCHAR(26) NOT NULL,
  ProfilePicture VARBINARY(MAX),
  LastLoginTime DATETIME2,
  IsDeleted BIT DEFAULT(0)
)

ALTER TABLE Users
ADD CONSTRAINT PK_Users 
PRIMARY KEY(ID)

ALTER TABLE Users
ADD CONSTRAINT CHK_Users 
CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024)

INSERT INTO Users (Username, [Password], IsDeleted)
VALUES ('Boyan', HASHBYTES('SHA1', '1234'), 1),
		('Gosho', HASHBYTES('SHA1', '324344'), 0),
		('Pesho', HASHBYTES('SHA1', '235435'), 1),
		('Misho', HASHBYTES('SHA1', '2132'), 0),
		('Mariya', HASHBYTES('SHA1', '09908'), 1)


--Problem 9. Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users 
PRIMARY KEY (ID, Username)

--Problem 10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_Password
CHECK (LEN([Password]) >= 5)

--Problem 11. Set Default Value of a Field
ALTER TABLE Users
ADD DEFAULT GETDATE()
FOR LastLoginTime

--Problem 12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_ID
PRIMARY KEY (ID)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username 
UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_Username
CHECK (LEN(Username) >= 3)

--Problem 13. Movies Database
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors (
  ID INT PRIMARY KEY IDENTITY,
  DirectorName NVARCHAR(50) NOT NULL,
  Notes NTEXT
)

CREATE TABLE Genres (
  ID INT PRIMARY KEY IDENTITY,
  GenreName NVARCHAR(50) NOT NULL,
  Notes NTEXT
)

CREATE TABLE Categories (
  ID INT PRIMARY KEY IDENTITY,
  CategoryName NVARCHAR(50) NOT NULL,
  Notes NTEXT
)

CREATE TABLE Movies (
  ID INT PRIMARY KEY IDENTITY,
  Title NVARCHAR(150) NOT NULL,
  DirectorID INT FOREIGN KEY REFERENCES Directors(ID) NOT NULL,
  CopyRightYear SMALLINT,
  [Length] VARCHAR(10) NOT NULL,
  GenreID INT FOREIGN KEY REFERENCES Genres(ID) NOT NULL,
  CategoryID INT FOREIGN KEY REFERENCES Categories(ID) NOT NULL,
  Rating FLOAT,
  Notes NTEXT
)

INSERT INTO Directors (DirectorName)
VALUES ('Boyan'),
		('Mariya'),
		('Petko'),
		('Misho'),
		('Pesho')

INSERT INTO Genres (GenreName)
VALUES ('comedy'),
		('Fantasy'),
		('western'),
		('action'),
		('adventure')

INSERT INTO Categories (CategoryName)
VALUES ('A'),
		('B'),
		('C'),
		('D'),
		('E')

INSERT INTO Movies (Title, DirectorID, CopyRightYear, [Length], GenreID, CategoryID, Rating)
VALUES ('back to the future', 1, 2001, '106:05', 2, 1, 12.4),
		('fast and furious 8', 4, 2017, '120:13', 5, 3, 25.67),
		('wizard of waverly place', 3, 2009, '106:05', 3, 2, 8.46),
		('back to the future 2', 2, 2001, '106:05', 1, 4, 16.7),
		('back to the future 3', 5, 2001, '106:05', 4, 5, 5.97)


--Problem 14. Car Rental Database
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories (
  ID INT PRIMARY KEY IDENTITY,
  CategoryName NVARCHAR(50) NOT NULL,
  DailyRate FLOAT NOT NULL,
  WeeklyRate FLOAT NOT NULL,
  MonthlyRate FLOAT NOT NULL,
  WeekendRate FLOAT NOT NULL
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('MINI CAR', 10.5, 80, 200.50, 48.55),
		('ECONOMY CAR', 8, 60, 160, 35),
		('COMPACT CAR', 9.8, 68.35, 180, 40)

CREATE TABLE Cars (
  ID INT PRIMARY KEY IDENTITY,
  PlateNumber NVARCHAR(30) NOT NULL,
  Manufacturer NVARCHAR(50) NOT NULL,
  Model NVARCHAR(50) NOT NULL,
  CarYear SMALLINT NOT NULL,
  CategoryID INT FOREIGN KEY REFERENCES Categories(ID) NOT NULL,
  Doors TINYINT NOT NULL,
  Picture VARBINARY(MAX),
  Condition NVARCHAR(50) NOT NULL,
  Available BIT DEFAULT 1 NOT NULL
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryID, Doors, Condition, Available)
VALUES ('СТ5098ТД', 'AUDI', 'A3', 2004, 2, 3, 'new', 1),
		('СВ6523ХГ', 'AUDI', 'A6', 2016, 1, 5, 'new', 0),
		('PB6745ФД', 'AUDI', 'A8', 2019, 3, 3, 'used', 1)

CREATE TABLE Employees (
  ID INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL,
  Title NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES ('Boyan', 'Kolev', 'human resorses'),
		('Mariya', 'Stancheva', 'mechanic'),
		('Georgi', 'Manev', 'manager')

CREATE TABLE Customers (
  ID INT PRIMARY KEY IDENTITY,
  DriverLicenseNumber VARCHAR(20) NOT NULL,
  FullName NVARCHAR(150) NOT NULL,
  [Address] NVARCHAR(200) NOT NULL,
  City NVARCHAR(180) NOT NULL,
  ZIPCode VARCHAR(10) NOT NULL,
  Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenseNumber, FullName, [Address], City, ZIPCode)
VALUES ('435434', 'Stamat Stamatov Stamatov', 'ul."Stamat NO:8"', 'Kazanluk', '6100'),
		('132132', 'Pesho peshov peshev', 'ul."Pesho NO:15"', 'Sofia', '2000'),
		('987898', 'Mincho Minchev Minchov', 'ul."Mincho NO:3"', 'Blagoevgrad', '9000')

CREATE TABLE RentalOrders (
  ID INT PRIMARY KEY IDENTITY,
  EmployeeID INT FOREIGN KEY REFERENCES Employees(ID) NOT NULL,
  CustomerID INT FOREIGN KEY REFERENCES Customers(ID) NOT NULL,
  CarID INT FOREIGN KEY REFERENCES Cars(ID) NOT NULL,
  TankLevel FLOAT NOT NULL,
  KilometrageStart INT NOT NULL,
  KilometrageEnd INT NOT NULL,
  TotalKilometrage INT NOT NULL,
  StartDate DATE NOT NULL,
  EndDate DATE NOT NULL,
  TotalDays SMALLINT NOT NULL,
  RateApplied FLOAT NOT NULL,
  TaxRate FLOAT NOT NULL,
  OrderStatus NVARCHAR(50),
  Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeID, CustomerID, CarID, TankLevel, KilometrageStart, KilometrageEnd, 
TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
VALUES (2, 3, 2, 23.55, 200000, 200030, 30, '2019-08-08', '2019-08-12', 4, 65.30, 0.20, 'Completed'),
		(1, 2, 3, 54.30, 150000, 150080, 80, '2019-07-07', '2019-07-12',  5, 80.5, 0.20,'unfinished'),
		(3, 1, 1, 10.45, 180000, 180300, 300, '2019-08-12', '2019-08-22', 10, 106.54, 0.20, 'approved')


--Problem 15. Hotel Database
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees (
  ID INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL,
  Title NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES ('Boyan', 'Kolev', 'manager'),
		('Mariya', 'Nedyalkova', 'director'),
		('Petur', 'Stanev', 'cleaner')

CREATE TABLE Customers (
  AccountNumber INT PRIMARY KEY,
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL,
  PhoneNumber VARCHAR(30),
  EmergencyName NVARCHAR(50) NOT NULL,
  EmergencyNumber VARCHAR(30) NOT NULL,
  Notes NVARCHAR(MAX)
)

INSERT INTO Customers (AccountNumber, FirstName, LastName, EmergencyName, EmergencyNumber)
VALUES (244435, 'Pesho', 'Ivanov', 'PeshoEM', '3243432'),
		(12234, 'Simo', 'Petkov', 'SimoEM', '122122'),
		(23244, 'Ginko', 'Jordanov', 'GinkoEM', '876867')

CREATE TABLE RoomStatus (
  RoomStatus NVARCHAR(50) PRIMARY KEY,
  Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus)
VALUES ('free'),
		('busy'),
		('approved')

CREATE TABLE RoomTypes (
  RoomType NVARCHAR(50) PRIMARY KEY,
  Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType)
VALUES ('luxury'),
		('standard'),
		('family')

CREATE TABLE BedTypes (
  BedType NVARCHAR(50) PRIMARY KEY,
  Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType)
VALUES ('single'),
		('double'),
		('triple')

CREATE TABLE Rooms (
  RoomNumber SMALLINT PRIMARY KEY,
  RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
  BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
  Rate FLOAT NOT NULL,
  Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate)
VALUES (205, 'luxury', 'single', 80.50),
		(206, 'standard', 'double', 53.60),
		(208, 'family', 'triple', 49.55)

CREATE TABLE Payments (
  ID INT PRIMARY KEY IDENTITY,
  EmployeeID INT FOREIGN KEY REFERENCES Employees(ID) NOT NULL,
  PaymentDate DATE NOT NULL,
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
  FirstDateOccupied DATE NOT NULL,
  LastDateOccupied DATE NOT NULL,
  TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
  AmountCharged MONEY NOT NULL,
  TaxRate FLOAT NOT NULL,
  TaxAmount AS AmountCharged * TaxRate,
  PaymentTotal AS AmountCharged + AmountCharged * TaxRate,
  Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied,
AmountCharged, TaxRate)
VALUES (2, '2019-07-01', 244435, '2019-08-01', '2019-08-05', 350, 0.2),
		(3, '2019-02-03', 12234, '2019-05-01', '2019-05-10', 545, 0.1),
		(1, '2019-04-08', 23244, '2019-06-05', '2019-06-10', 120, 0.15)

CREATE TABLE Occupancies (
  ID INT PRIMARY KEY IDENTITY,
  EmployeeID INT FOREIGN KEY REFERENCES Employees(ID) NOT NULL,
  DateOccupied DATE NOT NULL,
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
  RoomNumber SMALLINT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
  RateApplied FLOAT NOT NULL,
  PhoneCharge MONEY NOT NULL,
  Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeID, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES (3, '2019-04-03', 244435, 206, 20, 13),
		(1, '2019-02-13', 12234, 205, 38, 8),
		(2, '2019-08-02', 23244, 208, 54, 16)


--Problem 16. Create SoftUni Database
CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns (
	ID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses (
	ID INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(30) NOT NULL,
	TownID INT CONSTRAINT FK_Adresses_Town FOREIGN KEY REFERENCES Towns(ID) NOT NULL
)


CREATE TABLE Departments (
	ID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Employees (
	ID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentID INT CONSTRAINT FK_Employees_Departments FOREIGN KEY REFERENCES Departments(ID) NOT NULL,
	HireDate DATE NOT NULL,
	Salary MONEY NOT NULL,
	AddressID INT CONSTRAINT FK_Employees_Addresses FOREIGN KEY REFERENCES Addresses(ID)
)

--Problem 18. Basic Insert
INSERT INTO Towns ([Name])
VALUES ('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')
		

INSERT INTO Departments ([Name])
VALUES ('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')


INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentID, HireDate, Salary)
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, CONVERT(datetime, '01/02/2013', 103), 3500.00),
		('Petur', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(datetime, '02/03/2004', 103), 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, CONVERT(datetime, '28/08/2016', 103), 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, CONVERT(datetime, '09/12/2007', 103), 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, CONVERT(datetime, '28/08/2016', 103), 599.88)


--Problem 19. Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees


--Problem 20. Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21. Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--Problem 22. Increase Employees Salary
UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

--Problem 23. Decrease Tax Rate
USE Hotel

UPDATE Payments
SET TaxRate /= 1.03

SELECT TaxRate FROM Payments

--Problem 24. Delete All Records
TRUNCATE TABLE Occupancies