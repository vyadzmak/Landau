using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class XModalBody
    {
        public int Id { get; set; }
        public List<XModalRow> Rows { get; set; }

        /// <summary>
        /// Constructor of ModalBody with ready rows
        /// </summary>
        /// <param name="rows"></param>
        public XModalBody(int id, List<XModalRow> rows)
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
        public XModalBody(int id)
        {
            try
            {
                Id = id;
                Rows = new List<XModalRow>();
            }
            catch (Exception exception)
            {

            }
        }
    }
}