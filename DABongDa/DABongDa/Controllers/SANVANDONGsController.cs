using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DABongDa.Models;

namespace DABongDa.Controllers
{
    public class SANVANDONGsController : Controller
    {
        private QL_bongdaEntities2 db = new QL_bongdaEntities2();

        // GET: SANVANDONGs
        public ActionResult Index()
        {
            return View(db.SANVANDONG.ToList());
        }

        // GET: SANVANDONGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANVANDONG sANVANDONG = db.SANVANDONG.Find(id);
            if (sANVANDONG == null)
            {
                return HttpNotFound();
            }
            return View(sANVANDONG);
        }

        // GET: SANVANDONGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SANVANDONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSVD,TenSVD,DiaChi,SuaChua")] SANVANDONG sANVANDONG)
        {
            if (ModelState.IsValid)
            {
                db.SANVANDONG.Add(sANVANDONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sANVANDONG);
        }

        // GET: SANVANDONGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANVANDONG sANVANDONG = db.SANVANDONG.Find(id);
            if (sANVANDONG == null)
            {
                return HttpNotFound();
            }
            return View(sANVANDONG);
        }

        // POST: SANVANDONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSVD,TenSVD,DiaChi,SuaChua")] SANVANDONG sANVANDONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANVANDONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sANVANDONG);
        }

        // GET: SANVANDONGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANVANDONG sANVANDONG = db.SANVANDONG.Find(id);
            if (sANVANDONG == null)
            {
                return HttpNotFound();
            }
            return View(sANVANDONG);
        }

        // POST: SANVANDONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANVANDONG sANVANDONG = db.SANVANDONG.Find(id);
            db.SANVANDONG.Remove(sANVANDONG);
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
