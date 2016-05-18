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
    
    public partial class Documents
    {
        public Documents()
        {
            this.Comments = new HashSet<Comments>();
            this.DocumentControlVersion = new HashSet<DocumentControlVersion>();
            this.AnalyzeLog = new HashSet<AnalyzeLog>();
            this.Sheet = new HashSet<Sheet>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public System.Guid GUID { get; set; }
        public string FileName { get; set; }
        public int DocumentType { get; set; }
        public int State { get; set; }
        public string ServerPath { get; set; }
        public string Description { get; set; }
        public string FileSize { get; set; }
        public System.DateTime UploadDate { get; set; }
        public string CRC { get; set; }
        public int UserId { get; set; }
        public int ViewType { get; set; }
        public Nullable<int> DocumentInfoId { get; set; }
        public bool IsReaded { get; set; }
    
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<DocumentControlVersion> DocumentControlVersion { get; set; }
        public virtual DocumentInfo DocumentInfo { get; set; }
        public virtual ICollection<AnalyzeLog> AnalyzeLog { get; set; }
        public virtual DocumentState DocumentState { get; set; }
        public virtual DocumentTypes DocumentTypes { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual ViewTypes ViewTypes { get; set; }
        public virtual ICollection<Sheet> Sheet { get; set; }
    }
}
