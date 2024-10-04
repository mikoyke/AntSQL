-- 1. List all cities that have both Employees and Customers.
SELECT City FROM Employees
WHERE City IN (SELECT City FROM Customers)
GROUP BY City;

-- 2. List all cities that have Customers but no Employee.
--a.Use sub-query
SELECT City FROM Customers
WHERE City NOT IN (SELECT City FROM Employees)
GROUP BY City;

-- b.Do not use sub-query
SELECT c.City 
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL
GROUP BY c.City;

-- 3.List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(od.Quantity) AS TotalQuantity
FROM Products p
INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName;

-- 4.List all Customer Cities and total products ordered by that city.
SELECT Customers.City, SUM(od.Quantity) AS TotalQuantity
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
INNER JOIN [Order Details] od ON Orders.OrderID = od.OrderID
GROUP BY Customers.City;

-- 5.List all Customer Cities that have at least two customers.
SELECT City 
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2

-- 6.List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2;

-- 7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT c.CustomerID, c.City AS CustomerCity, o.ShipCity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City <> o.ShipCity;

-- 8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT TOP 5 
    p.ProductName, 
    AVG(p.UnitPrice) AS AvgPrice, 
    (SELECT TOP 1 c.City 
     FROM Customers c
     JOIN Orders o ON c.CustomerID = o.CustomerID
     JOIN [Order Details] od ON o.OrderID = od.OrderID
     WHERE od.ProductID = p.ProductID
     GROUP BY c.City
     ORDER BY SUM(od.Quantity) DESC) AS CityWithMostOrders
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName, p.ProductID  -- Include p.ProductID here
ORDER BY SUM(od.Quantity) DESC;

-- 9. List all cities that have never ordered something but we have employees there.

-- a. Use sub-query
SELECT City FROM Employees
WHERE City NOT IN (SELECT City FROM Customers)
GROUP BY City;

-- b. Do not use sub-query
SELECT Employees.City
FROM Employees
LEFT JOIN Customers ON Employees.City = Customers.City
WHERE Customers.City IS NULL
GROUP BY Employees.City;

-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
WITH EmployeeOrders AS (
    SELECT 
        e.City AS EmployeeCity,
        COUNT(o.OrderID) AS OrdersSold
    FROM 
        Employees e
    INNER JOIN 
        Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY 
        e.City
),
TotalQuantityOrdered AS (
    SELECT 
        c.City AS OrderCity,
        SUM(od.Quantity) AS TotalQuantityOrdered
    FROM 
        Customers c
    INNER JOIN 
        Orders o ON c.CustomerID = o.CustomerID
    INNER JOIN 
        [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY 
        c.City
)
SELECT TOP 1
    COALESCE(eo.EmployeeCity, tq.OrderCity) AS City,
    eo.OrdersSold,
    tq.TotalQuantityOrdered
FROM 
    EmployeeOrders eo
FULL OUTER JOIN 
    (SELECT TOP 1 * FROM TotalQuantityOrdered ORDER BY TotalQuantityOrdered DESC) tq ON eo.EmployeeCity = tq.OrderCity
ORDER BY eo.OrdersSold DESC;


-- 11. How do you remove the duplicates record of a table?
CREATE TABLE new_table AS
SELECT DISTINCT * FROM table_name;
