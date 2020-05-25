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
    public class PartyMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PartyMsts
        public ActionResult Index()
        {
            return View(db.PartyMsts.ToList());
        }

        // GET: PartyMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyMst partyMst = db.PartyMsts.Find(id);
            if (partyMst == null)
            {
                return HttpNotFound();
            }
            return View(partyMst);
        }

        // GET: PartyMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartyMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,MobileNumber")] PartyMst partyMst)
        {
            if (ModelState.IsValid)
            {
                db.PartyMsts.Add(partyMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partyMst);
        }

        // GET: PartyMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyMst partyMst = db.PartyMsts.Find(id);
            if (partyMst == null)
            {
                return HttpNotFound();
            }
            return View(partyMst);
        }

        // POST: PartyMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,MobileNumber")] PartyMst partyMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partyMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partyMst);
        }

        // GET: PartyMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyMst partyMst = db.PartyMsts.Find(id);
            if (partyMst == null)
            {
                return HttpNotFound();
            }
            return View(partyMst);
        }

        // POST: PartyMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartyMst partyMst = db.PartyMsts.Find(id);
            db.PartyMsts.Remove(partyMst);
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
