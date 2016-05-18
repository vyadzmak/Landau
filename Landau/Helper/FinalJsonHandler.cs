using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Helper;

namespace Landau.Helper
{
    /// <summary>
    /// We need that class because of incorrect implementation of json null fields remover
    /// </summary>
    public class FinalJsonHandler
    {
        public string ClearJson(string json)
        {
            try
            {
                json = Extensions.RemoveJsonNulls(json);
                return json.Replace(",}", "}");
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}