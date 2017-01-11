using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons_with_Yakov_11_
{
    class Interfaces
    {
        abstract class Figure
        {
            public int Width { get; set; }
            public int Hight { get; set; }
            public abstract int Area();
            public Figure(int width, int hight)
            {
                Width = width;
                Hight = hight;
            }
        }

        interface IRadius
        {
            int Radius();
        }

        class Rectangle : Figure
        {
            public Rectangle( int width, int hight) : base(width,hight)
            { }
            public override int Area()
            {
                return Width * Hight / 2;
            }
        }

         class Square : Figure
        {
            public Square(int width, int hight) : base(width,hight)
            { }
            public override int Area()
            {
                return Width * Width;
            }
        }

        class Circle : Figure, IRadius
        {
            public Circle(int width, int hight) : base(width, hight)
            { }
            public int Radius()
            {
                return (int)((Width + Hight) * 0.5);
            }
            public override int Area()
            {
                return (int)(Radius() * Radius() * 3.14);
            }

        }

        class Sphere : Figure, IRadius
        {
            
            public Sphere(int width, int hight) : base(width, hight)
            { }
            public override int Area()
            {
                return (int)(Radius() / 2);
            }
            public int Radius()
            {
                return (int)(3 * 3.14);
            }

        }
        
        static void RadiusCalc(IRadius figure)
        {
            Console.WriteLine(figure.GetType().Name);
            Console.WriteLine(figure.Radius());
        }

        static IRadius GetFigureIRadius(Figure[] figures)
        {
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] is IRadius)
                    return figures[i] as IRadius;
            }
            return null;
        }


        static void Main(string[] args)
        {
            Figure[] figures = { new Rectangle(1, 2), new Square(2, 3), new Circle(3, 4), new Sphere(4, 5) };
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] is IRadius)
                    RadiusCalc((IRadius)figures[i]);
            }
            Console.WriteLine();
            IRadius irad = GetFigureIRadius(figures);
            RadiusCalc(irad);
            Console.ReadLine();
        }
    }
}
