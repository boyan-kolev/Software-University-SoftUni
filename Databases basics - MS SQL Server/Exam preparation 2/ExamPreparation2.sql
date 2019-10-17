CREATE DATABASE School

USE School

CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30),
	LastName NVARCHAR(30) NOT NULL,
	Age TINYINT CHECK(Age > 0),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(15, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME2,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(15, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL

	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL

	PRIMARY KEY(StudentId, TeacherId)
)

--Section 2. DML (10 pts)
--2. Insert
INSERT INTO Teachers (FirstName, LastName, [Address], Phone, SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects ([Name], Lessons) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)


--3. Update
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE (SubjectId IN (1, 2)) AND Grade >= 5.50

--4. Delete
DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%' + '72' + '%')

DELETE FROM Teachers
WHERE Phone LIKE '%' + '72' + '%'

--Section 3. Querying (40 pts)
--5. Teen Students
SELECT FirstName,
		LastName,
		Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--6. Students Teachers
SELECT s.FirstName,
		s.LastName,
		COUNT(st.StudentId) AS [TeachersCount]
FROM Students AS s
LEFT JOIN StudentsTeachers AS st
ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

--7. Students to Go
SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS sm
ON sm.StudentId = s.Id
WHERE sm.StudentId IS NULL
ORDER BY [Full Name]

--8. Top Students
SELECT TOP(10) s.FirstName AS [First Name],
		s.LastName AS [Last Name],
		FORMAT(AVG(sm.Grade), 'N2') AS [Grade]
FROM Students AS s
JOIN StudentsExams AS sm
ON sm.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, S.FirstName, S.LastName

--9. Not So In The Studying
SELECT (s.FirstName + ISNULL(' ' + s.MiddleName, '') + ' ' + s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss
ON ss.StudentId = s.Id
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

--10. Average Grade per Subject
SELECT s.[Name],
		AVG(ss.Grade) AS [AverageGrade]
FROM Subjects AS s
JOIN StudentsSubjects AS ss
ON ss.SubjectId = s.Id
GROUP BY s.Id, s.[Name]
ORDER BY s.Id
GO

--Section 4. Programmability (20 pts)
--11. Exam Grades
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
RETURNS VARCHAR(100)
BEGIN
	DECLARE @student INT = (SELECT Id FROM Students WHERE Id = @studentId)

	IF(@student IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	IF(@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @countOfGrades INT = (SELECT COUNT(*) FROM StudentsSubjects WHERE StudentId = @studentId AND Grade BETWEEN (@grade + 0.01) AND (@grade + 0.50))
	DECLARE @firstNameOfStudent VARCHAR(20) = (SELECT FirstName FROM Students WHERE Id = @studentId)
	RETURN 'You have to update ' +  CAST(@countOfGrades AS VARCHAR(20)) + ' grades for the student ' + @firstNameOfStudent
END
GO

--12. Exclude from school
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN TRANSACTION
DECLARE @student INT = (SELECT TOP(1) Id FROM Students WHERE Id = @StudentId)

IF(@student IS NULL)
BEGIN
	RAISERROR('This school has no student with the provided id!', 16, 1)
	ROLLBACK
	RETURN
END

DELETE FROM StudentsTeachers WHERE StudentId = @StudentId
DELETE FROM StudentsSubjects WHERE StudentId = @StudentId
DELETE FROM StudentsExams WHERE StudentId = @StudentId
DELETE FROM Students WHERE Id = @StudentId

COMMIT
GO