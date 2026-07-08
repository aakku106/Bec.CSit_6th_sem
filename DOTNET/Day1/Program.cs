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

// ----------- DAY 4---------------

day4.Std kaka = new day4.Std("cat");
kaka.DisplayOnfo();

// Indexer

day4.StdHobbies sh = new day4.StdHobbies("adarasha");

sh[0] = "cricket";
sh[1] = "bat";
sh.DisplayDetails();

// ---------- DAY 5--------------

day5.EnumEg enumEg = new day5.EnumEg();
enumEg.Display();

// Struct

day5.Cat str = new day5.Cat("Orange", 2);
Console.WriteLine($"\n\tname: {str.getName()}");

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

namespace day4
{
    // class:std,
    // name,properties as mombers,
    // constructor1, takes name+grade,
    // c2, takes only name[set grade to Not assigned using constructor channing]
    // Method to display std info

    public class Std
    {
        private string name;
        private string grade;

        public Std(string name, string grade)
        {
            this.name = name;
            this.grade = grade;
        }
        public Std(string name) : this(name, "NotAssigned")
        {
            this.name = name;
        }
        public void DisplayOnfo()
        {
            Console.WriteLine($"Stdname:\t{name}, grage:\t{grade}");
        }
    }

    // Indexer

    public class StdHobbies
    {
        private string name;
        public StdHobbies(string name)
        {
            this.name = name;
        }

        private string[] hobbies = new string[10];
        public string this[int index]
        {
            get { return hobbies[index]; }
            set { hobbies[index] = value; }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"name:\t{name}");
            foreach (string a in hobbies)
            {
                Console.WriteLine($"\t{a}");
            }
        }
    }
}

namespace day5
{
    // Enum
    public class EnumEg
    {
        enum OrderStatus
        {
            Pending,
            Processing,
            Completed,
            Delevered
        }

        public void Display()
        {
            OrderStatus myOrderStatus = OrderStatus.Pending;
            int underlysingValue = (int)myOrderStatus;
            var type = Enum.GetUnderlyingType(typeof(OrderStatus));
            Console.WriteLine(underlysingValue + "\t" + type + "\t" + myOrderStatus + "\t" + OrderStatus.Completed + "\t" + ((int)OrderStatus.Completed));
        }
    }
    // struct Eg:

    public struct Cat
    {
        public string name;
        public int age;
        public string getName()
        {
            return name;
        }
        public Cat(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    };



}
