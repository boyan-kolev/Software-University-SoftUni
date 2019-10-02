--Problem 1. Employee Address
USE SoftUni

SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY A.AddressID 

--Problem 2. Addresses with Towns
SELECT TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--Problem 3. Sales Employee
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--Problem 4. Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

--Problem 5. Employees Without Project
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
WHERE EP.EmployeeID IS NULL
ORDER BY E.EmployeeID

--Problem 6. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

--Problem 7. Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON E.EmployeeID = EP.EmployeeID
JOIN Projects AS p
ON EP.ProjectID = P.ProjectID
WHERE p.StartDate > CONVERT(date, '13.08.2002', 103) AND p.EndDate IS NULL
ORDER BY E.EmployeeID

--Problem 8. Employee 24
SELECT e.EmployeeID, e.FirstName,
CASE
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE P.[Name]
END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON E.EmployeeID = EP.EmployeeID
JOIN Projects AS p
ON EP.ProjectID = P.ProjectID
WHERE ep.EmployeeID = 24
--Problem 9. Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3, 7) AND e.ManagerID IS NOT NULL
ORDER BY e.EmployeeID

--Problem 10. Employee Summary
SELECT TOP(50)
	e.EmployeeID, 
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, 
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName, 
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON E.DepartmentID = D.DepartmentID
WHERE d.DepartmentID IN (SELECT EmployeeID FROM Employees)
ORDER BY e.EmployeeID

--Problem 11. Min Average Salary
SELECT MIN(t.AvgSalary) AS MinAverageSalary 
FROM
	(SELECT AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID) AS t

--Problem 12. Highest Peaks in Bulgaria
USE Geography
SELECT 
	c.CountryCode, 
	m.MountainRange, 
	p.PeakName,
	p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON C.CountryCode = MC.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON m.Id = p.MountainId
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13. Count Mountain Ranges
SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m
ON M.Id = MC.MountainId
WHERE c.CountryCode IN (SELECT CountryCode
						FROM Countries
						WHERE CountryName IN ('United States', 'Russia', 'Bulgaria'))
GROUP BY c.CountryCode


--Problem 14. Countries with Rivers
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON r.Id = cr.RiverId
JOIN Continents AS co
ON co.ContinentCode = c.ContinentCode
WHERE co.ContinentName = 'Africa'
ORDER BY c.CountryName

--Problem 15. *Continents and Currencies
SELECT 	t.ContinentCode,
		t.CurrencyCode,
		t.CurrencyUsage
FROM    (SELECT 
		ContinentCode,
		CurrencyCode,
		COUNT(CurrencyCode) AS CurrencyUsage,
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS CurrencyRank
	    FROM Countries
	    GROUP BY ContinentCode, CurrencyCode) AS t
WHERE t.CurrencyUsage > 1 AND t.CurrencyRank = 1
ORDER BY t.ContinentCode

--•	ContinentCode
--•	CurrencyCode
--•	CurrencyUsage
--Find all continents and their most used currency. Filter any currency that is used in only one country. Sort your results by ContinentCode.


