

using System;
using System.Collections.Generic;
using System.Linq;

namespace codewar
{
    public class products
    {
        public static void Mainf()
        {
            List<Point> points = new List<Point>() {
                new Point { Name = "P22", X = 22, Y = 2, SupplierID = 22 },
                new Point { Name = "P2", X = 2, Y = 32, SupplierID = 22 },
                new Point { Name = "P1", X = 1, Y = 1, SupplierID = 314 } };

            //Predicate<Point> match = delegate (Point point) { return point.X >= point.Y; };
            //List<Point> pointsSort = points.FindAll(match);
            // foreach (Point p in points.FindAll(match))
            // {
            //     System.Console.WriteLine(p.ToString());
            // }
            Action<Point> ToStringsPoint = delegate (Point p) { System.Console.WriteLine("{0}\t{1}", p.X, p.Y); };
            points.FindAll(delegate (Point p) { return p.X > p.Y; }).ForEach(ToStringsPoint);
            System.Console.WriteLine(new string('=', 30));
            points.FindAll(delegate (Point p) { return p.X < p.Y; }).ForEach(ToStringsPoint);
            System.Console.WriteLine(new string('=', 30));
            points.FindAll(delegate (Point p) { return p.X >= p.Y; }).ForEach(ToStringsPoint);
            System.Console.WriteLine(new string('=', 30));

            Point nP = points.Find(n => n.X >= 2);
            IEnumerable<Point> LnP = points.Where(n => n.Y > n.X);
            List<Point> pointsWhere = new List<Point>();
            foreach (var e in LnP)
                pointsWhere.Add((Point)e);
            pointsWhere.ForEach(ToStringsPoint);

            System.Console.WriteLine(new string('-', 30));
            Action<Point> matchAction = delegate (Point p) { p.X *= (int)p.Y; };
            points.ForEach(matchAction);
            foreach (var e in points)
                System.Console.WriteLine(e.ToString());
            System.Console.WriteLine(new string('-', 40));

            //Null value int? decimal?
            int? Noint = 3; int? Eint = (int)Noint; Noint = 5; Eint = 6;
            points.Add(new Point() { Name = "P4", X = 4, Y = null, SupplierID = 314 });
            points.FindAll(delegate (Point p) { return p.Y.Equals(null); }).ForEach(Console.WriteLine);
            System.Console.WriteLine(new string('-', 40));


            var filtered = from Point e in points
                           where e.X > 2
                           select e;
            foreach (Point e in filtered)
                System.Console.WriteLine(e);
            System.Console.WriteLine(filtered.GetType());

            List<Supplier> suppliers = Supplier.GetSampleSuppliers();
            var filteredPS = from p in points
                             join s in suppliers
                             on p.SupplierID equals s.SupplierID
                             where p.X > 1
                             orderby s.Name, p.Name
                             select new { SupplierName = s.Name, PointName = p.Name };
            foreach (var e in filteredPS)
            System.Console.WriteLine("S-{0}, P-{1}", e.SupplierName, e.PointName);

        }
    }

    class Point
    {
        public string Name { get; set; } = "PName";
        public int SupplierID { get; set; }
        public int X { get; set; }
        decimal? y;
        public decimal? Y { get { return y; } set { y = value; } }

        public override string ToString()
        {
            return "X = " + X.ToString();
        }
    }
    class Supplier
    {
        public string Name { get; set; }
        public int SupplierID { get; set; }
        public static List<Supplier> GetSampleSuppliers()
        {
            return new List<Supplier> {
                new Supplier() { Name = "Rectangle", SupplierID = 22 },
                new Supplier() { Name = "Circle", SupplierID = 314 }
            };
        }
    }
}
