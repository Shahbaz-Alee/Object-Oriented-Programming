using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessAppWithClassAndLink
{
    public class credentials
    {
        public string name;
        public string password;
    }
    public class customer_data
    {
        public int balance=0;
        public string feedback;
    }
    public class customer_offers
    {
        public string offer_name;
        public string offer_type;
        public int offer_price;
        public string offer_spec;
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = "credentials.txt";

            credentials cre = new credentials();
            List<credentials> user_data = new List<credentials>();

            //............................................................customer_data
            string path1 = "customer";
            customer_data cus = new customer_data();
            List<customer_data> info = new List<customer_data>();

            //..........................................................customer offers

            string pathOffers = "offers.txt";
            customer_offers offers = new customer_offers();
            List<customer_offers> offers_data = new List<customer_offers>();

            readData(path, user_data);
            readDataOffers(pathOffers, offers_data);

            int option;
            bool check = false;
            
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();

                    check = signIn(cre, n, p, user_data);
                    while (check == true)
                    {
                        if(n=="ali" && p=="123")
                        {
                            int adminOption;
                            adminOption = admin_menu();
                        if (adminOption == 1)
                        {
                            Console.WriteLine("Balance (Rs.): " + cus.balance);
                        }
                        else if (adminOption == 2)
                        {
                                giveLoan(cus);
                        }
                        else if (adminOption==3)
                            {
                                addingOffers(offers,offers_data);
                            }
                        else if (adminOption == 4)
                            {
                                removeOffer(offers, offers_data);
                            }
                        else if (adminOption == 5)
                            {
                                viewOffers(offers, offers_data);
                            }
                        else if (adminOption == 6)
                            {
                                updatingOffersPrice(offers_data);
                            }
                        else if (adminOption == 7)
                            {
                                giftMbs();
                            }
                        else if (adminOption == 8)
                            {
                                questions();
                                Console.Write("Choose Option:");
                                string choice = Console.ReadLine();
                                if (choice == "1")
                                {
                                    Console.WriteLine("This is a business applicaion.");
                                }
                                if (choice == "2")
                                {
                                    Console.WriteLine("This app will save your time and provide you an easy suscribtion to offers.");
                                }
                                if (choice == "3")
                                {
                                    Console.WriteLine("You can download this app from play store.");
                                }
                            }
                        else if (adminOption == 10)
                            {
                                deleteAccount(cre,user_data);
                            }
                            else if (adminOption == 11)
                            {
                                break;
                            }
                        }
                        
                    }
                }
                else if (option == 2)
                {
                    signUp(path, user_data);
                }
                else if (option == 3)
                {
                    offersSave(pathOffers, offers_data);
                }
                else if (option == 4)
                {
                    break;
                }
                
            } while (option < 4);
            Console.Read();
        }
        static int menu()
        {
            Console.Clear();
            int option;

            Console.WriteLine("1.  Sign in");
            Console.WriteLine("2.  Sign up");
            Console.WriteLine("3.  Save Data");
            Console.WriteLine("4.  Exit");
            Console.WriteLine("Enter option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static string parseData(string record, int field)
        {

            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void readData(string path, List<credentials> user_data)
        {
            int x = 0;
            StreamReader filevariable = new StreamReader(path);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                credentials cre = new credentials();
                cre.name = parseData(record, 1);
                cre.password = parseData(record, 2);
                x++;
                user_data.Add(cre);
                if (x >= user_data.Count())
                {
                    break;
                }
            }
            filevariable.Close();
        }
        static bool signIn(credentials cre, string n, string p, List<credentials> user_data)
        {
            Console.Clear();
            bool flag = false;
            for (int x = 0; x < user_data.Count(); x++)
            {
                if (n == user_data[x].name && p == user_data[x].password)
                {
                    Console.WriteLine("Valid user");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            return flag;
            Console.ReadKey();
        }
        static void signUp(string path, List<credentials> user_data)
        {
            Console.Clear();
            credentials cre = new credentials();
            Console.WriteLine("Enter New Name: ");
            cre.name = Console.ReadLine();
            Console.WriteLine("Enter New Password: ");
            cre.password = Console.ReadLine();
            user_data.Add(cre);

            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(cre.name + "," + cre.password);
            file.Flush();
            file.Close();
        }
        static int admin_menu()
        {
            Console.Clear();
            int op;
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
            op = int.Parse(Console.ReadLine());
            return op;
        }
        static int giveLoan(customer_data cus)
        {
            Console.WriteLine("Enter Amount Of Loan To Give: ");
            int bal = int.Parse(Console.ReadLine());
            cus.balance = cus.balance + bal;
            Console.WriteLine(bal + " rupees loan is given");
            return cus.balance;
        }
        static bool addingOffers(customer_offers offers, List<customer_offers> offers_data)
        {
            string option = "1";
            while (option != "0")
            {
                Console.Clear();
                offers = new customer_offers();
                Console.WriteLine("Enter offer name: ");
                offers.offer_name = Console.ReadLine();
                Console.WriteLine("Enter offer type: ");
                offers.offer_type = Console.ReadLine();
                Console.WriteLine("Enter offer Price: ");
                offers.offer_price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter offer specification: ");
                offers.offer_spec = Console.ReadLine();
                offers_data.Add(offers);
                Console.WriteLine("");
                Console.WriteLine("...........Offer added successfully..............");
                Console.WriteLine("");
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if (option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static bool removeOffer(customer_offers offers, List<customer_offers> offers_data)
        {
            string offerName;
            string offerType;
            int offerPrice;
            string offerSpec;
            bool check = false;
            string option = "1";
            while (option != "0")
            {
                Console.Clear();
                Console.WriteLine(" Enter offer name: ");
                offerName = Console.ReadLine();
                Console.WriteLine(" Enter offer type: ");
                offerType = Console.ReadLine();
                Console.WriteLine(" Enter offer Price: ");
                offerPrice = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter offer specification: ");
                offerSpec = Console.ReadLine();
                for (int i = 0; i < offers_data.Count(); i++)
                {
                    if (offers_data[i].offer_name == offerName && offers_data[i].offer_type == offerType && offers_data[i].offer_price == offerPrice && offers_data[i].offer_spec == offerSpec)
                    {
                        offers_data.RemoveAt(i);
                        check = true;
                    }
                }
                if (check == true)
                {
                    Console.WriteLine("...............Offer is removed Successfully");
                }
                else if (check == false)
                {
                    Console.WriteLine("...............Offer not found");
                }
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if (option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static void offersSave(string pathOffers, List<customer_offers> offers_data)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(pathOffers, true);
            for (int i = 0; i < offers_data.Count(); i++)
            {
                file.WriteLine(offers_data[i].offer_name + "," + offers_data[i].offer_type + "," + offers_data[i].offer_price + "," + offers_data[i].offer_spec);
            }
            file.Flush();
            file.Close();
        }
        static void readDataOffers(string pathOffers, List<customer_offers> offers_data)
        {
            int x = 0;
            StreamReader filevariable = new StreamReader(pathOffers);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                customer_offers offers = new customer_offers();
                offers.offer_name = parseData(record, 1);
                offers.offer_type = parseData(record, 2);
                offers.offer_price = int.Parse(parseData(record, 3));
                offers.offer_spec = parseData(record, 4);
                offers_data.Add(offers);
                x++;
                if (x >= offers_data.Count())
                {
                    break;
                }
            }
            filevariable.Close();
        }
        static bool viewOffers(customer_offers offers, List<customer_offers> offers_data)
        {
            string option = "1";
            while (option != "0")
            {
                Console.Clear();
                Console.WriteLine("Offer Name \t\t" + "Type \t\t" + "Price \t\t\t" + "Specification");

                for (int i = 0; i < offers_data.Count(); i++)
                {
                    Console.WriteLine(offers_data[i].offer_name + "\t\t" + offers_data[i].offer_type + "\t\t" + offers_data[i].offer_price + "\t\t" + offers_data[i].offer_spec);

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter 0 to exit.............");
                option = Console.ReadLine();

                if (option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static bool updatingOffersPrice(List<customer_offers> offers_data)
        {
            string offerName;
            string offerType;
            int offerPrice;
            int newOfferPrice;
            string offerSpec;
            bool flag = false;
            string option = "1";
            while (option != "0")
            {
                Console.Clear();
                Console.WriteLine(" Enter Offer name: ");
                offerName = Console.ReadLine();
                Console.WriteLine(" Enter Type: ");
                offerType = Console.ReadLine();
                Console.WriteLine(" Enter current offer Price: ");
                offerPrice = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter new offer Price: ");
                newOfferPrice = int.Parse(Console.ReadLine());
                for (int i = 0; i < offers_data.Count(); i++)
                {
                    if (offers_data[i].offer_name == offerName && offers_data[i].offer_type == offerType && offers_data[i].offer_price == offerPrice)
                    {
                        offers_data[i].offer_price = newOfferPrice;
                        Console.ReadLine();
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                    Console.WriteLine("Offer price updated ");
                if (flag == false)
                    Console.WriteLine("Offer not found");
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if (option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static bool giftMbs()
        {
            string option = "1";
            while (option != "0")
            {
                Console.Clear();
                Console.WriteLine("Enter Gift MBs:");
                Console.ReadLine();
                
                    Console.WriteLine("Operation Successful");
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if (option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static void questions()
        {
            Console.WriteLine("1.What kind of app is this?");
            Console.WriteLine("2.What are the benefits of this app?");
            Console.WriteLine("3.How can you download this app?");
        }
        static bool deleteAccount(credentials cre, List<credentials> user_data)
        {
            string check = "1";
            bool flag = false;
            string password;
            string name;

            while (check != "0")
            {
                Console.Clear();
                Console.WriteLine("Customer Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Customer Password: ");
                password = Console.ReadLine();
                for (int i = 0; i < user_data.Count(); i++)
                {
                    if (user_data[i].name == name && user_data[i].password == password)
                    {
                        user_data.RemoveAt(i);
                        flag = true;
                    }
                }
                Console.WriteLine("");
                if (flag == true)
                    Console.WriteLine("Customer is reomved ");
                else if (flag == false)
                    Console.WriteLine("Customer not found");
                Console.WriteLine("Press 0 to go back");
                check = Console.ReadLine();
                if (check == "0")
                {
                    break;
                }
            }
            return true;
        }
    }
}
