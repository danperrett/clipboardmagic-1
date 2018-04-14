using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clipboardmagic
{
    class ClipBoardPoller
    {
        Timer _timer = new Timer();
        public delegate void NewText(string text);
        public event NewText newTextHandler = null;
        public delegate void NoDifference();
        public event NoDifference NoDiffernceHandler = null;
        public string LastListString = "";

        bool nodifferenceSent = false;
        bool justFlagged = false;
        string LastText = "";

        public ClipBoardPoller()
        {
            _timer.Interval = 500;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }


        void _timer_Tick(object sender, EventArgs e)
        {
            getText();
            getFileDropList();         
        }

        private void getFileDropList()
        {
            System.Collections.Specialized.StringCollection list;
            if (Clipboard.ContainsFileDropList())
            {
                list = Clipboard.GetFileDropList();
                if (!list.Contains(LastListString))
                {
                    if (newTextHandler != null)
                    {
                        foreach (string str in list)
                        {
                            newTextHandler(str);
                        }
                    }
                    if (list.Count > 0)
                    {
                        LastListString = list[list.Count - 1];
                    }
                }  
            }
            else
            {
                LastListString = "";
            }
        }

        public void getText()
        {
            string text = Clipboard.GetText();
            if (!string.IsNullOrEmpty(text))
            {
                if (text != LastText)
                {
                    nodifferenceSent = false;
                    if (newTextHandler != null)
                    {
                        newTextHandler(text);
                    }
                    LastText = text;
                    justFlagged = true;
                }
                else
                {
                    if (!nodifferenceSent)
                    {
                        if (NoDiffernceHandler != null)
                        {
                            NoDiffernceHandler();
                        }
                        nodifferenceSent = true;
                    }
                }
            }
        }
    }
}
