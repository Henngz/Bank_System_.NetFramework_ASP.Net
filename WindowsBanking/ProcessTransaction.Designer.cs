using System;

namespace WindowsBanking
{
    partial class ProcessTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label lblTransactionType;
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.mlblAccountNumber = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBalance = new System.Windows.Forms.Label();
            this.mlblClientNumber = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblFullName = new System.Windows.Forms.Label();
            this.grpTransaction = new System.Windows.Forms.GroupBox();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.transactionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.cboPayeeAccount = new System.Windows.Forms.ComboBox();
            this.payeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoAdditionalAccounts = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            lblTransactionType = new System.Windows.Forms.Label();
            this.grpClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.grpTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(167, 55);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(154, 25);
            clientNumberLabel.TabIndex = 0;
            clientNumberLabel.Text = "Client Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(744, 55);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(115, 25);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Full Name:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(167, 138);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(177, 25);
            accountNumberLabel.TabIndex = 4;
            accountNumberLabel.Text = "Account Number:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(749, 140);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(96, 25);
            balanceLabel.TabIndex = 6;
            balanceLabel.Text = "Balance:";
            // 
            // lblTransactionType
            // 
            lblTransactionType.AutoSize = true;
            lblTransactionType.Location = new System.Drawing.Point(338, 121);
            lblTransactionType.Name = "lblTransactionType";
            lblTransactionType.Size = new System.Drawing.Size(185, 25);
            lblTransactionType.TabIndex = 7;
            lblTransactionType.Text = "Transaction Type:";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(accountNumberLabel);
            this.grpClient.Controls.Add(this.mlblAccountNumber);
            this.grpClient.Controls.Add(balanceLabel);
            this.grpClient.Controls.Add(this.lblBalance);
            this.grpClient.Controls.Add(clientNumberLabel);
            this.grpClient.Controls.Add(this.mlblClientNumber);
            this.grpClient.Controls.Add(fullNameLabel);
            this.grpClient.Controls.Add(this.lblFullName);
            this.grpClient.Location = new System.Drawing.Point(94, 92);
            this.grpClient.Margin = new System.Windows.Forms.Padding(6);
            this.grpClient.Name = "grpClient";
            this.grpClient.Padding = new System.Windows.Forms.Padding(6);
            this.grpClient.Size = new System.Drawing.Size(1388, 206);
            this.grpClient.TabIndex = 0;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Data";
            // 
            // mlblAccountNumber
            // 
            this.mlblAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlblAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.mlblAccountNumber.Location = new System.Drawing.Point(375, 142);
            this.mlblAccountNumber.Name = "mlblAccountNumber";
            this.mlblAccountNumber.Size = new System.Drawing.Size(251, 38);
            this.mlblAccountNumber.TabIndex = 5;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_YZ.Models.BankAccount);
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblBalance.Location = new System.Drawing.Point(880, 137);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(241, 43);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mlblClientNumber
            // 
            this.mlblClientNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlblClientNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.mlblClientNumber.Location = new System.Drawing.Point(375, 55);
            this.mlblClientNumber.Name = "mlblClientNumber";
            this.mlblClientNumber.Size = new System.Drawing.Size(251, 39);
            this.mlblClientNumber.TabIndex = 1;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT_YZ.Models.Client);
            // 
            // lblFullName
            // 
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.lblFullName.Location = new System.Drawing.Point(880, 54);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(241, 40);
            this.lblFullName.TabIndex = 3;
            // 
            // grpTransaction
            // 
            this.grpTransaction.Controls.Add(lblTransactionType);
            this.grpTransaction.Controls.Add(this.cboTransactionType);
            this.grpTransaction.Controls.Add(this.lnkReturn);
            this.grpTransaction.Controls.Add(this.lnkUpdate);
            this.grpTransaction.Controls.Add(this.cboPayeeAccount);
            this.grpTransaction.Controls.Add(this.txtAmount);
            this.grpTransaction.Controls.Add(this.lblPayeeAccount);
            this.grpTransaction.Controls.Add(this.label1);
            this.grpTransaction.Controls.Add(this.lblNoAdditionalAccounts);
            this.grpTransaction.Location = new System.Drawing.Point(94, 360);
            this.grpTransaction.Margin = new System.Windows.Forms.Padding(6);
            this.grpTransaction.Name = "grpTransaction";
            this.grpTransaction.Padding = new System.Windows.Forms.Padding(6);
            this.grpTransaction.Size = new System.Drawing.Size(1388, 400);
            this.grpTransaction.TabIndex = 1;
            this.grpTransaction.TabStop = false;
            this.grpTransaction.Text = "Perform Transaction";
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DataSource = this.transactionTypeBindingSource;
            this.cboTransactionType.DisplayMember = "Description";
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(605, 121);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(399, 33);
            this.cboTransactionType.TabIndex = 8;
            this.cboTransactionType.ValueMember = "TransactionTypeId";
            this.cboTransactionType.SelectedIndexChanged += new System.EventHandler(this.cboTransactionType_SelectedIndexChanged);
            // 
            // transactionTypeBindingSource
            // 
            this.transactionTypeBindingSource.DataSource = typeof(BankOfBIT_YZ.Models.TransactionType);
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(638, 335);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(161, 25);
            this.lnkReturn.TabIndex = 5;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Location = new System.Drawing.Point(442, 335);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(81, 25);
            this.lnkUpdate.TabIndex = 4;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // cboPayeeAccount
            // 
            this.cboPayeeAccount.DataSource = this.payeeBindingSource;
            this.cboPayeeAccount.DisplayMember = "Description";
            this.cboPayeeAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayeeAccount.FormattingEnabled = true;
            this.cboPayeeAccount.Location = new System.Drawing.Point(606, 248);
            this.cboPayeeAccount.Margin = new System.Windows.Forms.Padding(6);
            this.cboPayeeAccount.Name = "cboPayeeAccount";
            this.cboPayeeAccount.Size = new System.Drawing.Size(398, 33);
            this.cboPayeeAccount.TabIndex = 3;
            this.cboPayeeAccount.ValueMember = "PayeeId";
            this.cboPayeeAccount.Visible = false;
            // 
            // payeeBindingSource
            // 
            this.payeeBindingSource.DataSource = typeof(BankOfBIT_YZ.Models.Payee);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(606, 188);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(6);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(398, 31);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPayeeAccount
            // 
            this.lblPayeeAccount.AutoSize = true;
            this.lblPayeeAccount.Location = new System.Drawing.Point(436, 248);
            this.lblPayeeAccount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPayeeAccount.Name = "lblPayeeAccount";
            this.lblPayeeAccount.Size = new System.Drawing.Size(79, 25);
            this.lblPayeeAccount.TabIndex = 1;
            this.lblPayeeAccount.Text = "Payee:";
            this.lblPayeeAccount.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount:";
            // 
            // lblNoAdditionalAccounts
            // 
            this.lblNoAdditionalAccounts.Location = new System.Drawing.Point(600, 294);
            this.lblNoAdditionalAccounts.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNoAdditionalAccounts.Name = "lblNoAdditionalAccounts";
            this.lblNoAdditionalAccounts.Size = new System.Drawing.Size(414, 41);
            this.lblNoAdditionalAccounts.TabIndex = 6;
            this.lblNoAdditionalAccounts.Text = "No accounts available to receive transfer.";
            this.lblNoAdditionalAccounts.Visible = false;
            // 
            // ProcessTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 939);
            this.Controls.Add(this.grpTransaction);
            this.Controls.Add(this.grpClient);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ProcessTransaction";
            this.Text = "ProcessTransaction";
            this.Load += new System.EventHandler(this.ProcessTransaction_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.grpTransaction.ResumeLayout(false);
            this.grpTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.GroupBox grpTransaction;
        private System.Windows.Forms.Label lblNoAdditionalAccounts;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.ComboBox cboPayeeAccount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label label1;
        private EWSoftware.MaskedLabelControl.MaskedLabel mlblAccountNumber;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label lblBalance;
        private EWSoftware.MaskedLabelControl.MaskedLabel mlblClientNumber;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.BindingSource transactionTypeBindingSource;
        private System.Windows.Forms.BindingSource payeeBindingSource;
    }
}