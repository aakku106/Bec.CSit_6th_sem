Console.WriteLine("Hello, Mater!");
int a = 3;

var b = a + a;
Console.WriteLine(b);

static int add(int a, int b)
{
    return a + b;
}

Console.WriteLine(add(5, 5));


hen.Wee arraarra = new hen.Wee("Master CCN");

// DAY2 
// ceating objects
day2.Laptop mac = new day2.Laptop();
day2.Laptop mac3 = new day2.Laptop("Mac book air m4", 16, "adsm22dds");
// giving value
mac.ramSize = 8;
mac.serialNum = "aakakaskdnjsf38009824";
mac.manufacturer = "Apple inc.";


// calling methods

day2.Laptop mac2 = new day2.Laptop(mac);
mac.DispplayDetails();
mac2.DispplayDetails();
mac3.DispplayDetails();


// static class
day2.Stds.Name = "Cat";
Console.WriteLine("/n/n" + day2.Stds.getName());




// ------- DAY 3--------------
day3.Std me = new day3.Std("Aakku", "106A", 3);
me.PrintColzDetails();
day3.Std another = new day3.Std("Ram", "10A", 3);
another.PrintColzDetails();
me.PrintStdDetails();
another.PrintStdDetails();
Console.WriteLine("Total std in Colz:\t" + me.getTotalStd());


// ENcapulation

day3.BankAccount myAcc = new day3.BankAccount();
myAcc.AccointHolder = "Aakku";
myAcc.AccountNumber = 106;
myAcc.DepositeMoney(100);
myAcc.DepositeMoney(100);
myAcc.WithdrawMoney(50);
Console.WriteLine("\n\nName:\t" + myAcc.AccointHolder + "\tAccNum:\t" + myAcc.AccountNumber + "\tBalance:\t" + myAcc.Balance + "\n\n");


namespace hen
{
    public class Wee
    {
        private string name;
        public Wee(string n)
        {
            name = "";
            setName(n);
            getName();
        }
        private void Suuu()
        {
            Console.WriteLine("aaaaaaaaaaawwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
        }
        private void setName(string n)
        {
            name = n;
        }
        private string getName()
        {
            return name;
        }
    }
}


namespace day2

//create a class laptop that includes:
// 1. Fields:
// - manufacturer (public; string)
// - ramSize(public; Int)
// -serieal numb (public; string)

//2. methods:
//showSpace()
//DisplayDetails()
//ShowManufacturer()
{
    public class Laptop
    {
        public string manufacturer;
        public int ramSize;
        public string serialNum;

        public Laptop()
        {
            manufacturer = "";
            ramSize = 0;
            serialNum = "";
        }
        public Laptop(string m, int r, string s)
        {
            manufacturer = m;
            ramSize = r;
            serialNum = s;
        }
        public Laptop(Laptop existingObj)
        {
            serialNum = existingObj.serialNum;
            ramSize = existingObj.ramSize;
            manufacturer = existingObj.manufacturer;
        }

        public void showSpace()
        {
            Console.WriteLine("Ram size:\t", ramSize);
        }
        public void DispplayDetails()
        {
            Console.WriteLine("\nManufuctur:\t" + manufacturer + "\nram size:\t" + ramSize + "\nserial number:\t" + serialNum);
        }
        public void Showmanufacturer()
        {
            Console.WriteLine("Manufuctur:", manufacturer);
        }
    }

    // Static example


    // No object, Only static menmber, No Inheratance ie sealed class

    public static class Stds
    {
        public static string Name;

        static Stds()
        {
            Name = "";
        }
        public static string getName()
        {
            return Name;
        }

    }
}


namespace day3
{
    // create class std
    // static field:
    // Schoolname string

    public class Std
    {
        static private string SchoolName;
        static private int TotalStudent;

        private string name, Id;
        private int GPA;

        static Std()
        {
            SchoolName = "Nepathys College";
            TotalStudent = 0;
            TotalStudent = 0;

            Console.WriteLine("Colz created as:\t" + SchoolName);
        }

        public Std()
        {
            name = "";
            Id = "";
            GPA = 0;
        }
        public Std(string name, string Id, int GPA)
        {
            this.name = name;
            this.Id = Id;
            this.GPA = GPA;
            TotalStudent++;
        }
        public void PrintColzDetails()
        {
            Console.WriteLine("School Name:\t" + SchoolName + "\tTotalNumOdStds:\t" + TotalStudent);
        }
        public void PrintStdDetails()
        {
            Console.WriteLine("Std name:\t" + name + "\tId:\t" + Id + "\tGPA:\t" + GPA);
        }
        public int getTotalStd()
        {
            return TotalStudent;
        }
    }

    // Enclupation Eg:
    public class BankAccount
    {
        private int accountNumber;
        private string accountName;
        private decimal balance;

        public BankAccount()
        {
            accountNumber = 0;
            accountName = "";
            balance = 0;
        }

        public string AccointHolder
        {
            get { return accountName; }
            set { accountName = value; }
        }
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public void DepositeMoney(decimal amount)
        {
            balance += amount;
        }
        public void WithdrawMoney(decimal amount)
        {
            balance -= amount;
        }
    }
}
