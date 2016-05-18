using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.OperationModels
{
    public class TransferCellsModel
    {
        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        public TransferCellsModel()
        {
            try
            {
                Cells = new List<TransferCellModel>();
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
        public List<TransferCellModel> Cells { get; set; }
        #endregion
    }
}