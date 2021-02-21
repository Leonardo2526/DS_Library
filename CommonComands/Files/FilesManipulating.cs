using System;
using System.IO;


namespace ConsoleApp_v2.Files
{
    class DeletingFile
    {
        static void Main1(string[] args)
        {
            if (File.Exists("test.txt"))
            {
                File.Delete("test.txt");
                if (File.Exists("test.txt") == false)
                    Console.WriteLine("File deleted...");
            }
            else
                Console.WriteLine("File test.txt does not yet exist!");
            Console.ReadKey();
        }
    }
    class DeletingDirectory
    {
        static void Main2(string[] args)
        {
            if (Directory.Exists("testdir"))
            {
                Directory.Delete("testdir", true);
                if (Directory.Exists("testdir") == false)
                    Console.WriteLine("Directory deleted...");
            }
            else
                Console.WriteLine("Directory testdir does not yet exist!");
            Console.ReadKey();
        }
    }
    class FileRenaming
    {
        static void Main3(string[] args)
        {
            Console.WriteLine("Enter a new name for this file:");
            string newFilename = Console.ReadLine();
            if (newFilename != String.Empty)
            {
                File.Move("test.txt", newFilename);
                if(File.Exists(newFilename))
                {
                    Console.WriteLine("The file was renamed to " + newFilename);
                    Console.ReadKey();
                }    
            }
        }
    }
    class DirectoryRenaming
    {
        static void Main4(string[] args)
        {
            if (Directory.Exists("testdir"))
            {
                Console.WriteLine("Please enter a new name for this directory:");
                string newDirName = Console.ReadLine();
                if (newDirName != String.Empty)
                {
                    Directory.Move("testdir", newDirName);
                    if (Directory.Exists(newDirName))
                    {
                        Console.WriteLine("The directory was renamed to " + newDirName);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
    class NewDirectoryCreating
    {
        static void Main4(string[] args)
        {
            Console.WriteLine("Please enter a name for the new directory:");
            string newDirName = Console.ReadLine();
            if (newDirName != String.Empty)
            {
                Directory.CreateDirectory(newDirName);
                if (Directory.Exists(newDirName))
                {
                    Console.WriteLine("The directory was created!");
                    Console.ReadKey();
                }
            }
        }
    }
    class FilesWritingReading
    {
        static void Main(string[] args)
        {
            string fileContents = "John Doe & Jane Doe sitting in a tree...";
            File.WriteAllText("test.txt", fileContents);

            string fileContentsFromFile = File.ReadAllText("test.txt");
            Console.WriteLine(fileContentsFromFile);
            Console.ReadKey();
        }
    }
}
