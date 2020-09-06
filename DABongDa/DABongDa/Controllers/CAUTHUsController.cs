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
    public class CAUTHUsController : Controller
    {
        private QL_bongdaEntities2 db = new QL_bongdaEntities2();

        // GET: CAUTHUs
        public ActionResult Index()
        {
            return View(db.CAUTHU.ToList());
        }

        // GET: CAUTHUs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUTHU cAUTHU = db.CAUTHU.Find(id);
            if (cAUTHU == null)
            {
                return HttpNotFound();
            }
            return View(cAUTHU);
        }

        // GET: CAUTHUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CAUTHUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCT,HoTen,SoAo,ChieuCao,CanNang,ViTri,NgaySinh,MaDB,SoBanThang,ThoiGianRaSan,SoTranThamGia,TieuSu")] CAUTHU cAUTHU)
        {
            if (ModelState.IsValid)
            {
                db.CAUTHU.Add(cAUTHU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cAUTHU);
        }

        // GET: CAUTHUs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUTHU cAUTHU = db.CAUTHU.Find(id);
            if (cAUTHU == null)
            {
                return HttpNotFound();
            }
            return View(cAUTHU);
        }

        // POST: CAUTHUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCT,HoTen,SoAo,ChieuCao,CanNang,ViTri,NgaySinh,MaDB,SoBanThang,ThoiGianRaSan,SoTranThamGia,TieuSu")] CAUTHU cAUTHU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAUTHU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cAUTHU);
        }

        // GET: CAUTHUs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUTHU cAUTHU = db.CAUTHU.Find(id);
            if (cAUTHU == null)
            {
                return HttpNotFound();
            }
            return View(cAUTHU);
        }

        // POST: CAUTHUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CAUTHU cAUTHU = db.CAUTHU.Find(id);
            db.CAUTHU.Remove(cAUTHU);
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
