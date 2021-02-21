using System;
using System.IO;


namespace ConsoleApp_v2.Files
{
    class Read
    {
        static void Main(string[] args)
        {
            if (File.Exists("test.txt"))
            {
                string content = File.ReadAllText("test.txt");
                Console.WriteLine("Current content of file:");
                Console.WriteLine(content);

            }
            Console.WriteLine("Please enter new content for the file - type exit and press enter to finish editing:");
            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                string newContent = Console.ReadLine();
                while (newContent != "exit")
                {
                    sw.Write(newContent + Environment.NewLine);
                    newContent = Console.ReadLine();
                }
            }
        }
    }
}
