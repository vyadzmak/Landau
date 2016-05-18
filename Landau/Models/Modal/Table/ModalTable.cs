using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class ModalTable
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public ModalBody Body { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Empty contructor of ModalTable
        /// </summary>
        public ModalTable()
        {
            try
            {

            }
            catch (Exception exception)
            {
                
            }
        }

        /// <summary>
        /// Empty contructor of ModalTable
        /// </summary>
        public ModalTable(Position position, string description)
        {
            try
            {
                Position = position;
                Description = description;
            }
            catch (Exception exception)
            {

            }
        }


    }
}