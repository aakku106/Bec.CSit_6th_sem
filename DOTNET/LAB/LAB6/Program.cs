using System;
using System.IO;

string directory = Path.Combine(AppContext.BaseDirectory, "NotesApp");
Directory.CreateDirectory(directory);
void CreateNote(string title, string content) => File.WriteAllText(Path.Combine(directory, title + ".txt"), content);
string ReadNote(string title) => File.ReadAllText(Path.Combine(directory, title + ".txt"));
void ListAllNotes()
{
	foreach (var file in Directory.GetFiles(directory, "*.txt"))
		Console.WriteLine(Path.GetFileNameWithoutExtension(file));
}

CreateNote("test", "Hello World");
Console.WriteLine(ReadNote("test"));
ListAllNotes();
File.Copy(Path.Combine(directory, "test.txt"), Path.Combine(directory, "test_copy.txt"), true);
File.Move(Path.Combine(directory, "test_copy.txt"), Path.Combine(directory, "test_renamed.txt"), true);
int lineNumber = 1;
foreach (var line in File.ReadLines(Path.Combine(directory, "test.txt")))
	Console.WriteLine($"{lineNumber++}: {line}");
File.Delete(Path.Combine(directory, "test_renamed.txt"));
