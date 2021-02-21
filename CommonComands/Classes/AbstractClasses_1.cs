using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Console.WriteLine(dog.Describe());
            Console.ReadLine();
        }
    }

    abstract class FourLeggedAnimal
    {
        public virtual string Describe()
        {
            return "Not much id known abour this four legges animal!";
        }
    }
    class Dog : FourLeggedAnimal
    {
        public override string Describe()
        {
            //return "This four legged animal is dog!";
            string result = base.Describe();
            result += "\n"+"In fact, it's a dog!";
            return result;
        }       
    }
}
