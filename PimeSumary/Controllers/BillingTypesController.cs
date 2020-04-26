using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PimeSumary.Models;

namespace PimeSumary.Controllers
{
    public class BillingTypesController : Controller
    {
        private PimeSumaryEntities db = new PimeSumaryEntities();

        // GET: BillingTypes
        public ActionResult Index()
        {
            return View(db.BillingType.ToList());
        }

        // GET: BillingTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingType billingType = db.BillingType.Find(id);
            if (billingType == null)
            {
                return HttpNotFound();
            }
            return View(billingType);
        }

        // GET: BillingTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillingTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TYPE")] BillingType billingType)
        {
            if (ModelState.IsValid)
            {
                db.BillingType.Add(billingType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billingType);
        }

        // GET: BillingTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingType billingType = db.BillingType.Find(id);
            if (billingType == null)
            {
                return HttpNotFound();
            }
            return View(billingType);
        }

        // POST: BillingTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TYPE")] BillingType billingType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billingType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billingType);
        }

        // GET: BillingTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingType billingType = db.BillingType.Find(id);
            if (billingType == null)
            {
                return HttpNotFound();
            }
            return View(billingType);
        }

        // POST: BillingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillingType billingType = db.BillingType.Find(id);
            db.BillingType.Remove(billingType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
