using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Landau.DB;
using System.Web.Script.Serialization;

namespace Landau.Controllers
{
    public class OperationsController : Controller
    {

        /// <summary>
        /// Получаем все 
        /// </summary>
        /// <returns></returns>
        public string GetAllOrdersForUser()
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    JavaScriptSerializer ordersListSerializer = new JavaScriptSerializer();
                    var query = (from od in db.Projects
                                 join d in db.Documents on od.Id equals d.ProjectId
                                 where d.DocumentType == 2 && d.ViewType == 3
                                 select new
                                     {
                                         Id = od.Id,
                                         Name = d.FileName
                                     }).ToList();
                    return ordersListSerializer.Serialize(query);
                }
                
                
            }
            catch (Exception exception)
            {
                return "";
            }
        }
	}
}