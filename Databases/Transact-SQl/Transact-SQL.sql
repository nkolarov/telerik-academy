-- 01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY),
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [bigint] NOT NULL
)
 
 CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PersonId] [int] NOT NULL FOREIGN KEY([PersonId]) REFERENCES [dbo].[Persons] ([Id]),
	[Balance] [money] NOT NULL
)
 
CREATE PROCEDURE usp_GetAllPersonsFullNames
AS
BEGIN
	SELECT
		CONCAT(p.FirstName, ' ', p.LastName) AS 'FullName'
	FROM
		Persons p
END
GO

EXEC usp_GetAllPersonsFullNames

-- 02. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

CREATE PROCEDURE usp_HasMoreMoneyThan (@Value money)
AS
BEGIN
	SELECT
		CONCAT(p.FirstName, ' ', p.LastName) AS 'FullName'
	FROM
		Persons p
	INNER JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE
		a.Balance > @Value;
END
GO

EXEC usp_HasMoreMoneyThan 100

-- 03. Create a function that accepts as parameters – sum, yearly interest rate and number of months. It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.

CREATE FUNCTION ufn_GetEarnings (@Sum money, @YearlyInterestRate float, @NumberOfMonths int)
RETURNS money
BEGIN
	RETURN @Sum + (@Sum*@YearlyInterestRate/100)*(@NumberOfMonths/12.0) ;
END

SELECT dbo.ufn_GetEarnings(1000,10,12) AS 'NewSum'

/*
Procedure Way:

CREATE PROCEDURE usp_GetEarnings (@Sum money, @YearlyInterestRate float, @NumberOfMonths int, @NewSum money OUTPUT)
AS
BEGIN
	SET @NewSum = @Sum + (@Sum*@YearlyInterestRate/100)*(@NumberOfMonths/12.0) ;
END
GO

DECLARE @NewSum money
EXEC usp_GetEarnings 1000,10, 12, @NewSum OUTPUT
SELECT @NewSum
*/
-- 04. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. 
-- It should take the AccountId and the interest rate as parameters.

CREATE PROCEDURE usp_GetOneMonthEarnings (@AccountId int, @YearlyInterestRate float, @NewSum money OUTPUT)
AS
BEGIN
DECLARE @Sum money;
SET @Sum = (Select acc.Balance FROM Accounts acc WHERE acc.Id = @AccountId);
SET @NewSum = (@Sum*@YearlyInterestRate/100)/12.0 ;
END
GO

DECLARE @NewSum money
EXEC usp_GetOneMonthEarnings 1,10, @NewSum OUTPUT
SELECT @NewSum


-- 05. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.

CREATE PROCEDURE usp_WithdrawMoney (@AccountId int, @Sum float)
AS
BEGIN
	BEGIN TRAN
	DECLARE @CurrrentBalance money;
	SET @CurrrentBalance = (SELECT acc.Balance FROM Accounts acc WHERE acc.Id = @AccountId);
	IF (@Sum > 0 AND @CurrrentBalance - @Sum >= 0)
	BEGIN
		UPDATE Accounts SET Balance = @CurrrentBalance - @Sum WHERE Accounts.Id = @AccountID;
		COMMIT TRAN;
	END
	ELSE
	ROLLBACK TRAN;
END
GO

-- Withdraw some money.
DECLARE @AccountID int;
SET @AccountID =1;

SELECT acc.Balance AS 'StartingMoney' FROM Accounts acc WHERE acc.Id = @AccountID;
EXEC usp_WithdrawMoney 1,100;
SELECT acc.Balance AS 'EndingMoney' FROM Accounts acc WHERE acc.Id = @AccountID;


CREATE PROCEDURE usp_DepositMoney(@AccountId int, @Sum float)
AS
BEGIN
	BEGIN TRAN
	DECLARE @CurrrentBalance money;
	SET @CurrrentBalance = (SELECT acc.Balance FROM Accounts acc WHERE acc.Id = @AccountId);
	IF (@Sum > 0 AND @CurrrentBalance + @Sum >= 0)
	BEGIN
		UPDATE Accounts SET Balance = @CurrrentBalance + @Sum WHERE Accounts.Id = @AccountID;
		COMMIT TRAN;
	END
	ELSE
	ROLLBACK TRAN;
END
GO

-- Deposit some money.
DECLARE @AccountID int;
SET @AccountID =1;

SELECT acc.Balance AS 'StartingMoney' FROM Accounts acc WHERE acc.Id = @AccountID;
EXEC usp_DepositMoney 1,100;
SELECT acc.Balance AS 'EndingMoney' FROM Accounts acc WHERE acc.Id = @AccountID;

-- 06. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[AccountId] [int] NOT NULL FOREIGN KEY([AccountId]) REFERENCES [dbo].[Accounts] ([Id]),
	[OldSum] [money] NOT NULL,
	[NewSum] [money] NOT NULL,
	[TransactionTime] [datetime] NOT NULL)

CREATE TRIGGER tr_AccountsONUpdate ON dbo.Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs (Logs.AccountId, Logs.OldSum, Logs.NewSum, Logs.TransactionTime)

	SELECT 
		deleted.Id,
		deleted.Balance,
        inserted.Balance,
         GETDATE()
  FROM deleted
  JOIN inserted
    ON deleted.Id = inserted.Id
END




-- 07. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. 
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
-- http://www.codeproject.com/Articles/42764/Regular-Expressions-in-MS-SQL-Server-2005-2008

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
 
USE TelerikAcademy
CREATE ASSEMBLY
--assembly name for references from SQL script
SqlRegularExpressions
-- assembly name and full path to assembly dll,
-- SqlRegularExpressions in this case
--change path to dll
FROM 'D:\SqlAddOns\SqlRegularExpressions.dll'  
WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION RegExpLike(@Text nvarchar(MAX), @Pattern nvarchar(255)) RETURNS BIT
--function external name
AS EXTERNAL NAME SqlRegularExpressions.SqlRegularExpressions.[LIKE]
 
GO

CREATE FUNCTION ufn_FindEmployeesByRegEx ( @regEx nvarchar(50) )
RETURNS TABLE
AS
RETURN 
	SELECT 
		emp.FirstName,
		emp.MiddleName,
		emp.LastName,
		Towns.Name
	FROM 
		Employees AS emp
	INNER JOIN Addresses AS adr
		ON emp.AddressID = adr.AddressID
	INNER JOIN Towns
		ON adr.TownID = Towns.TownID
	WHERE 
		dbo.RegExpLike(LOWER(Towns.Name), @regEx) = 1
		AND (
			dbo.RegExpLike(LOWER(emp.FirstName), @regEx) = 1
			OR dbo.RegExpLike(LOWER(ISNULL(emp.MiddleName, '')), @regEx) = 1
			OR dbo.RegExpLike(LOWER(emp.LastName), @regEx) = 1
			)
GO

SELECT * FROM ufn_FindEmployeesByRegEx('^[oistmiahf]+$')



-- 08. Using database cursor write a T-SQL script that scans all employees and their addresses 
-- and prints all pairs of employees that live in the same town.

DECLARE Employees_Cursor CURSOR READ_ONLY FOR
 
SELECT 
	fe.FirstName, 
	fe.LastName, 
	ft.Name, 
	se.FirstName, 
	se.LastName
FROM 
	Employees fe
INNER JOIN Addresses fadr
	ON fe.AddressID = fadr.AddressID
INNER JOIN Towns ft
	ON fadr.TownID = ft.TownID
CROSS JOIN 
	Employees se
INNER JOIN Addresses sadr
	ON se.AddressID = sadr.AddressID
INNER JOIN Towns st
	ON sadr.TownID = st.TownID
WHERE ft.Name = st.Name
  AND fe.EmployeeID <> se.EmployeeID
ORDER BY fe.FirstName, se.FirstName
 
OPEN Employees_Cursor
DECLARE @firstName1 NVARCHAR(50)
DECLARE @lastName1 NVARCHAR(50)
DECLARE @town NVARCHAR(50)
DECLARE @firstName2 NVARCHAR(50)
DECLARE @lastName2 NVARCHAR(50)
FETCH NEXT FROM Employees_Cursor
        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
WHILE @@FETCH_STATUS = 0
        BEGIN
                PRINT 
					@firstName1 + ' ' + @lastName1 + ', ' +
					@firstName2 + ' ' + @lastName2 + ' -> ' + @town 
                FETCH NEXT FROM Employees_Cursor
                        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
        END
 
CLOSE Employees_Cursor
DEALLOCATE Employees_Cursor

-- 09. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
-- 10.Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. For example the following SQL statement should return a single string:
-- SELECT StrConcat(FirstName + ' ' + LastName)
-- FROM Employees
