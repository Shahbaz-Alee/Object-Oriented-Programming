using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ShapeUI
    {
        public static void showAreas(List<Shape> shapesList)
        {
            string message;
            for (int idx = 0; idx < shapesList.Count; idx++)
            {
                message = "The shape is {0} and its area is {1}";
                message = (idx + 1) + "." + message;
                Shape s = shapesList[idx];
                Console.WriteLine(message, s.getShape(), s.getArea());
            }
        }
    }
}
