using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Student
    {
        string name;
        string ID;
        string marks;
        public bool getName()
        {
            if(name=="Ali")
            {
                return true;
            }
            else 
                return false;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public virtual void w()
        {
            Console.WriteLine( "Hello");
        }
    }
}
