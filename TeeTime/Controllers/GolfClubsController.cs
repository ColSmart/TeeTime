﻿using System;
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
    public class GolfClubsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GolfClubs
        public ActionResult Index()
        {
            return View(db.GolfClubs.ToList());
        }

        // GET: GolfClubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfClub golfClub = db.GolfClubs.Find(id);
            if (golfClub == null)
            {
                return HttpNotFound();
            }
            return View(golfClub);
        }

        // GET: GolfClubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GolfClubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GolfClubId,Name,Country,Area,County,Postcode,WebSite,Email,ContactNo")] GolfClub golfClub)
        {
            if (ModelState.IsValid)
            {
                db.GolfClubs.Add(golfClub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(golfClub);
        }

        // GET: GolfClubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfClub golfClub = db.GolfClubs.Find(id);
            if (golfClub == null)
            {
                return HttpNotFound();
            }
            return View(golfClub);
        }

        // POST: GolfClubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GolfClubId,Name,Country,Area,County,Postcode,WebSite,Email,ContactNo")] GolfClub golfClub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golfClub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(golfClub);
        }

        // GET: GolfClubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfClub golfClub = db.GolfClubs.Find(id);
            if (golfClub == null)
            {
                return HttpNotFound();
            }
            return View(golfClub);
        }

        // POST: GolfClubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GolfClub golfClub = db.GolfClubs.Find(id);
            db.GolfClubs.Remove(golfClub);
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
