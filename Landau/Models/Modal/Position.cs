using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int col)
        {
            try
            {
                Row = row;
                Column = col;
            }
            catch (Exception exception)
            {

            }
        }
    }
}