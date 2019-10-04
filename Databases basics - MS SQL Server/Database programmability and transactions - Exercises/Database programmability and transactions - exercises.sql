--Section I. Functions and Procedures
--Part 1. Queries for SoftUni Database
--Problem 1. Employees with Salary Above 35000
USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
GO

--Problem 2. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18, 4))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Number
GO

--Problem 3. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@InputString VARCHAR(20))
AS
SELECT [Name]
FROM Towns
WHERE [Name] LIKE @InputString + '%'
GO

--Problem 4. Employees from Town
CREATE PROC usp_GetEmployeesFromTown @TownName VARCHAR(30)
AS
SELECT e.FirstName, e.LastName
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
JOIN Towns AS t
ON t.TownID = a.TownID
WHERE t.[Name] = @TownName
GO

--Problem 5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(15)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(15)
	IF(@Salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF(@Salary <= 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END
	RETURN @salaryLevel
END
GO

