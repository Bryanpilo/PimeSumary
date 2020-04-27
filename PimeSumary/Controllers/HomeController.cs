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

        // POST: FullSumaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sumary([Bind(Include = "Name,Email,Phone,Address,NameProduct,UnitPrice,IdBillingType,Reference")] FullSumary fullSumary)
        {
            if (ModelState.IsValid)
            {
                SumaryPime sumaryPime = new SumaryPime
                {
                    Name = fullSumary.Name,
                    Email = fullSumary.Email,
                    Phone = fullSumary.Phone,
                    Address = fullSumary.Address
                };

                db.SumaryPime.Add(sumaryPime);
                db.SaveChanges();

                Product product = new Product
                {
                    NameProduct = fullSumary.NameProduct,
                    UnitPrice = fullSumary.UnitPrice,
                    IdSumaryPime = sumaryPime.Id
                };

                db.Product.Add(product);
                db.SaveChanges();

                BillingTypeUser billingTypeUser = new BillingTypeUser
                {
                    IdSumaryPime = sumaryPime.Id,
                    IdBillingType = fullSumary.IdBillingType,
                    Reference = fullSumary.Reference
                };

                db.BillingTypeUser.Add(billingTypeUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBillingType = new SelectList(db.BillingType, "Id", "TYPE");
            return View();
        }

        // GET: Products/Details/5
        public ActionResult SumaryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SumaryPime sumaryPime = db.SumaryPime.Find(id);
            if (sumaryPime == null)
            {
                return HttpNotFound();
            }
            return View(sumaryPime);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}