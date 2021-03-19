using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
//Add two new namespaces 
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Clash;

namespace TestViewpoints
{
    [Plugin("TestViewpoints", "DS", ToolTip = "", DisplayName = "TestViewpoints")]
    public class TestViewpointsPlugin : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {

            SavedVPs();
            return 0;
        }

        void SavedVPs()
        {
            Document oDoc =
                    Autodesk.Navisworks.Api.Application.ActiveDocument;

            string listOfViewpoints_1 = null;
            string listOfViewpoints_2 = null;


            // iterate the collection of saved viewpoints
            foreach (SavedItem oSVP in
                    oDoc.SavedViewpoints.Value)
            {

                // if it is a folder/animation 
                if (oSVP.IsGroup)
                    Recurse(oSVP, ref listOfViewpoints_1);
                else
                {
                    // Access the properties of the saved viewpoint               
                    SavedViewpoint oThisSVP =
                        oSVP as SavedViewpoint;
                    if (oThisSVP != null)
                    {
                        listOfViewpoints_2 = listOfViewpoints_2 + oThisSVP.DisplayName + "\n";
                    }
                }

            }
            MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, listOfViewpoints_1);
            MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, listOfViewpoints_2);
        }

        void Recurse(SavedItem oFolder, ref string listOfViewpoints_1)
        {
            foreach (SavedViewpoint oSVP in ((GroupItem)
                                        oFolder).Children)
            {
                // if it is a folder/animation                           
                if (oSVP.IsGroup)
                    Recurse(oSVP, ref listOfViewpoints_1);
                else
                {
                    // Access the properties of the saved viewpoint                                
                    SavedViewpoint oThisSVP =
                       oSVP as SavedViewpoint;
                    listOfViewpoints_1 = listOfViewpoints_1 + oThisSVP.DisplayName + "\n";
                }

            }
        }
    }
}