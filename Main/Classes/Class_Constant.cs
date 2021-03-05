using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
    {
    class Program
    {
        static void Main(string [] args)
        {
            Console.WriteLine("The fake answer to life: " + SomeClass.TheFakeAnswerToLife);
            Console.WriteLine("The real answer to life: " + SomeClass.GetAnswer());
            Console.ReadLine();
        }
    }

    class SomeClass
    {
        private const int TheAnsertToLife = 42;
        public const int TheFakeAnswerToLife =43;
        public static int GetAnswer()
        {
            return TheAnsertToLife;
        }

    }
}
