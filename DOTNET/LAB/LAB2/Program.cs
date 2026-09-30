using System;
using System.Collections.Generic;

enum AccType { Generic, Current, Saving, Business }

class BankAccount
{
	public string AccountName { get; set; }
	public long AccountNumber { get; }
	protected decimal Balance { get; set; }
	public AccType AccountType { get; set; } = AccType.Generic;
	private readonly List<string> history = [];

	public BankAccount(string name, long number)
	{
		AccountName = name;
		AccountNumber = number;
		history.Add("Account created: " + name);
	}

	public void Deposit(double amount)
	{
		if (amount <= 0) { Console.WriteLine("Invalid amount"); return; }
		Balance += (decimal)amount;
		history.Add("Deposited " + amount);
	}

	public void Withdrawal(double amount)
	{
		if (amount <= 0 || (decimal)amount > Balance) { Console.WriteLine("Invalid withdrawal"); return; }
		Balance -= (decimal)amount;
		history.Add("Withdrew " + amount);
	}

	public virtual void DisplayAccountInfo()
	{
		Console.WriteLine($"{AccountName} | {AccountNumber} | {AccountType} | Bal: {Balance}");
		foreach (var entry in history) Console.WriteLine(entry);
	}
}

class SavingsAccount(string name, long number) : BankAccount(name, number)
{
	public const double InterestRate = 0.04;
	public void ApplyInterest() => base.Deposit((double)Balance * InterestRate);
	public override void DisplayAccountInfo()
	{
		base.DisplayAccountInfo();
		Console.WriteLine($"Interest Rate: {InterestRate * 100}%");
	}
}

class Program
{
	static void Main()
	{
		BankAccount account = new SavingsAccount("Sita", 202);
		account.Deposit(5000);
		account.Withdrawal(1000);
		((SavingsAccount)account).ApplyInterest();
		account.DisplayAccountInfo();
	}
}
