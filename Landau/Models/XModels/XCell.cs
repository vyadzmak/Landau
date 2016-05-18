using System;
using System.Drawing;
using Landau.Helper;

namespace Landau.Models.XModels
{
    public class XCell
    {
        #region fields
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Number { get; set; }
        public string Value { get; set; }
        public bool IsButton { get; set; }
        public XStyle Style { get; set; }
        public XComment Comment { get; set; }
        public XFormat Format { get; set; }
        public string Editable { get; set; }

        public bool IsFormula { get; set; }
        public bool IsFitting = false;

        #endregion

    

        #region constructors
        /// <summary>
        /// XCell's constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public XCell(int id, int number, string value, XStyle style, 
            XComment comment, XFormat format, string editable, bool isFormula)
        {
            try
            {
                Id = id;
                Number = number;
                Value = value;
                Style = style;
                Comment = comment;
                Format = new XFormat("","");
                IsFormula = isFormula;
                Editable = editable;
            }
            catch (Exception exception)
            {

            }
        }


        /// <summary>
        /// XCell's constructor
        /// </summary>
        public XCell(int id, int number, string value, string editable, bool isFormula)
        {
            try
            {
                NewIdAndNumberGetter getter = new NewIdAndNumberGetter();
                Id = id;
                Number = number;
                Value = value;
                Style = new XStyle(getter.GetNewStyleId(), 12, 
                    "normal", null, null, "normal",
                     null, "#ffffff", "#000000", 0, null, null, "", "", "");
                Comment = new XComment(getter.GetNewCommentId(), null);
                Format = new XFormat(null, null);
                IsFormula = isFormula;
                IsButton = false;
                Editable = editable;
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

        /// <summary>
        /// XCell's constructor with fitting flag
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="comment"></param>
        /// <param name="format"></param>
        /// <param name="calculation"></param>
        /// <param name="isFitting"></param>
        public XCell(int id, int number, string value, XStyle style, XComment comment, 
            XFormat format, bool isFitting, bool isFormula)
        {
            try
            {
                Id = id;
                Number = number;
                Value = value;
                Style = style;
                Comment = comment;
                Format = new XFormat("", "");
                IsFormula = isFormula;
                IsFitting = isFitting;
            }
            catch (Exception exception)
            {

            }
        }
        #endregion

    }
}