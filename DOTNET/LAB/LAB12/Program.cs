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
		options.UseSqlite("Data Source=CompanyDB.db");
}

class Program
{
	static void Main()
	{
		using var context = new AppDbContext();
		context.Database.EnsureCreated();
		Seed(context);

		Console.WriteLine("--- Read: active employees ---");
		foreach (var employee in context.Employees.Where(employee => !employee.IsResigned))
			Console.WriteLine($"{employee.Id}. {employee.Name} - {employee.Salary}");

		Console.WriteLine("--- Create ---");
		var employeeToAdd = new Employee { Name = "E", Salary = 40000, Department = "HR", IsResigned = false, Experience = 1 };
		context.Employees.Add(employeeToAdd);
		context.SaveChanges();
		Console.WriteLine($"Inserted #{employeeToAdd.Id} {employeeToAdd.Name} ({employeeToAdd.Department}, exp {employeeToAdd.Experience})");

		Console.WriteLine("--- Update ---");
		var found = context.Employees.FirstOrDefault(employee => employee.Name == "E");
		if (found is not null)
		{
			found.Experience++;
			context.SaveChanges();
			Console.WriteLine($"{found.Name} experience is now {found.Experience}");
		}

		Console.WriteLine("--- Delete ---");
		var toDelete = context.Employees.Find(employeeToAdd.Id);
		if (toDelete is not null)
		{
			context.Employees.Remove(toDelete);
			context.SaveChanges();
			Console.WriteLine($"Deleted #{toDelete.Id} {toDelete.Name}");
		}

		Console.WriteLine("--- Final employee list ---");
		foreach (var employee in context.Employees)
			Console.WriteLine($"{employee.Id}. {employee.Name} - {employee.Salary} - {employee.Department} - resigned:{employee.IsResigned} - exp:{employee.Experience}");
	}

	static void Seed(AppDbContext context)
	{
		if (context.Employees.Any()) return;

		context.Employees.AddRange(
			new Employee { Name = "A", Salary = 50000, Department = "IT", IsResigned = false, Experience = 2 },
			new Employee { Name = "B", Salary = 70000, Department = "HR", IsResigned = true, Experience = 0 },
			new Employee { Name = "C", Salary = 60000, Department = "IT", IsResigned = false, Experience = 3 });
		context.SaveChanges();
		Console.WriteLine("Seeded 3 sample employees.");
	}
}
