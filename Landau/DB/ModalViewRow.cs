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
    
    public partial class ModalViewRow
    {
        public ModalViewRow()
        {
            this.ModalViewCell = new HashSet<ModalViewCell>();
        }
    
        public int Id { get; set; }
        public int ModalViewId { get; set; }
        public int Number { get; set; }
    
        public virtual ModalView ModalView { get; set; }
        public virtual ICollection<ModalViewCell> ModalViewCell { get; set; }
    }
}