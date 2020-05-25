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
    public class CaseMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CaseMsts
        public ActionResult Index()
        {
            var caseMsts = db.CaseMsts.Include(c => c.JudgeMst).Include(c => c.LawyerMst).Include(c => c.PartyMst);
            return View(caseMsts.ToList());
        }

        // GET: CaseMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMst caseMst = db.CaseMsts.Find(id);
            if (caseMst == null)
            {
                return HttpNotFound();
            }
            return View(caseMst);
        }

        // GET: CaseMsts/Create
        public ActionResult Create()
        {
            ViewBag.JudgeMstID = new SelectList(db.JudgeMsts, "ID", "Name");
            ViewBag.LawyerMstID = new SelectList(db.LawyerMsts, "ID", "Name");
            ViewBag.PartyMstID = new SelectList(db.PartyMsts, "ID", "Name");
            return View();
        }

        // POST: CaseMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JudgeMstID,LawyerMstID,PartyMstID,Name,Type")] CaseMst caseMst)
        {
            if (ModelState.IsValid)
            {
                db.CaseMsts.Add(caseMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JudgeMstID = new SelectList(db.JudgeMsts, "ID", "Name", caseMst.JudgeMstID);
            ViewBag.LawyerMstID = new SelectList(db.LawyerMsts, "ID", "Name", caseMst.LawyerMstID);
            ViewBag.PartyMstID = new SelectList(db.PartyMsts, "ID", "Name", caseMst.PartyMstID);
            return View(caseMst);
        }

        // GET: CaseMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMst caseMst = db.CaseMsts.Find(id);
            if (caseMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.JudgeMstID = new SelectList(db.JudgeMsts, "ID", "Name", caseMst.JudgeMstID);
            ViewBag.LawyerMstID = new SelectList(db.LawyerMsts, "ID", "Name", caseMst.LawyerMstID);
            ViewBag.PartyMstID = new SelectList(db.PartyMsts, "ID", "Name", caseMst.PartyMstID);
            return View(caseMst);
        }

        // POST: CaseMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JudgeMstID,LawyerMstID,PartyMstID,Name,Type")] CaseMst caseMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JudgeMstID = new SelectList(db.JudgeMsts, "ID", "Name", caseMst.JudgeMstID);
            ViewBag.LawyerMstID = new SelectList(db.LawyerMsts, "ID", "Name", caseMst.LawyerMstID);
            ViewBag.PartyMstID = new SelectList(db.PartyMsts, "ID", "Name", caseMst.PartyMstID);
            return View(caseMst);
        }

        // GET: CaseMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMst caseMst = db.CaseMsts.Find(id);
            if (caseMst == null)
            {
                return HttpNotFound();
            }
            return View(caseMst);
        }

        // POST: CaseMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseMst caseMst = db.CaseMsts.Find(id);
            db.CaseMsts.Remove(caseMst);
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
