using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2
{
    class Query_Syntax
    {
        static void Main (string[] args)
        {
            var names = new List<string>()
{
    "John Doe",
    "Jane Doe",
    "Jenna Doe",
    "Joe Doe"
};

            // Get the names which are 8 characters or less, using LINQ  
            var shortNames = from name in names where name.Length <= 8 orderby name.Length select name;

            foreach (var name in shortNames)
                Console.WriteLine(name);
            Console.ReadLine();
        }
    }
}
