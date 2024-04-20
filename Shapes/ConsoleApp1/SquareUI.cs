using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SquareUI
    {
        public static Square creatShape()
        {
            Console.Write("Enter Side:");
            double side = double.Parse(Console.ReadLine());
            Square s = new Square(side);
            return s;
        }
    }
}
