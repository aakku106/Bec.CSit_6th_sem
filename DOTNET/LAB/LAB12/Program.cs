using Microsoft.EntityFrameworkCore;

public class Employee
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public decimal Salary { get; set; }
	public string Department { get; set; } = "";
	public bool IsResigned { get; set; }
	public int Experience { get; set; }
}

public class AppDbContext : DbContext
{
	public DbSet<Employee> Employees => Set<Employee>();
	protected override void OnConfiguring(DbContextOptionsBuilder options) =>
		options.UseSqlServer("Server=localhost;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;");
}

class Program
{
	static void Main()
	{
		try
		{
			using var context = new AppDbContext();
			foreach (var employee in context.Employees.Where(employee => !employee.IsResigned))
				Console.WriteLine($"{employee.Name} - {employee.Salary}");

			var employeeToAdd = new Employee { Name = "E", Salary = 40000, Department = "HR", Experience = 1 };
			context.Employees.Add(employeeToAdd);
			context.SaveChanges();

			var found = context.Employees.FirstOrDefault(employee => employee.Name == "E");
			if (found is not null) { found.Experience++; context.SaveChanges(); }

			var toDelete = context.Employees.Find(1);
			if (toDelete is not null) { context.Employees.Remove(toDelete); context.SaveChanges(); }
		}
		catch (Exception exception) when (exception is InvalidOperationException or Microsoft.Data.SqlClient.SqlException)
		{
			Console.WriteLine($"Database unavailable: {exception.Message}");
		}
	}
}
