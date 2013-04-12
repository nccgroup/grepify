namespace Win.Grepify
{
    partial class frmConfigure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigure));
            this.button1 = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.grpEditor = new System.Windows.Forms.GroupBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.cmbCommandLines = new System.Windows.Forms.ComboBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.txtCmdLine = new System.Windows.Forms.TextBox();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpScan = new System.Windows.Forms.GroupBox();
            this.lstCommentLines = new System.Windows.Forms.ListBox();
            this.chkTestPath = new System.Windows.Forms.CheckBox();
            this.chkComments = new System.Windows.Forms.CheckBox();
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.chkTestFilename = new System.Windows.Forms.CheckBox();
            this.cmbExts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExts = new System.Windows.Forms.TextBox();
            this.chkExt = new System.Windows.Forms.CheckBox();
            this.lblExts = new System.Windows.Forms.Label();
            this.txtComRegex = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.ctxListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdFromFile = new System.Windows.Forms.Button();
            this.cmdExportTo = new System.Windows.Forms.Button();
            this.grpEditor.SuspendLayout();
            this.grpScan.SuspendLayout();
            this.ctxListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmdSave);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(275, 452);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // grpEditor
            // 
            this.grpEditor.Controls.Add(this.lblTip);
            this.grpEditor.Controls.Add(this.cmbCommandLines);
            this.grpEditor.Controls.Add(this.cmdSelect);
            this.grpEditor.Controls.Add(this.txtCmdLine);
            this.grpEditor.Controls.Add(this.txtProgram);
            this.grpEditor.Controls.Add(this.label2);
            this.grpEditor.Controls.Add(this.label1);
            this.grpEditor.Location = new System.Drawing.Point(23, 13);
            this.grpEditor.Name = "grpEditor";
            this.grpEditor.Size = new System.Drawing.Size(490, 110);
            this.grpEditor.TabIndex = 2;
            this.grpEditor.TabStop = false;
            this.grpEditor.Text = "Editor";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(9, 85);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(300, 13);
            this.lblTip.TabIndex = 6;
            this.lblTip.Text = "Note: {line} = line number and {file} = filename when launching";
            // 
            // cmbCommandLines
            // 
            this.cmbCommandLines.FormattingEnabled = true;
            this.cmbCommandLines.Items.AddRange(new object[] {
            "Notepad++",
            "Ultraedit"});
            this.cmbCommandLines.Location = new System.Drawing.Point(287, 51);
            this.cmbCommandLines.Name = "cmbCommandLines";
            this.cmbCommandLines.Size = new System.Drawing.Size(121, 21);
            this.cmbCommandLines.TabIndex = 5;
            this.cmbCommandLines.SelectedIndexChanged += new System.EventHandler(this.cmbCommandLines_SelectedIndexChanged);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(415, 17);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(61, 23);
            this.cmdSelect.TabIndex = 4;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // txtCmdLine
            // 
            this.txtCmdLine.Location = new System.Drawing.Point(89, 51);
            this.txtCmdLine.Name = "txtCmdLine";
            this.txtCmdLine.Size = new System.Drawing.Size(192, 20);
            this.txtCmdLine.TabIndex = 3;
            // 
            // txtProgram
            // 
            this.txtProgram.Location = new System.Drawing.Point(89, 19);
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.Size = new System.Drawing.Size(319, 20);
            this.txtProgram.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Command Line";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program Path";
            // 
            // grpScan
            // 
            this.grpScan.Controls.Add(this.cmdExportTo);
            this.grpScan.Controls.Add(this.cmdFromFile);
            this.grpScan.Controls.Add(this.cmdAdd);
            this.grpScan.Controls.Add(this.txtComRegex);
            this.grpScan.Controls.Add(this.lstCommentLines);
            this.grpScan.Controls.Add(this.chkTestPath);
            this.grpScan.Controls.Add(this.chkComments);
            this.grpScan.Controls.Add(this.chkCase);
            this.grpScan.Controls.Add(this.chkTestFilename);
            this.grpScan.Controls.Add(this.cmbExts);
            this.grpScan.Controls.Add(this.label3);
            this.grpScan.Controls.Add(this.txtExts);
            this.grpScan.Controls.Add(this.chkExt);
            this.grpScan.Controls.Add(this.lblExts);
            this.grpScan.Location = new System.Drawing.Point(23, 139);
            this.grpScan.Name = "grpScan";
            this.grpScan.Size = new System.Drawing.Size(490, 300);
            this.grpScan.TabIndex = 3;
            this.grpScan.TabStop = false;
            this.grpScan.Text = "Scan Configuration";
            // 
            // lstCommentLines
            // 
            this.lstCommentLines.ContextMenuStrip = this.ctxListBox;
            this.lstCommentLines.FormattingEnabled = true;
            this.lstCommentLines.Location = new System.Drawing.Point(160, 153);
            this.lstCommentLines.Name = "lstCommentLines";
            this.lstCommentLines.Size = new System.Drawing.Size(319, 134);
            this.lstCommentLines.TabIndex = 13;
            this.lstCommentLines.SelectedIndexChanged += new System.EventHandler(this.lstCommentLines_SelectedIndexChanged);
            // 
            // chkTestPath
            // 
            this.chkTestPath.AutoSize = true;
            this.chkTestPath.Location = new System.Drawing.Point(264, 105);
            this.chkTestPath.Name = "chkTestPath";
            this.chkTestPath.Size = new System.Drawing.Size(215, 17);
            this.chkTestPath.TabIndex = 12;
            this.chkTestPath.Text = "Exclude filenames with \'test\' in their path";
            this.chkTestPath.UseVisualStyleBackColor = true;
            // 
            // chkComments
            // 
            this.chkComments.AutoSize = true;
            this.chkComments.Location = new System.Drawing.Point(12, 153);
            this.chkComments.Name = "chkComments";
            this.chkComments.Size = new System.Drawing.Size(115, 17);
            this.chkComments.TabIndex = 11;
            this.chkComments.Text = "Exclude comments";
            this.chkComments.UseVisualStyleBackColor = true;
            this.chkComments.CheckedChanged += new System.EventHandler(this.chkComments_CheckedChanged);
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.Location = new System.Drawing.Point(12, 130);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(137, 17);
            this.chkCase.TabIndex = 10;
            this.chkCase.Text = "Case insensitive search";
            this.chkCase.UseVisualStyleBackColor = true;
            // 
            // chkTestFilename
            // 
            this.chkTestFilename.AutoSize = true;
            this.chkTestFilename.Location = new System.Drawing.Point(12, 105);
            this.chkTestFilename.Name = "chkTestFilename";
            this.chkTestFilename.Size = new System.Drawing.Size(220, 17);
            this.chkTestFilename.TabIndex = 9;
            this.chkTestFilename.Text = "Exclude filenames with \'test\' in their name";
            this.chkTestFilename.UseVisualStyleBackColor = true;
            // 
            // cmbExts
            // 
            this.cmbExts.FormattingEnabled = true;
            this.cmbExts.Items.AddRange(new object[] {
            "C/C++",
            ".NET",
            "Python",
            "Perl",
            "Ruby"});
            this.cmbExts.Location = new System.Drawing.Point(287, 45);
            this.cmbExts.Name = "cmbExts";
            this.cmbExts.Size = new System.Drawing.Size(121, 21);
            this.cmbExts.TabIndex = 8;
            this.cmbExts.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Note: extensions should be ; seperated i.e. *.foo;*.bar";
            // 
            // txtExts
            // 
            this.txtExts.Location = new System.Drawing.Point(89, 46);
            this.txtExts.Name = "txtExts";
            this.txtExts.Size = new System.Drawing.Size(192, 20);
            this.txtExts.TabIndex = 2;
            // 
            // chkExt
            // 
            this.chkExt.AutoSize = true;
            this.chkExt.Location = new System.Drawing.Point(12, 19);
            this.chkExt.Name = "chkExt";
            this.chkExt.Size = new System.Drawing.Size(101, 17);
            this.chkExt.TabIndex = 1;
            this.chkExt.Text = "Limit Extensions";
            this.chkExt.UseVisualStyleBackColor = true;
            this.chkExt.CheckedChanged += new System.EventHandler(this.chkExt_CheckedChanged);
            // 
            // lblExts
            // 
            this.lblExts.AutoSize = true;
            this.lblExts.Location = new System.Drawing.Point(9, 49);
            this.lblExts.Name = "lblExts";
            this.lblExts.Size = new System.Drawing.Size(58, 13);
            this.lblExts.TabIndex = 0;
            this.lblExts.Text = "Extensions";
            // 
            // txtComRegex
            // 
            this.txtComRegex.Location = new System.Drawing.Point(12, 177);
            this.txtComRegex.Name = "txtComRegex";
            this.txtComRegex.Size = new System.Drawing.Size(100, 20);
            this.txtComRegex.TabIndex = 14;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(124, 174);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(30, 23);
            this.cmdAdd.TabIndex = 15;
            this.cmdAdd.Text = "->";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // ctxListBox
            // 
            this.ctxListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdDeleteItem});
            this.ctxListBox.Name = "ctxListBox";
            this.ctxListBox.Size = new System.Drawing.Size(108, 26);
            // 
            // cmdDeleteItem
            // 
            this.cmdDeleteItem.Name = "cmdDeleteItem";
            this.cmdDeleteItem.Size = new System.Drawing.Size(107, 22);
            this.cmdDeleteItem.Text = "Delete";
            this.cmdDeleteItem.Click += new System.EventHandler(this.cmdDeleteItem_Click);
            // 
            // cmdFromFile
            // 
            this.cmdFromFile.Location = new System.Drawing.Point(66, 203);
            this.cmdFromFile.Name = "cmdFromFile";
            this.cmdFromFile.Size = new System.Drawing.Size(88, 23);
            this.cmdFromFile.TabIndex = 16;
            this.cmdFromFile.Text = "&Load from File";
            this.cmdFromFile.UseVisualStyleBackColor = true;
            this.cmdFromFile.Click += new System.EventHandler(this.cmdFromFile_Click);
            // 
            // cmdExportTo
            // 
            this.cmdExportTo.Location = new System.Drawing.Point(66, 232);
            this.cmdExportTo.Name = "cmdExportTo";
            this.cmdExportTo.Size = new System.Drawing.Size(88, 23);
            this.cmdExportTo.TabIndex = 17;
            this.cmdExportTo.Text = "&Export to File";
            this.cmdExportTo.UseVisualStyleBackColor = true;
            this.cmdExportTo.Click += new System.EventHandler(this.cmdExportTo_Click);
            // 
            // frmConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 492);
            this.Controls.Add(this.grpScan);
            this.Controls.Add(this.grpEditor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigure";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.frmConfigure_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfigure_KeyDown);
            this.grpEditor.ResumeLayout(false);
            this.grpEditor.PerformLayout();
            this.grpScan.ResumeLayout(false);
            this.grpScan.PerformLayout();
            this.ctxListBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox grpEditor;
        private System.Windows.Forms.TextBox txtCmdLine;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ComboBox cmbCommandLines;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.GroupBox grpScan;
        private System.Windows.Forms.ComboBox cmbExts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExts;
        private System.Windows.Forms.CheckBox chkExt;
        private System.Windows.Forms.Label lblExts;
        private System.Windows.Forms.CheckBox chkTestFilename;
        private System.Windows.Forms.CheckBox chkCase;
        private System.Windows.Forms.CheckBox chkComments;
        private System.Windows.Forms.CheckBox chkTestPath;
        private System.Windows.Forms.ListBox lstCommentLines;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtComRegex;
        private System.Windows.Forms.ContextMenuStrip ctxListBox;
        private System.Windows.Forms.ToolStripMenuItem cmdDeleteItem;
        private System.Windows.Forms.Button cmdFromFile;
        private System.Windows.Forms.Button cmdExportTo;
    }
}