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

--Problem 6. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel @LevelOfSalary VARCHAR(15)
AS
SELECT FirstName AS [First Name],
		LastName AS [Last Name]
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary
GO

--Problem 7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
	DECLARE @count INT = 1
	WHILE(@count <= LEN(@word))
	BEGIN
		DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @count, 1)
		DECLARE @charIdex INT = CHARINDEX(@currentLetter, @setOfLetters)

		IF(@charIdex = 0)
		BEGIN
			RETURN 0
		END
		SET @count += 1
	END
	RETURN 1
END
GO

--Problem 8. * Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT

UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

DELETE FROM Employees
WHERE DepartmentID = @departmentId

DELETE FROM Departments
WHERE DepartmentID = @departmentId

SELECT COUNT(*)
FROM Employees
WHERE DepartmentID = @departmentId
GO

--Part 2. Queries for Bank Database
--Problem 9. Find Full Name
USE Bank
GO

CREATE PROCEDURE usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName, ' ', LastName)
FROM AccountHolders
GO

--Problem 10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@InputMoney MONEY)
AS
SELECT t.FirstName AS [First Name],
		t.LastName AS [Last Name]
FROM (SELECT ah.Id, 
	 		ah.FirstName,
	 		ah.LastName,
	 		SUM(a.Balance) AS TotalBalance
	 FROM AccountHolders AS ah
	 JOIN Accounts AS a
	 ON a.AccountHolderId = ah.Id
	 GROUP BY ah.Id, ah.FirstName, ah.LastName
	 HAVING SUM(a.Balance) > @InputMoney) AS t
ORDER BY t.FirstName, t.LastName
GO

--Problem 11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@InitialSum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(18, 4)
BEGIN
	DECLARE @futureValue DECIMAL(18, 4)
	SET @futureValue = @InitialSum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
	RETURN @futureValue
END
GO

--Problem 12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@AccountID INT, @InterestRate FLOAT)
AS
SELECT t.Id AS [Account id],
		t.FirstName AS [First Name],
		t.LastName AS [Last Name],
		t.TotalBalance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(t.TotalBalance, @InterestRate, 5) AS [Balance in 5 years]
FROM (SELECT a.Id,
	 		FirstName,
	 		ah.LastName,
	 		SUM(a.Balance) AS TotalBalance
	 FROM AccountHolders AS ah
	 JOIN Accounts AS a
	 ON a.AccountHolderId = ah.Id
	 WHERE a.Id = @AccountID
	 GROUP BY a.Id, FirstName, ah.LastName) AS t
GO

--Part 3. Queries for Diablo Database
--Problem 13. *Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN
	SELECT SUM(t.Cash) AS SumCash
	FROM (SELECT ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS RowNumber,
		  ug.Cash
		 FROM Games AS g
		 JOIN UsersGames AS ug
		 ON ug.GameId = g.Id
		 WHERE G.[Name] = @GameName) AS t
	WHERE t.RowNumber % 2 <> 0
GO