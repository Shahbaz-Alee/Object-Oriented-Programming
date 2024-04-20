using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.bl
{
    class admin
    {
        string name;
        string password;
        static List<admin> adminList = new List<admin>();
        public admin(MUser user)
        {
            this.name = user.name;
            this.password = user.password;            
        }
        public admin(List<MUser> user)
        {
            this.user = user;
            foreach(MUser role1 in user)
            {
                if(role1.role=="ADMIN")
                {
                    adminList.Add(new admin(role1));       
                }
            }
        }
        List<MUser> user; 
    }
}
