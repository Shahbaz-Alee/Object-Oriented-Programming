using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double getArea()
        {
            double area = width * height;
            return area;
        }
        public override string getShape()
        {
            return "Rectangle";
        }
    }
}
