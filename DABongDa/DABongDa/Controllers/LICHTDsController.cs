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
    public class LICHTDsController : Controller
    {
        private QL_bongdaEntities2 db = new QL_bongdaEntities2();

        // GET: LICHTDs
        public ActionResult Index()
        {
            var lICHTD = db.LICHTD.Include(l => l.DOIBONG).Include(l => l.DOIBONG1);
            return View(LICHTD.ToList());
        }

        // GET: LICHTDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICHTD lICHTD = db.LICHTD.Find(id);
            if (lICHTD == null)
            {
                return HttpNotFound();
            }
            return View(lICHTD);
        }

        // GET: LICHTDs/Create
        public ActionResult Create()
        {
            ViewBag.MaDB1 = new SelectList(db.DOIBONG, "MaDB", "TenDB");
            ViewBag.MaDB2 = new SelectList(db.DOIBONG, "MaDB", "TenDB");
            return View();
        }

        // POST: LICHTDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDB1,MaDB2,ThoiGian,MaSVD,TenTrongTai,GiamSatTrongTai,NgayThiDau,TySo,Kenh,SoLuongKG,SuCo")] LICHTD lICHTD)
        {
            if (ModelState.IsValid)
            {
                db.LICHTD.Add(lICHTD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDB1 = new SelectList(db.DOIBONG, "MaDB", "TenDB", lICHTD.MaDB1);
            ViewBag.MaDB2 = new SelectList(db.DOIBONG, "MaDB", "TenDB", lICHTD.MaDB2);
            return View(lICHTD);
        }

        // GET: LICHTDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICHTD lICHTD = db.LICHTD.Find(id);
            if (lICHTD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDB1 = new SelectList(db.DOIBONG, "MaDB", "TenDB", lICHTD.MaDB1);
            ViewBag.MaDB2 = new SelectList(db.DOIBONG, "MaDB", "TenDB", lICHTD.MaDB2);
            return View(lICHTD);
        }

        // POST: LICHTDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDB1,MaDB2,ThoiGian,MaSVD,TenTrongTai,GiamSatTrongTai,NgayThiDau,TySo,Kenh,SoLuongKG,SuCo")] LICHTD lICHTD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lICHTD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDB1 = new SelectList(db.DOIBONG, "MaDB", "TenDB", lICHTD.MaDB1);
            ViewBag.MaDB2 = new SelectList(db.DOIBONG, "MaDB", "TenDB", lICHTD.MaDB2);
            return View(lICHTD);
        }

        // GET: LICHTDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICHTD lICHTD = db.LICHTD.Find(id);
            if (lICHTD == null)
            {
                return HttpNotFound();
            }
            return View(lICHTD);
        }

        // POST: LICHTDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LICHTD lICHTD = db.LICHTD.Find(id);
            db.LICHTD.Remove(lICHTD);
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
