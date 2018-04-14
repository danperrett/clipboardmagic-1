namespace clipboardmagic
{
    partial class UploadSchedule
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
            this.WhenNewRadioButton = new System.Windows.Forms.RadioButton();
            this.EveryMinRadioButton = new System.Windows.Forms.RadioButton();
            this.ManualRadioButton = new System.Windows.Forms.RadioButton();
            this.WhenClosedRadioButton = new System.Windows.Forms.RadioButton();
            this.EveryFiveMinRadioButton = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EveryFiveMinRadioButton);
            this.groupBox1.Controls.Add(this.WhenClosedRadioButton);
            this.groupBox1.Controls.Add(this.ManualRadioButton);
            this.groupBox1.Controls.Add(this.EveryMinRadioButton);
            this.groupBox1.Controls.Add(this.WhenNewRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // WhenNewRadioButton
            // 
            this.WhenNewRadioButton.AutoSize = true;
            this.WhenNewRadioButton.Location = new System.Drawing.Point(6, 23);
            this.WhenNewRadioButton.Name = "WhenNewRadioButton";
            this.WhenNewRadioButton.Size = new System.Drawing.Size(158, 17);
            this.WhenNewRadioButton.TabIndex = 0;
            this.WhenNewRadioButton.TabStop = true;
            this.WhenNewRadioButton.Text = "When new data in clipboard";
            this.WhenNewRadioButton.UseVisualStyleBackColor = true;
            this.WhenNewRadioButton.CheckedChanged += new System.EventHandler(this.WhenNewRadioButton_CheckedChanged);
            // 
            // EveryMinRadioButton
            // 
            this.EveryMinRadioButton.AutoSize = true;
            this.EveryMinRadioButton.Location = new System.Drawing.Point(6, 46);
            this.EveryMinRadioButton.Name = "EveryMinRadioButton";
            this.EveryMinRadioButton.Size = new System.Drawing.Size(87, 17);
            this.EveryMinRadioButton.TabIndex = 1;
            this.EveryMinRadioButton.TabStop = true;
            this.EveryMinRadioButton.Text = "Every Minute";
            this.EveryMinRadioButton.UseVisualStyleBackColor = true;
            // 
            // ManualRadioButton
            // 
            this.ManualRadioButton.AutoSize = true;
            this.ManualRadioButton.Location = new System.Drawing.Point(6, 92);
            this.ManualRadioButton.Name = "ManualRadioButton";
            this.ManualRadioButton.Size = new System.Drawing.Size(60, 17);
            this.ManualRadioButton.TabIndex = 2;
            this.ManualRadioButton.TabStop = true;
            this.ManualRadioButton.Text = "Manual";
            this.ManualRadioButton.UseVisualStyleBackColor = true;
            // 
            // WhenClosedRadioButton
            // 
            this.WhenClosedRadioButton.AutoSize = true;
            this.WhenClosedRadioButton.Location = new System.Drawing.Point(6, 115);
            this.WhenClosedRadioButton.Name = "WhenClosedRadioButton";
            this.WhenClosedRadioButton.Size = new System.Drawing.Size(89, 17);
            this.WhenClosedRadioButton.TabIndex = 3;
            this.WhenClosedRadioButton.TabStop = true;
            this.WhenClosedRadioButton.Text = "When Closed";
            this.WhenClosedRadioButton.UseVisualStyleBackColor = true;
            // 
            // EveryFiveMinRadioButton
            // 
            this.EveryFiveMinRadioButton.AutoSize = true;
            this.EveryFiveMinRadioButton.Location = new System.Drawing.Point(6, 69);
            this.EveryFiveMinRadioButton.Name = "EveryFiveMinRadioButton";
            this.EveryFiveMinRadioButton.Size = new System.Drawing.Size(115, 17);
            this.EveryFiveMinRadioButton.TabIndex = 4;
            this.EveryFiveMinRadioButton.TabStop = true;
            this.EveryFiveMinRadioButton.Text = "Every Five Minutes";
            this.EveryFiveMinRadioButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(116, 173);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(197, 173);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // UploadSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 214);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadSchedule";
            this.Text = "UploadSchedule";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton EveryFiveMinRadioButton;
        private System.Windows.Forms.RadioButton WhenClosedRadioButton;
        private System.Windows.Forms.RadioButton ManualRadioButton;
        private System.Windows.Forms.RadioButton EveryMinRadioButton;
        private System.Windows.Forms.RadioButton WhenNewRadioButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
    }
}