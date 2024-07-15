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
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.insertRadioButton = new System.Windows.Forms.RadioButton();
            this.removeRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(12, 12);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(379, 27);
            this.prefixTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(397, 47);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(397, 12);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(94, 29);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // insertRadioButton
            // 
            this.insertRadioButton.AutoSize = true;
            this.insertRadioButton.Checked = true;
            this.insertRadioButton.Location = new System.Drawing.Point(12, 49);
            this.insertRadioButton.Name = "insertRadioButton";
            this.insertRadioButton.Size = new System.Drawing.Size(66, 24);
            this.insertRadioButton.TabIndex = 1;
            this.insertRadioButton.TabStop = true;
            this.insertRadioButton.Text = "&Insert";
            this.insertRadioButton.UseVisualStyleBackColor = true;
            // 
            // removeRadioButton
            // 
            this.removeRadioButton.AutoSize = true;
            this.removeRadioButton.Location = new System.Drawing.Point(84, 49);
            this.removeRadioButton.Name = "removeRadioButton";
            this.removeRadioButton.Size = new System.Drawing.Size(84, 24);
            this.removeRadioButton.TabIndex = 2;
            this.removeRadioButton.Text = "&Remove";
            this.removeRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertLinePrefixDialog
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(503, 88);
            this.Controls.Add(this.removeRadioButton);
            this.Controls.Add(this.insertRadioButton);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertLinePrefixDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line Prefix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.RadioButton insertRadioButton;
        private System.Windows.Forms.RadioButton removeRadioButton;
    }
}