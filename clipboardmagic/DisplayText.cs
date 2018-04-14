using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clipboardmagic
{
    public partial class DisplayText : Form
    {
        public DisplayText(string displayText)
        {
            InitializeComponent();
            DisplayTextBox.Text = displayText;
        }

        public void SearchWord(string text)
        {
            Highlight(DisplayTextBox, text, Color.Red);
        }

        public void updateTitle(string title)
        {
            this.Text = this.Text + title;
        }

        private void Highlight(RichTextBox myRtb, string word, Color color)
        {
            if (word == string.Empty)
                return;

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }
    }
}
