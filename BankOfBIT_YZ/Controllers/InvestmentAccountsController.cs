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
    public class InvestmentAccountsController : Controller
    {
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        // GET: InvestmentAccounts
        public ActionResult Index()
        {
            var bankAccounts = db.BankAccounts.Include(i => i.AccountState).Include(i => i.Client);
            return View(db.InvestmentAccounts.ToList());
        }

        // GET: InvestmentAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = (InvestmentAccount)db.BankAccounts.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentAccount);
        }

        // GET: InvestmentAccounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            return View();
        }

        // POST: InvestmentAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankAccountId,ClientId,AccountStateId,AccountNumber,Balance,DateCreated,Notes,InterestRate")] InvestmentAccount investmentAccount)
        {
            if (ModelState.IsValid)
            {
                investmentAccount.SetNextAccountNumber();
                db.BankAccounts.Add(investmentAccount);
                investmentAccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentAccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentAccount.ClientId);
            return View(investmentAccount);
        }

        // GET: InvestmentAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = (InvestmentAccount)db.BankAccounts.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentAccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentAccount.ClientId);
            return View(investmentAccount);
        }

        // POST: InvestmentAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankAccountId,ClientId,AccountStateId,AccountNumber,Balance,DateCreated,Notes,InterestRate")] InvestmentAccount investmentAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investmentAccount).State = EntityState.Modified;
                investmentAccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentAccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentAccount.ClientId);
            return View(investmentAccount);
        }

        // GET: InvestmentAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = (InvestmentAccount)db.BankAccounts.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentAccount);
        }

        // POST: InvestmentAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentAccount investmentAccount = (InvestmentAccount)db.BankAccounts.Find(id);
            db.BankAccounts.Remove(investmentAccount);
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
