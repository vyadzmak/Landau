using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landau.Models.SourceModels
{
    /// <summary>
    /// модель ячейки
    /// </summary>
    public class SCell
    {

        public SCell(string value)
        {
            try
            {
                Value = value;
            }
            catch (Exception exception)
            {
                
            }
        }

        public SCell()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }
    
        /// <summary>
        /// идентификатор строки, к которой принадлежит ячейка
        /// </summary>
        public int RowId { get; set; }
        /// <summary>
        /// номер ячейки
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// значение ячейки
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// тип значения
        /// </summary>
        public string ValueType { get; set; }

        /// <summary>
        /// тип документа
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// тип аналитических данных
        /// </summary>
        public string AnalyticDataType { get; set; }
    }
}
