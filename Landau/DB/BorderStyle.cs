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
    
    public partial class BorderStyle
    {
        public int Id { get; set; }
        public int SheetId { get; set; }
        public int StartRowNum { get; set; }
        public int StartColNum { get; set; }
        public int EndRowNum { get; set; }
        public int EndColNum { get; set; }
        public int PositionId { get; set; }
        public int LineTypeId { get; set; }
        public Nullable<int> Width { get; set; }
        public string Color { get; set; }
    
        public virtual BorderPosition BorderPosition { get; set; }
        public virtual LineType LineType { get; set; }
    }
}
