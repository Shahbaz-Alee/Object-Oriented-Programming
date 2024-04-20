using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(rnd.Next(10));
            }
            Console.ReadKey();
        }
    }
}
