using System;
using System.Collections.Generic;

namespace OO16
{
    enum Color
    {
        Black,
        Blue,
        Red
    }
    abstract class Shape
    {
        public Color Color { get; set; }

        public Shape(Color color){
            Color = color;
        }

        public abstract double Area();
    }
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(Color color, double width, double height) : base(color)
        {
            Width = width;
            Height = height;
        }
        public override double Area()
        {
            return Width * Height;
        }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(Color color, double radius) : base(color)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * (Math.Pow(Radius, 2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Shape #" + (i + 1) + " data: ");
                Console.Write("Rectangle or Circle (r/c)? ");
                char op = char.Parse(Console.ReadLine());
                Console.Write("Color (Black/Blue/Red): ");
                Color color = Enum.Parse<Color>(Console.ReadLine());

                switch (op)
                {
                    case 'r':                        
                        Console.Write("Width: ");
                        double width = double.Parse(Console.ReadLine());
                        Console.Write("Height: ");
                        double height = double.Parse(Console.ReadLine());
                        shapes.Add(new Rectangle(color, width, height));
                        break;
                    case 'c':                        
                        Console.Write("Radius: ");
                        double radius = double.Parse(Console.ReadLine());
                        shapes.Add(new Circle(color, radius));
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            }

            Console.WriteLine("\nSHAPE AREAS: ");
            foreach(Shape obj in shapes){
                Console.WriteLine(obj.Area());
            }
        }
    }
}