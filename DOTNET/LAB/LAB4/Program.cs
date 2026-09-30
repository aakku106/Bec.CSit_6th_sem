using System;
using System.Collections.Generic;

Action<List<string>> printAll = list => list.ForEach(Console.WriteLine);
printAll(["A", "B", "C"]);
Func<int, bool> isEven = number => number % 2 == 0;
Console.WriteLine(isEven(4));
Predicate<int> isMultipleOf5 = number => number % 5 == 0;
Console.WriteLine(isMultipleOf5(10));
