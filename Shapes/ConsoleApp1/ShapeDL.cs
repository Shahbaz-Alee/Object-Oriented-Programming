using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ShapeDL
    {
        public static List<Shape> shapesList = new List<Shape>();
        public static void addIntoList(Shape shapes)
        {
            shapesList.Add(shapes);
        }
        public static List<Shape> getShapeList()
        {
            return shapesList;
        }
    }
}
