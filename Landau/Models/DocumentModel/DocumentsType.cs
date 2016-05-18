using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landau.Models.DocumentModel
{
    public class DocumentTypeListElement
    {

        public DocumentTypeListElement(int id, string title)
        {
            try
            {
                this.Id = id;
                this.Title = title;
            }
            catch (Exception)
            {

            }
        }

        public DocumentTypeListElement()
        {
        }

        public int Id { get; set; }
       
        public string Title { get; set; }

    }
}