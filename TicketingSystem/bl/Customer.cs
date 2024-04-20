using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.bl
{
    class Customer
    {
        public string role;
        public Customer(string role)
        {
            this.role = role;
        }
        public bool isCustomer()
        {
            if (role == "CUSTOMER")
            {
                return true;
            }
            else
                return false;
        }
        
    }
}
