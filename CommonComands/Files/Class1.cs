using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2.Files
{
    class FileRenaming
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a new name for this file:");
            string newFilename = Console.ReadLine();
            if (newFilename != String.Empty)
            {
                File.Move("test.txt", newFilename);
                if (File.Exists(newFilename))
                {
                    Console.WriteLine("The file was renamed to " + newFilename);
                    Console.ReadKey();
                }
            }
        }
    }
}
