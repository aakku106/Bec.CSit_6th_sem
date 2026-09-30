using System;

public delegate void MessageHandler();

class Program
{
	static void ShowWelcome() => Console.WriteLine("Welcome!");
	static void ShowGoodbye() => Console.WriteLine("Goodbye!");

	static void Main()
	{
		MessageHandler handler = ShowWelcome;
		handler();
		handler += ShowGoodbye;
		handler();
		handler -= ShowWelcome;
		handler();
	}
}
