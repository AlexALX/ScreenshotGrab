using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ScreenShot_Grab
{
    internal static class FastpicAPI
    {

        // (c) http://stackoverflow.com/a/11048296
        private class UpFile
        {
            public UpFile()
            {
                ContentType = "application/octet-stream";
            }
            public string Name { get; set; }
            public string Filename { get; set; }
            public string ContentType { get; set; }
            public Stream Stream { get; set; }
        }

        // fix for .net 3.5 (c) http://stackoverflow.com/a/1537490
        private static void BugFix_CookieDomain(CookieContainer cookieContainer)
        {
            System.Type _ContainerType = typeof(CookieContainer);
            Hashtable table = (Hashtable)_ContainerType.InvokeMember("m_domainTable",
                                       System.Reflection.BindingFlags.NonPublic |
                                       System.Reflection.BindingFlags.GetField |
                                       System.Reflection.BindingFlags.Instance,
                                       null,
                                       cookieContainer,
                                       new object[] { });
            ArrayList keys = new ArrayList(table.Keys);
            foreach (string keyObj in keys) {
                string key = (keyObj as string);
                if (key[0] == '.') {
                    string newKey = key.Remove(0, 1);
                    table[newKey] = table[keyObj];
                }
            }
        }

        private static byte[] UploadFiles(string address, IEnumerable<UpFile> files, NameValueCollection values, ref string sid)
        {
            var request = (HttpWebRequest) WebRequest.Create(address);
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            boundary = "--" + boundary;

            using (var requestStream = request.GetRequestStream()) {
                // Write the values
                foreach (string name in values.Keys) {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                // Write the files
                foreach (var file in files) {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    //file.Stream.CopyTo(requestStream);
                    CopyStream(file.Stream, requestStream);
                    buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
            }

            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var stream = new MemoryStream()) {
                //responseStream.CopyTo(stream);
                CopyStream(responseStream, stream);
                BugFix_CookieDomain(request.CookieContainer);
                foreach (Cookie cookie in request.CookieContainer.GetCookies(new Uri("http://fastpic.ru/"))) {
                    if (cookie.Name=="fp_sid") {
                        sid = cookie.Value;
                        break;
                    }
                    //Debug.WriteLine(String.Format("Name = {0} ; Value = {1} ; Domain = {2}", cookie.Name, cookie.Value, cookie.Domain));
                }
                return stream.ToArray();
            }
        }

        // (c) http://stackoverflow.com/a/230141
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0) {
                output.Write(buffer, 0, read);
            }
        }

        internal static string UploadFile(MainForm form, byte[] data, string filename)
        {
            using (var client = new WebClient()) {
                var url = "http://fastpic.ru/upload?api=1";
                var pdata = new NameValueCollection {
                    {"method","file"},
                    {"check_thumb", "no"},
                    {"uploading","1"},
                };

                var files = new[]
                 {
                    new UpFile
                    {
                        Name = "file1",
                        Filename = filename,
                        ContentType = "text/plain",
                        Stream = new MemoryStream(data)
                    }
                };

                var removeid = "";
                client.Headers.Add("User-Agent", "FPUploader");
                try {
                    var response = UploadFiles(url, files, pdata, ref removeid);
                    var result = Encoding.UTF8.GetString(response);
                    //Debug.WriteLine(result);
                    var link = "";
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    var err = doc.DocumentElement.SelectSingleNode("/UploadSettings/error");
                    if (err != null && err.InnerText != "") {
                        throw new Exception(err.InnerText);
                    } else {
                        link = doc.DocumentElement.SelectSingleNode("/UploadSettings/imagepath").InnerText;
                        if (removeid != "") {
                            var imgid = doc.DocumentElement.SelectSingleNode("/UploadSettings/imageid").InnerText;
                            form.removeid = imgid + "=" + removeid;
                            form.DeleteImage.Enabled = true;
                            //Debug.WriteLine(form.removeid);
                        }
                    }
                    return link;
                } catch (Exception e) {
                    throw new Exception(e.Message);
                }
            }
        }

        internal static bool DeleteImage(MainForm form, string link, string rmid)
        {
            if (!link.Contains("fastpic.ru") || rmid == "") return false;
            using (var client = new WebClient()) {
                try {
                    var tmp = rmid.Split('=');
                    client.Headers.Add(HttpRequestHeader.Cookie, "fp_sid=" + tmp[1]);

                    var response = client.UploadValues("http://fastpic.ru/my.php?act=delete", "POST", new NameValueCollection {
                        {"pics["+tmp[0]+"]","on"}
                    });

                    var result = Encoding.UTF8.GetString(response);
                    //Debug.WriteLine(result);
                    if (result!="") {
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
