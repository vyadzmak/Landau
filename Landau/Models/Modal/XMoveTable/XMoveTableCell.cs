using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.XMoveTable
{
    public class XMoveTableCell
    {
        public Guid ReferenceGuid { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public XMoveTableCell(Guid refGuid, int number, string value, string type)
        {
            try 
	        {	        
		        ReferenceGuid = refGuid;
                Number = number;
                Type = type;
                Value = value;
	        }
	        catch (Exception)
	        {

	        }
        }

        public XMoveTableCell()
        {
            try 
	        {	        
		        
	        }
	        catch (Exception)
	        {

	        }
        }

    }
}