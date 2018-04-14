using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace clipboardmagic
{
    public partial class MainDialog : Form
    {
        delegate void UpdateText(string text);
        Timer _timer = new Timer();
        ClipBoardPoller poler = new ClipBoardPoller();
        Timer _fileTimer = new Timer();
        string backupToServer = "";
        string LastText = "";
        bool _updateDifference = true;
        bool DiffOrReplace = true;
        string replace = "";
        string with = "";
        Webclient client = new Webclient();


        public MainDialog()
        {
            InitializeComponent();

            _fileTimer.Interval = (1000 * 60 * 60 * 24); // one day
            _fileTimer.Tick += new EventHandler(_fileTimer_Tick);
            _fileTimer.Start();

            poler.newTextHandler += new ClipBoardPoller.NewText(poler_newTextHandler);
            client.uploadComplete += new Webclient.UploadComplete(client_uploadComplete);     
         }

        void client_uploadComplete(string text)
        {
            updateUploadLabel(text);
        }

        void poler_newTextHandler(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (text != LastText)
                {
                    if (DiffOrReplace)
                    {
                        checkDifference(text);
                    }
                    else
                    {
                        replaceText(text);
                    }
                    inputLengthLabel.Text = text.Length.ToString();
                    LastText = text;
                    update(text);
                }
                else
                {
                    if (_updateDifference)
                    {
                        _updateDifference = false;
                        updateDifference("No Difference!");
                    }
                }
            }
        }

        void _fileTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime _now = DateTime.Now;
                string file = "Contents" + _now.Hour + _now.Day + _now.Month + _now.Year + ".dat";
                FileStream _file = new FileStream(file, FileMode.CreateNew, FileAccess.Write);
                string clipboard = clipboardText.Text;

                byte[] array = Encoding.ASCII.GetBytes(clipboard);
                _file.Write(array, 0, array.Length);
                _file.Close();
            }
            catch
            {
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            getText();
        }
        
        public void getText()
        {
            string text = Clipboard.GetText();
            if (!string.IsNullOrEmpty(text))
            {
                if (text != LastText)
                {
                    if (DiffOrReplace)
                    {
                        checkDifference(text);
                    }
                    else
                    {
                        replaceText(text);
                    }
                    inputLengthLabel.Text = text.Length.ToString();
                    LastText = text;
                    update(text);
                }
                else
                {
                    if (_updateDifference)
                    {
                        _updateDifference = false;
                        updateDifference("No Difference!");
                    }
                }
            }
        }

        private void replaceText(string textin)
        {
            if (!string.IsNullOrEmpty(replace))
            {
                string textout = textin.Replace(replace, with);
                updateDifference(textout);
            }
        }

        private void checkDifference(string latest)
        {
            char[] _last = LastText.ToCharArray();
            char[] _text = latest.ToCharArray();
            char[] result = new char[_last.Length];

            for (int n = 0; n < _last.Length; n++)
            {
                if (n < _text.Length)
                {
                    if (_last[n] != _text[n])
                    {
                        result[n] = _text[n];
                    }
                    else
                    {
                        result[n] = ' ';
                    }
                }
                else
                {
                    result[n] = _last[n];
                }
            }
            string _res = new string(result);

            updateDifference(_res);
        }

        private void updateDifference(string text)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new UpdateText(updateDifference), new object[] { text });
            }
            else
            {
                DifferenceTextBox.Text = text;
            }
        }

        void update(string text)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new UpdateText(update), new object[] { text });
            }
            else
            {
                clipboardText.AppendText(text + "\n\r");
                backupToServer += text + "\n\r";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _fileTimer_Tick(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Options optionsDialog = new Options();
            optionsDialog.SetData(DiffOrReplace, !DiffOrReplace, replace, with);
            if (optionsDialog.ShowDialog() == DialogResult.OK)
            {
                DiffOrReplace = optionsDialog.Difference;
                replace = optionsDialog.Replace;
                with = optionsDialog.With;
            }
        }

        private void MainDialog_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void MainDialog_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void RestoreMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void SendButton_Click(object sender, EventArgs e)
        {            
            string output = "";
            if (!string.IsNullOrEmpty(backupToServer))
            {
                updateUploadLabel("Uploading");
                client.PostClipboardToServer("danperre", "images", backupToServer, out output);
                backupToServer = "";
            }
        }

        public void updateUploadLabel(string text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateText(updateUploadLabel), new object[] { text });
            }
            else
            {
                text = text.ToLower().Replace("<html>", "").Replace("<head>", "").Replace("</html>", "").Replace("</head>", "").Replace("<h1>", "").Replace("</h1>", "");
                uploadlabel.Text = text;
            }
        }
    }
}
