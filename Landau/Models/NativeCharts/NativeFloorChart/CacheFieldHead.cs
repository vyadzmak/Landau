using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.NativeCharts.NativeBarChart
{
    public class CacheFieldHead
    {
        public string name { get; set; }
        public CacheFieldHead()
        {
            try
            {
                this.name = "category";
            }
            catch (Exception exception)
            {

            }
        }
    }
}