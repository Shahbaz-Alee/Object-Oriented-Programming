using Demo.bl;
using Demo.bl.DI;
using Demo.bl.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mobile Phone Services";
            string OfferPath = "OfferFile.txt";
            string datPath = "textfile.txt";
            string QuestionPath = "Questions.txt";
            string feedbackPath = "Feedback.txt";

            AddBalance bal = new AddBalance();

            List<MUser> users = new List<MUser>();

            int option;

            do
            {
                Console.Clear();
                UI.check(users, datPath, Offer.offers, OfferPath);

                Console.Clear();
                option = UI.menu();
                Console.Clear();
                if (option == 1)
                {
                    MUser user1 = AdminCRUD.takeInputWithoutRole();
                    
                    if (user1 != null)
                    {
                        if (user1 == null)
                        {
                            Console.WriteLine("User Not Found");
                        }
                        else if (user1.isAdmin(user1.name, user1.password))
                        {
                            int num = 0;
                            do
                            {
                                Console.Clear();
                                UI.adminHeader();
                                Console.ForegroundColor = ConsoleColor.White;
                                UI.welcome();
                                num = UI.adminMenu();
                                if (num == 1)
                                {
                                    Console.Clear();
                                    UI.adminHeader();
                                    UI.printBalance(bal, user1);
                                    Console.Clear();
                                }
                                if (num == 2)
                                {
                                    Console.Clear();
                                    UI.adminHeader();
                                    UI.printGiveLoan(bal);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                if (num == 3)
                                {
                                    Console.Clear();
                                    UI.adminHeader();
                                    Offer offer = OfferCRUD.addOffer(OfferPath);
                                    if (offer != null)
                                    {
                                        Console.WriteLine("Offer added successfully:");
                                        Console.WriteLine(offer.ToString());
                                    }
                                }
                                if (num == 4)
                                {
                                    Console.Clear();
                                    UI.adminHeader();
                                    bool removed = OfferCRUD.removeOffer(OfferPath);
                                    if (removed)
                                    {
                                        Console.WriteLine("Offer removed successfully.");
                                    }
                                }
                                if (num == 5)
                                {
                                    Console.Clear();
                                    UI.adminHeader();
                                    OfferCRUD.viewOfferList(OfferPath);

                                }
                                if (num == 6)
                                {
                                    Console.Clear();
                                    
                                    OfferCRUD.offers(OfferPath, Offer.offers);
                                    Console.Clear();
                                    Console.ReadKey();
                                }
                                if (num == 7)
                                {
                                    Console.Clear();
                                    UI.adminHeader();
                                    UI.giftMbs();
                                }
                                if (num == 8)
                                {
                                    UI.faqs();
                                }
                                if(num==9)
                                {
                                    Console.Clear();
                                    UI.adminHeader();
                                    AdminCRUD.displayFeedback(feedbackPath);
                                    Console.ReadKey();
                                }
                                if(num==10)
                                {
                                    AdminCRUD.removeCustomerAccount(datPath);
                                }
                            } while (num < 11);
                        }

                        else
                        {

                            Customer customer = new Customer(user1.name, user1.password, user1.role);
                            if (user1 != null)
                            {
                                user1 = AdminCRUD.signIn(user1, users);

                                if (user1 == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("User Not Found");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                
                                else if (customer.isValid(user1.name,user1.password,datPath)==1)
                                {
                                    int num = 0;
                                    do
                                    {
                                        Console.Clear();
                                        UI.customerHeader();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("Welcome Back : " + user1.name);
                                        Console.WriteLine("\n");
                                        num = UI.CustomerMenu();
                                        if (num == 1)
                                        {
                                            Console.Clear();
                                            UI.customerHeader();
                                            UI.printBalance(bal, user1);
                                            Console.Clear();
                                        }
                                        if (num == 2)
                                        {
                                            Console.Clear();
                                            UI.recharge(bal);
                                            Console.ReadKey();
                                        }
                                        if (num == 3)
                                        {
                                            Console.Clear();
                                            UI.customerHeader();
                                            UI.printGiveLoan(bal);
                                            Console.ReadKey();
                                        }
                                        if (num == 4)
                                        {
                                            Console.Clear();
                                            string targetOfferType = "CALL";
                                            UI.displayCallOffer(OfferPath, targetOfferType);
                                            Console.ReadKey();
                                        }
                                        if (num == 5)
                                        {
                                            Console.Clear();
                                            string targetOfferType = "SMS";
                                            UI.displayCallOffer(OfferPath, targetOfferType);
                                            Console.ReadKey();
                                        }
                                        if (num == 6)
                                        {
                                            Console.Clear();
                                            string targetOfferType = "NET";
                                            UI.displayCallOffer(OfferPath, targetOfferType);
                                            Console.ReadKey();
                                        }
                                        if (num == 7)
                                        {
                                            Console.Clear();
                                            UI.customerHeader();
                                            QuestionCRUD.displayQuestion(QuestionPath);
                                        }
                                        if (num == 8)
                                        {
                                            UI.faqs();
                                        }
                                        if (num == 9)
                                        {
                                            CustomerCRUD.customerFeedback(feedbackPath);
                                        }
                                    } while (num < 10);
                                }

                            }
                        }
                    }
                }
                else if (option == 2)
                {
                    MUser user = AdminCRUD.takeInputWithRole();
                    if (user != null)
                    {
                        AdminCRUD.storeDataInList(users, user);
                        AdminCRUD.storeDataInFile(datPath, user);
                    }
                }
                Console.ReadKey();
            } while (option < 3);
        }

    }
}

