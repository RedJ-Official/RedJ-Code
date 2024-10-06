namespace RedJ_Code
{
    partial class PrintCodeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintCodeDialog));
            printiconPictureBox = new System.Windows.Forms.PictureBox();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            printerSetupButton = new System.Windows.Forms.Button();
            pageSetupButton = new System.Windows.Forms.Button();
            includeLineNumbersCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)printiconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // printiconPictureBox
            // 
            printiconPictureBox.Image = (System.Drawing.Image)resources.GetObject("printiconPictureBox.Image");
            printiconPictureBox.Location = new System.Drawing.Point(12, 12);
            printiconPictureBox.Name = "printiconPictureBox";
            printiconPictureBox.Size = new System.Drawing.Size(128, 128);
            printiconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            printiconPictureBox.TabIndex = 0;
            printiconPictureBox.TabStop = false;
            // 
            // okButton
            // 
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Location = new System.Drawing.Point(146, 117);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(227, 117);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // printerSetupButton
            // 
            printerSetupButton.Location = new System.Drawing.Point(146, 12);
            printerSetupButton.Name = "printerSetupButton";
            printerSetupButton.Size = new System.Drawing.Size(156, 23);
            printerSetupButton.TabIndex = 2;
            printerSetupButton.Text = "Printer &Setup...";
            printerSetupButton.UseVisualStyleBackColor = true;
            printerSetupButton.Click += printerSetupButton_Click;
            // 
            // pageSetupButton
            // 
            pageSetupButton.Location = new System.Drawing.Point(146, 41);
            pageSetupButton.Name = "pageSetupButton";
            pageSetupButton.Size = new System.Drawing.Size(156, 23);
            pageSetupButton.TabIndex = 3;
            pageSetupButton.Text = "Page Se&tup...";
            pageSetupButton.UseVisualStyleBackColor = true;
            pageSetupButton.Click += pageSetupButton_Click;
            // 
            // includeLineNumbersCheckBox
            // 
            includeLineNumbersCheckBox.AutoSize = true;
            includeLineNumbersCheckBox.Location = new System.Drawing.Point(146, 70);
            includeLineNumbersCheckBox.Name = "includeLineNumbersCheckBox";
            includeLineNumbersCheckBox.Size = new System.Drawing.Size(128, 19);
            includeLineNumbersCheckBox.TabIndex = 4;
            includeLineNumbersCheckBox.Text = "Print &Line Numbers";
            includeLineNumbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // PrintCodeDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(314, 152);
            Controls.Add(includeLineNumbersCheckBox);
            Controls.Add(pageSetupButton);
            Controls.Add(printerSetupButton);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(printiconPictureBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrintCodeDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Print";
            FormClosed += PrintCodeDialog_FormClosed;
            Load += PrintCodeDialog_Load;
            ((System.ComponentModel.ISupportInitialize)printiconPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox printiconPictureBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button printerSetupButton;
        private System.Windows.Forms.Button pageSetupButton;
        private System.Windows.Forms.CheckBox includeLineNumbersCheckBox;
    }
}