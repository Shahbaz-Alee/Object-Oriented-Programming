using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.BL
{
    class Scholarship : Student
    {
        public Scholarship(string ID, string Name, int Age, int MathsMarks, int PhysicsMarks) : base(ID, Name, Age, MathsMarks, PhysicsMarks)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
            this.PhysicsMarks = PhysicsMarks;
            this.MathMarks = MathsMarks;
        }
        public override int sum()
        {
            int num1 = 5;
            int num2 = 5;
            return num1 + num2;
        }
    }
}
