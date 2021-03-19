using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wf=System.Windows.Forms;
using System.Text;

//Add two new namespaces
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.DocumentParts;



namespace BasicPlugIn

{
    [PluginAttribute("FileInfo", "DS", DisplayName = "FileInfoSample", ToolTip = "Tutorial")]        
    public class FileInfoClass : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            // get document from application
            Document document = Application.ActiveDocument;
            // info message - current file path with appended files
            string message = "Current File : " + document.CurrentFileName +
                              "\nAppend File : ";
            // get appended models from current document
            DocumentModels models = document.Models;
            // each model
            foreach (Model model in models)
            {
                // get filepath with index
                message += "\n         " + (models.IndexOf(model) + 1).ToString() + ". " + model.FileName;
            }
            // display message
            wf.MessageBox.Show(message);
            // int return
            return 0;
        }
    }

}