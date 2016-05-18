using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.DocumentModel
{
    public class DocumentsModel
    {
            public List<DocumentModelVm> Documents = null;

            public DocumentsModel()
            {
                Documents = new List<DocumentModelVm>();
            }
        
    }
}