using System;
using System.Collections.Generic;
using System.Linq;
using Landau.DB;
using Landau.Helper;
using Landau.Models;
using Landau.Models.XModels;
using Landau.Models.Chart;
using Landau.Models.Modal.Table;
using Landau.Models.Modal.XLineChart;
using Landau.Models.Modal.StackedBarchart;
using Landau.Models.Modal.XNonStackedBarchart;
using ConsoleSandbox.Models.Modal.Table;
using Landau.Models.Modal.XMoveTable;


namespace Landau.Helper
{
    public class DatabaseToModelConverter
    {
        #region methods
        /// <summary>
        ///     init all sheets in current document
        /// </summary>
        /// <param name="document"></param>
        /// <param name="sheets"></param>
        /// <returns></returns>
        private static XDocument InitDocument(XDocument document)
        {
            try
            {
                int docId = document.Id;
                List<XFloating> floatings = new List<XFloating>();

                using (var db = new LandauEntities())
                {
                    //forming sheets
                    var sheets = (from sheet in db.Sheet
                                  where sheet.DocumentId == docId
                                  select sheet).ToList();

                    var analyticData = (from m in db.ModalView
                                        join c in db.Cell on m.Id equals c.ModalViewId
                                        select new
                                        {
                                            Id = c.ModalViewId

                                        }).ToList();


                    foreach (var sheet in sheets)
                    {
                        var groups = (from gr in db.TableGroups where gr.SheetId == sheet.Id select gr).ToList();

                        document.Sheets.Add(new XSheet(sheet.Id, sheet.Number, sheet.Name));

                        XFloating xFloating = new XFloating();
                        xFloating.SheetNumber = sheet.Number;
                        xFloating.Name = "colGroup";

                        foreach (var groupItem in groups)
                        {
                            xFloating.Groups.Add(new XGroup(groupItem.Id, groupItem.StartGroup, groupItem.EndGroup, "colGroups", "colgroup", 1));
                        }

                        if (groups.Count != 0)
                        {
                            document.Floatings.Add(xFloating);
                        }
                    }

                    for (var i = 0; i < document.Sheets.Count; i++)
                    {
                        var sheet = document.Sheets[i];
                        var body = (from s in db.Body where s.SheetId == sheet.Id select s).FirstOrDefault();
                        document.Sheets[i].Body = new XBody(body.Id, new List<XRow>());

                        //init rows
                        var rows = (from s in db.Row where s.BodyId == body.Id select s).ToList();
                        for (var j = 0; j < rows.Count; j++)
                        {
                            var xRow = new XRow(rows[j].Id, rows[j].Number);
                            document.Sheets[i].Body.Rows.Add(xRow);

                            //init cells
                            //var cells = (from c in db.Cell where c.RowId == xRow.Id join 
                            //             st in db.CellStyles on c.Id equals st.CellId into ps
                            //             from p in ps.DefaultIfEmpty()

                            var cells = (from c in db.Cell
                                         where c.RowId == xRow.Id
                                         join st in db.CellStyleTemplates on c.CellStyleId equals st.Id
                                         select new
                                         {
                                             Id = c.Id,
                                             ModalId = c.ModalViewId,
                                             StyleId = st.Id,
                                             Number = c.Number,
                                             Value = c.Value,
                                             Height = st.Height,
                                             Width = st.Width,
                                             DFM = st.DFM,
                                             Indent = st.Indent,
                                             Align = st.Align,
                                             DataFormat = st.CellDataFormat,
                                             CellType = st.CellDataFormat,
                                             FontColor = st.FontColor,
                                             FontSize = st.FontSize,
                                             BackgroundColor = st.BackgroundColor,
                                             FontWeight = st.FontWeight,
                                             FontStyle = st.FontStyle,
                                             IsFormula = c.Calculation,
                                             //CommentId = com.Id,
                                             FontFamily = st.FontFamily,
                                             Calc = c.Calculation,
                                             DecoreLine = st.DecorLine,
                                             Name = st.Name,
                                             CellDataFormat = st.CellDataFormat,
                                             Editable = c.Editable

                                         }).ToList();

                            foreach (var item in cells)
                            {
                                bool calc = false;
                                if (item.Calc == true)
                                {
                                    calc = (bool)item.Calc;
                                }
                                XFormat xFormat = new XFormat(item.DataFormat, item.DFM);
                                //  XComment xComment = new XComment(item.CommentId, item.Comment);
                                //XStyle xStyle = new XStyle(item.FontSize, item.FontWeight, item.Width, item.Height, item.FontStyle, 
                                //    item.FontFamily, item.BackgroundColor, item.FontColor, item.Indent);

                                XStyle xStyle = new XStyle(item.StyleId, item.FontSize, item.FontWeight, item.Width, item.Height, item.FontStyle, item.FontFamily,
                                    item.BackgroundColor, item.FontColor, (int)item.Indent, item.Align, item.DecoreLine, item.Name, item.CellDataFormat, item.CellType);

                                XCell xCell;

                                if (item.Value == null)
                                {
                                    xCell = new XCell(item.Id, item.Number, "", xStyle, null/*xComment*/, xFormat, item.Editable, calc);
                                }

                                xCell = new XCell(item.Id, item.Number, item.Value, xStyle, null/*xComment*/, xFormat, item.Editable, calc);




                                foreach (var analyticItem in analyticData)
                                {
                                    //if (analyticItem.Id == item.ModalId)
                                    //{
                                    xCell.IsButton = true;
                                    //}
                                }

                                document.Sheets[i].Body.Rows[j].Cells.Add(xCell);

                            }
                        }
                    }

                    return document;
                }
            }
            catch (Exception exception)
            {
                LogHelper.AddLog("Error. InitDocument. Error:" + exception.Message + " InnerException: " + exception.InnerException.Message);

                return document;
            }
        }

        /// <summary>
        /// Getting borders for whole current document by it's id
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        public static List<XBorder> InitBorders(int docId)
        {
            try
            {
                List<XBorder> currentSheetBorders = new List<XBorder>();

                using (LandauEntities db = new LandauEntities())
                {
                    var sheets = from sh in db.Sheet where sh.DocumentId == docId select sh;
                    var borders = (from bs in db.BorderStyle
                                   join sh in sheets on bs.SheetId equals sh.Id
                                   join bp in db.BorderPosition on bs.PositionId equals bp.Id
                                   join lt in db.LineType on bs.LineTypeId equals lt.Id
                                   select new
                                   {
                                       Id = bs.Id,
                                       StartRow = bs.StartRowNum,
                                       StartCol = bs.StartColNum,
                                       EndRow = bs.EndRowNum,
                                       EndCol = bs.EndColNum,
                                       Position = bp.Name,
                                       Width = bs.Width,
                                       LineType = lt.Name,
                                       Color = bs.Color,
                                       SheetId = bs.SheetId,
                                       SheetNumber = sh.Number
                                   }).ToList();

                    foreach (var sheetItem in sheets)
                    {
                        foreach (var borderItem in borders)
                        {
                            if (borderItem.SheetId == sheetItem.Id)
                            {
                                currentSheetBorders.Add(new XBorder(borderItem.Id, borderItem.StartRow, borderItem.EndRow,
                                    borderItem.StartCol, borderItem.Position, CellPropertiesValidator.BorderWidthValidator(borderItem.Width), borderItem.LineType, borderItem.EndCol,
                                    borderItem.Color, borderItem.SheetNumber));
                            }
                        }
                    }

                    return currentSheetBorders;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get document from database by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static XDocument GetDocumentFromDatabase(int id)
        {
            try
            {
                using (var db = new LandauEntities())
                {
                    var documentFromDb = (from doc in db.Documents
                                          where (doc.Id == id)
                                          select new
                                          {
                                              Id = doc.Id,
                                              FileName = doc.FileName
                                          }).ToList();

                    var documentLog = (from v in db.DocumentControlVersion where v.DocId == id select v).ToList();

                    if (documentLog.Count == 0)
                    {
                        DocumentControlVersion version = new DocumentControlVersion();
                        version.DocId = id;
                        version.ChangeDate = DateTime.Now;
                        int userId = (from s in db.Documents where s.Id == id select s.UserId).FirstOrDefault();
                        version.Version = 1;
                        version.UserId = userId;
                        version.State = true;
                        db.DocumentControlVersion.Add(version);
                        db.SaveChanges();
                        documentLog = (from v in db.DocumentControlVersion where v.DocId == id select v).ToList();
                    }
                    var query = (from doc in documentFromDb
                                 join v in documentLog on doc.Id equals v.DocId
                                 select
                                     new
                                     {
                                         Id = doc.Id,
                                         FileName = doc.FileName,
                                         Version = v.Version
                                     }).ToList().LastOrDefault();

                    //returning document formed in InitDocument method
                    return InitDocument(new XDocument(query.Id, query.FileName, query.Version)); ;
                }
            }
            catch (Exception exception)
            {
                LogHelper.AddLog("Error. GetDocumentFromDatabase. Error:" + exception.Message + " InnerException: " + exception.InnerException.Message);

                return null;
            }
        }

        /// <summary>
        /// Gets the Id of the last Document in database
        /// </summary>
        /// <returns></returns>
        public static int GetLastDocumentId()
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    List<Documents> documents = (from doc in db.Documents select doc).ToList();
                    int id = documents[documents.Count - 1].Id;
                    return id;
                }
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        #region charts initialization
        public static Object InitChart(int id, int type)
        {
            try
            {
                Models.Modal.Position position;
                using (var db = new LandauEntities())
                {
                    var modalCell = (from mc in db.ModalViewCell
                                     join ad in db.AnalyticData on mc.Id equals ad.ModalViewCellId
                                     where ad.Id == id
                                     select new
                                     {
                                         Number = mc.Number,
                                         RowId = mc.RowId
                                     }).ToList().LastOrDefault();






                    int rowId = modalCell.RowId;
                    List<ModalViewRow> modalRowQuery = (from mr in db.ModalViewRow
                                                        where mr.Id == rowId
                                                        select mr).ToList();

                    ModalViewRow modalRow = new ModalViewRow();

                    if (modalRowQuery.Count != 0)
                    {
                        modalRow = modalRowQuery[0];
                    }

                    position = new Models.Modal.Position(modalRow.Number, modalCell.Number);
                }
               
                if (type == 1)
                {
                    return (Object)InitPieChart(position, id);
                }

                if (type == 2)
                {
                    return (Object)InitLineChart(id, position);
                }

                if (type == 4)
                {
                    return (Object)InitModalTable(position, id);
                }

                if (type == 5)
                {
                    return (Object)InitStackedBarchart(position, id);
                }

                if (type == 1005)
                {
                    return (Object)InitNonStackedBarchart(position, id);
                }

                if (type == 1006)
                {
                    return (Object)InitMoveTable(position, id);
                }

                return null;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static List<LogLine> GetReportLogs(int documentId)
        {
            try
            {
                List<LogLine> logLines = new List<LogLine>();

                using (LandauEntities db = new LandauEntities())
                {
                    var logQuery = (from l in db.AnalyzeLog
                        join mt in db.AnalyzeMessageType on l.TypeId equals mt.Id
                        select new
                        {
                            DocumentId = l.ProjectId,
                            MessageString = l.Message,
                            FullDescription = l.FullDescription,
                            Date = l.Date,
                            Type = mt.Type
                        }).ToList();

                    logLines.AddRange(logQuery.Select(logItem => new LogLine(logItem.Type, logItem.MessageString, 
                        logItem.Date.ToLongDateString(), logItem.FullDescription)));
                }

                return logLines;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static XLineChart InitLineChart(int id, Models.Modal.Position position)
        {
            try 
            {
                using (var db = new LandauEntities())
                {
                    LineChart lineChartQuery = (from lc in db.LineChart where lc.AnalyticDataId == id select lc).ToList().LastOrDefault();
                    List<LineChartElement> lineChartElementQuery = (from lce in db.LineChartElement where lce.LineChartId == lineChartQuery.Id select lce).ToList();
                    List<LineChartPoint> lineChartPointQuery = (from lcp in db.LineChartPoint where 1 == 1 select lcp).ToList();



                    XLineChart xLineChart = new XLineChart(lineChartQuery.Id, lineChartQuery.Description, position, lineChartQuery.Type);

                    foreach (var elementItem in lineChartElementQuery)
                    {
                        List<LineChartPoint> pointsQuery = (from lcp in lineChartPointQuery where lcp.LineChartElementId == elementItem.Id select lcp).ToList();
                        XLineChartElement element = new XLineChartElement(elementItem.Id, elementItem.Description);
                        List<XPointLineChart> points = new List<XPointLineChart>();
                        foreach (var pointItem in pointsQuery)
                        {
                            points.Add(new XPointLineChart(pointItem.Id, pointItem.PositionX,
                                double.Parse(pointItem.PositionY), pointItem.Category));
                        }
                        element.Points = points;
                        xLineChart.Elements.Add(element);
                    }

                    return xLineChart;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static XPieChart InitPieChart(Models.Modal.Position position, int id)
        {
            try
            {
                List<XPieChart> pieChartsList = new List<XPieChart>();
                XPieChart pie = new XPieChart();

                using (var db = new LandauEntities())
                {
                    var analyticDatas = (from ad in db.AnalyticData select ad).ToList();
                    var pieCharts = (from pc in db.PieChart select pc).ToList();
                    var chartElements = (from ce in db.PieChartElement select ce).ToList();

                    foreach (var analyticDataItem in analyticDatas)
                    {
                        if (analyticDataItem.Id == id && analyticDataItem.TypeId == 1)
                        {
                            foreach (var pieChartItem in pieCharts)
                            {
                                if (analyticDataItem.Id == pieChartItem.AnalyticDataId)
                                {
                                    pie = new XPieChart(pieChartItem.Id, pieChartItem.Description, position);
                                    pieChartsList.Add(pie);
                                }
                            }
                        }
                    }

                    foreach (var pieChart in pieChartsList)
                    {
                        foreach (var pieElement in chartElements)
                        {
                            if (pieElement.PieChartId == pieChart.Id)
                            {
                                pieChart.Elements.Add(new XPieChartElement(double.Parse(pieElement.Value), pieElement.Description));
                            }
                        }
                    }

                    return pie;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static XStackedBarchart InitStackedBarchart(Models.Modal.Position position, int id)
        {
            try
            {
                XStackedBarchart barchart = new XStackedBarchart();

                using (var db = new LandauEntities())
                {
                    var analyticDatas = (from ad in db.AnalyticData select ad).ToList();
                    var stackedCharts = (from sb in db.StackedBarchart select sb).ToList();
                    var chartColumns = (from sc in db.StackedBarchartColumn select sc).ToList();
                    var chartElements = (from se in db.StackedBarchartElement select se).ToList();

                    foreach (var analyticDataItem in analyticDatas)
                    {
                        if (analyticDataItem.Id == id && analyticDataItem.TypeId == 5)
                        {
                            foreach (var stackedChartItem in stackedCharts)
                            {
                                if (stackedChartItem.AnalyticDataId == analyticDataItem.Id)
                                {
                                    barchart = new XStackedBarchart(stackedChartItem.Id, stackedChartItem.Description, stackedChartItem.Title, position);
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    foreach (StackedBarchartColumn columnItem in chartColumns)
                    {
                        if (columnItem.StackedBarChartId == barchart.Id)
                        {
                            XStackedBarchartColumn column = new XStackedBarchartColumn(columnItem.Id, columnItem.PositionX, columnItem.Description);
                            foreach (StackedBarchartElement elementItem in chartElements)
                            {
                                if (elementItem.BarchartColumnId == columnItem.Id)
                                {
                                    column.Elements.Add(new XStackedBarchartElement(elementItem.Id, elementItem.Description,
                                        double.Parse(elementItem.Value), elementItem.Category));
                                }
                            }
                            barchart.Columns.Add(column);
                        }
                    }

                    return barchart;
                }

                
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static XNonStackedBarchart InitNonStackedBarchart(Models.Modal.Position position, int id)
         {
             try
             {
                 XNonStackedBarchart barchart = new XNonStackedBarchart();
                 using (var db = new LandauEntities())
                 {
                     var analyticDatas = (from ad in db.AnalyticData select ad).ToList();
                     var stackedCharts = (from sb in db.NonStackedBarChart select sb).ToList();
                     var chartColumns = (from sc in db.NonStackedBarChartColumn select sc).ToList();
                     var chartElements = (from se in db.NonStackedBarChartElement select se).ToList();

                     foreach (var analyticDataItem in analyticDatas)
                     {
                         if (analyticDataItem.Id == id && analyticDataItem.TypeId == 1005)
                         {
                             foreach (var stackedChartItem in stackedCharts)
                             {
                                 if (stackedChartItem.AnalyticDataId == analyticDataItem.Id)
                                 {
                                     barchart = new XNonStackedBarchart(stackedChartItem.Id, stackedChartItem.Description, position);
                                     break;
                                 }
                             }
                             break;
                         }
                     }

                     foreach (NonStackedBarChartColumn columnItem in chartColumns)
                     {
                         if (columnItem.NonStackedBarchartId == barchart.Id)
                         {
                             XNonStackedBarchartColumn column = new XNonStackedBarchartColumn(columnItem.Id, columnItem.PositionX, columnItem.Description);
                             foreach (NonStackedBarChartElement elementItem in chartElements)
                             {
                                 if (elementItem.NonStackedBarchartColumnId == columnItem.Id)
                                 {
                                     column.Elements.Add(new XNonStackedBarchartElement(elementItem.Id, elementItem.Description,
                                         double.Parse(elementItem.Value), elementItem.Category));
                                 }
                             }
                             barchart.Columns.Add(column);
                         }
                     }

                     return barchart;
                 }
             }
             catch (Exception exception)
             {
                 return null;
             }
         }

        public static XModalTable InitModalTable(Models.Modal.Position position, int id)
        {
            try
            {
                TableModal table = new TableModal();
                BodyModal body = new BodyModal();
                List<XModalRow> xModalRows = new List<XModalRow>();
 
                using (var db = new LandauEntities())
                {
                    var tablesQuery = (from tm in db.TableModal where tm.AnalyticDataId == id select tm).ToList();

                    // Типа LastOrDefault
                    if (tablesQuery.Count > 0)
                    {
                        table = tablesQuery[0];
                    }
                    else
                    {
                        return null;
                    }

                    int tableId = table.Id;
                    var bodyQuery = (from b in db.BodyModal where b.TableModalId == tableId select b).ToList();

                    if (bodyQuery.Count > 0)
                    {
                        body = bodyQuery[0];
                    }
                    else
                    {
                        return null;
                    }

                    int bodyId = body.Id;

                    List<RowModal> rowsQuery = (from r in db.RowModal where r.ModalBodyId == bodyId select r).ToList();
                    List<CellModal> cellsQuery = (from c in db.CellModal where 1 == 1 select c).ToList();
                    List<CellModalStyle> cellStylesQuery = (from cs in db.CellModalStyle where 1 == 1 select cs).ToList();

                    foreach (RowModal rowItem in rowsQuery)
                    {
                        List<XModalCell> xModalCells = new List<XModalCell>();

                        foreach (CellModal cellModalItem in cellsQuery)
                        {
                            XModalCellStyle xModalCellStyle = new XModalCellStyle();
                            if (cellModalItem.RowModalId == rowItem.Id)
                            {
                                foreach (CellModalStyle cellModalStyleItem in cellStylesQuery)
                                {
                                    if (cellModalStyleItem.CellModalId == cellModalItem.Id)
                                    {
                                        xModalCellStyle = new XModalCellStyle((int)cellModalStyleItem.FontSize, cellModalStyleItem.FontStyle, 
                                            cellModalStyleItem.FontFamily, cellModalStyleItem.Align, cellModalStyleItem.LinkColor, 
                                            cellModalStyleItem.BackgroundColor, cellModalStyleItem.FontColor);
                                    }
                                }

                                XModalCell xModalCell;
                                if (cellModalItem.IsHyperLink)
                                {
                                    xModalCell = new XModalCell(cellModalItem.Id, cellModalItem.Value, 
                                        cellModalItem.Number, (int)cellModalItem.ModalViewId, xModalCellStyle);
                                }
                                else
                                {
                                    xModalCell = new XModalCell(cellModalItem.Id, cellModalItem.Value, cellModalItem.Number, xModalCellStyle);
                                }

                                xModalCells.Add(xModalCell);
                            }
                        }

                        XModalRow xModalRow = new XModalRow(rowItem.Id, (int)rowItem.Number, xModalCells);
                        xModalRows.Add(xModalRow);
                    }

                    XModalBody xModalBody = new XModalBody(body.Id, xModalRows);
                    XModalTable xModalTable = new XModalTable(tableId, position, table.Description, table.Name, xModalBody);

                    return xModalTable;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static XMoveTable InitMoveTable(Models.Modal.Position position, int id)
        {
            try
            {
                MoveTable table = new MoveTable();
                List<XMoveTableRow> xMoveRows = new List<XMoveTableRow>();

                using (var db = new LandauEntities())
                {
                    var tablesQuery = (from tm in db.MoveTable where tm.AnalyticDataId == id select tm).ToList();
                    var moveCategories = (from mc in db.MoveCategories select mc).ToList();

                    // Типа LastOrDefault
                    if (tablesQuery.Count > 0)
                    {
                        table = tablesQuery[0];
                    }
                    else
                    {
                        return null;
                    }

                    int tableId = table.Id;

                    var rowsQuery = (from r in db.MoveTableRow
                                     where r.MoveTableId == tableId
                                     join mc in db.MoveCategories on r.MoveCategoryId equals mc.Id
                                     select new
                                     {
                                         Id = r.Id,
                                         Number = r.Number,
                                         Category = mc.Name
                                     }).ToList();

                    List<MoveTableCell> cellsQuery = (from c in db.MoveTableCell where 1 == 1 select c).ToList();

                    foreach (var rowItem in rowsQuery)
                    {
                        List<XMoveTableCell> xMoveCells = new List<XMoveTableCell>();

                        foreach (MoveTableCell cellMoveItem in cellsQuery)
                        {
                            if (cellMoveItem.MoveTableRowId == rowItem.Id)
                            {
                                XMoveTableCell xMoveCell = new XMoveTableCell(Guid.NewGuid(), cellMoveItem.Number, cellMoveItem.Value, cellMoveItem.Category);
                                xMoveCells.Add(xMoveCell);
                            }
                        }

                        XMoveTableRow xMoveRow = new XMoveTableRow(rowItem.Number, rowItem.Category, xMoveCells);
                        xMoveRows.Add(xMoveRow);
                    }

                    XMoveTable xMoveTable = new XMoveTable(Guid.NewGuid(), xMoveRows);

                    return xMoveTable;
                }

                
            }
            catch (Exception exception)
            {
                return null;
            }
        }

#endregion
        #endregion
    }
}