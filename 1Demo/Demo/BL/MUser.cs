using Demo.bl.DI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.bl
{
    class MUser
    {
        public static string adminName = "ALI";
        private string adminPassword = "12345";
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        // Constructor for MUser class with name and password parameters
        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        // Constructor for MUser class with name, password, and role parameters
        public MUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }

        // Method to check if the user is an admin
        public bool isAdmin(string name, string password)
        {
            if (name == adminName && password == adminPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // Interface for validating a user
    interface IValidatable
    {
        int isValid(string customerName, string customerPassword, string path);
    }
}
