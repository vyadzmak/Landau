using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landau.DB;
//using LandauSmartService.DB;

namespace Landau.Helper
{
    public static class Log
    {
        /// <summary>
        /// пишем в лог
        /// </summary>
        /// <param name="message"></param>
        public static void AddLog(string message)
        {
            try
            {
                LogTable table = new LogTable();
                table.Message = message;
                table.DateTime = DateTime.Now;

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
