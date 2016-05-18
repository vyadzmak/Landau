using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XNonStackedBarchart.Json
{
    public class JsonNonStackedBarchartRole
    {
        public string role { get; set; }
        public JsonNonStackedBarchartRole()
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