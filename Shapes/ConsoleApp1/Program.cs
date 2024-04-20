using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = RectangleUI.creatShape();
            ShapeDL.addIntoList(r);
            Circle c=CircleUI.creatShape();
            ShapeDL.addIntoList(c);
            Square s=SquareUI.creatShape();
            ShapeDL.addIntoList(s);
            Rectangle r1= RectangleUI.creatShape();
            ShapeDL.addIntoList(r1);
            Circle c1= CircleUI.creatShape();
            ShapeDL.addIntoList(c1);

            ShapeUI.showAreas(ShapeDL.getShapeList());
            Console.ReadKey();
        }
    }  
}




