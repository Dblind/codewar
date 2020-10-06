/*
namespace codewar
{
    public class other
    {
        static void Main3(string[] args)
        {
            DateTime date = new DateTime(10000L);

            string string1 = new string('a', 20);
            Console.WriteLine(string1);
            // char[] chars = { 0x22, }
            sbyte[] bytes = { 0x22, 0x23, 0x24, 0x25 };
            string1 = DateTime.Now.ToString();
            System.Console.WriteLine(string1);
            string string2 = "aaaa bbbb cccc";
            int startIndex = string2.IndexOf(' ') + 1;
            string1 = string2.Substring(startIndex, string2.IndexOf(' ', startIndex) - startIndex);
            System.Console.WriteLine(string1);
            double d = 36.6;
            string string3 = string.Format("{0:t}, {0:d}, {1:F1}", date, d);
            System.Console.WriteLine(string3);
            StreamWriter sw = new StreamWriter(@"txts.txt");
            sw.WriteLine(string3); sw.GetType();
            sw.Close();

            char ch = 'c'; startIndex = 0x10041; string strT = Char.ConvertFromUtf32(startIndex);
            System.Console.WriteLine("{0:x}  {1}", startIndex, ch.CompareTo('C'));
            System.Console.WriteLine("{0}", ch.GetType()); int inta = (int)ch;

            System.Console.WriteLine(char.IsSurrogatePair(strT[0], strT[0]) + Char.ConvertFromUtf32(startIndex));
            for (int i = startIndex; i < startIndex + 100; i++)
            {
                System.Console.Write(char.ConvertFromUtf32(i) + ' ');
            }
            System.Console.WriteLine();
            string sJ = "aAThe sunset sets at twelve o' clock.";
            int first, last = 0;
            string toNumStr = sJ.ToLower();
            string NumsLetters = string.Empty;
            foreach (char letter in sJ)
            {
                if ('a' <= letter && letter <= 'z') NumsLetters = $"{NumsLetters} {(int)letter + 1 - 'a'}";
            }
            System.Console.WriteLine(NumsLetters);

            // public void ExampleTest3()
            // {
            //     long expected = 9;

            //     long actual = Kata.QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2);

            //     Assert.AreEqual(expected, actual);
            // }

            System.Console.WriteLine("1 " + QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2));
            System.Console.WriteLine("2 " + QueueTime(new int[] { }, 2));
            System.Console.WriteLine("3 " + QueueTime(new int[] { 1 }, 2));
            System.Console.WriteLine("4 " + QueueTime(new int[] { 2, 3, 6 }, 4));
            System.Console.WriteLine("5 " + QueueTime(new int[] { 2, 3, 4 }, 2));
            //public static long QueueTime(int[] customers, int n)
            static int QueueTime(int[] customers, int n)
            {
                if (customers.Length < 1) return 0;
                else if (customers.Length == 1) return customers[0];
                else if (customers.Length <= n) return FindBigger(customers);
                else
                {
                    int[] tillsArr = new int[n];
                    for (int i = 0; i < tillsArr.Length; i++) tillsArr[i] = customers[i];
                    for (int i = tillsArr.Length; i < customers.Length; i++)
                    {
                        tillsArr[FindSmall(tillsArr)] += customers[i];
                    }
                    return FindBigger(tillsArr);
                }

                int FindSmall(int[] arr)
                {
                    int index = 0;
                    int var = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (var > arr[i]) { var = arr[i]; index = i; }
                    }
                    return index;
                }
                int FindBigger(int[] arr)
                {
                    int var = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (var < arr[i]) var = arr[i];
                    }
                    return var;
                }
            }
            static int CountSmileys(string[] smileys)
            {
                int counter = 0;
                foreach (string str in smileys)
                {
                    // if ((str.Contains(';') || str.Contains(':')) &&
                    //       (str.Contains('D') || str.Contains(')'))) counter++;
                    // if ((str.IndexOf(';') > -1 || str.IndexOf(':') > -1) &&
                    //       (str.IndexOf('D') > -1 || str.IndexOf(')') > -1)) counter++;
                    if ((str.StartsWith(':') || str.StartsWith(';')) && (str.EndsWith(')') || str.EndsWith('D'))) counter++;
                }
                return counter;
            }
            System.Console.WriteLine("=~D");
            System.Console.WriteLine("4 " + CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
            System.Console.WriteLine("2 " + CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
            System.Console.WriteLine("1 " + CountSmileys(new string[] { "8-(", "8(", ";)", "~P", "8~)", "8(" }));
            System.Console.WriteLine("0 " + CountSmileys(new string[] { ":~P", ":P" }));
            System.Console.WriteLine("1 " + CountSmileys(new string[] { "8(", "-(", "8P", ":~)", "8 )", "8-D", "P", "-P", ":-P" }));
            System.Console.WriteLine("0 " + CountSmileys(new string[] {  }));


            // Assert.AreEqual(4, Kata.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
            // Assert.AreEqual(2, Kata.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
            System.Console.WriteLine("----------");
            static int[] ArrayDiff(int[] a, int[] b)
            {
                // Your brilliant solution goes here
                // It's possible to pass random tests in about a second ;)
                List<int> list = new List<int>();
                foreach (var e in a)
                {
                    bool dontHave = true;
                    //for (int i = 0; i < b.Length; i++) if (e == b[i]) { dontHave = false; break; }
                    foreach (var h in b)
                    {
                        if (e == h)
                        {
                            dontHave = false;
                            break;
                        }
                    }
                    if (dontHave) list.Add(e);
                }
                return list.ToArray();
            }
            int[] arr = ArrayDiff(new int[] { 1, 2, 3, 4 }, new int[] { 2, 4 });
            foreach (int e in arr) System.Console.WriteLine(e);
            System.Console.WriteLine();
            arr = ArrayDiff(new int[] { }, new int[] { 2, 4 });
            foreach (int e in arr) System.Console.WriteLine(e);
            System.Console.WriteLine();
            arr = ArrayDiff(new int[] { 1, 2, 3, 4 }, new int[] { });
            foreach (int e in arr) System.Console.WriteLine(e);
            System.Console.WriteLine("---------------------------");

            static int find_it(int[] seq)
            {
                for (int ii = 0; ii < seq.Length; ii++)
                {
                    int odd = 0;
                    for (int inside = 0; inside < seq.Length; inside++) if (seq[ii] == seq[inside]) odd++;
                    if (odd % 2 == 1) return seq[ii];
                }
                return 0;
            }
            //5 
            // int ff = find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 });
            // System.Console.WriteLine(ff);
            // ff = find_it(new[] { 20, 20, 11, 11, 111 });
            // System.Console.WriteLine(ff);
            // System.Console.WriteLine("-------------------");
            // ff = test2.MaxSequence(new int[] { -100, 3, 4 });
            // System.Console.WriteLine(ff);
            // ff = test2.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            // System.Console.WriteLine(ff);
            // ff = test2.MaxSequence(new int[] { 291, 305, 324, 330, 336, 350, 369, 375, 389, 408, 414 });
            // System.Console.WriteLine(ff);

            System.Console.WriteLine(Kata.GetLongestPalindrome("aabcac"));

        }
    }
}
*/