using System;
using XlsxExport.Helpers;
using System.Drawing;

namespace XlsxExport.Models.XModels
{
    public class XCell
    {
        #region fields
        public int Id { get; set; }

        public int Number { get; set; }

        public string Value { get; set; }

        public string FontWeight { get; set; }

        public string FontFamily { get; set; }

        public int FontSize { get; set; }

        public string FontStyle { get; set; }

        public bool Underline { get; set; }

        public bool Overline { get; set; }

        public bool Strike { get; set; }

        public int Rotation { get; set; }

        public string BackgroundColor { get; set; }

        public string FontColor { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Comment { get; set; }

        #endregion

        public int DefautFontSize = 10;

        #region constructors
        /// <summary>
        /// XCell's constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public XCell(int id, int number, string value)
        {
            try
            {
                Id = id;
                Number = number;
                Value = value;
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// XCell's constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <param name="weight"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="family"></param>
        /// <param name="rotation"></param>
        /// <param name="back"></param>
        /// <param name="fontColor"></param>
        public XCell(int id, int number, string value, int? size, string weight, int? width, int? height,
            string style, string family, int? rotation, string back, string fontColor)
        {
            try
            {
                Id = id;
                Number = number;
                Value = value;
                if (size != null)
                {
                    FontSize = CellPropertiesValidator.FontSizeValidate((int)size);
                }
                else
                {
                    FontSize = DefautFontSize;
                }

                if (weight != null)
                {
                    FontWeight = CellPropertiesValidator.FontWeightValidate(weight);
                }

                if (style != null)
                {
                    FontStyle = CellPropertiesValidator.FontStyleValidate(style);
                }

                if (style != null)
                {
                    FontFamily = family;
                }

                if (rotation != null)
                {
                    Rotation = CellPropertiesValidator.CellRotationValidate((int)rotation);
                }

                if (back != null)
                {
                    BackgroundColor = back;
                }

                if (fontColor != null)
                {
                    FontColor = fontColor;
                }

                Height = CellPropertiesValidator.CellHeightValidate(height);

                Width = CellPropertiesValidator.CellWidthValidate(width);


                
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// XCell's constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <param name="weight"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="family"></param>
        /// <param name="rotation"></param>
        /// <param name="back"></param>
        /// <param name="fontColor"></param>
        /// <param name="comment"></param>
        public XCell(int id, int number, string value, int? size, string weight, int? width, int? height,
                     string style, string family, int? rotation, string back, string fontColor, string comment)
        {
            try
            {
                Id = id;
                Number = number;
                Value = value;
                if (size != null)
                {
                    FontSize = CellPropertiesValidator.FontSizeValidate((int)size);
                }
                else
                {
                    FontSize = DefautFontSize;
                }

                if (weight != null)
                {
                    FontWeight = CellPropertiesValidator.FontWeightValidate(weight);
                }

                if (style != null)
                {
                    FontStyle = CellPropertiesValidator.FontStyleValidate(style);
                }

                if (style != null)
                {
                    FontFamily = family;
                }

                if (rotation != null)
                {
                    Rotation = CellPropertiesValidator.CellRotationValidate((int)rotation);
                }

                if (back != null)
                {
                    BackgroundColor = back;
                }

                if (fontColor != null)
                {
                    FontColor = fontColor;
                }

                Height = CellPropertiesValidator.CellHeightValidate(height);

                Width = CellPropertiesValidator.CellWidthValidate(width);

                Comment = comment;


            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty XCell's constructor
        /// </summary>
        public XCell()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }

        }
        
        #endregion

    }
}