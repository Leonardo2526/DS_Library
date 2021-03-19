using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2.LINQ
{
    class Select
    {
        static void Main(string[] args)
        {
            List<User> listOfUsers = new List<User>()
            {
                new User() { Name = "John Doe", Age = 42 },
                new User() { Name = "Jane Doe", Age = 34 },
                new User() { Name = "Joe Doe", Age = 8 },
                new User() { Name = "Another Doe", Age = 15 },
            };
            List<string> names = listOfUsers.Select(user => user.Name).ToList();
            foreach (var user in names)
            Console.WriteLine(user);
            Console.ReadLine();
        }
        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
