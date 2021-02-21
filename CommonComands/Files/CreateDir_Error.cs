using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace ConsoleApp_v2.Files
{
    class NewDirectoryCreating
    {
        static void Main(string[] args)
        {
            string newDirName = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Desktop\Новая папка\");
            string FilePath = newDirName + "_Log.txt";

            Console.WriteLine(HasWritePermissionOnDir(newDirName));


            if (Directory.Exists(newDirName) == true)
                {
                    Console.WriteLine("Exist!");
                }
            else
            {
                Directory.CreateDirectory(newDirName);
                Console.WriteLine("Created!");

            }
            LogWriter("OK", FilePath);
            Console.ReadKey();


        }

        public static void LogWriter(string Note, string FilePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(LogPath(), true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(Note + FilePath + "'\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static string LogPath()
        {
            string CurDT = DateTime.Now.ToString("yyMMdd_HHmmss");
            return Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Desktop\Новая папка\" + CurDT + "_Log.txt");
        }


        public static bool HasWritePermissionOnDir(string path)
        {
            var writeAllow = false;
            var writeDeny = false;
            var accessControlList = Directory.GetAccessControl(path);
            if (accessControlList == null)
                return false;
            var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            if (accessRules == null)
                return false;

            foreach (FileSystemAccessRule rule in accessRules)
            {
                if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write) continue;

                if (rule.AccessControlType == AccessControlType.Allow)
                    writeAllow = true;
                else if (rule.AccessControlType == AccessControlType.Deny)
                    writeDeny = true;
            }

            return writeAllow && !writeDeny;
        }
    }
}
