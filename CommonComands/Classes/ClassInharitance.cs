using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInharitance
{
    public class Animal
    {
        public virtual void Greet()
        {
            Console.WriteLine("Hello, I'm some sort of animal");
            
        }
    }

    public class Dog: Animal
    {
        public override void Greet()
        {
            Console.WriteLine("Hello, I'm dog!");
            base.Greet();
            Console.ReadLine();
        }
    }
    public class Program
    {
        static void Main ()
        {
            Animal animal = new Animal();
            animal.Greet();
            Dog dog = new Dog();
            dog.Greet();
        }

    }
   
}
