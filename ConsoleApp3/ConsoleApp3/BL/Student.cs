using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.BL
{
    abstract class Student
    {
        protected string ID;
        protected string Name;
        protected int Age;
        protected int MathMarks;
        protected int PhysicsMarks;
        public Student (string ID,string Name,int Age,int MathMarks,int PhysicsMarks)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
            this.MathMarks = MathMarks;
            this.PhysicsMarks = PhysicsMarks;
        }
        abstract public int sum();
    }
}
