using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08_Sol04_.BL.UI
{
    internal class ShapeUI
    {
        public static Shape createRectangle()
        {
            Console.WriteLine( "Enter width:");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine( "Enter height:");
            double height = double.Parse(Console.ReadLine());
            return new Rectangle(width, height);
        }
        public static Shape createSquare()
        {
            Console.WriteLine("Enter side:");
            double side=double.Parse(Console.ReadLine());
            return new Square(side);
        }
        public static Shape createCircle() 
        {
            Console.WriteLine("Enter radius:");
            double radius=double.Parse(Console.ReadLine());
            return new Circle(radius);
        }
    }
}
