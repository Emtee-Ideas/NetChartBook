select e.EmployeeID, LastName, min(Freight) [Min], max(Freight) [Max],
	sum(Freight) [Sum], avg(Freight) [Avg], stdev(Freight) [StDev]
from Orders o inner join Employees e on e.EmployeeID = o.EmployeeID
group by e.EmployeeID, LastName
order by LastName