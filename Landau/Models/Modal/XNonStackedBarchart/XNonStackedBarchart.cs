using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XNonStackedBarchart
{
    public class XNonStackedBarchart
    {
        
        public int Id { get; set; }

        public Position Position { get; set; }
        public string Description { get; set; }

        public List<XNonStackedBarchartColumn> Columns { get; set; }

        public XNonStackedBarchart(int id, string description, List<XNonStackedBarchartColumn> columns, Position position)
        {
            try
            {
                Position = position;
                Id = id;
                Description = description;
                Columns = columns;
            }
            catch (Exception exception)
            {
                
            }
        }

        public XNonStackedBarchart(int id, string description, Position position)
        {
            try
            {
                Id = id;
                Description = description;
                Position = position;
                Columns = new List<XNonStackedBarchartColumn>();
            }
            catch (Exception exception)
            {

            }
        }

        public XNonStackedBarchart()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }
    
    }
}