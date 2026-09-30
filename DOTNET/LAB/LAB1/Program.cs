using System;
using System.Collections.Generic;

enum AccType { Generic, Current, Saving, Business }

class BankAccount
{
	public static string BankName { get; } = "Global Trust Bank";
	public string AccountName { get; set; }
	public long AccountNumber { get; }
	protected decimal Balance { get; set; }
	public AccType AccountType { get; set; } = AccType.Generic;
	public bool IsActive { get; private set; } = true;
	private readonly List<string> history = [];
	public IReadOnlyList<string> TransactionHistory => history;

	public BankAccount(string accountName, long accountNumber)
	{
		AccountName = accountName;
		AccountNumber = accountNumber;
		history.Add("Account created: " + accountName);
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

class Program
{
	static void Main()
	{
		var account = new BankAccount("Ram", 101);
		account.Deposit(1000);
		account.Withdrawal(300);
		account.DisplayAccountInfo();
	}
}
