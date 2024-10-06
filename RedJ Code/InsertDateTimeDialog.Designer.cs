namespace RedJ_Code
{
    partial class InsertDateTimeDialog
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
            formatsListBox = new System.Windows.Forms.ListBox();
            utcCheckBox = new System.Windows.Forms.CheckBox();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // formatsListBox
            // 
            formatsListBox.FormattingEnabled = true;
            formatsListBox.ItemHeight = 15;
            formatsListBox.Location = new System.Drawing.Point(12, 12);
            formatsListBox.Name = "formatsListBox";
            formatsListBox.Size = new System.Drawing.Size(250, 139);
            formatsListBox.TabIndex = 0;
            formatsListBox.DoubleClick += formatsListBox_DoubleClick;
            formatsListBox.KeyDown += formatsListBox_KeyDown;
            // 
            // utcCheckBox
            // 
            utcCheckBox.AutoSize = true;
            utcCheckBox.Location = new System.Drawing.Point(12, 160);
            utcCheckBox.Name = "utcCheckBox";
            utcCheckBox.Size = new System.Drawing.Size(47, 19);
            utcCheckBox.TabIndex = 1;
            utcCheckBox.Text = "&UTC";
            utcCheckBox.UseVisualStyleBackColor = true;
            utcCheckBox.CheckedChanged += utcCheckBox_CheckedChanged;
            // 
            // okButton
            // 
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Location = new System.Drawing.Point(106, 157);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(187, 157);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // InsertDateTimeDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(274, 192);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(utcCheckBox);
            Controls.Add(formatsListBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InsertDateTimeDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select DateTime Format";
            FormClosed += InsertDateTimeDialog_FormClosed;
            Load += InsertDateTimeDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox formatsListBox;
        private System.Windows.Forms.CheckBox utcCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}