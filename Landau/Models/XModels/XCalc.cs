using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.XModels
{
    public class XCalc
    {
        public bool IsFormula { get; set; }

        public XCalc(bool isFormula)
        {
            try
            {
                IsFormula = isFormula;
            }
            catch (Exception exception)
            {
                
            }
        }

        /// <summary>
        /// Empty constructor, sets default parameters
        /// </summary>
        public XCalc()
        {
            try
            {
                IsFormula = false;
            }
            catch (Exception exception)
            {

            }
        }
    }
}