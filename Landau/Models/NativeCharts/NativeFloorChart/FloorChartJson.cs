using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.NativeCharts.NativeBarChart;

namespace Landau.Models.NativeCharts
{
    public class FloorChartJson
    {
        #region fields
        public string seriesPosition { get; set; }
        public string legendPosition { get; set; }
        public string chartType { get; set; }
        public string floorType { get; set; }
        public FloorChartSource source { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string id { get; set; }
        public int sheetId { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// Constructor of native bar chart
        /// </summary>
        /// <param name="seriesPosition"></param>
        /// <param name="legendPosition"></param>
        /// <param name="chartType"></param>
        /// <param name="source"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="id"></param>
        /// <param name="sheetId"></param>
        public FloorChartJson(string seriesPosition, string legendPosition, 
            string chartType, FloorChartSource source, int x, int y, int width, int height, string id, int sheetId)
        {
            try
            {
                this.seriesPosition = seriesPosition;
                this.legendPosition = legendPosition;
                this.chartType = chartType;
                this.source = source;
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
                this.id = id;
                this.sheetId = sheetId;
                this.floorType = "chart";
            }
            catch (Exception exception)
            {

            }
        }
        #endregion
    }
}