using Demo.bl.DI;
using System;
using System.Collections.Generic;
using System.IO;

namespace Demo.bl.UI
{
    class UI
    {
        public static void check(List<MUser> users, string dataPath, List<Offer> offers, string OfferPath)
        {

            bool check = AdminCRUD.readData(dataPath, users) && OfferCRUD.readData(OfferPath, offers);
            if (check)
            {
                Console.WriteLine("Data Loaded SuccessFully");
            }

            else
            {
                Console.WriteLine("Data Not Loaded");
            }
            Console.WriteLine("Press Any Key To Continue".ToUpper());
            Console.ReadKey();
        }

        public static int menu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            header();
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. EXIT");
            Console.Write("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        public static void header()
        {
            string path = @"C:\Users\T L S\Desktop\Workspace\UNI-Work\OOP\Coding\New folder\Demo\Demo\bin\Debug\headerfile.txt";

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
        public static void welcome()
        {  
            Console.WriteLine("Welcome Back " + MUser.adminName+"\n");         
        }
        public static int adminMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
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
            Console.Write("Enter Option: ");
            int adminNum = int.Parse(Console.ReadLine());
            return adminNum;
        }
        public static void printBalance(AddBalance bal, MUser user)
        {

            Console.WriteLine("CUSTOMER: " + user.name);
            Console.WriteLine("Balance: " + bal.balance);
            Console.WriteLine("\nPress Any Key To Continue".ToUpper());
            Console.ReadKey();
        }
        public static void printGiveLoan(AddBalance bal)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Congratulations! You have given 30 rupees".ToUpper());
            bal.balance = bal.balance + 30;
            Console.WriteLine("Press Any Key To Continue".ToUpper());
        }
        public static void recharge(AddBalance bal)
        {
            customerHeader();
            Console.Write("\nEnter amount you want to recharge:");
            float amount = float.Parse(Console.ReadLine());
            Console.Write("Enter Credit Card Number:");
            string creditCard = Console.ReadLine();
            CustomerCRUD.balanceRecharge(bal, creditCard, amount);

        }
        public static int CustomerMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Main menu");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1.Check Balance");
            Console.WriteLine("2.Recharge");
            Console.WriteLine("3.Loan");
            Console.WriteLine("4.Call Offers");
            Console.WriteLine("5.SMS Offers");
            Console.WriteLine("6.Internet Offers");
            Console.WriteLine("7.Play & Win");
            Console.WriteLine("8.FAQs");
            Console.WriteLine("9.Feedback");
            Console.WriteLine("10.Back");
            Console.Write("Enter Option: ");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        public static void adminHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string path = @"C:\Users\T L S\Desktop\Workspace\UNI-Work\OOP\Coding\New folder\Demo\Demo\bin\Debug\adminHeader.txt";
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
        public static void customerHeader()
        {
            string path = @"C:\Users\T L S\Desktop\Workspace\UNI-Work\OOP\Coding\New folder\Demo\Demo\bin\Debug\customerHeader.txt";
            StreamReader customerHeaderReader = new StreamReader(path);

            // Read the contents of the file and print them to the console
            while (!customerHeaderReader.EndOfStream)
            {
                string line = customerHeaderReader.ReadLine();
                Console.WriteLine(line);
            }
            // Close the StreamReader object to release resources
            customerHeaderReader.Close();
        }
        public static void printOfferList(List<Offer> offers)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Offer NAME " + "\t" + "Type" + "\t" + "Spec" + "\t" + "Price");
            foreach (Offer offer in offers)
            {
                Console.WriteLine("   " + offer.offerName + "\t\t" + offer.offerType + "\t" + offer.offerSpec + "\t" + offer.offerPrice);
            }
            Console.Write("Enter Offer Name you want to activate:");
            string newOffer = Console.ReadLine();
            newOffer = newOffer.ToUpper();
            foreach(Offer offer in offers)
            {
                if(newOffer==offer.offerName)
                {
                    Console.WriteLine( "Offer Activated".ToUpper());
                }
                else
                {
                    Console.WriteLine( "Offer does not exist!".ToUpper());
                }
            }
        }
        public static void displayCallOffer(string OfferPath, string targetOfferType)
        {
            List<Offer> offers = OfferCRUD.getOffersByType(OfferPath, targetOfferType);

            // Display the retrieved offers
            printOfferList(offers);
            

            Console.WriteLine("Press any key to continue....".ToUpper());
            Console.ReadKey();

        }
        public static void giftMbs()
        {
            Console.Write("Enter customer name:");
            string customerName = Console.ReadLine();
            Console.Write("Enter MBs you want to gift:");
            string mbs = Console.ReadLine();
            Console.Clear();
            adminHeader();
            Console.WriteLine(mbs + " MBs have been gifted to " + customerName);
            Console.ReadKey();
        }
        public static void faqs()
        {
            Console.Clear();
            adminHeader();
            Console.WriteLine("Q1: What are mobile services packages?");
            Console.WriteLine("Q2: What does a typical mobile services package include?");
            Console.WriteLine("Q3: What should I do if I have issues or questions regarding my mobile services package?");

            string num = CustomerCRUD.faqOption();
            Console.Clear();
            if (num == "1")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("MOBILE SEVICES PACKAGES");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Mobile services packages refer to bundled offerings provided by mobile service\nproviders that include various services such as voice calls, text messages,\nmobile data, and additional features.");
                Console.ReadKey();
            }
            if (num == "2")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("TYPICAL MOBILE SERVICES APP INCLUDE");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A typical mobile services package includes a combination of voice minutes, text messages,\nand mobile data. It may also include additional features such as international calling,\nroaming services, and access to value-added services like music streaming or video content.");
                Console.ReadKey();
            }
            if (num == "3")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("CUSTOMER'S SUPPORT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("If you have issues or questions regarding your mobile services package,\nyou should contact your mobile service provider's customer support. They can\nassist you with troubleshooting, billing inquiries, or any other concerns you may have.");
                Console.ReadKey();
            }
        }
    }
}
