--Section 1. DDL (30 pts)
CREATE DATABASE Airport

USE Airport

CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)


CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)


CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15, 2) NOT NULL
)

--Section 2. DML (10 pts)
--2. Insert
INSERT INTO Planes ([Name], Seats, [Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes ([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3. Update
UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Carlsbad')

--4. Delete
DELETE FROM Tickets
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--Section 3. Querying (40 pts)
--5. The "Tr" Planes
SELECT Id, 
		[Name], 
		Seats, 
		[Range]
FROM Planes
WHERE [Name] LIKE '%' + 'tr' + '%'
ORDER BY Id, [Name], Seats, [Range]

--6. Flight Profits
SELECT t.FlightId,
	SUM(t.Price) AS [Price]
FROM Flights AS f
JOIN Tickets AS t
ON t.FlightId = f.Id
GROUP BY t.FlightId
ORDER BY Price DESC, t.FlightId

--7. Passenger Trips
SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
		f.Origin,
		f.Destination
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId = p.Id
JOIN Flights AS f
ON f.Id = t.FlightId
ORDER BY [Full Name], f.Origin, f.Destination

--8. Non Adventures People
SELECT p.FirstName AS [First Name],
		p.LastName AS [Last Name],
		p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t
ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC, p.FirstName, p.LastName

--9. Full Info
SELECT CONCAT(pa.FirstName, ' ', pa.LastName) AS [Full Name],
		pl.[Name] AS [Plane Name],
		CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
		lt.[Type] AS [Luggage Type]
FROM Planes AS pl
JOIN Flights AS f
ON f.PlaneId = pl.Id
JOIN Tickets AS t
ON t.FlightId = f.Id
JOIN Passengers AS pa
ON pa.Id = t.PassengerId
JOIN Luggages AS l
ON l.Id = t.LuggageId
JOIN LuggageTypes AS lt
ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, lt.[Type]


--10. PSP
SELECT p.[Name],
		p.Seats,
		COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f
ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t
ON t.FlightId = f.Id
GROUP BY p.Id, p.[Name], p.Seats
ORDER BY [Passengers Count] DESC, p.[Name], p.Seats
GO

--Section 4. Programmability (20 pts)
--11. Vacation
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(100)
BEGIN
	DECLARE @result VARCHAR(200)
	DECLARE @flightID INT = (SELECT TOP(1) Id FROM Flights WHERE Origin = @origin AND Destination = @destination)

	IF(@peopleCount <= 0)
	BEGIN
		SET @result = 'Invalid people count!'
	END
	ELSE IF(@flightID IS NULL)
	BEGIN
		SET @result = 'Invalid flight!'
	END
	ELSE
	BEGIN
		DECLARE @pricePerTicket DECIMAL(15, 2) = (SELECT TOP(1) Price FROM Tickets WHERE FlightId = @flightID)
		DECLARE @totalPrice DECIMAL(15, 2) = @peopleCount * @pricePerTicket
		SET @result = 'Total price ' + CAST(@totalPrice AS VARCHAR(20))
	END

	RETURN @result
END
GO

--12. Wrong Data
CREATE PROC usp_CancelFlights
AS
UPDATE Flights
SET ArrivalTime = NULL, DepartureTime = NULL
WHERE CAST(DepartureTime AS datetime2) < CAST(ArrivalTime AS datetime2)
GO
