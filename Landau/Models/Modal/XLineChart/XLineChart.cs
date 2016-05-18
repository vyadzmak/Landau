using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XLineChart
{
    public class XLineChart
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public Position Position { get; set; }

        public string Description { get; set; }

        public List<XLineChartElement> Elements { get; set; }

        public XLineChart(int id, string description, List<XLineChartElement> elements, Position position, string type)
        {
            try
            {
                Position = position;
                Type = type;
                Id = id;
                Description = description;
                Elements = elements;
            }
            catch (Exception exception)
            {

            }
        }

        public XLineChart(int id, string description, Position position, string type)
        {
            try
            {
                Id = id;
                Type = type;
                Position = position;
                Description = description;
                Elements = new List<XLineChartElement>();
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}