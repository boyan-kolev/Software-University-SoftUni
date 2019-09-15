--Problem 1. Records’ Count
SELECT COUNT(*) AS [Count]
  FROM WizzardDeposits

--Problem 2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
  FROM WizzardDeposits

--Problem 3. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
  FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 4. * Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) DepositGroup
  FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--Problem 5. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 6. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Problem 7. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--Problem 8. Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge]
  FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 9. Age Groups
select WD.AG as [AgeGroup], count(Age) as [WizardCount]
from (
      select Age,
         case when Age >= 0 and Age <= 10 then '[0-10]'
         when Age >= 11 and Age <= 20 then '[11-20]'
		 when Age >= 21 and Age <= 30 then '[21-30]'
		 when Age >= 31 and Age <= 40 then '[31-40]'
		 when Age >= 41 and Age <= 50 then '[41-50]'
		 when Age >= 51 and Age <= 60 then '[51-60]'
         else '[61+]' end as [AG]
     from WizzardDeposits) AS WD
group by WD.AG

--Problem 10. First Letter
SELECT LEFT(FirstName, 1) AS FirstLetter
  FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

--Problem 11. Average Interest 
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS [AverageInterest]
  FROM WizzardDeposits
WHERE DepositStartDate >= '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--Problem 12. * Rich Wizard, Poor Wizard
--version 1
SELECT SUM(K.Diff) AS SumDifference
FROM
(SELECT 
	WD.DepositAmount - (SELECT W.DepositAmount FROM WizzardDeposits AS W WHERE W.Id = WD.Id + 1) AS Diff
  FROM WizzardDeposits AS WD) AS K

--Version 2
SELECT SUM(DiffTable.Diff) AS SumDifference
  FROM
	(SELECT (DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY Id)) AS Diff
	  FROM WizzardDeposits) AS DiffTable

--Version 3
SELECT (SUM(DiffTable.Diff) * -1) AS SumDifference
  FROM
	(SELECT (DepositAmount - LAG(DepositAmount, 1) OVER (ORDER BY Id)) AS Diff
	  FROM WizzardDeposits) AS DiffTable

--Problem 13. Departments Total Salaries
USE SoftUni

SELECT DepartmentID ,SUM(Salary) AS TotalSum
  FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--Problem 14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
  FROM Employees
WHERE DepartmentID IN (2, 5 ,7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

--Problem 15. Employees Average Salaries
SELECT * 
  INTO EmployeesEarnMoreThan30000
  FROM Employees
 WHERE Salary > 30000

DELETE FROM EmployeesEarnMoreThan30000
WHERE ManagerID = 42

UPDATE EmployeesEarnMoreThan30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AvarageSalary
  FROM EmployeesEarnMoreThan30000
GROUP BY DepartmentID

--Problem 16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
  FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17. Employees Count Salaries
SELECT COUNT(*) AS [Count] 
  FROM Employees
 WHERE ManagerID IS NULL

--Problem 18. *3rd Highest Salary
SELECT DISTINCT K.DepartmentID, K.Salary
  FROM
	(SELECT
		DepartmentID,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	  FROM Employees) AS K
 WHERE K.SalaryRank = 3

--Problem 19. **Salary Challenge
SELECT TOP(10)
	FirstName,
	LastName, 
	DepartmentID
  FROM Employees AS e
 WHERE Salary > (SELECT AVG(Salary) FROM Employees AS em WHERE em.DepartmentID = e.DepartmentID)
ORDER BY DepartmentID


    