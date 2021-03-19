void Elemets_Iteration(UIApplication uiapp, DS_Tools dS_Tools)
        {
            Document doc = uiapp.ActiveUIDocument.Document;

            FilteredElementCollector docCollector = new FilteredElementCollector(doc);

            docCollector.WherePasses(new LogicalOrFilter
                (new ElementIsElementTypeFilter(false), new ElementIsElementTypeFilter(true)));

            foreach (Element el in docCollector)
            {
                ElementId elID = el.Id;

                dS_Tools.DS_StreamWriter(el.Name + "_" + el.Category + "_" + el.DesignOption + "_" + el.DesignOption + "_" + el.Parameters + "_" + el.Id);
            }
        }