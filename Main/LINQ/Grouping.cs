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
            var users = new List<User>()
 {
        new User { Name = "John Doe", Age = 42, HomeCountry = "USA" },
        new User { Name = "Jane Doe", Age = 38, HomeCountry = "USA" },
        new User { Name = "Joe Doe", Age = 19, HomeCountry = "Germany" },
        new User { Name = "Jenna Doe", Age = 19, HomeCountry = "Germany" },
        new User { Name = "James Doe", Age = 8, HomeCountry = "USA" },
        };
            var usersGroupedByCountry = users.GroupBy(user => user.HomeCountry);
            foreach (var group in usersGroupedByCountry)
            {
                Console.WriteLine("Users from " + group.Key + ":");
                foreach (var user in group)
                    Console.WriteLine("* " + user.Name);
            }
            Console.ReadLine();
        }
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string HomeCountry { get; set; }
        }
    }
}
