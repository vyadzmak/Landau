using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Landau.Models.XModels;

namespace Landau.Helper
{
    public class ExplicitDocumentCreation
    {
        public XDocument Document { get; set; }

        public XSheet Sheet { get; set; }

        public XBody Body { get; set; }

        //public XDocument ExcplicitDocumentGet()
        //{
        //    #region zeroRow
        //    List<XCell> xCells0 = new List<XCell>();
        //    XCell cell0 = new XCell(0, 2, "", null, "bold", 240, null, null, null, null, null, null);
        //    xCells0.Add(cell0);
        //    XRow xRow0 = new XRow(0, 0, xCells0);
        //    #endregion

        //    #region firstRow
        //    List<XCell> xCells1 = new List<XCell>();
        //    XCell cell1 = new XCell(1, 2, "ОПиУ", null, "bold", null, null, null, null, null, null, null, "Документ такой");
        //    xCells1.Add(cell1);
        //    XRow xRow1 = new XRow(1, 1, xCells1);
        //    #endregion

        //    #region thirdRow
        //    XCell cell2 = new XCell(2, 2, "ТОО \"ALMA Paper\"", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell3 = new XCell(3, 15, "2013г.", null, "bold", null, null, null, null, null, null, null);

        //    XRow xRow3 = new XRow(2, 3, new List<XCell>() { cell2, cell3 });
        //    #endregion

        //    #region fourthRow
        //    XCell cell4 = new XCell(4, 2, "Период", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell5 = new XCell(5, 3, "янв.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell6 = new XCell(6, 4, "фев.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell7 = new XCell(7, 5, "мар.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell8 = new XCell(8, 6, "апр.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell9 = new XCell(9, 7, "май.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell10 = new XCell(10, 8, "июн.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell11 = new XCell(11, 9, "июл.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell12 = new XCell(12, 10, "авг.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell13 = new XCell(13, 11, "сен.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell14 = new XCell(14, 12, "окт.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell15 = new XCell(15, 13, "ноя.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell16 = new XCell(16, 14, "дек.13", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell17 = new XCell(17, 15, "Ср. мес. 2013г.", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell18 = new XCell(18, 16, "Итого за 2013г.", null, "bold", null, null, null, null, null, Color.DarkTurquoise, null);

        //    XRow xRow4 = new XRow(3, 4, new List<XCell>() { cell4, cell5, cell6, cell7, cell8, cell9, cell10, cell11, 
        //        cell12, cell13, cell14, cell15, cell16, cell17, cell18 });
        //    #endregion

        //    #region fifthRow
        //    XCell cell34 = new XCell(34, 2, "Выручка", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell35 = new XCell(35, 3, "=C6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell36 = new XCell(36, 4, "=D6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell37 = new XCell(37, 5, "=E6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell38 = new XCell(38, 6, "=F6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell39 = new XCell(39, 7, "=G6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell40 = new XCell(40, 8, "=H6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell41 = new XCell(41, 9, "=I6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell42 = new XCell(42, 10, "=J6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell43 = new XCell(43, 11, "=K6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell44 = new XCell(44, 12, "=L6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell45 = new XCell(45, 13, "=M6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell46 = new XCell(46, 14, "=N6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell47 = new XCell(47, 15, "=O6", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell48 = new XCell(48, 16, "=P6", null, "bold", null, null, null, null, null, null, null);

        //    XRow xRow5 = new XRow(3, 5, new List<XCell>() { cell34, cell35, cell36, cell37, cell38, cell39, cell40, 
        //        cell41, cell42, cell43, cell44, cell45, cell46, cell47, cell48 });
        //    #endregion

        //    #region sixthRow
        //    XCell cell49 = new XCell(19, 2, "Выручка по счету 6010", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell50 = new XCell(20, 3, "28477949.07", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell51 = new XCell(21, 4, "28477949.07", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell52 = new XCell(22, 5, "38722274.86", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell53 = new XCell(23, 6, "32832326.7", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell54 = new XCell(24, 7, "35486168.74", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell55 = new XCell(25, 8, "37179243.26", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell56 = new XCell(26, 9, "53058295.47", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell57 = new XCell(27, 10, "34000550.9", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell58 = new XCell(28, 11, "28168739.24", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell59 = new XCell(29, 12, "40232941.93", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell60 = new XCell(30, 13, "31687118.69", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell61 = new XCell(31, 14, "19022450", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell62 = new XCell(32, 15, "=AVERAGE(C6:N6)", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell63 = new XCell(33, 16, "=SUM(C6:N6)", null, null, null, null, null, null, null, Color.DarkTurquoise, null);

        //    XRow xRow6 = new XRow(3, 6, new List<XCell>() { cell49, cell50, cell51, cell52, cell53, cell54, cell55, cell56, cell57, cell58,
        //    cell59, cell60, cell61, cell62, cell63 });
        //    #endregion

        //    #region seventhRow
        //    XCell cell64 = new XCell(34, 2, "Себестоимость", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell65 = new XCell(35, 3, "=C8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell66 = new XCell(36, 4, "=D8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell67 = new XCell(37, 5, "=E8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell68 = new XCell(38, 6, "=F8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell69 = new XCell(39, 7, "=G8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell70 = new XCell(40, 8, "=H8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell71 = new XCell(41, 9, "=I8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell72 = new XCell(42, 10, "=J8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell73 = new XCell(43, 11, "=K8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell74 = new XCell(44, 12, "=L8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell75 = new XCell(45, 13, "=M8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell76 = new XCell(46, 14, "=N8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell77 = new XCell(47, 15, "=O8", null, "bold", null, null, null, null, null, null, null);
        //    XCell cell78 = new XCell(48, 16, "=P8", null, "bold", null, null, null, null, null, null, null);

        //    XRow xRow7 = new XRow(3, 7, new List<XCell>() { cell64, cell65, cell66, cell67, cell68, cell69, cell70, 
        //        cell71, cell72, cell73, cell74, cell75, cell76, cell77, cell78 });
        //    #endregion

        //    #region eighthRow
        //    XCell cell79 = new XCell(34, 2, "Себестоимость 7010", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell80 = new XCell(35, 3, "26202124.18", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell81 = new XCell(36, 4, "21130022.88", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell82 = new XCell(37, 5, "35004198.92", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell83 = new XCell(38, 6, "28971665.91", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell84 = new XCell(39, 7, "31556570.38", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell85 = new XCell(40, 8, "33400746.21", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell86 = new XCell(41, 9, "43601485.23", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell87 = new XCell(42, 10, "29594103.18", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell88 = new XCell(43, 11, "24199583.72", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell89 = new XCell(44, 12, "34356056.24", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell90 = new XCell(45, 13, "26880227.41", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell91 = new XCell(46, 14, "16833764.47", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell92 = new XCell(47, 15, "=AVERAGE(C8:N8)", null, null, null, null, null, null, null, Color.DarkTurquoise, null);
        //    XCell cell93 = new XCell(48, 16, "=SUM(C8:N8)", null, null, null, null, null, null, null, Color.DarkTurquoise, null);

        //    XRow xRow8 = new XRow(3, 8, new List<XCell>() { cell79, cell80, cell81, cell82, cell83, cell84, cell85, 
        //        cell86, cell87, cell88, cell89, cell90, cell91, cell92, cell93});
        //    #endregion

        //    #region ninthRow
        //    XCell cell94 = new XCell(34, 2, "Маржа", null, null, null, null, null, null, null, null, null);
        //    XCell cell95 = new XCell(35, 3, "=ROUND(((C6/C8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell96 = new XCell(36, 4, "=ROUND(((D6/D8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell97 = new XCell(37, 5, "=ROUND(((E6/E8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell98 = new XCell(38, 6, "=ROUND(((F6/F8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell99 = new XCell(39, 7, "=ROUND(((G6/G8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell100 = new XCell(40, 8, "=ROUND(((H6/H8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell101 = new XCell(41, 9, "=ROUND(((I6/I8)*100),1)& \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell102 = new XCell(42, 10, "=ROUND(((J6/J8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell103 = new XCell(43, 11, "=ROUND(((K6/K8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell104 = new XCell(44, 12, "=ROUND(((L6/L8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell105 = new XCell(45, 13, "=ROUND(((M6/M8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell106 = new XCell(46, 14, "=ROUND(((N6/N8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell107 = new XCell(47, 15, "=ROUND(((O6/O8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);
        //    XCell cell108 = new XCell(48, 16, "=ROUND(((P6/P8)*100),1) & \" % \"", null, null, null, null, null, null, null, null, null);

        //    XRow xRow9 = new XRow(3, 9, new List<XCell>() { cell94, cell95, cell96, cell97, cell98, cell99, cell100, 
        //        cell101, cell102, cell103, cell104, cell105, cell106, cell107, cell108 });
        //    #endregion

        //    Body = new XBody(new List<XRow>() { xRow0, xRow1, xRow3, xRow4, xRow5, xRow6, xRow7, xRow8, xRow9 });

        //    Sheet = new XSheet(1, 1, Body);
        //    List<XSheet> xSheets = new List<XSheet>();
        //    xSheets.Add(Sheet);

        //    Document = new XDocument(xSheets);

        //    Document.Id = 1;
        //    Document.Name = "test";
        //    Document.Sheets = xSheets;

        //    return Document;
        //}
    }
}