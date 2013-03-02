namespace ThoughtQ
{
    partial class MainWindow
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
            this.thoughtEntry = new System.Windows.Forms.TextBox();
            this.thoughtList = new System.Windows.Forms.ListView();
            this.Thought = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ActiveContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.act_ctxt_cats = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tb_Active = new System.Windows.Forms.TabPage();
            this.tb_Archive = new System.Windows.Forms.TabPage();
            this.archiveList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArchiveContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbx_cats = new System.Windows.Forms.ComboBox();
            this.ActiveContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tb_Active.SuspendLayout();
            this.tb_Archive.SuspendLayout();
            this.ArchiveContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // thoughtEntry
            // 
            this.thoughtEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thoughtEntry.Location = new System.Drawing.Point(12, 12);
            this.thoughtEntry.MinimumSize = new System.Drawing.Size(200, 20);
            this.thoughtEntry.Name = "thoughtEntry";
            this.thoughtEntry.Size = new System.Drawing.Size(200, 20);
            this.thoughtEntry.TabIndex = 0;
            this.thoughtEntry.Enter += new System.EventHandler(this.thoughtEntry_Enter);
            this.thoughtEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thoughtEntry_KeyDown);
            this.thoughtEntry.Leave += new System.EventHandler(this.thoughtEntry_Leave);
            // 
            // thoughtList
            // 
            this.thoughtList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thoughtList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Thought,
            this.Created});
            this.thoughtList.ContextMenuStrip = this.ActiveContextMenu;
            this.thoughtList.FullRowSelect = true;
            this.thoughtList.GridLines = true;
            this.thoughtList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.thoughtList.LabelWrap = false;
            this.thoughtList.Location = new System.Drawing.Point(0, 0);
            this.thoughtList.MultiSelect = false;
            this.thoughtList.Name = "thoughtList";
            this.thoughtList.Size = new System.Drawing.Size(246, 270);
            this.thoughtList.TabIndex = 1;
            this.thoughtList.UseCompatibleStateImageBehavior = false;
            this.thoughtList.View = System.Windows.Forms.View.Details;
            this.thoughtList.DoubleClick += new System.EventHandler(this.thoughtList_DoubleClick);
            this.thoughtList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thoughtList_KeyDown);
            // 
            // Thought
            // 
            this.Thought.Text = "Thought";
            this.Thought.Width = 184;
            // 
            // Created
            // 
            this.Created.Text = "Created";
            this.Created.Width = 57;
            // 
            // ActiveContextMenu
            // 
            this.ActiveContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archiveToolStripMenuItem,
            this.act_ctxt_cats});
            this.ActiveContextMenu.Name = "ArchiveItem";
            this.ActiveContextMenu.Size = new System.Drawing.Size(131, 48);
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.archiveToolStripMenuItem.Text = "Archive";
            this.archiveToolStripMenuItem.Click += new System.EventHandler(this.archiveToolStripMenuItem_Click);
            // 
            // act_ctxt_cats
            // 
            this.act_ctxt_cats.Name = "act_ctxt_cats";
            this.act_ctxt_cats.Size = new System.Drawing.Size(130, 22);
            this.act_ctxt_cats.Text = "Categories";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(218, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 20);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Think...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tb_Active);
            this.tabControl1.Controls.Add(this.tb_Archive);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(254, 296);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tb_Active
            // 
            this.tb_Active.Controls.Add(this.thoughtList);
            this.tb_Active.Location = new System.Drawing.Point(4, 22);
            this.tb_Active.Name = "tb_Active";
            this.tb_Active.Padding = new System.Windows.Forms.Padding(3);
            this.tb_Active.Size = new System.Drawing.Size(246, 270);
            this.tb_Active.TabIndex = 0;
            this.tb_Active.Text = "Thoughts";
            this.tb_Active.UseVisualStyleBackColor = true;
            // 
            // tb_Archive
            // 
            this.tb_Archive.Controls.Add(this.archiveList);
            this.tb_Archive.Location = new System.Drawing.Point(4, 22);
            this.tb_Archive.Name = "tb_Archive";
            this.tb_Archive.Padding = new System.Windows.Forms.Padding(3);
            this.tb_Archive.Size = new System.Drawing.Size(246, 270);
            this.tb_Archive.TabIndex = 1;
            this.tb_Archive.Text = "Archive";
            this.tb_Archive.UseVisualStyleBackColor = true;
            // 
            // archiveList
            // 
            this.archiveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.archiveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.archiveList.ContextMenuStrip = this.ArchiveContextMenu;
            this.archiveList.FullRowSelect = true;
            this.archiveList.GridLines = true;
            this.archiveList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.archiveList.LabelWrap = false;
            this.archiveList.Location = new System.Drawing.Point(0, 0);
            this.archiveList.MultiSelect = false;
            this.archiveList.Name = "archiveList";
            this.archiveList.Size = new System.Drawing.Size(246, 283);
            this.archiveList.TabIndex = 2;
            this.archiveList.UseCompatibleStateImageBehavior = false;
            this.archiveList.View = System.Windows.Forms.View.Details;
            this.archiveList.DoubleClick += new System.EventHandler(this.archiveList_DoubleClick);
            this.archiveList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.archiveList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Thought";
            this.columnHeader1.Width = 182;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Created";
            // 
            // ArchiveContextMenu
            // 
            this.ArchiveContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.ArchiveContextMenu.Name = "DeleteFromArchive";
            this.ArchiveContextMenu.Size = new System.Drawing.Size(114, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // cbx_cats
            // 
            this.cbx_cats.FormattingEnabled = true;
            this.cbx_cats.Location = new System.Drawing.Point(145, 38);
            this.cbx_cats.Name = "cbx_cats";
            this.cbx_cats.Size = new System.Drawing.Size(121, 21);
            this.cbx_cats.TabIndex = 4;
            this.cbx_cats.SelectedIndexChanged += new System.EventHandler(this.cbx_cats_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 359);
            this.Controls.Add(this.cbx_cats);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.thoughtEntry);
            this.MinimumSize = new System.Drawing.Size(294, 397);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thought Q";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ActiveContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tb_Active.ResumeLayout(false);
            this.tb_Archive.ResumeLayout(false);
            this.ArchiveContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox thoughtEntry;
        private System.Windows.Forms.ListView thoughtList;
        private System.Windows.Forms.ColumnHeader Thought;
        private System.Windows.Forms.ColumnHeader Created;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tb_Active;
        private System.Windows.Forms.TabPage tb_Archive;
        private System.Windows.Forms.ListView archiveList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip ArchiveContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ActiveContextMenu;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbx_cats;
        private System.Windows.Forms.ToolStripMenuItem act_ctxt_cats;
    }
}

