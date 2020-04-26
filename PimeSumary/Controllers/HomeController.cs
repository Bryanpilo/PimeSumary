using PimeSumary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimeSumary.Controllers
{
    public class HomeController : Controller
    {
        private PimeSumaryEntities db = new PimeSumaryEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Sumary()
        {
            ViewBag.IdBillingType = new SelectList(db.BillingType, "Id", "TYPE");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}