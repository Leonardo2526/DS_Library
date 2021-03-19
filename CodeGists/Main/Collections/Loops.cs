using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        //The foreach loop
        static void Main_1(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add("John Doe");
            list.Add("Jane Doe");
            list.Add("Someone else");

            foreach (string name in list)
                Console.WriteLine(name);
            Console.ReadLine();
        }

        //The for loop
        static void Main_Test2 (string[] args)
        {
            int number = 5;
            for (int i = 0; i < number; i++)
                Console.WriteLine(i);
            Console.ReadLine();
        }

        //The while loop
        static void Main_Test1 (string[] args)
        {
            int number = 0;
            while (number < 5)
            {
                Console.WriteLine(number);
                number += 1;
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            List<string> list = new List<string> { "A", "B", "C" };

            for (int i = 0; i <list.Count; i++)
            {
                if (list[i] == "C")
                {
                    Console.WriteLine(list[i]);                   
                }                  
            }
            Console.ReadLine();
        }
        
        static void Main_3(string[] args)
        {
            List<string> dinosaurs = new List<string> { "Tyrannosaurus" , "Amargasaurus" };

            Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);

            Console.WriteLine("Count: {0}", dinosaurs.Count);

            Console.ReadLine();
        }

    }
}
