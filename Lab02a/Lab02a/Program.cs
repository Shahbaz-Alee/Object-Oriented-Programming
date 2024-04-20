using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] s = new Student[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                }
                else if (option == '2')
                {
                    viewStudent(s, count);
                }
                else if (option == '3')
                {
                    topStudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            } while (option != '4');
            Console.WriteLine("Press Enter to exit");
            Console.Read();
        }
        public static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press 1 for Adding a student");
            Console.WriteLine("Press 2 for View a student");
            Console.WriteLine("Press 3 for Top three student");
            Console.WriteLine("Press 4 for Exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        public static Student addStudent()
        {
            Console.Clear();
            Student s = new Student();
            Console.WriteLine("name:");
            s.name = Console.ReadLine();
            Console.WriteLine("roll_num:");
            s.roll_num = int.Parse(Console.ReadLine());
            Console.WriteLine("cgpa:");
            s.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("department:");
            s.department = Console.ReadLine();
            Console.WriteLine("is hostallide(y|n)");
            s.isHostallide = char.Parse(Console.ReadLine());
            return s;
        }
        public static void viewStudent(Student[] s, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("name:" + s[i].name + "roll num:" + s[i].roll_num + "cgpa" + s[i].cgpa + "department" + s[i].department + "is hostallide:" + s[i].isHostallide);
            }
            Console.WriteLine("Press Any key to continue");
            Console.ReadKey();
        }
        public static void topStudent(Student[] s, int count)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("No Record");
            }
            else if (count == 1)
            {
                viewStudent(s, 1);
            }
            else if (count == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    int index = largest(s, i, count);
                    Student temp = s[index];
                    s[index] = s[i];
                    s[i] = temp;
                }
                viewStudent(s, 2);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    int index = largest(s, i, count);
                    Student temp = s[index];
                    s[index] = s[i];
                    s[i] = temp;
                }
                viewStudent(s, 3);
            }
        }
        public static int largest(Student[] s, int start, int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for (int x = start; x < end; x++)
            {
                if (large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
    }
}
