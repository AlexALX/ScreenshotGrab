using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ScreenShot_Grab
{
    public partial class PinForm : Form
    {
        SettingsForm form2;

        public PinForm(SettingsForm parent)
        {
            form2 = parent;
            InitializeComponent();
        }

        /// <summary>
        /// Imgur access token
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Enabled = false;
            if (ImgurAPI.EnterPIN(form2, pin.Text)) {
                Close();
            } else { 
                Enabled = true;
            }
        }
    }
}
