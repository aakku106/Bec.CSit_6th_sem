using Microsoft.EntityFrameworkCore;

var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING")
    ?? "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

await using var db = new AppDbContext(connectionString);

try
{
    await db.Database.EnsureCreatedAsync();

    if (!await db.Students.AnyAsync())
    {
        db.Students.Add(new Student
        {
            Name = "Alice",
            Email = "alice@example.com"
        });

        await db.SaveChangesAsync();
    }

    Console.WriteLine("Students table is ready.");

    var students = await db.Students
        .OrderBy(student => student.Id)
        .ToListAsync();

    foreach (var student in students)
    {
        Console.WriteLine($"{student.Id}: {student.Name} ({student.Email})");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"PostgreSQL connection failed: {ex.Message}");
}

sealed class AppDbContext(string connectionString) : DbContext
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(connectionString);
}

sealed class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
