using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XlsxExport.Models.XModels
{
    public class XSheet
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public XBody Body { get; set; }

        public XSheet(int id, int number, XBody body)
        {
            try
            {
                Id = id;
                Number = number;
                Body = body;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public XSheet()
        {
            try
            {
                Body = new XBody();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public XSheet(int id, int number)
        {
            try
            {
                Id = id;
                Number = number;
                Body = new XBody();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}