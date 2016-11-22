using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ScreenShot_Grab
{
    public partial class AboutForm : Form
    {
        private MainForm form1;
        public AboutForm(MainForm parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://alexalx.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://creativecommons.org/licenses/by-nc-sa/4.0/");
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var buildtime = GetLinkerTime(Assembly.GetExecutingAssembly());
            version.Text = form1.ProductVersion + " (" + buildtime.ToString("d") + ")";
            //version.Text += " "+form1.LocM.GetString("net_for")+" "+Assembly.GetExecutingAssembly().ImageRuntimeVersion.Substring(0,4);
        }

        // (c) http://stackoverflow.com/questions/1600962/displaying-the-build-date
        public static DateTime GetLinkerTime(Assembly assembly) //, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            //var tz = target ?? TimeZoneInfo.Local;
            //var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            var localTime = linkTimeUtc.ToLocalTime();

            return localTime;
        }
    }
}
