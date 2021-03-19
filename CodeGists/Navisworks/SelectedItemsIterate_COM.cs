using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Windows.Forms;
using ComApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;


namespace DS_NWClass_Template
{
    [Plugin("TestPlugin_1", "DS", ToolTip = "", DisplayName = "TestPlugin_1")]

    public class TestPlugin : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            Program();

            return 0;
        }

        public void Program()
        {
            ComApi.InwOpState opState = ComApiBridge.State;

            //Through selected items names iterating
            foreach (ComApi.InwOaPath path in opState.CurrentSelection.Paths())
            {
                ComApi.InwOaNode node;
                node = path.Nodes().Last() as ComApi.InwOaNode;
                MessageBox.Show(Autodesk.Navisworks.Api.Application.Gui.MainWindow, "UserName=" + node.UserName);
            }
        }

    }
}
