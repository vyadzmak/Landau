using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XLineChart.Json
{
    public class JsonLine
    {
        public int typeId;
        public string description; 
        public JsonLineChartData data;

        public JsonLine(JsonLineChartData data, string description)
        {
            typeId = 2;
            this.data = data;
            this.description = description;
        }
    }
}