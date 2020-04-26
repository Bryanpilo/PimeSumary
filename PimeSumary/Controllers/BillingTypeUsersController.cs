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
    public class BillingTypeUsersController : Controller
    {
        private PimeSumaryEntities db = new PimeSumaryEntities();

        // GET: BillingTypeUsers
        public ActionResult Index()
        {
            var billingTypeUser = db.BillingTypeUser.Include(b => b.BillingType).Include(b => b.SumaryPime);
            return View(billingTypeUser.ToList());
        }

        // GET: BillingTypeUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingTypeUser billingTypeUser = db.BillingTypeUser.Find(id);
            if (billingTypeUser == null)
            {
                return HttpNotFound();
            }
            return View(billingTypeUser);
        }

        // GET: BillingTypeUsers/Create
        public ActionResult Create()
        {
            ViewBag.IdBillingType = new SelectList(db.BillingType, "Id", "TYPE");
            ViewBag.IdSumaryPime = new SelectList(db.SumaryPime, "Id", "Name");
            return View();
        }

        // POST: BillingTypeUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSumaryPime,IdBillingType")] BillingTypeUser billingTypeUser)
        {
            if (ModelState.IsValid)
            {
                db.BillingTypeUser.Add(billingTypeUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBillingType = new SelectList(db.BillingType, "Id", "TYPE", billingTypeUser.IdBillingType);
            ViewBag.IdSumaryPime = new SelectList(db.SumaryPime, "Id", "Name", billingTypeUser.IdSumaryPime);
            return View(billingTypeUser);
        }

        // GET: BillingTypeUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingTypeUser billingTypeUser = db.BillingTypeUser.Find(id);
            if (billingTypeUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBillingType = new SelectList(db.BillingType, "Id", "TYPE", billingTypeUser.IdBillingType);
            ViewBag.IdSumaryPime = new SelectList(db.SumaryPime, "Id", "Name", billingTypeUser.IdSumaryPime);
            return View(billingTypeUser);
        }

        // POST: BillingTypeUsers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSumaryPime,IdBillingType")] BillingTypeUser billingTypeUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billingTypeUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBillingType = new SelectList(db.BillingType, "Id", "TYPE", billingTypeUser.IdBillingType);
            ViewBag.IdSumaryPime = new SelectList(db.SumaryPime, "Id", "Name", billingTypeUser.IdSumaryPime);
            return View(billingTypeUser);
        }

        // GET: BillingTypeUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingTypeUser billingTypeUser = db.BillingTypeUser.Find(id);
            if (billingTypeUser == null)
            {
                return HttpNotFound();
            }
            return View(billingTypeUser);
        }

        // POST: BillingTypeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillingTypeUser billingTypeUser = db.BillingTypeUser.Find(id);
            db.BillingTypeUser.Remove(billingTypeUser);
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
