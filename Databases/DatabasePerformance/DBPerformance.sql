---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- TASK 01. 
-- Create a table in SQL Server with 1 000 000 log entries (date + text). Search in the table by date range. Check the speed (without caching).

CREATE TABLE [dbo].[ExampleLogs](
	[LogId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[LogText] [nvarchar](100) NOT NULL,
	[LogDate] [datetime] NOT NULL);
	
-- Add some data	
SET NOCOUNT ON
DECLARE @RowCount int = 1000000
WHILE @RowCount > 0
BEGIN
  DECLARE @Text nvarchar(100) = 
    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @Date datetime = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
   INSERT INTO ExampleLogs(LogText, LogDate)
  VALUES(@Text, @Date)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF

-- 15 minutes later ...

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

-- Search in the table by date range. 

SELECT
	COUNT(*)
FROM 
	ExampleLogs el
WHERE
	YEAR(el.LogDate) > 2000
	AND YEAR(el.LogDate) < 2020
	
-- Execution Time Without Cashe : 00:00:09	
-- Execution Time With Cashe : 00:00:00

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- TASK 2
-- Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).

CREATE INDEX IDX_ExampleLogs_LogDate ON ExampleLogs(LogDate);
-- Execution time: 00:00:09 seconds

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

-- Search in the table by date range. 

SELECT
	COUNT(*)
FROM 
	ExampleLogs el
WHERE
	YEAR(el.LogDate) > 2000
	AND YEAR(el.LogDate) < 2020
	
-- Execution Time Without Cashe : 00:00:02
-- Execution Time With Cashe : 00:00:00

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- TAKS 3
-- Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT 
	COUNT(*)
FROM
	ExampleLogs el
WHERE
	el.LogText LIKE '%999%'
	
-- Execution Time Without Cashe : 00:00:15
-- Execution Time With Cashe : 00:00:07

-- Create the catalog.
CREATE FULLTEXT CATALOG ExampleLogsFullTextCatalog WITH ACCENT_SENSITIVITY = OFF AS DEFAULT;
CREATE FULLTEXT INDEX ON ExampleLogs(LogText) KEY INDEX PK_ExampleLogs ON ExampleLogsFullTextCatalog WITH CHANGE_TRACKING AUTO;

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT 
	COUNT(*)
FROM
	ExampleLogs el
WHERE
	CONTAINS(el.LogText, '999')
	
-- Execution Time Without Cashe : 00:00:03
-- Execution Time With Cashe : 00:00:00

