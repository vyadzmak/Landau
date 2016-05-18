using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XStackedBarchart.Json
{
    public class JsonStackedBarchart
    {
        public int id { get; set; }
        public int typeId { get; set; }
        public string title { get; set; }
        public Position position { get; set; }
        public string description { get; set; }
        public List<List<Object>> elements { get; set; }

        public JsonStackedBarchart(int id, List<List<Object>> elements, string description, Position position, string title)
        {
            try
            {
                this.position = position;
                this.id = id;
                this.typeId = 5;
                this.description = description;
                this.elements = elements;
                this.title = title;
            }
            catch (Exception exception)
            {

            }
        }
    }
}