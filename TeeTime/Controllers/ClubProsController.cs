using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeeTime.Models;

namespace TeeTime.Controllers
{
    public class ClubProsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClubPros
        public ActionResult Index(int golfClubId)
        {
            var viewModel = new GolfClubProsViewModel();
            viewModel.ClubPros = db.ClubProes.Where(cp => cp.GolfClubId == golfClubId).ToList();
            viewModel.Club = db.GolfClubs.FirstOrDefault(gc => gc.GolfClubId == golfClubId);
            return View(viewModel);
        }

        // GET: ClubPros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubPro clubPro = db.ClubProes.Find(id);
            if (clubPro == null)
            {
                return HttpNotFound();
            }
            var viewModel = new GolfClubProViewModel();
            viewModel.ClubPro = clubPro;
            var club = db.GolfClubs.Find(clubPro.GolfClubId);
            viewModel.Club = club;

            return View(viewModel);
        }

        // GET: ClubPros/Create
        public ActionResult Create(int golfClubId)
        {
            var clubPro = new ClubPro();
            clubPro.GolfClubId = golfClubId;

            var viewModel = new GolfClubProViewModel();
            viewModel.ClubPro = clubPro;
            var club = db.GolfClubs.Find(clubPro.GolfClubId);
            viewModel.Club = club;

            return View(viewModel);
        }

        // POST: ClubPros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClubProId,Name,ContactNo,GolfClubId,Email")] ClubPro clubPro)
        {
            if (ModelState.IsValid)
            {
                db.ClubProes.Add(clubPro);
                db.SaveChanges();
                return RedirectToAction("Index", new { golfClubId = clubPro.GolfClubId});
            }

            return View(clubPro);
        }

        // GET: ClubPros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubPro clubPro = db.ClubProes.Find(id);
            if (clubPro == null)
            {
                return HttpNotFound();
            }

            var viewModel = new GolfClubProViewModel();
            viewModel.ClubPro = clubPro;
            var club = db.GolfClubs.Find(clubPro.GolfClubId);
            viewModel.Club = club;

            return View(viewModel);
        }

        // POST: ClubPros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClubProId,Name,ContactNo,GolfClubId,Email")] ClubPro clubPro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubPro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { golfClubId = clubPro.GolfClubId});
            }
            return View(clubPro);
        }

        // GET: ClubPros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubPro clubPro = db.ClubProes.Find(id);
            if (clubPro == null)
            {
                return HttpNotFound();
            }
            return View(clubPro);
        }

        // POST: ClubPros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubPro clubPro = db.ClubProes.Find(id);
            var golfClubId = clubPro.GolfClubId;
            db.ClubProes.Remove(clubPro);
            db.SaveChanges();
            return RedirectToAction("Index", new { golfClubId = golfClubId});
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
