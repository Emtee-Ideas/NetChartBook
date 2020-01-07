WITH CTE_EmpRegion AS
(
	SELECT EmployeeID, MAX(RegionID) RegionID
	FROM EmployeeTerritories et
		INNER JOIN territories t ON t.TerritoryID = et.TerritoryID
	GROUP BY EmployeeID
),
CTE_Sales AS
(
	SELECT RegionID, SUM(Quantity * UnitPrice) TotalSales
	FROM Orders o
		INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
		INNER JOIN CTE_EmpRegion er ON o.EmployeeID = er.EmployeeID
	GROUP BY RegionID
)
SELECT s.RegionID, r.RegionDescription, s.TotalSales
FROM CTE_Sales s INNER JOIN Region r on s.RegionID=r.RegionID
ORDER BY s.RegionID