using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08_Sol04_
{
    internal class Shape
    {
        public virtual double calculateArea()
        {
            double area = 0;
            return area;
        }
    }
    class Rectangle : Shape
    {
        public double width;
        public double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double calculateArea()
        {
            return width * height;
        }
    }
    class Square : Shape
    {
        public double side;
        public Square(double side)
        {
            this.side = side;
        }
        public override double calculateArea()
        {
            return side * side;
        }
    }
    class Circle : Shape
    {
        public double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double calculateArea()
        {
            return 2*Math.PI*Math.Pow(radius, 2);
        }
    }

}
