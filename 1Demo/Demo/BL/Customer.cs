using Demo.bl.DI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.bl
{
    class Customer : MUser, IValidatable
    {

        // Constructor for Customer class, inheriting from MUser class
        public Customer(string name, string password, string role) : base(name, password, role)
        {
            this.role = role;
        }

        // Method to validate customer credentials
        public int isValid(string customerName, string customerPassword, string path)
        {
            StreamReader file = new StreamReader(path);
            string record;

            // Read each line of the file
            while ((record = file.ReadLine()) != null)
            {
                // Parse the line to retrieve name, password, and role
                string tempName = AdminCRUD.parseData(record, 1);
                string tempPassword = AdminCRUD.parseData(record, 2);
                string tempRole = AdminCRUD.parseData(record, 3);

                // Check if the parsed values match the provided customerName, customerPassword, and role
                if (tempName == customerName && tempPassword == customerPassword && tempRole == "CUSTOMER")
                {
                    file.Close();
                    return 1; // Credentials are valid
                }
            }

            file.Close();
            return 0; // Credentials are invalid
        }
    }
}