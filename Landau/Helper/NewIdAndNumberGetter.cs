using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.DB;

namespace Landau.Helper
{
    public class NewIdAndNumberGetter
    {
        LandauEntities db;

        #region methods
        public int GetNewCellId()
        {
            try
            {
                return (from cell in db.Cell where (1 == 1) select cell).ToList().LastOrDefault().Id + 1;
            }
            catch(Exception exception)
            {
                return 0;
            }
        }

        public int GetNewRowId()
        {
            try
            {
                return (from row in db.Row where (1 == 1) select row).ToList().LastOrDefault().Id + 1;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public int GetNewSheetId()
        {
            try
            {
                return (from sheet in db.Sheet where (1 == 1) select sheet).ToList().LastOrDefault().Id + 1;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public int GetNewStyleId()
        {
            try
            {
                return (from st in db.CellStyles where 1 == 1 select st).ToList().LastOrDefault().Id + 1;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public int GetNewCommentId()
        {
            try
            {
                return (from com in db.CellComments where 1 == 1 select com).ToList().LastOrDefault().Id + 1;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public int GetNewBodyId()
        {
            try
            {
                return (from b in db.Body where 1 == 1 select b).ToList().LastOrDefault().Id + 1;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }



        
        #endregion

        public NewIdAndNumberGetter()
        {
            try
            {
                db = new LandauEntities();
            }
            catch (Exception exception)
            {

            }
        }
       
    }
}