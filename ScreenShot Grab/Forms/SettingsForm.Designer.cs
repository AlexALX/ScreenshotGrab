namespace ScreenShot_Grab
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.cutborder = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pathselect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.svurl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.useragent = new System.Windows.Forms.TextBox();
            this.ignoressl = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.quality = new System.Windows.Forms.NumericUpDown();
            this.format = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.adv = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.status = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imgurb = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.logfilecheck = new System.Windows.Forms.CheckBox();
            this.logfilebrowse = new System.Windows.Forms.Button();
            this.logfile = new System.Windows.Forms.TextBox();
            this.autoshow = new System.Windows.Forms.CheckBox();
            this.language = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.copylink = new System.Windows.Forms.CheckBox();
            this.openlink = new System.Windows.Forms.CheckBox();
            this.opendir = new System.Windows.Forms.CheckBox();
            this.editor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sysedit = new System.Windows.Forms.CheckBox();
            this.editselect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.reset = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.clipboard = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cutborder
            // 
            resources.ApplyResources(this.cutborder, "cutborder");
            this.cutborder.Checked = true;
            this.cutborder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cutborder.Name = "cutborder";
            this.cutborder.UseVisualStyleBackColor = true;
            this.cutborder.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // path
            // 
            resources.ApplyResources(this.path, "path");
            this.path.Name = "path";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pathselect
            // 
            resources.ApplyResources(this.pathselect, "pathselect");
            this.pathselect.Name = "pathselect";
            this.pathselect.UseVisualStyleBackColor = true;
            this.pathselect.Click += new System.EventHandler(this.button2_Click);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // svurl
            // 
            resources.ApplyResources(this.svurl, "svurl");
            this.svurl.Name = "svurl";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // useragent
            // 
            resources.ApplyResources(this.useragent, "useragent");
            this.useragent.Name = "useragent";
            // 
            // ignoressl
            // 
            resources.ApplyResources(this.ignoressl, "ignoressl");
            this.ignoressl.Name = "ignoressl";
            this.ignoressl.UseVisualStyleBackColor = true;
            this.ignoressl.CheckedChanged += new System.EventHandler(this.ignoressl_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.quality);
            this.groupBox1.Controls.Add(this.format);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pathselect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.path);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // quality
            // 
            this.quality.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            resources.ApplyResources(this.quality, "quality");
            this.quality.Name = "quality";
            this.quality.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.quality.ValueChanged += new System.EventHandler(this.quality_ValueChanged);
            // 
            // format
            // 
            this.format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.format.FormattingEnabled = true;
            this.format.Items.AddRange(new object[] {
            resources.GetString("format.Items"),
            resources.GetString("format.Items1"),
            resources.GetString("format.Items2"),
            resources.GetString("format.Items3")});
            resources.ApplyResources(this.format, "format");
            this.format.Name = "format";
            this.format.SelectedIndexChanged += new System.EventHandler(this.format_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // adv
            // 
            resources.ApplyResources(this.adv, "adv");
            this.adv.Name = "adv";
            this.adv.UseVisualStyleBackColor = true;
            this.adv.Click += new System.EventHandler(this.adv_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.ignoressl);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.useragent);
            this.tabPage1.Controls.Add(this.svurl);
            this.tabPage1.Controls.Add(this.label3);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.status);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.imgurb);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // status
            // 
            resources.ApplyResources(this.status, "status");
            this.status.Name = "status";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // imgurb
            // 
            resources.ApplyResources(this.imgurb, "imgurb");
            this.imgurb.Name = "imgurb";
            this.imgurb.UseVisualStyleBackColor = true;
            this.imgurb.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logfilecheck);
            this.groupBox3.Controls.Add(this.logfilebrowse);
            this.groupBox3.Controls.Add(this.logfile);
            this.groupBox3.Controls.Add(this.autoshow);
            this.groupBox3.Controls.Add(this.language);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.copylink);
            this.groupBox3.Controls.Add(this.openlink);
            this.groupBox3.Controls.Add(this.opendir);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // logfilecheck
            // 
            resources.ApplyResources(this.logfilecheck, "logfilecheck");
            this.logfilecheck.Name = "logfilecheck";
            this.logfilecheck.UseVisualStyleBackColor = true;
            this.logfilecheck.CheckedChanged += new System.EventHandler(this.logfilecheck_CheckedChanged);
            // 
            // logfilebrowse
            // 
            resources.ApplyResources(this.logfilebrowse, "logfilebrowse");
            this.logfilebrowse.Name = "logfilebrowse";
            this.logfilebrowse.UseVisualStyleBackColor = true;
            this.logfilebrowse.Click += new System.EventHandler(this.logfilebrowse_Click);
            // 
            // logfile
            // 
            resources.ApplyResources(this.logfile, "logfile");
            this.logfile.Name = "logfile";
            // 
            // autoshow
            // 
            resources.ApplyResources(this.autoshow, "autoshow");
            this.autoshow.Name = "autoshow";
            this.autoshow.UseVisualStyleBackColor = true;
            // 
            // language
            // 
            this.language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.language.FormattingEnabled = true;
            this.language.Items.AddRange(new object[] {
            resources.GetString("language.Items"),
            resources.GetString("language.Items1")});
            resources.ApplyResources(this.language, "language");
            this.language.Name = "language";
            this.language.SelectedIndexChanged += new System.EventHandler(this.language_SelectedIndexChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // copylink
            // 
            resources.ApplyResources(this.copylink, "copylink");
            this.copylink.Name = "copylink";
            this.copylink.UseVisualStyleBackColor = true;
            // 
            // openlink
            // 
            resources.ApplyResources(this.openlink, "openlink");
            this.openlink.Name = "openlink";
            this.openlink.UseVisualStyleBackColor = true;
            // 
            // opendir
            // 
            resources.ApplyResources(this.opendir, "opendir");
            this.opendir.Name = "opendir";
            this.opendir.UseVisualStyleBackColor = true;
            // 
            // editor
            // 
            resources.ApplyResources(this.editor, "editor");
            this.editor.Name = "editor";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // sysedit
            // 
            resources.ApplyResources(this.sysedit, "sysedit");
            this.sysedit.Checked = true;
            this.sysedit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sysedit.Name = "sysedit";
            this.sysedit.UseVisualStyleBackColor = true;
            this.sysedit.CheckedChanged += new System.EventHandler(this.sysedit_CheckedChanged);
            // 
            // editselect
            // 
            resources.ApplyResources(this.editselect, "editselect");
            this.editselect.Name = "editselect";
            this.editselect.UseVisualStyleBackColor = true;
            this.editselect.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.editselect);
            this.groupBox4.Controls.Add(this.sysedit);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.editor);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // reset
            // 
            resources.ApplyResources(this.reset, "reset");
            this.reset.Name = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.adv);
            this.groupBox5.Controls.Add(this.clipboard);
            this.groupBox5.Controls.Add(this.cutborder);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // clipboard
            // 
            resources.ApplyResources(this.clipboard, "clipboard");
            this.clipboard.Name = "clipboard";
            this.toolTip1.SetToolTip(this.clipboard, resources.GetString("clipboard.ToolTip"));
            this.clipboard.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "log";
            this.saveFileDialog1.FileName = "event.log";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cutborder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pathselect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox svurl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox useragent;
        private System.Windows.Forms.CheckBox ignoressl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox copylink;
        private System.Windows.Forms.CheckBox openlink;
        private System.Windows.Forms.CheckBox opendir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox editor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox sysedit;
        private System.Windows.Forms.Button editselect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button imgurb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox format;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown quality;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button adv;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.ComboBox language;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox autoshow;
        private System.Windows.Forms.Button logfilebrowse;
        private System.Windows.Forms.TextBox logfile;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox clipboard;
        private System.Windows.Forms.CheckBox logfilecheck;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}