using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.CommentModel
{
    public class CommentModelVm
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string GetUser { get;set; }
        public int GetUserId { get; set; }
        public string SendUser { get; set; }
        public int SendUserId { get; set; }
        public string Data { get; set; }
        public string Date { get; set; }
        public int Role { get; set; }
        public int State { get; set; }


    }
}