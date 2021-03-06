﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LandauEntities : DbContext
    {
        public LandauEntities()
            : base("name=LandauEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnalyticData> AnalyticData { get; set; }
        public virtual DbSet<AnalyzeMessageType> AnalyzeMessageType { get; set; }
        public virtual DbSet<BarChart> BarChart { get; set; }
        public virtual DbSet<BarChartElement> BarChartElement { get; set; }
        public virtual DbSet<Body> Body { get; set; }
        public virtual DbSet<BodyModal> BodyModal { get; set; }
        public virtual DbSet<BorderPosition> BorderPosition { get; set; }
        public virtual DbSet<BorderStyle> BorderStyle { get; set; }
        public virtual DbSet<Cell> Cell { get; set; }
        public virtual DbSet<CellComments> CellComments { get; set; }
        public virtual DbSet<CellModal> CellModal { get; set; }
        public virtual DbSet<CellModalStyle> CellModalStyle { get; set; }
        public virtual DbSet<CellStyles> CellStyles { get; set; }
        public virtual DbSet<CellStyleTemplates> CellStyleTemplates { get; set; }
        public virtual DbSet<ChartTypeCatalog> ChartTypeCatalog { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentControlVersion> DocumentControlVersion { get; set; }
        public virtual DbSet<DocumentInfo> DocumentInfo { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<DocumentState> DocumentState { get; set; }
        public virtual DbSet<DocumentTypes> DocumentTypes { get; set; }
        public virtual DbSet<HtmlForms> HtmlForms { get; set; }
        public virtual DbSet<LineChart> LineChart { get; set; }
        public virtual DbSet<LineChartElement> LineChartElement { get; set; }
        public virtual DbSet<LineChartPoint> LineChartPoint { get; set; }
        public virtual DbSet<LineType> LineType { get; set; }
        public virtual DbSet<LogTable> LogTable { get; set; }
        public virtual DbSet<ModalView> ModalView { get; set; }
        public virtual DbSet<ModalViewCell> ModalViewCell { get; set; }
        public virtual DbSet<ModalViewRow> ModalViewRow { get; set; }
        public virtual DbSet<MoveCategories> MoveCategories { get; set; }
        public virtual DbSet<MoveTable> MoveTable { get; set; }
        public virtual DbSet<MoveTableCell> MoveTableCell { get; set; }
        public virtual DbSet<MoveTableRow> MoveTableRow { get; set; }
        public virtual DbSet<NonStackedBarChart> NonStackedBarChart { get; set; }
        public virtual DbSet<NonStackedBarChartColumn> NonStackedBarChartColumn { get; set; }
        public virtual DbSet<NonStackedBarChartElement> NonStackedBarChartElement { get; set; }
        public virtual DbSet<Operations> Operations { get; set; }
        public virtual DbSet<OperationState> OperationState { get; set; }
        public virtual DbSet<OperationType> OperationType { get; set; }
        public virtual DbSet<PieChart> PieChart { get; set; }
        public virtual DbSet<PieChartElement> PieChartElement { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProjectStates> ProjectStates { get; set; }
        public virtual DbSet<RelationCells> RelationCells { get; set; }
        public virtual DbSet<ReportCellTypeCatalog> ReportCellTypeCatalog { get; set; }
        public virtual DbSet<ReportDocumentTypeCatalog> ReportDocumentTypeCatalog { get; set; }
        public virtual DbSet<Row> Row { get; set; }
        public virtual DbSet<RowModal> RowModal { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Sheet> Sheet { get; set; }
        public virtual DbSet<SourceDocumentCell> SourceDocumentCell { get; set; }
        public virtual DbSet<SourceDocumentRow> SourceDocumentRow { get; set; }
        public virtual DbSet<SourceDocuments> SourceDocuments { get; set; }
        public virtual DbSet<SourceDocumentSheet> SourceDocumentSheet { get; set; }
        public virtual DbSet<SourceDocumentStates> SourceDocumentStates { get; set; }
        public virtual DbSet<StackedBarchart> StackedBarchart { get; set; }
        public virtual DbSet<StackedBarchartColumn> StackedBarchartColumn { get; set; }
        public virtual DbSet<StackedBarchartElement> StackedBarchartElement { get; set; }
        public virtual DbSet<TableGroups> TableGroups { get; set; }
        public virtual DbSet<TableModal> TableModal { get; set; }
        public virtual DbSet<TypeAnalyticData> TypeAnalyticData { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ViewTypes> ViewTypes { get; set; }
        public virtual DbSet<AnalyzeLog> AnalyzeLog { get; set; }
    }
}
