using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsoleSandbox.Models.Modal.Table.Json;

namespace Landau.Models.Modal.Table
{
    public class ModalCellJson
    {
        public int id { get; set; }
        public int number { get; set; }
        public string value { get; set; }
        public int cellId { get; set; }
        public ModalCellStyleJson style { get; set; }

        public ModalCellJson(int id, int number, string value, int cellId, ModalCellStyleJson style)
        {
            this.id = id;
            this.number = number;
            this.value = value;
            this.cellId = cellId;
            this.style = style;
        }

        public ModalCellJson(int id, int number, string value, ModalCellStyleJson style)
        {
            this.id = id;
            this.number = number;
            this.value = value;
            this.style = style;
        }
    }
}