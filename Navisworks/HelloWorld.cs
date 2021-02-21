using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

//Add two new namespaces 
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
 
  
namespace BasicPlugIn 
{
    [Plugin("BasicPlugIn.ABasicPlugin",                   //Plugin name 
                     "ADSK",                                       //4 character Developer ID or GUID
                     ToolTip = "BasicPlugIn.ABasicPlugin tool tip",//The tooltip for the item in the ribbon
                     DisplayName = "Hello World Plugin")]          //Display name for the Plugin in the Ribbon

    public class ABasicPlugin : AddInPlugin                        //Derives from AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, "Hello World123");
            return 0;
        }
    }
}