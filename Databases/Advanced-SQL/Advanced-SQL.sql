-- 01. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.

SELECT
	emp.FirstName,
	emp.LastName,
	emp.Salary
FROM 
	Employees emp
WHERE
	emp.Salary = ( SELECT MIN(Salary) FROM EMPLOYEES)

-- 02. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT
	emp.FirstName,
	emp.LastName,
	emp.Salary
FROM 
	Employees emp
WHERE
	emp.Salary < ( SELECT MIN(Salary) FROM EMPLOYEES)*1.1

-- 03. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.

SELECT
	emp.FirstName,
	emp.LastName,
	emp.Salary,
	dep.Name
FROM 
	Employees emp,
	Departments dep
WHERE
	emp.Salary = ( SELECT MIN(Salary) FROM Employees WHERE Employees.DepartmentID = dep.DepartmentID)
ORDER BY
	dep.Name
	
-- 04. Write a SQL query to find the average salary in the department #1.

SELECT
	AVG(emp.Salary)
FROM 
	Employees emp
WHERE
	emp.DepartmentID = 1

-- 05. Write a SQL query to find the average salary  in the "Sales" department.

SELECT
	AVG(emp.Salary)
FROM 
	Employees emp
INNER JOIN Departments dep
	ON emp.DepartmentID = dep.DepartmentID
WHERE
	dep.Name = 'Sales'
	
-- 06. Write a SQL query to find the number of employees in the "Sales" department.

SELECT
	COUNT(*)
FROM 
	Employees emp
INNER JOIN Departments dep
	ON emp.DepartmentID = dep.DepartmentID
WHERE
	dep.Name = 'Sales'

-- 07. Write a SQL query to find the number of all employees that have manager.

SELECT
	COUNT(*)
FROM 
	Employees emp
WHERE
	emp.ManagerID IS NOT NULL

-- 08. Write a SQL query to find the number of all employees that have no manager.

SELECT
	COUNT(*)
FROM 
	Employees emp
WHERE
	emp.ManagerID IS NULL
	
-- 09. Write a SQL query to find all departments and the average salary for each of them.

SELECT dep.Name, AVG(emp.Salary)
FROM 
	Employees emp
INNER JOIN Departments dep
	ON dep.DepartmentID = emp.DepartmentID
GROUP BY dep.DepartmentID, dep.Name

-- 10. Write a SQL query to find the count of all employees in each department and for each town.

SELECT dep.Name, t.Name, AVG(emp.Salary)
FROM 
	Employees emp
INNER JOIN Departments dep
	ON dep.DepartmentID = emp.DepartmentID
INNER JOIN Towns t
	on t.TownID = dep.DepartmentID
GROUP BY dep.DepartmentID, dep.Name, t.TownID, t.Name

-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

SELECT 
	man.FirstName,
	man.LastName
FROM
Employees man
INNER JOIN
	(SELECT
		emp.ManagerID
	FROM
		Employees emp
	GROUP BY emp.ManagerID
	HAVING COUNT(emp.ManagerID) = 5) as mId
ON mId.ManagerID = man.EmployeeID

-- Second Way

SELECT 
	emp.FirstName,
	emp.LastName 
FROM Employees emp 
	INNER JOIN Employees man 
ON emp.EmployeeID = man.ManagerID
GROUP BY emp.FirstName,emp.LastName
HAVING COUNT(*)=5

-- 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT 
	emp.FirstName,
	emp.LastName,
	CASE
		WHEN man.FirstName IS NOT NULL
		THEN CONCAT(emp.FirstName, ' ', emp.LastName)
		ELSE '(no manager)'
	END as 'Manager'
FROM Employees emp 
	LEFT OUTER JOIN Employees man 
ON emp.ManagerID = man.EmployeeID

-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT 
	emp.FirstName,
	emp.LastName
FROM 
	Employees emp
WHERE
	LEN(emp.LastName) = 5
	
-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.

SELECT CONCAT(CONVERT(varchar, GETDATE(), 104), ' ', CONVERT(varchar, GETDATE(), 114))

-- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
-- Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE SystemUsers(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserName NVARCHAR(50) NOT NULL UNIQUE,
	UserPassword VARBINARY(50) NOT NULL CHECK(Len(UserPassword)>=5),
	FullName NVARCHAR(255) NOT NULL,
	LastLoginTime DATETIME NULL
);

-- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. 
-- Test if the view works correctly.

CREATE VIEW TodayUserLogins AS
SELECT
	*
FROM
	SystemUsers
WHERE 
	SystemUsers.LastLoginTime >= CONVERT(VARCHAR(10),GETDATE(),102)
	
INSERT SystemUsers VALUES ('Pesho', Convert(varbinary, 'zlaParola'), 'Pesheto', GETDATE())	
INSERT SystemUsers VALUES ('Pesho2', Convert(varbinary, 'zlaParola'), 'Pesheto2', DATEADD(DAY, -1, GETDATE()))

SELECT 
	* 
FROM
	TodayUserLogins

-- 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
-- Define primary key and identity column.

CREATE TABLE Groups(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL UNIQUE
);

-- 18. Write a SQL statement to add a column GroupID to the table Users. 
-- Fill some data in this new column and as well in the Groups table. 
-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE SystemUsers
ADD GroupId INT FOREIGN KEY REFERENCES Groups(Id);

INSERT Groups VALUES ('users')
INSERT Groups VALUES ('admins')
INSERT Groups VALUES ('ninjas')

UPDATE SystemUsers SET GroupId =  (SELECT Id from groups where name = 'ninjas') WHERE SystemUsers.UserName = 'Pesho'

-- 19. Write SQL statements to insert several records in the Users and Groups tables.

INSERT SystemUsers VALUES ('Ivan', Convert(varbinary, 'zlaParolaNaIvan'), 'Vankata', GETDATE())	
INSERT SystemUsers VALUES ('Miro', Convert(varbinary, 'zlaParolaMiro'), 'MiroGAzara', DATEADD(DAY, -1, GETDATE()))

INSERT Groups VALUES ('stupid_users')

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE SystemUsers SET GroupId = (SELECT Id from groups where name = 'stupid_users') WHERE SystemUsers.UserName = 'Miro'

UPDATE Groups SET Name = 'so_stupid_users' WHERE name = 'stupid_users'

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM SystemUsers WHERE UserName = 'Miro'
DELETE FROM Groups WHERE Name = 'so_stupid_users'

-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
-- Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
-- Use the same for the password, and NULL for last login time.

Insert SystemUsers
SELECT
	LOWER(CONCAT(SUBSTRING(emp.FirstName,1,3), emp.LastName)) as UserName,
	CONVERT(varbinary,CONCAT(SUBSTRING(emp.FirstName,1,1), LOWER(emp.LastName))) as userpass, 
	CONCAT(emp.FirstName, ' ', emp.LastName) as FullName,
	NULL as LastLoginTime,
	NULL as GroupId
FROM
	Employees emp 

-- We use the first 3 letters of the first name to bypass the unique constraint.
-- EmployeeID	FirstName	LastName
-- 185	            Andrew		Hill
-- 264				Annette		Hill
	
-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

INSERT SystemUsers VALUES ('PeshoPensiata', Convert(varbinary, 'zlaParola'), 'PeshoPensiata', DATEADD(YEAR, -10, GETDATE()), null);

UPDATE SystemUsers
	SET UserPassword = Convert(varbinary, 'NoPass')
WHERE 
	LastLoginTime < CONVERT(DATE, '10.03.2010', 104);

DELETE 
FROM 
	SystemUsers 
WHERE
	UserPassword = Convert(varbinary, 'NoPass');

-- 24. Write a SQL statement that deletes all users without passwords (NULL password).

DELETE 
FROM 
	SystemUsers 
WHERE
	UserPassword IS NULL;
	
-- By design our table have a NOT NULL constraint for password.
	
-- 25. Write a SQL query to display the average employee salary by department and job title.

SELECT
	dep.Name AS 'Department', 
	emp.JobTitle, 
	AVG(emp.Salary) AS 'AverageSalary'
FROM 
	Employees emp 
INNER JOIN Departments dep
	ON dep.DepartmentID = emp.DepartmentID
GROUP BY dep.DepartmentID, dep.Name,emp.JobTitle

-- 26. Write a SQL query to display the minimal employee salary by department and job title 
-- along with the name of some of the employees that take it.

-- Some employee chosen by fair dice roll guaranteed to be random
SELECT
	dep.Name AS 'Department', 
	MIN(emp.Salary) AS 'Minimal Salary',
	MIN(emp.FirstName + ' '+emp.LastName) AS 'Some Emplyee'
FROM 
	Employees emp 
INNER JOIN Departments dep
	ON dep.DepartmentID = emp.DepartmentID
GROUP BY dep.DepartmentID, dep.Name

-- All employees with minimal salary for their department.
SELECT 
	dep.Name AS 'Department',
	emp.FirstName,
	emp.LastName, 
	emp.JobTitle, 
	emp.Salary AS 'Minimal Salary'
FROM 
	Departments dep
INNER JOIN Employees emp 
	ON dep.DepartmentID = emp.DepartmentID
WHERE Salary = (
	SELECT MIN(Employees.Salary)
	FROM Employees
	WHERE Employees.DepartmentID = emp.DepartmentID
)

-- 27. Write a SQL query to display the town where maximal number of employees work.

SELECT 
	TOP 1
	t.Name, 
	COUNT(t.Name) AS 'Employees Count'
FROM 
	Employees emp
INNER JOIN Addresses adr
	ON adr.AddressID = emp.AddressID
INNER JOIN Towns t
	ON t.TownID = adr.TownID
GROUP BY t.Name
ORDER BY COUNT(t.Name) DESC

-- 28. Write a SQL query to display the number of managers from each town.

SELECT 
	t.Name AS 'Town Name',
	COUNT(t.Name) AS 'Managers Count'
FROM 
	Employees man
INNER JOIN  (SELECT ManagerID from Employees WHERE ManagerID IS NOT NULL GROUP BY ManagerID) AS AllManagers
	ON AllManagers.ManagerID = man.EmployeeID 
INNER JOIN Addresses adr
	ON adr.AddressID = man.AddressID
INNER JOIN Towns t
	ON t.TownID = adr.TownID
GROUP BY t.Name

-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
-- Don't forget to define  identity, primary key and appropriate foreign key. 
-- Issue few SQL statements to insert, update and delete of some data in the table.
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours(
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
        ReportDate date NOT NULL,
        Task nvarchar(80) NOT NULL,
        ExecutionHours float NOT NULL CHECK(Len(ExecutionHours)>=0),
        Comments nvarchar(255) NOT NULL
);

INSERT WorkHours VALUES('1', GETDATE(), 'Clean the pool', '2.5', 'Good job');
INSERT WorkHours VALUES('2', GETDATE(), 'Wash the windows', '1', 'Great job');
UPDATE WorkHours SET Comments = 'Perfect Job' WHERE WorkHours.EmployeeId = 2;
DELETE FROM WorkHours WHERE WorkHours.EmployeeId = 1;
INSERT WorkHours VALUES('1', GETDATE(), 'Clean the pool', '2.5', 'Good job');


CREATE TABLE WorkHoursLogs(
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        OldEmployeeId int NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
		NewEmployeeId int NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
        OldReportDate date NULL,
		NewReportDate date NULL,
        OldTask nvarchar(80) NULL,
		NewTask nvarchar(80) NULL,
        OldExecutionHours float NULL,
		NewExecutionHours float NULL,
        OldComments nvarchar(255) NULL,
		NewComments nvarchar(255) NULL,
		Command nvarchar(50) NULL
);

CREATE TRIGGER WorkHoursAfterInsert ON dbo.WorkHours AFTER INSERT AS
BEGIN
	DECLARE 
		@NewEmployeeId int, 
		@NewReportDate date, 
		@NewTask nvarchar(80),
		@NewExecutionHours float, 
		@NewComments nvarchar(255);
 
	SELECT 
		@NewEmployeeId = inserted.EmployeeId, 
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task, 
		@NewExecutionHours = inserted.ExecutionHours, 
		@NewComments = inserted.Comments
	FROM inserted;
 
	INSERT INTO WorkHoursLogs (
		NewEmployeeId, 
		NewReportDate, 
		NewTask,
		NewExecutionHours, 
		NewComments, 
		Command
	)
	VALUES (
		@NewEmployeeId, 
		@NewReportDate, 
		@NewTask, 
		@NewExecutionHours, 
		@NewComments, 
		'INSERT'
	);
END
GO

INSERT WorkHours VALUES('1', GETDATE(), 'Cleaning the pool', '2.5', 'Good job');

SELECT * FROM WorkHoursLogs;

CREATE TRIGGER WorkHoursAfterUpdate ON dbo.WorkHours AFTER UPDATE AS
BEGIN
	DECLARE 
		@NewEmployeeId int, 
		@NewReportDate date, 
		@NewTask nvarchar(80),
		@NewExecutionHours float, 
		@NewComments nvarchar(255),
		@OldEmployeeId int, 
		@OldReportDate date, 
		@OldTask nvarchar(80),
		@OldExecutionHours float, 
		@OldComments nvarchar(255);
 
	SELECT 
		@NewEmployeeId = inserted.EmployeeId, 
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task, 
		@NewExecutionHours = inserted.ExecutionHours, 
		@NewComments = inserted.Comments
	FROM inserted;

		SELECT 
		@OldEmployeeId = deleted.EmployeeId, 
		@OldReportDate = deleted.ReportDate,
		@OldTask = deleted.Task, 
		@OldExecutionHours = deleted.ExecutionHours, 
		@OldComments = deleted.Comments
	FROM deleted;
 
	INSERT INTO WorkHoursLogs (
		NewEmployeeId, 
		NewReportDate, 
		NewTask,
		NewExecutionHours, 
		NewComments, 
		OldEmployeeId, 
		OldReportDate, 
		OldTask,
		OldExecutionHours, 
		OldComments, 
		Command
	)
	VALUES (
		@NewEmployeeId, 
		@NewReportDate, 
		@NewTask, 
		@NewExecutionHours, 
		@NewComments, 
		@OldEmployeeId, 
		@OldReportDate, 
		@OldTask, 
		@OldExecutionHours, 
		@OldComments, 
		'UPDATE'
	);
END
GO

UPDATE WorkHours SET Comments = 'Perfect Job' WHERE WorkHours.EmployeeId = 1;
SELECT * FROM WorkHoursLogs;

CREATE TRIGGER WorkHoursAfterDelete ON dbo.WorkHours AFTER DELETE AS
BEGIN
	DECLARE 
		@NewEmployeeId int, 
		@NewReportDate date, 
		@NewTask nvarchar(80),
		@NewExecutionHours float, 
		@NewComments nvarchar(255),
		@OldEmployeeId int, 
		@OldReportDate date, 
		@OldTask nvarchar(80),
		@OldExecutionHours float, 
		@OldComments nvarchar(255);
 
	SELECT 
		@NewEmployeeId = inserted.EmployeeId, 
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task, 
		@NewExecutionHours = inserted.ExecutionHours, 
		@NewComments = inserted.Comments
	FROM inserted;

		SELECT 
		@OldEmployeeId = deleted.EmployeeId, 
		@OldReportDate = deleted.ReportDate,
		@OldTask = deleted.Task, 
		@OldExecutionHours = deleted.ExecutionHours, 
		@OldComments = deleted.Comments
	FROM deleted;
 
	INSERT INTO WorkHoursLogs (
		NewEmployeeId, 
		NewReportDate, 
		NewTask,
		NewExecutionHours, 
		NewComments, 
		OldEmployeeId, 
		OldReportDate, 
		OldTask,
		OldExecutionHours, 
		OldComments, 
		Command
	)
	VALUES (
		@NewEmployeeId, 
		@NewReportDate, 
		@NewTask, 
		@NewExecutionHours, 
		@NewComments, 
		@OldEmployeeId, 
		@OldReportDate, 
		@OldTask, 
		@OldExecutionHours, 
		@OldComments, 
		'DELETE'
	);
END
GO

DELETE FROM WorkHours WHERE WorkHours.EmployeeId = 1;
SELECT * FROM WorkHoursLogs;

-- 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. 
-- At the end rollback the transaction.

ALTER TABLE dbo.Employees DROP CONSTRAINT FK_Employees_Addresses_Cascade;

ALTER TABLE dbo.Employees
   ADD CONSTRAINT FK_Employees_Addresses_Cascade
   FOREIGN KEY (AddressID) REFERENCES dbo.Addresses(AddressID) ON DELETE CASCADE;
   
ALTER TABLE dbo.Employees DROP CONSTRAINT FK_Employees_Departments_Cascade;

ALTER TABLE dbo.Employees
   ADD CONSTRAINT FK_Employees_Departments_Cascade
   FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID) ON DELETE CASCADE;

ALTER TABLE dbo.EmployeesProjects DROP CONSTRAINT FK_EmployeesProjects_Employees;

ALTER TABLE dbo.EmployeesProjects
   ADD CONSTRAINT FK_EmployeesProjects_Employees_Cascade
   FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID) ON DELETE CASCADE;

BEGIN TRAN DeleteEmployee

DELETE FROM Employees WHERE Employees.EmployeeID = 5;

ROLLBACK TRAN

-- 31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?

BEGIN TRAN
 
DROP TABLE EmployeesProjects
 
ROLLBACK TRAN

-- We could restore the table from a backup.... If we had one ... :)

-- 32. Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

BEGIN TRAN
        SELECT 
			* 
		INTO #EmployeesProjects_Archive
        FROM 
			EmployeesProjects;

        DROP TABLE EmployeesProjects;

        SELECT 
			* 
		INTO EmployeesProjects
        FROM 
			#EmployeesProjects_Archive;

        DROP TABLE #EmployeesProjects_Archive;
GO
