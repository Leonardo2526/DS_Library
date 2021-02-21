[Transaction(TransactionMode.Manual)]
    public class OpenDoc : IExternalCommand

    {
        //Get current date and time 
        readonly string CurDate = DateTime.Now.ToString("yyMMdd");
        readonly string CurDateTime = DateTime.Now.ToString("yyMMdd_HHmmss");
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }

        public Result Execute(ExternalCommandData commandData,
        ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;

            Program(uiapp);

            return Result.Succeeded;
        }
        public void Program(UIApplication uiapp)
        {
            DS_Form newForm = new DS_Form
            {
                TopLevel = true
            };
            newForm.Show();

            DS_Tools dS_Tools = new DS_Tools
            {
                DS_LogName = CurDateTime + "_Log.txt"
            };

            SourcePath = newForm.DS_OpenInputFolderDialogForm("Set '*.rvt' file").ToString();
            if (SourcePath == "")
            {
                return;
            }

            newForm.Close();

            List<string> FileFullNames = new List<string>();
            DS_DirTools dS_DirTools = new DS_DirTools();
            FileFullNames = dS_DirTools.DS_GetFileNamesList(SourcePath, "rvt");

            ModelPath mp = ModelPathUtils.ConvertUserVisiblePathToModelPath(FileFullNames[0]);

            OpenOptions options1 = new OpenOptions
            {
                DetachFromCentralOption = DetachFromCentralOption.DetachAndDiscardWorksets
            };

            uiapp.OpenAndActivateDocument(mp, options1, false);

            //Document doc = uiapp.Application.OpenDocumentFile(mp, options1);
            //MessageBox.Show(doc.IsDetached.ToString());

            /*
            foreach (string FileName in FileFullNames)
            {
                ModelPath mp = ModelPathUtils.ConvertUserVisiblePathToModelPath(FileName);

                OpenOptions options1 = new OpenOptions
                {
                    DetachFromCentralOption = DetachFromCentralOption.DetachAndDiscardWorksets
                };

                Document doc = uiapp.Application.OpenDocumentFile(mp, options1);
                MessageBox.Show(doc.IsDetached.ToString());
            }
            */


            dS_Tools.DS_FileExistMessage();

        }
        private static ModelPath GetWSAPIModelPath(string fileName)
        {
            // Utility to get a local path for a target model file
            FileInfo filePath = new FileInfo(Path.Combine(@"C:\Documents\Revit Projects", fileName));
            ModelPath mp = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath.FullName);

            return mp;
        }



    }