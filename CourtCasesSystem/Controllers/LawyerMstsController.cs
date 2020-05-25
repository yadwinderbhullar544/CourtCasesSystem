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
    public class LawyerMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LawyerMsts
        public ActionResult Index()
        {
            return View(db.LawyerMsts.ToList());
        }

        // GET: LawyerMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerMst lawyerMst = db.LawyerMsts.Find(id);
            if (lawyerMst == null)
            {
                return HttpNotFound();
            }
            return View(lawyerMst);
        }

        // GET: LawyerMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LawyerMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Speciality,Age,MobileNumber")] LawyerMst lawyerMst)
        {
            if (ModelState.IsValid)
            {
                db.LawyerMsts.Add(lawyerMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lawyerMst);
        }

        // GET: LawyerMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerMst lawyerMst = db.LawyerMsts.Find(id);
            if (lawyerMst == null)
            {
                return HttpNotFound();
            }
            return View(lawyerMst);
        }

        // POST: LawyerMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Speciality,Age,MobileNumber")] LawyerMst lawyerMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawyerMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lawyerMst);
        }

        // GET: LawyerMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerMst lawyerMst = db.LawyerMsts.Find(id);
            if (lawyerMst == null)
            {
                return HttpNotFound();
            }
            return View(lawyerMst);
        }

        // POST: LawyerMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LawyerMst lawyerMst = db.LawyerMsts.Find(id);
            db.LawyerMsts.Remove(lawyerMst);
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
