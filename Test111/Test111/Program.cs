using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*MUser user = new MUser();
            user.Muskan = 8;            
            Console.ReadKey();*/
            MUser user = new MUser();
            user.takeInput();
            
            Console.WriteLine("OK");
            
            Console.ReadKey();
        }

    }

    class MUser
    {
        /* protected int num;

         public int Muskan
         {
             set
             {
                 if (value > 30)
                 {
                     num = value;
                     Console.WriteLine("The number is " + num);
                 }
                 else
                 {
                     Console.WriteLine("Invalid Number");
                 }
             }
             get
             {
                 return num;
             }
         }
     }

     class Users : MUser
     {
         public void Print()
         {
             num = 40;
             Console.WriteLine("ALi");
         }
     }*/

        public string name;
        public int age;
        public float cgpa;
        static List<MUser> stu = new List<MUser>();
        public MUser takeInput()
        {
            Console.Write( "Name:");
            Console.ReadLine();
            Console.Write( "Age:");
            age=int.Parse(Console.ReadLine());
            Console.Write( "CGPA:");
            cgpa=float.Parse(Console.ReadLine());
            
            MUser user = new MUser();  
            return user;
        }
    }
}