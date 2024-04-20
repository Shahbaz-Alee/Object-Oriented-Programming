using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.bl.UI;

namespace Demo.bl
{
    class CustomerCRUD
    {
        public static string faqOption()
        {
            Console.WriteLine("Choose option:");
            string option = Console.ReadLine();
            return option;
        }
        public static void balanceRecharge(AddBalance bal, string creditCard, float amount)
        {
            if (creditCard == "12345")
            {
                bal.balance = bal.balance + amount;
            }
            else
            {
                Console.WriteLine( "Invalid Credit Card!!!");
            }
        }
       public static void customerFeedback(string path)
        {
            Console.WriteLine( "Write your feedback:");
            string feedback=Console.ReadLine();
            StreamWriter file = new StreamWriter(path, false);
            file.WriteLine(feedback+",");
            file.Flush();
            file.Close();
        }
        
    }
}
