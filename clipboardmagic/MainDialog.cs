using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace clipboardmagic
{
    public partial class MainDialog : Form
    {
        delegate void UpdateText(string text);
        Timer _timer = new Timer();
        ClipBoardPoller poler = new ClipBoardPoller();
        Timer _fileTimer = new Timer();
        Timer uploadTimer = new Timer();
        string backupToServer = "";
        string LastText = "";
        bool _updateDifference = true;
        bool DiffOrReplace = true;
        bool bytesstream = false;
        string replace = "";
        string with = "";
        Webclient client = new Webclient();
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        int comparetextstringcharacters = 0;
        char[] compare1 = null;
        char[] compare2 = null;
        UploadPeriod uploadPeriod = UploadPeriod.EveryFive;
        int MaxUploadSize = 100000;
        ScratchPad scratchPad = new ScratchPad();

        public MainDialog()
        {
            InitializeComponent();

            _fileTimer.Interval = (1000 * 60 * 60 * 24); // one day
            _fileTimer.Tick += new EventHandler(_fileTimer_Tick);
            _fileTimer.Start();

            uploadTimer.Tick += UploadTimer_Tick;
            poler.newTextHandler += new ClipBoardPoller.NewText(poler_newTextHandler);
            client.uploadComplete += new Webclient.UploadComplete(client_uploadComplete);     
         }

      

        void client_uploadComplete(string text)
        {
            updateUploadLabel(text);
        }

        public static string ByteArrayToString(byte[] ba, bool makehex=false)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                if (makehex)
                {
                    hex.AppendFormat("0x{0:x2}, ", b);
                }
                else
                {
                    hex.AppendFormat("{0:x2}", b);
                }
            }
            return hex.ToString();
        }


        void printBytesToWindow(byte[] data, string text)
        {
            string decodedString = "";
            
            decodedString = ByteArrayToString(data, bytesstream);
            

            inputLengthLabel.Text = text.Length.ToString();
            OutputLength.Text = data.Length.ToString();
            updateDifference(decodedString);
        }

        void poler_newTextHandler(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] _data = Encoding.ASCII.GetBytes(text);
                Encryption(_data, RSA.ExportParameters(false), false);
                if (encodeBase64ToolStripMenuItem.Checked)
                {
                    update(text);
                    inputLengthLabel.Text = text.Length.ToString();
                    try
                    {
                        byte[] bytes_ = StringToByteArray(text);
                        string converted = Convert.ToBase64String(bytes_);

                        updateDifference(converted);
                        OutputLength.Text = converted.Length.ToString();
                    }
                    catch
                    {
                        updateDifference("");
                    }
                }
                else if (decodeBase64ToolStripMenuItem.Checked)
                {
                    update(text);
                    try
                    {
                        byte[] data = Convert.FromBase64String(text);
                        printBytesToWindow(data, text);
                    }
                    catch
                    {
                    }
                   
                }
                else if (textToHexToolStripMenuItem.Checked)
                {
                    update(text);
                    try
                    {
                        byte[] data = Encoding.ASCII.GetBytes(text);
                        printBytesToWindow(data, text);
                    }
                    catch
                    {
                    }
                   
                }
                else if (encodeSHA1ToolStripMenuItem.Checked)
                {
                    update(text);
                    byte[] data = EncodeSHA1(text);
                    printBytesToWindow(data, text); 
                }
                else if (compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Checked)
                {
                    if (comparetextstringcharacters == 0)
                    {
                        compare1 = text.ToCharArray();
                        comparetextstringcharacters++;
                    }
                    else
                    {
                        List<char> compareList = new List<char>();
                        List<char> compareList2 = new List<char>();

                        foreach (char c in compare1)
                        {
                            if (!compareList.Contains(c))
                            {
                                compareList.Add(c);
                            }
                        }

                        compare2 = text.ToCharArray();

                        foreach (char c in compare2)
                        {
                            if (!compareList2.Contains(c))
                            {
                                compareList2.Add(c);
                            }
                        }

                        List<char> diffList = new List<char>();
                        foreach (char c in compareList)
                        {
                            if (!compareList2.Contains(c))
                            {
                                diffList.Add(c);
                            }
                        }
                        string tt = "";
                        foreach (char c in diffList)
                        {
                            tt += c + " ";
                        }
                        updateDifference(tt);
                        comparetextstringcharacters = 0;
                    }

                   
                }
                else if (text != LastText)
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

            if (uploadPeriod == UploadPeriod.WhenCoppied)
            {
                lock (backupToServer)
                {
                    sendtoServer(text);
                    backupToServer = "";
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
                    if (encodeBase64ToolStripMenuItem.Checked)
                    {
                        
                    }
                    else if (decodeBase64ToolStripMenuItem.Checked)
                    {
                        try
                        {
                            byte[] data = Convert.FromBase64String(text);
                            string decodedString = Encoding.UTF8.GetString(data);
                            text = decodedString;
                        }
                        catch
                        {
                        }

                    }
                    else if (DiffOrReplace)
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
            string nums = "";

            for (int n = 0; n < _last.Length; n++)
            {
                if (n < _text.Length)
                {
                    if (_last[n] != _text[n])
                    {
                        result[n] = _text[n];
                        nums += n.ToString() + " ";
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
            _res += ":" + nums;
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
                lock (backupToServer)
                {
                    backupToServer += text + "\n\r";
                }
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                scratchPad.FormClosed += ScratchPad_FormClosed;
                scratchPad.Show();
                if (File.Exists("userinfo.dat"))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(User));
                    UserCredentialsStore store = UserCredentialsStore.GetInstance();
                    Random rand = new Random();
                    int r = rand.Next();
                    StreamReader file = new StreamReader("userinfo.dat");
                    User user = (User)ser.Deserialize(file);
                    store.Credentials = user;
                    CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();
                    //ClipboardServiceTest.ClipboardInterfaceClient remoteClipboard = new ClipboardServiceTest.ClipboardInterfaceClient();
                    store.Valid = remoteClipboard.checkCredantials(store.Username, store.getPassword(r), r);
                    SendButton.Enabled = store.Valid;
                    uploadScheduleToolStripMenuItem.Enabled = store.Valid;
                    if(store.Valid)
                    {
                        MaxUploadSize = remoteClipboard.getMaxSize();
                        uploadTimer.Interval = 60 * 1000 * 5;
                        uploadTimer.Start();
                    }
                    remoteClipboard.Close();
                }
                scratchPad.LoadScratchDates();
            }
            catch(Exception ex)
            {

            }
        }

        private void ScratchPad_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _fileTimer_Tick(null, null);
                XmlSerializer ser = new XmlSerializer(typeof(User));
                UserCredentialsStore store = UserCredentialsStore.GetInstance();
                StreamWriter file = new StreamWriter("userinfo.dat");
                ser.Serialize(file, store.Credentials);
            }
            catch(Exception ex)
            {

            }
            lock (backupToServer)
            {
                sendtoServer(backupToServer);
            }
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
                bytesstream = optionsDialog.ByteStreamComa;
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
            UserCredentialsStore store = UserCredentialsStore.GetInstance();
            lock (backupToServer)
            {
                if (!string.IsNullOrEmpty(backupToServer))
                {
                    sendtoServer(backupToServer);
                    backupToServer = "";
                }
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

        private void decodeBase64ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (decodeBase64ToolStripMenuItem.Checked)
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                optionsToolStripMenuItem1.Enabled = true;
            }
            else
            {
                decodeBase64ToolStripMenuItem.Checked = true;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = false;
            }
        }

        private void textToHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textToHexToolStripMenuItem.Checked)
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = true;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = true;
                textToHexToolStripMenuItem.Checked = false;
            }
            else
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = false;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = false;
                textToHexToolStripMenuItem.Checked = true;
            }
        }

        private void encodeSHA1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (encodeSHA1ToolStripMenuItem.Checked)
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = true;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = true;
                textToHexToolStripMenuItem.Checked = false;
                textToHexToolStripMenuItem.Enabled = true;
                encodeSHA1ToolStripMenuItem.Checked = false;
            }
            else
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = false;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = false;
                textToHexToolStripMenuItem.Checked = false;
                textToHexToolStripMenuItem.Enabled = false;
                encodeSHA1ToolStripMenuItem.Checked = true;
            }
        }

        byte[] EncodeSHA1(string text)
        {
            var input = new UTF8Encoding().GetBytes(text);
            var output = new SHA1CryptoServiceProvider().ComputeHash(input);
            return output;
        }

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey); encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                } return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private void openBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BinaryReader read = new BinaryReader(File.Open(file.FileName, FileMode.Open));
                byte[] contents = read.ReadBytes((int)read.BaseStream.Length);

                
                DisplayText test = new DisplayText(Convert.ToBase64String(contents)/*ByteArrayToString(contents)*/);
                test.ShowDialog();
            }
        }

        private void displayTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void encodeBase64ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (encodeBase64ToolStripMenuItem.Checked)
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = true;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = true;
                textToHexToolStripMenuItem.Checked = false;
                textToHexToolStripMenuItem.Enabled = true;
                encodeSHA1ToolStripMenuItem.Checked = false;
                encodeBase64ToolStripMenuItem.Checked = false;
            }
            else
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = false;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = false;
                textToHexToolStripMenuItem.Checked = false;
                textToHexToolStripMenuItem.Enabled = false;
                encodeSHA1ToolStripMenuItem.Checked = false;
                encodeBase64ToolStripMenuItem.Checked = true;
            }
        }

        public byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void compareAllCharacterInTheNextTwoCopiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Checked)
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = true;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = true;
                textToHexToolStripMenuItem.Checked = false;
                textToHexToolStripMenuItem.Enabled = true;
                encodeSHA1ToolStripMenuItem.Checked = false;
                encodeBase64ToolStripMenuItem.Checked = false;
                compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Checked = false;
            }
            else
            {
                decodeBase64ToolStripMenuItem.Checked = false;
                decodeBase64ToolStripMenuItem.Enabled = false;
                optionsToolStripMenuItem1.Checked = false;
                optionsToolStripMenuItem1.Enabled = false;
                textToHexToolStripMenuItem.Checked = false;
                textToHexToolStripMenuItem.Enabled = false;
                encodeSHA1ToolStripMenuItem.Checked = false;
                encodeBase64ToolStripMenuItem.Checked = false;
                compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Checked = true;
            }
        }

        private void openClipboardFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.Open(file.FileName, FileMode.Open));
                String everything = read.ReadToEnd();
                clipboardText.Text = everything;
            }
        }

        private void userCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserCredentials usercred = new UserCredentials();
            if(usercred.ShowDialog() == DialogResult.OK)
            {
                UserCredentialsStore store = UserCredentialsStore.GetInstance();
                if(store.Valid)
                {
                    SendButton.Enabled = true;
                    uploadScheduleToolStripMenuItem.Enabled = true;
                }
            }
        }
      

        private void LoadButton_Click(object sender, EventArgs e)
        {
            DownloadClipboard upload = new DownloadClipboard();
            if(upload.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Random rand = new Random();
                    int r = rand.Next();
                    UserCredentialsStore store = UserCredentialsStore.GetInstance();
                    CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();
                    CodinggainClipboardService.EncryptionData enData = remoteClipboard.getAccessRights(store.Username, store.getPassword(r), true, r);
                    CodinggainClipboardService.ReturnInterface data = remoteClipboard.getClipboardContent(store.Username, store.getPassword(r), upload.Fromdate, upload.Todate, enData.access_key_id, r);
                    if (data.success)
                    {
                        string str = Decode(data.content, (byte)enData.encrypt_key);
                        update(str);
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void uploadScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadSchedule schedule = new UploadSchedule(uploadPeriod);
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                uploadPeriod = schedule.Period;
                if ((uploadPeriod == UploadPeriod.Manual) || (uploadPeriod == UploadPeriod.WhenClosed) || (uploadPeriod == UploadPeriod.WhenCoppied))
                {
                    return;
                }
                if (uploadPeriod == UploadPeriod.EveryMin)
                {
                    uploadTimer.Interval = 60 * 1000;
                }
                else if (uploadPeriod == UploadPeriod.EveryFive)
                {
                    uploadTimer.Interval = 60 * 1000 * 5;
                }

                uploadTimer.Start();
            }
        }

        delegate bool SendToServer(string text);

        private bool sendtoServer(string text)
        {
            try
            {
                if (text.Length > MaxUploadSize)
                {
                    int size = text.Length;
                    string local = text;
                    text = local.Substring(0, MaxUploadSize);
                    string whatsleft = text.Substring(MaxUploadSize, size);
                  //  Invoke(new SendToServer(sendtoServer, new object[] { whatsleft }));
                }
                Random rand = new Random();
                int r = rand.Next();
                UserCredentialsStore store = UserCredentialsStore.GetInstance();
                CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();
                CodinggainClipboardService.EncryptionData enData = remoteClipboard.getAccessRights(store.Username, store.getPassword(r), true, r);
                if (enData.useable)
                {
                    string str = Encode(backupToServer, (byte)enData.encrypt_key);
                    if (!remoteClipboard.putClipboardContent(store.Username, store.getPassword(r), str, enData.access_key_id, r))
                    {
                        DifferenceTextBox.Text = "Unable to upload clip text!";
                    }
                }
                else
                {
                    DifferenceTextBox.Text = "Passwar not useable";
                }
                remoteClipboard.Close();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        private void UploadTimer_Tick(object sender, EventArgs e)
        {
            lock (backupToServer)
            {
                if (!string.IsNullOrEmpty(backupToServer))
                {
                    sendtoServer(backupToServer);
                    backupToServer = "";
                }
            }
        }

        private void clipboardText_TextChanged(object sender, EventArgs e)
        {

        }

        private string Encode(string content, byte key)
        {
            byte[] data = Encoding.ASCII.GetBytes(content.ToCharArray());
            return Convert.ToBase64String(scramble(data, key));
  
        }

        private string Decode(string content, byte key)
        {
            byte[] data = scramble(Convert.FromBase64String(content), key);
            return System.Text.Encoding.UTF8.GetString(data);
        }

        private byte[] scramble(byte[] data, byte key)
        {
            byte[] o = new byte[data.Length];
            int count = 0;
            foreach(byte d in data)
            {
                o[count] = (byte)(d^key);
                count++;
            }
            return o;
        }

        private string encodePassword(string username, string password)
        {
            string pass = "";
            try
            {
                int i = 0;
                char[] _username = username.ToCharArray();
                char[] _password = password.ToCharArray();
                byte[] data = new byte[_password.Length];

                for(int n = 0; n < data.Length; n++)
                {
                    data[n] = (byte)((byte)_password[n] ^ (byte)_username[i++]);
                    if(i == _username.Length)
                    {
                        i = 0;
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return pass;
        }

        private void searchDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SearchDatabase search = new SearchDatabase();
                if (search.ShowDialog() == DialogResult.OK)
                {
                    string criteria = search.Criteria;
                    Random rand = new Random();
                    int r = rand.Next();
                    UserCredentialsStore store = UserCredentialsStore.GetInstance();
                    CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();
                    CodinggainClipboardService.EncryptionData enData = remoteClipboard.getAccessRights(store.Username, store.getPassword(r), true, r);
                    CodinggainClipboardService.ReturnInterface content = remoteClipboard.searchClipboard(store.Username, store.getPassword(r), criteria, enData.access_key_id, r, 0);
                    if (content != null && content.success)
                    {
                        string contents = "";
                        string errors = "";
                        if (content.numberOfSegments > 1)
                        {
                            int segs = content.numberOfSegments;
                            for (int n = 0; n < segs; n++)
                            {
                                try
                                {
                                    enData = remoteClipboard.getAccessRights(store.Username, store.getPassword(r), true, r);
                                    content = remoteClipboard.searchClipboard(store.Username, store.getPassword(r), criteria, enData.access_key_id, r, n + 1);
                                    if (content != null && content.success)
                                    {
                                        contents += Decode(content.content, (byte)enData.encrypt_key);
                                    }
                                }
                                catch(Exception ex)
                                {
                                    errors += " : Errors!!";
                                }
                            }
                        }
                        else
                        {
                            contents = Decode(content.content, (byte)enData.encrypt_key);
                        }
                        DisplayText dis = new DisplayText(contents);
                        dis.SearchWord(criteria);
                        dis.updateTitle(errors);
                        dis.ShowDialog();
                    }
                    else
                    {
                        DisplayText dis = new DisplayText("Did not return any results!");
                        dis.SearchWord(criteria);
                        dis.ShowDialog();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
