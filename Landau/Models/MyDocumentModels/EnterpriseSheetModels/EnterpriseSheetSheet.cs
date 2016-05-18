using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.MyDocumentModels.EnterpriseSheetModels
{
    public class EnterpriseSheetSheet
    {
        public int id { get; set; }
        public string name { get; set; }
       


        #region constructors
        /// <summary>
        /// Constructor for ES sheet model
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public EnterpriseSheetSheet(int id, string name)
        {
            try
            {
                this.id = id;
                this.name = name;
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty constructor for ES sheet model
        /// </summary>
        public EnterpriseSheetSheet()
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