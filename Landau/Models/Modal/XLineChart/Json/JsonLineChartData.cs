using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XLineChart.Json
{
    public class JsonLineChartData
    {

        public List<string> labels { get; set; }

        public List<JsonDataset> datasets { get; set; }

        public JsonLineChartData(List<string> labels, List<JsonDataset> datasets)
        {
            try
            {
                this.labels = labels;
                this.datasets = datasets;
            }
            catch (Exception exception)
            {
                
            }
        }

        public JsonLineChartData()
        {
            try
            {
                this.labels = new List<string>();
                this.datasets = new List<JsonDataset>();
            }
            catch (Exception exception)
            {

            }
        }
    }
}