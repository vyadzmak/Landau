using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.XModels
{
    public class XFormat
    {
        public string Format { get; set; }
        public string Template { get; set; }

        public XFormat(string format, string dfm)
        {
            try
            {
                Format = format;
                Template = dfm;
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty constructor, sets default parameters
        /// </summary>
        public XFormat()
        {
            try
            {
                Format = "";
                Template = "";
            }
            catch (Exception exception)
            {

            }
        }
    }
}