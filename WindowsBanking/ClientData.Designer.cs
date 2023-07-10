namespace WindowsBanking
{
    partial class ClientData
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
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label fullAddressLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label descriptionLabel2;
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.clientNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblFullAddress = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboAccountNumber = new System.Windows.Forms.ComboBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            clientNumberLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            fullAddressLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            descriptionLabel2 = new System.Windows.Forms.Label();
            this.grpClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.grpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(70, 75);
            clientNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(154, 25);
            clientNumberLabel.TabIndex = 0;
            clientNumberLabel.Text = "Client Number:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(76, 250);
            dateCreatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(145, 25);
            dateCreatedLabel.TabIndex = 2;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // fullAddressLabel
            // 
            fullAddressLabel.AutoSize = true;
            fullAddressLabel.Location = new System.Drawing.Point(76, 131);
            fullAddressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            fullAddressLabel.Name = "fullAddressLabel";
            fullAddressLabel.Size = new System.Drawing.Size(138, 25);
            fullAddressLabel.TabIndex = 4;
            fullAddressLabel.Text = "Full Address:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(76, 190);
            fullNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(115, 25);
            fullNameLabel.TabIndex = 6;
            fullNameLabel.Text = "Full Name:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(76, 61);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(177, 25);
            accountNumberLabel.TabIndex = 2;
            accountNumberLabel.Text = "Account Number:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(730, 64);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(96, 25);
            balanceLabel.TabIndex = 4;
            balanceLabel.Text = "Balance:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(676, 124);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(150, 25);
            descriptionLabel.TabIndex = 6;
            descriptionLabel.Text = "Account Type:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(76, 192);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(74, 25);
            notesLabel.TabIndex = 8;
            notesLabel.Text = "Notes:";
            // 
            // descriptionLabel2
            // 
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Location = new System.Drawing.Point(76, 123);
            descriptionLabel2.Name = "descriptionLabel2";
            descriptionLabel2.Size = new System.Drawing.Size(68, 25);
            descriptionLabel2.TabIndex = 10;
            descriptionLabel2.Text = "State:";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(clientNumberLabel);
            this.grpClient.Controls.Add(this.clientNumberMaskedTextBox);
            this.grpClient.Controls.Add(dateCreatedLabel);
            this.grpClient.Controls.Add(this.lblDateCreated);
            this.grpClient.Controls.Add(fullAddressLabel);
            this.grpClient.Controls.Add(this.lblFullAddress);
            this.grpClient.Controls.Add(fullNameLabel);
            this.grpClient.Controls.Add(this.lblFullName);
            this.grpClient.Location = new System.Drawing.Point(110, 42);
            this.grpClient.Margin = new System.Windows.Forms.Padding(6);
            this.grpClient.Name = "grpClient";
            this.grpClient.Padding = new System.Windows.Forms.Padding(6);
            this.grpClient.Size = new System.Drawing.Size(1268, 308);
            this.grpClient.TabIndex = 0;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Data";
            // 
            // clientNumberMaskedTextBox
            // 
            this.clientNumberMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.clientNumberMaskedTextBox.Location = new System.Drawing.Point(286, 71);
            this.clientNumberMaskedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.clientNumberMaskedTextBox.Mask = "0000-0000";
            this.clientNumberMaskedTextBox.Name = "clientNumberMaskedTextBox";
            this.clientNumberMaskedTextBox.Size = new System.Drawing.Size(232, 31);
            this.clientNumberMaskedTextBox.TabIndex = 1;
            this.clientNumberMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.clientNumberMaskedTextBox.Leave += new System.EventHandler(this.clientNumberMaskedTextBox_Leave_1);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT_YZ.Models.Client);
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateCreated.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "DateCreated", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.lblDateCreated.Location = new System.Drawing.Point(286, 250);
            this.lblDateCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(236, 37);
            this.lblDateCreated.TabIndex = 3;
            // 
            // lblFullAddress
            // 
            this.lblFullAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullAddress", true));
            this.lblFullAddress.Location = new System.Drawing.Point(286, 131);
            this.lblFullAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullAddress.Name = "lblFullAddress";
            this.lblFullAddress.Size = new System.Drawing.Size(834, 37);
            this.lblFullAddress.TabIndex = 5;
            // 
            // lblFullName
            // 
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.lblFullName.Location = new System.Drawing.Point(286, 190);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(834, 37);
            this.lblFullName.TabIndex = 7;
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(descriptionLabel2);
            this.grpAccount.Controls.Add(this.lblState);
            this.grpAccount.Controls.Add(accountNumberLabel);
            this.grpAccount.Controls.Add(this.cboAccountNumber);
            this.grpAccount.Controls.Add(balanceLabel);
            this.grpAccount.Controls.Add(this.lblBalance);
            this.grpAccount.Controls.Add(descriptionLabel);
            this.grpAccount.Controls.Add(this.lblAccountType);
            this.grpAccount.Controls.Add(notesLabel);
            this.grpAccount.Controls.Add(this.lblNotes);
            this.grpAccount.Controls.Add(this.lnkDetails);
            this.grpAccount.Controls.Add(this.lnkProcess);
            this.grpAccount.Location = new System.Drawing.Point(110, 363);
            this.grpAccount.Margin = new System.Windows.Forms.Padding(6);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Padding = new System.Windows.Forms.Padding(6);
            this.grpAccount.Size = new System.Drawing.Size(1268, 429);
            this.grpAccount.TabIndex = 1;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Bank Account Data";
            // 
            // lblState
            // 
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountState.Description", true));
            this.lblState.Location = new System.Drawing.Point(286, 123);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(236, 41);
            this.lblState.TabIndex = 11;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_YZ.Models.BankAccount);
            // 
            // cboAccountNumber
            // 
            this.cboAccountNumber.DataSource = this.bankAccountBindingSource;
            this.cboAccountNumber.DisplayMember = "AccountNumber";
            this.cboAccountNumber.FormattingEnabled = true;
            this.cboAccountNumber.Location = new System.Drawing.Point(286, 53);
            this.cboAccountNumber.Name = "cboAccountNumber";
            this.cboAccountNumber.Size = new System.Drawing.Size(236, 33);
            this.cboAccountNumber.TabIndex = 3;
            this.cboAccountNumber.ValueMember = "BankAccountId";
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblBalance.Location = new System.Drawing.Point(870, 64);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(250, 41);
            this.lblBalance.TabIndex = 5;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAccountType
            // 
            this.lblAccountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccountType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Description", true));
            this.lblAccountType.Location = new System.Drawing.Point(870, 123);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(250, 41);
            this.lblAccountType.TabIndex = 7;
            // 
            // lblNotes
            // 
            this.lblNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Notes", true));
            this.lblNotes.Location = new System.Drawing.Point(286, 194);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(834, 144);
            this.lblNotes.TabIndex = 9;
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Location = new System.Drawing.Point(770, 354);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(130, 25);
            this.lnkDetails.TabIndex = 1;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Location = new System.Drawing.Point(320, 354);
            this.lnkProcess.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(209, 25);
            this.lnkProcess.TabIndex = 0;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Transaction";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // ClientData
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 865);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.grpClient);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ClientData";
            this.Text = "ClientData";
            this.Load += new System.EventHandler(this.ClientData_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.MaskedTextBox clientNumberMaskedTextBox;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblFullAddress;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cboAccountNumber;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblState;
    }
}