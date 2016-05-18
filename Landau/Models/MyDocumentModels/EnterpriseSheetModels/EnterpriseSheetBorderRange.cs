using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.MyDocumentModels.EnterpriseSheetModels
{
    public class EnterpriseSheetBorderRange
    {
        public List<List<int>> Range;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public EnterpriseSheetBorderRange()
        {
            try
            {
                Range = new List<List<int>>() { new List<int>() };
            }
            catch (Exception exception)
            {

            }
        }

        public EnterpriseSheetBorderRange(int sheetNum, int startRow, int startCol, int endRow, int endCol)
        {
            try
            {
                Range = new List<List<int>>() { new List<int>() {sheetNum, startRow, startCol, endRow, endCol} };
            }
            catch (Exception exception)
            {

            }
        }
    }
}