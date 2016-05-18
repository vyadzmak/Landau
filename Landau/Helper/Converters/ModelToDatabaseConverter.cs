using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Landau.Models;
using Landau.Models.XModels;
using Landau.DB;
using System.Data.Linq;


namespace Landau.Helper
{
    public class ModelToDatabaseConverter
    {
        public static XDocument UpdateDocumentInDatabase(XDocument document, int sheetIndex, int rowIndex,
            int cellIndex, int userId)
        {
            try
            {
                CellStyleTemplates styleTemplateNew = new CellStyleTemplates();

                using (LandauEntities db = new LandauEntities())
                {
                    var cellStylesQuery = (from cs in db.CellStyleTemplates select cs).ToList();


                    Document documentNew = new Document()
                    {
                        Id = document.Id,
                        Name = document.Name
                    };
                    db.Document.AddOrUpdate(documentNew);
                    db.SaveChanges();

                    int necessarySheetIndex = IndexSelectorByNumber(document.Sheets, sheetIndex);

                    Sheet sheetNew = new Sheet()
                    {
                        Number = document.Sheets[necessarySheetIndex].Number,
                        DocumentId = document.Id,
                        Name = document.Sheets[necessarySheetIndex].Name
                    };

                    if (document.Sheets[necessarySheetIndex].Id != 0)
                    {
                        sheetNew.Id = document.Sheets[necessarySheetIndex].Id;
                    }

                    db.Sheet.AddOrUpdate(sheetNew);
                    db.SaveChanges();

                    document.Sheets[necessarySheetIndex].Id = sheetNew.Id;

                    Body bodyNew = new Body()
                    {
                        SheetId = sheetNew.Id,
                    };

                    if (document.Sheets[necessarySheetIndex].Body.Id != 0)
                    {
                        bodyNew.Id = document.Sheets[necessarySheetIndex].Body.Id;
                    }
                    db.Body.AddOrUpdate(bodyNew);
                    db.SaveChanges();

                    document.Sheets[necessarySheetIndex].Body.Id = bodyNew.Id;

                    int necessaryRowIndex = IndexSelectorByNumber(document.Sheets[necessarySheetIndex].Body.Rows, rowIndex);
                    Row rowNew = new Row()
                    {
                        BodyId = bodyNew.Id,
                        Number = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Number
                    };

                    if (document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Id != 0)
                    {
                        rowNew.Id = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Id;
                    }

                    db.Row.AddOrUpdate(rowNew);
                    db.SaveChanges();

                    document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Id = rowNew.Id;

                    int necessaryCellIndex = IndexSelectorByNumber(document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells, cellIndex);

                    XCell cell = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex];
                    // Поищем готовый стиль в таблице стилей
                    bool isExisting = false;
                    foreach (var cellStyleItem in cellStylesQuery)
                    {
                        if (cellStyleItem.FontWeight == cell.Style.FontWeight &&
                            cellStyleItem.BackgroundColor == cell.Style.BackgroundColor &&
                            cellStyleItem.FontColor == cell.Style.FontColor &&
                            cellStyleItem.CellType == cell.Style.CellType &&
                            cellStyleItem.Align == cell.Style.Align &&
                            cellStyleItem.DFM == cell.Style.DFM &&
                            cellStyleItem.Height == cell.Style.Height &&
                            cellStyleItem.Width == cell.Style.Width &&
                            cellStyleItem.FontFamily == cell.Style.FontFamily &&
                            cellStyleItem.DecorLine == cell.Style.DecorLine &&
                            cellStyleItem.Indent == cell.Style.Indent &&
                            cellStyleItem.FontSize == cell.Style.FontSize)
                        {
                            isExisting = true;
                            styleTemplateNew = cellStyleItem;
                            break;
                        }
                    }

                    // Если так и не нашли - запилим новый
                    if (!isExisting)
                    {
                        styleTemplateNew = new CellStyleTemplates()
                        {
                            FontWeight = cell.Style.FontWeight,
                            FontSize = cell.Style.FontSize,
                            BackgroundColor = cell.Style.BackgroundColor,
                            FontColor = cell.Style.FontColor,
                            CellType = cell.Style.CellType,
                            CellDataFormat = cell.Style.CellDataFormat,
                            Align = cell.Style.Align,
                            DFM = cell.Style.DFM,
                            Height = cell.Style.Height,
                            Width = cell.Style.Width,
                            FontFamily = cell.Style.FontFamily,
                            FontStyle = cell.Style.FontStyle,
                            DecorLine = cell.Style.DecorLine,
                            Indent = cell.Style.Indent,
                            Name = cell.Style.Name
                        };

                        db.CellStyleTemplates.Add(styleTemplateNew);
                        db.SaveChanges();
                    }

                    Cell cellNew = new Cell()
                    {
                        Number = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex].Number,
                        RowId = rowNew.Id,
                        Value = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex].Value,
                        ModalViewId = 0,
                        CellStyleId = styleTemplateNew.Id,
                        Editable = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex].Editable,
                        Calculation = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex].IsFormula
                    };

                    if (document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex].Id != 0)
                    {
                        cellNew.Id = document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex].Id;
                    }
                    db.Cell.AddOrUpdate(cellNew);
                    db.SaveChanges();

                    document.Sheets[necessarySheetIndex].Body.Rows[necessaryRowIndex].Cells[necessaryCellIndex].Id = cellNew.Id;

                    if (cell.Comment != null)
                    {
                        CellComments cellCommentNew = new CellComments()
                        {
                            Message = cell.Comment.Message,
                            CellId = cellNew.Id
                        };

                        if (cell.Comment.Id != 0)
                        {
                            cellCommentNew.Id = cell.Comment.Id;
                        }
                        db.CellComments.AddOrUpdate(cellCommentNew);
                        db.SaveChanges();
                    }


                    db.Dispose();

                    return document;
                }

               
            }
            catch (Exception exception)
            {
                return document;
            }


        }

        public static void UpdateDocumentVersion(XDocument document, int userId)
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    DocumentControlVersion docVerNew = new DocumentControlVersion()
                    {
                        DocId = document.Id,
                        Version = document.Version,
                        ChangeDate = DateTime.Now,
                        UserId = userId,
                        State = true
                    };
                    db.DocumentControlVersion.AddOrUpdate(docVerNew);
                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {

            }
        }

        public static void UpdateSingleCellInDatabase(XRow row, XCell cell)
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    CellStyleTemplates styleTemplate = new CellStyleTemplates()
                    {
                        Id = cell.Style.Id,
                        FontWeight = cell.Style.FontWeight,
                        FontSize = cell.Style.FontSize,
                        BackgroundColor = cell.Style.BackgroundColor,
                        FontColor = cell.Style.FontColor,
                        CellType = cell.Style.CellType,
                        CellDataFormat = cell.Style.CellDataFormat,
                        Align = cell.Style.Align,
                        DFM = cell.Style.DFM,
                        Height = cell.Style.Height,
                        Width = cell.Style.Width,
                        FontFamily = cell.Style.FontFamily,
                        FontStyle = cell.Style.FontStyle,
                        DecorLine = cell.Style.DecorLine,
                        Indent = cell.Style.Indent,
                        Name = cell.Style.Name
                    };

                    db.Cell.AddOrUpdate();
                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                
            }
        }


        /// <summary>
        /// Selecting necessary index by sheet index
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int IndexSelectorByNumber(List<XRow> rows, int number)
        {
            try
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    if (rows[i].Number == number)
                    {
                        return i;
                    }
                }

                return 0;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Selecting necessary index by sheet index
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int IndexSelectorByNumber(List<XCell> cells, int number)
        {
            try
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    if (cells[i].Number == number)
                    {
                        return i;
                    }
                }

                return 0;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Selecting necessary index by sheet index
        /// </summary>
        /// <param name="sheets"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int IndexSelectorByNumber(List<XSheet> sheets, int number)
        {
            try
            {
                for (int i = 0; i < sheets.Count; i++)
                {
                    if (sheets[i].Number == number)
                    {
                        return i;
                    }
                }

                return 0;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }
    }
}