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
    
    public partial class LineChartPoint
    {
        public int Id { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public int LineChartElementId { get; set; }
        public string Category { get; set; }
        public Nullable<double> RealValue { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> AnalyticDataType { get; set; }
        public Nullable<int> DocumentType { get; set; }
        public Nullable<int> ChartType { get; set; }
        public Nullable<int> ProjectId { get; set; }
    
        public virtual ChartTypeCatalog ChartTypeCatalog { get; set; }
        public virtual LineChartElement LineChartElement { get; set; }
        public virtual ReportCellTypeCatalog ReportCellTypeCatalog { get; set; }
        public virtual ReportDocumentTypeCatalog ReportDocumentTypeCatalog { get; set; }
    }
}
