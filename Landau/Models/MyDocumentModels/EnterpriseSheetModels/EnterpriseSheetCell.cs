using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.MyDocumentModels.EnterpriseSheetModels;

namespace Landau.Models.MyDocumentModels.EnterpriseSheetModels
{
    public class EnterpriseSheetCell
    {
        #region fields
        public int sheet { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public EnterpriseSheetJson json { get; set; }
        #endregion

        #region construtors
        /// <summary>
        /// Filling the cell
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="json"></param>
        public EnterpriseSheetCell(int sheet, int row, int col, EnterpriseSheetJson json)
        {
            try
            {
                this.sheet = sheet;
                this.row = row;
                this.col = col;
                this.json = json;
            }
            catch (Exception exception)
            {

            }
        }

        public EnterpriseSheetCell()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

        #endregion
    }
}