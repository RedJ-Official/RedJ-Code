namespace RedJ_Code
{
    partial class LinePrefixDialog
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
            prefixTextBox = new System.Windows.Forms.TextBox();
            cancelButton = new System.Windows.Forms.Button();
            acceptButton = new System.Windows.Forms.Button();
            insertRadioButton = new System.Windows.Forms.RadioButton();
            removeRadioButton = new System.Windows.Forms.RadioButton();
            SuspendLayout();
            // 
            // prefixTextBox
            // 
            prefixTextBox.Location = new System.Drawing.Point(12, 11);
            prefixTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            prefixTextBox.Name = "prefixTextBox";
            prefixTextBox.Size = new System.Drawing.Size(332, 23);
            prefixTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(353, 38);
            cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            acceptButton.Location = new System.Drawing.Point(353, 11);
            acceptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new System.Drawing.Size(75, 23);
            acceptButton.TabIndex = 3;
            acceptButton.Text = "OK";
            acceptButton.UseVisualStyleBackColor = true;
            // 
            // insertRadioButton
            // 
            insertRadioButton.AutoSize = true;
            insertRadioButton.Checked = true;
            insertRadioButton.Location = new System.Drawing.Point(12, 40);
            insertRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            insertRadioButton.Name = "insertRadioButton";
            insertRadioButton.Size = new System.Drawing.Size(54, 19);
            insertRadioButton.TabIndex = 1;
            insertRadioButton.TabStop = true;
            insertRadioButton.Text = "&Insert";
            insertRadioButton.UseVisualStyleBackColor = true;
            // 
            // removeRadioButton
            // 
            removeRadioButton.AutoSize = true;
            removeRadioButton.Location = new System.Drawing.Point(72, 40);
            removeRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            removeRadioButton.Name = "removeRadioButton";
            removeRadioButton.Size = new System.Drawing.Size(68, 19);
            removeRadioButton.TabIndex = 2;
            removeRadioButton.Text = "&Remove";
            removeRadioButton.UseVisualStyleBackColor = true;
            // 
            // LinePrefixDialog
            // 
            AcceptButton = acceptButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(440, 72);
            Controls.Add(removeRadioButton);
            Controls.Add(insertRadioButton);
            Controls.Add(prefixTextBox);
            Controls.Add(cancelButton);
            Controls.Add(acceptButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LinePrefixDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Line Prefix";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.RadioButton insertRadioButton;
        private System.Windows.Forms.RadioButton removeRadioButton;
    }
}