using System;
using System.Windows.Forms;

namespace ScreenShot_Grab
{
    public partial class CropForm : Form
    {
        public CropForm()
        {
            InitializeComponent();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            up.Value = 0;
            left.Value = 0;
            right.Value = 0;
            bottom.Value = 0;
            //Properties.Settings.Default.Save();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            up.Maximum = Decimal.MaxValue;
            left.Maximum = Decimal.MaxValue;
            right.Maximum = Decimal.MaxValue;
            bottom.Maximum = Decimal.MaxValue;
            up.Value = Properties.Settings.Default.cut_top;
            left.Value = Properties.Settings.Default.cut_left;
            right.Value = Properties.Settings.Default.cut_right;
            bottom.Value = Properties.Settings.Default.cut_bottom;
        }

        private void save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.cut_top = Convert.ToInt32(up.Value);
            Properties.Settings.Default.cut_left = Convert.ToInt32(left.Value);
            Properties.Settings.Default.cut_right = Convert.ToInt32(right.Value);
            Properties.Settings.Default.cut_bottom = Convert.ToInt32(bottom.Value);
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
