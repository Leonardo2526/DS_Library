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
            dynamic user = new System.Dynamic.ExpandoObject();
            user.Name = "John Doe";
            user.Age = 42;
            user.HomeTown = "New York";
            Console.WriteLine(user.Name + " is " + user.Age + " years old and lives in " + user.HomeTown);
            Console.ReadLine();

            /*dynamic user = new System.Dynamic.ExpandoObject();  
user.Name = "John Doe";  
user.Age = 42;  

foreach (KeyValuePair<string, object> kvp in user)
{
    Console.WriteLine(kvp.Key + ": " + kvp.Value);
}
            */
        }
    }
}
