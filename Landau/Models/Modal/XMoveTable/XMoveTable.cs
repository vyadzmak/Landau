using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XMoveTable
{
    public class XMoveTable
    {
        #region fields

        public Guid GUID { get; set; }

        public List<XMoveTableRow> Rows { get; set; }

        #endregion

        #region constructors

        public XMoveTable()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }
        public XMoveTable(Guid guid)
        {
            try
            {
                GUID = guid;
                Rows = new List<XMoveTableRow>();
            }
            catch (Exception exception)
            {

            }
        }
        public XMoveTable(Guid guid, List<XMoveTableRow> rows)
        {
            try
            {
                GUID = guid;
                Rows = rows;
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

    }
}