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
    public partial class UserCredentials : Form
    {
        UserCredentialsStore store = UserCredentialsStore.GetInstance();
        public UserCredentials()
        {
            InitializeComponent();
            UsernameTextBox.Text = store.Username;
            PasswordTextBox.Text = store.Password;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
            store.Username = UsernameTextBox.Text;
            store.Password = PasswordTextBox.Text;
            try
            {
                Random rand = new Random();
                int r = rand.Next();
                CodinggainClipboardService.ClipboardInterfaceClient remoteClipboard = new CodinggainClipboardService.ClipboardInterfaceClient();
                
                //ClipboardServiceTest.ClipboardInterfaceClient remoteClipboard = new ClipboardServiceTest.ClipboardInterfaceClient();
                store.Valid = remoteClipboard.checkCredantials(store.Username, store.getPassword(r), r);
                remoteClipboard.Close();
                
            }
            catch(Exception ex)
            {
                store.Valid = false;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
