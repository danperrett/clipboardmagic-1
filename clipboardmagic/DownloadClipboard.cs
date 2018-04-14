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
    public partial class DownloadClipboard : Form
    {
        public string Todate = "";
        public string Fromdate = "";

        public DownloadClipboard()
        {
            InitializeComponent();
            ToDatePicker.CustomFormat = @"yyyy\MM\dd";
            ToDatePicker.Format = DateTimePickerFormat.Custom;
            FromDatePicker.CustomFormat = @"yyyy\MM\dd";
            FromDatePicker.Format = DateTimePickerFormat.Custom;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            string fromdate = FromDatePicker.Value.ToShortDateString();
            string[] fr = fromdate.Split('/');
            string todate = ToDatePicker.Value.ToShortDateString();
            string[] to = todate.Split('/');
            Fromdate = fr[2] + "/" + fr[1] + "/" + fr[0];
            Todate = to[2] + "/" + to[1] + "/" + to[0];
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
        }
    }
}
