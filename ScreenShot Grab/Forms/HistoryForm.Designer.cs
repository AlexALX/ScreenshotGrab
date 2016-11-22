namespace ScreenShot_Grab
{
    partial class HistoryForm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.eventlist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contentmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openfile = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyLink = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveList = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.savelog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contentmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventlist
            // 
            resources.ApplyResources(this.eventlist, "eventlist");
            this.eventlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.eventlist.FullRowSelect = true;
            this.eventlist.GridLines = true;
            this.eventlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.eventlist.Name = "eventlist";
            this.eventlist.UseCompatibleStateImageBehavior = false;
            this.eventlist.View = System.Windows.Forms.View.Details;
            this.eventlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.eventlist_MouseClick);
            this.eventlist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.eventlist_DoubleMouseClick);
            this.eventlist.MouseMove += new System.Windows.Forms.MouseEventHandler(this.eventlist_MouseMove);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Name = "panel1";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.eventlist);
            this.panel2.Name = "panel2";
            // 
            // contentmenu
            // 
            resources.ApplyResources(this.contentmenu, "contentmenu");
            this.contentmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfile,
            this.CopyLink,
            this.RemoveList,
            this.RemoveFile});
            this.contentmenu.Name = "contentmenu";
            // 
            // openfile
            // 
            resources.ApplyResources(this.openfile, "openfile");
            this.openfile.Name = "openfile";
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // CopyLink
            // 
            resources.ApplyResources(this.CopyLink, "CopyLink");
            this.CopyLink.Name = "CopyLink";
            this.CopyLink.Click += new System.EventHandler(this.copylink_Click);
            // 
            // RemoveList
            // 
            resources.ApplyResources(this.RemoveList, "RemoveList");
            this.RemoveList.Name = "RemoveList";
            this.RemoveList.Click += new System.EventHandler(this.removelist_Click);
            // 
            // RemoveFile
            // 
            resources.ApplyResources(this.RemoveFile, "RemoveFile");
            this.RemoveFile.Name = "RemoveFile";
            this.RemoveFile.Click += new System.EventHandler(this.removefile_Click);
            // 
            // savelog
            // 
            this.savelog.DefaultExt = "log";
            this.savelog.FileName = "event.log";
            resources.ApplyResources(this.savelog, "savelog");
            this.savelog.FileOk += new System.ComponentModel.CancelEventHandler(this.savelog_FileOk);
            // 
            // HistoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contentmenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.ListView eventlist;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contentmenu;
        private System.Windows.Forms.ToolStripMenuItem CopyLink;
        private System.Windows.Forms.ToolStripMenuItem RemoveList;
        private System.Windows.Forms.ToolStripMenuItem RemoveFile;
        private System.Windows.Forms.SaveFileDialog savelog;
        private System.Windows.Forms.ToolStripMenuItem openfile;
    }
}