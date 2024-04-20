using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\1 UET\\Semester 2\\OOP\\Lab1\\name&password.txt";
            string[] names = new string[5];
            string[] passwords = new string[5];
            int option;
            do
            {
                readData(path, names, passwords);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Username: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    sigin(n, p, names, passwords);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter new name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter new password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);
            Console.ReadKey();
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Enter Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader newFile = new StreamReader(path);
                string record;
                while ((record = newFile.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                newFile.Close();
            }
            else
            {
                Console.WriteLine("Invalid Username or Password");
            }
        }
        static void sigin(string n, string p, string[] names, string[] passwords)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == names[x] && p == passwords[x])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid Username or Passwod");
                Console.WriteLine("Press any Key to Continue");
            }
            Console.ReadKey();
        }
        static void signUp(string path, string n, string p)
        {
            StreamWriter newFile = new StreamWriter(path, true);
            newFile.WriteLine(n + "," + p);
            newFile.Flush();
            newFile.Close();
        }


    }
}
