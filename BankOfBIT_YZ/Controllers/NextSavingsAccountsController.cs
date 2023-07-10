using System;
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
    public class NextSavingsAccountsController : Controller
    {
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        // GET: NextSavingsAccounts
        public ActionResult Index()
        {
            return View(NextSavingsAccount.GetInstance());
        }

        // GET: NextSavingsAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextSavingsAccount nextSavingsAccount = db.NextSavingsAccounts.Find(id);
            if (nextSavingsAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextSavingsAccount);
        }

        // GET: NextSavingsAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextSavingsAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextSavingsAccount nextSavingsAccount)
        {
            if (ModelState.IsValid)
            {
                db.NextSavingsAccounts.Add(nextSavingsAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextSavingsAccount);
        }

        // GET: NextSavingsAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextSavingsAccount nextSavingsAccount = db.NextSavingsAccounts.Find(id);
            if (nextSavingsAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextSavingsAccount);
        }

        // POST: NextSavingsAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextSavingsAccount nextSavingsAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextSavingsAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextSavingsAccount);
        }

        // GET: NextSavingsAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextSavingsAccount nextSavingsAccount = db.NextSavingsAccounts.Find(id);
            if (nextSavingsAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextSavingsAccount);
        }

        // POST: NextSavingsAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextSavingsAccount nextSavingsAccount = db.NextSavingsAccounts.Find(id);
            db.NextSavingsAccounts.Remove(nextSavingsAccount);
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
