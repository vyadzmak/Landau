using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XMoveTable
{
    public class XMoveTableRow
    {
        public List<XMoveTableCell> Cells { get; set; }

        public string Category { get; set; }

        public int Number { get; set; }

        #region constructors
        public XMoveTableRow()
        {
            try
            {
                Cells = new List<XMoveTableCell>();
            }
            catch (Exception exception)
            {
            }
        }

        public XMoveTableRow(int number, string category, List<XMoveTableCell> cells)
        {
            try
            {
                Number = number;
                Cells = cells;
                Category = category;
            }
            catch (Exception exception)
            {

            }
        }

        #endregion
    }
}