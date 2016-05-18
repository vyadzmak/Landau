using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.Modal;

namespace Landau.Models.Chart
{
    public class XPieChart
    {
        public int Id { get; set; }

        public Position Position { get; set; }

        public string Description { get; set; }

        public List<XPieChartElement> Elements { get; set; }

        /// <summary>
        /// Constructor with all properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="elements"></param>
        public XPieChart(int id, string description, List<XPieChartElement> elements, Position position)
        {
            try
            {
                Id = id;
                Description = description;
                Elements = elements;
            }
            catch (Exception exception)
            {

            }
        }

        public XPieChart(int id, string description, Position position)
        {
            try
            {
                Position = position;
                Id = id;
                Description = description;
                Elements = new List<XPieChartElement>();
            }
            catch (Exception exception)
            {

            }
        }

        public XPieChart()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }
    }
}