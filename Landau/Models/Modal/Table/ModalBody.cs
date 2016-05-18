using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class ModalBody
    {
        public int Id { get; set; }
        public List<ModalRow> Rows { get; set; }

        /// <summary>
        /// Constructor of ModalBody with ready rows
        /// </summary>
        /// <param name="rows"></param>
        public ModalBody(int id, List<ModalRow> rows)
        {
            try
            {
                Id = id;
                Rows = rows;
            }
            catch (Exception exception)
            {
                
            }
        }

        /// <summary>
        /// Constructor of ModalBody with empty rows
        /// </summary>
        public ModalBody(int id)
        {
            try
            {
                Id = id;
                Rows = new List<ModalRow>();
            }
            catch (Exception exception)
            {

            }
        }
    }
}