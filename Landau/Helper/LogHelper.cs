using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.DB;

namespace Landau.Helper
{
    public static class LogHelper
    {
        public static void AddLog(string message)
        {
            try
            {
                LogTable table = new LogTable();
                table.DateTime = DateTime.Now;
                table.Message = message;

                using (LandauEntities entities = new LandauEntities())
                {
                    entities.LogTable.Add(table);
                    entities.SaveChanges();
                }

            }
            catch (Exception exception)
            {

            }
        }
    }
}