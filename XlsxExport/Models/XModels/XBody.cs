using System;
using System.Collections.Generic;

namespace XlsxExport.Models.XModels
{
    public class XBody
    {
        public int Id { get; set; }

        public List<XRow> Rows { get; set; }

        #region constructors

        /// <summary>
        /// Empty constructor of XBody
        /// </summary>
        public XBody()
        {
            try
            {
                Rows = new List<XRow>();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Constructor of XBody
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rows"></param>
        public XBody(int id, List<XRow> rows)
        {
            Id = id;
            Rows = rows;
        }

        /// <summary>
        /// Constructor of XBody
        /// </summary>
        /// <param name="rows"></param>
        public XBody(List<XRow> rows)
        {
            Rows = rows;
        }

        #endregion
    }
}