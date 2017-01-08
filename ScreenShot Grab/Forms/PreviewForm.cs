using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot_Grab
{
    public partial class PreviewForm : Form
    {
        private MainForm form1;
        public PreviewForm(MainForm parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            if (form1.imgedit) {
                var imgf = Image.FromFile(form1.lastfile);
                var TempImg = new Bitmap(imgf.Width, imgf.Height);
                var G = Graphics.FromImage(TempImg);
                G.DrawImage(imgf, 0, 0);
                imgf.Dispose();
                img.Image = TempImg;
            } else {
                img.Image = form1.SaveFile("", form1.ImgFormat[Properties.Settings.Default.format], true);
            }
            ClientSize = new Size(img.Image.Width + 10, img.Image.Height + 10);
            img.Width = img.Image.Width+10;
            img.Height = img.Image.Height+10;
            if (img.Image.Width >= Screen.PrimaryScreen.Bounds.Width || img.Image.Height >= Screen.PrimaryScreen.Bounds.Height) {
                WindowState = FormWindowState.Maximized;
            }
            CenterToScreen();
        }

        private void PreviewForm_Deactivate(object sender, EventArgs e)
        {
            img.Image.Dispose();
        }

        private void PreviewForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
