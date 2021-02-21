using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2
{
    public static class Rectangle
    {
        public static int CalculatedArea(int width, int height)
        {
            return width * height;
        }
      
    
    class New
    {
            static void Main()
            {
                Console.WriteLine("The area is: " + Rectangle.CalculatedArea(5, 4));
                Console.ReadLine();
            }
        }
    }
}
