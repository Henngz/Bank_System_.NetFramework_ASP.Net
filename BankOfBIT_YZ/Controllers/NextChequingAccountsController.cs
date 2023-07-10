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
    public class NextChequingAccountsController : Controller
    {
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        // GET: NextChequingAccounts
        public ActionResult Index()
        {
            return View(NextChequingAccount.GetInstance());
        }

        // GET: NextChequingAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextChequingAccount nextChequingAccount = db.NextChequingAccounts.Find(id);
            if (nextChequingAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextChequingAccount);
        }

        // GET: NextChequingAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextChequingAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextChequingAccount nextChequingAccount)
        {
            if (ModelState.IsValid)
            {
                db.NextChequingAccounts.Add(nextChequingAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextChequingAccount);
        }

        // GET: NextChequingAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextChequingAccount nextChequingAccount = db.NextChequingAccounts.Find(id);
            if (nextChequingAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextChequingAccount);
        }

        // POST: NextChequingAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextChequingAccount nextChequingAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextChequingAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextChequingAccount);
        }

        // GET: NextChequingAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextChequingAccount nextChequingAccount = db.NextChequingAccounts.Find(id);
            if (nextChequingAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextChequingAccount);
        }

        // POST: NextChequingAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextChequingAccount nextChequingAccount = db.NextChequingAccounts.Find(id);
            db.NextChequingAccounts.Remove(nextChequingAccount);
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
