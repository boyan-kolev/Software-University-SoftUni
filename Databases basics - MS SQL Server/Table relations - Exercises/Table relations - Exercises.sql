--Problem 1. One-To-One Relationship
CREATE DATABASE TableRelationsExercises

USE TableRelationsExercises

CREATE TABLE Persons (
	PersonID INT NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	Salary MONEY NOT NULL,
	PassportID INT NOT NULL
)

CREATE TABLE Passports (
	PassportID INT NOT NULL,
	PassportNumber CHAR(8) NOT NULL
)

ALTER TABLE Persons
ADD CONSTRAINT PK_Person PRIMARY KEY(PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_Passport PRIMARY KEY(PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)

ALTER TABLE Persons
ADD CONSTRAINT UQ_Persons UNIQUE(PassportID)

ALTER TABLE Passports
ADD CONSTRAINT UQ_Passports UNIQUE(PassportNumber) 

INSERT INTO Passports (PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
		(102, 'K65LO4R7'),
		(103, 'ZE657QP2')

INSERT INTO Persons (PersonID, FirstName, Salary, PassportID)
VALUES (1, 'Roberto', 43300.00, 102),
		(2, 'Tom', 56100.00, 103),
		(3, 'Yana', 60200.00, 101)

--Problem 2. One-To-Many Relationship
CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models (
	ModelID INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	ManufacturerID INT,
	CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers (ManufacturerID, [Name], EstablishedOn)
VALUES (1, 'BMW', '07/03/1916'),
		(2, 'Tesla', '01/01/2003'),
		(3, 'Lada', '01/05/1966')

INSERT INTO Models (ModelID, [Name], ManufacturerID)
VALUES (101, 'X1', 1),
		(102, 'i6', 1),
		(103, 'Model S', 2),
		(104, 'Model X', 2),
		(105, 'Model 3', 2),
		(106, 'Nova', 3)

--Problem 3. Many-To-Many Relationship
CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(30) NOT NULL
)


CREATE TABLE StudentsExams (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students
VALUES ('Mila'),
		('Toni'),
		('Ron')

INSERT INTO Exams
VALUES ('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')

INSERT INTO StudentsExams
VALUES (1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)

--Problem 4. Self-Referencing
CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES ('John', NULL),
		('Maya', 106),
		('Silvia', 106),
		('Ted', 105),
		('Mark', 101),
		('Greta', 101)

--Problem 9. *Peaks in Rila
USE Geography

SELECT M.MountainRange, P.PeakName, P.Elevation FROM Mountains AS m
JOIN Peaks AS p
ON M.Id = P.MountainId
WHERE M.MountainRange = 'Rila'
ORDER BY P.Elevation DESC