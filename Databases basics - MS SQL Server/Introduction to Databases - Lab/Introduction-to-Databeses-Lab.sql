CREATE TABLE Clients (
  ID INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL
)

CREATE TABLE Accounttype (
  ID INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(50) NOT NULL
)


CREATE TABLE Accounts (
  ID INT PRIMARY KEY IDENTITY,
  AccountTypeID INT FOREIGN KEY REFERENCES AccountType(ID),
  Balance DECIMAL(15, 2) NOT NULL DEFAULT(0),
  ClientsID INT FOREIGN KEY REFERENCES Clients(ID)
)


INSERT INTO Clients (FirstName, LastName) VALUES
('Boyan', 'Kolev'),
('Mariya', 'Petrova'),
('Kostadin', 'Binev'),
('Aleksandra', 'Peneva')

INSERT INTO Accounttype (name) VALUES
('Checking'),
('Savings')


INSERT INTO Accounts (ClientsID, AccountTypeID, Balance) VALUES
(1, 1, 175),
(2, 1, 275.56),
(3, 1, 138.01),
(4, 1, 40.30),
(4, 2, 375.50)


GO
CREATE FUNCTION f_CalculateTotalBalance (@ClientID INT)
RETURNS DECIMAL(15, 2)
BEGIN
  DECLARE @result AS DECIMAL(15, 2) =  (
  SELECT SUM(Balance)
  FROM Accounts WHERE ClientsID = @ClientID
  )
  RETURN @result
END
GO

SELECT dbo.f_CalculateTotalBalance(3) AS Balance