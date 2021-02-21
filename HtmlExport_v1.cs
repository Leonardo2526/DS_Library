using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class HtmlExport_v1
    {
        static void Main1(string[] args)
        {
            ArrayList listNames = new ArrayList();
            listNames.Add("John Doe");
            listNames.Add("Jane Doe");
            listNames.Add("Someone else");

            ArrayList headersList = new ArrayList();
            headersList.Add("a");
            headersList.Add("b");
            headersList.Add("c");

            btnExport_Click(listNames, headersList);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        static private void btnExport_Click(ArrayList listNames, ArrayList headersList)
        {
            //Table start.
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>";

            //Adding HeaderRow.
            html += "<tr>";
            foreach (string hdr in headersList)
            {
                html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + hdr + "</th>";
            }
            html += "</tr>";

            //Adding DataRow.
            //foreach (string header in headersList)
            //{
            html += "<tr>";
            foreach (string name in listNames)
            {
                html += "<td style='width:120px;border: 1px solid #ccc'>" + name + "</td>";
            }
            html += "</tr>";

            html += "<tr>";
            /*
            foreach (string name in listNames)
            {
                html += "<td><img src='D:\\Новая папка\\Test.png'></img ></td>";
            }
            html += "</tr>";
            */
            //}

            //Table end.
            html += "</table>";

            File.WriteAllText(@"D:\Новая папка\DataGridView.htm", html);
        }
    }
}
