using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Chart
{
    public class PieElementJsonModel
    {
        //public double value { get; set; }
        //public string label { get; set; }

        public List<Object> element { get; set; }

        public PieElementJsonModel(double value, string label)
        {
            try
            {
                element = new List<Object>(2);
                element[0] = (Object)label;
                element[1] = (Object)value;
            }
            catch (Exception exception)
            {

            }
        }
    }
}