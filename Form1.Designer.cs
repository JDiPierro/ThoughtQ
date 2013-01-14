namespace ThoughtQ
{
    partial class Form1
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
            this.thoughtEntry = new System.Windows.Forms.TextBox();
            this.thoughtList = new System.Windows.Forms.ListView();
            this.Thought = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
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
            this.thoughtList.FullRowSelect = true;
            this.thoughtList.GridLines = true;
            this.thoughtList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.thoughtList.LabelWrap = false;
            this.thoughtList.Location = new System.Drawing.Point(12, 38);
            this.thoughtList.MultiSelect = false;
            this.thoughtList.Name = "thoughtList";
            this.thoughtList.Size = new System.Drawing.Size(254, 309);
            this.thoughtList.TabIndex = 1;
            this.thoughtList.UseCompatibleStateImageBehavior = false;
            this.thoughtList.View = System.Windows.Forms.View.Details;
            this.thoughtList.DoubleClick += new System.EventHandler(this.thoughtList_DoubleClick);
            // 
            // Thought
            // 
            this.Thought.Text = "Thought";
            this.Thought.Width = 182;
            // 
            // Created
            // 
            this.Created.Text = "Created";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(218, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 20);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 359);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.thoughtList);
            this.Controls.Add(this.thoughtEntry);
            this.MinimumSize = new System.Drawing.Size(294, 397);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thought Q";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox thoughtEntry;
        private System.Windows.Forms.ListView thoughtList;
        private System.Windows.Forms.ColumnHeader Thought;
        private System.Windows.Forms.ColumnHeader Created;
        private System.Windows.Forms.Button btnSave;
    }
}

