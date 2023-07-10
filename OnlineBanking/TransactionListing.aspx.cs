using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking
{
    public partial class TransactionListing : System.Web.UI.Page
    {
        /// <summary>
        /// Bind data to different controls as long as the page loads successfully.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            BankOfBIT_YZContext db = new BankOfBIT_YZContext();

            if (!IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    try
                    {
                        // Set client name for label
                        Client client = (Client)Session["SessionClient"];

                        String fName = client.FirstName;

                        String lName = client.LastName;

                        lblClientName.Text = fName + " " + lName;

                        //Set Account Number for label
                        long accountNumber = long.Parse(Session["SessionAccountNumber"].ToString());

                        lblAccountNumberValue.Text = accountNumber.ToString();

                        BankAccount bankAccount = db.BankAccounts.
                                                   Where(x => x.AccountNumber == accountNumber).
                                                   SingleOrDefault();

                        Session["SessionBankAccount"] = bankAccount;

                        lblBalanceValue.Text = bankAccount.Balance.ToString("c2");

                        int bankAccountId = bankAccount.BankAccountId;

                        //Bind data to gvTransationListing
                        IQueryable<Transaction> transactions = db.Transactions.
                                                                Where(x => x.BankAccountId == bankAccountId);

                        gvTransationListing.DataSource = transactions.ToList();

                        gvTransationListing.DataBind();
                    }

                    catch (Exception)
                    {
                        lblException.Text = "There are some exceptions.";
                    }
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }

        /// <summary>
        /// When the user cilcks the link button, the page will direct to AccountListing page.
        /// </summary>
        protected void lbtnAccountListing_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountListing.aspx");
        }

        /// <summary>
        /// When the user cilcks the link button, the page will direct to AccountListing page.
        /// </summary>
        protected void lbtnTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateTransaction.aspx");
        }
    }
}