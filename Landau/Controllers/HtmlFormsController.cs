using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Landau.DB;

namespace Landau.Controllers
{
    public class HtmlFormsController : Controller
    {
        //
        // GET: /HtmlForms/
        [HttpPost]
        public string GetHtmlForm(string id)
        {

            int formId = Int32.Parse(id);

            using (LandauEntities db = new LandauEntities())
            {
                return (from f in db.HtmlForms where f.Id == formId select f).ToList().LastOrDefault().Html;
            }

        }
	}
}