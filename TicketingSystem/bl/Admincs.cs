using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.bl;
using System.IO;

namespace TicketingSystem.bl
{

    class MUser
    {
        public string name;
        public string password;
        public string role;

        //public List<Employee> EUser = new List<Employee>();
        //public List<Customer> CUser = new List<Customer>();

        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public MUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;

        }
        public bool isAdmin()
        {
            if (role == "ADMIN")
            {
                return true;
            }
            else
                return false;
        }
    }
}
