using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XStackedBarchart.Json
{
    public class JsonStackedBarchartRole
    {
        public string role { get; set; }
        public JsonStackedBarchartRole()
        {
            try
            {
                role = "annotation";
            }
            catch (Exception exception)
            {

            }
        }
    }
}