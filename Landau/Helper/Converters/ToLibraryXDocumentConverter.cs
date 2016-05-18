using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dllModels = XlsxExport.Models.XModels;
using projModels = Landau.Models.XModels;

namespace Landau.Helper
{
    public class ToLibraryXDocumentConverter
    {
        public dllModels.XDocument Convert(projModels.XDocument projDocument)
        {
            List<dllModels.XSheet> xSheets = new List<dllModels.XSheet>();
            foreach (var sheetItem in projDocument.Sheets)
            {
                List<dllModels.XRow> xRows = new List<dllModels.XRow>();
                foreach (var rowItem in sheetItem.Body.Rows)
                {
                    List<dllModels.XCell> xCells = new List<dllModels.XCell>();
                    foreach (var cellItem in rowItem.Cells)
                    {
                        xCells.Add(new dllModels.XCell(cellItem.Id, cellItem.Number, cellItem.Value));
                    }
                    xRows.Add(new dllModels.XRow(rowItem.Id, rowItem.Number, xCells));
                }
                xSheets.Add(new dllModels.XSheet(sheetItem.Id, sheetItem.Number, new dllModels.XBody(sheetItem.Body.Id, xRows)));
            }

            dllModels.XDocument xDocument = new dllModels.XDocument(projDocument.Id, projDocument.Name, xSheets);
            return xDocument;
        }
    }
}