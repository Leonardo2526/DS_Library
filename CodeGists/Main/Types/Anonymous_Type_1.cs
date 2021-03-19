using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            var user = new
            {
                Name = "John Doe",
                Age = 42
            };
            Console.WriteLine(user.Name + " - " + user.Age + " years old");
            Console.ReadLine();
        }
    }
}

//Unlike a real class, an anonymous type can't have fields or methods - only properties
//Once the object has been initialized, you can't add new properties to it
//Properties are readonly - as soon as the object has been initialized, you can't change their values