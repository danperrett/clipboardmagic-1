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
    public partial class SearchDatabase : Form
    {
        public String Criteria = "";
        public SearchDatabase()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Criteria = CriteriaTextBox.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
