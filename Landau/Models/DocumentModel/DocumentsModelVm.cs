using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.DocumentModel
{
    public class DocumentModelVm
    {
        public int Id { get; set; }
        public string SettingsName { get; set; }
        public string SettingsValue { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public string DocumentType { get; set; }
        public string DataUpload { get; set; }
        public int DocumentTypeInt { get; set; }
        public string Image { get; set; }
        public string ServerPath { get; set; }
        public Guid FileNameGuid { get; set; }
        public string User { get; set; }
        public int UserInt { get; set; }
        public string Description { get; set; }

        public string State { get; set; }
        public int StateComments { get; set; }
        public int ProjectId { get; set; }


    }
}