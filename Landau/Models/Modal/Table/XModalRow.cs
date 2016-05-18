using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class XModalRow
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<XModalCell> Cells { get; set; }

        /// <summary>
        /// Constructor if ModalRow with ready cells
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="cells"></param>
        public XModalRow(int id, int number, List<XModalCell> cells)
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
        public XModalRow(int id, int number)
        {
            try
            {
                Id = id;
                Number = number;
                Cells = new List<XModalCell>();
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty constructor of ModalRow
        /// </summary>
        public XModalRow()
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