using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableScope
{
    class Program
     {
        private static string helloClass = "Hello, class";

        static void Main(string[] args)
        {
            string helloLocal = "Hello, local!";
            Console.WriteLine(helloLocal);
            Console.WriteLine(helloClass);
            DoStuff();
        }

        static void DoStuff()
        {
            Console.WriteLine("A message from DoStuff: " + helloClass);
            Console.ReadLine();
        }
        }
}
