/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/grepify

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win.Grepify
{
    public partial class frmSearch : Form
    {

        private ListView lstResults = null;

        /// <summary>
        /// search the list review
        /// </summary>
        /// <param name="strSearch"></param>
        public void searchList(string strSearch)
        {
            int intCount = 0;
            int intCount2 = 0;
            int intRes = 0;

            if (this.InvokeRequired)
            {
                lstResults.Invoke(new MethodInvoker(() => { searchList(strSearch); }));
            }
            else
            {

                // Reset
                for (intCount2 = 0; intCount2 < lstResults.Items.Count; intCount2++)
                {
                    lstResults.Items[intCount2].Selected = false;
                    intRes = 0;
                }

                // Now..
                for (intCount = 0; intCount < lstResults.Columns.Count; intCount++)
                {


                    for (intCount2 = 0; intCount2 < lstResults.Items.Count; intCount2++)
                    {
                        ListViewItem selItem = lstResults.Items[intCount2];

                        string strTemp = selItem.SubItems[intCount].Text;

                        if (strTemp.ToLower().Contains(strSearch.ToLower()) == true)
                        {
                            lstResults.Items[intCount2].Selected = true;
                            intRes++;
                        }
                    }
                }

            }

            if (intRes == 0)
            {
                MessageBox.Show("No matching results found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();

            }
        }

        public frmSearch(ListView lstMainResults)
        {
            InitializeComponent();
            this.lstResults = lstMainResults;
            KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchList(this.txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                searchList(this.txtSearch.Text);
            }
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Visible = false;
                this.Close();
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
