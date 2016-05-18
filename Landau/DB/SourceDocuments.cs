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
    
    public partial class SourceDocuments
    {
        public SourceDocuments()
        {
            this.SourceDocumentSheet = new HashSet<SourceDocumentSheet>();
        }
    
        public int Id { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public string FilePath { get; set; }
        public System.Guid Guid { get; set; }
        public string Extension { get; set; }
        public System.DateTime UploadDate { get; set; }
        public string DocumentType { get; set; }
        public Nullable<int> Version { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Hash { get; set; }
    
        public virtual Projects Projects { get; set; }
        public virtual SourceDocumentStates SourceDocumentStates { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<SourceDocumentSheet> SourceDocumentSheet { get; set; }
    }
}