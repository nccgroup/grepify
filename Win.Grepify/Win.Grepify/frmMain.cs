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
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Win.Grepify
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public bool bScanRunning = false;
        public bool bScanStopped = false;
        private string[] profileLines = null;
        private ListViewColumnSorter lvwColumnSorter;
        Scanner myScanner = null;

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
                if (MessageBox.Show("Are you sure you wish to exit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string strVersion = fvi.FileVersion;

            this.Text = "NCC Group Grepify - " + strVersion;

            loadProfileToolStripMenuItem.Text = "&Load\nProfile";
            scanToolStripMenuItem.Text = "&Start\nScan";
            resetResultsToolStripMenuItem.Text = "&Reset\nResults";
            ListViewHelper.EnableDoubleBuffer(listResults);
            lvwColumnSorter = new ListViewColumnSorter();
            this.listResults.ListViewItemSorter = lvwColumnSorter;
            KeyPreview = true;


            if (Screen.PrimaryScreen.Bounds.Width < 1165)
            {
                MessageBox.Show("Screen resolution too low. Some menu icons may be missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Used to sort the ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bScanRunning == true)
            {
                if (MessageBox.Show("Scan already running, would you like to stop it and load a new code profile?", "Scan running", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    myScanner.Stop();
                    
                }
                else
                {
                    return;
                }
            }

            OpenFileDialog ofdLoad = new OpenFileDialog();
            ofdLoad.CheckFileExists = true;
            ofdLoad.CheckPathExists = true;
            ofdLoad.AutoUpgradeEnabled = true;
            ofdLoad.Multiselect = true;
            ofdLoad.DefaultExt = "*.txt";
            ofdLoad.Title = "Select code profile to load";

            if (ofdLoad.ShowDialog() == DialogResult.OK)
            {
                string strTitle = "NCC Group Grepify - ";
                string[] strNewLines = null;
                List<string> strRegexs = new List<string>();
                profileLines = null;
                this.Text = strTitle;
                bool bError = false;

                foreach (string strFilename in ofdLoad.FileNames)
                {
                    if (!File.Exists(strFilename))
                    {

                        MessageBox.Show("File " + strFilename + " does not exist", "File does not exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;

                    }
                    else
                    {
                        try
                        {
                            strNewLines = File.ReadAllLines(strFilename);
                        }
                        catch (FileNotFoundException)
                        {
                            MessageBox.Show("File not found", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DirectoryNotFoundException)
                        {
                            MessageBox.Show("Directory not found", "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            MessageBox.Show("Unable to access file", "Unable to access file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unknown error", "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        strTitle += strFilename + " ";
                        this.Text = strTitle;

                        // Sanity check the regex
                        int intCount = 0;
                        foreach (string strRegex in strNewLines)
                        {

                            intCount++;

                            if (strRegex.StartsWith("#")) continue;

                            try
                            {
                                Match regexMatch = Regex.Match("Mooo", strRegex);
                                strRegexs.Add(strRegex); 
                            }
                            catch (ArgumentException rExcp)
                            {
                                MessageBox.Show("Regex looks broken on line " + intCount + ". Regex is '" + strRegex + "'. Error is '" + rExcp.Message + "' in file " + strFilename + ".", "Regex error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                profileLines = null;
                                bError = true;
                                break;
                            }
                        }

                        if (profileLines == null && bError == false)
                        {
                            profileLines = strRegexs.ToArray();
                        }
                        else if(bError == false)
                        {
                            profileLines = profileLines.Concat(strRegexs).ToArray();
                        }

                    }
                }
            }
            else
            {

            }

        }

        private void mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void UpdateList(string strPath, string strFile, string strExt, string strHit, int intLineNumber, string strLine)
        {

            if (this.InvokeRequired)
            {
                listResults.Invoke(new MethodInvoker(() => { UpdateList(strPath, strFile, strExt, strHit, intLineNumber, strLine); }));
            }
            else
            {
                ListViewItem itemNew = new ListViewItem();

                itemNew.Text = strPath;
                itemNew.SubItems.Add(strFile);
                itemNew.SubItems.Add(strExt);
                itemNew.SubItems.Add(strHit);
                itemNew.SubItems.Add(intLineNumber.ToString());
                itemNew.SubItems.Add(strLine);

                listResults.Items.Add(itemNew);
            }

        }

        /// <summary>
        /// Update the progress bar
        /// </summary>
        public void UpdateProgess()
        {

            
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(UpdateProgess));
            }
            else
            {
                this.prgMain.Value = this.prgMain.Value + 1;
                this.statusMain.Invalidate();
                this.Invalidate();
            }
             
        }

        private void listResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (bScanRunning == true)
            {
                MessageBox.Show("Can't sort while scan running due to performance issues", "Can't sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listResults.Sort();
        }

        public void ScanStopping()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(ScanStopping));
            }
            else
            {
                lblStatus.Text = "Queue processing..";
                lblStatus.Invalidate();
            }
        }

        public void ScanStopped()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(ScanStopped));
            } 
            else 
            {
                /*
                lblStatus.Text = "Removing duplicates..";

                List<ListViewItem> toRemove = new List<ListViewItem>();
                foreach (ListViewItem iCompare1 in listResults.Items)
                {
                    foreach (ListViewItem iCompare2 in listResults.Items)
                    {

                        if (
                            iCompare1.Text.CompareTo(iCompare2.Text) == 0 &&
                            iCompare1.SubItems[0].ToString().CompareTo(iCompare2.SubItems[0].ToString()) == 0 &&
                            iCompare1.SubItems[1].ToString().CompareTo(iCompare2.SubItems[1].ToString()) == 0 &&
                            iCompare1.SubItems[3].ToString().CompareTo(iCompare2.SubItems[3].ToString()) == 0 &&
                            iCompare1.SubItems[4].ToString().CompareTo(iCompare2.SubItems[4].ToString()) == 0
                            )
                        {
                            listResults.Items.Remove(iCompare2);
                        }
                        
                        
                    }
                }    
                */

                lblStatus.Text = "Idle";
                prgMain.Value = 0;
                scanToolStripMenuItem.Text = "&Start\nScan";
                bScanRunning = false;
                //listResults.Enabled = true;
                this.listResults.ListViewItemSorter = lvwColumnSorter;
                this.Invalidate();
                this.listResults.Invalidate();
                this.mnuMain.Invalidate();
                //listResults.Visible = true;
                //this.mnuMain.Enabled = true;
            }
            
        }

        private void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bScanRunning == true)
            {
                this.Invalidate();
                lblStatus.Text = "Stopping..";
                myScanner.Stop();
            }
            else
            {
                if(profileLines == null){
                    MessageBox.Show("Please load a code profile","Code profile not loaded",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }


                FolderBrowserDialog fbdDir = new FolderBrowserDialog();
                fbdDir.Description = "Please select the directory to scan";
                if (Properties.Settings.Default.LastPathSelected != null)
                {
                    fbdDir.SelectedPath = Properties.Settings.Default.LastPathSelected; 
                }

                if (fbdDir.ShowDialog() == DialogResult.Cancel) return;

                if (Directory.Exists(fbdDir.SelectedPath))
                {
                    int intTotalFiles = 0;
                    lblStatus.Text = "Counting files...";
                    lblStatus.Invalidate();
                    string[] strFilesNoo = null;

                    if (Properties.Settings.Default.ExtensionsLimit == true)
                    {
                        foreach(string strExt in Properties.Settings.Default.Extensions){
                            strFilesNoo = Directory.GetFiles(fbdDir.SelectedPath, strExt , SearchOption.AllDirectories);
                            intTotalFiles += strFilesNoo.Count();
                        }
                    }
                    else
                    {
                        strFilesNoo = Directory.GetFiles(fbdDir.SelectedPath, "*.*", SearchOption.AllDirectories);
                        intTotalFiles += strFilesNoo.Count();
                    }
                    
                    prgMain.Maximum = intTotalFiles;
                    bScanRunning = true;
                    bScanStopped = false;
                    myScanner = new Scanner();
                    Properties.Settings.Default.LastPathSelected = fbdDir.SelectedPath;
                    Properties.Settings.Default.Save();
                    if(Properties.Settings.Default.ExtensionsLimit == true){
                        string[] strExts = null; 
                        strExts = new string[Properties.Settings.Default.Extensions.Count];
                        Properties.Settings.Default.Extensions.CopyTo(strExts, 0);
                        myScanner.Start(profileLines, fbdDir.SelectedPath, strExts , this);
                    } else {
                        string[] strAllExt = new string[]{"*.*"};
                        myScanner.Start(profileLines, fbdDir.SelectedPath, strAllExt, this);
                    }
                    
                    scanToolStripMenuItem.Text = "&Stop\nScan";
                    lblStatus.Text = "Scanning...";
                    lblStatus.Invalidate();
                    this.listResults.ListViewItemSorter = null;
                    //listResults.Enabled = false;
                    //listResults.Visible = false;
                    //this.mnuMain.Enabled = false;4
                }
                else
                {
                    MessageBox.Show("Directory " + fbdDir.SelectedPath + " does not exist", "Directory does not exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void resetResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bScanRunning == true)
            {
                MessageBox.Show("Please stop the current scan first", "Computer says no", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (MessageBox.Show("You sure you wish to reset the results table?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listResults.Items.Clear();
                }
            }
        }

        private void openInEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int intCount = 0;

            if (Properties.Settings.Default.EditorPath == null || (!File.Exists(Properties.Settings.Default.EditorPath)))
            {
                MessageBox.Show("Path to editor not configured, please select configure first", "Configuration needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listResults.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select an item", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (listResults.SelectedItems.Count > 1)
            {
                MessageBox.Show("Ensure only a single item is selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (intCount = 0; intCount < listResults.SelectedItems.Count; intCount++)
                {
                    ListViewItem selItem = listResults.SelectedItems[intCount];
                    string strFoo = selItem.SubItems[0].Text + "\\" + selItem.SubItems[1].Text;
                    //Console.WriteLine(strFoo);

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = Properties.Settings.Default.EditorPath;

                    string strArgs = Properties.Settings.Default.EditorCommandLine;

                    try{
                        strArgs = strArgs.Replace("{line}",selItem.SubItems[4].Text);
                    } catch(Exception){

                    }

                    try
                    {
                        strArgs = strArgs.Replace("{file}", strFoo);
                    }
                    catch (Exception)
                    {

                    }

                    startInfo.Arguments = strArgs;

                    Process.Start(startInfo);
                }
            }
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frmConfig = new frmConfigure();
            frmConfig.Visible = true;

        }

        private void showInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // woof
            int intCount = 0;

            if (listResults.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select an item", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (listResults.SelectedItems.Count > 1)
            {
                MessageBox.Show("Ensure only a single item is selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (intCount = 0; intCount < listResults.SelectedItems.Count; intCount++)
                {
                    ListViewItem selItem = listResults.SelectedItems[intCount];
                    string strFoo = selItem.SubItems[0].Text.ToString() + "\\" + selItem.SubItems[1].Text.ToString(); // filename
                    if (strFoo == "N/A")
                    {
                        MessageBox.Show("No filename for this file", "No Manifest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    strFoo.Replace(@"\", @"\\");
                    ShowSelectedInExplorer.FileOrFolder(strFoo, false);
                }
            }
        }

        /// <summary>
        /// Exports the results from the list view to a file
        /// </summary>
        /// <param name="strOutfile">the filename to output to</param>
        /// <returns></returns>
        private bool Export(string strOutfile)
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
            for (intCount = 0; intCount < this.listResults.Columns.Count; intCount++)
            {
                string strOut = this.listResults.Columns[intCount].Text;
                strOut = strOut.Replace("\r", string.Empty);
                strOut = strOut.Replace("\n", string.Empty);
                strOut = strOut.Replace("\r\n", string.Empty);
                strOut = strOut.Replace((char)0x0A, (char)0x20);
                strOut = strOut.Replace(Environment.NewLine, string.Empty);
                swOut.Write(strOut + ",");
            }
            swOut.Write(Environment.NewLine);

            ExportListView(swOut, this.listResults);

            swOut.Close();
            swOut.Dispose();

            return true;
        }

        /// <summary>
        /// Exports a given list view
        /// </summary>
        /// <param name="swOut"></param>
        /// <param name="lstResults"></param>
        private void ExportListView(StreamWriter swOut, ListView lstResults)
        {
            int intCount = 0;
            int intCount2 = 0;

            if (this.InvokeRequired)
            {
                lstResults.Invoke(new MethodInvoker(() => { ExportListView(swOut, lstResults); }));
            }
            else
            {
                for (intCount = 0; intCount < listResults.Items.Count; intCount++)
                {
                    ListViewItem selItem = listResults.Items[intCount];

                    swOut.Write(selItem.Text + ",");
                    //swOut.Write(intCount + ",");

                    for (intCount2 = 1; intCount2 < selItem.SubItems.Count; intCount2++)
                    {
                        string strTemp = selItem.SubItems[intCount2].Text;

                        strTemp = strTemp.Replace(Environment.NewLine, ";");
                        strTemp = strTemp.Replace(Environment.NewLine, ";");
                        strTemp = strTemp.Replace(",", ";");
                        strTemp = strTemp.Replace("\r", ";");
                        strTemp = strTemp.Replace("\n", ";");
                        strTemp = strTemp.Replace("\r\n", ";");
                        strTemp = strTemp.Replace((char)0x0A, (char)0x3b);
                        strTemp = strTemp.Replace(Environment.NewLine, ";");

                        swOut.Write(strTemp + ",");
                    }

                    swOut.WriteLine();
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create new SaveFileDialog object
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.DefaultExt = "csv";
            DialogSave.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            DialogSave.AddExtension = true;
            DialogSave.RestoreDirectory = true;
            DialogSave.Title = "Where do you want to save the file?";
            if (DialogSave.ShowDialog() == DialogResult.OK)
            {
                Export(DialogSave.FileName);
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

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString().Equals("F"))
            {
                //Console.WriteLine("Search");
                Form frmSearch = new frmSearch(this.listResults);
                frmSearch.Visible = true;
            }
            else if (e.Control && e.KeyCode.ToString().Equals("Z"))
            {
                if(MessageBox.Show("Are you sure you want to erase your configuration?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes){
                    Properties.Settings.Default.EditorPath = "";
                    Properties.Settings.Default.EditorCommandLine = "";
                    Properties.Settings.Default.ExtensionsLimit = false;
                    Properties.Settings.Default.Extensions = null;
                    Properties.Settings.Default.LastPathSelected = "";
                    Properties.Settings.Default.Comments = false;
                    Properties.Settings.Default.CaseSensitive = false;
                    Properties.Settings.Default.TestFilenames = false;
                    Properties.Settings.Default.Save();
                }
            }
            else if (e.Control && e.KeyCode.ToString().Equals("D"))
            {
                string strOut = "Ed Path :" + Properties.Settings.Default.EditorPath + Environment.NewLine +
                                "Ed CL   :" + Properties.Settings.Default.EditorCommandLine + Environment.NewLine +
                                "Ext Lim :" + Properties.Settings.Default.ExtensionsLimit.ToString() + Environment.NewLine +
                                "Exts    :" + Properties.Settings.Default.Extensions.ToString() + Environment.NewLine +
                                "LastPath:" + Properties.Settings.Default.LastPathSelected +
                                "Case    :" + Properties.Settings.Default.CaseSensitive +
                                "Test FNa:" + Properties.Settings.Default.TestFilenames +
                                "Comments:" + Properties.Settings.Default.Comments;

                MessageBox.Show(strOut, "Current config", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
            else if (e.Control && e.KeyCode.ToString().Equals("P"))
            {
                StringBuilder strOut = new StringBuilder();

                if (profileLines == null) return;

                foreach (string strLine in profileLines)
                {
                    if (strOut.Length == 0)
                    {
                        strOut.Append(strLine);
                    }
                    else
                    {
                        strOut.Append("\n");
                        strOut.Append(strLine);
                    }                    
                }

                MessageBox.Show(strOut.ToString(), "Current config", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void statusMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
