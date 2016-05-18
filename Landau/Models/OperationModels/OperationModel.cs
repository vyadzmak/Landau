using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.OperationModels
{
    public class OperationModel
    {
        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        public OperationModel()
        {
            try
            {
                TransferCells = new TransferCellsModel();
                Contragents = new List<string>();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region fields
        /// <summary>
        /// тип операции
        /// </summary>
        public int OperationType { get; set; }

        /// <summary>
        /// Id проекта
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// пользовательский Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// клиентский Id
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Id исходного документа
        /// </summary>
        public int SourceDocumentId { get; set; }

        /// <summary>
        /// перемещаемые ячейки
        /// </summary>
        public TransferCellsModel TransferCells { get; set; }

        /// <summary>
        /// контрагенты
        /// </summary>
        public List<string> Contragents { get; set; }
        #endregion

    }
}