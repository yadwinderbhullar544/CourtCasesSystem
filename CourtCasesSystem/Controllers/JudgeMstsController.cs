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
    public class JudgeMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JudgeMsts
        public ActionResult Index()
        {
            return View(db.JudgeMsts.ToList());
        }

        // GET: JudgeMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeMst judgeMst = db.JudgeMsts.Find(id);
            if (judgeMst == null)
            {
                return HttpNotFound();
            }
            return View(judgeMst);
        }

        // GET: JudgeMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JudgeMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Speciality,Age")] JudgeMst judgeMst)
        {
            if (ModelState.IsValid)
            {
                db.JudgeMsts.Add(judgeMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(judgeMst);
        }

        // GET: JudgeMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeMst judgeMst = db.JudgeMsts.Find(id);
            if (judgeMst == null)
            {
                return HttpNotFound();
            }
            return View(judgeMst);
        }

        // POST: JudgeMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Speciality,Age")] JudgeMst judgeMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(judgeMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(judgeMst);
        }

        // GET: JudgeMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeMst judgeMst = db.JudgeMsts.Find(id);
            if (judgeMst == null)
            {
                return HttpNotFound();
            }
            return View(judgeMst);
        }

        // POST: JudgeMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JudgeMst judgeMst = db.JudgeMsts.Find(id);
            db.JudgeMsts.Remove(judgeMst);
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
