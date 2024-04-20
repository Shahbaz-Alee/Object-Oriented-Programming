using ConsoleApp3.BL;
using ConsoleApp3.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*if(StudentCRUD.check()==true)
            {
                Console.WriteLine("Can Apply for Scholarship");
            }
            else
            { Console.WriteLine("Sorry Putter"); }
            Console.Clear();*/
            StudentCRUD.displaySum();
            Console.ReadKey();
        }
    }
}
