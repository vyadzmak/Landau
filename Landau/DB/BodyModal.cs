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
    
    public partial class BodyModal
    {
        public BodyModal()
        {
            this.RowModal = new HashSet<RowModal>();
        }
    
        public int Id { get; set; }
        public int TableModalId { get; set; }
        public string Description { get; set; }
    
        public virtual TableModal TableModal { get; set; }
        public virtual ICollection<RowModal> RowModal { get; set; }
    }
}