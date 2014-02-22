﻿namespace FileManager
{
	partial class SidePanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SidePanel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.upDirBtn = new System.Windows.Forms.ToolStripButton();
            this.rootDirBtn = new System.Windows.Forms.ToolStripButton();
            this.newDirBtn = new System.Windows.Forms.ToolStripButton();
            this.copyItemBtn = new System.Windows.Forms.ToolStripButton();
            this.moveItemBtn = new System.Windows.Forms.ToolStripButton();
            this.refreshListsBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteItemBtn = new System.Windows.Forms.ToolStripButton();
            this.compareDirsBtn = new System.Windows.Forms.ToolStripButton();
            this.compareFilesBtn = new System.Windows.Forms.ToolStripButton();
            this.txtEditorBtn = new System.Windows.Forms.ToolStripButton();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.comboBoxDrives = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upDirBtn,
            this.rootDirBtn,
            this.newDirBtn,
            this.copyItemBtn,
            this.moveItemBtn,
            this.refreshListsBtn,
            this.deleteItemBtn,
            this.compareDirsBtn,
            this.compareFilesBtn,
            this.txtEditorBtn,
            this.toolStripButton1,
            this.comboBoxDrives});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(396, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // upDirBtn
            // 
            this.upDirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("upDirBtn.Image")));
            this.upDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upDirBtn.Name = "upDirBtn";
            this.upDirBtn.Size = new System.Drawing.Size(23, 22);
            this.upDirBtn.Text = "toolStripButton1";
            this.upDirBtn.ToolTipText = "Directory Up";
            this.upDirBtn.Click += new System.EventHandler(this.tsb_UpDir_Click);
            // 
            // rootDirBtn
            // 
            this.rootDirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rootDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("rootDirBtn.Image")));
            this.rootDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rootDirBtn.Name = "rootDirBtn";
            this.rootDirBtn.Size = new System.Drawing.Size(23, 24);
            this.rootDirBtn.ToolTipText = "Root Directory";
            this.rootDirBtn.Click += new System.EventHandler(this.rootDirBtn_Click);
            // 
            // newDirBtn
            // 
            this.newDirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("newDirBtn.Image")));
            this.newDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newDirBtn.Name = "newDirBtn";
            this.newDirBtn.Size = new System.Drawing.Size(23, 24);
            this.newDirBtn.ToolTipText = "New Folder";
            this.newDirBtn.Click += new System.EventHandler(this.newDirBtn_Click);
            // 
            // copyItemBtn
            // 
            this.copyItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("copyItemBtn.Image")));
            this.copyItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyItemBtn.Name = "copyItemBtn";
            this.copyItemBtn.Size = new System.Drawing.Size(23, 24);
            this.copyItemBtn.Text = "Copy File";
            this.copyItemBtn.Click += new System.EventHandler(this.copyItemBtn_Click);
            // 
            // moveItemBtn
            // 
            this.moveItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("moveItemBtn.Image")));
            this.moveItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveItemBtn.Name = "moveItemBtn";
            this.moveItemBtn.Size = new System.Drawing.Size(23, 24);
            this.moveItemBtn.Text = "Move";
            this.moveItemBtn.Click += new System.EventHandler(this.moveItemBtn_Click);
            // 
            // refreshListsBtn
            // 
            this.refreshListsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshListsBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshListsBtn.Image")));
            this.refreshListsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshListsBtn.Name = "refreshListsBtn";
            this.refreshListsBtn.Size = new System.Drawing.Size(23, 24);
            this.refreshListsBtn.Text = "Refresh Lists";
            this.refreshListsBtn.Click += new System.EventHandler(this.refreshListsBtn_Click);
            // 
            // deleteItemBtn
            // 
            this.deleteItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteItemBtn.Image")));
            this.deleteItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteItemBtn.Name = "deleteItemBtn";
            this.deleteItemBtn.Size = new System.Drawing.Size(23, 24);
            this.deleteItemBtn.Text = "Delete Item";
            this.deleteItemBtn.Click += new System.EventHandler(this.deleteItemBtn_Click);
            // 
            // compareDirsBtn
            // 
            this.compareDirsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compareDirsBtn.Image = ((System.Drawing.Image)(resources.GetObject("compareDirsBtn.Image")));
            this.compareDirsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compareDirsBtn.Name = "compareDirsBtn";
            this.compareDirsBtn.Size = new System.Drawing.Size(23, 24);
            this.compareDirsBtn.Text = "Compare Folders";
            this.compareDirsBtn.Click += new System.EventHandler(this.compareDirsBtn_Click);
            // 
            // compareFilesBtn
            // 
            this.compareFilesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compareFilesBtn.Image = ((System.Drawing.Image)(resources.GetObject("compareFilesBtn.Image")));
            this.compareFilesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compareFilesBtn.Name = "compareFilesBtn";
            this.compareFilesBtn.Size = new System.Drawing.Size(23, 24);
            this.compareFilesBtn.Text = "Compare Files Content";
            this.compareFilesBtn.Click += new System.EventHandler(this.compareFilesBtn_Click);
            // 
            // txtEditorBtn
            // 
            this.txtEditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.txtEditorBtn.Image = global::FileManager.Properties.Resources._1462_Pencil_16x16;
            this.txtEditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtEditorBtn.Name = "txtEditorBtn";
            this.txtEditorBtn.Size = new System.Drawing.Size(23, 24);
            this.txtEditorBtn.Text = "toolStripButton1";
            this.txtEditorBtn.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pathBox
            // 
            this.pathBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathBox.Location = new System.Drawing.Point(0, 25);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(396, 20);
            this.pathBox.TabIndex = 1;
            this.pathBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pathBox_KeyUp);
            this.pathBox.Leave += new System.EventHandler(this.pathBox_Leave);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(396, 411);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(75, 25);
            this.comboBoxDrives.Sorted = true;
            // 
            // SidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SidePanel";
            this.Size = new System.Drawing.Size(396, 456);
            this.Load += new System.EventHandler(this.SidePanel_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TextBox pathBox;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolStripButton upDirBtn;
        private System.Windows.Forms.ToolStripButton rootDirBtn;
        private System.Windows.Forms.ToolStripButton newDirBtn;
        private System.Windows.Forms.ToolStripButton copyItemBtn;
        private System.Windows.Forms.ToolStripButton moveItemBtn;
        private System.Windows.Forms.ToolStripButton refreshListsBtn;
        private System.Windows.Forms.ToolStripButton deleteItemBtn;
        private System.Windows.Forms.ToolStripButton compareDirsBtn;
        private System.Windows.Forms.ToolStripButton compareFilesBtn;
        private System.Windows.Forms.ToolStripButton txtEditorBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox comboBoxDrives;
	}
}
