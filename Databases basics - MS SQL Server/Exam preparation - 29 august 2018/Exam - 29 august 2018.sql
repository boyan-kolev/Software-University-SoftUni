--Section 1. DDL (30 pts)
CREATE DATABASE Supermarket
USE Supermarket

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(15, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
	Salary DECIMAL(15, 2) NOT NULL,
)

CREATE TABLE Orders(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems(
	OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
	Quantity INT CHECK (Quantity >= 1) NOT NULL

	PRIMARY KEY(OrderId, ItemId)
)

CREATE TABLE Shifts(
	Id INT IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL

	PRIMARY KEY(Id, EmployeeId)
)

ALTER TABLE Shifts
ADD CONSTRAINT ch_CheckInCheckOut CHECK(CheckIn < CheckOut)

--Section 2. DML (10 pts)
--2. Insert
INSERT INTO Employees (FirstName, LastName, Phone, Salary) VALUES
('Stoyan', 'Petrov', '888-785-8573', '500.25'),
('Stamat', 'Nikolov', '789-613-1122', '999995.25'),
('Evgeni', 'Petkov', '645-369-9517', '1234.51'),
('Krasimir', 'Vidolov', '321-471-9982', '50.25')

INSERT INTO Items ([Name], Price, CategoryId) VALUES
('Tesla battery', '154.25', '8'),
('Chess', '30.25', '8'),
('Juice', '5.32', '1'),
('Glasses', '10', '8'),
('Bottle of water', '1', '1')

--3. Update
UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN (1, 2 ,3)

--4. Delete
DELETE FROM OrderItems
WHERE OrderId = 48

--Section 3. Querying (40 pts)
--5. Richest People
SELECT Id, FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id

--6. Cool Phone Numbers
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name],
		Phone AS [Phone Number]
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

--7. Employee Statistics
SELECT t.FirstName, t.LastName, t.Count	
FROM (SELECT e.Id,
			e.FirstName,
			e.LastName,
			COUNT(o.Id) AS [Count]
	 FROM Employees AS e
	 JOIN Orders AS o
	 ON o.EmployeeId = e.Id
	 GROUP BY e.Id, e.FirstName, e.LastName) AS t
ORDER BY t.[Count] DESC, t.FirstName

--8. Hard Workers Club
SELECT e.FirstName,
		e.LastName,
		AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours]
FROM Employees AS e
JOIN Shifts AS s
ON s.EmployeeId = e.Id
GROUP BY e.Id, e.FirstName, e.LastName
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work hours] DESC, e.Id


--9. The Most Expensive Order
SELECT TOP(1) oi.OrderId,
	SUM(i.Price * oi.Quantity) AS [TotalPrice]
FROM Items AS i
JOIN OrderItems AS oi
ON OI.ItemId = I.Id
GROUP BY oi.OrderId
ORDER BY TotalPrice DESC

--10. Rich Item, Poor Item
SELECT TOP(10) oi.OrderId,
	MAX(i.Price) AS [ExpensivePrice], 
	MIN(i.Price) AS [CheapPrice]
FROM Items AS i
JOIN OrderItems AS oi
ON OI.ItemId = I.Id
GROUP BY oi.OrderId
ORDER BY ExpensivePrice DESC, oi.OrderId

--11. Cashiers
SELECT DISTINCT e.Id,
		e.FirstName,
		e.LastName
FROM Employees AS e
JOIN Orders AS o
ON o.EmployeeId = e.Id
ORDER BY e.Id

--12. Lazy Employees
SELECT DISTINCT e.Id,
		(e.FirstName + ' ' + e.LastName) AS [Full Name]
FROM Employees AS e
JOIN Shifts AS s
ON s.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id

--13. Sellers
SELECT (e.FirstName + ' ' + e.LastName) AS [Full Name],
		SUM(i.Price * oi.Quantity) AS [Total Price],
		SUM(oi.Quantity) AS [Items]
FROM Employees AS e
JOIN Orders AS o
ON o.EmployeeId = e.Id
JOIN OrderItems AS oi
ON oi.OrderId = o.Id
JOIN Items AS i
ON i.Id = oi.ItemId
WHERE O.[DateTime] < '2018-06-15'
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, Items DESC

--14. Tough days
SELECT (e.FirstName + ' ' + e.LastName) AS [Full Name],  
		DATENAME(dw, s.CheckIn) AS [Day of week]
FROM Employees AS e
JOIN Shifts AS s
ON s.EmployeeId = e.Id
LEFT JOIN Orders AS o
ON o.EmployeeId = e.Id
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

--15. Top Order per Employee
SELECT t.[Full Name],
		DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS [WorkHours],
		t.TotalPrice
FROM (SELECT (e.FirstName + ' ' + e.LastName) AS [Full Name],
	 		e.Id AS EmployeeId,
			o.[DateTime],
	 		SUM(i.Price * oi.Quantity) AS [TotalPrice],
	 		ROW_NUMBER() OVER(PARTITION BY e.id ORDER BY SUM(i.Price * oi.Quantity) DESC) AS [RowNumber]
	 FROM Employees AS e
	 JOIN Orders AS o
	 ON o.EmployeeId = e.Id
	 JOIN OrderItems AS oi
	 ON oi.OrderId = o.Id
	 JOIN Items AS i
	 ON i.Id = oi.ItemId
	 GROUP BY o.Id, e.FirstName, e.LastName, e.Id, o.[DateTime]) AS t
JOIN Shifts AS s
ON s.EmployeeId = t.EmployeeId
WHERE t.RowNumber = 1 AND t.[DateTime] BETWEEN s.CheckIn AND s.CheckOut
ORDER BY [Full Name], WorkHours DESC, TotalPrice DESC


--16. Average Profit per Day
SELECT t.[Day],
		CAST((t.TotalSum / t.CountOfOrders) AS DECIMAL(15, 2)) AS [Total profit]
FROM (SELECT SUM(i.Price * oi.Quantity) AS [TotalSum],
			COUNT(o.Id) AS [CountOfOrders],
			DATEPART(DAY, o.[DateTime]) AS [Day]
	 FROM OrderItems AS oi
	 JOIN Orders AS o
	 ON o.Id = oi.OrderId
	 JOIN Items AS i
	 ON i.Id = oi.ItemId
	 GROUP BY DATEPART(DAY, o.[DateTime])) AS t
ORDER BY [Day]

--17. Top Products
SELECT i.[Name] AS [Item],
	c.[Name] AS [Category],
	SUM(oi.Quantity) AS [Count],
	SUM(i.Price * oi.Quantity) AS [TotalPrice]
FROM OrderItems AS oi
RIGHT JOIN Items AS i
RIGHT JOIN Categories AS c
ON c.Id = i.CategoryId
ON i.Id = oi.ItemId
GROUP BY i.Id, i.[Name], c.[Name]
ORDER BY TotalPrice DESC, Count DESC
GO

--Section 4. Programmability (20 pts)
--18. Promotion days
CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATE, @StartDate DATE, @EndDate DATE, @Discount DECIMAL(15, 2), @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(MAX)
BEGIN
	DECLARE @firstItem INT = (SELECT Id FROM Items WHERE Id = @FirstItemId)
	DECLARE @secondItem INT = (SELECT Id FROM Items WHERE Id = @SecondItemId)
	DECLARE @thirdItem INT = (SELECT Id FROM Items WHERE Id = @ThirdItemId)
	DECLARE @result VARCHAR(MAX)

	IF(@firstItem IS NOT NULL AND @secondItem IS NOT NULL AND @thirdItem IS NOT NULL)
	BEGIN
		DECLARE @firstItemName VARCHAR(100) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
		DECLARE @secondItemName VARCHAR(100) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
		DECLARE @thirdItemName VARCHAR(100) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

		IF(@CurrentDate BETWEEN @StartDate AND @EndDate)
		BEGIN
			DECLARE @priceOfItem1 DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
			DECLARE @priceOfItem2 DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
			DECLARE @priceOfItem3 DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

			DECLARE @priceDiscount1 DECIMAL(15, 2) = (@priceOfItem1 - (@priceOfItem1 * (@Discount / 100)))
			DECLARE @priceDiscount2 DECIMAL(15, 2) = (@priceOfItem2 - (@priceOfItem2 * (@Discount / 100)))
			DECLARE @priceDiscount3 DECIMAL(15, 2) = (@priceOfItem3 - (@priceOfItem3 * (@Discount / 100)))
					

			SET @result = @firstItemName + ' price: ' + CAST(@priceDiscount1 AS VARCHAR(50)) + ' <-> ' + @secondItemName + ' price: ' + CAST(@priceDiscount2 AS VARCHAR(50)) + ' <-> ' + @thirdItemName + ' price: ' + CAST(@priceDiscount3 AS VARCHAR(50))
		END
		ELSE
		BEGIN
			SET @result = 'The current date is not within the promotion dates!'
		END
	END
	ELSE
	BEGIN
		SET @result = 'One of the items does not exists!'
	END

	RETURN @result
END
GO

--19. Cancel order
CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATE)
AS
BEGIN TRANSACTION
DECLARE @order INT = (SELECT TOP(1) Id FROM Orders WHERE Id = @OrderId)

IF(@order IS NULL)
BEGIN
	RAISERROR('The order does not exist!', 16, 1)
	ROLLBACK
	RETURN
END

DECLARE @orderDate DATE = (SELECT TOP(1) [DateTime] FROM Orders WHERE Id = @OrderId)

IF(DATEDIFF(DAY, @orderDate, @CancelDate) > 3)
BEGIN
	RAISERROR('You cannot cancel the order!', 16, 2)
	ROLLBACK
	RETURN
END

DELETE FROM OrderItems
WHERE OrderId = @OrderId

DELETE FROM Orders
WHERE Id = @OrderId

COMMIT

--20. Deleted Order
CREATE TABLE DeletedOrders(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
)
GO

CREATE TRIGGER tr_DeletedOrders ON OrderItems FOR DELETE
AS

INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
	SELECT OrderId, ItemId, Quantity FROM deleted


