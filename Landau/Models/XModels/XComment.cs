using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.XModels
{
    public class XComment
    {
        public int Id;

        public string Message;

        public XComment(int id, string message)
        {
            try
            {
                Id = id;
                Message = message;
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Empty constructor, sets default parameters
        /// </summary>
        public XComment()
        {
            try
            {
                Id = 0;
                Message = "";
            }
            catch (Exception exception)
            {

            }
        }
    }
}