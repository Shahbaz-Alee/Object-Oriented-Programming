using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Square:Shape
    {
        private double side;
        public Square(double side)
        {
            this.side = side;
        }
        public override double getArea()
        {
            double area = Math.Pow(side, 2);
            return area;
        }
        public override string getShape()
        {
            return "Square";
        }
    }
}
