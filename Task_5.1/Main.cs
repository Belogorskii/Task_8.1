using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;


namespace Task_6._1
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute (ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Documet doc = commandData.Application.ActiveUIDocument.Document;
            using (var ts = new Transaction(doc, "export ifs"))
            {
                tr.Start("Export doc");
                try
                {
                    IFCExportOptions o = new IFCExportOptions();
                    bool ret = doc.Export("D:\\temp\\", "ExportDoc.ifc", o);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.RollBack();
                }
            return Result.Succeeded;
        }
      /*  public void BatchPrint(DocumentPage doc)
        {
            var sheets = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>()
                .ToList();
            var groupedSheets = sheets.GroupBy(sheets => doc.GetElement(new FilteredElementCollector(doc, sheets.Id)
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .FirstElementId()).Name);
            var viewSets = new List<ViewSet>();
            PrintManager printManager = doc.PrintManager;
            printManager.SelectNewPrintDriver("PDFCeator");
            ViewSheetSetting = printManager.ViewSheetSetting;
            foreach (var groupedSheet in groupedSheets)
            {
                if (groupedSheet.Key == null)
                    continue;
                var view Set = new ViewSet();
                var sheetsOfGroup = groupedSheet.Select(sbyte => s).ToList();
                foreach (var sheet in sheetsOfGroup)
                {
                    viewSet.Insert(sheet);
                }
                viewSets.Add(viewSet);
           
                printManager.PrintRange = PrintRange.Select;
                viewSheetSetting.CurrentViewSheetSet.Views = viewSet;

                using (var ts = new Transaction(doc, "Create view set"))
                {
                     ts.Start();
                     viewSheetSetting.SaveAs($"{groupedSheet.Key}_{Guid.NewGuid()}");
                     ts.Commit();
                }

                bool isFormatSelected = false;
                foreach (PaperSize paperSize in printManager.PaperSizes)
                {
                    if(string.Equals(groupedSheet.Key, "A4K") &&
                      string.Equals(paperSise.Name, "A4"))
                    {
                        printManager.PrintSetup.CurrentPrintSetting.PrintParameters.PaperSize = paperSize;
                        printManager.PrintSetup.CurrentPrintSetting.PrintParameters.PageOrientation = PageOrientationType.Portrait;
                        isFormatSelected = true;
                    }
                    else if(string.Equals(groupedSheet.Key, "A3A") &&
                      string.Equals(paperSise.Name, "A3 "))
                    {
                        printManager.PrintSetup.CurrentPrintSetting.PrintParameters.PaperSize = paperSize;
                        printManager.PrintSetup.CurrentPrintSetting.PrintParameters.PageOrientation = PageOrientationType.Landscape;
                        isFormatSelected = true;
                    }
                }
                if(!isPormatSelected)
                {
                     TaskDialog.Show("Ошибка", "Не найден формат")
                     return Result.Failed;
                }
                printManager.CombinedFile = false;
                printManager.SubmitPrint();*/
            }
        }
    }
}
