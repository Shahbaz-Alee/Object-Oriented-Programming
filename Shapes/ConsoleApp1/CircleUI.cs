using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CircleUI
    {
        public static Circle creatShape()
        {
            Console.Write("Enter Radius:");
            double radius = double.Parse(Console.ReadLine());
            Circle c = new Circle(radius);
            return c;
        }
    }
}
