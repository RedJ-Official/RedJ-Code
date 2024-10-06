namespace RedJ_Code
{
    partial class ExportDialog
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
            includeLineNumbersCheckBox = new System.Windows.Forms.CheckBox();
            usePreTagCheckBox = new System.Windows.Forms.CheckBox();
            useStyleTagCheckBox = new System.Windows.Forms.CheckBox();
            exportButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            exportTypeGroupBox = new System.Windows.Forms.GroupBox();
            rtfRadioButton = new System.Windows.Forms.RadioButton();
            htmlRadioButton = new System.Windows.Forms.RadioButton();
            exportOptionsGroupBox = new System.Windows.Forms.GroupBox();
            useOriginalFontCheckBox = new System.Windows.Forms.CheckBox();
            saveHtmlFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveRtfFileDialog = new System.Windows.Forms.SaveFileDialog();
            exportRangeGroupBox = new System.Windows.Forms.GroupBox();
            selectionRadioButton = new System.Windows.Forms.RadioButton();
            rangeRadioButton = new System.Windows.Forms.RadioButton();
            exportTypeGroupBox.SuspendLayout();
            exportOptionsGroupBox.SuspendLayout();
            exportRangeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // includeLineNumbersCheckBox
            // 
            includeLineNumbersCheckBox.AutoSize = true;
            includeLineNumbersCheckBox.Location = new System.Drawing.Point(6, 20);
            includeLineNumbersCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            includeLineNumbersCheckBox.Name = "includeLineNumbersCheckBox";
            includeLineNumbersCheckBox.Size = new System.Drawing.Size(142, 19);
            includeLineNumbersCheckBox.TabIndex = 0;
            includeLineNumbersCheckBox.Text = "Include &Line Numbers";
            includeLineNumbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // usePreTagCheckBox
            // 
            usePreTagCheckBox.AutoSize = true;
            usePreTagCheckBox.Location = new System.Drawing.Point(6, 66);
            usePreTagCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            usePreTagCheckBox.Name = "usePreTagCheckBox";
            usePreTagCheckBox.Size = new System.Drawing.Size(105, 19);
            usePreTagCheckBox.TabIndex = 2;
            usePreTagCheckBox.Text = "Use <&PRE> Tag";
            usePreTagCheckBox.UseVisualStyleBackColor = true;
            usePreTagCheckBox.CheckedChanged += usePreTagCheckBox_CheckedChanged;
            // 
            // useStyleTagCheckBox
            // 
            useStyleTagCheckBox.AutoSize = true;
            useStyleTagCheckBox.Checked = true;
            useStyleTagCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            useStyleTagCheckBox.Location = new System.Drawing.Point(6, 89);
            useStyleTagCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            useStyleTagCheckBox.Name = "useStyleTagCheckBox";
            useStyleTagCheckBox.Size = new System.Drawing.Size(116, 19);
            useStyleTagCheckBox.TabIndex = 3;
            useStyleTagCheckBox.Text = "Use <&STYLE> Tag";
            useStyleTagCheckBox.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            exportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            exportButton.Location = new System.Drawing.Point(77, 267);
            exportButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            exportButton.Name = "exportButton";
            exportButton.Size = new System.Drawing.Size(75, 23);
            exportButton.TabIndex = 3;
            exportButton.Text = "&Export...";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(158, 267);
            cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // exportTypeGroupBox
            // 
            exportTypeGroupBox.Controls.Add(rtfRadioButton);
            exportTypeGroupBox.Controls.Add(htmlRadioButton);
            exportTypeGroupBox.Location = new System.Drawing.Point(12, 11);
            exportTypeGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            exportTypeGroupBox.Name = "exportTypeGroupBox";
            exportTypeGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            exportTypeGroupBox.Size = new System.Drawing.Size(221, 66);
            exportTypeGroupBox.TabIndex = 0;
            exportTypeGroupBox.TabStop = false;
            exportTypeGroupBox.Text = "Export Type";
            // 
            // rtfRadioButton
            // 
            rtfRadioButton.AutoSize = true;
            rtfRadioButton.Location = new System.Drawing.Point(6, 43);
            rtfRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            rtfRadioButton.Name = "rtfRadioButton";
            rtfRadioButton.Size = new System.Drawing.Size(43, 19);
            rtfRadioButton.TabIndex = 1;
            rtfRadioButton.Text = "&RTF";
            rtfRadioButton.UseVisualStyleBackColor = true;
            // 
            // htmlRadioButton
            // 
            htmlRadioButton.AutoSize = true;
            htmlRadioButton.Checked = true;
            htmlRadioButton.Location = new System.Drawing.Point(6, 20);
            htmlRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            htmlRadioButton.Name = "htmlRadioButton";
            htmlRadioButton.Size = new System.Drawing.Size(57, 19);
            htmlRadioButton.TabIndex = 0;
            htmlRadioButton.TabStop = true;
            htmlRadioButton.Text = "&HTML";
            htmlRadioButton.UseVisualStyleBackColor = true;
            htmlRadioButton.CheckedChanged += htmlRadioButton_CheckedChanged;
            // 
            // exportOptionsGroupBox
            // 
            exportOptionsGroupBox.Controls.Add(useOriginalFontCheckBox);
            exportOptionsGroupBox.Controls.Add(includeLineNumbersCheckBox);
            exportOptionsGroupBox.Controls.Add(usePreTagCheckBox);
            exportOptionsGroupBox.Controls.Add(useStyleTagCheckBox);
            exportOptionsGroupBox.Location = new System.Drawing.Point(12, 151);
            exportOptionsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            exportOptionsGroupBox.Name = "exportOptionsGroupBox";
            exportOptionsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            exportOptionsGroupBox.Size = new System.Drawing.Size(221, 112);
            exportOptionsGroupBox.TabIndex = 2;
            exportOptionsGroupBox.TabStop = false;
            exportOptionsGroupBox.Text = "Export Options";
            // 
            // useOriginalFontCheckBox
            // 
            useOriginalFontCheckBox.AutoSize = true;
            useOriginalFontCheckBox.Checked = true;
            useOriginalFontCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            useOriginalFontCheckBox.Location = new System.Drawing.Point(6, 43);
            useOriginalFontCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            useOriginalFontCheckBox.Name = "useOriginalFontCheckBox";
            useOriginalFontCheckBox.Size = new System.Drawing.Size(117, 19);
            useOriginalFontCheckBox.TabIndex = 1;
            useOriginalFontCheckBox.Text = "Use &Original Font";
            useOriginalFontCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveHtmlFileDialog
            // 
            saveHtmlFileDialog.Filter = "HTML Document|*.html;*.htm";
            saveHtmlFileDialog.Title = "Export as HTML";
            // 
            // saveRtfFileDialog
            // 
            saveRtfFileDialog.Filter = "RTF Document|*.rtf";
            saveRtfFileDialog.Title = "Export as RTF";
            // 
            // exportRangeGroupBox
            // 
            exportRangeGroupBox.Controls.Add(selectionRadioButton);
            exportRangeGroupBox.Controls.Add(rangeRadioButton);
            exportRangeGroupBox.Location = new System.Drawing.Point(12, 81);
            exportRangeGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            exportRangeGroupBox.Name = "exportRangeGroupBox";
            exportRangeGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            exportRangeGroupBox.Size = new System.Drawing.Size(221, 66);
            exportRangeGroupBox.TabIndex = 1;
            exportRangeGroupBox.TabStop = false;
            exportRangeGroupBox.Text = "Export Range";
            // 
            // selectionRadioButton
            // 
            selectionRadioButton.AutoSize = true;
            selectionRadioButton.Location = new System.Drawing.Point(6, 43);
            selectionRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            selectionRadioButton.Name = "selectionRadioButton";
            selectionRadioButton.Size = new System.Drawing.Size(93, 19);
            selectionRadioButton.TabIndex = 1;
            selectionRadioButton.Text = "Selected &Text";
            selectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // rangeRadioButton
            // 
            rangeRadioButton.AutoSize = true;
            rangeRadioButton.Checked = true;
            rangeRadioButton.Location = new System.Drawing.Point(6, 20);
            rangeRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            rangeRadioButton.Name = "rangeRadioButton";
            rangeRadioButton.Size = new System.Drawing.Size(118, 19);
            rangeRadioButton.TabIndex = 0;
            rangeRadioButton.TabStop = true;
            rangeRadioButton.Text = "Whole &Document";
            rangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExportDialog
            // 
            AcceptButton = exportButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(245, 301);
            Controls.Add(exportRangeGroupBox);
            Controls.Add(exportOptionsGroupBox);
            Controls.Add(exportTypeGroupBox);
            Controls.Add(cancelButton);
            Controls.Add(exportButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Export";
            FormClosed += ExportDialog_FormClosed;
            Load += ExportDialog_Load;
            exportTypeGroupBox.ResumeLayout(false);
            exportTypeGroupBox.PerformLayout();
            exportOptionsGroupBox.ResumeLayout(false);
            exportOptionsGroupBox.PerformLayout();
            exportRangeGroupBox.ResumeLayout(false);
            exportRangeGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox includeLineNumbersCheckBox;
        private System.Windows.Forms.CheckBox usePreTagCheckBox;
        private System.Windows.Forms.CheckBox useStyleTagCheckBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox exportTypeGroupBox;
        private System.Windows.Forms.GroupBox exportOptionsGroupBox;
        private System.Windows.Forms.CheckBox useOriginalFontCheckBox;
        private System.Windows.Forms.RadioButton rtfRadioButton;
        private System.Windows.Forms.RadioButton htmlRadioButton;
        private System.Windows.Forms.SaveFileDialog saveHtmlFileDialog;
        private System.Windows.Forms.SaveFileDialog saveRtfFileDialog;
        private System.Windows.Forms.GroupBox exportRangeGroupBox;
        private System.Windows.Forms.RadioButton selectionRadioButton;
        private System.Windows.Forms.RadioButton rangeRadioButton;
    }
}