using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XLineChart.Json
{
    public class JsonLinechart
    {
        public int id { get; set; }
        public string type { get; set; }
        public Position position { get; set; }
        public int typeId { get; set; }
        public string description { get; set; }
        public List<List<Object>> elements { get; set; }

        public JsonLinechart(int id, string description, List<List<Object>> elements, Position position, string type)
        {
            try
            {
                this.position = position;
                this.id = id;
                this.typeId = 2;
                this.description = description;
                this.elements = elements;
                this.type = type;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}