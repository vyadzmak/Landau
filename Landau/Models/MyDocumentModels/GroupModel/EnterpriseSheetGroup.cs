using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.MyDocumentModels
{
    public class EnterpriseSheetGroup
    {
        public int sheet { get; set; }
        public string name { get; set; }
        public string ftype { get; set; }
        public string json { get; set; }

        #region constructors
        /// <summary>
        /// Empty enterprise sheet group constructor
        /// </summary>
        public EnterpriseSheetGroup()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Enterprise sheet group constructor
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <param name="ftype"></param>
        /// <param name="json"></param>
        public EnterpriseSheetGroup(int sheet, string name, string ftype, string json)
        {
            try
            {
                this.sheet = sheet;
                this.name = name;
                this.ftype = ftype;
                this.json = json;
            }
            catch (Exception exception)
            {

            }
        }

        #endregion



    }
}