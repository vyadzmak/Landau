using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XLineChart
{
    public class XLineChartElement
    {
        public int Id { get; set; }

        public List<XPointLineChart> Points { get; set; }

        public string Description { get; set; }

        public XLineChartElement(int id, List<XPointLineChart> points, string description)
        {
            try
            {
                Id = id;
                Points = points;
                Description = description;
            }
            catch (Exception exception)
            {

            }
        }

        public XLineChartElement(int id, string description)
        {
            try
            {
                Id = id;
                Points = new List<XPointLineChart>();
                Description = description;
            }
            catch (Exception exception)
            {

            }
        }
    }
}