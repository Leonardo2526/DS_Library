using System;
using System.IO;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathOfExe = System.Reflection.Assembly.GetEntryAssembly().Location;
            FileInfo fileInfo = new FileInfo(pathOfExe);
            var simpleFileInfo = new
            {
                fileInfo.Name,
                FileSize = fileInfo.Length
            };
            Console.WriteLine("File name: " + fileInfo.CreationTime + ". Size: " + simpleFileInfo.FileSize + " bytes");
            Console.ReadLine();
        }
    }
}