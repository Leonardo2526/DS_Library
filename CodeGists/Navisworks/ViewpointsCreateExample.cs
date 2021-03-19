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
    [Plugin("TestViewpoints_2", "DS", ToolTip = "", DisplayName = "TestViewpoints_2")]
    public class TestViewpointsPlugin_2 : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            createSavedVP_Folder();
            return 0;
        }
        void createSavedVP_Folder()
        {
            Document oDoc =
                Autodesk.Navisworks.Api.Application.ActiveDocument;

            // Create a saved viewpoint with current viewpoint
            SavedViewpoint oNewViewPt1 = new SavedViewpoint(oDoc.CurrentViewpoint.ToViewpoint());
            oNewViewPt1.DisplayName = "MySavedView1";

            // Create a viewpoint for the second saved viewpoint
            Viewpoint oNewVP = new Viewpoint();

            // Based on the current viewpoint, move camera along X+ with value 10
            oNewVP =oDoc.CurrentViewpoint.ToViewpoint().CreateCopy();
            Point3D oNewPos =
                new Point3D(oNewVP.Position.X + 10,
                            oNewVP.Position.Y,
                            oNewVP.Position.Z);
            
            oNewVP.Position = oNewPos;

            // Create the saved viewpoint with the new viewpoint
            SavedViewpoint oNewViewPt2 = new SavedViewpoint(oNewVP);
            oNewViewPt2.DisplayName = "MySavedView2";

            // Add the saved viewpoints to the collection
            oDoc.SavedViewpoints.AddCopy(oNewViewPt1);
            oDoc.SavedViewpoints.AddCopy(oNewViewPt2);

            FolderItem oNewViewPtFolder1 = new FolderItem();
            oNewViewPtFolder1.DisplayName = "Group1";

            // put the saved viewpoint1 to group1
            oNewViewPtFolder1.Children.Add(oNewViewPt1);

            // add the group
            oDoc.SavedViewpoints.AddCopy(oNewViewPtFolder1);

            // add saved viewpoint
            oDoc.SavedViewpoints.AddCopy(oNewViewPt2);
        }
    }
}