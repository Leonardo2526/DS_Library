[Transaction(TransactionMode.Manual)]
    public class Views : IExternalCommand
    {
        readonly string CurDateTime = DateTime.Now.ToString("yyMMdd_HHmmss");

        public Result Execute(ExternalCommandData commandData,
        ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            Document document = application.ActiveUIDocument.Document;

            FilteredElementCollector viewCollector = new FilteredElementCollector(document);
            viewCollector.OfClass(typeof(View));
             
            DS_Tools dS_Tools = new DS_Tools
            {
                DS_LogName = CurDateTime + "_Log.txt"
            };

            foreach (Element viewElement in viewCollector)
            {
                View view = (View)viewElement;
                dS_Tools.DS_StreamWriter(view.Name + "_" + view.Id.ToString() + "\n");
            }

            dS_Tools.DS_FileExistMessage();

            return Result.Succeeded;
        }
    }