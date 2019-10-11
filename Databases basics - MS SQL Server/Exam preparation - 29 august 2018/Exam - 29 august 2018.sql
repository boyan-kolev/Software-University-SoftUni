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
