using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.OperationModels
{
    public class TransferCellModel
    {
        /// <summary>
        /// модели перемещаемых строк
        /// </summary>
        public TransferCellModel()
        {
            try
            {

            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Id перемещаемой ячейки
        /// </summary>
        public int SourceCellId { get; set; }

        /// <summary>
        /// тип новой категории
        /// </summary>
        public int NewCategoryType { get; set; }

        /// <summary>
        /// категория текущей ячейки
        /// </summary>
        public int CurrentCategoryType { get; set; }

        /// <summary>
        /// тип документа текущей ячейки
        /// </summary>
        public int CurrentDocumentType { get; set; }

    }
}