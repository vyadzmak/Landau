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
    
    public partial class SourceDocumentRow
    {
        public SourceDocumentRow()
        {
            this.SourceDocumentCell = new HashSet<SourceDocumentCell>();
        }
    
        public int Id { get; set; }
        public int SourceDocumentSheetId { get; set; }
        public int Number { get; set; }
        public Nullable<int> ClassifierType { get; set; }
        public string Value { get; set; }
    
        public virtual ICollection<SourceDocumentCell> SourceDocumentCell { get; set; }
        public virtual SourceDocumentSheet SourceDocumentSheet { get; set; }
    }
}
