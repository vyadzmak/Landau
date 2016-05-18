using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XNonStackedBarchart.Json
{
    public class JsonNonStackedBarchart
    {
        public int id { get; set; }
        public int typeId { get; set; }

        public Position position { get; set; }
        public string description { get; set; }
        public List<List<Object>> elements { get; set; }

        public JsonNonStackedBarchart(int id, List<List<Object>> elements, string description, Position position)
        {
            try
            {
                this.position = position;
                this.id = id;
                this.typeId = 6;
                this.description = description;
                this.elements = elements;
            }
            catch (Exception exception)
            {

            }
        }
    }
}