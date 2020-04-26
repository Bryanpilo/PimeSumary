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
    public class SumaryPimesController : Controller
    {
        private PimeSumaryEntities db = new PimeSumaryEntities();

        // GET: SumaryPimes
        public ActionResult Index()
        {
            return View(db.SumaryPime.ToList());
        }

        // GET: SumaryPimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryPime sumaryPime = db.SumaryPime.Find(id);
            if (sumaryPime == null)
            {
                return HttpNotFound();
            }
            return View(sumaryPime);
        }

        // GET: SumaryPimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SumaryPimes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,Address")] SumaryPime sumaryPime)
        {
            if (ModelState.IsValid)
            {
                db.SumaryPime.Add(sumaryPime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sumaryPime);
        }

        // GET: SumaryPimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryPime sumaryPime = db.SumaryPime.Find(id);
            if (sumaryPime == null)
            {
                return HttpNotFound();
            }
            return View(sumaryPime);
        }

        // POST: SumaryPimes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,Address")] SumaryPime sumaryPime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sumaryPime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sumaryPime);
        }

        // GET: SumaryPimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryPime sumaryPime = db.SumaryPime.Find(id);
            if (sumaryPime == null)
            {
                return HttpNotFound();
            }
            return View(sumaryPime);
        }

        // POST: SumaryPimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SumaryPime sumaryPime = db.SumaryPime.Find(id);
            db.SumaryPime.Remove(sumaryPime);
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
