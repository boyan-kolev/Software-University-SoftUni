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

--Section II. Triggers and Transactions
--Part 1. Queries for Bank Database
--Problem 14. Create Table Logs
CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum DECIMAL(15, 2) NOT NULL,
	NewSum DECIMAL(15, 2) NOT NULL
)
GO

CREATE TRIGGER tr_InsertIntoAccount ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted)
	DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
	DECLARE @accountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs (AccountId, OldSum, NewSum)
	VALUES (@accountId, @oldSum, @newSum)
END
GO

--Problem 15. Create Table Emails
CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	[Subject] VARCHAR(50) NOT NULL,
	Body VARCHAR(100) NOT NULL
)
GO

CREATE TRIGGER tr_InsertToLogs ON Logs FOR INSERT
AS
BEGIN
	DECLARE @dateNow VARCHAR(30) = convert(varchar(30), getdate(), 100)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT OldSum FROM inserted)
	DECLARE @newSum DECIMAL(15, 2) = (SELECT NewSum FROM inserted)
	DECLARE @recipient INT = (SELECT AccountId FROM inserted)
	DECLARE @subjects VARCHAR(50) = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(50))
	DECLARE @body VARCHAR(100) = 'On ' + @dateNow + ' your balance was changed from ' + CAST(@oldSum AS varchar(20)) +' to '+ CAST(@newSum AS varchar(20)) + ' .'

	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	VALUES (@recipient, @subjects, @body)
END
GO

--Problem 16. Deposit Money
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
	DECLARE @currAccountId INT = (SELECT TOP(1) Id FROM Accounts WHERE Id = @AccountId)

	IF(@currAccountId IS NULL)
	BEGIN
		RAISERROR('The account does not exist', 16, 1)
		ROLLBACK
		RETURN
	END

	IF(@MoneyAmount < 0)
	BEGIN
		RAISERROR('The amount can not be negative!', 16, 2)
		ROLLBACK
		RETURN
	END

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId

COMMIT
GO

--Problem 17. Withdraw Money
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
	DECLARE @currAccountId INT = (SELECT TOP(1) Id FROM Accounts WHERE Id = @AccountId)

	IF(@currAccountId IS NULL)
	BEGIN
		RAISERROR('The account does not exist', 16, 1)
		ROLLBACK
		RETURN
	END

	IF(@MoneyAmount < 0)
	BEGIN
		RAISERROR('The amount can not be negative!', 16, 2)
		ROLLBACK
		RETURN
	END

	DECLARE @currBalance DECIMAL(18, 4) = (SELECT TOP(1) Balance FROM Accounts WHERE Id = @AccountId)

	IF((@currBalance - @MoneyAmount) < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient avaible money!', 16, 3)
		RETURN
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

COMMIT
GO

--Problem 18. Money Transfer
CREATE PROCEDURE usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
DECLARE @currSenderId INT = (SELECT TOP(1) Id FROM Accounts WHERE Id = @SenderId)
DECLARE @currReceiverId INT = (SELECT TOP(1) Id FROM Accounts WHERE Id = @SenderId)

IF(@currSenderId IS NULL OR @currReceiverId IS NULL)
BEGIN
	RAISERROR('Invalid account!', 16, 1)
	ROLLBACK
	RETURN
END

EXEC usp_WithdrawMoney @senderId, @Amount
EXEC usp_DepositMoney @ReceiverId, @Amount
COMMIT
GO

--Part 2. Queries for Diablo Database
--Problem 19. Trigger
USE Diablo
GO

CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @userGameID INT = (SELECT TOP(1) UserGameId FROM inserted)
DECLARE @itemID INT = (SELECT TOP(1) ItemId FROM inserted)

DECLARE @userGameLevel INT = (SELECT TOP(1) [Level] FROM UsersGames WHERE Id = @userGameID)
DECLARE @itemLevel INT = (SELECT TOP(1) MinLevel FROM Items WHERE Id = @itemID)

IF(@userGameLevel >= @itemLevel)
BEGIN
	INSERT INTO UserGameItems(UserGameId, ItemId)
	VALUES (@userGameID, @itemID)
END
GO

UPDATE UsersGames
SET Cash += 50000
WHERE GameId = (SELECT Id FROM Games WHERE [Name] = 'Bali') 
AND UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))
GO

CREATE PROC usp_BuyItem (@UserID INT, @ItemID INT, @GameID INT)
AS
BEGIN TRANSACTION
DECLARE @user INT = (SELECT TOP(1) Id FROM Users WHERE Id = @UserID)
DECLARE @item INT = (SELECT TOP(1) Id FROM Items WHERE Id = @ItemID)

IF(@user IS NULL OR @item IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid user or item!', 16, 1)
	return
END

DECLARE @cash DECIMAL(15, 2) = (SELECT TOP(1) Cash FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)
DECLARE @priceOfItem DECIMAL(15, 2) = (SELECT TOP(1) Price FROM Items WHERE Id = @ItemID)

IF(@cash - @priceOfItem < 0)
BEGIN
	ROLLBACK
	RAISERROR('Insufficient funds', 16, 2)
	RETURN
END

UPDATE UsersGames
SET Cash -= @priceOfItem
WHERE UserId = @UserID AND GameId = @GameID

DECLARE @userGameID INT = (SELECT TOP(1) Id FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)

INSERT INTO UserGameItems(UserGameId, ItemId)
VALUES (@userGameID, @ItemID)

COMMIT
GO

DECLARE @counterItemsID INT = 251
DECLARE @gameID INT = (SELECT TOP(1) Id FROM Games WHERE [Name] = 'Bali')

WHILE(@counterItemsID < 299)
BEGIN
	EXEC usp_BuyItem 61, @counterItemsID, @gameID
	EXEC usp_BuyItem 52, @counterItemsID, @gameID
	EXEC usp_BuyItem 37, @counterItemsID, @gameID
	EXEC usp_BuyItem 22, @counterItemsID, @gameID
	EXEC usp_BuyItem 12, @counterItemsID, @gameID
	SET @counterItemsID += 1
END
GO

DECLARE @counterItemsID INT = 501
DECLARE @gameID INT = (SELECT TOP(1) Id FROM Games WHERE [Name] = 'Bali')

WHILE(@counterItemsID < 539)
BEGIN
	EXEC usp_BuyItem 61, @counterItemsID, @gameID
	EXEC usp_BuyItem 52, @counterItemsID, @gameID
	EXEC usp_BuyItem 37, @counterItemsID, @gameID
	EXEC usp_BuyItem 22, @counterItemsID, @gameID
	EXEC usp_BuyItem 12, @counterItemsID, @gameID
	SET @counterItemsID += 1
END
GO

SELECT u.Username,
		g.[Name],
		ug.Cash,
		i.[Name]
FROM Users AS u
JOIN UsersGames AS ug
ON ug.UserId = u.Id
JOIN Games AS g
ON g.Id = ug.GameId
JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE g.[Name] = 'Bali'
ORDER BY u.Username, i.[Name]
GO

--Problem 20. *Massive Shopping
DECLARE @userGameID INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)
DECLARE @stamatCash DECIMAL(15, 2) = (SELECT Cash FROM UsersGames WHERE Id = @userGameID)
DECLARE @totalPriceOfItems DECIMAL(15, 2) = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF(@stamatCash >= @totalPriceOfItems)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		SET Cash -= @totalPriceOfItems
		WHERE Id = @userGameID

		INSERT INTO UserGameItems (ItemId, UserGameId)
		SELECT Id, @userGameID FROM Items WHERE MinLevel BETWEEN 11 AND 12
	COMMIT
END

SET @stamatCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameID)
SET @totalPriceOfItems = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF(@stamatCash >= @totalPriceOfItems)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		SET Cash -= @totalPriceOfItems
		WHERE Id = @userGameID

		INSERT INTO UserGameItems (ItemId, UserGameId)
		SELECT Id, @userGameID FROM Items WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END

SELECT i.[Name]
FROM UsersGames AS ug
JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE ug.UserId = 9 AND ug.GameId = 87
ORDER BY i.[Name]

--Part 3. Queries for SoftUni Database
--Problem 21. Employees with Three Projects
USE SoftUni
GO

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
DECLARE @countOfProjects INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

IF(@countOfProjects >= 3)
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 1)
	RETURN
END

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (@emloyeeId, @projectID)

COMMIT
GO


--Problem 22. Delete Employees
CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentID) NOT NULL,
	Salary Money NOT NULL
)
GO

CREATE TRIGGER tr_InsertToDeleted_Employees ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted