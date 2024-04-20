using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.bl
{
    class Employee
    {
        public string role;
        //public Employee(string role)
        //{
        //    this.role = role;
        //}
        public bool isEmployee()
        {
            if (role == "EMPLOYEE")
            {
                return true;
            }
            else
                return false;
        }
        public int employeeMenu()
        {            
            Console.WriteLine("Main menu");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1.  Mark Attendance");
            Console.WriteLine("2.  View Balance");
            Console.WriteLine("3.  View Alotted Bonus");
            Console.WriteLine("4.  View running attendance");
            Console.WriteLine("5.  Withdraw Salary");
            Console.WriteLine("6.  View assigned Tasks / Duties");
            Console.WriteLine("7.  Deducted Amount");
            Console.WriteLine("8.  Change Password");
            Console.WriteLine("9.  Lodge a complaint");
            Console.WriteLine("10. Exit");
            Console.Write("Select option: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }
    }
}
