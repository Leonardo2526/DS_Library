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
            Dictionary<string, int> users = new Dictionary<string, int>()
            {
                { "John Doe", 42},
                { "Jane Doe", 38},
                { "Joe Doe", 12},
                { "Jenna Doe", 12}
            };
            foreach(KeyValuePair<string, int> user in users.OrderBy(user => user.Value))
            {
                Console.WriteLine(user.Key + "is " + user.Value + " years old");
            }
            Console.ReadLine();
        }
    }
}
