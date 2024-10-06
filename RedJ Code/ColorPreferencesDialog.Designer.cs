namespace RedJ_Code
{
    partial class ColorPreferencesDialog
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
            colorGroupBox = new System.Windows.Forms.GroupBox();
            selectionColorButton = new System.Windows.Forms.Button();
            selectionLabel = new System.Windows.Forms.Label();
            backgroundColorButton = new System.Windows.Forms.Button();
            textBackgroundLabel = new System.Windows.Forms.Label();
            autocompleteMenuColorButton = new System.Windows.Forms.Button();
            autocompleteMenuLabel = new System.Windows.Forms.Label();
            documentMapColorButton = new System.Windows.Forms.Button();
            documentMapLabel = new System.Windows.Forms.Label();
            currentLineColorButton = new System.Windows.Forms.Button();
            currentLineLabel = new System.Windows.Forms.Label();
            foldingIndicatorColorButton = new System.Windows.Forms.Button();
            foldingIndicatorLabel = new System.Windows.Forms.Label();
            bookmarkColorButton = new System.Windows.Forms.Button();
            bookmarksLabel = new System.Windows.Forms.Label();
            lineNumberColorButton = new System.Windows.Forms.Button();
            lineNumbersLabel = new System.Windows.Forms.Label();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            colorDialog = new System.Windows.Forms.ColorDialog();
            resetButton = new System.Windows.Forms.Button();
            colorGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // colorGroupBox
            // 
            colorGroupBox.Controls.Add(selectionColorButton);
            colorGroupBox.Controls.Add(selectionLabel);
            colorGroupBox.Controls.Add(backgroundColorButton);
            colorGroupBox.Controls.Add(textBackgroundLabel);
            colorGroupBox.Controls.Add(autocompleteMenuColorButton);
            colorGroupBox.Controls.Add(autocompleteMenuLabel);
            colorGroupBox.Controls.Add(documentMapColorButton);
            colorGroupBox.Controls.Add(documentMapLabel);
            colorGroupBox.Controls.Add(currentLineColorButton);
            colorGroupBox.Controls.Add(currentLineLabel);
            colorGroupBox.Controls.Add(foldingIndicatorColorButton);
            colorGroupBox.Controls.Add(foldingIndicatorLabel);
            colorGroupBox.Controls.Add(bookmarkColorButton);
            colorGroupBox.Controls.Add(bookmarksLabel);
            colorGroupBox.Controls.Add(lineNumberColorButton);
            colorGroupBox.Controls.Add(lineNumbersLabel);
            colorGroupBox.Location = new System.Drawing.Point(12, 12);
            colorGroupBox.Name = "colorGroupBox";
            colorGroupBox.Size = new System.Drawing.Size(452, 254);
            colorGroupBox.TabIndex = 0;
            colorGroupBox.TabStop = false;
            colorGroupBox.Text = "Colors";
            // 
            // selectionColorButton
            // 
            selectionColorButton.Location = new System.Drawing.Point(296, 138);
            selectionColorButton.Name = "selectionColorButton";
            selectionColorButton.Size = new System.Drawing.Size(150, 23);
            selectionColorButton.TabIndex = 9;
            selectionColorButton.UseVisualStyleBackColor = true;
            selectionColorButton.Click += colorButton_Click;
            // 
            // selectionLabel
            // 
            selectionLabel.AutoSize = true;
            selectionLabel.Location = new System.Drawing.Point(6, 142);
            selectionLabel.Name = "selectionLabel";
            selectionLabel.Size = new System.Drawing.Size(58, 15);
            selectionLabel.TabIndex = 8;
            selectionLabel.Text = "&Selection:";
            // 
            // backgroundColorButton
            // 
            backgroundColorButton.Location = new System.Drawing.Point(296, 225);
            backgroundColorButton.Name = "backgroundColorButton";
            backgroundColorButton.Size = new System.Drawing.Size(150, 23);
            backgroundColorButton.TabIndex = 15;
            backgroundColorButton.UseVisualStyleBackColor = true;
            backgroundColorButton.Click += colorButton_Click;
            // 
            // textBackgroundLabel
            // 
            textBackgroundLabel.AutoSize = true;
            textBackgroundLabel.Location = new System.Drawing.Point(6, 229);
            textBackgroundLabel.Name = "textBackgroundLabel";
            textBackgroundLabel.Size = new System.Drawing.Size(98, 15);
            textBackgroundLabel.TabIndex = 14;
            textBackgroundLabel.Text = "&Text Background:";
            // 
            // autocompleteMenuColorButton
            // 
            autocompleteMenuColorButton.Location = new System.Drawing.Point(296, 196);
            autocompleteMenuColorButton.Name = "autocompleteMenuColorButton";
            autocompleteMenuColorButton.Size = new System.Drawing.Size(150, 23);
            autocompleteMenuColorButton.TabIndex = 13;
            autocompleteMenuColorButton.UseVisualStyleBackColor = true;
            autocompleteMenuColorButton.Click += colorButton_Click;
            // 
            // autocompleteMenuLabel
            // 
            autocompleteMenuLabel.AutoSize = true;
            autocompleteMenuLabel.Location = new System.Drawing.Point(6, 200);
            autocompleteMenuLabel.Name = "autocompleteMenuLabel";
            autocompleteMenuLabel.Size = new System.Drawing.Size(120, 15);
            autocompleteMenuLabel.TabIndex = 12;
            autocompleteMenuLabel.Text = "&Autocomplete Menu:";
            // 
            // documentMapColorButton
            // 
            documentMapColorButton.Location = new System.Drawing.Point(296, 167);
            documentMapColorButton.Name = "documentMapColorButton";
            documentMapColorButton.Size = new System.Drawing.Size(150, 23);
            documentMapColorButton.TabIndex = 11;
            documentMapColorButton.UseVisualStyleBackColor = true;
            documentMapColorButton.Click += colorButton_Click;
            // 
            // documentMapLabel
            // 
            documentMapLabel.AutoSize = true;
            documentMapLabel.Location = new System.Drawing.Point(6, 171);
            documentMapLabel.Name = "documentMapLabel";
            documentMapLabel.Size = new System.Drawing.Size(93, 15);
            documentMapLabel.TabIndex = 10;
            documentMapLabel.Text = "Document &Map:";
            // 
            // currentLineColorButton
            // 
            currentLineColorButton.Location = new System.Drawing.Point(296, 109);
            currentLineColorButton.Name = "currentLineColorButton";
            currentLineColorButton.Size = new System.Drawing.Size(150, 23);
            currentLineColorButton.TabIndex = 7;
            currentLineColorButton.UseVisualStyleBackColor = true;
            currentLineColorButton.Click += colorButton_Click;
            // 
            // currentLineLabel
            // 
            currentLineLabel.AutoSize = true;
            currentLineLabel.Location = new System.Drawing.Point(6, 113);
            currentLineLabel.Name = "currentLineLabel";
            currentLineLabel.Size = new System.Drawing.Size(75, 15);
            currentLineLabel.TabIndex = 6;
            currentLineLabel.Text = "Current &Line:";
            // 
            // foldingIndicatorColorButton
            // 
            foldingIndicatorColorButton.Location = new System.Drawing.Point(296, 80);
            foldingIndicatorColorButton.Name = "foldingIndicatorColorButton";
            foldingIndicatorColorButton.Size = new System.Drawing.Size(150, 23);
            foldingIndicatorColorButton.TabIndex = 5;
            foldingIndicatorColorButton.UseVisualStyleBackColor = true;
            foldingIndicatorColorButton.Click += colorButton_Click;
            // 
            // foldingIndicatorLabel
            // 
            foldingIndicatorLabel.AutoSize = true;
            foldingIndicatorLabel.Location = new System.Drawing.Point(6, 84);
            foldingIndicatorLabel.Name = "foldingIndicatorLabel";
            foldingIndicatorLabel.Size = new System.Drawing.Size(100, 15);
            foldingIndicatorLabel.TabIndex = 4;
            foldingIndicatorLabel.Text = "&Folding Indicator:";
            // 
            // bookmarkColorButton
            // 
            bookmarkColorButton.Location = new System.Drawing.Point(296, 51);
            bookmarkColorButton.Name = "bookmarkColorButton";
            bookmarkColorButton.Size = new System.Drawing.Size(150, 23);
            bookmarkColorButton.TabIndex = 3;
            bookmarkColorButton.UseVisualStyleBackColor = true;
            bookmarkColorButton.Click += colorButton_Click;
            // 
            // bookmarksLabel
            // 
            bookmarksLabel.AutoSize = true;
            bookmarksLabel.Location = new System.Drawing.Point(6, 55);
            bookmarksLabel.Name = "bookmarksLabel";
            bookmarksLabel.Size = new System.Drawing.Size(69, 15);
            bookmarksLabel.TabIndex = 2;
            bookmarksLabel.Text = "&Bookmarks:";
            // 
            // lineNumberColorButton
            // 
            lineNumberColorButton.Location = new System.Drawing.Point(296, 22);
            lineNumberColorButton.Name = "lineNumberColorButton";
            lineNumberColorButton.Size = new System.Drawing.Size(150, 23);
            lineNumberColorButton.TabIndex = 1;
            lineNumberColorButton.UseVisualStyleBackColor = true;
            lineNumberColorButton.Click += colorButton_Click;
            // 
            // lineNumbersLabel
            // 
            lineNumbersLabel.AutoSize = true;
            lineNumbersLabel.Location = new System.Drawing.Point(6, 26);
            lineNumbersLabel.Name = "lineNumbersLabel";
            lineNumbersLabel.Size = new System.Drawing.Size(84, 15);
            lineNumbersLabel.TabIndex = 0;
            lineNumbersLabel.Text = "Line &Numbers:";
            // 
            // okButton
            // 
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Location = new System.Drawing.Point(308, 272);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(389, 272);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            resetButton.Location = new System.Drawing.Point(12, 272);
            resetButton.Name = "resetButton";
            resetButton.Size = new System.Drawing.Size(75, 23);
            resetButton.TabIndex = 3;
            resetButton.Text = "&Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // ColorPreferencesDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(476, 307);
            Controls.Add(resetButton);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(colorGroupBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ColorPreferencesDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Color Preferences";
            colorGroupBox.ResumeLayout(false);
            colorGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Button lineNumberColorButton;
        private System.Windows.Forms.Label lineNumbersLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button autocompleteMenuColorButton;
        private System.Windows.Forms.Label autocompleteMenuLabel;
        private System.Windows.Forms.Button documentMapColorButton;
        private System.Windows.Forms.Label documentMapLabel;
        private System.Windows.Forms.Button currentLineColorButton;
        private System.Windows.Forms.Label currentLineLabel;
        private System.Windows.Forms.Button foldingIndicatorColorButton;
        private System.Windows.Forms.Label foldingIndicatorLabel;
        private System.Windows.Forms.Button bookmarkColorButton;
        private System.Windows.Forms.Label bookmarksLabel;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Label textBackgroundLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button selectionColorButton;
        private System.Windows.Forms.Label selectionLabel;
    }
}