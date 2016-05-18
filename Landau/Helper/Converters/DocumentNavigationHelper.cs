using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.XModels;
using Landau.DB;

namespace Landau.Helper
{
    public static class DocumentNavigationHelper
    {
        #region methods
        /// <summary>
        /// Returns sheet by index, or null, if not exists
        /// </summary>
        /// <param name="document"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static XSheet GetSheetByNumber(XDocument document, int number)
        {
            try
            {
                foreach (var sheet in document.Sheets)
                {
                    if (sheet.Number == number)
                    {
                        return sheet;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns row by index, returns null, if not exists
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static XRow GetRowbyNumber(XBody body, int number)
        {
            try
            {
                foreach (var row in body.Rows)
                {
                    if (row.Number == number)
                    {
                        return row;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns cell by index, returns null, if not exists
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static XCell GetCellByNumber(XRow row, int number)
        {
            try
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.Number == number)
                    {
                        return cell;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Getting cell id by its sheet, row, and column number, and document id it belongs to
        /// </summary>
        /// <param name="docId"></param>
        /// <param name="sheetNum"></param>
        /// <param name="rowNum"></param>
        /// <param name="colNum"></param>
        /// <returns></returns>
        public static int GetNecessaryCellId(int docId, int sheetNum, int rowNum, int colNum)
        {
            try
            {
                using (var db = new LandauEntities())
                {

                    Sheet validSheet = (from sh in db.Sheet where sh.DocumentId == docId && sh.Number == sheetNum select sh).ToList().LastOrDefault();
                    int valSheetId = validSheet.Id;

                    Body validBody = (from b in db.Body where b.SheetId == valSheetId select b).ToList().LastOrDefault();
                    int valBodyId = validBody.Id;

                    Row validRow = (from r in db.Row where r.Number == rowNum && r.BodyId == valBodyId select r).ToList().LastOrDefault();
                    int valRowId = validRow.Id;

                    List<Cell> cl = (from c in db.Cell where c.RowId == valRowId && c.Number == colNum select c).ToList();

                    return (int)cl[0].Id;
                }
            }
            catch (Exception exception)
            {
                return 0;
            }
        }
        #endregion
    }
}