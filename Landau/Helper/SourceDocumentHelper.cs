using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.DB;
using System.Data.Linq;

namespace Landau.Helper
{
    public static class SourceDocumentHelper
    {
        public static void UpdateSourceDocument(bool isSource, int documentId, string changes)
        {
            try
            {
               OperationsHelper.MakeTransferCells(isSource, documentId, changes);
                //using (LandauEntities db = new LandauEntities())
                //{
                //    foreach (var cellItem in changedCells)
                //    {
                //        int rowId = (int)cellItem["Id"];
                //        List<SourceDocumentCell> query = (from c in db.SourceDocumentCell where c.SourceDocumentRowId == rowId select c).ToList();

                //        foreach (SourceDocumentCell queryItem in query)
                //        {
                //            queryItem.AnalyticDataType = Int32.Parse(cellItem["Value"].ToString());
                //            // db.SourceDocumentCell.
                //        }

                //        db.SaveChanges();
                //    }
                //}
            }
            catch (Exception exception)
            {

            }
        }
    }
}