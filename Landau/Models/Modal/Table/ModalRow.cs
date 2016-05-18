using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class ModalRow
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<ModalCell> Cells { get; set; }

        /// <summary>
        /// Constructor if ModalRow with ready cells
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="cells"></param>
        public ModalRow(int id, int number, List<ModalCell> cells)
        {
            try
            {
                Id = id;
                Cells = cells;
                Number = number;
            }
            catch (Exception exception)
            {
                
            }
        }

        /// <summary>
        /// Constructor of ModalRow with empty cells
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        public ModalRow(int id, int number)
        {
            try
            {
                Id = id;
                Number = number;
                Cells = new List<ModalCell>();
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty constructor of ModalRow
        /// </summary>
        public ModalRow()
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