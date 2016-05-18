using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Script.Serialization;
using Landau.DB;
using Landau.Models.SourceModels;
using System.Collections.Generic;
using Microsoft.Ajax.Utilities;

namespace Landau.Helper
{
    /// <summary>
    ///     класс для преобразования исходных докумментов
    ///     при выводе их в модальное окно
    /// </summary>
    public static class SourceDocumentToViewConverter
    {
        /// <summary>
        ///     выделяем и преобразовываем документ
        /// </summary>
        /// <returns></returns>

        public static string GetToSourceDocumentToViewModel(int documentId)
        {
            try
            {
                using (var entities = new LandauEntities())
                {
                    var docId = new SqlParameter("@DocumentId", documentId);
                    string documentName =
                        (from s in entities.SourceDocuments where s.Id == documentId select s.FileName).FirstOrDefault();

                    var documentInfo =
                       (from s in entities.SourceDocuments
                        where s.Id == documentId
                        select new
                        {
                            Name = s.FileName,
                            Extension = s.Extension
                        }).FirstOrDefault();
                    //инициализируем команду для поиска всех ячеек для этого документа
                    var command =
                        "select * from SourceDocumentCell cells Join SourceDocumentRow Rows on cells.SourceDocumentRowId=Rows.Id " +
                        "Join SourceDocumentSheet sheets on Rows.SourceDocumentSheetId=sheets.Id " +
                        "Join SourceDocuments document on sheets.SourceDocumentId=document.Id where  " +
                        "document.Id=@DocumentId;";

                    //исполняем команду и находи все ячейки документа
                    var cells = entities.Database.SqlQuery<SourceDocumentCell>(command, docId).ToList();

                    // подготовим выборку типов документов
                    Dictionary<int, string> documentTypeCatalogQuery = (from t in entities.ReportDocumentTypeCatalog
                                                                        select new
                                                                        {
                                                                            Key = t.Id,
                                                                            Value = t.Title
                                                                        }).ToDictionary(i => i.Key, v => v.Value);

                    Dictionary<int, string> reportDataTypeQuery = (from a in entities.ReportCellTypeCatalog
                                                                   select new
                                                                   {
                                                                       Key = a.Id,
                                                                       Value = a.Title
                                                                   }).ToDictionary(i => i.Key, v => v.Value);

                    int headRowId = cells[0].SourceDocumentRowId;

                    // Получим ячейки, которые являются шапкой таблицы
                    List<SourceDocumentCell> headCells = (from c in cells where c.SourceDocumentRowId == headRowId select c).ToList();


                    //находим все строки по ячейкам. для этого делаем Distinct по ID строки
                    var uniqueCells =
                        cells.Select(x => x.SourceDocumentRowId)
                            .Distinct()
                            .Select(y => cells.First(car => car.SourceDocumentRowId == y))
                            .ToList();


                    // убираем нулевой элемент из "уникальных" ячеек, т.к. шапка у нас уже есть
                    uniqueCells.Remove(uniqueCells[0]);

                    //строим документ
                    var sDocument = new SDocument();
                    sDocument.Name = documentName;
                    sDocument.Extension = documentInfo.Extension;
                    sDocument.Sheets.Add(new SSheet());

                    // построим "шапку" самостоятельно

                    SRow sRowHead = new SRow();

                    foreach (var headCellItem in headCells)
                    {
                        SCell sCellHead = new SCell();

                        sCellHead.AnalyticDataType = "";
                        sCellHead.DocumentType = "";
                        sCellHead.Number = headCellItem.Number;
                        sCellHead.Value = headCellItem.Value;

                        sRowHead.Cells.Add(sCellHead);
                    }

                    sRowHead.AnalyticDataType = "";
                    sRowHead.DocumentType = "";

                    // явно задаем столбцы, так как извлечь нам их неоткуда пока
                    sRowHead.Cells.Add(new SCell("Тип документа"));
                    sRowHead.Cells.Add(new SCell("Тип данных"));

                    sDocument.Sheets[0].Rows.Add(sRowHead);

                    //идем по всем уникальным ячейкам
                    var rowId = 1;
                    foreach (var currentCell in uniqueCells)
                    {
                        SRow row = new SRow();

                        //вытягиваем все группу ячеек для данной строки
                        var groupCells = cells.Where(x => x.SourceDocumentRowId == currentCell.SourceDocumentRowId);

                        //идем по группе ячеек
                        foreach (var groupCell in groupCells)
                        {
                            int key1 = 0;
                            int key2 = 0;
                            string analyticDataType = "";
                            string docType = "";

                            if (groupCell.AnalyticDataType != null)
                            {
                                key1 = (int)groupCell.AnalyticDataType;
                            }
                            if (groupCell.DocumentType != null)
                            {
                                key2 = (int)groupCell.DocumentType;
                            }

                            if (reportDataTypeQuery.ContainsKey(key1))
                            {
                                analyticDataType = reportDataTypeQuery[key1];
                            }
                            if (documentTypeCatalogQuery.ContainsKey(key2))
                            {
                                docType = documentTypeCatalogQuery[key2];
                            }



                            //добавляем ячейку в строку
                            SCell sCell = new SCell
                            {
                                Number = groupCell.Number,
                                Value = groupCell.Value,
                                RowId = groupCell.SourceDocumentRowId,
                                ValueType = groupCell.ValueType,
                                AnalyticDataType = analyticDataType,
                                DocumentType = docType
                            };
                            row.Cells.Add(sCell);

                            row.DocumentType = sCell.DocumentType;
                            row.AnalyticDataType = sCell.AnalyticDataType;
                        }

                        if (sDocument.Sheets[0].Rows.Count == 0)
                        {
                            int emptyHeaderCount = 1;
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                if (string.IsNullOrEmpty(row.Cells[i].Value))
                                {
                                    row.Cells[i].Value = "X" + emptyHeaderCount;
                                    emptyHeaderCount++;
                                }
                            }
                        }
                        row.Cells.Add(new SCell(row.Cells.LastOrDefault().DocumentType));
                        row.Cells.Add(new SCell(row.Cells[row.Cells.Count - 2].AnalyticDataType));

                        //добавляем строку
                        sDocument.Sheets[0].Rows.Add(row);

                    }
                    SetCellTypeList(ref sDocument);
                    //сериализуем документ
                    var javaScriptSerializer = new JavaScriptSerializer();
                    javaScriptSerializer.MaxJsonLength = Int32.MaxValue;
                    var jsonString = javaScriptSerializer.Serialize(sDocument);

                    return jsonString;
                }


            }
            catch (Exception)
            {
                return "";
            }
        }

        //public static SDocument GetToSourceDocumentToViewModel(int documentId)
        //{
        //    try
        //    {
        //        var entities = new LandauEntities();

        //        var docId = new SqlParameter("@DocumentId", documentId);
        //        string documentName =
        //            (from s in entities.SourceDocuments where s.Id == documentId select s.FileName).FirstOrDefault();

        //        var parameters = new List<SqlParameter>();
        //        parameters.Add(docId);

        //        var documentInfo =
        //           (from s in entities.SourceDocuments
        //            where s.Id == documentId
        //            select new
        //            {
        //                Name = s.FileName,
        //                Extension = s.Extension
        //            }).FirstOrDefault();

        //        //строим документ
        //        var sDocument = new SDocument();
        //        sDocument.Name = documentName;
        //        sDocument.Extension = documentInfo.Extension;
        //        sDocument.Sheets.Add(new SSheet());

        //        //инициализируем команду для поиска всех ячеек для этого документа
        //        var command =
        //            "select distinct * from SourceDocumentCell cells Join SourceDocumentRow Rows on cells.SourceDocumentRowId=Rows.Id " +
        //            "Join SourceDocumentSheet sheets on Rows.SourceDocumentSheetId=sheets.Id " +
        //            "Join SourceDocuments document on sheets.SourceDocumentId=document.Id where  " +
        //            "document.Id=@DocumentId;";

        //        //исполняем команду и находи все ячейки документа
        //        var cells = entities.Database.SqlQuery<SourceDocumentCell>(command, parameters
        //            .Select(x => ((ICloneable)x).Clone()).ToArray()).ToList();

        //        // подготовим выборку типов документов
        //        Dictionary<int, string> documentTypeCatalogQuery = (from t in entities.ReportDocumentTypeCatalog
        //                                                            select new
        //                                                            {
        //                                                                Key = t.Id,
        //                                                                Value = t.Title
        //                                                            }).ToDictionary(i => i.Key, v => v.Value);

        //        Dictionary<int, string> reportDataTypeQuery = (from a in entities.ReportCellTypeCatalog
        //                                                       select new
        //                                                       {
        //                                                           Key = a.Id,
        //                                                           Value = a.Title
        //                                                       }).ToDictionary(i => i.Key, v => v.Value);

        //        int headRowId = cells[0].SourceDocumentRowId;

        //        // Получим ячейки, которые являются шапкой таблицы
        //        List<SourceDocumentCell> headCells = (from c in cells where c.SourceDocumentRowId == headRowId select c).ToList();



        //        // построим "шапку" самостоятельно

        //        SRow sRowHead = new SRow();

        //        foreach (var headCellItem in headCells)
        //        {
        //            SCell sCellHead = new SCell();

        //            sCellHead.AnalyticDataType = "";
        //            sCellHead.DocumentType = "";
        //            sCellHead.Number = headCellItem.Number;
        //            sCellHead.Value = headCellItem.Value;

        //            sRowHead.Cells.Add(sCellHead);
        //        }

        //        sRowHead.AnalyticDataType = "";
        //        sRowHead.DocumentType = "";

        //        // явно задаем столбцы, так как извлечь нам их неоткуда пока
        //        sRowHead.Cells.Add(new SCell("Тип документа"));
        //        sRowHead.Cells.Add(new SCell("Тип данных"));

        //        sDocument.Sheets[0].Rows.Add(sRowHead);

        //        List<List<SourceDocumentCell>> allRows = new List<List<SourceDocumentCell>>();
        //        int firstId = cells[0].SourceDocumentRowId;
        //        int lastId = cells[cells.Count - 1].SourceDocumentRowId;
        //        int step = 1000;
        //        if (lastId - firstId < step) step = lastId - firstId;
        //        List<SourceDocumentCell> _allCells = new List<SourceDocumentCell>();
        //        int currentId = firstId;
        //        while (true)
        //        {
        //            int toId = currentId + step;
        //            var allCommand =
        //          "select distinct cells.* from SourceDocumentCell cells Join SourceDocumentRow Rows on cells.SourceDocumentRowId=Rows.Id " +
        //          "right Join SourceDocumentSheet sheets on Rows.SourceDocumentSheetId=sheets.Id " +
        //          "right Join SourceDocuments document on sheets.SourceDocumentId=document.Id  " +
        //          "where Rows.Id Between " + currentId + " AND " + toId;
        //            parameters = new List<SqlParameter>();
        //            parameters.Clear();
        //            parameters.Add(docId);
        //            entities.Database.CommandTimeout = 240;
        //            //исполняем команду и находи все ячейки документа
        //            List<SourceDocumentCell> allCells = entities.Database.SqlQuery<SourceDocumentCell>(allCommand, parameters.Select(x => ((ICloneable)x).Clone()).ToArray()).ToList();

        //            _allCells.AddRange(allCells);
        //            if (allCells.Count == 0) break;
        //            if (allCells[allCells.Count - 1].SourceDocumentRowId >= lastId) break;

        //            currentId += step;
        //        }

        //        foreach (var sourceCellItem in cells)
        //        {
        //            List<SourceDocumentCell> query = (from q in _allCells where q.SourceDocumentRowId == sourceCellItem.SourceDocumentRowId select q).ToList();

        //            if (query != null && query.Count > 0)
        //                allRows.Add(query);
        //        }


        //        SSheet sSheet = new SSheet();
        //        sSheet.Rows.Add(sRowHead);

        //        allRows.Remove(allRows[0]);

        //        foreach (var rowItem in allRows)
        //        {
        //            SRow sRow = new SRow();
        //            foreach (var cellItem in rowItem)
        //            {
        //                int key1 = (int)cellItem.AnalyticDataType;
        //                int key2 = (int)cellItem.DocumentType;
        //                string analyticDataType = "";
        //                string docType = "";


        //                analyticDataType = reportDataTypeQuery[key1];

        //                docType = documentTypeCatalogQuery[key2];

        //                sRow.AnalyticDataType = analyticDataType;
        //                sRow.DocumentType = docType;

        //                SCell sCell = new SCell();
        //                sCell.AnalyticDataType = analyticDataType;
        //                sCell.DocumentType = docType;
        //                sCell.Number = cellItem.Number;
        //                sCell.Value = cellItem.Value;

        //                sRow.Cells.Add(sCell);
        //            }

        //            sSheet.Rows.Add(sRow);
        //        }

        //        sDocument.Sheets.Add(sSheet);

        //        SetCellTypeList(ref sDocument);

        //        return sDocument;
        //    }
        //    catch (Exception exception)
        //    {
        //        return null;
        //    }
        //}


        /// <summary>
        /// Method for getting details about transaction in cell
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="cellId"></param>
        /// <returns></returns>
        public static SDocument GetDetailsFromSourceDocument(int documentId, int cellId)
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    // Получим ячейку по её Id, для извлечения из неё даннных (год, месяц и т.д.)
                    Landau.DB.Cell necessaryCell = (from c in db.Cell where c.Id == cellId select c).ToList().LastOrDefault();

                    // Получим документ по его Id, чтобы знать, с каким проектом мы работаем (projectId)
                    Landau.DB.Documents necessaryDocument = (from d in db.Documents where d.Id == documentId select d).ToList().LastOrDefault();

                    int yearValue = (int)necessaryCell.Year;
                    int monthValue = (int)necessaryCell.Month;
                    string sMonth = "0";
                    if (necessaryCell.Month != null)
                    {
                        sMonth = monthValue.ToString();
                        if (sMonth.Length == 1)
                            sMonth = "0" + sMonth;

                    }
                    int reportCellTypeValue = (int)necessaryCell.ReportCellType;
                    int reportDocumentTypeValue = (int)necessaryCell.ReportDocumentType;

                    int projectId = (int)necessaryDocument.ProjectId;

                    var docId = new SqlParameter("@DocumentId", documentId);
                    string documentName =
                        (from s in db.SourceDocuments where s.Id == documentId select s.FileName).FirstOrDefault();

                    //инициализируем команду для поиска всех ячеек для этого документа
                    var command =
                        "select distinct cells.* from SourceDocumentCell cells Join SourceDocumentRow Rows on cells.SourceDocumentRowId=Rows.Id " +
                        "right Join SourceDocumentSheet sheets on Rows.SourceDocumentSheetId=sheets.Id " +
                        "right Join SourceDocuments document on sheets.SourceDocumentId=document.Id " +
                        "right Join Documents pDocument on document.ProjectId=pDocument.ProjectId " +
                        "where " +
                        "document.ProjectId=" + projectId.ToString() + " AND " +
                        "cells.Name='Period' AND cells.Value LIKE '%" + sMonth + "." + yearValue.ToString() + "%' AND cells.AnalyticDataType=" + reportCellTypeValue + " AND cells.DocumentType=" + reportDocumentTypeValue; ;

                    var parameters = new List<SqlParameter>();
                    parameters.Add(docId);
                    //исполняем команду и находи все ячейки документа
                    var cells = db.Database.SqlQuery<SourceDocumentCell>(command, parameters.Select(x => ((ICloneable)x).Clone()).ToArray()).ToList();

                    //var dCells
                    // подготовим выборку типов документов
                    Dictionary<int, string> documentTypeCatalogQuery = (from t in db.ReportDocumentTypeCatalog
                                                                        select new
                                                                        {
                                                                            Key = t.Id,
                                                                            Value = t.Title
                                                                        }).ToDictionary(i => i.Key, v => v.Value);

                    Dictionary<int, string> reportDataTypeQuery = (from a in db.ReportCellTypeCatalog
                                                                   select new
                                                                   {
                                                                       Key = a.Id,
                                                                       Value = a.Title
                                                                   }).ToDictionary(i => i.Key, v => v.Value);


                    // получаем ячейки для шапки таблицы
                    int firstHeaderCellRowId = (from sdc in db.SourceDocumentCell select sdc).Take(1).FirstOrDefault().SourceDocumentRowId;
                    List<SourceDocumentCell> headerSourceCells = (from hsc in db.SourceDocumentCell
                                                                  where hsc.SourceDocumentRowId == firstHeaderCellRowId
                                                                  select hsc).ToList();

                    // получим ряд-шапку таблицы
                    SRow sRowHeader = new SRow();
                    int emptyHeaderCount = 1;
                    foreach (var headerCellItem in headerSourceCells)
                    {
                        SCell sCellHeader = new SCell();

                        int key1 = reportCellTypeValue;
                        int key2 = reportDocumentTypeValue;
                        string analyticDataType = "";
                        string docType = "";


                        analyticDataType = reportDataTypeQuery[key1];

                        docType = documentTypeCatalogQuery[key2];


                        sCellHeader.AnalyticDataType = analyticDataType;
                        sCellHeader.DocumentType = docType;
                        sCellHeader.Number = headerCellItem.Number;
                        sCellHeader.Value = headerCellItem.Value;
                        if (string.IsNullOrEmpty(sCellHeader.Value))
                        {
                            sCellHeader.Value = "X" + emptyHeaderCount;
                            emptyHeaderCount++;
                        }
                        sRowHeader.AnalyticDataType = analyticDataType;
                        sRowHeader.DocumentType = docType;

                        sRowHeader.Cells.Add(sCellHeader);
                    }

                    List<List<SourceDocumentCell>> allRows = new List<List<SourceDocumentCell>>();
                    int firstId = cells[0].SourceDocumentRowId;
                    int lastId = cells[cells.Count - 1].SourceDocumentRowId;
                    int step = 1000;
                    if (lastId - firstId < step) step = lastId - firstId;
                    List<SourceDocumentCell> _allCells = new List<SourceDocumentCell>();
                    int currentId = firstId;
                    while (true)
                    {
                        int toId = currentId + step;
                        var allCommand =
                      "select distinct cells.* from SourceDocumentCell cells Join SourceDocumentRow Rows on cells.SourceDocumentRowId=Rows.Id " +
                      "right Join SourceDocumentSheet sheets on Rows.SourceDocumentSheetId=sheets.Id " +
                      "right Join SourceDocuments document on sheets.SourceDocumentId=document.Id  " +
                      "right Join Documents pDocument on document.ProjectId=pDocument.ProjectId where " +
                      "document.ProjectId=" + projectId.ToString() + " AND cells.DocumentType=" +
                      reportDocumentTypeValue +
                      " AND Rows.Id Between " + currentId + " AND " + toId;
                        parameters = new List<SqlParameter>();
                        parameters.Clear();
                        parameters.Add(docId);
                        db.Database.CommandTimeout = 240;
                        //исполняем команду и находи все ячейки документа
                        List<SourceDocumentCell> allCells = db.Database.SqlQuery<SourceDocumentCell>(allCommand, parameters.Select(x => ((ICloneable)x).Clone()).ToArray()).ToList();

                        _allCells.AddRange(allCells);
                        if (allCells.Count == 0) break;
                        if (allCells[allCells.Count - 1].SourceDocumentRowId >= lastId) break;

                        currentId += step;
                    }

                    foreach (var sourceCellItem in cells)
                    {
                        List<SourceDocumentCell> query = (from q in _allCells where q.SourceDocumentRowId == sourceCellItem.SourceDocumentRowId select q).ToList();

                        if (query != null && query.Count > 0)
                            allRows.Add(query);
                    }


                    SDocument sDocument = new SDocument();
                    SSheet sSheet = new SSheet();
                    sSheet.Rows.Add(sRowHeader);

                    foreach (var rowItem in allRows)
                    {
                        SRow sRow = new SRow();
                        foreach (var cellItem in rowItem)
                        {
                            int key1 = reportCellTypeValue;
                            int key2 = reportDocumentTypeValue;
                            string analyticDataType = "";
                            string docType = "";


                            analyticDataType = reportDataTypeQuery[key1];

                            docType = documentTypeCatalogQuery[key2];

                            sRow.AnalyticDataType = analyticDataType;
                            sRow.DocumentType = docType;

                            SCell sCell = new SCell();
                            sCell.AnalyticDataType = analyticDataType;
                            sCell.DocumentType = docType;
                            sCell.Number = cellItem.Number;
                            sCell.Value = cellItem.Value;
                            sCell.RowId = cellItem.SourceDocumentRowId;

                            sRow.Cells.Add(sCell);
                        }

                        
                        sSheet.Rows.Add(sRow);
                    }

                    sDocument.Sheets.Add(sSheet);

                    SetCellTypeList(ref sDocument);

                    return sDocument;
                }


            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get all types for dropdown
        /// </summary>
        /// <returns></returns>
        public static void SetCellTypeList(ref SDocument document)
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    var query = (from t in db.ReportCellTypeCatalog where t.IsClassificator!=null && (bool)t.IsClassificator
                                 select new
                                 {
                                     Id = t.Id,
                                     Title = t.Title
                                 }).ToList();

                    foreach (var item in query)
                    {
                        document.CellTypes.Add(item as object);
                    }
                }

            }
            catch (Exception exception)
            {

            }
        }

        public static string GetZakup(int id)
        {
            try
            {
                id = 673;
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                using (LandauEntities entities = new LandauEntities())
                {
                    var documentInfo =
                        (from s in entities.SourceDocuments
                         where s.Id == id
                         select new
                         {
                             Name = s.FileName,
                             Extension = s.Extension
                         }).FirstOrDefault();

                    //инициализируем команду для поиска всех ячеек для этого документа
                    var command1 =
                        "select sdc.* from SourceDocuments sd " +
                        "LEFT JOIN SourceDocumentSheet sds ON sd.Id = sds.SourceDocumentId " +
                        "LEFT JOIN SourceDocumentRow sdr ON sds.Id = sdr.SourceDocumentSheetId " +
                        "LEFT JOIN SourceDocumentCell sdc ON sdr.Id = sdc.SourceDocumentRowId " +
                        "where sd.AccountNumber LIKE '10%'";
                    //    +"AND (sdc.Name = 'AnalyticaDt' OR sdc.Name = 'AccountDt') " +
                    //"AND sdc.Value NOT LIKE '335%' " +
                    //"AND sdc.Value NOT LIKE '338%' " +
                    //"AND sdc.Value NOT LIKE '343%' " +
                    //"AND sdc.Value NOT LIKE '10%' " +
                    //"AND sdc.Value NOT LIKE '31%' " +
                    //"AND sdc.Value NOT LIKE '32%';";

                    SqlParameter parameter = new SqlParameter("@Mask", id);
                    List<SqlParameter> ps = new List<SqlParameter>();
                    ps.Add(parameter);
                    //исполняем команду и находи все ячейки документа
                    var cells = entities.Database.SqlQuery<SourceDocumentCell>(command1, ps.Select(x => ((ICloneable)x).Clone()).ToArray()).ToList();

                    List<SourceDocumentCell> tt = (from c in cells
                                                   where
                                                       c.Name.Equals("AnalyticaDt") ||
                                                       c.Name.Equals("AccountDt") && !c.Value.StartsWith("335") && !c.Value.StartsWith("338") &&
                                                       !c.Value.StartsWith("343") && !c.Value.StartsWith("10") && !c.Value.StartsWith("31") &&
                                                       !c.Value.StartsWith("32") && !c.Value.StartsWith("14") && !c.Value.StartsWith("625") && 
                                                       !c.Value.StartsWith("628")
                                                   select c).ToList();

                    var rowIdsWithoutDuplicates = (from c in tt
                                                   group c by
                                                       new { c.SourceDocumentRowId } into g
                                                   where g.Count() > 1
                                                   orderby g.Key.SourceDocumentRowId
                                                   select g).ToList();

                    var cellsWithoutDuplicates = (from cw in cells
                                                  where cw.Name == "AnalyticaDt"
                                                  join ri in rowIdsWithoutDuplicates on cw.SourceDocumentRowId equals ri.Key.SourceDocumentRowId
                                                  select new
                                                  {
                                                      Id = cw.SourceDocumentRowId,
                                                      Value = cw.Value
                                                  }).ToList();


                    //var notPair = (from c in cells group c by c.SourceDocumentRowId 
                    //               where grp.Count() > 1
                    //               select grp).ToList();

                    //var result = (from c in cells 
                    //                  join n in notPair on c.SourceDocumentRowId equals n.)

                    var distinticBy = cellsWithoutDuplicates
                     .Select(car => car.Value)
                     .Distinct()
                     .Select(code => cellsWithoutDuplicates.First(car => car.Value == code))
                     .ToList();

                    List<SourceDocumentCell> cls = new List<SourceDocumentCell>();

                    foreach (var c in distinticBy)
                    {
                        if (!string.IsNullOrEmpty(c.Value) && !c.Value.Contains("Аналитика"))
                        {
                            string v = c.Value;
                            //if (c.Value.Contains('\n'))
                            List<string> vals = c.Value.Split('\n').ToList();
                            if (vals.Count > 0)
                                v = vals[0];
                            cls.Add(new SourceDocumentCell() { Id = c.Id, Value = v });
                        }
                    }

                    var distinticBy2 = cls
                     .Select(car => car.Value)
                     .Distinct()
                     .Select(code => cls.First(car => car.Value == code))
                     .ToList();

                    List<SourceDocumentCell> cls2 = new List<SourceDocumentCell>();

                    foreach (var dd in distinticBy2)
                    {
                        cls2.Add(new SourceDocumentCell() { Id = dd.Id, Value = dd.Value });
                    }

                    return serializer.Serialize(cls2);
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}