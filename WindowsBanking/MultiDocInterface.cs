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
    public partial class MultiDocInterface : Form
    {
        public MultiDocInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open the client form within the current mdi frame.
        /// </summary>
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientData client = new ClientData();
            client.MdiParent = this;
            client.Show();
        }

        /// <summary>
        /// Open the Batch Process form within the current mdi frame.
        /// </summary>
        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatchProcess batchProcess = new BatchProcess();
            batchProcess.MdiParent = this;
            batchProcess.Show();
        }

        /// <summary>
        /// Close the mdi frame and any open windows within the frame.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

