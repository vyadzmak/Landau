using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.XModels
{
    public class XFloating
    {
        public int SheetNumber { get; set; }

        public string Name { get; set; }

        public List<XGroup> Groups { get; set; }

        public XFloating()
        {
            try
            {
                Groups = new List<XGroup>();
            }
            catch (Exception exception)
            {

            }
        }
    }
}