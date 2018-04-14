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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DifferenceRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ReplaceTextRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void SetData(bool diff, bool replace, string _replace, string with)
        {
            DifferenceRadioButton.Checked = diff;
            ReplaceTextRadioButton.Checked = replace;
            ReplaceTextBox.Text = _replace;
            WithTextBox.Text = with;
        }

        public string Replace
        {
            get
            {
                return ReplaceTextBox.Text;
            }
        }

        public string With
        {
            get
            {
                return WithTextBox.Text;
            }
        }

        public bool Difference
        {
            get
            {
                return DifferenceRadioButton.Checked;
            }
        }

        public bool ReplaceFlag
        {
            get
            {
                return ReplaceTextRadioButton.Checked;
            }
        }
    }
}
