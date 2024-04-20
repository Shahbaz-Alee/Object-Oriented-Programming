using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double getArea()
        {
            double area = 2 * Math.PI * Math.Pow(radius, 2);
            return area;
        }
        public override string getShape()
        {
            return "Circle";
        }
    }
}
