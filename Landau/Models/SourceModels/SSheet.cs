using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landau.Models.SourceModels
{
    /// <summary>
    /// модель вкладки
    /// </summary>
    public class SSheet
    {
        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        public SSheet()
        {
            try
            {
                Rows = new List<SRow>();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// rows
        /// </summary>
        public List<SRow> Rows { get; set; }
        #endregion
    }
}
