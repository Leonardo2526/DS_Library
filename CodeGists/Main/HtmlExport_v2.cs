using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace ConsoleApp1
{
    class HtmlExport_1
    {

        static void Main(string[] args)
        {
            ArrayList listNames = new ArrayList();
            listNames.Add("John Doe");
            listNames.Add("Jane Doe");
            listNames.Add("Someone else");

            ArrayList headersList = new ArrayList();
            headersList.Add("a");
            headersList.Add("b");
            headersList.Add("c");

            HtmlRecord(listNames, headersList);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }


        static private void HtmlRecord(ArrayList listNames, ArrayList headersList)
        {

            try
            {
                using (FileStream fs = new FileStream(@"D:\Новая папка\test_1.htm", FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine("<html>");
                        w.WriteLine("<body>");
                        w.WriteLine("<p> THIS</p>");
                        w.WriteLine("<table border = '1'>");
                        w.WriteLine("<tr>");
                        foreach (string hdr in headersList)
                        {
                            w.WriteLine("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + hdr + "</th>");
                        }
                        w.WriteLine("</tr>");

                        foreach (string name in listNames)
                        {
                            w.WriteLine("<tr>");
                            w.WriteLine("<td><img src='D:\\Новая папка\\Test.png' alt='' border=3 height=100 width=100></img ></td><td>" + name + "</td>");
                            w.WriteLine("</tr>");
                        }

                        w.WriteLine("</table>");
                        w.WriteLine("</body>");
                        w.WriteLine("</html>");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex.Message);
            }
        }
    }
}
