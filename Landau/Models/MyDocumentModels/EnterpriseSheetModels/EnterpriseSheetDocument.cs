using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.MyDocumentModels.EnterpriseSheetModels;

namespace Landau.Models.MyDocumentModels.EnterpriseSheetModels
{
    public class EnterpriseSheetDocument
    {
        public string fileName { get; set; }
        public int version { get; set; }
        public List<EnterpriseSheetSheet> sheets { get; set; }
        public List<EnterpriseSheetCell> cells { get; set; }
        public List<EnterpriseSheetGroup> floatings { get; set; }

        #region constructors
        /// <summary>
        /// ES Document empty constructor
        /// </summary>
        public EnterpriseSheetDocument()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// ES document constructor
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheets"></param>
        /// <param name="cells"></param>
        /// <param name="floatings"></param>
        public EnterpriseSheetDocument(string fileName, int version, List<EnterpriseSheetSheet> sheets,
            List<EnterpriseSheetCell> cells, List<EnterpriseSheetGroup> floatings)
        {
            try
            {
                this.fileName = fileName;
                this.sheets = sheets;
                this.cells = cells;
                this.floatings = floatings;
                this.version = version;
            }
            catch (Exception exception)
            {

            }
        }
        #endregion

    }
}