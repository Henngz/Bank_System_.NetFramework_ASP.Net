﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;

namespace BankOfBIT_YZ.Controllers
{
    public class BronzeStatesController : Controller
    {
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        // GET: BronzeStates
        public ActionResult Index()
        {
            return View(BronzeState.GetInstance());
        }

        // GET: BronzeStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BronzeState bronzeState = (BronzeState)db.AccountStates.Find(id);
            if (bronzeState == null)
            {
                return HttpNotFound();
            }
            return View(bronzeState);
        }

        // GET: BronzeStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BronzeStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountStateId,LowerLimit,UpperLimit,Rate")] BronzeState bronzeState)
        {
            if (ModelState.IsValid)
            {
                db.AccountStates.Add(bronzeState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bronzeState);
        }

        // GET: BronzeStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BronzeState bronzeState = (BronzeState)db.AccountStates.Find(id);
            if (bronzeState == null)
            {
                return HttpNotFound();
            }
            return View(bronzeState);
        }

        // POST: BronzeStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountStateId,LowerLimit,UpperLimit,Rate")] BronzeState bronzeState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bronzeState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bronzeState);
        }

        // GET: BronzeStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BronzeState bronzeState = (BronzeState)db.AccountStates.Find(id);
            if (bronzeState == null)
            {
                return HttpNotFound();
            }
            return View(bronzeState);
        }

        // POST: BronzeStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BronzeState bronzeState = (BronzeState)db.AccountStates.Find(id);
            db.AccountStates.Remove(bronzeState);
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
