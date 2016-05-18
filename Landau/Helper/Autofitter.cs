using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.XModels;

namespace Landau.Helper
{
    public class Autofitter
    {

        public XDocument Document { get; set; }
        /// <summary>
        /// Counts needed width for column
        /// </summary>
        /// <param name="fontSize"></param>
        /// <param name="stringLength"></param>
        /// <returns></returns>
        public int StringWidthCalcuation(XCell xCell)
        {
            try
            {
                if (xCell.Style.FontSize != 0)
                {
                    return (xCell.Style.FontSize / 2 * xCell.Value.Length) + (xCell.Style.FontSize / 2 * xCell.Value.Length) / 2;
                }
                return CellPropertiesValidator.WidthDefault;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Counts used columns on the sheet
        /// </summary>
        /// <param name="xSheet"></param>
        /// <returns></returns>
        public int ColumnsCounter(XSheet xSheet)
        {
            try
            {
                List<int> rowLengths = new List<int>();

                foreach (var rowItem in xSheet.Body.Rows)
                {
                    rowLengths.Add(rowItem.Cells.Count);
                }

                return rowLengths.Max();
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Generate row with autofit
        /// </summary>
        /// <returns></returns>
        public XRow GenerateAutofit(XSheet xSheet)
        {
            try
            {
                NewIdAndNumberGetter getter = new NewIdAndNumberGetter();
                XCell cellWithLongestValue = new XCell();
                List<XCell> fitCells = new List<XCell>();

                List<List<XCell>> columns = CreateColumns(xSheet);

                foreach (var columnItem in columns)
                {
                    cellWithLongestValue = FindLongestValue(columnItem);
                    int columnWidth = StringWidthCalcuation(cellWithLongestValue);

                    if (columnWidth == 0)
                    {
                        columnWidth = 80; // Default width
                    }

                    XCell fitCell = new XCell(getter.GetNewCellId(), columns.IndexOf(columnItem) + 1, "",
                        new XStyle(columnWidth),
                        new XComment(getter.GetNewCommentId(), ""), new XFormat("", ""), true, false);
                    fitCells.Add(fitCell);

                }

                XRow fitRow = new XRow(getter.GetNewRowId(), 0, fitCells);

                return fitRow;

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Constructs columns
        /// </summary>
        /// <param name="xSheet"></param>
        /// <returns></returns>
        public List<List<XCell>> CreateColumns(XSheet xSheet)
        {
            try
            {
                int columnsNumber = ColumnsCounter(xSheet);
                List<List<XCell>> columns = new List<List<XCell>>();

                for (int i = 1; i <= columnsNumber; i++)
                {
                    List<XCell> column = new List<XCell>();
                    foreach (var rowItem in xSheet.Body.Rows)
                    {
                        foreach (var cellItem in rowItem.Cells)
                        {
                            if (cellItem.Number == i)
                            {
                                column.Add(cellItem);
                                break;
                            }
                        }
                    }

                    columns.Add(column);
                }

                return columns;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Finds bearing cell to autofit whole column
        /// </summary>
        /// <param name="xCells"></param>
        /// <returns></returns>
        public XCell FindLongestValue(List<XCell> xCells)
        {
            try
            {
                int maxLength = int.MinValue;
                XCell cellWithLongestValue = new XCell();

                foreach (var cellItem in xCells)
                {
                    if (cellItem.Value == null)
                    {
                        cellItem.Value = "";
                    }
                    if (cellItem.Value.Length > maxLength)
                    {
                        maxLength = cellItem.Value.Length;
                    }

                }

                foreach (var cellItem in xCells)
                {
                    if (cellItem.Value.Length == maxLength)
                    {
                        cellWithLongestValue = cellItem;
                    }

                }

                return cellWithLongestValue;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Adds autofit to the sheet
        /// </summary>
        /// <param name="xDocument"></param>
        /// <returns></returns>
        public XDocument GetAutofitedDocument(XDocument xDocument)
        {
            try
            {
                Document = xDocument;

                foreach (var sheetItem in xDocument.Sheets)
                {
                    sheetItem.Body.Rows.Add(GenerateAutofit(sheetItem));
                }

                return Document;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}