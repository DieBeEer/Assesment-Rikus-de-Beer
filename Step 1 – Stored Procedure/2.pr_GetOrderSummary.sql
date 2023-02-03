USE [Northwind]
GO
/****** Object:  StoredProcedure [dbo].[pr_GetOrderSummary]    Script Date: 1/19/2023 3:41:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetOrderSummary] --'1996-07-04 00:00:00.000', '1998-05-06 00:00:00.000', Null, Null

@StartDate DATETIME,
@EndDate DATETIME,
@EmployeeID INT,
@CustomerID NCHAR(10) 

AS
BEGIN

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

SELECT 

([Employees].[TitleOfCourtesy] + ' ' + [Employees].[FirstName] + ' ' + [Employees].[LastName])	AS [EmployeeFullName],
[Shippers].[CompanyName]																		AS [ShipperCompanyName],
[Customers].[CompanyName]																		AS [CustomerCompanyName],
COUNT([Orders].[OrderID])																		AS [NumberOfOders],
[Orders].[OrderDate]																			AS [OrderDate],
SUM([Orders].[Freight])																			AS [TotalFreightCost],
COUNT([Order Details].[ProductID])																AS [NumberOfDifferentProducts],
SUM([Order Details].[Quantity] * [Order Details].[UnitPrice])									AS [TotalOrderValue]																					
FROM [Orders] 
INNER JOIN [Employees] ON [Employees].[EmployeeID] = [Orders].[EmployeeID]
INNER JOIN [Customers] ON [Customers].[CustomerID] = [Orders].[CustomerID]
INNER JOIN [Shippers] ON [Shippers].[ShipperID] = [Orders].[ShipVia]
INNER JOIN [Order Details] ON [Order Details].[OrderID] = [Orders].[OrderID]


WHERE 
([Orders].[OrderDate] BETWEEN @StartDate AND @EndDate)
AND ([Employees].[EmployeeID] = @EmployeeID OR @EmployeeID IS NULL)
AND ([Customers].[CustomerID] = @CustomerID OR @CustomerID IS NULL)

GROUP BY
[Orders].[OrderDate],
[Employees].[TitleOfCourtesy],
[Employees].[FirstName],
[Employees].[LastName],
[Customers].[CompanyName],
[Shippers].[CompanyName]

END

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID=NULL

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID=NULL

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID='VINET'

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID='VINET'

