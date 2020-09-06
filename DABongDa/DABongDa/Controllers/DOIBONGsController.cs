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
    public class DOIBONGsController : Controller
    {
        private QL_bongdaEntities2 db = new QL_bongdaEntities2();

        // GET: DOIBONGs
        public ActionResult Index()
        {
            var dOIBONG = db.DOIBONG.Include(d => d.BANGTONGKET).Include(d => d.CAUTHU).Include(d => d.SANVANDONG);
            return View(dOIBONG.ToList());
        }

        // GET: DOIBONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOIBONG dOIBONG = db.DOIBONG.Find(id);
            if (dOIBONG == null)
            {
                return HttpNotFound();
            }
            return View(dOIBONG);
        }

        // GET: DOIBONGs/Create
        public ActionResult Create()
        {
            ViewBag.MaDB = new SelectList(db.BANGTONGKET, "DoiBong", "DoiBong");
            ViewBag.MaCT = new SelectList(db.CAUTHU, "MaCT", "HoTen");
            ViewBag.MaSVD = new SelectList(db.SANVANDONG, "MaSVD", "TenSVD");
            return View();
        }

        // POST: DOIBONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDB,TenDB,TenHLV,DiaChi,TieuSu,SoCauThu,MaSVD,MaCT")] DOIBONG dOIBONG)
        {
            if (ModelState.IsValid)
            {
                db.DOIBONG.Add(dOIBONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDB = new SelectList(db.BANGTONGKET, "DoiBong", "DoiBong", dOIBONG.MaDB);
            ViewBag.MaCT = new SelectList(db.CAUTHU, "MaCT", "HoTen", dOIBONG.MaCT);
            ViewBag.MaSVD = new SelectList(db.SANVANDONG, "MaSVD", "TenSVD", dOIBONG.MaSVD);
            return View(dOIBONG);
        }

        // GET: DOIBONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOIBONG dOIBONG = db.DOIBONG.Find(id);
            if (dOIBONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDB = new SelectList(db.BANGTONGKET, "DoiBong", "DoiBong", dOIBONG.MaDB);
            ViewBag.MaCT = new SelectList(db.CAUTHU, "MaCT", "HoTen", dOIBONG.MaCT);
            ViewBag.MaSVD = new SelectList(db.SANVANDONG, "MaSVD", "TenSVD", dOIBONG.MaSVD);
            return View(dOIBONG);
        }

        // POST: DOIBONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDB,TenDB,TenHLV,DiaChi,TieuSu,SoCauThu,MaSVD,MaCT")] DOIBONG dOIBONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOIBONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDB = new SelectList(db.BANGTONGKET, "DoiBong", "DoiBong", dOIBONG.MaDB);
            ViewBag.MaCT = new SelectList(db.CAUTHU, "MaCT", "HoTen", dOIBONG.MaCT);
            ViewBag.MaSVD = new SelectList(db.SANVANDONG, "MaSVD", "TenSVD", dOIBONG.MaSVD);
            return View(dOIBONG);
        }

        // GET: DOIBONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOIBONG dOIBONG = db.DOIBONG.Find(id);
            if (dOIBONG == null)
            {
                return HttpNotFound();
            }
            return View(dOIBONG);
        }

        // POST: DOIBONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DOIBONG dOIBONG = db.DOIBONG.Find(id);
            db.DOIBONG.Remove(dOIBONG);
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
