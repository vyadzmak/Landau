using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.MyDocumentModels
{
    public class GroupJsonItem
    {
        public int level { get; set; }
        public List<int> span { get; set; }

        public GroupJsonItem(int level, int p1, int p2)
        {
            this.level = level;
            span = new List<int>(2) {p1, p2};
        }
    }
}