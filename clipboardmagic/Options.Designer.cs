namespace clipboardmagic
{
    partial class Options
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DisplayBytesCheckBox = new System.Windows.Forms.CheckBox();
            this.ReplaceTextGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WithTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceTextRadioButton = new System.Windows.Forms.RadioButton();
            this.DifferenceRadioButton = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.ReplaceTextGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DisplayBytesCheckBox);
            this.groupBox1.Controls.Add(this.ReplaceTextGroupBox);
            this.groupBox1.Controls.Add(this.ReplaceTextRadioButton);
            this.groupBox1.Controls.Add(this.DifferenceRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DisplayBytesCheckBox
            // 
            this.DisplayBytesCheckBox.AutoSize = true;
            this.DisplayBytesCheckBox.Location = new System.Drawing.Point(15, 160);
            this.DisplayBytesCheckBox.Name = "DisplayBytesCheckBox";
            this.DisplayBytesCheckBox.Size = new System.Drawing.Size(224, 17);
            this.DisplayBytesCheckBox.TabIndex = 3;
            this.DisplayBytesCheckBox.Text = "Display Bytes streams as seperated with \',\'";
            this.DisplayBytesCheckBox.UseVisualStyleBackColor = true;
            this.DisplayBytesCheckBox.CheckedChanged += new System.EventHandler(this.DisplayBytesCheckBox_CheckedChanged);
            // 
            // ReplaceTextGroupBox
            // 
            this.ReplaceTextGroupBox.Controls.Add(this.label2);
            this.ReplaceTextGroupBox.Controls.Add(this.label1);
            this.ReplaceTextGroupBox.Controls.Add(this.WithTextBox);
            this.ReplaceTextGroupBox.Controls.Add(this.ReplaceTextBox);
            this.ReplaceTextGroupBox.Location = new System.Drawing.Point(6, 64);
            this.ReplaceTextGroupBox.Name = "ReplaceTextGroupBox";
            this.ReplaceTextGroupBox.Size = new System.Drawing.Size(256, 90);
            this.ReplaceTextGroupBox.TabIndex = 2;
            this.ReplaceTextGroupBox.TabStop = false;
            this.ReplaceTextGroupBox.Text = "Replace Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "With";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Replace";
            // 
            // WithTextBox
            // 
            this.WithTextBox.Location = new System.Drawing.Point(106, 59);
            this.WithTextBox.Name = "WithTextBox";
            this.WithTextBox.Size = new System.Drawing.Size(144, 20);
            this.WithTextBox.TabIndex = 1;
            // 
            // ReplaceTextBox
            // 
            this.ReplaceTextBox.Location = new System.Drawing.Point(106, 28);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(144, 20);
            this.ReplaceTextBox.TabIndex = 0;
            // 
            // ReplaceTextRadioButton
            // 
            this.ReplaceTextRadioButton.AutoSize = true;
            this.ReplaceTextRadioButton.Location = new System.Drawing.Point(104, 28);
            this.ReplaceTextRadioButton.Name = "ReplaceTextRadioButton";
            this.ReplaceTextRadioButton.Size = new System.Drawing.Size(89, 17);
            this.ReplaceTextRadioButton.TabIndex = 1;
            this.ReplaceTextRadioButton.Text = "Replace Text";
            this.ReplaceTextRadioButton.UseVisualStyleBackColor = true;
            this.ReplaceTextRadioButton.CheckedChanged += new System.EventHandler(this.ReplaceTextRadioButton_CheckedChanged);
            // 
            // DifferenceRadioButton
            // 
            this.DifferenceRadioButton.AutoSize = true;
            this.DifferenceRadioButton.Checked = true;
            this.DifferenceRadioButton.Location = new System.Drawing.Point(15, 28);
            this.DifferenceRadioButton.Name = "DifferenceRadioButton";
            this.DifferenceRadioButton.Size = new System.Drawing.Size(74, 17);
            this.DifferenceRadioButton.TabIndex = 0;
            this.DifferenceRadioButton.TabStop = true;
            this.DifferenceRadioButton.Text = "Difference";
            this.DifferenceRadioButton.UseVisualStyleBackColor = true;
            this.DifferenceRadioButton.CheckedChanged += new System.EventHandler(this.DifferenceRadioButton_CheckedChanged);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(124, 231);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(207, 231);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ReplaceTextGroupBox.ResumeLayout(false);
            this.ReplaceTextGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox ReplaceTextGroupBox;
        private System.Windows.Forms.RadioButton ReplaceTextRadioButton;
        private System.Windows.Forms.RadioButton DifferenceRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WithTextBox;
        private System.Windows.Forms.TextBox ReplaceTextBox;
        private System.Windows.Forms.CheckBox DisplayBytesCheckBox;
    }
}