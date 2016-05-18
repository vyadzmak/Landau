using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Chart
{
    public class XPieChartElement
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public XPieChartElement(double value, string description)
        {
            try
            {
                Value = value;
                Description = description;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}