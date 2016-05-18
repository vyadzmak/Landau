using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.Chart;
using Landau.Models.Modal.Table;
using Landau.Models.Modal.XLineChart.Json;
using Landau.Models.Modal.XLineChart;
using Landau.Models.Modal.StackedBarchart;
using Landau.Models.Modal.XStackedBarchart.Json;
using Landau.Models.Modal.XNonStackedBarchart.Json;
using Landau.Models.Modal.XNonStackedBarchart;
using ConsoleSandbox.Models.Modal.Table;
using ConsoleSandbox.Models.Modal.Table.Json;
using Landau.Models.Modal.XMoveTable;

namespace Landau.Helper.Converters
{
    public class ChartToJsonModelConverter
    {
        public Object Convert(Object obj, string type)
        {
            try
            {
                if (type == "Landau.Models.Chart.XPieChart")
                {
                    XPieChart pie = obj as XPieChart;
                    return (Object)ConvertPie(pie); 
                }

                if (type == "Landau.Models.Modal.XLineChart.XLineChart")
                {
                    XLineChart line = obj as XLineChart;
                    return (Object)ConvertLine(line);
                }

                if (type == "Landau.Models.Modal.Table.XModalTable")
                {
                    XModalTable mTable = obj as XModalTable;
                    return (Object)ConvertTable(mTable);
                }

                if (type == "Landau.Models.Modal.StackedBarchart.XStackedBarchart")
                {
                    XStackedBarchart barchart = obj as XStackedBarchart;
                    return (Object)ConvertStackedBarchart(barchart);
                }

                if (type == "Landau.Models.Modal.XNonStackedBarchart.XNonStackedBarchart")
                {
                    XNonStackedBarchart barchart = obj as XNonStackedBarchart;
                    return (Object)ConvertNonStackedBarchart(barchart);
                }

                if (type == "Landau.Models.Modal.XMoveTable.XMoveTable")
                {
                    XMoveTable moveTable = obj as XMoveTable;
                    return (Object)ConvertMoveTable(moveTable);
                }
                

                return null;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public PieChartJsonModel ConvertPie(XPieChart pieChart)
        {
            try
            {
                List<List<Object>> elements = new List<List<Object>>();

                elements.Add(new List<Object>(2) { (Object)"A", (Object)"B" });

                foreach (var elementItem in pieChart.Elements)
                {
                    elements.Add(new List<Object>() { (Object) elementItem.Description, (Object) elementItem.Value });
                }

                
                return new PieChartJsonModel(pieChart.Id, elements, pieChart.Description, pieChart.Position);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public ModalTableJson ConvertTable(XModalTable mTable)
        {
            try 
	        {	 
                List<ModalRowJson> rows = new List<ModalRowJson>();
                foreach (var rowItem in mTable.Body.Rows)
                {
                    List<ModalCellJson> cells = new List<ModalCellJson>();
                    foreach (var cellItem in rowItem.Cells)
                    {
                        ModalCellStyleJson modalCellStyleJson = new ModalCellStyleJson(cellItem.Style.FontSize, cellItem.Style.FontStyle, 
                            cellItem.Style.FontFamily, cellItem.Style.Align, cellItem.Style.LinkColor, 
                            cellItem.Style.BackgroundColor, cellItem.Style.FontColor);
                        if (cellItem.IsHyperLink)
                        {
                            cells.Add(new ModalCellJson(cellItem.Id, cellItem.Number, cellItem.Value, cellItem.ModalViewId, modalCellStyleJson));
                        }
                        else
                        {
                            cells.Add(new ModalCellJson(cellItem.Id, cellItem.Number, cellItem.Value, modalCellStyleJson));
                        }
                    }
                    rows.Add(new ModalRowJson(rowItem.Id, rowItem.Number, cells));
                }
                 
                return new ModalTableJson(mTable.Id, rows, mTable.Description, mTable.Position);
	        }
	        catch (Exception exception)
	        {
                return null;
	        }
        }

        public JsonLinechart ConvertLine(XLineChart xLine)
        {
            try
            {
                List<List<Object>> chartsData = new List<List<object>>(); // Массив данных для диаграммы

                List<Object> categories = new List<Object>();   // Сформируем первую строку массива данных для линейной диаграммы
                                                                
                categories.Add((Object)"X");                    // Элемент "заглушка". Нам необязательно, чтобы он обладал сементикой

                foreach (var pointItem in xLine.Elements[0].Points) 
                {
                    categories.Add((string)pointItem.Category);   
                }

                chartsData.Add(categories);

                foreach (var columnItem in xLine.Elements)
                {
                    List<Object> dataLine = new List<Object>();
                    dataLine.Add(columnItem.Points[0].PositionX);
                    
                    foreach (var pointItem in columnItem.Points)
                    {
                        dataLine.Add(pointItem.PositionY);
                    }

                    chartsData.Add(dataLine);
                }
                //List<List<Object>> elements = new List<List<Object>>();
                //List<Object> categories = new List<Object>();
                //List<Object> xLabels = new List<Object>();
                //List<List<Object>> pointsStacks = new List<List<Object>>();
                //List<XPointLineChart> allPoints = new List<XPointLineChart>();

                //categories.Add((Object)"X");
                //foreach (var elementItem in xLine.Elements)
                //{
                //    categories.Add((Object)elementItem.Description);
                //    foreach (var pointItem in elementItem.Points)
                //    {
                //        allPoints.Add(pointItem);
                //    }
                //}

                //elements.Add(categories);

                //foreach (var pointItem in xLine.Elements[0].Points)
                //{
                //    List<Object> pointsStack = new List<Object>();
                //    pointsStack.Add(pointItem.PositionX);
                //    pointsStacks.Add(pointsStack);
                //}

                //foreach (var stackItem in pointsStacks)
                //{
                //    foreach (var pointItem in allPoints)
                //    {
                //        if (stackItem[0].ToString() == pointItem.PositionX.ToString())
                //        {
                //            stackItem.Add(pointItem.PositionY);
                //        }
                //    }
                    
                //}

                //foreach (var item in pointsStacks)
                //{
                //    elements.Add(item);
                //}

                JsonLinechart line = new JsonLinechart(xLine.Id, xLine.Description, chartsData, xLine.Position, xLine.Type);

                return line;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public JsonStackedBarchart ConvertStackedBarchart(XStackedBarchart chart)
        {
            try
            {
                List<Object> categories = new List<Object>();
                List<List<Object>> columns = new List<List<Object>>();

                categories.Add((Object)"A");
                foreach (var elementItem in chart.Columns[0].Elements)
                {
                    categories.Add((Object)elementItem.Category);
                }
                categories.Add((Object)new JsonStackedBarchartRole());

                columns.Add(categories);

                foreach (var columnItem in chart.Columns)
                {
                    List<Object> column = new List<Object>();
                    column.Add((Object)columnItem.PositionX);
                    foreach (var elementItem in columnItem.Elements)
                    {
                        column.Add((Object)elementItem.Value);
                    }
                    column.Add((Object)"");
                    columns.Add(column);
                }

                JsonStackedBarchart jsonObj = new JsonStackedBarchart(chart.Id, columns, chart.Description, chart.Position, chart.Title);

                return jsonObj;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public JsonNonStackedBarchart ConvertNonStackedBarchart(XNonStackedBarchart chart)
        {
            try
            {
                List<Object> categories = new List<Object>();
                List<List<Object>> columns = new List<List<Object>>();

                categories.Add((Object)"A");
                foreach (var elementItem in chart.Columns[0].Elements)
                {
                    categories.Add((Object)elementItem.Category);
                }
                categories.Add((Object)new JsonNonStackedBarchartRole());

                columns.Add(categories);

                foreach (var columnItem in chart.Columns)
                {
                    List<Object> column = new List<Object>();
                    column.Add((Object)columnItem.PositionX);
                    foreach (var elementItem in columnItem.Elements)
                    {
                        column.Add((Object)elementItem.Value);
                    }
                    column.Add((Object)"");
                    columns.Add(column);
                }

                JsonNonStackedBarchart jsonObj = new JsonNonStackedBarchart(chart.Id, columns, chart.Description, chart.Position);

                return jsonObj;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public List<List<List<string>>> ConvertMoveTable(XMoveTable moveTable)
        {
            try
            {
                List<List<List<string>>> rows = new List<List<List<string>>>();
                foreach (var rowItem in moveTable.Rows)
                {
                    List<List<string>> row = new List<List<string>>();
                    foreach (var cellItem in rowItem.Cells)
                    {
                        List<string> el = new List<string>();
                        el.Add(cellItem.Type);
                        el.Add(cellItem.Value);
                        el.Add(rowItem.Category);
                        row.Add(el);
                        
                    }
                    rows.Add(row);
                }

                return rows;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        
    }
}