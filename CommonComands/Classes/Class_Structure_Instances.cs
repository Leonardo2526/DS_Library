using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Structure_Instances
{
    /*public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    */
    public struct Person
    {
        public string Name;
        public int Age;
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main ()
        {
            Person person1 = new Person("Leopold", 6);
            Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);
            Person person2 = person1;

            //Declare new person, assign person1 to it.
            person2.Name = "Molly";
            person2.Age = 16;

            //Change the name of person2, and person1 also changes or doesn't changes if structure.
            Console.WriteLine("person2 Name = {0} Age = {1}", person2.Name, person2.Age);
            Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

            //Keep console open in debug mode.
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
