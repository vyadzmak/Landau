using System;
using System.Collections.Generic;

namespace Landau.Models.XModels
{
    public class XRow
    {
        /// <summary>
        /// Row's identity number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Row's number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<XCell> Cells { get; set; }

        /// <summary>
        /// Row's constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="cell"></param>
        public XRow(int id, int number)
        {
            try
            {
                Id = id;
                Number = number;
                Cells = new List<XCell>();
            }

            catch (Exception)
            {
                
                throw;
            }
        }

        public XRow(int id, int number, List<XCell> cells)
        {
            try
            {
                Id = id;
                Number = number;
                Cells = cells;

            }

            catch (Exception)
            {

                throw;
            }
        }

        public XRow()
        {
            try
            {
                Cells = new List<XCell>();
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}