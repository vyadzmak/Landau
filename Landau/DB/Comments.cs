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
    
    public partial class Comments
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int UserIdSend { get; set; }
        public int UserIdGet { get; set; }
        public string Data { get; set; }
        public System.DateTime Date { get; set; }
        public int State { get; set; }
    
        public virtual Documents Documents { get; set; }
    }
}