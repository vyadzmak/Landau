using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class ModalRowJson
    {
        public int id { get; set; }

        public int number { get; set; }

        public List<ModalCellJson> cells { get; set; }

        public ModalRowJson(int id, int number, List<ModalCellJson> cells)
        {
            this.id = id;
            this.number = number;
            this.cells = cells;
        }
    }
}