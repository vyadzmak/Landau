using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.NativeCharts.NativeBarChart
{
    public class NativeFloorChart
    {
        public int sheet { get; set; }
        public string name { get; set; }
        public string ftype { get; set; }
        public FloorChartJson json { get; set; }

        public NativeFloorChart(int sheet, string name, FloorChartJson json)
        {
            try
            {
                this.sheet = sheet;
                this.name = name;
                this.ftype = "floor";
                this.json = json;
            }
            catch (Exception exception)
            {
                
            }
        }

    }
}