using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.XModels
{
    public class XSheet
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public XBody Body { get; set; }

        public List<XBorder> Borders { get; set; }

        public XSheet(int id, int number, string name, XBody body)
        {
            try
            {
                Id = id;
                Number = number;
                Name = name;
                Body = body;
            }
            catch (Exception)
            {

            }
            
        }

        public XSheet(int id, int number,  XBody body)
        {
            try
            {
                Id = id;
                Number = number;
                Name = number.ToString();
                Body = body;
            }
            catch (Exception)
            {

            }

        }

        public XSheet()
        {
            try
            {
                Body = new XBody();
            }
            catch (Exception exception)
            {

            }
        }

        public XSheet(int id, int number, string name)
        {
            try
            {
                Id = id;
                Number = number;
                Name = name;
                Body = new XBody();
            }
            catch (Exception exception)
            {

            }

        }
    }
}