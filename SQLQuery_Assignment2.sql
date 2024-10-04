USE AdventureWorks2019
-- 1.How many products can you find in the Production.Product table?
SELECT COUNT(*)
FROM Production.Product

--2.Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(Pp.ProductID)
FROM Production.Product Pp
WHERE Pp.ProductSubcategoryID IS NOT NULL

--3.How many Products reside in each SubCategory? Write a query to display the results with the following titles.
SELECT Ps.ProductSubcategoryID, COUNT(Pp.ProductID) AS CountedProducts
FROM Production.product Pp JOIN Production.ProductSubcategory Ps ON Pp.ProductSubcategoryID = Ps.ProductSubcategoryID
GROUP BY Ps.ProductSubcategoryID

--4.How many products that do not have a product subcategory.    
SELECT COUNT(Pp.ProductID)
FROM Production.Product Pp
WHERE Pp.ProductSubcategoryID IS NULL

--5.Write a query to list the sum of products quantity of each product in the Production.ProductInventory table.
SELECT pi.ProductID, SUM(pi.Quantity) AS TotalQuantity
FROM Production.ProductInventory pi
GROUP BY pi.ProductID

--6.Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID,SUM(Quantity) AS TheSum
FROM Production.ProductInventory
Where LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity)<100

--7.Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT Shelf,ProductID,SUM(Quantity) AS TheSum
FROM Production.ProductInventory
Where LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity)<100

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT ProductID,AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
Where LocationID = 10
GROUP BY ProductID

--9.Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT ProductID, Shelf,AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY Shelf,ProductID

--10.Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT ProductID, Shelf,AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY Shelf,ProductID

--11.List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Pp.Color,Pp.Class,AVG(Pp.ListPrice)AS AvgPrice
FROM Production.Product Pp
WHERE Pp.Color IS NOT NULL AND Pp.Class IS NOT NULL
GROUP BY Pp.Color,Pp.Class

--Joins:

--12.Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
SELECT pc.Name AS CountryName,ps.Name AS ProvinceName
FROM person.CountryRegion pc JOIN person.StateProvince ps 
ON pc.CountryRegionCode = ps.CountryRegionCode

--13.Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT pc.Name AS CountryName,ps.Name AS ProvinceName
FROM person.CountryRegion pc JOIN person.StateProvince ps 
ON pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.Name IN ('Germany', 'Canada')


USE Northwind
-- 14.  List all Products that has been sold at least once in last 27 years.
Select DISTINCT p.ProductName, o.OrderDate
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON p.ProductID = od.ProductID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())

-- 15.  List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 ShipPostalCode,SUM(od.Quantity) AS ProductQuantity
FROM Orders o 
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY ShipPostalCode
ORDER BY ProductQuantity DESC

-- 16.  List top 5 locations (Zip Code) where the products sold most in last 27 years.
SELECT TOP 5 ShipPostalCode,SUM(od.Quantity) AS ProductQuantity
FROM Orders o 
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL AND o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY ShipPostalCode
ORDER BY ProductQuantity DESC

-- 17.   List all city names and number of customers in that city. 
SELECT City,COUNT(ContactName) AS TheCount
FROM Customers
GROUP BY City 

-- 18.  List city names which have more than 2 customers, and number of customers in that city
SELECT City,COUNT(ContactName) AS TheCount
FROM Customers
GROUP BY City 
HAVING COUNT(ContactName) >= 2

-- 19.  List the names of customers who placed orders after 1/1/98 with order date.
SELECT DISTINCT c.ContactName
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate >= '1998-01-01'

-- 20.  List the names of all customers with most recent order dates
SELECT c.ContactName,MAX(o.OrderDate) AS TheRecent
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

-- 21.Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName,SUM(od.Quantity) AS AllProducts
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.ContactName
ORDER BY AllProducts DESC


-- 22.Display the customer ids who bought more than 100 Products with count of products.
SELECT c.CustomerID,SUM(od.Quantity) AS AllProducts
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.CustomerID
HAVING SUM(od.Quantity)>100

--23.List all of the possible ways that suppliers can ship their products. Display the results as below
SELECT DISTINCT su.CompanyName AS [Supplier Company Name], sh.CompanyName AS [Shipping Company Name]
FROM [Order Details] od 
JOIN Products p ON od.ProductID = p.ProductID
JOIN Orders o ON o.ORDERID = od.OrderID
JOIN Shippers sh ON o.ShipVia = sh.ShipperID 
JOIN Suppliers su ON su.SupplierID = p.SupplierID

-- 24.  Display the products order each day. Show Order date and Product Name.
SELECT p.ProductName,o.OrderDate
FROM Products p 
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON o.OrderID = od.OrderID

-- 25.  Displays pairs of employees who have the same job title.
SELECT e1.FirstName + ' ' + e1.LastName AS Employee1, e2.FirstName + ' '+e2.LastName AS Employee2, e1.Title
FROM Employees e1
JOIN Employees e2 ON e1.Title = e2.Title
WHERE e1.EmployeeID <> e2.EmployeeID
ORDER BY e1.Title

-- 26.  Display all the Managers who have more than 2 employees reporting to them.
SELECT T1.EmployeeId, T1.LastName, T1.FirstName,T2.ReportsTo, COUNT(T2.ReportsTo) AS Subordinate  
FROM Employees T1 JOIN Employees T2 ON T1.EmployeeId = T2.ReportsTo
WHERE T2.ReportsTo IS NOT NULL
GROUP BY T1.EmployeeId, T1.LastName, T1.FirstName,T2.ReportsTo
HAVING COUNT(T2.ReportsTo) > 2

-- 27.  Display the customers and suppliers by city. The results should have the following columns
SELECT c.City, c.CompanyName, c.ContactName, 'Customer' as Type
FROM Customers c
UNION
SELECT s.City, s.CompanyName, s.ContactName, 'Supplier' as Type
FROM Suppliers s;
