namespace clipboardmagic
{
    partial class MainDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.clipboardText = new System.Windows.Forms.RichTextBox();
            this.DifferenceTextBox = new System.Windows.Forms.RichTextBox();
            this.output = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openClipboardFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeBase64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeSHA1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeBase64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareAllCharacterInTheNextTwoCopiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.inputLengthLabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RestoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendButton = new System.Windows.Forms.Button();
            this.uploadlabel = new System.Windows.Forms.Label();
            this.OutputLength = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // clipboardText
            // 
            this.clipboardText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardText.Location = new System.Drawing.Point(2, 27);
            this.clipboardText.Name = "clipboardText";
            this.clipboardText.Size = new System.Drawing.Size(479, 179);
            this.clipboardText.TabIndex = 0;
            this.clipboardText.Text = "";
            this.clipboardText.TextChanged += new System.EventHandler(this.clipboardText_TextChanged);
            // 
            // DifferenceTextBox
            // 
            this.DifferenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DifferenceTextBox.Location = new System.Drawing.Point(0, 258);
            this.DifferenceTextBox.Name = "DifferenceTextBox";
            this.DifferenceTextBox.Size = new System.Drawing.Size(479, 104);
            this.DifferenceTextBox.TabIndex = 1;
            this.DifferenceTextBox.Text = "";
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(-1, 239);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(42, 13);
            this.output.TabIndex = 2;
            this.output.Text = "Output:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(483, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.openBinaryFileToolStripMenuItem,
            this.openClipboardFileToolStripMenuItem,
            this.userCredentialsToolStripMenuItem,
            this.uploadScheduleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openBinaryFileToolStripMenuItem
            // 
            this.openBinaryFileToolStripMenuItem.Name = "openBinaryFileToolStripMenuItem";
            this.openBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openBinaryFileToolStripMenuItem.Text = "Open Binary File";
            this.openBinaryFileToolStripMenuItem.Click += new System.EventHandler(this.openBinaryFileToolStripMenuItem_Click);
            // 
            // openClipboardFileToolStripMenuItem
            // 
            this.openClipboardFileToolStripMenuItem.Name = "openClipboardFileToolStripMenuItem";
            this.openClipboardFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openClipboardFileToolStripMenuItem.Text = "Open Clipboard File";
            this.openClipboardFileToolStripMenuItem.Click += new System.EventHandler(this.openClipboardFileToolStripMenuItem_Click);
            // 
            // userCredentialsToolStripMenuItem
            // 
            this.userCredentialsToolStripMenuItem.Name = "userCredentialsToolStripMenuItem";
            this.userCredentialsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.userCredentialsToolStripMenuItem.Text = "User Credentials";
            this.userCredentialsToolStripMenuItem.Click += new System.EventHandler(this.userCredentialsToolStripMenuItem_Click);
            // 
            // uploadScheduleToolStripMenuItem
            // 
            this.uploadScheduleToolStripMenuItem.Enabled = false;
            this.uploadScheduleToolStripMenuItem.Name = "uploadScheduleToolStripMenuItem";
            this.uploadScheduleToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.uploadScheduleToolStripMenuItem.Text = "Upload Schedule";
            this.uploadScheduleToolStripMenuItem.Click += new System.EventHandler(this.uploadScheduleToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem1,
            this.decodeBase64ToolStripMenuItem,
            this.textToHexToolStripMenuItem,
            this.encodeSHA1ToolStripMenuItem,
            this.encodeBase64ToolStripMenuItem,
            this.compareAllCharacterInTheNextTwoCopiesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(306, 22);
            this.optionsToolStripMenuItem1.Text = "Options";
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
            // 
            // decodeBase64ToolStripMenuItem
            // 
            this.decodeBase64ToolStripMenuItem.Name = "decodeBase64ToolStripMenuItem";
            this.decodeBase64ToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.decodeBase64ToolStripMenuItem.Text = "Decode Base64";
            this.decodeBase64ToolStripMenuItem.Click += new System.EventHandler(this.decodeBase64ToolStripMenuItem_Click);
            // 
            // textToHexToolStripMenuItem
            // 
            this.textToHexToolStripMenuItem.Name = "textToHexToolStripMenuItem";
            this.textToHexToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.textToHexToolStripMenuItem.Text = "TextToHex";
            this.textToHexToolStripMenuItem.Click += new System.EventHandler(this.textToHexToolStripMenuItem_Click);
            // 
            // encodeSHA1ToolStripMenuItem
            // 
            this.encodeSHA1ToolStripMenuItem.Name = "encodeSHA1ToolStripMenuItem";
            this.encodeSHA1ToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.encodeSHA1ToolStripMenuItem.Text = "Encode SHA-1";
            this.encodeSHA1ToolStripMenuItem.Click += new System.EventHandler(this.encodeSHA1ToolStripMenuItem_Click);
            // 
            // encodeBase64ToolStripMenuItem
            // 
            this.encodeBase64ToolStripMenuItem.Name = "encodeBase64ToolStripMenuItem";
            this.encodeBase64ToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.encodeBase64ToolStripMenuItem.Text = "Encode Base64";
            this.encodeBase64ToolStripMenuItem.Click += new System.EventHandler(this.encodeBase64ToolStripMenuItem_Click);
            // 
            // compareAllCharacterInTheNextTwoCopiesToolStripMenuItem
            // 
            this.compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Name = "compareAllCharacterInTheNextTwoCopiesToolStripMenuItem";
            this.compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Text = "compare all character in the next two copies";
            this.compareAllCharacterInTheNextTwoCopiesToolStripMenuItem.Click += new System.EventHandler(this.compareAllCharacterInTheNextTwoCopiesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayTextToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // displayTextToolStripMenuItem
            // 
            this.displayTextToolStripMenuItem.Name = "displayTextToolStripMenuItem";
            this.displayTextToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.displayTextToolStripMenuItem.Text = "DisplayText";
            this.displayTextToolStripMenuItem.Click += new System.EventHandler(this.displayTextToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchDatabaseToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // searchDatabaseToolStripMenuItem
            // 
            this.searchDatabaseToolStripMenuItem.Name = "searchDatabaseToolStripMenuItem";
            this.searchDatabaseToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.searchDatabaseToolStripMenuItem.Text = "Search Database";
            this.searchDatabaseToolStripMenuItem.Click += new System.EventHandler(this.searchDatabaseToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input Length:";
            // 
            // inputLengthLabel
            // 
            this.inputLengthLabel.AutoSize = true;
            this.inputLengthLabel.Location = new System.Drawing.Point(69, 210);
            this.inputLengthLabel.Name = "inputLengthLabel";
            this.inputLengthLabel.Size = new System.Drawing.Size(0, 13);
            this.inputLengthLabel.TabIndex = 5;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Clipboard Magic";
            this.notifyIcon1.Visible = true;
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestoreMenuItem,
            this.CloseMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(114, 48);
            // 
            // RestoreMenuItem
            // 
            this.RestoreMenuItem.Name = "RestoreMenuItem";
            this.RestoreMenuItem.Size = new System.Drawing.Size(113, 22);
            this.RestoreMenuItem.Text = "Restore";
            this.RestoreMenuItem.Click += new System.EventHandler(this.RestoreMenuItem_Click);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(113, 22);
            this.CloseMenuItem.Text = "Close";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(398, 212);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 6;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // uploadlabel
            // 
            this.uploadlabel.AutoSize = true;
            this.uploadlabel.Location = new System.Drawing.Point(295, 239);
            this.uploadlabel.Name = "uploadlabel";
            this.uploadlabel.Size = new System.Drawing.Size(0, 13);
            this.uploadlabel.TabIndex = 7;
            // 
            // OutputLength
            // 
            this.OutputLength.AutoSize = true;
            this.OutputLength.Location = new System.Drawing.Point(47, 239);
            this.OutputLength.Name = "OutputLength";
            this.OutputLength.Size = new System.Drawing.Size(0, 13);
            this.OutputLength.TabIndex = 8;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(317, 212);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 9;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 374);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.OutputLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uploadlabel);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.inputLengthLabel);
            this.Controls.Add(this.clipboardText);
            this.Controls.Add(this.output);
            this.Controls.Add(this.DifferenceTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainDialog";
            this.Text = "Cliboard Magic";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.DoubleClick += new System.EventHandler(this.MainDialog_DoubleClick);
            this.Resize += new System.EventHandler(this.MainDialog_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox clipboardText;
        private System.Windows.Forms.RichTextBox DifferenceTextBox;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label inputLengthLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RestoreMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label uploadlabel;
        private System.Windows.Forms.ToolStripMenuItem decodeBase64ToolStripMenuItem;
        private System.Windows.Forms.Label OutputLength;
        private System.Windows.Forms.ToolStripMenuItem textToHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeSHA1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeBase64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBinaryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareAllCharacterInTheNextTwoCopiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openClipboardFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userCredentialsToolStripMenuItem;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ToolStripMenuItem uploadScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDatabaseToolStripMenuItem;
    }
}

