using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

//Add two new namespaces
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.DocumentParts;
 
 

namespace BasicPlugIn
{
    
    [PluginAttribute("CreateNWD", "DS", DisplayName = "CreateNWD", ToolTip = "Tutorial")]  
    
    public class MainClass : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            Autodesk.Navisworks.Api.Automation.NavisworksApplication automationApplication = null;
            try
            {
                //Get Current Working directory
                string workingDir = @"C:\Users\dnknt\OneDrive\Рабочий стол\Новая папка";
                    //System.IO.Directory.GetCurrentDirectory().TrimEnd('\\');

                //create NavisworksApplication automation object
                automationApplication =
                   new Autodesk.Navisworks.Api.Automation.NavisworksApplication();

                //disable progress whilst we do this procedure
                automationApplication.DisableProgress();

                //Open two AutoCAD files
                automationApplication.OpenFile(workingDir + "\\Модель_ТС.dwg", workingDir + "\\Модель_ЦМК.dwg");

                //Save the combination into a Navisworks file
                automationApplication.SaveFile(workingDir + "\\hello_world.nwd");

                //Re-enable progress
                automationApplication.EnableProgress();
                MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, "Done");

            }
            catch (Autodesk.Navisworks.Api.Automation.AutomationException e)
            {
                //An error occurred, display it to the user
                System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
            }
            catch (Autodesk.Navisworks.Api.Automation.AutomationDocumentFileException e)
            {
                //An error occurred, display it to the user
                System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                if (automationApplication != null)
                {
                    automationApplication.Dispose();
                    automationApplication = null;
                }
            }
            return 0;
        }
    }

}