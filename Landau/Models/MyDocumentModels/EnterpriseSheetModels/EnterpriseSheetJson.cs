using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.MyDocumentModels.EnterpriseSheetModels
{
    public class EnterpriseSheetJson
    {
        #region fields
        /// <summary>
        /// Useful data
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// Font weight
        /// </summary>
        public string fw { get; set; }

        /// <summary>
        /// Underlined
        /// </summary>
        public string u { get; set; }

        /// <summary>
        /// Font style
        /// </summary>
        public string fs { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public int fz { get; set; }

        /// <summary>
        /// Family
        /// </summary>
        public string ff { get; set; }

        /// <summary>
        /// If data is formula
        /// </summary>
        public bool cal { get; set; }

        /// <summary>
        /// Overlined
        /// </summary>
        public string o { get; set; }

        /// <summary>
        /// Line-through
        /// </summary>
        public string s { get; set; }

        /// <summary>
        /// Background color
        /// </summary>
        public string bgc { get; set; }

        /// <summary>
        /// Font color
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// Cell height
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Cell width
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// Comment, pinned to cell
        /// </summary>
        public string comment { get; set; }

        /// <summary>
        /// Data format
        /// </summary>
        public string fm { get; set; }

        /// <summary>
        /// Template
        /// </summary>
        public string dfm { get; set; }

        /// <summary>
        /// Indent
        /// </summary>
        public string ti { get; set; }

        /// <summary>
        /// Align
        /// </summary>
        public string ta { get; set; }

        public string dsd { get; set; }

        /// <summary>
        /// Vertical align
        /// </summary>
       // public string va { get; set; }

        /// <summary>
        /// For creating DOM element "button"
        /// </summary>
       // public string it { get; set; }


        /// <summary>
        /// Provides creating DOM element with assigned style
        /// </summary>
     //   public string btnStyle { get; set; }

        /// <summary>
        /// Binds created DOM element with assigned function
        /// </summary>
        public string onCellMouseMoveFn { get; set; }
        #endregion

        #region constructors
        /// <summary>
        /// Empty constructor for "json" field
        /// </summary>
        public EnterpriseSheetJson()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Contructor with filling of "json" field
        /// </summary>
        public EnterpriseSheetJson(string data, string fw, string u, string fs, int fz, string ff,
            bool cal, string o, string s, string bgc, string color, int height, int width,
            string comment, string fm, string dfm, string ti, string ta, string dsd)
        {
            try
            {
                this.data = data;
                this.fw = fw;
                this.u = u;
                this.fs = fs;
                this.fz = fz;
                this.ff = ff;
                this.cal = cal;
                this.o = o;
                this.s = s;
                this.bgc = bgc;
                this.color = color;
                this.height = height;
                this.width = width;
                this.comment = comment;
                this.fm = fm;
                this.dfm = dfm;
                this.ti = ti;
                this.ta = ta;
                this.dsd = dsd;
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Constructor for "json" field only of fitting cells
        /// </summary>
        /// <param name="width"></param>
        public EnterpriseSheetJson(int width)
        {
            try
            {
                this.width = width;
            }
            catch (Exception exception)
            {
                
            }
        }
        #endregion
    }
}