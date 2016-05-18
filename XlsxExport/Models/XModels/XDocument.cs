using System;
using System.Collections.Generic;

namespace XlsxExport.Models.XModels
{
    public class XDocument
    {
        /// <summary>
        /// Document's identity number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Document's name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Document's body 
        /// </summary>
        public List<XSheet> Sheets { get; set; }

        #region constructors

        /// <summary>
        /// Empty constructor of XDocument
        /// </summary>
        public XDocument()
        {
            try
            {
                Sheets = new List<XSheet>();
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Construcor of XDocument
        /// </summary>
        /// <param name="sheets"></param>
        public XDocument(List<XSheet> sheets)
        {
            try
            {
                Sheets = new List<XSheet>();
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// Construcor of XDocument
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public XDocument(int id, string name)
        {
            try
            {
                Id = id;
                Name = name;
                Sheets = new List<XSheet>();
            }
            catch (Exception exception)
            {

            }
        }

        public XDocument(int id, string name, List<XSheet> sheets)
        {
            try
            {
                Id = id;
                Name = name;
                Sheets = sheets;
            }
            catch (Exception exception)
            {

            }
        }
        #endregion
    }
}