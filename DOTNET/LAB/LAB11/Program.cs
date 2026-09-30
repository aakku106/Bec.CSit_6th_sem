using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;";

try
{
	await using var connection = new SqlConnection(connectionString);
	await connection.OpenAsync();

	await using var readCommand = new SqlCommand(
		"SELECT Name, Salary FROM Employee WHERE IsResigned = 0", connection);
	await using var reader = await readCommand.ExecuteReaderAsync();
	while (await reader.ReadAsync())
		Console.WriteLine($"{reader["Name"]} - {reader["Salary"]}");
	await reader.CloseAsync();

	await using var insertCommand = new SqlCommand(
		"INSERT INTO Employee (Name, Salary, Department, IsResigned, Experience) VALUES (@name, @salary, @department, @resigned, @experience)", connection);
	insertCommand.Parameters.AddWithValue("@name", "D");
	insertCommand.Parameters.AddWithValue("@salary", 45000m);
	insertCommand.Parameters.AddWithValue("@department", "IT");
	insertCommand.Parameters.AddWithValue("@resigned", false);
	insertCommand.Parameters.AddWithValue("@experience", 1);
	await insertCommand.ExecuteNonQueryAsync();
}
catch (SqlException exception)
{
	Console.WriteLine($"Database unavailable: {exception.Message}");
}
