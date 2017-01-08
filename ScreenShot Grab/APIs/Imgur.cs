using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ScreenShot_Grab
{
    internal static class ImgurAPI
    {

        private const string clientid = "afd1481e5938c4d";
        private const string clientsecret = "3d4ea898105c1a3f01baeac89ff602f97e9df6ab";

        internal static void ConnectAccount(SettingsForm sform)
        {
            if (Properties.Settings.Default.account != "") {
                Properties.Settings.Default.account = "";
                Properties.Settings.Default.access_token = "";
                Properties.Settings.Default.refresh_token = "";
                Properties.Settings.Default.Save();
                sform.RegImgur();
            } else {
                sform.imgurb.Enabled = false;
                System.Diagnostics.Process.Start("https://api.imgur.com/oauth2/authorize?client_id=" + clientid + "&response_type=pin&state=APPLICATION_STATE");
                Thread.Sleep(1000);
                var form = new PinForm(sform);
                form.ShowDialog();
                sform.imgurb.Enabled = true;
            }
        }

        // imgur refresh token
        internal static void RefreshToken()
        {
            using (var client = new WebClient()) {
                var pdata = new NameValueCollection {
                    {"client_id", clientid},
                    {"client_secret", clientsecret},
                    {"grant_type","refresh_token"},
                    {"refresh_token",Properties.Settings.Default.refresh_token}
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
                    Properties.Settings.Default.Save();
                } catch { //(Exception ex) {
                    //MessageBox.Show(ex.Message, LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Enabled = true;
                }
            }
        }

        internal static string UploadFile(MainForm form, byte[] data)
        {
            if (Properties.Settings.Default.access_token != ""
            && DateTime.Now > Properties.Settings.Default.expires) {
                RefreshToken();
            }

            using (var client = new WebClient()) {
                var url = "https://api.imgur.com/3/image.xml";
                var pdata = new NameValueCollection();
                if (Properties.Settings.Default.access_token != "") {
                    client.Headers.Add("Authorization", "Bearer " + Properties.Settings.Default.access_token);
                } else {
                    client.Headers.Add("Authorization", "Client-ID " + clientid);
                }
                url = "https://api.imgur.com/3/image.xml";
                pdata.Add("image", Convert.ToBase64String(data));

                try {
                    var response = client.UploadValues(url, "POST", pdata);
                    var result = Encoding.UTF8.GetString(response);

                    var link = "";
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    var err = doc.DocumentElement.SelectSingleNode("/data/error");
                    if (err != null) {
                        throw new Exception(err.InnerText);
                    } else {
                        var rem = doc.DocumentElement.SelectSingleNode("/data/deletehash");
                        if (rem != null) {
                            form.removeid = rem.InnerText;
                            form.DeleteImage.Enabled = true;
                        }
                        link = doc.DocumentElement.SelectSingleNode("/data/link").InnerText;
                    }
                    return link;
                } catch (Exception e) {
                    throw new Exception(e.Message);
                }
            }
        }

        internal static bool EnterPIN(SettingsForm form2, string pin) { 
            using (var client = new WebClient()) {
                var pdata = new NameValueCollection {
                    {"client_id", clientid},
                    {"client_secret", clientsecret},
                    {"grant_type","pin"},
                    {"pin",pin}
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
                    return true;
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, MainForm.LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
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

        internal static bool DeleteImage(MainForm form, string link, string rmid)
        {
            if (!link.Contains("imgur.com") || rmid == "") return false;
            using (var client = new WebClient()) {
                if (Properties.Settings.Default.access_token != "") {
                    client.Headers.Add("Authorization", "Bearer " + Properties.Settings.Default.access_token);
                } else {
                    client.Headers.Add("Authorization", "Client-ID " + clientid);
                }
                try {
                    var response = client.UploadValues("https://api.imgur.com/3/image/" + rmid + ".xml", "DELETE", new NameValueCollection());
                    var result = Encoding.UTF8.GetString(response);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    var status = doc.DocumentElement.SelectSingleNode("/data");
                    if (status != null && status.InnerText == "true") {
                        if (form.lastlink == link) {
                            form.lastlabel.Enabled = false;
                            form.lastlink = "";
                            form.removeid = "";
                        }
                        form.AddEvent(MainForm.LocM.GetString("event_removeimg"), link);
                        return true;
                    } else throw new Exception(MainForm.LocM.GetString("img_rm_err"));
                } catch (Exception ex) {
                    form.AddEvent(MainForm.LocM.GetString("event_removeimg_err"), link);
                    MessageBox.Show(ex.Message, MainForm.LocM.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
        }

    }
}
