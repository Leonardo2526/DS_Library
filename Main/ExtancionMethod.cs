using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2
{
    public static class MyExtensionMethods
    {
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }

    class Program
    {
        static void Main (string [] args)
        {
 string test = "4";
if (test.IsNumeric())
    Console.WriteLine("Yes");
else
    Console.WriteLine("No");
            Console.ReadLine();
        }       
    }
}
