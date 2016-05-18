using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.MyDocumentModels.EnterpriseSheetModels
{
    /// <summary>
    /// Class-mediator between json string and model in view
    /// </summary>
    public class JsonModel
    {
        /// <summary>
        /// Keeps the json string for sending it to view
        /// </summary>
        public string Value { get; set; }
    }
}