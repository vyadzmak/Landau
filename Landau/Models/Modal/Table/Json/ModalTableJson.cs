using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class ModalTableJson
    {
        public int id;

        public int typeId;

        public Position position { get; set; }
        public string description { get; set; }

        public List<ModalRowJson> rows { get; set; }

        public ModalTableJson(int id, List<ModalRowJson> rows, string description, Position position)
        {
            try
            {
                this.position = position;
                this.id = id;
                this.typeId = 4;
                this.rows = rows;
                this.description = description;
            }
            catch (Exception exception)
            {

            }
        }
    }
}