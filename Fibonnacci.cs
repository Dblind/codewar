using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace codewar
{
    public class FibonnacciSequences
    {
        static List<int> fibonacci;
        static FibonnacciSequences()
        {
            fibonacci = new List<int>();
            fibonacci.Add(1); fibonacci.Add(1);
            for (int i = 3; i < 30; i++)
            {
                fibonacci.Add(fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2]);
            }
        }
        static public IEnumerable<int> Fibonacci
        {
            get { return new FibonnacciSequencesI(); }
        }
    }

    class FibonnacciSequencesI : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            //return new FibonacciEnumerator();
            int current = 1, previous = 1;
            yield return 1;
            yield return 1;
            while (true)
            {
                var newValue = current + previous;
                previous = current;
                current = newValue;
                yield return current;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class FibonacciEnumerator : IEnumerator<int>
    {
        int currentIndex = 1;
        int currentValue = 0;
        int previousValue = 1;

       public int Current
        {
            get
            {
                //if (currentIndex == 0 || currentIndex == 1) return 1;
                return currentValue;
            }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            currentIndex++;
            var newValue = currentValue + previousValue;
            previousValue = currentValue;
            currentValue = newValue;
            return true;
        }

        public void Reset()
        {
            //throw new NotImplementedException();
        }
    }

    public class program
    {
        public static void MainFF()
        {
            var fibonacci = new FibonnacciSequences();
            foreach (var e in FibonnacciSequences.Fibonacci)
            {
                System.Console.WriteLine(e);
                Thread.Sleep(100);
                if (Console.KeyAvailable) break;
            }
        }
    }
}