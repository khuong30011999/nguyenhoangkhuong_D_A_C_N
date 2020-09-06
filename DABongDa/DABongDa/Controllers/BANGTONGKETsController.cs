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
    public class BANGTONGKETsController : Controller
    {
        private QL_bongdaEntities2 db = new QL_bongdaEntities2();

        // GET: BANGTONGKETs
        public ActionResult Index()
        {
            var bANGTONGKET = db.BANGTONGKET.Include(b => b.DOIBONG1);
            return View(bANGTONGKET.ToList());
        }

        // GET: BANGTONGKETs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGTONGKET bANGTONGKET = db.BANGTONGKET.Find(id);
            if (bANGTONGKET == null)
            {
                return HttpNotFound();
            }
            return View(bANGTONGKET);
        }

        // GET: BANGTONGKETs/Create
        public ActionResult Create()
        {
            ViewBag.DoiBong = new SelectList(db.DOIBONG, "MaDB", "TenDB");
            return View();
        }

        // POST: BANGTONGKETs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoiBong,SoTran,T,B,H,HS,TV,TD,Diem")] BANGTONGKET bANGTONGKET)
        {
            if (ModelState.IsValid)
            {
                db.BANGTONGKET.Add(bANGTONGKET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoiBong = new SelectList(db.DOIBONG, "MaDB", "TenDB", bANGTONGKET.DoiBong);
            return View(bANGTONGKET);
        }

        // GET: BANGTONGKETs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGTONGKET bANGTONGKET = db.BANGTONGKET.Find(id);
            if (bANGTONGKET == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoiBong = new SelectList(db.DOIBONG, "MaDB", "TenDB", bANGTONGKET.DoiBong);
            return View(bANGTONGKET);
        }

        // POST: BANGTONGKETs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoiBong,SoTran,T,B,H,HS,TV,TD,Diem")] BANGTONGKET bANGTONGKET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANGTONGKET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoiBong = new SelectList(db.DOIBONG, "MaDB", "TenDB", bANGTONGKET.DoiBong);
            return View(bANGTONGKET);
        }

        // GET: BANGTONGKETs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGTONGKET bANGTONGKET = db.BANGTONGKET.Find(id);
            if (bANGTONGKET == null)
            {
                return HttpNotFound();
            }
            return View(bANGTONGKET);
        }

        // POST: BANGTONGKETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BANGTONGKET bANGTONGKET = db.BANGTONGKET.Find(id);
            db.BANGTONGKET.Remove(bANGTONGKET);
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
