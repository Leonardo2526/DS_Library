using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2
{
    class Coords
    {
        public int x, y;

        // Default constructor.
        public Coords()
        {
            x = 0;
            y = 0;
        }

        // A constructor with two arguments.
        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        // Override the ToString method.
        public override string ToString()
        {
            return $"({x},{y})";
        }
        
    }

    class MainClass
    {
        static void Main1()
        {
            var p1 = new Coords();
            var p2 = new Coords(5, 3);

            // Display the results using the overriden ToString method.
            Console.WriteLine($"Coords #1 at {p1}");
            Console.WriteLine($"Coords #2 at {p2}");
            Console.ReadKey();
        }
    }
    /* Output:
     Coords #1 at (0,0)
     Coords #2 at (5,3)
    */
}
