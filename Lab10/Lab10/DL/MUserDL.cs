using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10.BL;

namespace Lab10.DL
{
    internal class MUserDL
    {
        private static List<MUser> userList = new List<MUser>();
        internal static List<MUser> UserList { get => userList; set => userList = value; }
        public static void addUserIntoList(MUser user)
        {
            UserList.Add(user);
        }
        public static MUser SignIn(MUser user)
        {
            foreach (MUser storedUser in userList)
            {
                if (storedUser.UserName == user.UserName && storedUser.UserPassword == user.UserPassword)
                {
                    return storedUser;
                }
            }
            return null;
        }
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = " ";
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
        public static bool readDataFromFile(string path)

        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string userName = parseData(record, 1);
                    string userPassword = parseData(record, 2);
                    string userRole = parseData(record, 3);
                    MUser user = new MUser(userName, userPassword, userRole);
                    addUserIntoList(user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        public static void storeUserIntoFile(MUser user, string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.getUserName() + "," + user.getUserPassword() + "," + user.getUserRole());
            file.Flush();
            file.Close();
        }
        public static void deleteUserFromList(MUser user)
        {
            for (int index = 0; index < userList.Count; index++)
            {
                if (userList[index].UserName == user.UserName && userList[index].UserPassword == user.UserPassword)
                {
                    userList.RemoveAt(index);
                }
            }
        }
        public static void editUserFromList(MUser previous, MUser updated)
        {
            foreach (MUser user in userList)
            {
                if (user.UserName == previous.UserName && user.UserPassword == previous.UserPassword)
                {
                    user.UserName = updated.UserName;
                    user.UserPassword = updated.UserPassword;
                    user.UserRole = updated.UserRole;
                }
            }
        }
        public static void storeAllDataInFile(string path)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (MUser storedUser in userList)
            {
                file.WriteLine(storedUser.UserName + "," + storedUser.UserPassword + "," + storedUser.UserRole);
            }
            file.Flush();
            file.Close();
        }
    }
}
