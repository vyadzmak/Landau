using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.XModels
{
    public class XBorder
    {
        public int Id { get; set; }

        public int StartRowNumber { get; set; }

        public int EndRowNumber { get; set; }

        public int StartColNumber { get; set; }

        public int EndColNumber { get; set; }

        public string Position { get; set; }

        public int Width { get; set; }

        public string Color { get; set; }

        public string LineType { get; set; }

        public int SheetNumber { get; set; }

        public XBorder(int id, int startRow, int endRow, int startCol, 
            string position, int width, string lineType, int endCol, string color, int number)
        {
            try
            {
                Id = id;
                StartColNumber = startCol;
                EndColNumber = endCol;
                StartRowNumber = startRow;
                EndRowNumber = endRow;
                Color = color;
                SheetNumber = number;
                Width = width;
                LineType = lineType;
                Position = position;
            }
            catch (Exception exception)
            {

            }
        }
    }
}