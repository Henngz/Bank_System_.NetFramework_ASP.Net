using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Migrations;
using BankOfBIT_YZ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsBanking.TransactionManagerServiceReference;

namespace WindowsBanking
{
    public partial class ProcessTransaction : Form
    {
        ConstructorData constructorData;

        //Define an instance of the BankOfBIT_YZContext class.
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        public NumberStyles Float { get; private set; }

        /// Form can only be opened with a Constructor Data object
        /// containing client and account details.
        /// </summary>
        /// <param name="constructorData">Populated Constructor data object.</param>
        public ProcessTransaction(ConstructorData constructorData)
        {
            //Given, more code to be added.
            InitializeComponent();
            this.constructorData = constructorData;
        }

        /// <summary>
        /// Return to the Client Data form passing specific client and 
        /// account information within ConstructorData.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            constructorData.client = (Client)clientBindingSource.Current;
            constructorData.bankAccount = (BankAccount)bankAccountBindingSource.Current;

            ClientData client = new ClientData(constructorData);

            client.MdiParent = this.MdiParent;
            client.Show();
            this.Close();
        }

        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void ProcessTransaction_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                this.Location = new Point(0, 0);

                Client client = constructorData.client;

                clientBindingSource.DataSource = client;

                BankAccount account = constructorData.bankAccount;

                mlblAccountNumber.Mask = Utility.BusinessRules.AccountFormat(account.Description);

                bankAccountBindingSource.DataSource = account;

                IQueryable<TransactionType> transactiontypes = db.TransactionTypes.
                                                                   Where(x => x.TransactionTypeId < 5);

                transactionTypeBindingSource.DataSource = transactiontypes.ToList();


            }
            catch (Exception exception)
            {
                string title = "Error";
                MessageBox.Show(exception.Message, title);
            }
        }

        /// <summary>
        /// This event handler is to handle different situations when users selet different transaction types.
        /// </summary>
        private void cboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransactionType.SelectedIndex == 0 || cboTransactionType.SelectedIndex == 1)
            {
                cboPayeeAccount.Visible = false;

                lblNoAdditionalAccounts.Visible = false;

                lblPayeeAccount.Visible = false;

                lnkUpdate.Enabled = true;
            }
            else if (cboTransactionType.SelectedIndex == 2)
            {
                IQueryable<Payee> payees = db.Payees;

                payeeBindingSource.DataSource = payees.ToList();

                cboPayeeAccount.DisplayMember = "Description";

                cboPayeeAccount.ValueMember = "PayeeId";

                cboPayeeAccount.SelectedIndex = 0;

                cboPayeeAccount.Visible = true;

                lblPayeeAccount.Visible = true;

                lnkUpdate.Enabled = true;
            }
            else if (cboTransactionType.SelectedIndex == 3)
            {
                Client client = constructorData.client;

                BankAccount account = constructorData.bankAccount;

                IQueryable<BankAccount> bankAccounts = db.BankAccounts.
                                                        Where(x => x.ClientId == client.ClientId && x.AccountNumber != account.AccountNumber);

                if (bankAccounts == null)
                {
                    cboPayeeAccount.Visible = false;

                    lblNoAdditionalAccounts.Visible = false;

                    lblPayeeAccount.Visible = false;

                    lnkUpdate.Enabled = false;
                }
                else
                {
                    payeeBindingSource.DataSource = bankAccounts.ToList();

                    cboPayeeAccount.SelectedIndex = 0;

                    cboPayeeAccount.DisplayMember = "AccountNumber";

                    cboPayeeAccount.ValueMember = "BankAccountId";

                    cboPayeeAccount.Visible = true;

                    lblPayeeAccount.Visible = true;

                    lnkUpdate.Enabled = true;

                    lblNoAdditionalAccounts.Visible = false;
                }
            }

        }

        /// <summary>
        /// This event handler is to process transcation and update account.
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            BankAccount account = constructorData.bankAccount;

            if (txtAmount.Text == "")
            {
                string message1 = "Please input amount.";
                string title1 = "Invalid Amount";
                MessageBox.Show(message1, title1);
            }
            else
            {
                try
                {
                    if (Utility.Numeric.IsNumeric(txtAmount.Text, Float))
                    {

                        if (cboTransactionType.SelectedIndex > 0)
                        {
                            double amount = double.Parse(txtAmount.Text.ToString());

                            int bankAccountId = account.BankAccountId;

                            if (double.Parse(txtAmount.Text) > account.Balance)
                            {
                                string message = "Insufficient funds exist for requested transaction.";
                                string title = "Insufficient Funds";
                                MessageBox.Show(message, title);
                            }
                            else
                            {
                                // Process withdrawal
                                if (cboTransactionType.SelectedIndex == 1)
                                {
                                    String notes = "Withdraw : " + txtAmount.Text;

                                    // Create an instance of the WCF Service
                                    TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                                    try
                                    {
                                        double newBalance = (double)transactionManagerClient.Withdrawal(bankAccountId, amount, notes);

                                        lblBalance.Text = newBalance.ToString("C2");
                                    }
                                    catch (Exception)
                                    {
                                        string message = "Error completing Transaction.";
                                        string title = "Transaction Error";
                                        MessageBox.Show(message, title);
                                    }
                                }

                                // Process Billpayment
                                else if (cboTransactionType.SelectedIndex == 2)
                                {
                                    String notes = "Banking Payment to : " + cboPayeeAccount.Text;

                                    TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                                    try
                                    {
                                        double newBalance = (double)transactionManagerClient.BillPayment(bankAccountId, amount, notes);

                                        lblBalance.Text = newBalance.ToString("c2");
                                    }
                                    catch (Exception)
                                    {
                                        string message = "Error completing Transaction.";
                                        string title = "Transaction Error";
                                        MessageBox.Show(message, title);
                                    }
                                }

                                // Process Transfer
                                else if (cboTransactionType.SelectedIndex == 3)
                                {
                                    String notes = "Banking Transfer From: " + mlblAccountNumber.Text + " To: " + cboPayeeAccount.Text;

                                    TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                                    int fromBankAccountId = bankAccountId;

                                    int toBankAccountId = (int)cboPayeeAccount.SelectedValue;

                                    try
                                    {
                                        double newBalance = (double)transactionManagerClient.Transfer(fromBankAccountId, toBankAccountId, amount, notes);

                                        lblBalance.Text = newBalance.ToString("C2");
                                    }
                                    catch (Exception)
                                    {
                                        string message = "Error completing Transaction.";
                                        string title = "Transaction Error";
                                        MessageBox.Show(message, title);
                                    }
                                }
                            }
                        }

                        // Process deposit
                        else if (cboTransactionType.SelectedIndex == 0)
                        {
                            double amount = double.Parse(txtAmount.Text.ToString());

                            int bankAccountId = account.BankAccountId;

                            String notes = "Deposit : " + txtAmount.Text;

                            TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                            try
                            {
                                double newBalance = (double)transactionManagerClient.Deposit(bankAccountId, amount, notes);

                                lblBalance.Text = newBalance.ToString("C2");
                            }
                            catch (Exception)
                            {
                                string message = "Error completing Transaction.";
                                string title = "Transaction Error";
                                MessageBox.Show(message, title);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    string title = "Transaction Exception";
                    MessageBox.Show(ex.Message, title);
                }
            }
        }
    }

}