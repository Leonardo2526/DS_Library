using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp_Test
{
    class KillProcess
    {
        public void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                Console.WriteLine(process.MainWindowTitle.ToString());
                if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName)
                    process.Kill();
            }
        }
		
		 public void  killsallrunningthreads()
        {
		 Environment.Exit(1);
		}
    }
	
}
