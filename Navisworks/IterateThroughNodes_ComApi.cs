using Autodesk.Navisworks.Api.Plugins;
using System.Windows.Forms;
using ComApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge = Autodesk.Navisworks.Api.ComApi;

namespace Test_ComApi
{
    [Plugin("Selected_Nodes", "DS", ToolTip = "", DisplayName = "Selected_Nodes")]
    public class Selected_Nodes : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            Program();
            return 0;
        }
        void Program()
        {
            ComApi.InwOpState10 state;
            state = ComApiBridge.ComApiBridge.State;

            foreach (ComApi.InwOaPath path in state.CurrentSelection.Paths())
            {
                ComApi.InwOaNode node;
                node = path.Nodes().Last() as ComApi.InwOaNode;
                MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, "UserName=" + node.UserName);
            }
        }
    }
}