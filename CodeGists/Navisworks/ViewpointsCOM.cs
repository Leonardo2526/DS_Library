using Autodesk.Navisworks.Api.Plugins;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using ComApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge = Autodesk.Navisworks.Api.ComApi;
using Autodesk.Navisworks.Api.Interop.ComApi;

namespace Test_ComApi
{
    [Plugin("Example", "DS", ToolTip = "", DisplayName = "Example")]
    public class Selected_Nodes : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            ModelItemCollection items = new ModelItemCollection();
            Program(items);
            return 0;
        }
        void Program(ModelItemCollection items)
        {
            Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
            Viewpoint viewPointCopy = doc.CurrentViewpoint.CreateCopy();

            // point at adjusts the camera angle, you could also manually adjust this angle
            viewPointCopy.PointAt(items.BoundingBox().Center);
            doc.CurrentViewpoint.CopyFrom(viewPointCopy);

            InwOpState10 state = ComApiBridge.ComApiBridge.State;
            InwOpSelection selection = ComApiBridge.ComApiBridge.ToInwOpSelection(items);
            // Com API is used to zoom in on the model items, will only zoom does not adjust camera angle
            state.ZoomInCurViewOnSel(selection);
        }
    }
}