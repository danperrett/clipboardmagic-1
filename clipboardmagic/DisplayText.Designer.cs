﻿namespace clipboardmagic
{
    partial class DisplayText
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
            this.DisplayTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // DisplayTextBox
            // 
            this.DisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayTextBox.Location = new System.Drawing.Point(12, 12);
            this.DisplayTextBox.Name = "DisplayTextBox";
            this.DisplayTextBox.Size = new System.Drawing.Size(441, 406);
            this.DisplayTextBox.TabIndex = 0;
            this.DisplayTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 430);
            this.Controls.Add(this.DisplayTextBox);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Text Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox DisplayTextBox;
    }
}