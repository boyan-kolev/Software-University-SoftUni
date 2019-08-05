CREATE TABLE Clients (
  ID INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Accounttype (
  ID INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Accounts (
  ID INT PRIMARY KEY IDENTITY,
  AccountTypeID INT FOREIGN KEY REFERENCES AccountType(ID),
  Balance DECIMAL(15, 2) NOT NULL DEFAULT(0),
  ClientsID INT FOREIGN KEY REFERENCES Clients(ID)
)
GO

INSERT INTO Clients (FirstName, LastName) VALUES
('Boyan', 'Kolev'),
('Mariya', 'Petrova'),
('Kostadin', 'Binev'),
('Aleksandra', 'Peneva')
GO

INSERT INTO Accounttype (name) VALUES
('Checking'),
('Savings')
GO

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
GO

CREATE PROC p_AddAccount @ClientID INT, @AccountTypeID INT AS
INSERT INTO Accounts (ClientsID, AccountTypeID)
VALUES (@ClientID, @AccountTypeID)
GO

p_AddAccount 2, 2
GO

SELECT * FROM Accounts
GO

CREATE PROC p_Deposit @AccountID INT, @Amount DECIMAL(15, 2) AS
UPDATE Accounts
SET Balance += @Amount
WHERE ID = @AccountID
GO

CREATE PROC p_Withdraw @AccountID INT, @Amount DECIMAL(15, 2) AS
BEGIN
  DECLARE @OldBalance DECIMAL(15, 2)
  SELECT @OldBalance = Balance FROM Accounts WHERE ID = @AccountID
  IF (@OldBalance - @Amount >= 0)
  BEGIN
    UPDATE Accounts
	SET Balance -= @Amount
	WHERE ID = @AccountID
  END
  ELSE
  BEGIN
    RAISERROR ('Insufficient funds', 10, 1)
  END
END
GO

CREATE TABLE Transaktions (
ID INT PRIMARY KEY IDENTITY,
AccountID INT FOREIGN KEY REFERENCES Accounts(ID),
OldBalance DECIMAL(15, 2) NOT NULL,
NewBalance DECIMAL(15, 2) NOT NULL,
Amount AS NewBalance - OldBalance,
[DateTime] DATETIME2
)
GO

CREATE TRIGGER tr_Transaktion ON Accounts
AFTER UPDATE
AS
  INSERT INTO Transaktions (AccountID, OldBalance, NewBalance, [DateTime])
  SELECT inserted.ID, deleted.Balance, inserted.Balance, GETDATE() FROM inserted
  JOIN deleted ON inserted.ID = deleted.ID
GO

p_Deposit 1, 25.00
GO

p_Deposit 1, 40.00
GO

p_Withdraw 2, 200.00
GO

p_Deposit 4, 180.00
GO

SELECT * FROM Transaktions
GO
