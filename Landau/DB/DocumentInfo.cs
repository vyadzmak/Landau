//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Landau.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocumentInfo
    {
        public DocumentInfo()
        {
            this.Documents = new HashSet<Documents>();
        }
    
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentVersion { get; set; }
        public string AccountNumber { get; set; }
    
        public virtual ICollection<Documents> Documents { get; set; }
    }
}