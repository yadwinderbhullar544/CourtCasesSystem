using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourtCasesSystem.Models;

namespace CourtCasesSystem.Controllers
{
    [Authorize]
    public class HearingMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HearingMsts
        public ActionResult Index()
        {
            var hearingMsts = db.HearingMsts.Include(h => h.CaseMst);
            return View(hearingMsts.ToList());
        }

        // GET: HearingMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingMst hearingMst = db.HearingMsts.Find(id);
            if (hearingMst == null)
            {
                return HttpNotFound();
            }
            return View(hearingMst);
        }

        // GET: HearingMsts/Create
        public ActionResult Create()
        {
            ViewBag.CaseMstID = new SelectList(db.CaseMsts, "ID", "Name");
            return View();
        }

        // POST: HearingMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CaseMstID,CurrentDate,NextDate")] HearingMst hearingMst)
        {
            if (ModelState.IsValid)
            {
                db.HearingMsts.Add(hearingMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseMstID = new SelectList(db.CaseMsts, "ID", "Name", hearingMst.CaseMstID);
            return View(hearingMst);
        }

        // GET: HearingMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingMst hearingMst = db.HearingMsts.Find(id);
            if (hearingMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseMstID = new SelectList(db.CaseMsts, "ID", "Name", hearingMst.CaseMstID);
            return View(hearingMst);
        }

        // POST: HearingMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CaseMstID,CurrentDate,NextDate")] HearingMst hearingMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hearingMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseMstID = new SelectList(db.CaseMsts, "ID", "Name", hearingMst.CaseMstID);
            return View(hearingMst);
        }

        // GET: HearingMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingMst hearingMst = db.HearingMsts.Find(id);
            if (hearingMst == null)
            {
                return HttpNotFound();
            }
            return View(hearingMst);
        }

        // POST: HearingMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HearingMst hearingMst = db.HearingMsts.Find(id);
            db.HearingMsts.Remove(hearingMst);
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
