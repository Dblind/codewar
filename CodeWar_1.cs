using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace codewar
{
    class programCode
    {
        static void BoardLine(string plasS = "")
        {
            System.Console.WriteLine(new string('-', 40) + plasS);
        }
        public static void Main()
        {
            PerfectPower.IsPerfectPower(8);
            System.Console.WriteLine(new string('-', 40));
            PerfectPower.IsPerfectPower(9);
            System.Console.WriteLine(new string('-', 40));
            PerfectPower.IsPerfectPower(16);
            System.Console.WriteLine(new string('-', 40));
            PerfectPower.IsPerfectPower(15);
            System.Console.WriteLine(new string('-', 40));
            PerfectPower.IsPerfectPower(0);
            System.Console.WriteLine(new string('-', 40) + "\n");

            BuyCar bc = new BuyCar();
            bc.BuyCarMain();
            BoardLine("Time");

            Stat statEx = new Stat();
            System.Console.WriteLine("Range: 01|01|18 Average: 01|38|05 Median: 01|32|34 (Expected)");
            System.Console.WriteLine(Stat.stat("01|15|59, 1|47|16, 01|17|20, 1|32|34, 2|17|17\n"));
            System.Console.WriteLine("Range: 00|31|17 Average: 02|26|18 Median: 02|22|00 (Expected)");
            System.Console.WriteLine(Stat.stat("02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|17|17, 2|22|00, 2|31|41"));
            System.Console.WriteLine("Range: 00|31|17 Average: 02|27|10 Median: 02|24|57 (Expected)");
            System.Console.WriteLine(Stat.stat("02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|32|34, 2|17|17"));
            System.Console.WriteLine("Range: 00|31|17 Average: 02|27|10 Median: 02|24|57 (Expected)");
            System.Console.WriteLine(Stat.stat(null));
            BoardLine("Mix");

            // System.Console.WriteLine("2:eeeee/2:yy/=:hh/=:rr  Expected");
            // System.Console.WriteLine(Mixing.Mix("Are they here", "yes, they are here"));
            // System.Console.WriteLine("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg  Expected: ");
            // System.Console.WriteLine(Mixing.Mix("looping is fun but dangerous", "less dangerous than coding"));
            // System.Console.WriteLine("1:ee/1:ll/1:oo  Expected: ");
            // System.Console.WriteLine(Mixing.Mix("Lords of the Fallen", "gamekult"));
            System.Console.WriteLine("1:cccc/2:vvv/2:www/1:kk/1:qq/1:xx/2:ll/2:ss/=:ff  Expected: ");
            System.Console.WriteLine(Mixing.Mix("Vwcnq2cgleRcxdrFpfck$xyfk.qmti", "3flda%vvbwAksji;wpwf(seor#xvcl"));

        }
    }

    public class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            //System.Console.WriteLine($"---{s1}\n---{s2}");
            if ((s1 == null && s1.Length == 0) || (s2 == null && s2.Length == 0)) return null;
            StringBuilder sB = new StringBuilder("");
            Dictionary<char, int> dictionaryS1 = new Dictionary<char, int>();
            Dictionary<char, int> dictionaryS2 = new Dictionary<char, int>();
            Dictionary<char, int> equalsLetter = new Dictionary<char, int>();
            int maxCapacity = 0;

            CreateAndSortTo1S2SEquals();
            for (int i = maxCapacity; i > 1; i--)
            {
                sB.Append(MakeBlockLetters(dictionaryS1, '1', i));
                sB.Append(MakeBlockLetters(dictionaryS2, '2', i));
                sB.Append(MakeBlockLetters(equalsLetter, '=', i));
            }
            if (sB.Length == 0) return null; else return sB.Remove(0, 1).ToString();

            void CreateAndSortTo1S2SEquals()
            {
                Dictionary<char, int> caseSwap1 = new Dictionary<char, int>();
                Dictionary<char, int> caseSwap2 = new Dictionary<char, int>();

                foreach (char e in s1)
                    if (e >= 'a' && e <= 'z')
                        if (dictionaryS1.ContainsKey(e)) { dictionaryS1[e]++; if (dictionaryS1[e] > maxCapacity) maxCapacity = dictionaryS1[e]; }
                        else dictionaryS1.Add(e, 1);
                foreach (char e in s2)
                    if (e >= 'a' && e <= 'z')
                        if (dictionaryS2.ContainsKey(e)) { dictionaryS2[e]++; if (dictionaryS2[e] > maxCapacity) maxCapacity = dictionaryS2[e]; }
                        else dictionaryS2.Add(e, 1);
                
                foreach (KeyValuePair<char, int> e in dictionaryS1) if (e.Value > 1) caseSwap1.Add(e.Key, e.Value);
                dictionaryS1 = caseSwap1; caseSwap1 = new Dictionary<char, int>();
                foreach (var e in dictionaryS2) if (e.Value > 1) caseSwap1.Add(e.Key, e.Value);
                dictionaryS2 = caseSwap1; caseSwap1 = new Dictionary<char, int>();

                foreach (var e in dictionaryS1)
                    if (dictionaryS2.ContainsKey(e.Key))
                        if (e.Value == dictionaryS2[e.Key]) equalsLetter.Add(e.Key, e.Value);
                        else if (e.Value > dictionaryS2[e.Key]) caseSwap1.Add(e.Key, dictionaryS1[e.Key]);
                        else caseSwap2.Add(e.Key, dictionaryS2[e.Key]);
                
                foreach (var e in equalsLetter)
                {
                    if (dictionaryS1.ContainsKey(e.Key)) dictionaryS1.Remove(e.Key);
                    if (dictionaryS2.ContainsKey(e.Key)) dictionaryS2.Remove(e.Key);
                }
                foreach (var e in caseSwap1)
                    if (dictionaryS2.ContainsKey(e.Key)) dictionaryS2.Remove(e.Key);
                foreach (var e in caseSwap2)
                    if (dictionaryS1.ContainsKey(e.Key)) dictionaryS1.Remove(e.Key);
            }

            string MakeBlockLetters(Dictionary<char, int> dict, char id, int i)
            {
                string strOutput = string.Empty;
                string str = string.Empty;
                foreach (var e in dict)
                {
                    if (e.Value == i) str += e.Key;
                }
                char ch;
                while (str.Length > 0)
                {
                    ch = str[0];
                    foreach (char e in str) if (e < ch) ch = e;
                    strOutput += $"/{id}:" + new string(ch, i);
                    str = str.Remove(str.IndexOf(ch), 1);
                }
                return strOutput;
            }

            #region  old


            // List<Pair> ListS1 = new List<Pair>();
            // List<Pair> ListS2 = new List<Pair>();
            // List<Pair> ListConcat = new List<Pair>();
            // foreach (var e in dictionaryS1)
            //     if (!equalsLetter.ContainsKey(e.Key)) caseSwap1.Add(e.Key, e.Value);
            // dictionaryS1 = caseSwap1; caseSwap1.Clear();
            // foreach (var e in dictionaryS2)
            //     if (!equalsLetter.ContainsKey(e.Key)) caseSwap1.Add(e.Key, e.Value);
            // dictionaryS2 = caseSwap1; caseSwap1.Clear();

            // foreach (var e in dictionaryS1)
            //     if (e.Value > 1) ListS1.Add(new Pair(e.Key, e.Value, '1'));
            // foreach (var e in dictionaryS2)
            //     if (e.Value > 1) ListS2.Add(new Pair(e.Key, e.Value, '2'));
            // foreach (var e in ListS1)
            //     foreach (var e2 in ListS2)
            //     {
            //         if (e.Letter == e2.Letter)
            //             if (e.Capacity == e2.Capacity) { e.Sourse = '='; ListConcat.Add(e); }
            //             else if (e.Capacity > e2.Capacity) { ListConcat.Add(e); }
            //             else { ListConcat.Add(e2); }
            //     }
            // List<Pair> ListEny = new List<Pair>();
            // foreach (var e in ListS2)
            // {
            //     bool flag = true;
            //     foreach (var e2 in ListConcat)
            //     {
            //         if (e.Letter == e2.Letter) { flag = false; break; }
            //     }
            //     if (flag) ListEny.Add(e);
            // }
            // foreach (var e in ListEny) ListConcat.Add(e);
            // ListEny.Clear();
            // foreach (var e in ListS1)
            // {
            //     bool flag = true;
            //     foreach (var e2 in ListConcat)
            //     {
            //         if (e.Letter == e2.Letter) { flag = false; break; }
            //     }
            //     if (flag) ListEny.Add(e);
            // }
            // foreach (var e in ListEny) ListConcat.Add(e);
            // foreach (var e in ListConcat) if (e.Capacity > maxCapacity) maxCapacity = e.Capacity;
            // ListEny.Clear();
            // for (int i = maxCapacity; i > 1; i--)
            // {
            //     ListEny = ListConcat.FindAll(delegate (Pair p) { return p.Capacity == i; });
            //     List<Pair> ListEny2 = ListEny.FindAll(delegate (Pair p) { return p.Sourse == '1'; });
            //     ListEny2.Sort(delegate (Pair p1, Pair p2) { return p1.Letter.CompareTo(p2.Letter); });
            //     foreach (var e in ListEny2)
            //     {
            //         sB.AppendFormat("/{0}:{1}", e.Sourse, new string(e.Letter, e.Capacity));
            //     }
            //     ListEny2 = ListEny.FindAll(delegate (Pair p) { return p.Sourse == '2'; });
            //     ListEny2.Sort(delegate (Pair p1, Pair p2) { return p1.Letter.CompareTo(p2.Letter); });
            //     foreach (var e in ListEny2)
            //     {
            //         sB.AppendFormat("/{0}:{1}", e.Sourse, new string(e.Letter, e.Capacity));
            //     }
            //     ListEny2 = ListEny.FindAll(delegate (Pair p) { return p.Sourse == '='; });
            //     ListEny2.Sort(delegate (Pair p1, Pair p2) { return p1.Letter.CompareTo(p2.Letter); });
            //     foreach (var e in ListEny2)
            //     {
            //         sB.AppendFormat("/{0}:{1}", e.Sourse, new string(e.Letter, e.Capacity));
            //     }
            // }
            // if (sB.Length > 0) sB.Remove(0, 1);
            // return sB.ToString();
            #endregion
        }

        class Pair
        {
            public char Letter { get; }
            public int Capacity { get; }
            public char Sourse { get; set; }
            public Pair(char l, int c, char s)
            {
                Letter = l;
                Capacity = c;
                Sourse = s;
            }
        }
    }
    public class Stat
    {
        public static string stat(string strg)
        {
            if (strg == null || strg == "") return string.Empty;
            int mediane, range, average = 0;
            List<DataTime> ListResultsRace = new List<DataTime>();

            foreach (string e in strg.Split(','))
                ListResultsRace.Add(new DataTime(e));
            ListResultsRace.Sort(delegate (DataTime dt, DataTime dt2) { return dt.TimeInSeconds.CompareTo(dt2.TimeInSeconds); });
            range = FindRange();
            average = FindAverage();
            mediane = FindMediane();

            return string.Format("Range: {0} Average: {1} Median: {2}",
                DataTime.FormatSecondsToHMS(range),
                DataTime.FormatSecondsToHMS(average),
                DataTime.FormatSecondsToHMS(mediane));

            #region SupportFunctions

            int FindRange()
            {
                int rangeMax = 0;
                ListResultsRace.ForEach(delegate (DataTime dt) { rangeMax = dt.TimeInSeconds > rangeMax ? dt.TimeInSeconds : rangeMax; });
                int rangeMin = rangeMax;
                ListResultsRace.ForEach(delegate (DataTime dt) { rangeMin = dt.TimeInSeconds < rangeMin ? dt.TimeInSeconds : rangeMin; });
                return rangeMax - rangeMin;
            }

            int FindMediane()
            {
                return ListResultsRace.Count % 2 == 1 ? ListResultsRace[ListResultsRace.Count / 2].TimeInSeconds :
                    (ListResultsRace[ListResultsRace.Count / 2 - 1].TimeInSeconds + ListResultsRace[ListResultsRace.Count / 2].TimeInSeconds) / 2;
            }

            int FindAverage()
            {
                ListResultsRace.ForEach(delegate (DataTime dt) { average += dt.TimeInSeconds; });
                return average / ListResultsRace.Count;
            }
            #endregion
        }
        class DataTime
        {
            public string TimeSentence { get; }
            public int[] HMS_ValuesTime { get; } = new int[3];
            public int TimeInSeconds { get; }
            public DataTime(string time)
            {
                TimeSentence = time.Trim();
                int counter = 0;
                foreach (string e in TimeSentence.Split('|'))
                    HMS_ValuesTime[counter++] = int.Parse(e);
                TimeInSeconds = 3600 * HMS_ValuesTime[0] + 60 * HMS_ValuesTime[1] + HMS_ValuesTime[2];
            }
            public static string FormatSecondsToHMS(int seconds)
            {
                return string.Format("{0:00}|{1:00}|{2:00}",
                    seconds / 3600, seconds % 3600 / 60, seconds % 60);
            }
        }
    }
    public class PerfectPower
    {/*
        static int max = 1;
        static StringBuilder sB = new StringBuilder();
        public static (int, int)? IsPerfectPower(int n)
        {
            System.Console.WriteLine($"value: {n}");
            if (n == 0) return null;
            max = (int)Math.Sqrt(n);
            int HalfN = n / 2 + 1;
            int result = 0;
            //recursionDivTwo(n);
            for (int down = max; down > 1; down--)
            {
                //sB.Clear();
                int up = 2;
                do
                {
                    result = (int)Math.Pow(down, up);
                    //sB.Append(string.Format("{0} ", result));
                    if (result == n)
                    {
                        //System.Console.WriteLine(sB.ToString());
                        //System.Console.WriteLine($"result: {down} {up}");
                        return (down, up);
                    }
                    up++;
                }
                while (result < HalfN);
                //System.Console.WriteLine(sB.ToString());
            }
            System.Console.WriteLine("return: null");
            return null;
        }
        static void recursionDivTwo(int n)
        {
            if (n > 1) recursionDivTwo(n / 2);
            max++;
        }*/

        static StringBuilder sB = new StringBuilder();
        public static (int, int)? IsPerfectPower(int n)
        {
            System.Console.Write($"\nvalue: {n}, ");
            if (n == 0) goto ReturnNull;
            int maxMult = (int)Math.Sqrt(n);
            System.Console.Write("MaxMult: " + maxMult + ", ");
            for (int down = maxMult; down > 1; down--)
            {
                int up = 0;
                int current = n;
                while (current % down == 0)
                {
                    up++;
                    current /= down;
                }
                if (current == 1)
                {
                    System.Console.WriteLine($"{down}^{up}");
                    return (down, up);
                }
            }
        ReturnNull:
            System.Console.WriteLine("return: null");
            return null;

        }
        //     public static (int, int)? IsPerfectPower(int n)
        //     {
        //         if (n == 0) return null;
        //         int maxMult = (int)Math.Sqrt(n);
        //         for (int down = maxMult; down > 1; down--)
        //         {
        //             if (n % down == 0)
        //             {
        //                 n /= down;
        //                 int up = 1;
        //                 while(n % down == 0)
        //                 {
        //                     up++;
        //                     n /= down;
        //                 }
        //                 return (down, up);
        //             }
        //         }
        //         return null;
        //     }
        // }
    }

    public class BuyCar
    {
        public static int[] nbMonths(int startPriceOld, int startPriceNew, int savingPerMonth, double percentLossByMonth)
        {
            bool isTwoMonth = false;
            double percents = 1 - percentLossByMonth / 100;
            int counterMonth = 0;
            int savingMoney = 0;
            double oldMinusPercents = startPriceOld;
            double newMinusPercents = startPriceNew;
            while (savingMoney + oldMinusPercents < newMinusPercents)
            {
                if (isTwoMonth)
                {
                    percents -= .005;
                    isTwoMonth = !isTwoMonth;
                }
                else isTwoMonth = !isTwoMonth;
                savingMoney += savingPerMonth;
                counterMonth++;
                oldMinusPercents = oldMinusPercents * percents;
                newMinusPercents = newMinusPercents * percents;
                System.Console.WriteLine($"{oldMinusPercents + savingMoney,-10:.####}: {newMinusPercents,-10:.####}: {percents}.");
            }
            System.Console.WriteLine("month: {0}, percents: {2}, division: {1}",
                        counterMonth, oldMinusPercents + savingMoney - newMinusPercents, percents);
            return new int[] { counterMonth, (int)Math.Round(oldMinusPercents + savingMoney - newMinusPercents) };
        }

        public void BuyCarMain()
        {
            nbMonths(2000, 8000, 1000, 1.5);
            System.Console.WriteLine("Expected: 6, 766.\n");
            nbMonths(12000, 8000, 1000, 1.5);
            System.Console.WriteLine("Expected: 0, 4000.\n");

        }
    }
}
