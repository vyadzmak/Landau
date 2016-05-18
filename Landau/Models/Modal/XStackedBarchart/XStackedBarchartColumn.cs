using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.StackedBarchart
{
    public class XStackedBarchartColumn
    {
        public int Id { get; set; }
        public string PositionX { get; set; }

        public string Description { get; set; }

        public List<XStackedBarchartElement> Elements { get; set; }

        public XStackedBarchartColumn(int id, string positionX, string description, List<XStackedBarchartElement> elements)
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

        public XStackedBarchartColumn(int id, string positionX, string description)
        {
            try
            {
                Id = id;
                PositionX = positionX;
                Description = description;
                Elements = new List<XStackedBarchartElement>();
            }
            catch (Exception exception)
            {

            }
        }

        public XStackedBarchartColumn()
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