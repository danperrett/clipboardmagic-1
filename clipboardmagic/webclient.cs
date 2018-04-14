using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Configuration;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;

namespace clipboardmagic
{
    public class WebUpload : WebClient
    {
        private int _timeout;

       
        /// <summary>
        /// Time in milliseconds
        /// </summary>
        public int Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
            }
        }

        public WebUpload()
        {
            this._timeout = 60000;
        }

        public WebUpload(int timeout)
        {
            this._timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var result = base.GetWebRequest(address);
            result.Timeout = this._timeout;
            return result;
        }
    }

    public class Webclient
    {
        public delegate void UploadComplete(string text);
        public event UploadComplete uploadComplete;

        public Webclient()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool PostClipboardToServer(string username, string password, string text, out string output)
        {
            bool ret = false;
            try
            {
                WebProxy wProxy = (WebProxy)WebProxy.GetDefaultProxy();
                wProxy.Credentials = new NetworkCredential("dan.perrett", "password", "MYANITE");
                wProxy.Credentials = (System.Net.NetworkCredential)System.Net.CredentialCache.DefaultCredentials;

                System.Net.GlobalProxySelection.Select = wProxy;
                string URI = "http://www.danperrett.com:8000/ClipBoardData";

                WebUpload wc = new WebUpload(5 * 60 * 1000);
                wc.Proxy = wProxy;

                SetAllowUnsafeHeaderParsing20();

                wc.Headers["Content-type"] = "application/x-www-form-urlencoded";

                text = text.Substring(0, text.Length - 2);
                text = text.Trim();
                NameValueCollection myNameValueCollection = new NameValueCollection();
                // Add necessary parameter/value pairs to the name/value container.
                myNameValueCollection.Add("name", username);            
                myNameValueCollection.Add("password", password);
                myNameValueCollection.Add("data", text);

                wc.UploadValuesCompleted += new UploadValuesCompletedEventHandler(wc_UploadValuesCompleted);
                wc.UploadValuesAsync(new Uri(URI), myNameValueCollection);
                
               
                //output = System.Text.ASCIIEncoding.ASCII.GetString(ret_b);
                output = "complete";
                ret = true;
            }
            catch
            {
                output = "Error";
            }

            return ret;
        }

        void wc_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            string output = System.Text.ASCIIEncoding.ASCII.GetString(e.Result);
            if (uploadComplete != null)
            {
                uploadComplete(output);
            }
        }

        void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            
        }

        public bool PostToServer(string username, string password, string project, string filename, out string ret)
        {
           // filename = "C:\\Users\\Public\\Pictures\\Sample Pictures\\Forest.jpg";
            try
            {
                WebProxy wProxy = (WebProxy)WebProxy.GetDefaultProxy();
                wProxy.Credentials = new NetworkCredential("dan.perrett", "password", "MYANITE");
                wProxy.Credentials = (System.Net.NetworkCredential)System.Net.CredentialCache.DefaultCredentials;
                // See what proxy is used for resource.
                //Uri resourceProxy = proxy.GetProxy(url);

                // WebProxy wProxy = new WebProxy("http://10.4.1.200:80");

                //wProxy.Credentials
                System.Net.GlobalProxySelection.Select = wProxy;
                string URI = "http://www.danperrett.com:8000/uploadFile";
              //  string myParamters = "project=" + project + "&datafile=" + System.Web.HttpUtility.UrlEncode(contents);

                WebUpload wc = new WebUpload(5*60*1000);
                wc.Proxy = wProxy;
                string[] file_s = filename.Split('\\');
                string file = file_s[file_s.Length - 1];
                //file = project + "/" + file;
                //file = file.Replace("/", "%2F");
                SetAllowUnsafeHeaderParsing20();

                wc.Headers["Content-type"] = "image/jpg";
                wc.QueryString["directory"] = project + "/" + file;
                wc.QueryString["username"] = username;
                wc.QueryString["password"] = password;
             
                wc.UploadFileCompleted += new UploadFileCompletedEventHandler(wc_UploadFileCompleted);
                byte[] ret_b = wc.UploadFile(URI, filename);
                ret = System.Text.ASCIIEncoding.ASCII.GetString(ret_b);

                return true;
            }
            catch
            {
                ret = "Unsuccessful";
                return false;
            }
        }

        void wc_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            if (uploadComplete != null)
            {
                uploadComplete("Fin");
            }
        }
    

        public string setUpWeb(string url)
        {
            try
            {
                WebProxy wProxy = (WebProxy)WebProxy.GetDefaultProxy();
                wProxy.Credentials = new NetworkCredential("dan.perrett", "password", "MYANITE");
                wProxy.Credentials = (System.Net.NetworkCredential)System.Net.CredentialCache.DefaultCredentials;
                // See what proxy is used for resource.
                //Uri resourceProxy = proxy.GetProxy(url);

                // WebProxy wProxy = new WebProxy("http://10.4.1.200:80");

                //wProxy.Credentials
                System.Net.GlobalProxySelection.Select = wProxy;
                SetAllowUnsafeHeaderParsing20();


                HttpWebRequest myHttpWebRequest1 =
                       (HttpWebRequest)WebRequest.Create(url);

                myHttpWebRequest1.KeepAlive = false;
                myHttpWebRequest1.Timeout = 5 * 60 * 1000;
                // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
                HttpWebResponse myHttpWebResponse1 =
                  (HttpWebResponse)myHttpWebRequest1.GetResponse();


                // we will read data via the response stream
                Stream resStream = myHttpWebResponse1.GetResponseStream();

                string tempString = null;
                int count = 0;
                // used on each read operation
                byte[] buf = new byte[8192];

                // used to build entire input
                StringBuilder sb = new StringBuilder();

                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);

                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);

                        // continue building the string
                        sb.Append(tempString);
                    }
                } while (count > 0); // any more data to read?

                resStream.Close();


                return sb.ToString();
            }
            catch
            {
                return null;
            }
        }

        public byte[] getFile(string file)
        {
            try
            {
                WebProxy wProxy = (WebProxy)WebProxy.GetDefaultProxy();
                wProxy.Credentials = new NetworkCredential("dan.perrett", "password", "MYANITE");
                wProxy.Credentials = (System.Net.NetworkCredential)System.Net.CredentialCache.DefaultCredentials;
                // See what proxy is used for resource.
                //Uri resourceProxy = proxy.GetProxy(url);

                // WebProxy wProxy = new WebProxy("http://10.4.1.200:80");

                //wProxy.Credentials
                System.Net.GlobalProxySelection.Select = wProxy;
                string url = "http://www.danperrett.com:8000/GetUserFile?username=dperrett&password=images&file=" + file;

                SetAllowUnsafeHeaderParsing20();


                HttpWebRequest myHttpWebRequest1 =
                       (HttpWebRequest)WebRequest.Create(url);

                myHttpWebRequest1.KeepAlive = false;
                myHttpWebRequest1.Timeout = 5 * 60 * 1000;
                // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
                HttpWebResponse myHttpWebResponse1 =
                  (HttpWebResponse)myHttpWebRequest1.GetResponse();


                // we will read data via the response stream
                Stream resStream = myHttpWebResponse1.GetResponseStream();

                int count = 0;
                // used on each read operation
                byte[] buf = null;
                int totalSize = 0;
                List<byte[]> TotalBytes = new List<byte[]>();

                do
                {
                    byte[] temp = new byte[8192];
                    // fill the buffer with data

                    count = resStream.Read(temp, 0, temp.Length);

                    // make sure we read some data
                    if (count != 0)
                    {
                        buf = new byte[count];
                        //temp.CopyTo(buf, 0);
                        totalSize += count;
                        for (int n = 0; n < count; n++) buf[n] = temp[n];
                        TotalBytes.Add(buf);
                    }
                } while (count > 0); // any more data to read?

                resStream.Close();

                int index = 0;
                byte[] bigBuf = new byte[totalSize];
                foreach (byte[] b in TotalBytes)
                {
                    b.CopyTo(bigBuf, index);
                    index += b.Length;
                }

                return bigBuf;
            }
            catch
            {
                return null;
            }
        }

        public byte[] getPicture(int id)
        {
            try
            {
                string url = "http://www.danperrett.com:8000/getPicture/" + id.ToString();


                SetAllowUnsafeHeaderParsing20();


                HttpWebRequest myHttpWebRequest1 =
                       (HttpWebRequest)WebRequest.Create(url);

                myHttpWebRequest1.KeepAlive = false;
                myHttpWebRequest1.Timeout = 5 * 60 * 1000;
                // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
                HttpWebResponse myHttpWebResponse1 =
                  (HttpWebResponse)myHttpWebRequest1.GetResponse();


                // we will read data via the response stream
                Stream resStream = myHttpWebResponse1.GetResponseStream();

                int count = 0;
                // used on each read operation
                byte[] buf = null;
                int totalSize = 0;
                List<byte[]> TotalBytes = new List<byte[]>();

                do
                {
                    byte[] temp = new byte[8192];
                    // fill the buffer with data
                   
                    count = resStream.Read(temp, 0, temp.Length);

                    // make sure we read some data
                    if (count != 0)
                    {
                        buf = new byte[count];
                        //temp.CopyTo(buf, 0);
                        totalSize += count;
                        for (int n = 0; n < count; n++) buf[n] = temp[n];
                        TotalBytes.Add(buf);
                    }
                } while (count > 0); // any more data to read?

                resStream.Close();

                int index = 0;
                byte[] bigBuf = new byte[totalSize];
                foreach (byte[] b in TotalBytes)
                {
                    b.CopyTo(bigBuf, index);
                    index += b.Length;
                }

                return bigBuf;
            }
            catch
            {
                return null;
            }
        }


        private bool SetAllowUnsafeHeaderParsing20()
        {
            //Get the assembly that contains the internal class
            System.Reflection.Assembly aNetAssembly = System.Reflection.Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section",
                      BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });

                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
