using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
	public string Name { get; set; } = "";
	public double Salary { get; set; }
	public string Department { get; set; } = "";
	public bool IsResigned { get; set; }
	public int Experience { get; set; }
}

class Program
{
	static void Main()
	{
		List<Employee> employees =
		[
			new() { Name = "A", Salary = 50000, Department = "IT", IsResigned = false, Experience = 2 },
			new() { Name = "B", Salary = 70000, Department = "HR", IsResigned = true, Experience = 0 },
			new() { Name = "C", Salary = 60000, Department = "IT", IsResigned = false, Experience = 3 }
		];

		var activeQuery = from employee in employees where !employee.IsResigned select employee;
		var activeMethod = employees.Where(employee => !employee.IsResigned);
		var sortedQuery = from employee in employees orderby employee.Salary descending select employee;
		var sortedMethod = employees.OrderByDescending(employee => employee.Salary);
		var departmentsQuery = (from employee in employees select employee.Department).Distinct();
		var departmentsMethod = employees.Select(employee => employee.Department).Distinct();
		bool anyZeroQuery = (from employee in employees where employee.Experience == 0 select employee).Any();
		bool anyZeroMethod = employees.Any(employee => employee.Experience == 0);
		var projectionQuery = from employee in employees select new { employee.Name, employee.Salary };
		var projectionMethod = employees.Select(employee => new { employee.Name, employee.Salary });

		foreach (var employee in activeMethod) Console.WriteLine(employee.Name);
	}
}
