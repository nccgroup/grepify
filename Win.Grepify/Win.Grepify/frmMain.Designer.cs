namespace Win.Grepify
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgMain = new System.Windows.Forms.ToolStripProgressBar();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.loadProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listResults = new System.Windows.Forms.ListView();
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LineNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openInEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.ctxList.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.prgMain});
            this.statusMain.Location = new System.Drawing.Point(0, 526);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(1149, 22);
            this.statusMain.TabIndex = 0;
            this.statusMain.Text = "statusStrip1";
            this.statusMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusMain_ItemClicked);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 17);
            this.lblStatus.Text = "Idle";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgMain
            // 
            this.prgMain.MarqueeAnimationSpeed = 500;
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(400, 16);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProfileToolStripMenuItem,
            this.scanToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.resetResultsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mnuMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1149, 136);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            this.mnuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuMain_ItemClicked);
            // 
            // loadProfileToolStripMenuItem
            // 
            this.loadProfileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadProfileToolStripMenuItem.Image")));
            this.loadProfileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.loadProfileToolStripMenuItem.Name = "loadProfileToolStripMenuItem";
            this.loadProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadProfileToolStripMenuItem.Size = new System.Drawing.Size(210, 132);
            this.loadProfileToolStripMenuItem.Text = "&Load Profile";
            this.loadProfileToolStripMenuItem.Click += new System.EventHandler(this.loadProfileToolStripMenuItem_Click);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scanToolStripMenuItem.Image")));
            this.scanToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(172, 132);
            this.scanToolStripMenuItem.Text = "&Scan";
            this.scanToolStripMenuItem.Click += new System.EventHandler(this.scanToolStripMenuItem_Click);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configureToolStripMenuItem.Image")));
            this.configureToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(200, 132);
            this.configureToolStripMenuItem.Text = "&Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // resetResultsToolStripMenuItem
            // 
            this.resetResultsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetResultsToolStripMenuItem.Image")));
            this.resetResultsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.resetResultsToolStripMenuItem.Name = "resetResultsToolStripMenuItem";
            this.resetResultsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetResultsToolStripMenuItem.Size = new System.Drawing.Size(215, 132);
            this.resetResultsToolStripMenuItem.Text = "&Reset Results";
            this.resetResultsToolStripMenuItem.Click += new System.EventHandler(this.resetResultsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem.Image")));
            this.exportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 132);
            this.exportToolStripMenuItem.Text = "&Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 132);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // listResults
            // 
            this.listResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Path,
            this.FileName,
            this.FileExt,
            this.Hit,
            this.LineNumber,
            this.Line});
            this.listResults.ContextMenuStrip = this.ctxList;
            this.listResults.FullRowSelect = true;
            this.listResults.Location = new System.Drawing.Point(12, 139);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(1125, 384);
            this.listResults.TabIndex = 2;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.DoubleClick += new System.EventHandler(this.openInEditorToolStripMenuItem_Click);
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 150;
            // 
            // FileName
            // 
            this.FileName.Text = "File Name";
            this.FileName.Width = 150;
            // 
            // FileExt
            // 
            this.FileExt.Text = "File Extension";
            this.FileExt.Width = 75;
            // 
            // Hit
            // 
            this.Hit.Text = "Hit";
            this.Hit.Width = 150;
            // 
            // LineNumber
            // 
            this.LineNumber.Text = "Line #";
            // 
            // Line
            // 
            this.Line.Text = "Line";
            this.Line.Width = 400;
            // 
            // ctxList
            // 
            this.ctxList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInEditorToolStripMenuItem,
            this.showInExplorerToolStripMenuItem});
            this.ctxList.Name = "ctxList";
            this.ctxList.Size = new System.Drawing.Size(162, 48);
            // 
            // openInEditorToolStripMenuItem
            // 
            this.openInEditorToolStripMenuItem.Name = "openInEditorToolStripMenuItem";
            this.openInEditorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openInEditorToolStripMenuItem.Text = "&Open in Editor";
            this.openInEditorToolStripMenuItem.Click += new System.EventHandler(this.openInEditorToolStripMenuItem_Click);
            // 
            // showInExplorerToolStripMenuItem
            // 
            this.showInExplorerToolStripMenuItem.Name = "showInExplorerToolStripMenuItem";
            this.showInExplorerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showInExplorerToolStripMenuItem.Text = "&Show in Explorer";
            this.showInExplorerToolStripMenuItem.Click += new System.EventHandler(this.showInExplorerToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 548);
            this.Controls.Add(this.listResults);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "NCC Group Grepify";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ctxList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem loadProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView listResults;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileExt;
        private System.Windows.Forms.ColumnHeader Hit;
        private System.Windows.Forms.ColumnHeader LineNumber;
        private System.Windows.Forms.ColumnHeader Line;
        private System.Windows.Forms.ToolStripMenuItem resetResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar prgMain;
        private System.Windows.Forms.ContextMenuStrip ctxList;
        private System.Windows.Forms.ToolStripMenuItem openInEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

