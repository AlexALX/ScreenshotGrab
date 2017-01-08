using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Resources;
using System.Reflection;
using System.Diagnostics;
//using System.Net.Http;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ScreenShot_Grab
{

    public partial class MainForm : Form
    {

        internal string[] ImgFormatExt = new string[] {
            "png", "jpg", "bmp", "gif"
        };

        internal ImageFormat[] ImgFormat = new ImageFormat[] {
            ImageFormat.Png,
            ImageFormat.Jpeg,
            ImageFormat.Bmp,
            ImageFormat.Gif
        };

        static internal ResourceManager LocM = new ResourceManager("ScreenShot_Grab.Resources.WinFormStrings", typeof(MainForm).Assembly);

        internal string spath = "";
        internal string lastfile = "";
        internal string lastlink = "";

        internal Bitmap lastres = null;

        internal string removeid = "";

        private StreamWriter logfile = null;

        private bool mainlock = false;

        internal bool Selection = false;

        /// <summary>
        /// Main functions
        /// </summary>

        public MainForm()
        {
            var lang = Properties.Settings.Default.language;
            // first run
            if (lang == "") {
                /*if (IsWindows10()) {
                    Properties.Settings.Default.cutborder = true;
                }*/
                DefLanguage();
            } else {
                //Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                try {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
                } catch {
                    DefLanguage();
                }
            }
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon1.Icon = Icon;
            notifyIcon1.Visible = true;
            if (Properties.Settings.Default.startmin) {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.scrpath != "") {
                spath = Properties.Settings.Default.scrpath;
            } else {
                spath = Path.Combine(Application.StartupPath, @"src\");
                try {
                    System.IO.Directory.CreateDirectory(spath);
                } catch {
                    spath = Application.StartupPath;
                    Properties.Settings.Default.scrpath = spath;
                }
            }
            if (Properties.Settings.Default.logfile == "") {
                Properties.Settings.Default.logfile = spath + "event.log";
            }
            if (Properties.Settings.Default.ignoressl) {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            }
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls;
            try {
                System.Net.ServicePointManager.SecurityProtocol |= (SecurityProtocolType)3072; //SecurityProtocolType.Tls12;
            } catch { }
            if (Properties.Settings.Default.writelog) {
                EnableLog();
            }
            AddEvent(LocM.GetString("event_start"));
        }

        internal void EnableLog(bool disable = false)
        {
            if (disable) {
                if (logfile != null) {
                    logfile.Close();
                    logfile = null;
                }
                return;
            }
            if (logfile != null) return;
            var exists = File.Exists(Properties.Settings.Default.logfile);
            try {
                logfile = new StreamWriter(Properties.Settings.Default.logfile,true);
                if (!exists) {
                    foreach (var line in events) {
                        logfile.WriteLine("[" + line[0] + "] " + line[2] + (line[1] != "" ? " - " + line[3] : ""));
                    }
                    logfile.Flush();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DefLanguage()
        {
            var lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            if (lang != "ru" && lang != "uk") lang = "en";
            foreach (CultureInfo item in GetSupportedCulture()) {
                if (item.TwoLetterISOLanguageName == lang) {
                    lang = item.TwoLetterISOLanguageName;
                }
            }
            Properties.Settings.Default.language = lang;
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
        }

        internal void OnLangChange()
        {
            // special fix for menus, not sure how to do this better
            var manager = new ComponentResourceManager(GetType());
            foreach (ToolStripItem ctl in MenuTray.Items) {
                manager.ApplyResources(ctl, ctl.Name);
            }
            foreach (ToolStripItem ctl in MenuLastFile.Items) {
                manager.ApplyResources(ctl, ctl.Name);
            }
            foreach (ToolStripItem ctl in MenuLastImage.Items) {
                manager.ApplyResources(ctl, ctl.Name);
            }
            //Icon = notifyIcon1.Icon;
            if (lastres != null) {
                button1.Enabled = true;
                button2.Enabled = true;
                upload.Enabled = true;
                button5.Enabled = true;
                preview.Enabled = true;
                TrayPreview.Enabled = true;
                TrayUpload.Enabled = true;
                TraySave.Enabled = true;
                TraySaveAs.Enabled = true;
                TrayEdit.Enabled = true;
            }
            if (lastlink != "") {
                lastlabel.Text = Path.GetFileName(lastlink);
                lastlabel.Enabled = true;
                TrayCopyLink.Enabled = true;
            }
            if (lastfile != "") {
                savelabel.Text = Path.GetFileName(lastfile);
                savelabel.Enabled = true;
                TrayUpload.Enabled = true;
                TrayUploadFrom.Enabled = true;
                TrayCopyFilePath.Enabled = true;
            }
        }

        internal void OnGrabScreen(Bitmap res, bool clipboard = false, int mode = 0)
        {
            if (lastres != null) lastres.Dispose();  // fix memory leak with clicking print screen
            lastres = res;
            lastfile = "";
            imgedit = false;
            button1.Enabled = true;
            button2.Enabled = true;
            upload.Enabled = true;
            button5.Enabled = true;
            preview.Enabled = true;
            TraySave.Enabled = true;
            TraySaveAs.Enabled = true;
            TrayUpload.Enabled = true;
            TrayEdit.Enabled = true;
            TrayUploadFrom.Enabled = true;
            TrayPreview.Enabled = true;
            history.Enabled = true;
            if (Properties.Settings.Default.autoshow && !clipboard) {
                TrayShowHide(true);
            }
            if (res == null) {
                MessageBox.Show(LocM.GetString("capture_err"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddEvent(LocM.GetString("event_capture_err"));
            }
            if (clipboard) {
                AddEvent(LocM.GetString("event_clipboard"));
            } else {
                if (mode == 2) AddEvent(LocM.GetString("event_grabc"));
                else AddEvent(LocM.GetString("event_grab" + (mode == 1 ? "w" : "")));
            }
            if (Properties.Settings.Default.autosave && !clipboard) {
                SimpleSave();
            }
        }

        /// <summary>
        /// Event functions
        /// </summary>

        internal IList<string[]> events = new List<string[]>();
        private HistoryForm historyform;
        private string[] lastitem;

        internal void AddEvent(string desc, string file = "", int type = 0, string rmid = "")
        {
            var item = new string[] { DateTime.Now.ToString("G"), Path.GetFileName(file), desc, file, type.ToString(), rmid};
            events.Add(item);
            lastitem = item;
            if (historyform!=null) {
                historyform.AddEvent(item);
            }
            if (logfile!=null) {
                logfile.WriteLine("[" + item[0] + "] " + item[2] + (item[1] != "" ? " - " + item[3] : ""));
                logfile.Flush();
            }
        }

        /// <summary>
        /// Notify icon handlers
        /// </summary>

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState) {
                //this.Hide();
                TrayShowHide(false);
            }/* else if (FormWindowState.Normal == this.WindowState) {
                //notifyIcon1.Visible = false;
            }*/
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            TrayShowHide(this.WindowState == FormWindowState.Minimized);
        }

        private void TrayToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TrayShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrayShowHide(this.WindowState == FormWindowState.Minimized);
        }

        private void TrayShowHide(bool show)
        {
            if (mainlock) return;
            if (show) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                TrayShow.Text = LocM.GetString("hide");
            } else {
                TrayShow.Text = LocM.GetString("show");
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// File save functions
        /// </summary>

        internal Image SaveFile(string FilePath, ImageFormat format, bool stm = false)
        {
            /* Image crop at file save, moved to Program.cs
            var width = lastres.Width;
            var height = lastres.Height;
            if (CutBorder())
            {
                width -= Properties.Settings.Default.cut_left + Properties.Settings.Default.cut_right;
                height -= Properties.Settings.Default.cut_top + Properties.Settings.Default.cut_bottom;
                if (width < 1) width = 1;
                if (height < 1) height = 1;
            }
            var TempImg = new Bitmap(width, height);
            var G = Graphics.FromImage(TempImg);
            if (CutBorder()) {
                G.DrawImage(lastres, -Properties.Settings.Default.cut_left, -Properties.Settings.Default.cut_top);
            } else {
                G.DrawImage(lastres, 0, 0);
            }*/
            var curimg = lastres;
            var err = false;
            if (format == ImageFormat.Jpeg) {
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                ImageCodecInfo Encoder = GetEncoder(format);
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                myEncoderParameters.Param[0] = new EncoderParameter(myEncoder, Properties.Settings.Default.quality);

                if (stm) {
                    using (MemoryStream stream = new MemoryStream()) {
                        curimg.Save(stream, Encoder, myEncoderParameters);
                        return Image.FromStream(stream);
                    }
                } else {
                    try {
                        curimg.Save(FilePath, Encoder, myEncoderParameters);
                    } catch {
                        MessageBox.Show(LocM.GetString("file_err"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        err = true;
                    }
                }
            } else {
                if (stm) {
                    using (MemoryStream stream = new MemoryStream()) {
                        curimg.Save(stream, format);
                        return Image.FromStream(stream);
                    }
                } else {
                    try {
                        curimg.Save(FilePath, format);
                    } catch {
                        MessageBox.Show(LocM.GetString("file_err"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        err = true;
                    }
                }
            }
            if (err) {
                savelabel.Text = LocM.GetString("error");
            } else {
                lastfile = FilePath;
                savelabel.Text = Path.GetFileName(lastfile);
                savelabel.Enabled = true;
                TrayCopyFilePath.Enabled = true;
            }
            //lastres.Dispose();
            return null;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (lastres == null) { noimage(); return; }
            SimpleSave();
        }

        private bool SimpleSave(bool edit = false)
        {
            if (!Directory.Exists(spath)) {
                AddEvent(LocM.GetString("event_save_err"));
                MessageBox.Show(LocM.GetString("path_nf"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var FileName = ConvertToBase(unixTimestamp, 36);
            var FileExt = ImgFormatExt[Properties.Settings.Default.format];
            if (!edit) {
                var i = 0;
                var fname = FileName;
                while(File.Exists(spath + fname + "." + FileExt)) {
                    i++;
                    fname = FileName + ConvertToBase(i, 36);
                }
                FileName = fname;
            }
            SaveFile(spath + FileName + "." + FileExt, ImgFormat[Properties.Settings.Default.format]);
            if (savelabel.Text == LocM.GetString("error")) {
                AddEvent(LocM.GetString("event_save_err"));
                return false;
            }
            AddEvent(LocM.GetString("event_save"), lastfile, 1);
            if (!edit && Properties.Settings.Default.opendir) {
                try {
                    System.Diagnostics.Process.Start(spath);
                } catch { }
            }
            return true;
        }

        private void saveas_Click(object sender, EventArgs e)
        {
            if (lastres == null) { noimage(); return; }
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            saveFileDialog1.FileName = base_convert(unixTimestamp.ToString(),10,36);
            saveFileDialog1.InitialDirectory = spath;
            saveFileDialog1.FilterIndex = Properties.Settings.Default.format+1;
            saveFileDialog1.ShowDialog();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var name = saveFileDialog1.FileName;
            SaveFile(name,ImgFormat[saveFileDialog1.FilterIndex - 1]);
            if (savelabel.Text == LocM.GetString("error")) {
                AddEvent(LocM.GetString("event_save_err"),name);
                return;
            }
            AddEvent(LocM.GetString("event_save"), lastfile, 1);
            imgedit = true;

            if (Properties.Settings.Default.opendir) {
                try {
                    System.Diagnostics.Process.Start(Path.GetDirectoryName(name));
                } catch { }
            }
        }

        /// <summary>
        /// Upload file functions
        /// </summary>

        private void upload_Click(object sender, EventArgs e)
        {
            if (lastres == null) { noimage(); return; }
            uploadfile();
        }

        private void uploadfile(bool bitmap = true)
        {
            byte[] data;
            if (bitmap && !imgedit) {
                data = BitmapToArray(lastres);
            } else {
                if (!File.Exists(lastfile)) {
                    AddEvent(LocM.GetString("event_upload_err"));
                    MessageBox.Show(LocM.GetString("file_nf"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                data = File.ReadAllBytes(lastfile);
            }

            upload.Enabled = false;
            loadfrom.Enabled = false;
            lastlabel.Text = LocM.GetString("loading");
            lastlabel.Enabled = false;
            TrayUpload.Enabled = false;
            TrayCopyLink.Enabled = false;
            DeleteImage.Enabled = false;
            removeid = "";

            try {
                var link = "";
                if (Properties.Settings.Default.service == 1) {
                    link = ImgurAPI.UploadFile(this, data); 
                } else if (Properties.Settings.Default.service == 2) {
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    var FileName = ConvertToBase(unixTimestamp, 36);
                    var FileExt = ImgFormatExt[Properties.Settings.Default.format];
                    link = FastpicAPI.UploadFile(this, data, FileName + "." + FileExt);
                } else {
                    link = WebServerAPI.UploadFile(this, data);
                }
                lastlink = link;
                lastlabel.Text = Path.GetFileName(link);
                lastlabel.Enabled = true;
                TrayCopyLink.Enabled = true;
                AddEvent(LocM.GetString("event_upload"), lastlink, 2, removeid);
                if (Properties.Settings.Default.openlink) {
                    try {
                        System.Diagnostics.Process.Start(link);
                    } catch { }
                }
                if (Properties.Settings.Default.copylink) {
                    Clipboard.SetText(link);
                }
            } catch (Exception e) {
                lastlabel.Text = LocM.GetString("error");
                lastlabel.Enabled = false;
                TrayCopyLink.Enabled = false;
                AddEvent(LocM.GetString("event_upload_err"));
                MessageBox.Show(e.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (lastres != null) {
                upload.Enabled = true;
                TrayUpload.Enabled = true;
            }
            loadfrom.Enabled = true;

            /* Disabled due to .NET framework 3.5 (win xp support)
             * code is fully working
            HttpContent bytesContent = new ByteArrayContent(data);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent()) {
                var url = "";
                if (Properties.Settings.Default.service == 0) {
                    client.DefaultRequestHeaders.Add("User-Agent", Properties.Settings.Default.agent);
                    url = Properties.Settings.Default.svurl;
                    formData.Add(new StringContent(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName), "lang");
                } else {
                    if (Properties.Settings.Default.access_token != "") {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Properties.Settings.Default.access_token);
                    } else {
                        client.DefaultRequestHeaders.Add("Authorization", "Client-ID " + clientid);
                    }
                    url = "https://api.imgur.com/3/image.xml";
                }

                formData.Add(bytesContent, "image", "image");
                try {
                    var response = client.PostAsync(url, formData).Result;

                    if (!response.IsSuccessStatusCode) {
                        MessageBox.Show(response.ReasonPhrase, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lastlabel.Text = LocM.GetString("error");
                        lastlabel.Enabled = false;
                    } else {
                        var result = response.Content.ReadAsStringAsync().Result;
                        //Debug.WriteLine(result);
                        var link = "";
                        if (Properties.Settings.Default.service == 0) {
                            if (result.StartsWith("http")) {
                                link = result;
                            } else {
                                if (result == "") result = LocM.GetString("sv_err");
                                MessageBox.Show(result, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                load.Enabled = true;
                                loadfrom.Enabled = true;
                                lastlabel.Text = LocM.GetString("error");
                                lastlabel.Enabled = false;
                                return;
                            }
                        } else {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(result);
                            link = doc.DocumentElement.SelectSingleNode("/data/link").InnerText;
                        }
                        response.Dispose();
                        lastlink = link;
                        lastlabel.Text = Path.GetFileName(link);
                        lastlabel.Enabled = true;
                        if (Properties.Settings.Default.openlink) {
                            System.Diagnostics.Process.Start(link);
                        }
                        if (Properties.Settings.Default.copylink) {
                            Clipboard.SetText(link);
                        }
                    //}
                } catch (Exception e) {
                    lastlabel.Text = LocM.GetString("error");
                    lastlabel.Enabled = false;
                    MessageBox.Show(e.InnerException.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                load.Enabled = true;
                loadfrom.Enabled = true;
            }*/
        }

        private void uploadfrom_Click(object sender, EventArgs e)
        {
            if (lastfile != "") {
                openFileDialog1.FileName = Path.GetFileName(lastfile);
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(lastfile);
            } else {
                openFileDialog1.InitialDirectory = spath;
            }
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = openFileDialog1.FileName;
            lastfile = name;
            uploadfile(false);
        }

        /// <summary>
        /// Image edit button
        /// </summary>

        internal bool imgedit = false;

        private void edit_Click(object sender, EventArgs e)
        {
            if (lastres == null) { noimage(); return; }
            if (lastfile == "")
            {
                if (!SimpleSave(true)) {
                    AddEvent(LocM.GetString("event_edit_err"));
                    return;
                }
            }
            if (!File.Exists(lastfile)) {
                AddEvent(LocM.GetString("event_edit_err"));
                MessageBox.Show(LocM.GetString("file_nf"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            imgedit = true;
            if (Properties.Settings.Default.sysedit) {
                string file = lastfile;
                ProcessStartInfo pi = new ProcessStartInfo(file);
                pi.Arguments = Path.GetFileName(file);
                pi.Verb = "EDIT";
                try {
                    Process.Start(pi);
                    AddEvent(LocM.GetString("event_edit"));
                } catch (Exception ex) {
                    AddEvent(LocM.GetString("event_edit_err"));
                    MessageBox.Show(ex.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                try {
                    Process.Start(Properties.Settings.Default.editor, "\"" + lastfile + "\"");
                    AddEvent(LocM.GetString("event_edit"));
                } catch (Exception ex) {
                    AddEvent(LocM.GetString("event_edit_err"));
                    MessageBox.Show(ex.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Preview button
        /// </summary>
        private void preview_Click(object sender, EventArgs e)
        {
            if (lastres == null) { noimage(); return; }
            if (imgedit && !File.Exists(lastfile)) {
                MessageBox.Show(LocM.GetString("file_nf"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TrayPreview.Enabled = false;
            mainlock = true;
            var form = new PreviewForm(this);
            form.ShowDialog();
            TrayPreview.Enabled = true;
            mainlock = false;
        }

        /// <summary>
        /// Open folder
        /// </summary>
        private void opendir_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(spath)) {
                MessageBox.Show(LocM.GetString("file_nf"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                System.Diagnostics.Process.Start(spath);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Settings button
        /// </summary>

        private void settings_Click(object sender, EventArgs e)
        {
            TraySettings.Enabled = false;
            mainlock = true;
            var form = new SettingsForm(this);
            form.ShowDialog();
            TraySettings.Enabled = true;
            mainlock = false;
        }

        /// <summary>
        /// Other buttons
        /// </summary>

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://alexalx.com/");
        }

        private void lastlabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            System.Diagnostics.Process.Start(lastlink);
        }

        private void about_Click(object sender, EventArgs e)
        {
            var form = new AboutForm(this);
            form.ShowDialog();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lastlink);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lastfile);
        }

        private void savelabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (!File.Exists(lastfile)) {
                MessageBox.Show(LocM.GetString("file_nf"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(lastfile);
        }

        private void clipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage()) {
                var img = Clipboard.GetImage();
                OnGrabScreen(new Bitmap(img), true);
            } else {
                AddEvent(LocM.GetString("event_clipboard_err"));
                MessageBox.Show(LocM.GetString("clipboard_err"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void history_Click(object sender, EventArgs e)
        {
            TrayHistory.Enabled = false;
            mainlock = true;
            historyform = new HistoryForm(this);
            historyform.ShowDialog();
            TrayHistory.Enabled = true;
            mainlock = false;
        }

        /// <summary>
        /// Misc functions
        /// </summary>

        // (c) http://stackoverflow.com/questions/553244/programmatic-way-to-get-all-the-available-languages-in-satellite-assemblies
        internal IList<CultureInfo> GetSupportedCulture()
        {
            //Get all culture 
            CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.AllCultures);

            //Find the location where application installed.
            string exeLocation = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

            //Return all culture for which satellite folder found with culture code.
            //return culture.Where(cultureInfo => Directory.Exists(Path.Combine(exeLocation, cultureInfo.Name)));
            IList<CultureInfo> cultures = new List<CultureInfo>();
            foreach (var cultureInfo in culture) {
                if (Directory.Exists(Path.Combine(exeLocation, cultureInfo.Name))) {
                    cultures.Add(cultureInfo);
                }
            }
            return cultures;
        }

        private void noimage()
        {
            MessageBox.Show(LocM.GetString("noprtscr"), LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // (c) http://stackoverflow.com/questions/686847/base-convert-in-net
        private const string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
        private static string ConvertToBase(int b10, int targetBase)
        {
            if (targetBase < 2) throw new ArgumentException("Target base must be greater than 2.", "targetBase");
            if (targetBase > 36) throw new ArgumentException("Target base must be less than 36.", "targetBase");

            if (targetBase == 10) return b10.ToString();

            StringBuilder result = new StringBuilder();

            while (b10 >= targetBase) {
                int mod = b10 % targetBase;
                result.Append(chars[mod]);
                b10 = b10 / targetBase;
            }

            result.Append(chars[b10]);

            return Reverse(result.ToString());
        }

        private static string Reverse(string s)
        {
            char[] charArray = new char[s.Length];
            int len = s.Length - 1;
            for (int i = 0; i <= len; i++)
                charArray[i] = s[len - i];
            return new string(charArray);
        }

        private string base_convert(string number, int frombase, int tobase)
        {
            int value = Convert.ToInt32(number, frombase);
            return ConvertToBase(value, tobase);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs) {
                if (codec.FormatID == format.Guid) {
                    return codec;
                }
            }
            return null;
        }

        private Byte[] BitmapToArray(Bitmap bitmap)
        {
            if (bitmap == null) return null;
            using (MemoryStream stream = new MemoryStream()) {
                bitmap.Save(stream, ImgFormat[Properties.Settings.Default.format]);
                return stream.ToArray();
            }
        }

        internal bool DeleteFile(string file)
        {
            var res = false;
            try {
                File.Delete(file);
                AddEvent(LocM.GetString("event_removefile"), file);
                res = true;
            } catch (Exception ex) {
                AddEvent(LocM.GetString("event_removefile_err"), file);
                MessageBox.Show(ex.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (file == lastfile) {
                lastfile = "";
                TrayCopyFilePath.Enabled = false;
                savelabel.Enabled = false;
            }
            return res;
        }

        private void DeleteFile_Click(object sender, EventArgs e)
        {
            var li = lastitem;
            if (DeleteFile(lastfile)) {
                li[4] = "3";
            }
        }

        private void DeleteImage_Click(object sender, EventArgs e)
        {
            var res = false;
            var li = lastitem;
            if (lastlink.Contains("fastpic.ru")) {
                res = FastpicAPI.DeleteImage(this, lastlink, removeid);
            } else {
                res = ImgurAPI.DeleteImage(this, lastlink, removeid);
            }
            if (res) {
                li[4] = "3";
            }
        }

        private void MainForm_Deactivate(object sender, FormClosedEventArgs e)
        {
            AddEvent(LocM.GetString("event_close"));
            if (logfile!=null) logfile.Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.startmin) {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        private void savelabel_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(savelabel, lastfile);
        }

        private void lastlabel_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lastlabel, lastlink);
        }
    }
}
