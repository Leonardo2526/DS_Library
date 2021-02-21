using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Navisworks.Api.Automation;
using System.Windows.Forms;


namespace ConsoleApp_Navisworks
{
    class Test
    {
        static void Main(string[] args)
        {
            string aString = "Hello";

            Autodesk.Navisworks.Api.Automation.NavisworksApplication navisworksApplication =
               new Autodesk.Navisworks.Api.Automation.NavisworksApplication();

            // Execute command on our message receiver
            int retval = navisworksApplication.ExecuteAddInPlugin("BasicPlugIn.ABasicPlugin.ADSK", aString);

            //Show the result received from the plugin
            MessageBox.Show(String.Format("Plugin returned {0}", retval));
        }
    }
}
