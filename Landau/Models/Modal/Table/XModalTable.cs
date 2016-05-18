using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal.Table
{
    public class XModalTable
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public XModalBody Body { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Empty contructor of ModalTable
        /// </summary>
        public XModalTable()
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
        public XModalTable(int id, Position position, string description, string name, XModalBody body)
        {
            try
            {
                Id = id;
                Position = position;
                Description = description;
                Name = name;
                Body = body;
            }
            catch (Exception exception)
            {

            }
        }


    }
}