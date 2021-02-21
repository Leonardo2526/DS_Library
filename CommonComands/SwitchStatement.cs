using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchStatement
{
    class Program
    {
        static void Main_Test (string[] args)
        {
            Console.WriteLine("Do you enjoy c#? (yes/no/maybe)");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "yes":
                   case "maybe":
                    Console.WriteLine("Great!");
                break;
                case "no":
                    Console.WriteLine("Too bad");
                break;
                default:
                    Console.WriteLine("I'm sorry, I don't understand that!");
                    break;
            }
            Console.ReadLine();
        }


        static void Main_Test1 (string[] args)
        {
            int number = 5;
            switch (number)
            {
                case 0:
                    Console.WriteLine("The number is zero!");
                    break;
                case 1:
                    Console.WriteLine("The number is one!");
                    break;
            }
            Console.ReadLine();
        }
    }
}
