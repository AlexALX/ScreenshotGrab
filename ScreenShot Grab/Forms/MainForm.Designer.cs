namespace ScreenShot_Grab
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.upload = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.TraySave = new System.Windows.Forms.ToolStripMenuItem();
            this.TraySaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.TrayPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TrayUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayUploadFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TrayCopyLink = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayCopyFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TrayOpenDir = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.TraySettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TrayShow = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.loadfrom = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lastlabel = new System.Windows.Forms.LinkLabel();
            this.MenuLastImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteImage = new System.Windows.Forms.ToolStripMenuItem();
            this.savelabel = new System.Windows.Forms.LinkLabel();
            this.MenuLastFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.clipboard = new System.Windows.Forms.Button();
            this.history = new System.Windows.Forms.Button();
            this.MenuTray.SuspendLayout();
            this.MenuLastImage.SuspendLayout();
            this.MenuLastFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.save_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.saveas_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "printscreentest";
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            this.saveFileDialog1.OverwritePrompt = false;
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // upload
            // 
            resources.ApplyResources(this.upload, "upload");
            this.upload.Name = "upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.MenuTray;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MenuTray
            // 
            this.MenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrayClipboard,
            this.toolStripSeparator6,
            this.TraySave,
            this.TraySaveAs,
            this.toolStripSeparator5,
            this.TrayPreview,
            this.TrayEdit,
            this.toolStripSeparator3,
            this.TrayUpload,
            this.TrayUploadFrom,
            this.toolStripSeparator2,
            this.TrayCopyLink,
            this.TrayCopyFilePath,
            this.toolStripSeparator4,
            this.TrayOpenDir,
            this.TrayHistory,
            this.TraySettings,
            this.toolStripSeparator1,
            this.TrayShow,
            this.TrayExit});
            this.MenuTray.Name = "contextMenuStrip3";
            resources.ApplyResources(this.MenuTray, "MenuTray");
            // 
            // TrayClipboard
            // 
            this.TrayClipboard.Name = "TrayClipboard";
            resources.ApplyResources(this.TrayClipboard, "TrayClipboard");
            this.TrayClipboard.Click += new System.EventHandler(this.clipboard_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // TraySave
            // 
            resources.ApplyResources(this.TraySave, "TraySave");
            this.TraySave.Name = "TraySave";
            this.TraySave.Click += new System.EventHandler(this.save_Click);
            // 
            // TraySaveAs
            // 
            resources.ApplyResources(this.TraySaveAs, "TraySaveAs");
            this.TraySaveAs.Name = "TraySaveAs";
            this.TraySaveAs.Click += new System.EventHandler(this.saveas_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // TrayPreview
            // 
            resources.ApplyResources(this.TrayPreview, "TrayPreview");
            this.TrayPreview.Name = "TrayPreview";
            this.TrayPreview.Click += new System.EventHandler(this.preview_Click);
            // 
            // TrayEdit
            // 
            resources.ApplyResources(this.TrayEdit, "TrayEdit");
            this.TrayEdit.Name = "TrayEdit";
            this.TrayEdit.Click += new System.EventHandler(this.edit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // TrayUpload
            // 
            resources.ApplyResources(this.TrayUpload, "TrayUpload");
            this.TrayUpload.Name = "TrayUpload";
            this.TrayUpload.Click += new System.EventHandler(this.upload_Click);
            // 
            // TrayUploadFrom
            // 
            this.TrayUploadFrom.Name = "TrayUploadFrom";
            resources.ApplyResources(this.TrayUploadFrom, "TrayUploadFrom");
            this.TrayUploadFrom.Click += new System.EventHandler(this.uploadfrom_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // TrayCopyLink
            // 
            resources.ApplyResources(this.TrayCopyLink, "TrayCopyLink");
            this.TrayCopyLink.Name = "TrayCopyLink";
            this.TrayCopyLink.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // TrayCopyFilePath
            // 
            resources.ApplyResources(this.TrayCopyFilePath, "TrayCopyFilePath");
            this.TrayCopyFilePath.Name = "TrayCopyFilePath";
            this.TrayCopyFilePath.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // TrayOpenDir
            // 
            this.TrayOpenDir.Name = "TrayOpenDir";
            resources.ApplyResources(this.TrayOpenDir, "TrayOpenDir");
            this.TrayOpenDir.Click += new System.EventHandler(this.opendir_Click);
            // 
            // TrayHistory
            // 
            this.TrayHistory.Name = "TrayHistory";
            resources.ApplyResources(this.TrayHistory, "TrayHistory");
            this.TrayHistory.Click += new System.EventHandler(this.history_Click);
            // 
            // TraySettings
            // 
            this.TraySettings.Name = "TraySettings";
            resources.ApplyResources(this.TraySettings, "TraySettings");
            this.TraySettings.Click += new System.EventHandler(this.settings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // TrayShow
            // 
            this.TrayShow.Name = "TrayShow";
            resources.ApplyResources(this.TrayShow, "TrayShow");
            this.TrayShow.Click += new System.EventHandler(this.TrayShowToolStripMenuItem_Click);
            // 
            // TrayExit
            // 
            this.TrayExit.Name = "TrayExit";
            resources.ApplyResources(this.TrayExit, "TrayExit");
            this.TrayExit.Click += new System.EventHandler(this.TrayToolStripMenuItem3_Click);
            // 
            // loadfrom
            // 
            resources.ApplyResources(this.loadfrom, "loadfrom");
            this.loadfrom.Name = "loadfrom";
            this.loadfrom.UseVisualStyleBackColor = true;
            this.loadfrom.Click += new System.EventHandler(this.uploadfrom_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "png";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.edit_Click);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.opendir_Click);
            // 
            // settings
            // 
            resources.ApplyResources(this.settings, "settings");
            this.settings.Name = "settings";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // preview
            // 
            resources.ApplyResources(this.preview, "preview");
            this.preview.Name = "preview";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // about
            // 
            resources.ApplyResources(this.about, "about");
            this.about.Name = "about";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lastlabel
            // 
            resources.ApplyResources(this.lastlabel, "lastlabel");
            this.lastlabel.ContextMenuStrip = this.MenuLastImage;
            this.lastlabel.Name = "lastlabel";
            this.lastlabel.TabStop = true;
            this.lastlabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lastlabel_LinkClicked);
            // 
            // MenuLastImage
            // 
            this.MenuLastImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.DeleteImage});
            this.MenuLastImage.Name = "contextMenuStrip1";
            resources.ApplyResources(this.MenuLastImage, "MenuLastImage");
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            resources.ApplyResources(this.ToolStripMenuItem, "ToolStripMenuItem");
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // DeleteImage
            // 
            resources.ApplyResources(this.DeleteImage, "DeleteImage");
            this.DeleteImage.Name = "DeleteImage";
            this.DeleteImage.Click += new System.EventHandler(this.DeleteImage_Click);
            // 
            // savelabel
            // 
            resources.ApplyResources(this.savelabel, "savelabel");
            this.savelabel.ContextMenuStrip = this.MenuLastFile;
            this.savelabel.Name = "savelabel";
            this.savelabel.TabStop = true;
            this.savelabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.savelabel_LinkClicked);
            // 
            // MenuLastFile
            // 
            this.MenuLastFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.DeleteFileMenu});
            this.MenuLastFile.Name = "contextMenuStrip1";
            resources.ApplyResources(this.MenuLastFile, "MenuLastFile");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // DeleteFileMenu
            // 
            this.DeleteFileMenu.Name = "DeleteFileMenu";
            resources.ApplyResources(this.DeleteFileMenu, "DeleteFileMenu");
            this.DeleteFileMenu.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // clipboard
            // 
            resources.ApplyResources(this.clipboard, "clipboard");
            this.clipboard.Name = "clipboard";
            this.clipboard.UseVisualStyleBackColor = true;
            this.clipboard.Click += new System.EventHandler(this.clipboard_Click);
            // 
            // history
            // 
            resources.ApplyResources(this.history, "history");
            this.history.Name = "history";
            this.history.UseVisualStyleBackColor = true;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.history);
            this.Controls.Add(this.clipboard);
            this.Controls.Add(this.savelabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.about);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadfrom);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.MenuTray.ResumeLayout(false);
            this.MenuLastImage.ResumeLayout(false);
            this.MenuLastFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button loadfrom;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lastlabel;
        private System.Windows.Forms.ContextMenuStrip MenuLastImage;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel savelabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip MenuLastFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TraySave;
        private System.Windows.Forms.ToolStripMenuItem TrayUpload;
        private System.Windows.Forms.ToolStripMenuItem TrayExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TrayShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem TraySaveAs;
        private System.Windows.Forms.ToolStripMenuItem TrayUploadFrom;
        private System.Windows.Forms.ToolStripMenuItem TrayOpenDir;
        private System.Windows.Forms.ToolStripMenuItem TrayEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem TrayCopyLink;
        private System.Windows.Forms.ToolStripMenuItem TrayCopyFilePath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem TrayPreview;
        internal System.Windows.Forms.ToolStripMenuItem TraySettings;
        private System.Windows.Forms.Button clipboard;
        private System.Windows.Forms.Button history;
        private System.Windows.Forms.ToolStripMenuItem TrayClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem DeleteImage;
        private System.Windows.Forms.ToolStripMenuItem DeleteFileMenu;
        private System.Windows.Forms.ToolStripMenuItem TrayHistory;
        private System.Windows.Forms.ContextMenuStrip MenuTray;
    }
}

