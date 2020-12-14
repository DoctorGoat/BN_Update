namespace Universal_Launcher
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupTargetFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dummy1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTemplateToolStripMenuItem,
            this.targetFolderToolStripMenuItem,
            this.backupTargetFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadTemplateToolStripMenuItem
            // 
            this.loadTemplateToolStripMenuItem.Name = "loadTemplateToolStripMenuItem";
            this.loadTemplateToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.loadTemplateToolStripMenuItem.Text = "Load Template";
            this.loadTemplateToolStripMenuItem.Click += new System.EventHandler(this.loadTemplateToolStripMenuItem_Click);
            // 
            // targetFolderToolStripMenuItem
            // 
            this.targetFolderToolStripMenuItem.Name = "targetFolderToolStripMenuItem";
            this.targetFolderToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.targetFolderToolStripMenuItem.Text = "Target Folder";
            this.targetFolderToolStripMenuItem.Click += new System.EventHandler(this.targetFolderToolStripMenuItem_Click);
            // 
            // backupTargetFolderToolStripMenuItem
            // 
            this.backupTargetFolderToolStripMenuItem.Name = "backupTargetFolderToolStripMenuItem";
            this.backupTargetFolderToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.backupTargetFolderToolStripMenuItem.Text = "Backup Target Folder";
            this.backupTargetFolderToolStripMenuItem.Click += new System.EventHandler(this.backupTargetFolderToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 454);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 184);
            this.textBox1.TabIndex = 1;
            // 
            // dummy1
            // 
            this.dummy1.Location = new System.Drawing.Point(13, 28);
            this.dummy1.Multiline = true;
            this.dummy1.Name = "dummy1";
            this.dummy1.Size = new System.Drawing.Size(776, 35);
            this.dummy1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(274, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(515, 381);
            this.listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dummy1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem targetFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupTargetFolderToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox dummy1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

