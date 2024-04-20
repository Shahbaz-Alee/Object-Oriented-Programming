using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1();
            //task2();
            //task3();
            //task4();
            //task5();
            //task6();
            //task7();
            //task8();
            //task9();
            //task10();
            //task11();
            //task12();     //Self Assessment
            //task13();     //Self Assessment
        }
        public static void task1()
        {
            Console.Write("Hello world!");
            Console.Write("This is 2nd hello world!");
            Console.ReadLine();
        }

        static void task2()
        {
            Console.WriteLine("Hello World!");
            Console.Write("Hello World!");
            Console.ReadKey();
        }
        static void task3()
        {
            float length;
            float area;
            string str;
            Console.WriteLine("Length: ");
            str = Console.ReadLine();
            length = float.Parse(str);
            area = length * length;
            Console.WriteLine("Area:");
            Console.Write(area);
            Console.ReadKey();
        }
        static void task4()
        {
            string input;
            float marks;
            Console.Write("Marks:");
            input = Console.ReadLine();
            marks = float.Parse(input);
            if (marks > 50)
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            Console.ReadKey();
        }
        static void task5()
        {
            for (int x = 0; x < 5; x++)
            {
                Console.WriteLine("Welcome Jack!");

            }
            Console.ReadKey();
        }
        static void task6()
        {
            int num;
            int sum = 0;
            Console.Write("Number:");
            num = int.Parse(Console.ReadLine());
            while (num != 1)
            {
                sum = sum + num;
                Console.Write("Number:");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Total:" + sum);
            Console.ReadKey();
        }
        static void task7()
        {
            int num;
            int sum = 0;
            do
            {
                Console.Write("Number:");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            while (num != 1);
            sum = sum + 1;
            Console.WriteLine("Total:" + sum);
            Console.ReadKey();
        }
        static void task8()
        {
            int[] numbers = new int[3];
            for (int idx = 0; idx < 3; idx++)
            {
                Console.Write("Number:" + idx);
                numbers[idx] = int.Parse(Console.ReadLine());
            }
            int largest = -1;
            for (int idx = 0; idx < 3; idx++)
            {
                if (numbers[idx] > largest)
                {
                    largest = numbers[idx];
                }
            }
            Console.WriteLine("Largest is :" + largest);
            Console.Read();
        }
        static void task9()
        {
            int num1;
            int num2;
            Console.Write("1st Number:");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("2nd Number:");
            num2 = int.Parse(Console.ReadLine());
            int result = add(num1, num2);
            Console.WriteLine("Sum" + result);
            Console.Read();
        }
        static int add(int num1, int num2)
        {
            return num1 + num2;
        }
        static void task10()
        {
            string path = "D:\\1 UET\\Semester 2\\OOP\\Lab1\\textfile.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exist");
            }
            Console.ReadKey();
        }
        static void task11()
        {
            string path = "D:\\1 UET\\Semester 2\\OOP\\Lab1\\textfile.txt";
            StreamWriter filevariable = new StreamWriter(path, true);
            filevariable.WriteLine("HELLO!");
            filevariable.Flush();
            filevariable.Close();
            Console.ReadKey();
        }
        static void task12()
        {
            float machinePrice;
            float toyPrice;
            int age;
            Console.Write("Lilly Age:");
            age = int.Parse(Console.ReadLine());
            Console.Write("Machine Price:");
            machinePrice = float.Parse(Console.ReadLine());
            Console.Write("Price of each Toy:");
            toyPrice = float.Parse(Console.ReadLine());
            float result = calculateMoney(age, machinePrice, toyPrice);
            if (result > machinePrice)
            {
                float final = result - machinePrice;
                Console.WriteLine("Yes!!  " + final + "  left");
            }
            else
            {
                float final = machinePrice - result;
                Console.WriteLine("No!!  " + final + "  is sufficient");
            }
            Console.ReadKey();
        }
        static float calculateMoney(int age, float machinePrice, float toyPrice)
        {
            float totalMoney1 = 0;
            float totalMoney2 = 0;
            int count = 0;
            for (int x = 2; x <= age; x = x + 2)
            {
                count = count + 1;
                totalMoney2 = totalMoney2 + (10 * count);
            }
            for (int x = 1; x <= age; x = x + 2)
            {
                totalMoney2 = totalMoney2 + toyPrice;
            }
            float totalMoney3 = (totalMoney1 - count) + totalMoney2;
            return totalMoney3;
        }
        public static void task13()
        {
            string path = "D:\\1 UET\\Semester 2\\OOP\\Lab1\\textfile.txt";
            string[] names = new string[5];
            int uOrder;
            int uprice;
            int orders = 1;
            int orders1 = 1;
            int[] prices = new int[100];
            int[] price1 = new int[100];
            bool check = readdata(path, names, orders, orders1, prices, price1);
            if (check)
            {
                Console.Write("Enter No. of Order: ");
                uOrder = int.Parse(Console.ReadLine());
                Console.Write("Enter Minimum Price: ");
                uprice = int.Parse(Console.ReadLine());
                calculate(names, orders, orders1, prices, price1, uOrder, uprice);
            }

            Console.ReadKey();
        }

        static bool readdata(string path, string[] names, int orders, int orders1, int[] prices, int[] price1)
        {

            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                record = filevariable.ReadLine();
                names[0] = parseData(record, 1);
                orders = int.Parse(parseData(record, 2));
                int y = 0;

                for (int index = 3; index < 11; index++)
                {
                    prices[y] = int.Parse(parseData(record, index));
                    y++;
                }
                record = filevariable.ReadLine();
                names[1] = parseData(record, 1);
                orders1 = int.Parse(parseData(record, 2));
                int z = 0;
                for (int x = 3; x < 13; x++)
                {
                    price1[z] = int.Parse(parseData(record, x));
                    z++;
                }

                filevariable.Close();
                return true;
            }
            else
            {
                Console.WriteLine(" Not Exists");
                return false;
            }
        }
        static void calculate(string[] names, int orders, int orders1, int[] prices, int[] price1, int uOrder, int uprice)
        {
            int sum = 0;
            int ave = 0;
            for (int x = 0; x < uOrder; x++)
            {
                sum = sum + prices[x];
            }
            ave = sum / uOrder;
            if (ave > uprice)
            {
                Console.WriteLine(" " + names[0]);
            }
            int sum1 = 0;
            int ave1 = 0;

            for (int x = 0; x < uOrder; x++)
            {
                sum1 = sum1 + price1[x];
            }
            ave1 = sum1 / uOrder;
            if (ave1 > uprice)
            {
                Console.WriteLine(" " + names[1]);
            }
            else
            {
                Console.WriteLine("none");
            }
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
    }
}