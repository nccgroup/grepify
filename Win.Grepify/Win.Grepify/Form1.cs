using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Win.Grepify
{
    public partial class frmMain : Form
    {
        bool bScanRunning = false;
        string[] profileLines = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (bScanRunning == true)
            {
                if (MessageBox.Show("Scan running as you sure you wish to exit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdLoad = new OpenFileDialog();

            ofdLoad.CheckFileExists = true;
            ofdLoad.CheckPathExists = true;
            ofdLoad.AutoUpgradeEnabled = true;
            ofdLoad.DefaultExt = "grpfy";
            ofdLoad.Title = "Select code profile to load";

            if (ofdLoad.ShowDialog() == DialogResult.OK)
            {
                File fileFile = new File(
                

                if (!File.Exists(ofdLoad.FileName))
                {
                    
                } else {
                    File.ReadAllLines(path);
                }

                
                // Open the file to read from.
                
            }
            else
            {

            }

        }
    }
}
