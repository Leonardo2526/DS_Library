using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle_CalculateArea;

namespace Rectangle_CalculateArea
{
    public class Rectangle
    {
        private int width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public static int CalculateArea(int width, int height)
        {
            return width * height;
        }

        static void Main_Test1 (string[] args)
        {
            Console.WriteLine("Area output: " + CalculateArea(5, 4));
            Console.ReadLine();
        }
    }

}

