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
    
    public partial class TableModal
    {
        public TableModal()
        {
            this.BodyModal = new HashSet<BodyModal>();
        }
    
        public int Id { get; set; }
        public int AnalyticDataId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    
        public virtual AnalyticData AnalyticData { get; set; }
        public virtual ICollection<BodyModal> BodyModal { get; set; }
    }
}