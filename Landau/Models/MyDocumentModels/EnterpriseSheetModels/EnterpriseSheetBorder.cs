using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.MyDocumentModels.EnterpriseSheetModels
{
    public class EnterpriseSheetBorder
    {
        public string position { get; set; }

        public string color { get; set; }

        public int width { get; set; }

        public string lineType { get; set; }

        public EnterpriseSheetBorderRange range {get; set;}

        /// <summary>
        /// Empty constructor
        /// </summary>
        public EnterpriseSheetBorder()
        {
            try 
	        {	        
		         range = new EnterpriseSheetBorderRange();
	        }
	        catch (Exception exception)
	        {

	        }
        }

        public EnterpriseSheetBorder(string position, string color, int width, string lineType, EnterpriseSheetBorderRange range)
        {
            try 
            {	        
		        this.position = position;
                this.color = color;
                this.width = width;
                this.lineType = lineType;
                this.range = range;
	        }
	        catch (Exception exception)
	        {
            
            }
        }


    }
}