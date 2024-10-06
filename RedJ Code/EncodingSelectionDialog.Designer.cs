namespace RedJ_Code
{
    partial class EncodingSelectionDialog
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
            asciiRadioButton = new System.Windows.Forms.RadioButton();
            utf7RadioButton = new System.Windows.Forms.RadioButton();
            utf8RadioButton = new System.Windows.Forms.RadioButton();
            utf16leRadioButton = new System.Windows.Forms.RadioButton();
            utf32leRadioButton = new System.Windows.Forms.RadioButton();
            otherRadioButton = new System.Windows.Forms.RadioButton();
            codepageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            utf16beRadioButton = new System.Windows.Forms.RadioButton();
            latin1RadioButton = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            bomCheckBox = new System.Windows.Forms.CheckBox();
            utf32beRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)codepageNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // asciiRadioButton
            // 
            asciiRadioButton.AutoSize = true;
            asciiRadioButton.Location = new System.Drawing.Point(12, 12);
            asciiRadioButton.Name = "asciiRadioButton";
            asciiRadioButton.Size = new System.Drawing.Size(53, 19);
            asciiRadioButton.TabIndex = 0;
            asciiRadioButton.Text = "&ASCII";
            asciiRadioButton.UseVisualStyleBackColor = true;
            asciiRadioButton.CheckedChanged += anyRadioButton_CheckedChanged;
            // 
            // utf7RadioButton
            // 
            utf7RadioButton.AutoSize = true;
            utf7RadioButton.Location = new System.Drawing.Point(12, 62);
            utf7RadioButton.Name = "utf7RadioButton";
            utf7RadioButton.Size = new System.Drawing.Size(56, 19);
            utf7RadioButton.TabIndex = 2;
            utf7RadioButton.Text = "UTF-&7";
            utf7RadioButton.UseVisualStyleBackColor = true;
            utf7RadioButton.CheckedChanged += anyRadioButton_CheckedChanged;
            // 
            // utf8RadioButton
            // 
            utf8RadioButton.AutoSize = true;
            utf8RadioButton.Location = new System.Drawing.Point(12, 87);
            utf8RadioButton.Name = "utf8RadioButton";
            utf8RadioButton.Size = new System.Drawing.Size(56, 19);
            utf8RadioButton.TabIndex = 3;
            utf8RadioButton.Text = "UTF-&8";
            utf8RadioButton.UseVisualStyleBackColor = true;
            utf8RadioButton.CheckedChanged += anyRadioButton_CheckedChanged;
            // 
            // utf16leRadioButton
            // 
            utf16leRadioButton.AutoSize = true;
            utf16leRadioButton.Location = new System.Drawing.Point(12, 112);
            utf16leRadioButton.Name = "utf16leRadioButton";
            utf16leRadioButton.Size = new System.Drawing.Size(77, 19);
            utf16leRadioButton.TabIndex = 4;
            utf16leRadioButton.Text = "UTF-&16 LE";
            utf16leRadioButton.UseVisualStyleBackColor = true;
            utf16leRadioButton.CheckedChanged += anyRadioButton_CheckedChanged;
            // 
            // utf32leRadioButton
            // 
            utf32leRadioButton.AutoSize = true;
            utf32leRadioButton.Location = new System.Drawing.Point(12, 162);
            utf32leRadioButton.Name = "utf32leRadioButton";
            utf32leRadioButton.Size = new System.Drawing.Size(77, 19);
            utf32leRadioButton.TabIndex = 6;
            utf32leRadioButton.Text = "UTF-&32 LE";
            utf32leRadioButton.UseVisualStyleBackColor = true;
            utf32leRadioButton.CheckedChanged += anyRadioButton_CheckedChanged;
            // 
            // otherRadioButton
            // 
            otherRadioButton.AutoSize = true;
            otherRadioButton.Checked = true;
            otherRadioButton.Location = new System.Drawing.Point(12, 212);
            otherRadioButton.Name = "otherRadioButton";
            otherRadioButton.Size = new System.Drawing.Size(55, 19);
            otherRadioButton.TabIndex = 7;
            otherRadioButton.TabStop = true;
            otherRadioButton.Text = "&Other";
            otherRadioButton.UseVisualStyleBackColor = true;
            otherRadioButton.CheckedChanged += otherRadioButton_CheckedChanged;
            // 
            // codepageNumericUpDown
            // 
            codepageNumericUpDown.Enabled = false;
            codepageNumericUpDown.Location = new System.Drawing.Point(127, 237);
            codepageNumericUpDown.Name = "codepageNumericUpDown";
            codepageNumericUpDown.Size = new System.Drawing.Size(75, 23);
            codepageNumericUpDown.TabIndex = 9;
            // 
            // okButton
            // 
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Location = new System.Drawing.Point(127, 12);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.TabIndex = 11;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(127, 41);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 12;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // utf16beRadioButton
            // 
            utf16beRadioButton.AutoSize = true;
            utf16beRadioButton.Location = new System.Drawing.Point(12, 137);
            utf16beRadioButton.Name = "utf16beRadioButton";
            utf16beRadioButton.Size = new System.Drawing.Size(78, 19);
            utf16beRadioButton.TabIndex = 5;
            utf16beRadioButton.Text = "UTF-1&6 BE";
            utf16beRadioButton.UseVisualStyleBackColor = true;
            utf16beRadioButton.CheckedChanged += anyRadioButton_CheckedChanged;
            // 
            // latin1RadioButton
            // 
            latin1RadioButton.AutoSize = true;
            latin1RadioButton.Location = new System.Drawing.Point(12, 37);
            latin1RadioButton.Name = "latin1RadioButton";
            latin1RadioButton.Size = new System.Drawing.Size(57, 19);
            latin1RadioButton.TabIndex = 1;
            latin1RadioButton.Text = "&Latin1";
            latin1RadioButton.UseVisualStyleBackColor = true;
            latin1RadioButton.CheckedChanged += anyRadioButton_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 239);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 15);
            label1.TabIndex = 8;
            label1.Text = "&Codepage:";
            // 
            // bomCheckBox
            // 
            bomCheckBox.AutoSize = true;
            bomCheckBox.Location = new System.Drawing.Point(127, 70);
            bomCheckBox.Name = "bomCheckBox";
            bomCheckBox.Size = new System.Drawing.Size(53, 19);
            bomCheckBox.TabIndex = 10;
            bomCheckBox.Text = "&BOM";
            bomCheckBox.UseVisualStyleBackColor = true;
            bomCheckBox.Visible = false;
            // 
            // utf32beRadioButton
            // 
            utf32beRadioButton.AutoSize = true;
            utf32beRadioButton.Location = new System.Drawing.Point(12, 187);
            utf32beRadioButton.Name = "utf32beRadioButton";
            utf32beRadioButton.Size = new System.Drawing.Size(78, 19);
            utf32beRadioButton.TabIndex = 13;
            utf32beRadioButton.TabStop = true;
            utf32beRadioButton.Text = "UTF-3&2 BE";
            utf32beRadioButton.UseVisualStyleBackColor = true;
            // 
            // EncodingSelectionDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(214, 272);
            Controls.Add(utf32beRadioButton);
            Controls.Add(bomCheckBox);
            Controls.Add(label1);
            Controls.Add(latin1RadioButton);
            Controls.Add(utf16beRadioButton);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(codepageNumericUpDown);
            Controls.Add(otherRadioButton);
            Controls.Add(utf32leRadioButton);
            Controls.Add(utf16leRadioButton);
            Controls.Add(utf8RadioButton);
            Controls.Add(utf7RadioButton);
            Controls.Add(asciiRadioButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EncodingSelectionDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select Encoding";
            FormClosed += EncodingSelectionDialog_FormClosed;
            ((System.ComponentModel.ISupportInitialize)codepageNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton asciiRadioButton;
        private System.Windows.Forms.RadioButton utf7RadioButton;
        private System.Windows.Forms.RadioButton utf8RadioButton;
        private System.Windows.Forms.RadioButton utf16leRadioButton;
        private System.Windows.Forms.RadioButton utf32leRadioButton;
        private System.Windows.Forms.RadioButton otherRadioButton;
        private System.Windows.Forms.NumericUpDown codepageNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton utf16beRadioButton;
        private System.Windows.Forms.RadioButton latin1RadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox bomCheckBox;
        private System.Windows.Forms.RadioButton utf32beRadioButton;
    }
}