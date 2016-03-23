using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using MvcAppRest.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MvcAppRest.Controllers
{
    [HandleError]
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
         
        private ActionResult Rest(object datos)
        {
            ActionResult resultado = null;
            //if (Request.ContentType == "application/json")
                resultado = Json(datos, JsonRequestBehavior.AllowGet);

            return resultado;
        } 

    }
}
