using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Landau.Models.MyDocumentModels;
using Landau.Models.MyDocumentModels.EnterpriseSheetModels;
using Landau.Models.XModels;
using Landau.Helper;


namespace Landau.Helper
{
    public class ConverterToEnterpriseSheetModel
    {
        /// <summary>
        /// Number of sheet
        /// </summary>
        public int SheetNumber { get; set; }

        private XDocument Document { get; set; }

        //private List<EnterpriseSheetCell> ESCells { get; set; }

        #region methods

        public static List<EnterpriseSheetBorder> ConvertBorders(List<XBorder> borders)
        {
            try
            {
                List<EnterpriseSheetBorder> esBorders = new List<EnterpriseSheetBorder>();

                foreach (var borderItem in borders)
                {
                    esBorders.Add(new EnterpriseSheetBorder(borderItem.Position, borderItem.Color, borderItem.Width, borderItem.LineType, 
                        new EnterpriseSheetBorderRange(borderItem.SheetNumber, borderItem.StartRowNumber, borderItem.StartColNumber,
                            borderItem.EndRowNumber, borderItem.EndColNumber)));
                }

                return esBorders;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Method, converting our document's cells model to EnterpriseSheet's acceptable model
        /// </summary>
        /// <returns></returns>
        public List<EnterpriseSheetCell> ConvertCells()
        {
            try
            {
                List<EnterpriseSheetCell> enterpriseSheetCells = new List<EnterpriseSheetCell>();

                foreach (var sheet in Document.Sheets)
                {
                    foreach (var row in sheet.Body.Rows)
                    {
                        foreach (var cell in row.Cells)
                        {
                            BoolPropertiesConverter boolConverter = new BoolPropertiesConverter();
                            EnterpriseSheetJson enterpriseSheetJson;

                            if (!cell.IsFitting) 
                            {
                                enterpriseSheetJson = new EnterpriseSheetJson(cell.Value,
                                 cell.Style.FontWeight,
                                 boolConverter.GetState(cell),
                                 cell.Style.FontStyle,
                                 cell.Style.FontSize,
                                 cell.Style.FontFamily,
                                 cell.IsFormula,
                                 boolConverter.GetState(cell),
                                 boolConverter.GetState(cell),
                                 cell.Style.BackgroundColor,
                                 cell.Style.FontColor,
                                 cell.Style.Height,
                                 cell.Style.Width,
                                 null,//cell.Comment.Message,
                                 cell.Format.Format,
                                 cell.Format.Template,
                                 cell.Style.Indent.ToString() + "px",
                                 cell.Style.Align,
                                 cell.Editable
                             );
                            }
                            else
                            {
                                enterpriseSheetJson = new EnterpriseSheetJson(cell.Style.Width);
                            }

                            // Filling Of "json" Field
                            

                            if (cell.IsButton)
                            {
                                enterpriseSheetJson.onCellMouseMoveFn = "CELL_MOUSE_OUT_CALLBACK_FN";
                            }

                           // Filling of cell
                            EnterpriseSheetCell enterpriseSheetCell = new EnterpriseSheetCell(sheet.Number, row.Number,
                                cell.Number, enterpriseSheetJson);

                          
                            

                            enterpriseSheetCells.Add(enterpriseSheetCell);

                        }
                    }
                }

                return enterpriseSheetCells;
            }
            catch (Exception exception)
            {
                return null;
            }
           
        }

        /// <summary>
        /// Method, converting our document's sheets model to EnterpriseSheet's acceptable model
        /// </summary>
        /// <returns></returns>
        public List<EnterpriseSheetSheet> ConvertSheets()
        {
            try
            {
                List<EnterpriseSheetSheet> sheets = new List<EnterpriseSheetSheet>();
                EnterpriseSheetSheet esSheetNew;
                foreach (var sheetItem in Document.Sheets)
                {
                    if (sheetItem.Name != "")
                    { 
                        esSheetNew = new EnterpriseSheetSheet(sheetItem.Number, sheetItem.Name); 
                    }
                    else
                    {
                        esSheetNew = new EnterpriseSheetSheet(sheetItem.Number, sheetItem.Number.ToString()); 
                    }
                    

                    sheets.Add(esSheetNew);
                }

                return sheets;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

       /// <summary>
        /// Method, converting our document's floatings model to EnterpriseSheet's acceptable model
       /// </summary>
       /// <returns></returns>
        public List<EnterpriseSheetGroup> ConvertFloatings()
        {
            try
            {
                // Excplicit creation of groups 
                
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                
               
                List<EnterpriseSheetGroup> groups = new List<EnterpriseSheetGroup>();

                foreach (var item in Document.Floatings)
                {
                    List<GroupJsonItem> items = new List<GroupJsonItem>();
                    foreach (var groupItem in item.Groups)
                    {
                        GroupJsonItem i = new GroupJsonItem(groupItem.Level, groupItem.Start, groupItem.End);
                        items.Add(i);
                    }
                    string jsonItemsString = serializer.Serialize(items).Replace("\"", "");
                    groups.Add(new EnterpriseSheetGroup(item.SheetNumber, "colGroups", "colgroups", jsonItemsString)) ;
                }
               

                

                return groups;
            }
            catch (Exception exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Summarizes all convertions to one ES model document
        /// </summary>
        /// <returns></returns>
        public EnterpriseSheetDocument ConvertDocument(XDocument document)
        {
            try
            {
                Document = document;

                string fileName = Document.Name;
                List<EnterpriseSheetSheet> sheets = ConvertSheets(); 
                List<EnterpriseSheetCell> cells = ConvertCells();
                List<EnterpriseSheetGroup> floatings = ConvertFloatings();

                return new EnterpriseSheetDocument(fileName, document.Version, sheets, cells, floatings);
            }
            catch (Exception exception)
            {
                return null;
            }
             
        }

        #endregion

        /// <summary>
        /// Constructor of converter class
        /// </summary>
        public ConverterToEnterpriseSheetModel()
        {
            try
            {
            }
            catch (Exception exception)
            {

            }
        }
    }
}