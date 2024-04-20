using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.bl;
using TicketingSystem.bl.Dl;
using TicketingSystem.bl.UI;
using System.IO;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string datPath = "textfile.txt";
            Employee EUser = new Employee();
            List<MUser> users = new List<MUser>();
            List<Employee> Elist = new List<Employee>();            
            int option;
            
            do
            {
                Console.Clear();
                UI.check(users,datPath);
                option = UI.menu();
                Console.Clear();
                if (option == 1)
                {
                    MUser user1 = AdminCRUD.takeInputWithoutRole();
                    if (user1 != null)
                    {
                        user1 = AdminCRUD.signIn(user1, users);
                        if (user1 == null)
                            Console.WriteLine("User Not Found");
                        else if (user1.isAdmin())
                        {
                            Console.Clear();
                            UI.adminHeader();
                            Console.WriteLine("Welcome Back : " + user1.name);
                            Console.WriteLine("\n");
                            int num = UI.adminMenu();
                            if (num == 1)
                            {

                            }
                        }

                        else
                            Console.Clear();
                            UI.adminHeader();
                            Console.WriteLine("Welcome Back : " + user1.name);
                            Console.WriteLine("\n");
                            Console.WriteLine("User Menu");
                            int num1 = UI.CustomerMenu();
                    }
                }
                else if (option == 2)
                {
                    MUser user = AdminCRUD.takeInputWithRole();
                    if (user != null)
                    {
                        AdminCRUD.storeDataInFile(datPath, user);
                        AdminCRUD.storeDataInList(users, user);
                    }
                }
                Console.ReadKey();
            }
            while (option < 3);
        }
    }
}
