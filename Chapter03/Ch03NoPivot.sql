WITH CTE_1996 AS
(
	SELECT LastName, COUNT(YEAR(OrderDate)) AS [1996]
	FROM Employees e
	INNER JOIN Orders o ON e.EmployeeID = o.EmployeeID
	WHERE YEAR(OrderDate) = 1996
	GROUP BY LastName
),
CTE_1997 AS
(
	SELECT LastName, COUNT(YEAR(OrderDate)) AS [1997]
	FROM Employees e
	INNER JOIN Orders o ON e.EmployeeID = o.EmployeeID
	WHERE YEAR(OrderDate) = 1997
	GROUP BY LastName
)
SELECT a.LastName, a.[1996], b.[1997]
FROM CTE_1996 a INNER JOIN CTE_1997 b ON a.LastName=b.LastName