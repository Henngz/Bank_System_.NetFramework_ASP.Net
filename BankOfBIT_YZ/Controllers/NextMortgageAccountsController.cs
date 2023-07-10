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
    public class NextMortgageAccountsController : Controller
    {
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        // GET: NextMortgageAccounts
        public ActionResult Index()
        {
            return View(NextMortgageAccount.GetInstance());
        }

        // GET: NextMortgageAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextMortgageAccount nextMortgageAccount = db.NextMortgageAccounts.Find(id);
            if (nextMortgageAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextMortgageAccount);
        }

        // GET: NextMortgageAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextMortgageAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextMortgageAccount nextMortgageAccount)
        {
            if (ModelState.IsValid)
            {
                db.NextMortgageAccounts.Add(nextMortgageAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextMortgageAccount);
        }

        // GET: NextMortgageAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextMortgageAccount nextMortgageAccount = db.NextMortgageAccounts.Find(id);
            if (nextMortgageAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextMortgageAccount);
        }

        // POST: NextMortgageAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextMortgageAccount nextMortgageAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextMortgageAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextMortgageAccount);
        }

        // GET: NextMortgageAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextMortgageAccount nextMortgageAccount = db.NextMortgageAccounts.Find(id);
            if (nextMortgageAccount == null)
            {
                return HttpNotFound();
            }
            return View(nextMortgageAccount);
        }

        // POST: NextMortgageAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextMortgageAccount nextMortgageAccount = db.NextMortgageAccounts.Find(id);
            db.NextMortgageAccounts.Remove(nextMortgageAccount);
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
