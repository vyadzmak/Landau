using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landau.Models.SourceModels
{
    /// <summary>
    /// модель документа
    /// </summary>
    public class SDocument
    {

        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        public SDocument()
        {
            try
            {
                Sheets = new List<SSheet>();
                CellTypes = new List<object>();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region fields
        /// <summary>
        /// вкладки 
        /// </summary>
        public List<SSheet> Sheets { get; set; }

        /// <summary>
        /// имя документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// сопутствующий список видов проводок
        /// </summary>
        public List<object> CellTypes { get; set; }

        
        /// <summary>
        /// расширение файла
        /// </summary>
        public string Extension { get; set; }


        #endregion
    }
}
