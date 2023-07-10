using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace WindowsBanking
{
    public partial class History : Form
    {
        ConstructorData constructorData;

        //Define an instance of the BankOfBIT_YZContext class.
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        /// <summary>
        /// Form can only be opened with a Constructor Data object
        /// containing client and account details.
        /// </summary>
        /// <param name="constructorData">Populated Constructor data object.</param>
        public History(ConstructorData constructorData)
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

            ClientData client = new ClientData(constructorData);
            client.MdiParent = this.MdiParent;
            client.Show();
            this.Close();
        }
        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(0, 0);

                Client client = constructorData.client;

                clientBindingSource.DataSource = client;

                BankAccount account = constructorData.bankAccount;

                mlblAccountNumber.Mask = Utility.BusinessRules.AccountFormat(account.Description);

                bankAccountBindingSource.DataSource = account;

                var Query = from Transaction in db.Transactions
                                     join TransactionType in db.TransactionTypes on Transaction.TransactionTypeId equals TransactionType.TransactionTypeId
                                     where Transaction.BankAccountId == account.BankAccountId
                                     select new {
                                                    DateCreated = Transaction.DateCreated,
                                                    TransactionType = TransactionType.Description,
                                                    Deposit = Transaction.Deposit,
                                                    Withdrawal = Transaction.Withdrawal,
                                                    Notes = Transaction.Notes
                                     };

                transactionBindingSource.DataSource = Query.ToList();

            }
            catch (Exception exception)
            {
                string title = "Error";
                MessageBox.Show(exception.Message, title);
            }          
        }
    }
}
