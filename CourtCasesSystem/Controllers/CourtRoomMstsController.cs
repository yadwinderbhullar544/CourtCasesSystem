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
    public class CourtRoomMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourtRoomMsts
        public ActionResult Index()
        {
            return View(db.CourtRoomMsts.ToList());
        }

        // GET: CourtRoomMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRoomMst courtRoomMst = db.CourtRoomMsts.Find(id);
            if (courtRoomMst == null)
            {
                return HttpNotFound();
            }
            return View(courtRoomMst);
        }

        // GET: CourtRoomMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtRoomMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoomNumber")] CourtRoomMst courtRoomMst)
        {
            if (ModelState.IsValid)
            {
                db.CourtRoomMsts.Add(courtRoomMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courtRoomMst);
        }

        // GET: CourtRoomMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRoomMst courtRoomMst = db.CourtRoomMsts.Find(id);
            if (courtRoomMst == null)
            {
                return HttpNotFound();
            }
            return View(courtRoomMst);
        }

        // POST: CourtRoomMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoomNumber")] CourtRoomMst courtRoomMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtRoomMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtRoomMst);
        }

        // GET: CourtRoomMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRoomMst courtRoomMst = db.CourtRoomMsts.Find(id);
            if (courtRoomMst == null)
            {
                return HttpNotFound();
            }
            return View(courtRoomMst);
        }

        // POST: CourtRoomMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtRoomMst courtRoomMst = db.CourtRoomMsts.Find(id);
            db.CourtRoomMsts.Remove(courtRoomMst);
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
