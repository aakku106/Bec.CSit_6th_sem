namespace AfterKtm
{
    internal class @delegate
    {
        public void run()
        {

            greet();
            sum();
            Area();
            number();
            multiple();

        }

        public void greet()
        {
            Action<string> greet = delegate (string name)
            {
                Console.WriteLine($"hey {name} thats me ");
            };
            greet("sanjita");
        }
        public void sum()
        {
            Func<int, int, int> add = delegate (int a, int b) { return a + b; };
            int result = add(5, 20);
            Console.WriteLine(result);
        }
        public void Area()
        {
            Func<double, double, double> rectangle = delegate (double a, double b) { return a * b; };
            double totalArea = rectangle(5, 4);
            Console.WriteLine(totalArea);
        }
        public void number()
        {
            Func<int, bool> check = delegate (int a) { return a % 2 == 0; };
            bool checkd = check(5);
            Console.WriteLine(checkd);

        }
        public void multiple()
        {
            Predicate<int> multiple = delegate (int a) { return a % 5 == 0; };
            bool multipled = multiple(5);
            Console.WriteLine(multipled);
        }
    }
}
