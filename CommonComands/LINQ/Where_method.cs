using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2
{
    class Class1
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            {
                1,2,4,8,16,32
            };

            var smallNumbers = numbers.Where(n => n > 1 && n != 4 && n < 10);

            foreach (var n in smallNumbers)
                Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}   
