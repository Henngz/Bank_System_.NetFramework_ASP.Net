using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBanking.TransactionManagerService;
using System.Linq.Expressions;

namespace OnlineBanking
{
    public partial class CreateTransaction : System.Web.UI.Page
    {
        BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        /// <summary>
        /// Bind data to different controls as long as the page loads successfully.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    try
                    {
                        long accountNumber = long.Parse(Session["SessionAccountNumber"].ToString());

                        lblAccountNumberValue.Text = accountNumber.ToString();

                        BankAccount bankAccount = (BankAccount)Session["SessionBankAccount"];

                        lblBalanceValue.Text = bankAccount.Balance.ToString("c2");

                        // Bind data to Transaction Type DropDownList
                        DataBindingForTransactionTypeDropDownList();

                        // Bind data to Payee/Accounts DropDownList
                        DataBindingForPayeeDropDownList();

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
        /// This method is to bind data to Transaction Type DropDownList control.
        /// </summary>
        public void DataBindingForTransactionTypeDropDownList()
        {
            IQueryable<TransactionType> transactionTypes = db.TransactionTypes.
                                                                        Where(x => x.TransactionTypeId == 3 || x.TransactionTypeId == 4);

            ddlTransactionType.DataSource = transactionTypes.ToList();

            ddlTransactionType.DataBind();

        }

        /// <summary>
        /// This method is to bind data to Payee/Account DropDownList control.
        /// </summary>
        public void DataBindingForPayeeDropDownList()
        {
            IQueryable<Payee> payees = db.Payees;

            ddlpayee.DataSource = payees.ToList();

            ddlpayee.DataBind();

        }

        /// <summary>
        /// This method is to clear out any previous databindings on the Payee/Account DropDownList control.
        /// </summary>
        public void ClearDataOfPayeeDropDownList()
        {
            ddlpayee.DataSource = null;

            ddlpayee.DataTextField = null;

            ddlpayee.DataValueField = null;
        }

        /// <summary>
        /// This method is to process some tasks after the selected index of Payee dropdownlist changed
        /// </summary>
        protected void ddlpayee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method is to rebind data for Payee/Account DropDownList control
        /// after the selected index of TransactionType dropdownlist changed
        /// </summary>
        protected void ddlTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataOfPayeeDropDownList();

            if(int.Parse(ddlTransactionType.SelectedItem.Value) == 3)
            {
                ddlpayee.DataTextField = "Description";

                ddlpayee.DataValueField = "PayeeId";

                DataBindingForPayeeDropDownList();
            }
            else if(int.Parse(ddlTransactionType.SelectedItem.Value) == 4)
            {
                ddlpayee.DataTextField = "AccountNumber";

                ddlpayee.DataValueField = "BankAccountId";

                long accountNumber = long.Parse(Session["SessionAccountNumber"].ToString());

                Client client = (Client)Session["SessionClient"];

                int clientId = client.ClientId;

                IQueryable<BankAccount> bankAccounts = db.BankAccounts.
                                                        Where(x => x.ClientId == clientId && x.AccountNumber != accountNumber);

                ddlpayee.DataSource = bankAccounts.ToList();

                ddlpayee.DataBind();
            }
        }

        /// <summary>
        /// This method is to complete the transaction according to the infortion of the page.
        /// </summary>
        protected void lbtnCompleteTransaction_Click(object sender, EventArgs e)
        {
            rfvAmount.Enabled = true;

            Page.Validate();

            if(this.Page.User.Identity.IsAuthenticated)
            {
                if (Page.IsValid)
                {
                    BankAccount bankAccount = (BankAccount)Session["SessionBankAccount"];

                    double balance = bankAccount.Balance;

                    try
                    {
                        if (balance >= double.Parse(txtAmountValue.Text.ToString()))
                        {
                            lblException.Visible = false;

                            if (int.Parse(ddlTransactionType.SelectedItem.Value) == 3)
                            {
                                double amount = double.Parse(txtAmountValue.Text.ToString());

                                int bankAccountId = bankAccount.BankAccountId;

                                String notes = "Online Banking Payment to : " + ddlpayee.SelectedItem.Text;

                                // Create an instance of the WCF Service
                                TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                                //Identify if the transaction is successful.
                                try
                                {
                                    if (transactionManagerClient.BillPayment(bankAccountId, amount, notes) == null)
                                    {
                                        throw new Exception("The transaction is failed.");
                                    }
                                    else
                                    {
                                        double newBalance = (double)transactionManagerClient.BillPayment(bankAccountId, amount, notes);

                                        lblBalanceValue.Text = newBalance.ToString("c2");
                                    }
                                }
                                catch (Exception billPaymentException)
                                {
                                    lblException.Text = billPaymentException.Message;
                                    lblException.Visible = true;
                                }
                            }
                            else if (int.Parse(ddlTransactionType.SelectedItem.Value) == 4)
                            {
                                int fromBankAccountId = bankAccount.BankAccountId;

                                int toBankAccountId = int.Parse(ddlpayee.SelectedItem.Value);

                                double amount = double.Parse(txtAmountValue.Text);

                                String notes = "Online Banking Transfer From: " + lblAccountNumberValue.Text + " To : " + ddlpayee.SelectedItem.Text;

                                // Create an instance of the WCF Service
                                TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                                //Identify if the transaction is successful.
                                try
                                {
                                    if (transactionManagerClient.Transfer(fromBankAccountId, toBankAccountId, amount, notes) == null)
                                    {
                                        throw new Exception("The transaction is failed.");
                                    }
                                    else
                                    {
                                        double newBalance = (double)transactionManagerClient.Transfer(fromBankAccountId, toBankAccountId, amount, notes);
                                       
                                        lblBalanceValue.Text = newBalance.ToString("c2");
                                    }

                                }
                                catch (Exception transferException)
                                {
                                    lblException.Text = transferException.Message;
                                    lblException.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("The balance is not enough");
                        }
                    }
                    catch (Exception balanceException)
                    {
                        lblException.Text = balanceException.Message;
                        lblException.Visible = true;
                    }
                }
            }
            else 
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            
        }

        /// <summary>
        /// The web will return to BankAccountListing after clicking the buttn.
        /// </summary>
        protected void lbtnReturntoBankAccountListing_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountListing.aspx");
        }
    }
}