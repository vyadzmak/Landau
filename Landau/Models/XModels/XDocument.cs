using System;
using System.Collections.Generic;

namespace Landau.Models.XModels
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

        public Guid Guid { get; set; }

        public int ProjectId { get; set; }

        public string FileName { get; set; }

        public int DocumentType { get; set; }

        public int State { get; set; }

        public string ServerPath { get; set; }

        public string Description { get; set; }

        public long FileSize {get; set;}

        public DateTime UploadDate {get; set;}

        public string CRC {get; set;}

        public int UserId {get; set;}

        public int ViewType {get; set;}
        public int Version { get; set; }

        /// <summary>
        /// Document's body 
        /// </summary>
        public List<XSheet> Sheets { get; set; }

        public List<XFloating> Floatings { get; set; }

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
                Sheets = sheets;
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
        public XDocument(int id, string name, int version)
        {
            try
            {
                Id = id;
                Name = name;
                Version = version;
                Sheets = new List<XSheet>();
                Floatings = new List<XFloating>();
            }
            catch (Exception exception)
            {

            }
        }

       
        #endregion
    }
}