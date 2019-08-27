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