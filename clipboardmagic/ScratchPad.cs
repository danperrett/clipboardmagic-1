﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clipboardmagic
{
    public partial class ScratchPad : Form
    {
        Timer uploadTimer = new Timer();
        int counter = 0;
        class DateListComboInfo
        {
            public string date = "";
            public string title = "";
            public int id = -1;
        }

        List<DateListComboInfo> dateList = new List<DateListComboInfo>();
        string currentContent = "";

        delegate void SetScratchTextdelegate(string text, string title);

        public ScratchPad()
        {
            InitializeComponent();
            LoadScratchDates();
            
            uploadTimer.Interval += 60*1000;
            uploadTimer.Tick += UploadTimer_Tick;
            uploadTimer.Start();
        }

        public void intialise()
        {
            if (dateList.Count > 0)
            {
                int id = dateList[dateList.Count - 1].id;
                GetSetText(id);
            }
        }

        public void LoadScratchDates()
        {
            dateList.Clear();
            SelectComboBox.Items.Clear();
            CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();
            if(remoteClipboard != null)
            {
                Random rand = new Random();
                int r = rand.Next();
                UserCredentialsStore store = UserCredentialsStore.GetInstance();
                if (store.Valid)
                {
                    SaveButton.Enabled = true;
                    CodinggainClipboardService.EncryptionData enData = remoteClipboard.getAccessRights(store.Username, store.getPassword(r), true, r);
                    CodinggainClipboardService.ScratchDataInfo[] dates = remoteClipboard.getScratchDates(store.Username, store.getPassword(r), enData.access_key_id, r);
                    
                    foreach (CodinggainClipboardService.ScratchDataInfo info in dates)
                    {
                        try
                        {
                            if (info.date != null)
                            {
                                DateListComboInfo dl = new DateListComboInfo();
                                dl.date = info.date;
                                if(info.title !=null)
                                {
                                    dl.title = info.title;
                                }
                                dl.id = info.id;
                                dateList.Add(dl);
                                // ListViewItem item = new ListViewItem(info.date);
                                string tt = info.date;
                                if(info.title !=null)
                                {
                                    tt += " " + info.title;
                                }
                                SelectComboBox.Items.Add(info.date + " " + tt);
                            }
                        }
                        catch(Exception ex)
                        {

                        }
                    }

                    if(dates.Length > 0)
                    {
                        SelectComboBox.SelectedIndex = 0;
                        SelectComboBox.Text = dates[0].date;
                    }
                   
                }
            }
        }

        private void sendData()
        {
            CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();

            if (!string.IsNullOrEmpty(ScratchPadTextBox.Text) && ScratchPadTextBox.Text != currentContent)
            {
                EncoderDecoder encoder = new EncoderDecoder();
                Random rand = new Random();
                int r = rand.Next();
                UserCredentialsStore store = UserCredentialsStore.GetInstance();
                CodinggainClipboardService.EncryptionData enData = remoteClipboard.getAccessRights(store.Username, store.getPassword(r), true, r);
                string str = encoder.Encode(ScratchPadTextBox.Text, (byte)enData.encrypt_key);
                currentContent = ScratchPadTextBox.Text;
                int id = remoteClipboard.putScratchPad(store.Username, store.getPassword(r), TitleTextBox.Text, str, ImportantCheckBox.Checked, false, enData.access_key_id, r, 0);
                if (ImportantCheckBox.Checked)
                    ImportantCheckBox.Checked = false;
                LoadScratchDates();
            }
        }

        private void UploadTimer_Tick(object sender, EventArgs e)
        {
            sendData();
            if(counter%2 == 0)
            {
                LoadScratchDates();
            }

            counter++;
        }

        private void setScratchText(String text, string title)
        {
            if(InvokeRequired)
            {
                this.BeginInvoke(new SetScratchTextdelegate(setScratchText), new object[] { text });
            }
            else
            {
                TitleTextBox.Text = title;
                ScratchPadTextBox.Text = text;
            }
        }

        private void GetSetText(int id)
        {
            UserCredentialsStore store = UserCredentialsStore.GetInstance();
            if (store.Valid)
            {
                Random rand = new Random();
                int r = rand.Next();
                CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();
                CodinggainClipboardService.EncryptionData enData = remoteClipboard.getAccessRights(store.Username, store.getPassword(r), true, r);
                CodinggainClipboardService.ScratchDataInfo data = remoteClipboard.getScratchData(store.Username, store.getPassword(r), id, enData.access_key_id, r);
                if (data != null)
                {
                    if (data.containsdata)
                    {
                        currentContent = data.content;
                        string title = data.title;
                        if(title == null)
                        {
                            title = "";
                        }
                        setScratchText(currentContent, title);
                    }
                }
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            int index = SelectComboBox.SelectedIndex;
            int id = dateList[index].id;
            GetSetText(id);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;
            sendData();
            SaveButton.Enabled = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;
            SelectButton.Enabled = false;
            ScratchPadTextBox.ReadOnly = true;
            ScratchPadTextBox.Text = "";
            SaveButton.Enabled = true;
            SelectButton.Enabled = true;
            ScratchPadTextBox.ReadOnly = false;
        }
    }
}
