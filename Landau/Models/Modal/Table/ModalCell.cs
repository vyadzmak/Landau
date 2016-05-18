using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class ModalCell
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int Number { get; set; }

        public int CellId { get; set; }
        /// <summary>
        /// Constructor if ModalCell
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public ModalCell(int id, string value, int number, int cellId)
        {
            try
            {
                Id = id;
                Value = value;
                Number = number;
                CellId = cellId;
            }
            catch (Exception exception)
            {
                
            }
        }
        public ModalCell(int id, string value, int number)
        {
            try
            {
                Id = id;
                Value = value;
                Number = number;
                CellId = 0;
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty constructor of ModalCell
        /// </summary>
        public ModalCell()
        {
            try
            {

            }
            catch (Exception exception)
            {
                
            }
        }
        
    }
}