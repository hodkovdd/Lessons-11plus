using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_5
{
    class PointDescription
    {
        public string Name { get; set; }
        public PointDescription()
        {

        }
    }

    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription pointDesc = new PointDescription(); 
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return String.Format("x = {0}, y = {1}, name = {2}", X, Y, pointDesc.Name);
        }

        public object Clone()
        {
            Point temp = new Point(this.X,this.Y);
            temp.pointDesc.Name = this.pointDesc.Name;
            return temp;
        }

        public object Clone2()
        {
            return this.MemberwiseClone();
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 5);
            p1.pointDesc.Name = "P1";
            Console.WriteLine(p1);
            Point p2 = p1.Clone() as Point;
            p2.pointDesc.Name = "P2";
            p2.X = 20;
            Console.WriteLine(p1);
            Console.ReadLine();
        }
    }
}
