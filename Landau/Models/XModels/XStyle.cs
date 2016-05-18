using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Helper;

namespace Landau.Models.XModels
{
    public class XStyle
    {
        public int Id { get; set; }
        public string Align { get; set; }
        public string FontWeight { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public string FontStyle { get; set; }
        public bool Underline { get; set; }
        public bool Overline { get; set; }
        public bool Strike { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Indent { get; set; }
        public string DecorLine { get; set; }
        public  string Name { get; set; }
        public string CellDataFormat { get; set; }
        public string DFM { get; set; }
        public string CellType { get; set; }
        
        //Id = 0; 
        //FontSize = DefautFontSize;
        //FontWeight = "normal";
        //FontStyle = "normal";
        //FontFamily = "times";
        //BackgroundColor = "white";
        //FontColor = "black";
        //Height = 2
        //Indent = 0;
        //Align = "right";
        //DecorLine = null;

         /// <summary>
        /// XCell's constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="align"></param>
        /// <param name="fontSize"></param>
        /// <param name="weight"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="family"></param>
        /// <param name="back"></param>
        /// <param name="fontColor"></param>
        /// <param name="decorLine"></param>
        public XStyle(
            int id,           // 1
            int? fontSize,    // 2
            string weight,    // 3
            int? width,       // 4
            int? height,      // 5 
            string style,     // 6
            string family,    // 7
            string back,      // 8
            string fontColor, // 9
            int indent,       // 10
            string align,     // 11
            string decorLine,  // 12
            string name,
            string cellDataFormat,
            string cellType
            ) 
        {
            try
            {
                Id = id;

                if (fontSize != null)
                {
                    FontSize = CellPropertiesValidator.FontSizeValidate((int)fontSize);
                }
                else
                {
                    FontSize = 10;  // Default font size
                }

                if (weight != null)
                {
                    FontWeight = CellPropertiesValidator.FontWeightValidate(weight);
                }
                else
                {
                    FontWeight = "normal";
                }

                if (style != null)
                {
                    FontStyle = CellPropertiesValidator.FontStyleValidate(style);
                }
                else
                {
                    FontStyle = "normal";
                }

                if (family != null)
                {
                    FontFamily = family;
                }
                else
                {
                    FontFamily = "times";
                }

                if (back != null)
                {
                    BackgroundColor = back;
                }
                else
                {
                    BackgroundColor = "white";
                }

                if (fontColor != null)
                {
                    FontColor = fontColor;
                }
                else
                {
                    FontColor = "black";
                }

                Height = CellPropertiesValidator.CellHeightValidate(height);
                Width = CellPropertiesValidator.CellWidthValidate(width);
                Indent = indent;
                Align = align;
                DecorLine = decorLine;
                Name = name;

                if (cellDataFormat != null)
                {
                    CellDataFormat = cellDataFormat;
                }
                else
                {
                    CellDataFormat = "";
                }

                if (cellType != null)
                {
                    CellType = cellType;
                }
                else
                {
                    CellType = "";
                }
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty constructor, called to set style with default parameters
        /// </summary>
        public XStyle(string name)
        {
            try
            {
                Id = 0; 
                FontSize = 10;
                FontWeight = "normal";
                FontStyle = "normal";
                FontFamily = "times";
                BackgroundColor = "white";
                FontColor = "black";
                Height = 20;
                Width = 80;
                Indent = 0;
                Align = "right";
                DecorLine = null;
                Name = name;
            }
            catch (Exception exception)
            {
                
            }
        }
        public XStyle(int width)
        {
            try
            {
                Width = width;
            }
            catch (Exception exception)
            {
                
            }
        }
    }
}
