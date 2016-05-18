﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landau.Controllers
{
    public class HomeController : Controller
    {
   /// <summary>
   /// Главная страница
   /// </summary>
   /// <returns></returns>
        public ActionResult Index()
        {
            HttpRuntime.UnloadAppDomain();   
            return RedirectToAction("Login","Account");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}