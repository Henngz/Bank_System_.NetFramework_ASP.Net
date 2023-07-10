using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsBanking
{
    public partial class ClientData : Form
    {
        ConstructorData constructorData = new ConstructorData();

        //Define an instance of the BankOfBIT_YZContext class.
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        /// <summary>
        /// This constructor will execute when the form is opened
        /// from the MDI Frame.
        /// </summary>
        public ClientData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This constructor will execute when the form is opened by
        /// returning from the History or Transaction forms.
        /// </summary>
        /// <param name="constructorData">Populated ConstructorData object.</param>
        public ClientData(ConstructorData constructorData)
        {
            //Given:
            InitializeComponent();
            this.constructorData = constructorData;


            Client client = constructorData.client;

            //More code to be added:
            clientNumberMaskedTextBox.Text = client.ClientNumber.ToString();

            clientNumberMaskedTextBox_Leave_1(null, null);
        }

        /// <summary>
        /// Open the Transaction form passing ConstructorData object.
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RetriveCurrentRecord();

            //Given, more code to be added.
            ProcessTransaction transaction = new ProcessTransaction(constructorData);
            transaction.MdiParent = this.MdiParent;
            transaction.Show();
            this.Close();
        }

        /// <summary>
        /// Open the History form passing ConstructorData object.
        /// </summary>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RetriveCurrentRecord();

            //Given, more code to be added.
            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close();
        }

        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void ClientData_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

        }

        /// <summary>
        /// This event handler is to retrive data from client and BankAccount 
        /// when users input the client number into the MaskedTextBox.
        /// </summary>
        private void clientNumberMaskedTextBox_Leave_1(object sender, EventArgs e)
        {
            long clientNumber = long.Parse(clientNumberMaskedTextBox.Text);

            Client client = db.Clients.
                            Where(x => x.ClientNumber == clientNumber).
                            SingleOrDefault();

            if (client == null)
            {
                clientBindingSource.Clear();
                bankAccountBindingSource.Clear();

                string message = "Client Number: " + clientNumber + " does not exist.";
                string title = "Invalid Client Number";
                MessageBox.Show(message, title);

                lnkDetails.TabStop = false;
                lnkProcess.TabStop = false;

                clientNumberMaskedTextBox.Select();

                // Clear both BindingSource objects
                clientBindingSource.DataSource = typeof(Client);
                bankAccountBindingSource.DataSource = typeof(BankAccount);
            }
            else
            {
                clientBindingSource.DataSource = client;

                int clientId = client.ClientId;

                IQueryable<BankAccount> accounts = db.BankAccounts.
                                                      Where(x => x.ClientId == clientId);

                if (constructorData.bankAccount != null)
                {
                    bankAccountBindingSource.DataSource = accounts. ToList();

                    BankAccount selectedAccount = constructorData.bankAccount;

                    cboAccountNumber.SelectedIndex = cboAccountNumber.FindString(selectedAccount.AccountNumber.ToString());
                }
                else
                {
                    if (accounts == null)
                    {
                        lnkDetails.TabStop = false;
                        lnkProcess.TabStop = false;

                        clientBindingSource.DataSource = typeof(Client);
                        bankAccountBindingSource.DataSource = typeof(BankAccount);
                    }
                    else
                    {
                        bankAccountBindingSource.DataSource = accounts.ToList();          

                        lnkDetails.TabStop = true;
                        lnkProcess.TabStop = true;
                    }
                }
            }
        }

        //This is method is to store current clint and bankaccount to constructorData.
        public void RetriveCurrentRecord()
        {
            constructorData.client = (Client)clientBindingSource.Current;
            constructorData.bankAccount = (BankAccount)bankAccountBindingSource.Current;

        }
    }     
}
