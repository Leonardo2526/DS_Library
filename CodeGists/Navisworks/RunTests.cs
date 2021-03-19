using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

//Add two new namespaces 
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Clash;


namespace RunTests
{
    [Plugin("RunTests", "DS", ToolTip = "", DisplayName = "RunTests")]

    public class RunTestsPlugin : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            string FileName = @"D:\OneDrive\Рабочая папка ГЦМ\Тест\Координация\Тест_Модели.nwf";
            Autodesk.Navisworks.Api.Application.ActiveDocument.TryOpenFile(FileName);
            
            Document oDoc = Autodesk.Navisworks.Api.Application.ActiveDocument;
            DocumentClash documentClash = oDoc.GetClash();
            DocumentClashTests oDCT = documentClash.TestsData;

            string listOfTestNames = null;
            oDCT.TestsRunAllTests();

            for (int i = 0; i < oDCT.Tests.Count; i++)
            {
                listOfTestNames = listOfTestNames + documentClash.TestsData.Tests[i].DisplayName + "\n";
            }
            
            MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, listOfTestNames + "Done!!");
            
            return 0;
        }
    }

}