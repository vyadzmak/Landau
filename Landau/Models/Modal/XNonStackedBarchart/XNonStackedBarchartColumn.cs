using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XNonStackedBarchart
{
    public class XNonStackedBarchartColumn
    { 
        public int Id { get; set; }
        public string PositionX { get; set; }

        public string Description { get; set; }

        public List<XNonStackedBarchartElement> Elements { get; set; }

        public XNonStackedBarchartColumn(int id, string positionX, string description, List<XNonStackedBarchartElement> elements)
        {
            try
            {
                Id = id;
                PositionX = positionX;
                Description = description;
                Elements = elements;
            }
            catch (Exception exception)
            {
                
            }
        }

        public XNonStackedBarchartColumn(int id, string positionX, string description)
        {
            try
            {
                Id = id;
                PositionX = positionX;
                Description = description;
                Elements = new List<XNonStackedBarchartElement>();
            }
            catch (Exception exception)
            {

            }
        }

        public XNonStackedBarchartColumn()
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