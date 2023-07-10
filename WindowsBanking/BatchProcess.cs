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
    public partial class BatchProcess : Form
    {
        //Define an instance of the BankOfBIT_YZContext class.
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        public BatchProcess()
        {
            InitializeComponent();

            institutionBindingSource.DataSource = db.Institutions.ToList();
        }

        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void BatchProcess_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
        }

        /// <summary>
        ///  This event handler is to process transmissions when lnkProcess is clinked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //given:  Ensure key has been entered.  Note: for use with Assignment 9
            //if(txtKey.Text.Length == 0)
            //{
            //    MessageBox.Show("Please enter a key to decrypt the input file(s).", "Key Required");
            //}

            if (radSelect.Checked)
            {
                Batch batch = new Batch();

                batch.ProcessTransmission(cboInstitution.SelectedValue.ToString(), txtKey.Text);

                rtxtLog.Text += batch.WriteLogData();
            }

            if (radAll.Checked)
            {
                foreach(Institution institution in db.Institutions.ToList())
                {
                    Batch batch = new Batch();

                    batch.ProcessTransmission(institution.InstitutionNumber.ToString(), txtKey.Text);

                    rtxtLog.Text += batch.WriteLogData();
                }
            }
        }

        /// <summary>
        /// This event handler is to enable cboInstitution when radSelect is checked.
        /// </summary>
        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelect.Checked)
            {
                cboInstitution.Enabled = true;
            }
            else
            {
                cboInstitution.Enabled = false;
            }
        }

        /// <summary>
        /// This event handler is to disable cboInstitution when radAllis checked.
        /// </summary>
        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                cboInstitution.Enabled = false;
            }
            else
            {
                cboInstitution.Enabled = true;
            }
        }
    }
}
