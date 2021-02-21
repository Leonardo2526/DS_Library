using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.Interop.ComApi;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;

namespace DS_NWClass_Template
{
    [Plugin("TestPlugin_4", "DS", ToolTip = "", DisplayName = "TestPlugin_4")]

    public class TestPlugin : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            Program();

            return 0;
        }

        public void Program()
        {
            Document oDoc =

       Autodesk.Navisworks.Api.Application.ActiveDocument;

            // assume we get two model items

            ModelItem oItem1 = oDoc.Models[6].RootItem.DescendantsAndSelf.
                ElementAt<ModelItem>(0);


            // create ModelItemCollection

            ModelItemCollection oSel_Net = new ModelItemCollection
            {
                oItem1
            };


            //highlight by COM API

            ComApi.InwOpState10 oState = ComApiBridge.State;
            ComApi.InwOpSelection comSelectionOut = ComApiBridge.ToInwOpSelection(oSel_Net);

            oState.CurrentSelection = comSelectionOut;


        }

    }
}
