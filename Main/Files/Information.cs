using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2.Files
{
    class FileInformation
    {
        static void Main1(string[] args)
        {
            FileInfo fi = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (fi != null)
                Console.WriteLine(String.Format("Information about file: {0}, {1} bytes, last modified on {2} - Full path: {3}", fi.Name, fi.Length, fi.LastWriteTime, fi.FullName));
            Console.ReadKey();
        }
    }
    class DirectoryInformation
    {
        static void Main1(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName("C:\\Users\\dnknt\\OneDrive\\Рабочий стол\\Новая папка\\"));
            if (di != null)
            {
                FileInfo[] subFiles = di.GetFiles();
                if(subFiles.Length>0)
                {
                    Console.WriteLine("Files: ");
                        foreach(FileInfo subFile in subFiles)
                    {
                        Console.WriteLine("   " + subFile.Name + " (" + subFile.Length + " bytes)");
                    }
                }
            }
            Console.ReadKey();
        }
    }
    class GetDirectoryInformation
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName("C:\\Users\\dnknt\\OneDrive\\Рабочий стол\\Новая папка\\"));
            if (di != null)
            {
                DirectoryInfo[] subDirs = di.GetDirectories();
                //DirectoryInfo[] subDirs = di.GetDirectories("*test*");
                //FileInfo[] subFiles = di.GetFiles("*.exe", SearchOption.AllDirectories);
                if (subDirs.Length > 0)
                {
                    Console.WriteLine("Directories:");
                    foreach (DirectoryInfo subDir in subDirs)
                    {
                        Console.WriteLine("   " + subDir.Name);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
