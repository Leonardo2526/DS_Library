using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

//Add two new namespaces 
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Clash;

namespace ViewpointsCreate
{
    [Plugin("ViewpointsCreate", "DS", ToolTip = "", DisplayName = "ViewpointsCreate")]
    public class ViewpointsCreate : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            CreateVP();
            return 0;
        }
        void CreateVP()
        {
            Document oDoc =
                Autodesk.Navisworks.Api.Application.ActiveDocument;

            // Create a viewpoint
            Viewpoint oNewVP = new Viewpoint();
            
            //oNewVP = oDoc.CurrentViewpoint.ToViewpoint().CreateCopy();

            Point3D oNewPos = new Point3D(38.514, 201.116, -1.949);
            //ViewpointImageFit oNewIF = new ViewpointImageFit(); 

            oNewVP.Position = oNewPos;
            oNewVP.FarPlaneDistance = 56;
            oNewVP.FocalDistance = 10;

            // Create the saved viewpoint with the new viewpoint
            SavedViewpoint oNewViewPt = new SavedViewpoint(oNewVP);
            oNewViewPt.DisplayName = "MySavedView"; 

            FolderItem oNewViewPtFolder1 = new FolderItem();
            oNewViewPtFolder1.DisplayName = "Group1";

            // put the saved viewpoint to group1
            oNewViewPtFolder1.Children.Add(oNewViewPt);

            // add the group
            oDoc.SavedViewpoints.AddCopy(oNewViewPtFolder1);
            oDoc.CurrentViewpoint.CopyFrom(oNewVP);

        }
    }
}