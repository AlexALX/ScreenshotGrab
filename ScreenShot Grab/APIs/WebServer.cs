using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;

namespace ScreenShot_Grab
{
    internal static class WebServerAPI
    {
        internal static string UploadFile(MainForm form, byte[] data)
        {
            using (var client = new WebClient()) {
                var url = Properties.Settings.Default.svurl;
                var pdata = new NameValueCollection {
                    {"lang", Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName},
                    {"image", Convert.ToBase64String(data)},
                };
                client.Headers.Add("User-Agent", Properties.Settings.Default.agent);

                try {
                    var response = client.UploadValues(url, "POST", pdata);
                    var result = Encoding.UTF8.GetString(response);

                    var link = "";
                    if (result.StartsWith("http")) {
                        link = result;
                    } else {
                        if (result == "") result = MainForm.LocM.GetString("sv_err");
                        throw new Exception(result);
                    }
                    return link;
                } catch (Exception e) {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
