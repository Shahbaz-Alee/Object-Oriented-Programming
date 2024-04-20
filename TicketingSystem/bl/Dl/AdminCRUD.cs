using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TicketingSystem.bl.Dl
{
    class AdminCRUD
    {
        public static MUser takeInputWithoutRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            name = name.ToUpper();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MUser user = new MUser(name, password);
                return user;
            }
            return null;
        }
        public static MUser takeInputWithRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            name = name.ToUpper();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role (admin,customer): ");
            string role = Console.ReadLine();
            role = role.ToUpper();
            if (name != null && password != null && role != null)
            {
                MUser user = new MUser(name, password, role);
                return user;
            }
            return null;
        }
        public static void storeDataInList(List<MUser> users, MUser user)
        {
            users.Add(user);
        }
        public static void storeDataInFile(string path, MUser user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }
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

        public static void AddEmployee()
        {
            string name;
            int password;
            Console.WriteLine("Enter the name of the employee: ");
            name = Console.ReadLine();
            name = name.ToUpper();
            Console.WriteLine("Assign the paswword to employee: ");
            password = int.Parse(Console.ReadLine());
        }

    }
}
