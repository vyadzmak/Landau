using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XlsxExport.Models.XModels;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;
namespace XlsxExport
{
    public class Exporter
    {
        private XDocument Document { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Exporter()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

        public FileInfo GenerateXls(XDocument document)
        {
            try
            {
                FileInfo file = OutputFileCreating(document);
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    foreach (var sheetItem in document.Sheets)
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetItem.Id.ToString());
                        foreach (var rowItem in sheetItem.Body.Rows)
                        {
                            foreach (var cellItem in rowItem.Cells)
                            {
                                int val;
                                if (Int32.TryParse(cellItem.Value, out val))
                                {
                                    worksheet.Cells[rowItem.Number, cellItem.Number].Value = Int32.Parse(cellItem.Value);
                                }
                                else
                                {
                                    if (cellItem.Value.IndexOf("=") != -1)
                                    {
                                        worksheet.Cells[rowItem.Number, cellItem.Number].Formula = cellItem.Value;
                                    }
                                    else 
                                    {
                                        worksheet.Cells[rowItem.Number, cellItem.Number].Value = cellItem.Value;
                                    }
                                    
                                }
                            }
                        }

                        #region borders and groups explicit addition
                        // Explicit border style and groups addition
                        foreach(var cellItem in worksheet.Cells["C4:O5"])
                        {
                            cellItem.Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                        }
                   
                        for (var i = 3; i <= 15; i++)
                        {
                            worksheet.Column(i).OutlineLevel = 1;
                            worksheet.Column(i).Collapsed = true;
                        }

                        worksheet.Cells["C2"].AddComment("Some example text", "Me");
                        #endregion

                    }

                    package.Save();

                }

                return file;

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public FileInfo OutputFileCreating(XDocument document)
        {
            try
            {
                string outputPath = @"c:\Out\";

                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }

                FileInfo newFile = new FileInfo(outputPath + document.Name + ".xlsx");
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new FileInfo(outputPath + document.Name + ".xlsx");
                }

                return newFile;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
