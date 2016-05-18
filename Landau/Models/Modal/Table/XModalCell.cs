using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsoleSandbox.Models.Modal.Table;

namespace Landau.Models.Modal.Table
{
    public class XModalCell
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int Number { get; set; }
        public bool IsHyperLink { get; set; }
        public int ModalViewId { get; set; }
        public XModalCellStyle Style { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="number"></param>
        /// <param name="modalViewId"></param>
        /// <param name="xModalCellStyle"></param>
        public XModalCell(int id, string value, int number, int modalViewId, XModalCellStyle style)
        {
            try
            {
                Id = id;
                Value = value;
                Number = number;
                IsHyperLink = true;
                ModalViewId = modalViewId;
                Style = style;
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public XModalCell(int id, string value, int number, XModalCellStyle style)
        {
            try
            {
                Id = id;
                Value = value;
                Number = number;
                IsHyperLink = false;
                ModalViewId = 0;
                Style = style;
            }
            catch (Exception exception)
            {

            }
        }


        /// <summary>
        /// Empty constructor
        /// </summary>
        public XModalCell()
        {
            try
            {
                Style = new XModalCellStyle();
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}