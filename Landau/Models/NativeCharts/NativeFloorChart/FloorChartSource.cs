using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.NativeCharts.NativeBarChart
{
    public class FloorChartSource
    {
        public List<List<Object>> series { get; set; }
        public List<List<Object>> categories { get; set; }
        public List<List<Object>> labels { get; set; }
        public bool usAbs { get; set; }
        public List<Object> cacheFields { get; set; }

        public FloorChartSource(List<List<Object>> series, List<List<Object>> categories,
            List<List<Object>> labels, bool usAbs, List<Object> cacheFields)
        {
            try
            {
                this.series = series;
                this.categories = categories;
                this.labels = labels;
                this.usAbs = usAbs;
                this.cacheFields = cacheFields;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}