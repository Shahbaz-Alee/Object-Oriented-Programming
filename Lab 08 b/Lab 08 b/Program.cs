using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08_b
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Bird b = new Bird();
            b.speak();
            b.move();
            b.fly();
            Console.ReadKey();
        }
        abstract class Animal
        {
            public int legs;
            public void speak()
            {
                Console.WriteLine("hmmm");
            }
            public abstract void move();
        }
        interface Flyable
        {
            void fly();
        }
        class Bird : Animal, Flyable
        {
            public void fly()
            {
                Console.WriteLine("With Wings");
            }
            public override void move()
            {
                Console.WriteLine("2 Steps");
            }
        }
    }
}

