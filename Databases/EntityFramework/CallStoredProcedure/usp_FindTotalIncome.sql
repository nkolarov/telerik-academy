USE northwind;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_FindTotalIncome]') AND type in (N'P', N'PC'))
DROP PROCEDURE [usp_FindTotalIncome]
GO

CREATE PROCEDURE [dbo].[usp_FindTotalIncome]
	-- Add the parameters for the stored procedure here
	(@supplierName nvarchar(50), @startDate DateTime, @endDate DateTime)
AS
BEGIN
	SELECT 
		SUM(od.Quantity*od.UnitPrice) AS TotalIncome
	FROM 
		Orders o
	INNER JOIN [ORDER Details] od
		ON o.OrderID = od.OrderID
	INNER JOIN Products p
		ON p.ProductID = od.ProductID
	INNER JOIN Suppliers sup
		ON sup.SupplierID = p.SupplierID
	WHERE 
		sup.CompanyName = @supplierName 
		AND o.OrderDate >= @startDate 
		AND o.OrderDate <= @endDate
END
GO

