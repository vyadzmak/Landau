using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.StackedBarchart
{
    public class XStackedBarchart
    {
        public int Id { get; set; }

        public Position Position { get; set; }
        public string Description { get; set; }

        public string Title { get; set; }
        public List<XStackedBarchartColumn> Columns { get; set; }

        public XStackedBarchart(int id, string description, string title, List<XStackedBarchartColumn> columns, Position position)
        {
            try
            {
                Position = position;
                Id = id;
                Description = description;
                Columns = columns;
                Title = title;
            }
            catch (Exception exception)
            {
                
            }
        }

        public XStackedBarchart(int id, string description, string title, Position position)
        {
            try
            {
                Id = id;
                Description = description;
                Position = position;
                Columns = new List<XStackedBarchartColumn>();
                Title = title;
            }
            catch (Exception exception)
            {

            }
        }

        public XStackedBarchart()
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