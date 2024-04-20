using System;
using System.Collections.Generic;
using System.IO;

namespace Demo.bl.DI
{
    class AdminCRUD
    {
        // Take input from the user without role
        public static MUser takeInputWithoutRole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            name = name.ToUpper();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MUser user = new MUser(name, password);
                return user;
            }
            return null;
        }

        // Take input from the user with role
        public static MUser takeInputWithRole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            name = name.ToUpper();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            string role = "CUSTOMER";
            if (name == null || password == null || name.Length < 1 || name.Length > 17 || password.Length < 3 || password.Length > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password or Username requirement not met.......");
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear();
                return takeInputWithoutRole();
            }
            else
            {
                MUser user = new MUser(name, password, role);
                return user;
            }
        }

        // Store user data in a list
        public static void storeDataInList(List<MUser> users, MUser user)
        {
            users.Add(user);
        }

        // Store user data in a file
        public static void storeDataInFile(string path, MUser user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }

        // Sign in a user
        public static MUser signIn(MUser user, List<MUser> users)
        {
            foreach (MUser storedUser in users)
            {
                if (user.name == storedUser.name && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }

        // Read data from a file
        public static bool readData(string path, List<MUser> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    MUser user = new MUser(name, password, role);
                    storeDataInList(users, user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }

        // Parse data from a record
        public static string parseData(string record, int field)
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

        // Display feedback from a file
        public static void displayFeedback(string feedbackPath)
        {
            if (File.Exists(feedbackPath))
            {
                string record;
                StreamReader file = new StreamReader(feedbackPath);
                while ((record = file.ReadLine()) != null)
                {
                    string[] line = record.Split(',');
                    string tempFeedback = line[0];
                    Console.WriteLine("Feedback is:\n" + tempFeedback);
                }
                file.Close();
            }
        }

        // Remove a customer account
        public static void removeCustomerAccount(string path)
        {
            Console.Write("Enter the name of the customer to remove the account: ");
            string nameToRemove = Console.ReadLine().ToUpper();

            List<MUser> users = new List<MUser>();

            // Read the data from the file
            if (readData(path, users))
            {
                // Find the customer with the matching name
                MUser customerToRemove = users.Find(user => user.name.Equals(nameToRemove));

                if (customerToRemove != null)
                {
                    // Remove the customer from the list
                    users.Remove(customerToRemove);

                    // Write the updated data back to the file
                    StreamWriter file = new StreamWriter(path, false);
                    foreach (MUser user in users)
                    {
                        file.WriteLine(user.name + "," + user.password + "," + user.role);
                    }
                    file.Flush();
                    file.Close();

                    Console.WriteLine("Customer account successfully removed.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Customer account not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("File not found.");
                Console.ReadKey();
            }
        }
    }
}
