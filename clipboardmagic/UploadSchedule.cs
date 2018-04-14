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

    public enum UploadPeriod
    {
        WhenCoppied = 0,
        EveryMin = 1,
        EveryFive = 2,
        Manual = 3,
        WhenClosed = 4,
        Unknown
    };

    public partial class UploadSchedule : Form
    {

        public UploadPeriod Period
        {
            get
            {
                if(WhenNewRadioButton.Checked)
                {
                    return UploadPeriod.WhenCoppied;
                }
                else if(EveryMinRadioButton.Checked)
                {
                    return UploadPeriod.EveryMin;
                }
                else if(EveryFiveMinRadioButton.Checked)
                {
                    return UploadPeriod.EveryFive;
                }
                else if(ManualRadioButton.Checked)
                {
                    return UploadPeriod.Manual;
                }
                else if(WhenClosedRadioButton.Checked)
                {
                    return UploadPeriod.WhenClosed;
                }

                return UploadPeriod.Unknown;
            }
        }
        
        public UploadSchedule(UploadPeriod current)
        {
            InitializeComponent();

            switch(current)
            {
                case UploadPeriod.WhenCoppied:
                    WhenNewRadioButton.Checked = true;
                    break;
                case UploadPeriod.EveryMin:
                    EveryMinRadioButton.Checked = true;
                    break;
                case UploadPeriod.EveryFive:
                    EveryFiveMinRadioButton.Checked = true;
                    break;
                case UploadPeriod.Manual:
                    ManualRadioButton.Checked = true;
                    break;
                case UploadPeriod.WhenClosed:
                    WhenClosedRadioButton.Checked = true;
                    break;
            }
          
        }

        private void WhenNewRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
