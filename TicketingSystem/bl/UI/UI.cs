using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TicketingSystem.bl.Dl;
namespace TicketingSystem.bl.UI
{
    class UI
    {
        public static void check(List<MUser> users, string dataPath)
        {

            bool check = AdminCRUD.readData(dataPath, users);
            if (check)
            {
                Console.WriteLine("Data Loaded SuccessFully");
            }

            else
            {
                Console.WriteLine("Data Not Loaded");
            }
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }

        public static int menu()
        {
            header();
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. EXIT");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        public static void header()
        {
            string path = @"D:\1 UET\Semester 2\OOP\New folder\TicketingSystem\bin\Debug\headerfile.txt";

            // Create a StreamReader object to read the contents of the file
            StreamReader headerReader = new StreamReader(path);

            // Read the contents of the file and print them to the console
            while (!headerReader.EndOfStream)
            {
                string line = headerReader.ReadLine();
                Console.WriteLine(line);
            }
            // Close the StreamReader object to release resources
            headerReader.Close();
        }
        public static int adminMenu()
        {
            Console.WriteLine("1.Check Customer's Balance:");
            Console.WriteLine("2.Give Loan:");
            Console.WriteLine("3.Add Offers:");
            Console.WriteLine("4.Remove Offers");
            Console.WriteLine("5.View Offer List:");
            Console.WriteLine("6.Add Sale On Offers:");
            Console.WriteLine("7.Gift MBs To Customers:");
            Console.WriteLine("8.See FAQs:");
            Console.WriteLine("9.View Feedback:");
            Console.WriteLine("10.Delete Account:");
            Console.WriteLine("11.Logout:");
            Console.WriteLine("Enter Option: ");
            int adminNum = int.Parse(Console.ReadLine());
            return adminNum;
        }
        public static int CustomerMenu()
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1.Check Balance");
            Console.WriteLine("2.Recharge");
            Console.WriteLine("3.Loan");
            Console.WriteLine("4.Call Offers");
            Console.WriteLine("5.SMS Offers");
            Console.WriteLine("6.Internet Offers");
            Console.WriteLine("7.Sale Offers");
            Console.WriteLine("8.FAQs");
            Console.WriteLine("9.Feedback");
            Console.WriteLine("10.Back");
            Console.WriteLine("Enter Option: ");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        public static void adminHeader()
        {
            string path = @"D:\1 UET\Semester 2\OOP\New folder\TicketingSystem\bin\Debug\adminHeader.txt";
            StreamReader adminHeaderReader = new StreamReader(path);

            // Read the contents of the file and print them to the console
            while (!adminHeaderReader.EndOfStream)
            {
                string line = adminHeaderReader.ReadLine();
                Console.WriteLine(line);
            }
            // Close the StreamReader object to release resources
            adminHeaderReader.Close();
        }
    }

}
