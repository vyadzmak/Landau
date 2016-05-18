using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal
{
    public class ChartInfo
    {
        public int AnalyticDataId { get; set; }
        public int TypeId { get; set; }

        public ChartInfo(int analyticDataId, int typeId)
        {
            try
            {
                AnalyticDataId = analyticDataId;
                TypeId = typeId;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}