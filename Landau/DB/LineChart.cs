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
    
    public partial class LineChart
    {
        public LineChart()
        {
            this.LineChartElement = new HashSet<LineChartElement>();
        }
    
        public int Id { get; set; }
        public int AnalyticDataId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
    
        public virtual AnalyticData AnalyticData { get; set; }
        public virtual ICollection<LineChartElement> LineChartElement { get; set; }
    }
}
