using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Landau.DB;
using Landau.Helper;
using Landau.Models;
using Landau.Models.MyDocumentModels.EnterpriseSheetModels;
using Landau.Models.XModels;
using Landau.Models.Chart;
using System.Drawing;
using Landau.Helper.Converters;
using Landau.Models.Modal;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using Landau.Models.OperationModels;

namespace Landau.Controllers
{
    public class CabinetController : Controller
    {
        //
        // GET: /Cabinet/

        public static XDocument Document { get; set; }


        public static int Id { get; set; }

        [HttpGet]
        public ActionResult Cabinet(int? id)
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    ViewBag.StartSession = Session["UserId"];
                    ViewBag.StartLogin = Session["Name"];
                    //if (id == null)
                    //{
                    //    Id = DatabaseToModelConverter.GetLastDocumentId();
                    //}
                    //else
                    //{
                    //    Id = id.Value;
                    //}

                    // Метод, достающий документ из базы. Не трогать!!!
                    //Document = DatabaseToModelConverter.GetDocumentFromDatabase(Id);

                    //ExplicitDocumentCreation creator = new ExplicitDocumentCreation();
                    //JavaScriptSerializer serializer = new JavaScriptSerializer();

                    //// Метод, задающий документ явно
                    //// Document = creator.ExcplicitDocumentGet();

                    //ConverterToEnterpriseSheetModel converter = new ConverterToEnterpriseSheetModel();
                    //EnterpriseSheetDocument esDocument = converter.ConvertDocument(Document);

                    //#region correcting the final string

                    //JsonModel jsonModel = new JsonModel();
                    //jsonModel.Value = serializer.Serialize(esDocument);
                    //jsonModel.Value = Extensions.RemoveJsonNulls(jsonModel.Value);
                    //jsonModel.Value = jsonModel.Value.Replace(",}", "}");

                    //#endregion

                    ////  return RedirectToAction("IndexMy");

                    return View(/*jsonModel*/);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception exception)
            {
                LogHelper.AddLog("Error. Login. Error:" + exception.Message + ". Inner Exception: " + exception.InnerException.Message);
                return null;
            }
        }

        [HttpPost]
        //public string Cabinet(string docId, string sheetNumberVar, string sheetName, string rowVar, 
        //    string colVar, string afterChangesVar, string originVar, string current, string documentVersion)
        public string Cabinet(string docId, string version, string changes)
        {
            try
            {
                JavaScriptSerializer sz = new JavaScriptSerializer();
                List<object> changedCells = sz.Deserialize<List<object>>(changes);

                if (changes == "[]")
                {
                    return CheckChanges(docId, version);
                }
                else
                {
                    for (int i = 0; i < changedCells.Count; i++) // Цикл по всем пришедшим к нам измененным ячейкам
                    {
                        // Преобразуем объект ячейки в коллекцию для доступа через индекс
                        Dictionary<string, object> changedCell = changedCells[i] as Dictionary<string, object>;

                        // Извлечём данные о позиционировании ячейки
                        int rowIndex = (int)changedCell["row"];
                        int colIndex = (int)changedCell["col"];
                        int sheetIndex = (int)changedCell["sheetId"];
                        string sheetName = (string)changedCell["sheetName"];

                        // Преобразуем объект свойств стилистики ячейки в коллекцию
                        Dictionary<string, object> cellStyleChanges = changedCell["current"] as Dictionary<string, object>;

                        EnterpriseSheetJson deserializedCell = new EnterpriseSheetJson();

                        if (cellStyleChanges.ContainsKey("data")) { deserializedCell.data = (string)cellStyleChanges["data"]; } else deserializedCell.data = null;
                        if (cellStyleChanges.ContainsKey("fw")) { deserializedCell.fw = (string)cellStyleChanges["fw"]; } else deserializedCell.fw = null;
                        if (cellStyleChanges.ContainsKey("u")) { deserializedCell.u = (string)cellStyleChanges["u"]; } else deserializedCell.u = null;
                        if (cellStyleChanges.ContainsKey("fs")) { deserializedCell.fs = (string)cellStyleChanges["fs"]; } else deserializedCell.fs = null;
                        if (cellStyleChanges.ContainsKey("fz")) { deserializedCell.fz = (int)cellStyleChanges["fz"]; } else deserializedCell.fz = CellPropertiesValidator.FontSizeDefault;
                        if (cellStyleChanges.ContainsKey("ff")) { deserializedCell.ff = (string)cellStyleChanges["ff"]; } else deserializedCell.ff = null;
                        if (cellStyleChanges.ContainsKey("cal")) { deserializedCell.cal = (bool)cellStyleChanges["cal"]; } else deserializedCell.cal = false;
                        if (cellStyleChanges.ContainsKey("o")) { deserializedCell.o = (string)cellStyleChanges["o"]; } else deserializedCell.o = null;
                        if (cellStyleChanges.ContainsKey("s")) { deserializedCell.s = (string)cellStyleChanges["s"]; } else deserializedCell.s = null;
                        if (cellStyleChanges.ContainsKey("bgc")) { deserializedCell.bgc = (string)cellStyleChanges["bgc"]; } else deserializedCell.bgc = null;
                        if (cellStyleChanges.ContainsKey("color")) { deserializedCell.color = (string)cellStyleChanges["color"]; } else deserializedCell.color = null;
                        if (cellStyleChanges.ContainsKey("height")) { deserializedCell.height = (int)cellStyleChanges["height"]; } else deserializedCell.height = CellPropertiesValidator.CellHeightValidate(null);
                        if (cellStyleChanges.ContainsKey("width")) { deserializedCell.width = (int)cellStyleChanges["width"]; } else deserializedCell.width = CellPropertiesValidator.CellWidthValidate(null);
                        if (cellStyleChanges.ContainsKey("comment")) { deserializedCell.comment = (string)cellStyleChanges["comment"]; } else deserializedCell.comment = null;
                        if (cellStyleChanges.ContainsKey("fm")) { deserializedCell.fm = (string)cellStyleChanges["fm"]; } else deserializedCell.fm = null;
                        if (cellStyleChanges.ContainsKey("dfm")) { deserializedCell.dfm = (string)cellStyleChanges["dfm"]; } else deserializedCell.dfm = null;
                        if (cellStyleChanges.ContainsKey("ti")) { deserializedCell.ti = (string)cellStyleChanges["ti"]; } else deserializedCell.ti = null;
                        if (cellStyleChanges.ContainsKey("ta")) { deserializedCell.ta = (string)cellStyleChanges["ta"]; } else deserializedCell.ta = null;
                        if (cellStyleChanges.ContainsKey("dsd")) { deserializedCell.dsd = (string)cellStyleChanges["dsd"]; } else deserializedCell.dsd = null;

                        XSheet sheet = new XSheet();
                        XBody body = new XBody();
                        XCell cell = new XCell();
                        XRow row = new XRow();

                        List<XRow> rowsNew = new List<XRow>();
                        List<XCell> cellsNew = new List<XCell>();

                        XStyle xStyle;

                        int indent = 0;

                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"\d+");
                        if (deserializedCell.ti != null)
                        {
                            var match = reg.Match(deserializedCell.ti);
                            indent = Int32.Parse(match.Value.ToString());
                        }

                        if (deserializedCell.GetType().GetProperty("bgc") == null)
                        {
                            xStyle = new XStyle(sheet.Name);
                        }
                        else
                        {
                            xStyle = new XStyle(0, deserializedCell.fz, deserializedCell.fw, deserializedCell.width,
                                                deserializedCell.height, deserializedCell.fs, deserializedCell.ff, deserializedCell.bgc,
                                                deserializedCell.color, indent, deserializedCell.ta,
                                                CellPropertiesValidator.DecoreLineValidate(deserializedCell.o, deserializedCell.u, deserializedCell.s),
                                                sheetName, deserializedCell.dfm, "");
                        }

                        sheet = DocumentNavigationHelper.GetSheetByNumber(Document, sheetIndex);
                        NewIdAndNumberGetter getter = new NewIdAndNumberGetter();

                        if (sheet == null)
                        {
                            XComment xComment = new XComment(0, deserializedCell.comment);
                            XFormat xFormat = new XFormat(deserializedCell.fm, deserializedCell.dfm);

                            cell = new XCell(0, colIndex, deserializedCell.data, xStyle, xComment, xFormat, deserializedCell.dsd, deserializedCell.cal);
                            cellsNew.Add(cell);

                            row = new XRow(0, rowIndex, cellsNew);
                            rowsNew.Add(row);

                            body = new XBody(0, rowsNew);

                            sheet = new XSheet(0, sheetIndex, sheetName, body);

                            Document.Sheets.Add(sheet);
                        }
                        else
                        {
                            body = sheet.Body;
                            row = DocumentNavigationHelper.GetRowbyNumber(body, rowIndex);

                            if (row == null)
                            {
                                XComment xComment = new XComment(0, deserializedCell.comment);
                                XFormat xFormat = new XFormat(deserializedCell.fm, deserializedCell.dfm);

                                cell = new XCell(0, colIndex, deserializedCell.data, xStyle, xComment, xFormat, deserializedCell.dsd, deserializedCell.cal);
                                cellsNew.Add(cell);

                                row = new XRow(0, rowIndex, cellsNew);
                                sheet.Body.Rows.Add(row);
                            }
                            else
                            {
                                cell = DocumentNavigationHelper.GetCellByNumber(row, colIndex);

                                if (cell == null)
                                {
                                    XComment xComment = null;

                                    if (deserializedCell.comment != null)
                                    {
                                        xComment = new XComment(0, deserializedCell.comment);
                                    }

                                    XFormat xFormat = new XFormat(deserializedCell.fm, deserializedCell.dfm);

                                    cell = new XCell(0, colIndex, deserializedCell.data, xStyle, xComment, xFormat, deserializedCell.dsd, deserializedCell.cal);

                                    row.Cells.Add(cell);
                                }
                                else
                                {
                                    if (cell.Comment != null)
                                    {
                                        cell.Comment = new XComment(cell.Comment.Id, deserializedCell.comment);
                                        cell.Comment.Message = deserializedCell.comment;
                                    }

                                    cell.IsFormula = deserializedCell.cal;
                                    cell.Format.Format = deserializedCell.fm;
                                    cell.Format.Template = deserializedCell.dfm;
                                    cell.Value = deserializedCell.data;
                                    cell.Style = xStyle;
                                    cell.Editable = deserializedCell.dsd;
                                }
                            }
                            Document.Sheets[sheetIndex - 1] = sheet;
                        }

                        Document = ModelToDatabaseConverter.UpdateDocumentInDatabase(Document, sheetIndex,
                            rowIndex, colIndex, (int)Session["UserId"]);
                    }

                    Document.Version = Document.Version + 1;
                    ModelToDatabaseConverter.UpdateDocumentVersion(Document, (int)Session["UserId"]);

                    return Document.Version.ToString();
                }
            }

            catch (Exception exception)
            {
                return "fail";
            }
        }

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]
        public string GetListOfDocuments()
        {
            try
            {
                JavaScriptSerializer docListSerializer = new JavaScriptSerializer();
                List<Documents> query = new List<Documents>();

                using (LandauEntities db = new LandauEntities())
                {
                    query = (from doc in db.Documents where doc.ViewType == 3 select doc).ToList();
                }

                return docListSerializer.Serialize(query);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        [HttpPost]
        public string GetListOfDocuments(string id)
        {
            try
            {
                int projectId = Int32.Parse(id);
                JavaScriptSerializer docListSerializer = new JavaScriptSerializer();
                List<Documents> query = new List<Documents>();
                using (LandauEntities db = new LandauEntities())
                {
                    int userId = (int)Session["UserId"];

                    query = (from doc in db.Documents
                             where doc.ProjectId == projectId &&
                                 doc.ViewType == 3 && doc.State == 5 &&
                                 doc.UserId == userId
                             select doc).ToList();
                }


                return docListSerializer.Serialize(query);
            }
            catch (Exception exception)
            {
                LogHelper.AddLog("Error. GetListOfDocuments. Error:" + exception.Message + " InnerException: " + exception.InnerException.Message);
                return null;
            }
        }

        [HttpGet]
        public string GetOrdersList()
        {
            try
            {
                int userid = (int)Session["UserId"];
                JavaScriptSerializer ordersListSerializer = new JavaScriptSerializer();

                using (LandauEntities db = new LandauEntities())
                {
                    Users clientid = (from s in db.Users where s.Id == userid select s).FirstOrDefault();


                    var query = (from od in db.Projects
                                 where od.ClientId == clientid.ClientId
                                 join st in db.ProjectStates on od.State equals st.Id
                                 join cl in db.Clients on od.ClientId equals cl.Id
                                 select new
                                 {
                                     Id = od.Id,
                                     Name = cl.Name,
                                     State = st.Description,
                                     ProjectName = od.ProjectName
                                 }).ToList();

                    return ordersListSerializer.Serialize(query);
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public string CheckChanges(string docId, string version)
        {
            try
            {
                int docIdNum = Int32.Parse(docId);
                int ver = Int32.Parse(version);
                List<DocumentControlVersion> query;

                using (LandauEntities db = new LandauEntities())
                {
                    query = (from d in db.DocumentControlVersion
                             where d.DocId == docIdNum
                             select d).ToList();
                }

                if (query.LastOrDefault().Version != ver)
                {
                    return GetDocument(docId);
                }

                else return "uptodate";
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        [HttpPost]
        public string GetDocument(string id)
        {
            try
            {
                if (id == "") { return null; }
                Autofitter autofiter = new Autofitter();

                // Метод, достающий документ из базы. Не трогать!!!
                Document = DatabaseToModelConverter.GetDocumentFromDatabase(Int32.Parse(id));

                Document = autofiter.GetAutofitedDocument(Document);



                ExplicitDocumentCreation creator = new ExplicitDocumentCreation();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                FinalJsonHandler handler = new FinalJsonHandler();
                JsonModel jsonModel = new JsonModel();

                // Метод, задающий документ явно
                // Document = creator.ExcplicitDocumentGet();

                ConverterToEnterpriseSheetModel converter = new ConverterToEnterpriseSheetModel();
                EnterpriseSheetDocument esDocument = converter.ConvertDocument(Document);

                jsonModel.Value = handler.ClearJson(serializer.Serialize(esDocument));

                return jsonModel.Value;

            }
            catch (Exception exception)
            {
                LogHelper.AddLog("Error. GetDocument. Error:" + exception.Message + " InnerException: " + exception.InnerException.Message);

                return null;
            }
        }

        public int GetNecessaryModalViewId(string documentId, string rowNumber, string columnNumber, string sheetNumber)
        {
            try
            {
                string chartInfo = "";
                int cellId = 0;
                int docId = Int32.Parse(documentId);
                int rowNum = Int32.Parse(rowNumber);
                int colNum = Int32.Parse(columnNumber);
                int sheetNum = Int32.Parse(sheetNumber);
                ChartToJsonModelConverter converter = new ChartToJsonModelConverter();
                List<Cell> cl = new List<Cell>();

                using (LandauEntities db = new LandauEntities())
                {
                    #region getting necessary cell id

                    Sheet validSheet = (from sh in db.Sheet where sh.DocumentId == docId && sh.Number == sheetNum select sh).ToList().LastOrDefault();
                    int valSheetId = validSheet.Id;

                    Body validBody = (from b in db.Body where b.SheetId == valSheetId select b).ToList().LastOrDefault();
                    int valBodyId = validBody.Id;

                    Row validRow = (from r in db.Row where r.Number == rowNum && r.BodyId == valBodyId select r).ToList().LastOrDefault();
                    int valRowId = validRow.Id;

                    cl = (from c in db.Cell where c.RowId == valRowId && c.Number == colNum select c).ToList();
                    #endregion
                }

                return (int)cl[0].ModalViewId;

            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public string GetChart(string documentId, string rowNumber, string columnNumber, string sheetNumber)
        {
            try
            {
                #region objects declaration
                ChartToJsonModelConverter converter = new ChartToJsonModelConverter();
                ChartInfoGetter cellsGetter = new ChartInfoGetter();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string chartInfo = "";
                ModalView modalQuery;
                #endregion

                int valModalId = GetNecessaryModalViewId(documentId, rowNumber, columnNumber, sheetNumber);

                if (valModalId == 0)
                {
                    return "{ \"state\": \"Empty\" }";
                }

                using (LandauEntities db = new LandauEntities())
                {
                    modalQuery = (from m in db.ModalView where m.Id == valModalId select m).ToList().LastOrDefault();
                }

                List<ChartInfo> infos = cellsGetter.GetChartInfo(modalQuery);
                List<Object> charts = new List<Object>();

                foreach (var item in infos)
                {
                    Object obj = new Object();
                    obj = (Object)DatabaseToModelConverter.InitChart(item.AnalyticDataId, item.TypeId);
                    if (obj != null) { charts.Add(obj); }
                }

                List<Object> jsonChartModels = new List<Object>();

                foreach (var item in charts)
                {
                    Object obj = converter.Convert(item, item.GetType().ToString());
                    if (obj != null) { jsonChartModels.Add(obj); }
                }

                chartInfo = serializer.Serialize(jsonChartModels);

                return chartInfo;
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        [HttpPost]
        public string GetChart2(string documentId, string sheetName)
        {
            try
            {
                #region objects declaration
                ChartToJsonModelConverter converter = new ChartToJsonModelConverter();
                ChartInfoGetter cellsGetter = new ChartInfoGetter();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string chartInfo = "";
                ModalView modalQuery;
                int docId = Int32.Parse(documentId);
                #endregion

                var dId = new SqlParameter("@DocumentId", docId);
                var sName = new SqlParameter("@SheetName", sheetName);
                var command = "select cells.* from Cell cells " +
                              "JOIN [Row] [rows] on [rows].Id = cells.RowId " +
                              "JOIN Body body on body.Id = [rows].BodyId " +
                              "JOIN Sheet sheet on sheet.Id = body.SheetId " +
                              "JOIN Documents doc on doc.Id = sheet.DocumentId " +
                              "where doc.Id = @DocumentId AND sheet.Name = @SheetName;";

                using (LandauEntities db = new LandauEntities())
                {

                    //List<Cell> cells = 
                    //    (from c in db.Cell
                    //        join r in db.Row on c.RowId equals r.Id
                    //        join b in db.Body on r.BodyId equals b.Id
                    //        join s in db.Sheet on b.SheetId equals s.Id
                    //        join d in db.Document on s.DocumentId equals d.Id
                    //        where d.Id == docId && s.Name == sheetName
                    //        select c).ToList();

                    Cell cell = db.Database.SqlQuery<Cell>(command, new object[] {dId, sName}).ToList().LastOrDefault();
                    int valModalId = (int) cell.ModalViewId;

               // int valModalId = GetNecessaryModalViewId(documentId, rowNumber, columnNumber, sheetNumber);

                    if (valModalId == 0)
                    {
                        return "{ \"state\": \"Empty\" }";
                    }


                    modalQuery = (from m in db.ModalView where m.Id == valModalId select m).ToList().LastOrDefault();
                }

                List<ChartInfo> infos = cellsGetter.GetChartInfo(modalQuery);
                List<Object> charts = new List<Object>();

                foreach (var item in infos)
                {
                    Object obj = new Object();
                    obj = (Object)DatabaseToModelConverter.InitChart(item.AnalyticDataId, item.TypeId);
                    if (obj != null) { charts.Add(obj); }
                }

                List<Object> jsonChartModels = new List<Object>();

                foreach (var item in charts)
                {
                    Object obj = converter.Convert(item, item.GetType().ToString());
                    if (obj != null) { jsonChartModels.Add(obj); }
                }

                chartInfo = serializer.Serialize(jsonChartModels);

                return chartInfo;
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        [HttpPost]
        public string GetCharts(string modal)
        {
            try
            {
                string chartInfo = "";
                int modalId = Int32.Parse(modal);
                ChartInfoGetter cellsGetter = new ChartInfoGetter();
                ChartToJsonModelConverter converter = new ChartToJsonModelConverter();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ModalView modalQuery;

                using (LandauEntities db = new LandauEntities())
                {
                    modalQuery = (from m in db.ModalView
                                  where m.Id == modalId
                                  select m).ToList().LastOrDefault();
                }

                List<ChartInfo> infos = cellsGetter.GetChartInfo(modalQuery);

                List<Object> charts = new List<Object>();
                foreach (var item in infos)
                {
                    Object obj = new Object();
                    obj = (Object)DatabaseToModelConverter.InitChart(item.AnalyticDataId, item.TypeId);
                    if (obj != null) { charts.Add(obj); }
                }

                List<Object> jsonChartModels = new List<Object>();

                foreach (var item in charts)
                {
                    Object obj = converter.Convert(item, item.GetType().ToString());
                    if (obj != null) { jsonChartModels.Add(obj); }
                }

                chartInfo = serializer.Serialize(jsonChartModels);

                return chartInfo;
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        [HttpPost]
        public string GetTransactions(string documentId, string rowNumber, string columnNumber, string sheetNumber)
        {
            try
            {
                #region declaration of objects
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<Object> charts = new List<Object>();
                List<Object> jsonChartModels = new List<Object>();
                ChartToJsonModelConverter converter = new ChartToJsonModelConverter();
                ChartInfoGetter cellsGetter = new ChartInfoGetter();
                ModalView modalQuery;
                #endregion

                int modalViewId = GetNecessaryModalViewId(documentId, rowNumber, columnNumber, sheetNumber);

                using (LandauEntities db = new LandauEntities())
                {
                    modalQuery = (from m in db.ModalView where m.Id == modalViewId select m).ToList().LastOrDefault();
                }

                List<ChartInfo> infos = cellsGetter.GetChartInfo(modalQuery);

                foreach (var item in infos)
                {
                    Object obj = new Object();
                    obj = (Object)DatabaseToModelConverter.InitChart(item.AnalyticDataId, item.TypeId);
                    if (obj != null) { charts.Add(obj); }
                }

                foreach (var item in charts)
                {
                    Object obj = converter.Convert(item, item.GetType().ToString());
                    if (obj != null) { jsonChartModels.Add(obj); }
                }

                string chartInfo = serializer.Serialize(jsonChartModels);

                if (chartInfo == "") { return "{ \"state\": \"Empty\" }"; }

                return chartInfo;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public FileResult ExportDocument(string id)
        {
            try
            {
                Document = DatabaseToModelConverter.GetDocumentFromDatabase(Int32.Parse(id));

                XlsxExport.Models.XModels.XDocument dllDoc = new XlsxExport.Models.XModels.XDocument();
                ToLibraryXDocumentConverter converter = new ToLibraryXDocumentConverter();
                dllDoc = converter.Convert(Document);
                XlsxExport.Exporter exporter = new XlsxExport.Exporter();
                FileInfo file = exporter.GenerateXls(dllDoc);

                byte[] fileBytes = System.IO.File.ReadAllBytes(file.ToString());
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file.Name);
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        [HttpPost]
        public void ImportDocument(string data)
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

        public void SetCurrentId(string id)
        {
            try
            {
                Id = Int32.Parse(id);
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Getting border styles for 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetBorders(string id)
        {
            try
            {
                List<XBorder> borders = DatabaseToModelConverter.InitBorders(Int32.Parse(id));

                List<EnterpriseSheetBorder> esBorders = ConverterToEnterpriseSheetModel.ConvertBorders(borders);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string bordersJson = serializer.Serialize(esBorders);

                return bordersJson;

            }
            catch (Exception exception)
            {
                return null;
            }
        }
        public string UpdateSourceCards(string changes)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                TransferModel[] models = serializer.Deserialize<TransferModel[]>(changes);

                if (models.Length > 0)
                {
                    string mChanges = serializer.Serialize(models);
                    LandauEntities entities = new LandauEntities();

                    int rId = Convert.ToInt32(models[0].Id);

                    var q = (from row in entities.SourceDocumentRow
                        join sheet in entities.SourceDocumentSheet on row.SourceDocumentSheetId equals sheet.Id
                        join document in entities.SourceDocuments on sheet.SourceDocumentId equals document.Id
                        select document).FirstOrDefault();

                    if (q != null)
                    {
                        OperationsHelper.MakeTransferCells(true,q.Id,mChanges);
                    }





                    //SourceDocumentHelper.UpdateSourceDocument();
                }

               
                return "";
            }
            catch (Exception exception)
            {
                return "";
            }
        }


        public string MakePurchase(string changes)
        {
            try
            {

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var models = serializer.Deserialize<PurchaseModel[]>(changes);
                if (models.Length > 0)
                {
                    string mChanges = serializer.Serialize(models);
                    LandauEntities entities = new LandauEntities();

                    

                    var q = (from row in entities.SourceDocumentRow
                             join sheet in entities.SourceDocumentSheet on row.SourceDocumentSheetId equals sheet.Id
                             join document in entities.SourceDocuments on sheet.SourceDocumentId equals document.Id
                             select document).FirstOrDefault();

                    if (q != null)
                    {
                        OperationsHelper.MakePurchaseOperation(q.Id, mChanges);
                    }





                    //SourceDocumentHelper.UpdateSourceDocument();
                }


                return "";
            }
            catch (Exception exception)
            {
                return "";
            }
        }
        public string Zakup(string id)
        {
            try
            {
                int idInteger = Int32.Parse(id);
                return SourceDocumentToViewConverter.GetZakup(idInteger);


            }
            catch (Exception exception)
            {
                return "";
            }
        }

    }
}
