SELECT e.LastName, YEAR(o.OrderDate) [Year], COUNT(o.OrderDate) TotalOrders
FROM Employees e
INNER JOIN Orders o on e.EmployeeID = o.EmployeeID
Where Year(o.OrderDate) in (1996,1997)
GROUP BY e.LastName, Year(o.OrderDate)
ORDER BY e.LastName