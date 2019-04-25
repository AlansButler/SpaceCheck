namespace SpaceCheck
{
    partial class formSpaceCheck
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.brnRE = new System.Windows.Forms.Button();
			this.tbFNToFind = new System.Windows.Forms.TextBox();
			this.btnFindFile = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbCutoff = new System.Windows.Forms.TextBox();
			this.tbRootDir = new System.Windows.Forms.TextBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.lv = new System.Windows.Forms.ListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
			this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.numericUpDownFolderDepth = new System.Windows.Forms.NumericUpDown();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFolderDepth)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.numericUpDownFolderDepth);
			this.splitContainer1.Panel1.Controls.Add(this.listBox1);
			this.splitContainer1.Panel1.Controls.Add(this.brnRE);
			this.splitContainer1.Panel1.Controls.Add(this.tbFNToFind);
			this.splitContainer1.Panel1.Controls.Add(this.btnFindFile);
			this.splitContainer1.Panel1.Controls.Add(this.btnStop);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.tbCutoff);
			this.splitContainer1.Panel1.Controls.Add(this.tbRootDir);
			this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
			this.splitContainer1.Panel1MinSize = 50;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lv);
			this.splitContainer1.Size = new System.Drawing.Size(1211, 597);
			this.splitContainer1.SplitterDistance = 143;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 4;
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(143, 225);
			this.listBox1.TabIndex = 13;
			this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// brnRE
			// 
			this.brnRE.Location = new System.Drawing.Point(94, 403);
			this.brnRE.Name = "brnRE";
			this.brnRE.Size = new System.Drawing.Size(46, 23);
			this.brnRE.TabIndex = 12;
			this.brnRE.Text = "RE";
			this.brnRE.UseVisualStyleBackColor = true;
			this.brnRE.Click += new System.EventHandler(this.brnRE_Click);
			// 
			// tbFNToFind
			// 
			this.tbFNToFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFNToFind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.tbFNToFind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.tbFNToFind.Location = new System.Drawing.Point(13, 432);
			this.tbFNToFind.Name = "tbFNToFind";
			this.tbFNToFind.Size = new System.Drawing.Size(127, 20);
			this.tbFNToFind.TabIndex = 8;
			this.tbFNToFind.Text = "FindThis";
			this.tbFNToFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFNToFind_KeyPress);
			this.tbFNToFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFNToFind_KeyUp);
			// 
			// btnFindFile
			// 
			this.btnFindFile.Location = new System.Drawing.Point(13, 403);
			this.btnFindFile.Name = "btnFindFile";
			this.btnFindFile.Size = new System.Drawing.Size(75, 23);
			this.btnFindFile.TabIndex = 7;
			this.btnFindFile.Text = "FindFile";
			this.btnFindFile.UseVisualStyleBackColor = true;
			this.btnFindFile.Click += new System.EventHandler(this.btnFindFile_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(13, 249);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 6;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 507);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(13, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "0";
			// 
			// tbCutoff
			// 
			this.tbCutoff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCutoff.Location = new System.Drawing.Point(8, 343);
			this.tbCutoff.Name = "tbCutoff";
			this.tbCutoff.Size = new System.Drawing.Size(127, 20);
			this.tbCutoff.TabIndex = 4;
			this.tbCutoff.Text = "500";
			this.tbCutoff.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCutoff_KeyUp);
			// 
			// tbRootDir
			// 
			this.tbRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRootDir.Location = new System.Drawing.Point(13, 278);
			this.tbRootDir.Name = "tbRootDir";
			this.tbRootDir.Size = new System.Drawing.Size(127, 20);
			this.tbRootDir.TabIndex = 3;
			this.tbRootDir.Text = "c:\\";
			this.tbRootDir.DoubleClick += new System.EventHandler(this.tbRootDir_DoubleClick);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(13, 314);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnRefresh.TabIndex = 2;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// lv
			// 
			this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSize});
			this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv.GridLines = true;
			this.lv.Location = new System.Drawing.Point(0, 0);
			this.lv.MultiSelect = false;
			this.lv.Name = "lv";
			this.lv.Size = new System.Drawing.Size(1060, 597);
			this.lv.TabIndex = 6;
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.View = System.Windows.Forms.View.Details;
			this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
			this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
			this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
			this.lv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_MouseClick);
			this.lv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_MouseDown);
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 139;
			// 
			// colSize
			// 
			this.colSize.Text = "Size (mb)";
			this.colSize.Width = 100;
			// 
			// directorySearcher1
			// 
			this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
			this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
			this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// numericUpDownFolderDepth
			// 
			this.numericUpDownFolderDepth.Location = new System.Drawing.Point(8, 369);
			this.numericUpDownFolderDepth.Name = "numericUpDownFolderDepth";
			this.numericUpDownFolderDepth.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownFolderDepth.TabIndex = 14;
			this.numericUpDownFolderDepth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// formSpaceCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1211, 597);
			this.Controls.Add(this.splitContainer1);
			this.Name = "formSpaceCheck";
			this.Text = "Space Check";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSpaceCheck_FormClosing);
			this.Load += new System.EventHandler(this.formSpaceCheck_Load);
			this.Shown += new System.EventHandler(this.formSpaceCheck_Shown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFolderDepth)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox tbRootDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox tbCutoff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnFindFile;
				private System.Windows.Forms.TextBox tbFNToFind;
      private System.Windows.Forms.Button brnRE;
			private System.Windows.Forms.ListBox listBox1;
			private System.Windows.Forms.NumericUpDown numericUpDownFolderDepth;
			private System.Windows.Forms.ToolTip toolTip1;
    }
}

