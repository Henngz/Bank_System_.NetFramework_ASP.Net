using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Utility; 

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionManager.svc or TransactionManager.svc.cs at the Solution Explorer and start debugging.
    public class TransactionManager : ITransactionManager
    {
        //Define an instance of the BankOfBIT_YZContext class.
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        public void DoWork()
        {
        }

        /// <summary>
        /// This method is to update balance of the bank account and change state according to updatedc balance.
        /// </summary>
        /// <param name="accountId">Represent account id</param>
        /// <param name="amount">Represent amount which need to be updated.</param>
        /// <returns>Return the updated balance.</returns>
        private double? UpdateBalance(int accountId, double amount)
        {
            try
            {
                double originalBalance = db.BankAccounts
                                        .Where(x => x.BankAccountId == accountId)
                                        .Select(x => x.Balance)
                                        .SingleOrDefault();

                BankAccount bankAccount = db.BankAccounts.Where(x => x.BankAccountId == accountId).SingleOrDefault();

                double updatedBalance = originalBalance + amount;

                bankAccount.Balance = updatedBalance;

                bankAccount.ChangeState();

                db.SaveChanges();

                return updatedBalance;
            }

            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// This method is to create a new transaction.
        /// </summary>
        /// <param name="accountId">Represent accoun id.</param>
        /// <param name="amount">Represent amount which need to be updated.</param>
        /// <param name="transactionTypeId">Represent transaction type id</param>
        /// <param name="notes">Represent notes</param>
        private void CreateTransaction(int accountId, double amount, int transactionTypeId, String notes)
        {
            Transaction newTransaction = new Transaction();

            newTransaction.BankAccountId = accountId;

            newTransaction.TransactionTypeId = transactionTypeId;

            newTransaction.Notes = notes;
            
            newTransaction.DateCreated = DateTime.Now;
            
            if(amount < 0)
            {
                newTransaction.Deposit = null;

                newTransaction.Withdrawal = -amount;
            }
            else
            {
                newTransaction.Deposit = amount;

                newTransaction.Withdrawal = null;
            }

            newTransaction.SetNextTransactionNumber();

            db.Transactions.Add(newTransaction);

            db.SaveChanges();
        }

        /// <summary>
        /// This method is to deposit money to account and return the updated balance.
        /// </summary>
        /// <param name="accountId">Represent accoun id.</param>
        /// <param name="amount">Represent amount which need to be updated.</param>
        /// <param name="notes">Represent notes</param>
        /// <returns>Return updated balance</returns>
        /// <exception cref="NotImplementedException">Return null</exception>
        public double? Deposit(int accountId, double amount, string notes)
        {
            try
            {
                double updatedBalance = (double)UpdateBalance(accountId, Math.Abs(amount));

                CreateTransaction(accountId, Math.Abs(amount), (int)TransactionTypeValues.DEPOSIT, notes);

                return updatedBalance;
            }
            catch(Exception)
            {
                return null;
            }          
        }

        /// <summary>
        /// This method is to withdraw money to account and return the updated balance.
        /// </summary>
        /// <param name="accountId">Represent accoun id.</param>
        /// <param name="amount">Represent amount which need to be updated.</param>
        /// <param name="notes">Represent notes</param>
        /// <returns>Return updated balance</returns>
        /// <exception cref="NotImplementedException">Return null</exception>
        public double? Withdrawal(int accountId, double amount, string notes)
        {
            try
            {
                double updatedBalance = (double)UpdateBalance(accountId, -1 * Math.Abs(amount));

                CreateTransaction(accountId, -1 * Math.Abs(amount), (int)TransactionTypeValues.WITHDRAWAL, notes);

                return updatedBalance;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// This method is to withdraw money to account and return the updated balance.
        /// </summary>
        /// <param name="accountId">Represent accoun id.</param>
        /// <param name="amount">Represent amount which need to be updated.</param>
        /// <param name="notes">Represent notes</param>
        /// <returns>Return updated balance</returns>
        public double? BillPayment(int accountId, double amount, string notes)
        {
            try
            {
                double updatedBalance = (double)UpdateBalance(accountId, -1 * Math.Abs(amount));

                CreateTransaction(accountId, -1 * Math.Abs(amount), (int)TransactionTypeValues.BILL_PAYMENT, notes);

                return updatedBalance;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// This method is to update balance and create transaction of transfering money from two accounts.
        /// </summary>
        /// <param name="fromAccountId">Represent the account id of sending account</param>
        /// <param name="toAccountId">Represent the account id of receiving account</param>
        /// <param name="amount">Represent the amount of the account</param>
        /// <param name="notes">Represent notes of this transcation </param>
        /// <returns>Return the updated balance of the sending account (fromAccountId).</returns>
        public double? Transfer(int fromAccountId, int toAccountId, double amount, string notes)
        {
            try
            {
                double updatedBalanceOfSending = (double)UpdateBalance(fromAccountId, -1 * Math.Abs(amount));

                CreateTransaction(fromAccountId, -1 * Math.Abs(amount), (int)TransactionTypeValues.TRANSFER, notes);

                double receivingAmount = Math.Abs(amount);

                double updatedBalanceOfReceiving = (double)UpdateBalance(toAccountId, receivingAmount);

                CreateTransaction(toAccountId, receivingAmount, (int)TransactionTypeValues.TRANSFER_RECIPIENT, notes);

                return updatedBalanceOfSending;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// This method is to calculate the interest and return the updated balance.
        /// </summary>
        /// <param name="accountId">Represent accoun id.</param>
        /// <param name="notes">Represent notes</param>
        /// <returns>Return updated balance</returns>
        public double? CalculateInterest(int accountId, string notes)
        {
            try
            { 
                int accountStateId = db.BankAccounts
                                        .Where(x => x.BankAccountId == accountId)
                                        .Select(x => x.AccountStateId)
                                        .SingleOrDefault();

                BankAccount bankAccount = db.BankAccounts
                                        .Where(x => x.BankAccountId == accountId)
                                        .SingleOrDefault();


                AccountState accountState = db.AccountStates.Where(x => x.AccountStateId == accountStateId).SingleOrDefault();

                double rate = accountState.RateAdjustment(bankAccount);

                double interest = (rate * bankAccount.Balance * 1) / 12;

       
                double updatedBalance = (double)UpdateBalance(accountId, interest);

                CreateTransaction(accountId, interest, (int)TransactionTypeValues.INTEREST, notes);

                return updatedBalance;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
