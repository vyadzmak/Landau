using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.NativeCharts.NativeBarChart
{
    public class CacheField
    {
        public string name { get; set; }
        public string title { get; set; }

        public CacheField(string name, string title)
        {
            try
            {
                this.name = name;
                this.title = title;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}