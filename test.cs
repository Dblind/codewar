namespace codewar
{
    /*   public class test
      {
          static int counter = 0;
          static int biggedSum = 0;
          public static int MaxSequence(int[] arr)
          {
              //TODO : create code
              //if (arr.Length == 0) ;
              //int[] subsets = arr;
              //int first = 0; int last = 0;
              int biggerSum = 0;
              Iteration(0, 0, arr);
              static void Iteration(int indexLeft, int indexRun, int[] arr)
              {
                  if (indexRun < arr.Length - 1) Iteration(indexLeft, 1 + indexRun, arr);
                  EqualsSubset(indexLeft, indexRun, arr);
                  if (indexLeft == indexRun && indexLeft < arr.Length - 1) Iteration(1 + indexLeft, 1 + indexRun, arr);
                  counter++;
              }
              static void EqualsSubset(int a, int b, int[] arr)
              {
                  int sum = 0;
                  for (int index = a; index <= b; index++)
                  {
                      sum = sum + arr[index];
                  }
                  System.Console.Write("{0} {1} - {2} : ", a + 1, b + 1, sum);
                  if (sum > biggedSum)
                  {
                      //first = a; last = b;
                      biggedSum = sum;
                      System.Console.WriteLine(sum);
                  }
                  else System.Console.WriteLine();
              }
              System.Console.WriteLine($" - - {biggedSum} - - , counter:{counter}");
              return biggedSum;
          }
          // maxSequence[-2, 1, -3, 4, -1, 2, 1, -5, 4]
          // -- should be 6: [4, -1, 2, 1]
      } */
    /* class test2
    {
        static int biggedSum = 0;
        public static int MaxSequence(int[] arr)
        {
            // Iteration(0, 0, arr);
            // void Iteration(int indexLeft, int indexRun, int[] arr)
            // {
            //     if (indexRun < arr.Length - 1) Iteration(indexLeft, 1 + indexRun, arr);
            //     EqualsSubset(indexLeft, indexRun, arr);
            //     if (indexLeft == indexRun && indexLeft < arr.Length - 1) Iteration(1 + indexLeft, 1 + indexRun, arr);
            // }
            // void EqualsSubset(int a, int b, int[] arr)
            // {
            //     int sum = 0;
            //     for (int index = a; index <= b; index++) sum = sum + arr[index];
            //     if (sum > biggedSum)
            //     {
            //         biggedSum = sum;
            //     }
            // }
            // return biggedSum;
        int maximum = 0, result = 0, sum = 0;
        foreach(var item in arr)
        {
            sum += item;
            maximum = sum > maximum ? maximum : sum;
            result = result > sum - maximum ? result : sum - maximum;
        }
        return result;
        }
    } */

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Kata
    {
        public static int GetLongestPalindrome(string str)
        {
            int lengthPolindrom = 0;
            for (int leftIndex = 0; leftIndex <= str.Length - lengthPolindrom; leftIndex++)
            {
                for (int rightIndex = str.Length - 1; rightIndex >= leftIndex + lengthPolindrom; rightIndex--)
                {
                    if (checkPolindrom(leftIndex, rightIndex, str)) lengthPolindrom = rightIndex - leftIndex + 1;
                }
            }
            return lengthPolindrom;
        }
        static bool checkPolindrom(int l, int r, string str)
        {
            while(l < r)
            {
                if (!str[l].Equals(str[r])) return false;
                l++; r--;
            }
            return true;
        }


    }

    /* using NUnit.Framework;
      using System;

      [TestFixture]
      public class SolutionTest
      {
        [TestCase("", ExpectedResult = 0, Description = "empty string test")]
        [TestCase(null, ExpectedResult = 0, Description = "'null' value test")]
        [TestCase("a", ExpectedResult = 1, Description = "'a' value test")]
        [TestCase("aa", ExpectedResult = 2, Description = "'aa' value test")]
        [TestCase("baa", ExpectedResult = 2, Description = "'baa' value test")]
        [TestCase("abc0cba1", ExpectedResult = 7, Description = "'abc0cba1' value test")]
        [TestCase("12 21glg", ExpectedResult = 5, Description = "'12 21glg' value test")]
        [TestCase("   ", ExpectedResult = 3, Description = "empty space test")]
        public int SampleTest(string str)
        {
          return Kata.GetLongestPalindrome(str);
        }
      } */

}

/*
291
305
324
330
336
350
369
375
389
408
414

exp 87

was 414
*/