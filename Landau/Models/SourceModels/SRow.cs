using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landau.Models.SourceModels
{
    /// <summary>
    /// модель строки
    /// </summary>
    public class SRow
    {
        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        public SRow()
        {
            try
            {
                Cells = new List<SCell>();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region fields

        /// <summary>
        /// ячейки
        /// </summary>
        public List<SCell> Cells { get; set; }

        public string DocumentType { get; set; }
        public string AnalyticDataType { get; set; }
        #endregion

    }
}
