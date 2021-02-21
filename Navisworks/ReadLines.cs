using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;

//Add two new namespaces 
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;


namespace BasicPlugIn
{
    [Plugin("TestPath",                   //Plugin name 
                     "ADSK",                                       //4 character Developer ID or GUID
                     ToolTip = "BasicPlugIn.ABasicPlugin tool tip",//The tooltip for the item in the ribbon
                     DisplayName = "TestPath")]          //Display name for the Plugin in the Ribbon

    public class TestPath : AddInPlugin                        //Derives from AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {

            //Name of input file
            string FilePathTxt = @"D:\OneDrive\Рабочая папка ГЦМ\Тест\Координация\FilePathes.txt"; ;
            if (File.Exists(FilePathTxt))
            {

                string listOfTestNames = null;

                //Files renaming
                string[] lines = File.ReadAllLines(FilePathTxt);
                try
                {
                    for (int i = 0; i <= lines.Length - 1; i++)
                    {
                        listOfTestNames = listOfTestNames + lines[i] + "\n";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, ex.ToString());
                }

                MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, listOfTestNames + "\nDone!");
            }
            else
                MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, "File '" + FilePathTxt + "' is absent.");

            return 0;
        }
    }
}