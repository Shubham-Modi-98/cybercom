using System;

namespace MultiLevelInheritance
{
    class Shape
    {

        public double width;
        public double length;

        public Shape(double w, double l)
        {
            width = w;
            length = l;
        }

        public Shape(double y)
        {
            width = length = y;
        }
        public void DisplayDimension()
        {
            Console.WriteLine("Width and Length are {0} and {1}",width,length);
        }
    }

    class Rectangle : Shape
    {

        string style; 
        public Rectangle(string s, double w, double l) : base(w, l)
        {
            style = s;
        }

        public Rectangle(double y) : base(y)
        {
            style = "square";
        }

        public double Area()
        {
            return width * length;
        }
        public void DisplayStyle()
        {
            Console.WriteLine("Rectangle is {0}",style);
        }
    }

    class ColorRectangle : Rectangle
    {

        string rcolor;

        public ColorRectangle(string c, string s,double w, double l): base(s, w, l)
        {
            rcolor = c;
        }

        public void DisplayColor()
        {
            Console.WriteLine("Color is {0}",rcolor);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ColorRectangle r1 = new ColorRectangle("pink","Rectangle", 2.0, 3.236);

            ColorRectangle r2 = new ColorRectangle("black","Square", 4.0, 4.0);

            Console.WriteLine("Details of r1: ");
            r1.DisplayStyle();
            r1.DisplayDimension();
            r1.DisplayColor();

            Console.WriteLine("Area is " + r1.Area());
            Console.WriteLine();

            Console.WriteLine("Details of r2: ");
            r2.DisplayStyle();
            r2.DisplayDimension();
            r2.DisplayColor();

            Console.WriteLine("Area is " + r2.Area());
        }
    }
}
