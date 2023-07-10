namespace WindowsBanking
{
    partial class BatchProcess
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
            System.Windows.Forms.Label descriptionLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboInstitution = new System.Windows.Forms.ComboBox();
            this.institutionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.radSelect = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.institutionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(165, 228);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(0, 25);
            descriptionLabel.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(descriptionLabel);
            this.groupBox1.Controls.Add(this.cboInstitution);
            this.groupBox1.Controls.Add(this.lnkProcess);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.radSelect);
            this.groupBox1.Controls.Add(this.radAll);
            this.groupBox1.Location = new System.Drawing.Point(62, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1412, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transmission Selection";
            // 
            // cboInstitution
            // 
            this.cboInstitution.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.institutionBindingSource, "Description", true));
            this.cboInstitution.DataSource = this.institutionBindingSource;
            this.cboInstitution.DisplayMember = "Description";
            this.cboInstitution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstitution.FormattingEnabled = true;
            this.cboInstitution.Location = new System.Drawing.Point(106, 211);
            this.cboInstitution.Name = "cboInstitution";
            this.cboInstitution.Size = new System.Drawing.Size(257, 33);
            this.cboInstitution.TabIndex = 6;
            this.cboInstitution.ValueMember = "InstitutionNumber";
            // 
            // institutionBindingSource
            // 
            this.institutionBindingSource.DataSource = typeof(BankOfBIT_YZ.Models.Institution);
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Location = new System.Drawing.Point(108, 306);
            this.lnkProcess.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(224, 25);
            this.lnkProcess.TabIndex = 4;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Transmission";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1044, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter Key:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(962, 125);
            this.txtKey.Margin = new System.Windows.Forms.Padding(6);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(274, 31);
            this.txtKey.TabIndex = 2;
            // 
            // radSelect
            // 
            this.radSelect.AutoSize = true;
            this.radSelect.Location = new System.Drawing.Point(108, 125);
            this.radSelect.Margin = new System.Windows.Forms.Padding(6);
            this.radSelect.Name = "radSelect";
            this.radSelect.Size = new System.Drawing.Size(255, 29);
            this.radSelect.TabIndex = 1;
            this.radSelect.TabStop = true;
            this.radSelect.Text = "Select a Transmission";
            this.radSelect.UseVisualStyleBackColor = true;
            this.radSelect.CheckedChanged += new System.EventHandler(this.radSelect_CheckedChanged);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(106, 67);
            this.radAll.Margin = new System.Windows.Forms.Padding(6);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(257, 29);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "Run All Transmissions";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(62, 504);
            this.rtxtLog.Margin = new System.Windows.Forms.Padding(6);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(1408, 504);
            this.rtxtLog.TabIndex = 1;
            this.rtxtLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 444);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transmission Log:";
            // 
            // BatchProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 1054);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BatchProcess";
            this.Text = "BatchProcess";
            this.Load += new System.EventHandler(this.BatchProcess_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.institutionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.RadioButton radSelect;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboInstitution;
        private System.Windows.Forms.BindingSource institutionBindingSource;
    }
}