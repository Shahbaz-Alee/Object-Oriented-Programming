using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Shape
    {
        protected string shapeName;
        abstract public double getArea();
        abstract public string getShape();
    }
}
