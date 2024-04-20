using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class RectangleUI
    {
        public static Rectangle creatShape()
        {
            Console.Write("Width:");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height");
            double height = double.Parse(Console.ReadLine());
            Rectangle r = new Rectangle(width, height);
            return r;
        }
    }
}
