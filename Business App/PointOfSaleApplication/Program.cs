using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PointOfSaleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int usersCount = 0;  //This counter will count the user signing in

            string[] product = new string[5];
            int[] price = new int[5];
            string[] type = new string[5];
            string[] spec = new string[5];
            int productCount = 0;

            int balance=0;           //Balance of customer
            string customerName;     //Name of customer
            string customerPassword; //Password of customer
            string feedback;         //Read the feedback of customer from console
            string[] review = new string[5];


            char choice;

            ///////////////////////////FILE HANDLING/////////////////////
            
            string[] roles = new string[5]; //Role e.g.Admin or customer (For File Handling)
            string[] names = new string[5]; //Name of user (For File Handling)
            string[] pass = new string[5];  //Password of user (For File Handling)
            
            //Name Of files in which the data is stored
            string inventoryPath = "inventory.txt";
            string usersPath = "users.txt";        //File for CREDENTIALS
            string feedbackPath = "feedback.txt";  //File for feedback of customers

            readUserData(usersPath, names, pass, roles, ref usersCount);   //Load CREDENTIALS from respective files
            readProductData(inventoryPath, product, price, type,spec, ref productCount);
            
            do
            {
                choice = menu();
                clearScreen();
                if (choice == '1')
                {

                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    string who = logIn(n, p, names, pass, roles, usersCount);
                    
                    if (who == "admin")
                    {
                        int adminOption;
                        do
                        {
                            clearScreen();
                            adminOption = admin_menu();
                            clearScreen();
                            if (adminOption == 1)
                            {
                                Console.WriteLine("Balance (Rs.): " + balance);
                                
                            }
                            else if (adminOption == 2)
                            {
                                Console.WriteLine("Enter Amount Of Loan To Give: ");
                                int loan = giveLoan(ref balance);
                                Console.WriteLine("Loan is given");
                            }
                            else if (adminOption == 3)
                            {
                                Console.WriteLine("Enter Offer Name: ");
                                string newProduct = Console.ReadLine();
                                Console.WriteLine("Enter Price: ");
                                int newPrice = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Type: ");
                                string newType = Console.ReadLine();
                                Console.WriteLine("Enter Spefification: ");
                                string newSpec = Console.ReadLine();
                                addOffers(newProduct, newPrice, newType, newSpec, product, price, type, spec, ref productCount);
                            }
                            else if (adminOption == 4)
                            {
                                viewOffers(product, price, type, spec, productCount);
                                Console.WriteLine("Enter Offer Name you want to Delete: ");
                                string newProduct = Console.ReadLine();
                                deleteItem(newProduct, product, price, type, spec, ref productCount);
                            }
                            else if (adminOption == 5)
                            {
                                viewOffers(product, price, type, spec, productCount);
                            }
                            else if (adminOption == 6)
                            {
                                viewOffers(product, price, type, spec, productCount);
                                Console.WriteLine("Enter Product Name you want to Update: ");
                                string newProduct = Console.ReadLine();
                                updateItem(newProduct, product, price, type, spec, ref productCount);
                            }
                            else if (adminOption == 7)
                            {
                                giftMbs();
                            }
                            else if (adminOption == 8)
                            {
                                questions();
                                Console.Write("Choose Option:");
                                int option = int.Parse(Console.ReadLine());
                                if (option == 1)
                                {
                                    Console.WriteLine("This is a business applicaion.");
                                }
                                if (option == 2)
                                {
                                    Console.WriteLine("This app will save your time and provide you an easy suscribtion to offers.");
                                }
                                if (option == 3)
                                {
                                    Console.WriteLine("You can download this app from play store.");
                                }
                            }
                            else if (adminOption == 9)
                            {
                                viewFeedback(review, names, productCount);
                            }
                            else if(adminOption == 11)
                            {
                                break;
                            }
                        }
                        while (adminOption != 12);
                        clearScreen();

                    }
                    else if (who != "admin")
                    {
                        int userOption;
                        do
                        {
                            userOption = user_menu();
                            clearScreen();
                            if (userOption == 1)
                            {
                                Console.Write("Balance(Rs.):" + balance + " rupees");
                            }
                            else if (userOption == 2)
                            {
                                int creditCard;
                                Console.Write("Enter Credit Card Number: ");
                                creditCard = int.Parse(Console.ReadLine());
                                Console.Write("Amount: ");
                                int bal=recharge(ref balance);

                            }
                            else if (userOption == 3)
                            {
                                int bal = getLoan(ref balance);
                                Console.Write("You have successfully recieved Rs.25");
                            }

                            //This is the option for Call Offers
                            else if (userOption == 4)
                            {
                                Console.WriteLine("No." + '\t' + "Offer Name" + '\t' + '\t' + "Specification" +'\t'+ "Charges(Rs.)");
                                Console.WriteLine("1:" + '\t' + "Raat Din" + '\t'+'\t' + "1000 min"+ '\t' +"20");
                                Console.WriteLine("2:" + '\t' + "Yaari Offer" + '\t' + '\t' + "500 min" + '\t' + '\t' + "15");
                                Console.WriteLine("3:" + '\t' + "Call Now" + '\t' + '\t' + "120 min" + '\t' + '\t' + "30");
                                Console.Write("Choose Option: ");
                                int option = int.Parse(Console.ReadLine());
                                if (option == 1)
                                {
                                    if (balance >= 20)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 20;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                                if (option == 2)
                                {
                                    if (balance >= 15)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 15;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                                if (option == 3)
                                {
                                    if (balance >= 30)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 30;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                            }

                            //This is the option for SMS Offers
                            else if (userOption == 5)
                            {
                                Console.WriteLine("No." + '\t' + "Offer Name" + '\t' + "Specification" + '\t' + "Charges(Rs.)");
                                Console.WriteLine("1:" + '\t' + "Paygham" + '\t'+'\t' + "1000 SMS" + '\t' + "20");
                                Console.WriteLine("2:" + '\t' + "Chit Chat" + '\t' + "500 SMS" + '\t' + '\t' + "15");
                                Console.WriteLine("3:" + '\t' + "SMS Pro Offer" + '\t' + "120 SMS" + '\t' + '\t' + "30");
                                Console.Write("Choose Option: ");
                                int option = int.Parse(Console.ReadLine());
                                if (option == 1)
                                {
                                    if (balance >= 20)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 20;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                                if (option == 2)
                                {
                                    if (balance >= 15)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 15;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                                if (option == 3)
                                {
                                    if (balance >= 30)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 30;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                            }

                            //This is the option for Internet Offers
                            else if (userOption == 6)
                            {
                                Console.WriteLine("No." + '\t' + "Offer Name" + '\t' + "Specification"+ "Charges");
                                Console.WriteLine("1:" + '\t' + "Mega Net" + '\t' + "25 GB" + '\t'+'\t' + "20");
                                Console.WriteLine("2:" + '\t' + "Monthly Offer" + '\t' + "10 GB" + '\t' + '\t' + "15");
                                Console.WriteLine("3:" + '\t' + "Global" + '\t'+'\t' + "40 GB" + '\t' + '\t' + "30");
                                Console.Write("Choose Option: ");
                                int option = int.Parse(Console.ReadLine());
                                if (option == 1)
                                {
                                    if (balance >= 20)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 20;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                                if (option == 2)
                                {
                                    if (balance >= 15)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 15;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                                if (option == 3)
                                {
                                    if (balance >= 30)
                                    {
                                        Console.Write("Congratulations!!");
                                        balance = balance - 30;
                                    }
                                    else
                                    {
                                        Console.Write("Insufficient Balance :-(");
                                    }
                                }
                            }
                            else if (userOption == 7)
                            {
                                Console.WriteLine("No." + '\t' + "Offer Name" + '\t' + "Specification" + '\t' + "Discount");
                                Console.WriteLine("1:" + '\t' + "Mega Net" + '\t' + "25 GB" + '\t' + "120 rupee");
                                Console.WriteLine("2:" + '\t' + "Monthly Offer" + '\t' + "10 GB" + '\t' + "100 rupee");
                                Console.WriteLine("3:" + '\t' + "Global" + '\t' + "40 GB" + '\t' + "50 rupee");
                                Console.Write("Choose Option: ");
                                int option = int.Parse(Console.ReadLine());
                                if (option == 1 || option == 2 || option == 3)
                                {
                                    Console.Write("Congratulations!!");
                                }
                                else
                                {
                                    Console.Write("Invalid Option:");
                                }
                            }
                            else if (userOption == 8)
                            {
                                questions();
                                Console.Write("Choose Option:");
                                int option = int.Parse(Console.ReadLine());
                                if (option == 1)
                                {
                                    Console.WriteLine("This is a business applicaion.");
                                }
                                if (option == 2)
                                {
                                    Console.WriteLine("This app will save your time and provide you an easy suscribtion to offers.");
                                }
                                if (option == 3)
                                {
                                    Console.WriteLine("You can download this app from play store.");
                                }
                            }
                            else if (userOption == 9)
                            {
                                Console.Write("Feedback:");
                                feedback = Console.ReadLine();
                                
                                StreamWriter f1 = new StreamWriter(feedbackPath, false);
                                for (int x = 0; x < 1; x++)
                                {
                                    review[x] = feedback;
                                    f1.WriteLine(review[x]);
                                }
                                f1.Flush();
                                f1.Close();
                                Console.WriteLine("Thank You For Your Feedback");
                            }
                            else if (userOption== 10)
                            {
                                break;
                            }
                            clearScreen();
                        }
                        while (userOption != 11);
                    }
                    else
                    {
                        Console.WriteLine("Invalid User");
                        clearScreen();
                    }
                }
                else if (choice == '2')
                {
                    Console.Write("Enter name: ");
                    customerName = Console.ReadLine();
                    Console.Write("Enter password: ");
                    customerPassword = Console.ReadLine();

                    StreamWriter f1 = new StreamWriter(usersPath, true);
                    for (int x = 0; x < usersCount; x++)
                    {
                        names[x] = customerName;
                        pass[x] = customerPassword;
                        roles[x] ="customer";
                        f1.WriteLine(names[x] + "," + pass[x] + "," + roles[x]);
                    }
                    f1.Flush();
                    f1.Close();
                }
                else if ( choice == '3')
                {
                    break;
                }
                
                saveProductData(inventoryPath, product,price,type,spec, productCount);
            } while (choice != '4');
           
        }


        static void saveUserData(string usersPath , string[] names, string[] pass, string[] roles, int usersCount)
        {
            StreamWriter f1 = new StreamWriter(usersPath, false);
            for (int x = 1; x < usersCount; x++)
            {
                f1.WriteLine(names[x] + "," + pass[x] + "," + roles[x]);
            }
            f1.Flush();
            f1.Close();
        }
        static void saveProductData(string inventoryPath, string[] product, int[] price, string[] type,string[] spec, int productCount)
        {
            StreamWriter f1 = new StreamWriter(inventoryPath, false);
            for (int x = 0; x < productCount; x++)
            {
                f1.WriteLine(product[x] + "," + price[x] + "," + type[x] + "," + spec[x]);
            }
            f1.Flush();
            f1.Close();
        }


        static void viewOffers(string[] product, int[] price,string[] type,string[] spec, int productCount)
        {
            Console.WriteLine("Offer Name\t\tType\t\tPrice\t\tSpecification");
            for (int x = 0; x < productCount; x++)
            {
                Console.WriteLine(product[x] + "\t\t\t" + type[x] + "\t\t" + price[x] + "\t\t" + spec[x]);
            }
        }
        static void viewFeedback(string[] review, string[] names, int productCount)
        {

            string path = "D:\\1 UET\\Semester 2\\OOP\\PointOfSaleApplication(Updated1)\\PointOfSaleApplication\\bin\\Debug\\feedback.txt";
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();
            }
        }


        // update an item
        static void updateItem(string newProduct, string[] product, int [] price, string [] type,string [] spec, ref int productCount)
        {
            int idx = findProduct(newProduct, product, productCount);
            if (idx >= 0 && idx <= 4)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine("Enter the Updated charges");
                int newPrice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Updated specification: ");
                string newSpec = Console.ReadLine();
                price[idx] = newPrice;
                spec[idx] = newSpec;
            }
            else
            {
                clearScreen();
                Console.WriteLine("Product Does Not Exists.");
            }
        }


        static void deleteItem(string newProduct, string[] product, int[] price, string[] type,string[] spec, ref int productCount)
        {
            int idx = findProduct(newProduct, product, productCount);
            if (idx >= 0 && idx <= 4)
            {
                Console.WriteLine("Product Found");
                for (int x = idx; x < productCount - 1; x++)
                {
                    product[x] = product[x + 1];
                    price[x] = price[x + 1];
                    type[x] = type[x + 1];
                }
                productCount = productCount - 1;
            }
        }


        static int findProduct(string newProduct, string[] product, int productCount)
        {
            for (int x = 0; x < productCount; x++)
            {
                if (newProduct == product[x])
                {
                    return x;
                }
            }
            return -1;
        }


        // add an item
        static void addOffers(string newProduct, int newPrice, string newType,string newSpec, string [] product, int[] price, string[] type,string[] spec, ref int productCount)
        {
            if (productCount <= 4)
            {
                product[productCount] = newProduct;
                price[productCount] = newPrice;
                type[productCount] = newType;
                spec[productCount] = newSpec;
                productCount = productCount + 1;
            }
        }


        
    
        // separating credentials for storing in arrays individually
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


        // reading user file for storing data in arrays
        static void readUserData(string usersPath, string[] names, string[] pass, string[] roles, ref int usersCount)
        {
            StreamReader fp = new StreamReader(usersPath);
            string record;
            while ((record = fp.ReadLine()) != null)
            {
                if (usersCount > 4)
                {
                    break;
                }
                names[usersCount] = parseData(record, 1);
                pass[usersCount] = parseData(record, 2);
                roles[usersCount] = parseData(record, 3);
                usersCount = usersCount + 1;
            }
            fp.Close();
        }


        // reading product file for storing data in arrays
        static void readProductData(string inventoryPath, string[] product, int[] price, string[] type,string[] spec, ref int productCount)
        {
            StreamReader fp = new StreamReader(inventoryPath);
            string record;
            while ((record = fp.ReadLine()) != null)
            {
                if (productCount > 4)
                {
                    break;
                }
                product[productCount] = parseData(record, 1);
                price[productCount] = int.Parse(parseData(record, 2));
                type[productCount] = parseData(record, 3);
                spec[productCount] = parseData(record, 4);
                productCount = productCount + 1;
            }
            fp.Close();
        }


        //adding data of Users into user Arrays
        static void addUser(string newUser, string newPass, string newRole, string[] names, string[] pass, string[] roles, ref int usersCount)
        {
            if (newRole == "admin" || newRole == "customer")
            {
                if (usersCount <= 4)
                {
                    names[usersCount] = newUser;
                    pass[usersCount] = newPass;
                    roles[usersCount] = newRole;
                    usersCount = usersCount + 1;
                }
                else
                {
                    clearScreen();
                    Console.WriteLine("User Limit Exceeded.");
                }
            }
            else
            {
                clearScreen();
                Console.WriteLine("Invalid User type");
            }
        }


        // implementing login feature for admin and users
        static string logIn(string n, string p, string[] names, string[] pass, string[] roles, int usersCount)
        {
            string user_role;
            for (int x = 0; x < 1; x++)
            {
                if (n == names[0] && p == pass[0])
                {
                    user_role = roles[0];
                    return user_role;
                }
            }
            return "Wrong User";

        }

        //This is the SignUp and SignIn screen of this application
        static char menu()
        {
            char op;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Option: ");
            op = char.Parse(Console.ReadLine());
            return op;
        }

        //////////////////////////////////////////////////// ADMIN FUNCTIONS ///////////////////////////////////

        // admin menu
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
        static int giveLoan(ref int balance)
        {
            int bal = int.Parse(Console.ReadLine());
            balance = balance + bal;
            return balance;
        }
        static void giftMbs()
        {
            Console.WriteLine("Enter Gift MBs:");
            int mbs = Console.Read();
            Console.WriteLine("Operation Successful");
        }

        
        //////////////////////////////////////////////////// USER FUNCTIONS ///////////////////////////////////
        
     

        // user menu
        static int user_menu()
        {
            Console.Clear();
            int op;
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
            op = int.Parse(Console.ReadLine());
            return op;
        }
        static int recharge(ref int balance)
        {
            
            balance = balance + int.Parse(Console.ReadLine());
            return balance;
        }
        static int getLoan(ref int balance)
        {
            balance = balance + 25;
            return balance;
        }
        static void questions()
        {
            Console.WriteLine("1.What kind of app is this?");
            Console.WriteLine("2.What are the benefits of this app?");
            Console.WriteLine("3.How can you download this app?");
        }
        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
