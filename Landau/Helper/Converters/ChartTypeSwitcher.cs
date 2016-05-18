using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Helper
{
    public class ChartTypeSwitcher
    {
        public static int GetChartTypeId(string id)
        {
            try
            {
                if (id == "p") { return 1; }

                if (id == "li") { return 2; }

                if (id == "b") { return 3; }

                if (id == "t") { return 4; }

                return 0;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }
    }
}