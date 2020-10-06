using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace codewar
{
    class ComparerSort
    {
        public static void MainTe()
        {
            System.Collections.Generic.List<Tests1> arrList = Tests1.GetListTests();
            //arrList.Sort(new TestsComparer());
            arrList.Sort(delegate (Tests1 x, Tests1 y) { return x.Name.CompareTo(y.Name); });
            ArrayList L = new ArrayList(); L.Sort();
            foreach (Tests1 e in arrList)
                System.Console.WriteLine(e.Name);
            Tests1 tests1 = new Tests1();
            // Tests2 tests2 = (Tests2) tests1;
            System.Console.WriteLine(new string('-', 30));

            Predicate<Tests1> deltest = delegate (Tests1 t) { return t.Price > 10; };
            List<Tests1> matches = arrList.FindAll(deltest);
            Action<Tests1> print = Console.WriteLine;
            matches.ForEach(print);
        }
    }
    public class Tests1 //: IComparer
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public static System.Collections.Generic.List<Tests1> GetListTests()
        {
            return new System.Collections.Generic.List<Tests1>{
                new Tests1() { Name = "name 4", Price = 1 },
                new Tests1() { Name = "name 3", Price = 11 },
                new Tests1() { Name = "name 1", Price = 221 }
            };
        }

        // public int Compare(object x, object y)
        // {
        //     Tests1 obj1 = (Tests1)x;
        //     Tests1 obj2 = (Tests1)y;
        //     return obj1.Price.CompareTo(obj2.Price);
        // }
    }
    class TestsComparer : System.Collections.Generic.IComparer<Tests1>
    {
        public int Compare(Tests1 x, Tests1 y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public class Tests2 : Tests1
    {
        public string[] Names = { "str" };
    }
}