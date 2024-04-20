using Demo.bl.DI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.bl
{
    class Admin : MUser
    {
        // List to store Admin objects
        public static List<Admin> adminList = new List<Admin>();

        // Constructor for Admin class, inheriting from MUser class
        public Admin(string name, string password) : base(name, password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
