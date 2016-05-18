using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XLineChart
{
    public class XPointLineChart
    {
        public int Id { get; set; }

        public string PositionX { get; set; }

        public double PositionY { get; set; }

        public string Category { get; set; }

        public XPointLineChart(int id, string positionX, double positionY, string category)
        {
            try
            {
                Id = id;
                PositionX = positionX;
                PositionY = positionY;
                Category = category;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}