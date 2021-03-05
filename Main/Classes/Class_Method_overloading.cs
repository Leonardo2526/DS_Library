using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2
{
    class SillyMath
    {
            public int Plus(int number1, int number2)
            {
                return Plus(number1, number2, 0);
            }
            public int Plus(int number1, int number2, int number3)
            {
                return Plus(number1, number2, number3, 0);
            }
            public int Plus(int number1, int number2, int number3, int number4)
            {
                return number1 + number2 + number3 + number4;
            }
    }

    class Program
    {
        static void Main()
        {
            SillyMath SM = new SillyMath();
            Console.WriteLine(SM.Plus(1, 2));
            Console.ReadLine();
        }
    }
}
