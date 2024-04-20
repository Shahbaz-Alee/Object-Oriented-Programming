using ConsoleApp3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.DL
{
    internal class StudentCRUD
    {
        public static bool check()
        {

            Console.WriteLine("ID");
            string ID = Console.ReadLine();
            Console.WriteLine("Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Age");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("MathsMarks");
            int MathsMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("PhysicsMarks");
            int PhysicsMarks = int.Parse(Console.ReadLine());
            Scholarship scholarship = new Scholarship(ID, Name, Age, MathsMarks,PhysicsMarks);
            if (MathsMarks + PhysicsMarks > 50)
            {
                return true;
            }
            else
                return false;
            
        }
       public static void displaySum()
        {
            Console.WriteLine("ID");
            string ID = Console.ReadLine();
            Console.WriteLine("Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Age");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("MathsMarks");
            int MathsMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("PhysicsMarks");
            int PhysicsMarks = int.Parse(Console.ReadLine());
            Scholarship scholarship = new Scholarship(ID, Name, Age, MathsMarks, PhysicsMarks);
            Console.WriteLine(scholarship.sum()); 
        }
    }
}
