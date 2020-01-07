SELECT * FROM
(
	SELECT Year(OrderDate) AS pvt_col, e.LastName, o.OrderDate
	FROM Employees e
	INNER JOIN Orders o ON e.EmployeeID = o.EmployeeID
) AS t
PIVOT
(
	COUNT(OrderDate) FOR pvt_col in ([1996],[1997])
) AS pv
ORDER BY LastName