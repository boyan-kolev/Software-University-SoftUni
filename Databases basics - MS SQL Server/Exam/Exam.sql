CREATE DATABASE [Service]

USE [Service]

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT	CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT	CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)


--Section 2. DML (10 pts)
--2. Insert
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId) VALUES
(1, 1, '2017-04-13', NULL,'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL ,'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--3. Update
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4. Delete
DELETE FROM Reports
WHERE StatusId = 4

--Section 3. Querying (40 pts)
--5. Unassigned Reports
SELECT [Description],
		CONVERT(VARCHAR(20), OpenDate, 105) AS [OpenDate]
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY CONVERT(datetime2, OpenDate, 105), [Description]

--6. Reports & Categories
SELECT r.[Description],
		c.[Name] AS [CategoryName]
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
ORDER BY r.[Description], c.[Name]

--7. Most Reported Category
SELECT TOP(5) c.[Name] AS [CategoryName],
		COUNT(c.Id) AS [ReportsNumber]
FROM Categories AS c
JOIN Reports AS r
ON r.CategoryId = c.Id
GROUP BY c.Id, c.[Name]
ORDER BY ReportsNumber DESC, CategoryName

--8. Birthday Report
SELECT u.Username,
		c.[Name] AS [CategoryName]
FROM Users AS u
JOIN Reports AS r
ON r.UserId = u.Id
JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE DAY(r.OpenDate) = DAY(u.Birthdate) AND MONTH(r.OpenDate) = MONTH(u.Birthdate)
ORDER BY u.Username, CategoryName


--9. Users per Employee
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [FullName],
		COUNT(u.Id) AS [UserCount]
FROM Users AS u
JOIN Reports AS r
ON r.UserId = u.Id
RIGHT JOIN Employees AS e
ON e.Id = r.EmployeeId
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY UserCount DESC, FullName

--10. Full Info
SELECT ISNULL((e.FirstName + ' ' + e.LastName), 'None') AS [Employee],
		ISNULL(d.[Name], 'None') AS [Department],
		ISNULL(c.[Name], 'None') AS [Category],
		ISNULL(r.[Description], 'None') AS [Description],
		ISNULL(convert(VARCHAR(20), r.OpenDate, 104), 'None') AS [OpenDate],
		ISNULL(s.[Label], 'None') AS [Status],
		ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
LEFT JOIN Users AS u
ON u.Id = r.UserId
LEFT JOIN Categories AS c
ON c.Id = r.CategoryId
LEFT JOIN [Status] AS s
ON s.Id = r.StatusId
LEFT JOIN Employees AS e
ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d
ON d.Id = e.DepartmentId
ORDER BY e.FirstName DESC, 
		LastName DESC, 
		Department, 
		Category, 
		[Description], 
		convert(DATE, r.OpenDate, 104), 
		[Status], [User]
GO

--Section 4. Programmability (20 pts)
--11. Hours to Complete
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END
GO

--12. Assign Employee
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
DECLARE @employeeDep INT = (SELECT TOP(1) DepartmentId FROM Employees WHERE Id = @EmployeeId)
DECLARE @reportDep INT = (SELECT DepartmentId FROM Categories WHERE Id = (SELECT CategoryId FROM Reports WHERE Id = @ReportId))

IF(@employeeDep <> @reportDep)
BEGIN
	RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
	RETURN
END

UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId
