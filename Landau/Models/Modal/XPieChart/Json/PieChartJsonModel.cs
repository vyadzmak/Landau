using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.Modal;

namespace Landau.Models.Chart
{
    public class PieChartJsonModel
    {
        public int id { get; set; }
        public int typeId { get; set; }

        public Position position { get; set; }
        public string description { get; set; }
        public List<List<Object>> elements { get; set; }

        public string title { get; set; }
        public PieChartJsonModel(int id, List<List<Object>> elements, string description, Position position)
        {
            try
            {
                this.id = id;
                this.position = position;
                this.typeId = 1;
                this.elements = elements;
                this.description = description;
                this.title = description;
            }
            catch (Exception exception)
            {

            }
        }
    }
}