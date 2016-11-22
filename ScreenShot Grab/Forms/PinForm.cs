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
            using (var client = new WebClient()) {
                var pdata = new NameValueCollection {
                    {"client_id", form2.form1.clientid},
                    {"client_secret", form2.form1.clientsecret},
                    {"grant_type","pin"},
                    {"pin",pin.Text}
                };

                try {
                    var response = client.UploadValues("https://api.imgur.com/oauth2/token.xml", "POST", pdata);
                    var result = Encoding.UTF8.GetString(response);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    //Debug.WriteLine(result);
                    var access = doc.DocumentElement.SelectSingleNode("/response/access_token").InnerText;
                    Properties.Settings.Default.access_token = access;
                    var refresh = doc.DocumentElement.SelectSingleNode("/response/refresh_token").InnerText;
                    Properties.Settings.Default.refresh_token = refresh;
                    var account = doc.DocumentElement.SelectSingleNode("/response/account_username").InnerText;
                    Properties.Settings.Default.account = account;
                    var expires = doc.DocumentElement.SelectSingleNode("/response/expires_in").InnerText;
                    Properties.Settings.Default.expires = DateTime.Now.AddSeconds(Convert.ToInt32(expires));
                    form2.RegImgur();
                    Properties.Settings.Default.Save();
                    Close();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, form2.form1.LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Enabled = true;
                }
            }
            /* Disabled due to .NET framework 3.5 (win xp support)
             * code is fully working
            using (var client = new HttpClient()) {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", form2.form1.clientid),
                    new KeyValuePair<string, string>("client_secret", clientsecret),
                    new KeyValuePair<string, string>("grant_type", "pin"),
                    new KeyValuePair<string, string>("pin", pin.Text),
                });

                var response = client.PostAsync("https://api.imgur.com/oauth2/token.xml", formContent).Result;
                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show(response.ReasonPhrase, form2.form1.LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Enabled = true;
                } else {
                    var result = response.Content.ReadAsStringAsync().Result;
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    //Debug.WriteLine(result);
                    var access = doc.DocumentElement.SelectSingleNode("/response/access_token").InnerText;
                    Properties.Settings.Default.access_token = access;
                    var refresh = doc.DocumentElement.SelectSingleNode("/response/refresh_token").InnerText;
                    Properties.Settings.Default.refresh_token = refresh;
                    var account = doc.DocumentElement.SelectSingleNode("/response/account_username").InnerText;
                    Properties.Settings.Default.account = account;
                    var expires = doc.DocumentElement.SelectSingleNode("/response/expires_in").InnerText;
                    Properties.Settings.Default.expires = DateTime.Now.AddSeconds(Convert.ToInt32(expires));
                    form2.RegImgur();
                    Properties.Settings.Default.Save();
                    Close();
                }
            }*/
        }
    }
}
