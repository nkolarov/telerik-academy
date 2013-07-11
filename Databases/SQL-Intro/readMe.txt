01. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
Structured query language for query and manipulation of relational data. SQL consists of:
- Data Manipulation Language (DML) - SELECT, INSERT, UPDATE, DELETE 
- Data Definition Language (DDL) - CREATE, DROP, ALTER, GRANT, REVOKE
02. What is Transact-SQL (T-SQL)?
Transact SQL is an extension to the standart SQL language. It supports if statements, loops and exceptions. It`s used for writing procedures, functions, triggers etc.
03. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
-- Done
04. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT        
	DepartmentID, 
	Name 
FROM
	Departments

05. Write a SQL query to find all department names.

SELECT        
	Name 
FROM
	Departments
	
06. Write a SQL query to find the salary of each employee.

SELECT        
	emp.FirstName,
	emp.LastName,
	emp.Salary
FROM
	Employees emp
	
07. Write a SQL to find the full name of each employee.

SELECT        
	CONCAT(emp.FirstName,  ' ', emp.LastName) as FullName
FROM
	Employees emp
	
08. Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

SELECT        
	CONCAT(emp.FirstName,  ' ', emp.LastName) as FullName,
	CONCAT(emp.FirstName,  '.', emp.LastName, '@telrik.com') as FullEmailAddresses
FROM
	Employees emp

09. Write a SQL query to find all different employee salaries.

SELECT        
	DISTINCT(emp.Salary)
FROM
	Employees emp
	
10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

SELECT        
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
WHERE
	emp.JobTitle = 'Sales Representative'
	
11. Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT        
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
WHERE
	emp.FirstName LIKE 'SA%'
	
12. Write a SQL query to find the names of all employees whose last name contains "ei".

SELECT        
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
WHERE
	emp.LastName LIKE '%ei%'
	
13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

SELECT        
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
WHERE
	emp.Salary BETWEEN 20000 AND 30000
	
14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

SELECT        
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
WHERE
	emp.Salary IN (
		25000,
		14000,
		12500,
		23600
	)
	
15. Write a SQL query to find all employees that do not have manager.

SELECT        
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
WHERE
	emp.ManagerID IS NULL
	
16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

SELECT        
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
WHERE
	emp.Salary > 50000
ORDER BY emp.Salary DESC

17. Write a SQL query to find the top 5 best paid employees.

SELECT TOP 5     
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle
FROM
	Employees emp
ORDER BY emp.Salary DESC

18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.

SELECT    
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle,
	adr.AddressText
FROM
	Employees emp
INNER JOIN Addresses adr 
	ON emp.AddressID = adr.AddressID

	
19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

SELECT    
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle,
	adr.AddressText
FROM
	Employees emp,
	Addresses adr 
WHERE
	emp.AddressID = adr.AddressID

	
20. Write a SQL query to find all employees along with their manager.

SELECT    
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle,
	CONCAT(man.FirstName, ' ', man.LastName) as 'Manager'
FROM
	Employees emp
LEFT JOIN Employees man
	ON emp.ManagerID = man.EmployeeID

21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

SELECT    
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle,
	adr.AddressText,
	CONCAT(man.FirstName, ' ', man.LastName) as 'Manager'
FROM
	Employees emp
LEFT JOIN Employees man
	ON emp.ManagerID = man.EmployeeID
INNER JOIN Addresses adr
	ON emp.AddressID = adr.AddressID
	
22. Write a SQL query to find all departments and all town names as a single list. Use UNION.

SELECT d.Name FROM Departments d
UNION
SELECT t.Name FROM Towns t

23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

SELECT    
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle,
	CONCAT(man.FirstName, ' ', man.LastName) as 'Manager'
FROM
	Employees man
RIGHT JOIN Employees emp
	ON emp.ManagerID = man.EmployeeID

	
SELECT    
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle,
	CONCAT(man.FirstName, ' ', man.LastName) as 'Manager'
FROM
	Employees emp
LEFT JOIN Employees man
	ON emp.ManagerID = man.EmployeeID

	
24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

SELECT    
	emp.FirstName, 
	emp.LastName, 
	emp. Salary, 
	emp.JobTitle,
	emp.HireDate
FROM
	Employees emp
INNER JOIN Departments dep
	ON dep.DepartmentID = emp.DepartmentID
WHERE
	dep.Name in ('Sales', 'Finance')
	AND emp.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-12-31 23:59:59'
