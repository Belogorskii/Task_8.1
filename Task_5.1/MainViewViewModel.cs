using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Task_5._1
{
    public class MainViewViewModel
    {
        private ExternalCommandData _commandData;

        public Furniture Furniture { get; }

        public List<FamilySymbol> FamilyTypes { get; } = new List<FamilySymbol>();

        public DelegateCommand SaveCommand { get; }

        public FamilySymbol SelectedFamilyType { get; set; }

        public MainViewViewModel(ExternalCommandData commandData)

         {
            _commandData = commandData;
            Furniture = SelectionUtils.GetObject<Furniture>(commandData, "Выберете мебель");
            FamilyTypes = FamilySymbolUtils.GetFamilySymbols(commandData);
            SaveCommand = new DelegateCommand(OnSaveCommand);
         }

        private void OnSaveCommand()
        {
            UIApplication uiapp = _commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var locationCurve = Furniture.Location as locationCurve;
            var pipeCurve = locationCurve.Curve;
            var oLevel = (Level)doc.GetElement(Furniture.LevelId);

            FamilyInstanceUtills.CreateFamilyInstance(_commandData, SelectedFamilyType, furnitureCurve.GetEndPoint(0), oLevel);
            FamilyInstanceUtills.CreateFamilyInstance(_commandData, SelectedFamilyType, furnitureCurve.GetEndPoint(1), oLevel);

            RaiseCloseRequest();

        }
        
        public event EventHandler CloseRequested;
        private void RaiseCloseRequest()
        { 
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}