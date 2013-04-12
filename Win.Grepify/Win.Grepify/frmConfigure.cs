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
using System.IO;
using System.Text.RegularExpressions;

namespace Win.Grepify
{
    public partial class frmConfigure : Form
    {

        private Properties.Settings lpropSettings = null;

        public frmConfigure()
        {
            InitializeComponent();
            lpropSettings = Properties.Settings.Default;

            txtProgram.Text = lpropSettings.EditorPath;
            txtCmdLine.Text = lpropSettings.EditorCommandLine;

            if (lpropSettings.CaseSensitive == true) chkCase.Checked = true;
            if (lpropSettings.TestFilenames == true) chkTestFilename.Checked = true;
            if (lpropSettings.Comments == true) chkComments.Checked = true;
            if (lpropSettings.TestPath == true) chkTestPath.Checked = true;

            if (lpropSettings.CommentsRegex != null)
            {
                lstCommentLines.Items.Clear();
                foreach (object lstItem in Properties.Settings.Default.CommentsRegex)
                {
                    lstCommentLines.Items.Add(lstItem);
                }
            }

            if (lpropSettings.Comments == true)
            {
                txtComRegex.Enabled = true;
                cmdAdd.Enabled = true;
                lstCommentLines.Enabled = true;
                cmdFromFile.Enabled = true;
                cmdExportTo.Enabled = true;
            }
            else
            {
                txtComRegex.Enabled = false;
                cmdAdd.Enabled = false;
                lstCommentLines.Enabled = false;
                cmdFromFile.Enabled = false;
                cmdExportTo.Enabled = false;
            }

            if (lpropSettings.ExtensionsLimit == true)
            {
                if (lpropSettings.Extensions != null)
                {
                    chkExt.Checked = true;
                    string[] strExts = new string[lpropSettings.Extensions.Count];
                    lpropSettings.Extensions.CopyTo(strExts, 0);
                    StringBuilder strOut = new StringBuilder();
                    foreach (string strExt in strExts)
                    {
                        if (strOut.Length == 0)
                        {
                            strOut.Append(strExt);
                        }
                        else
                        {
                            strOut.Append(";");
                            strOut.Append(strExt);
                        }
                    }
                    txtExts.Text = strOut.ToString();
                    cmbExts.Enabled = true;
                }
                else
                {
                    cmbExts.Enabled = false;
                    chkExt.Checked = false;
                    txtExts.Enabled = false;
                }
            }
            else
            {
                chkExt.Checked = false;
                txtExts.Enabled = false;
                cmbExts.Enabled = false;
            }

            KeyPreview = true;
        }

        private void frmConfigure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Visible = false;
                this.Close();
            }
        }

        private void cmdSave(object sender, EventArgs e)
        {

            if (txtCmdLine.Text.Length > 0 && txtCmdLine.Text.Contains("{file}") == false)
            {
                MessageBox.Show("You must use the {file} macro in the command line", "File macor not used", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtCmdLine.Text.Length > 0)
            {

                lpropSettings.EditorPath = txtProgram.Text;
                lpropSettings.EditorCommandLine = txtCmdLine.Text;
            }


            if (chkExt.Checked == true)
            {
                if (lpropSettings.Extensions == null)
                {
                    lpropSettings.Extensions = new System.Collections.Specialized.StringCollection();
                }
                else
                {
                    lpropSettings.Extensions.Clear();
                }

                string[] strExts = txtExts.Text.Split(';');
                foreach (string strExt in strExts)
                {
                    if (strExt.StartsWith("*.") == false)
                    {
                        MessageBox.Show(txtExts.Text + " is not in the correct format\nPlease use *.ext1;*.ext2\nSetting's wont be saved!", "Incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                foreach (string strExt in strExts)
                {
                    lpropSettings.Extensions.Add(strExt);
                }
                lpropSettings.ExtensionsLimit = true;
            }
            else
            {
                lpropSettings.ExtensionsLimit = false;
            }

            if (chkTestFilename.Checked == true)
            {
                lpropSettings.TestFilenames = true;
            }
            else
            {
                lpropSettings.TestFilenames = false;
            }

            if (chkCase.Checked == true)
            {
                lpropSettings.CaseSensitive = true;
            }
            else
            {
                lpropSettings.CaseSensitive = false;
            }

            if (chkComments.Checked == true)
            {
                lpropSettings.Comments = true;
            }
            else
            {
                lpropSettings.Comments = false;
            }

            if (chkTestPath.Checked == true)
            {
                lpropSettings.TestPath = true;
            }
            else
            {
                lpropSettings.TestPath = false;
            }

            if(Properties.Settings.Default.CommentsRegex != null) Properties.Settings.Default.CommentsRegex.Clear();
            else Properties.Settings.Default.CommentsRegex = new System.Collections.Specialized.StringCollection();

            foreach (object lstItem in lstCommentLines.Items)
            {
                Properties.Settings.Default.CommentsRegex.Add(lstItem.ToString());
            }

            Properties.Settings.Default.Save();

 


            lpropSettings.Save();
            this.Close();
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void frmConfigure_Load(object sender, EventArgs e)
        {

        }

        private void chkExt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExt.Checked == true)
            {
                txtExts.Enabled = true;
                cmbExts.Enabled = true;
            }
            else
            {
                txtExts.Enabled = false;
                cmbExts.Enabled = false;
            }
        }

        private void cmbCommandLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbCommandLines.SelectedIndex){
             
                case 0:
                    txtCmdLine.Text = "-n{line} \"{file}\"";
                    break;
                case 1:
                    txtCmdLine.Text = "\"{file}\"/{line}";
                    break;
            }


        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdEditor = new OpenFileDialog();

            fdEditor.CheckFileExists = true;
            fdEditor.DefaultExt = ".exe";
            fdEditor.Filter = "Executables|*.exe";
            fdEditor.Title = "Please select your editor";

            if (txtProgram.Text != "")
            {
                
            }

            if (fdEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtProgram.Text = fdEditor.FileName;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Match regexMatch = Regex.Match("Mooo", txtComRegex.Text);               
                lstCommentLines.Items.Add(txtComRegex.Text);

            }
            catch (ArgumentException rExcp)
            {
                MessageBox.Show("Regex looks broken, it is '" + txtComRegex.Text + "'. Error is '" + rExcp.Message + "'", "Regex error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstCommentLines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdDeleteItem_Click(object sender, EventArgs e)
        {
            int intCount = 0;

            if (lstCommentLines.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select an item", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             else if (lstCommentLines.SelectedItems.Count > 1)
             {
                 MessageBox.Show("Ensure only a single item is selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
             else
             {
                 for (intCount = 0; intCount < lstCommentLines.SelectedItems.Count; intCount++)
                 {
                     Object objToDel = (Object)lstCommentLines.SelectedItems[intCount];
                     lstCommentLines.Items.Remove(objToDel);
                 }
             }
        }

        private void chkComments_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComments.Checked == true)
            {
                txtComRegex.Enabled = true;
                cmdAdd.Enabled = true;
                lstCommentLines.Enabled = true;
                cmdFromFile.Enabled = true;
                cmdExportTo.Enabled = true;
                
            }
            else
            {
                txtComRegex.Enabled = false;
                cmdAdd.Enabled = false;
                lstCommentLines.Enabled = false;
                cmdFromFile.Enabled = false;
                cmdExportTo.Enabled = false;
            }
        }

        private bool SaveComments(string strOutfile)
        {
            StreamWriter swOut = null;

            try
            {
                swOut = new StreamWriter(strOutfile);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Could not open " + strOutfile + " access was denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int intCount = 0;
            for (intCount = 0; intCount < this.lstCommentLines.Items.Count; intCount++)
            {
                string strOut = this.lstCommentLines.Items[intCount].ToString();
                if(strOut.Length > 0) swOut.Write(strOut + Environment.NewLine);
            }

            swOut.Close();
            swOut.Dispose();

            return true;
        }

        private void cmdExportTo_Click(object sender, EventArgs e)
        {
            // Create new SaveFileDialog object
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.DefaultExt = "grepify";
            DialogSave.Filter = "GREPIFY (*.grepify)|*.grepify|All files (*.*)|*.*";
            DialogSave.AddExtension = true;
            DialogSave.RestoreDirectory = true;
            DialogSave.Title = "Which file do you want to export to?";
            if (DialogSave.ShowDialog() == DialogResult.OK)
            {
                SaveComments(DialogSave.FileName);
            }
            else
            {
                DialogSave.Dispose();
                DialogSave = null;
                return;
            }

            DialogSave.Dispose();
            DialogSave = null;
        }

        private bool LoadComments(string strInfile)
        {
            StreamReader swIn = null;
            bool bReplace = false;

            if (MessageBox.Show("Do you want to append these comments to the existing? "+ Environment.NewLine+"Selecting yes will append, selecting no will replace.", "Do you want to append to the current?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) bReplace = true;

            try
            {
                swIn = new StreamReader(strInfile);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Could not open " + strInfile + " access was denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (bReplace) lstCommentLines.Items.Clear();

            int intCount = 0;
            string strLine = null;
            while ((strLine = swIn.ReadLine()) != null)
            {
                intCount++;

                try
                {
                    Match regexMatch = Regex.Match("Mooo", strLine);
                    lstCommentLines.Items.Add(strLine);
                }
                catch (ArgumentException rExcp)
                {
                    MessageBox.Show("Regex looks broken, it is '" + strLine + "' (line "+intCount+"). Error is '" + rExcp.Message + "'", "Regex error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
            swIn.Close();
            swIn.Dispose();

            return true;
        }

        private void cmdFromFile_Click(object sender, EventArgs e)
        {
            // Create new OpenFileDialog object
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "grepify";
            DialogOpen.Filter = "GREPIFY (*.grepify)|*.grepify|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Which file do you want to import from?";
            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                LoadComments(DialogOpen.FileName);
            }
            else
            {
                DialogOpen.Dispose();
                DialogOpen = null;
                return;
            }

            DialogOpen.Dispose();
            DialogOpen = null;
        }
 
    }
}
