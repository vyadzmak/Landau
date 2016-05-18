using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.StackedBarchart
{
    public class XStackedBarchartElement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string Category { get; set; }

        public XStackedBarchartElement(int id, string description, double value, string category)
        {
            try
            {
                Id = id;
                Description = description;
                Value = value;
                Category = category;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}