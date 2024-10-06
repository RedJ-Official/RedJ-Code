namespace RedJ_Code
{
    partial class HtmlDocEditForm
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
            webBrowser = new System.Windows.Forms.WebBrowser();
            newButton = new System.Windows.Forms.Button();
            openButton = new System.Windows.Forms.Button();
            saveButton = new System.Windows.Forms.Button();
            titleTextBox = new System.Windows.Forms.TextBox();
            titleLabel = new System.Windows.Forms.Label();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            webBrowserPanel = new System.Windows.Forms.Panel();
            printButton = new System.Windows.Forms.Button();
            editButton = new System.Windows.Forms.Button();
            webBrowserPanel.SuspendLayout();
            SuspendLayout();
            // 
            // webBrowser
            // 
            webBrowser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            webBrowser.Location = new System.Drawing.Point(1, 1);
            webBrowser.Margin = new System.Windows.Forms.Padding(0);
            webBrowser.Name = "webBrowser";
            webBrowser.Size = new System.Drawing.Size(577, 607);
            webBrowser.TabIndex = 0;
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            // 
            // newButton
            // 
            newButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            newButton.Location = new System.Drawing.Point(13, 662);
            newButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            newButton.Name = "newButton";
            newButton.Size = new System.Drawing.Size(100, 35);
            newButton.TabIndex = 1;
            newButton.Text = "&New";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // openButton
            // 
            openButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            openButton.Location = new System.Drawing.Point(229, 662);
            openButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            openButton.Name = "openButton";
            openButton.Size = new System.Drawing.Size(100, 35);
            openButton.TabIndex = 3;
            openButton.Text = "&Open...";
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += openButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            saveButton.Location = new System.Drawing.Point(337, 662);
            saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(100, 35);
            saveButton.TabIndex = 4;
            saveButton.Text = "&Save As...";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // titleTextBox
            // 
            titleTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            titleTextBox.Location = new System.Drawing.Point(138, 12);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new System.Drawing.Size(455, 27);
            titleTextBox.TabIndex = 7;
            titleTextBox.TextChanged += titleTextBox_TextChanged;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(14, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(118, 20);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Document &Title :";
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "HTML Files|*.html;*.htm|Text Files|*.txt|All Files|*";
            openFileDialog.Title = "Open File";
            // 
            // webBrowserPanel
            // 
            webBrowserPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            webBrowserPanel.BackColor = System.Drawing.Color.Black;
            webBrowserPanel.Controls.Add(webBrowser);
            webBrowserPanel.Location = new System.Drawing.Point(14, 45);
            webBrowserPanel.Name = "webBrowserPanel";
            webBrowserPanel.Padding = new System.Windows.Forms.Padding(1);
            webBrowserPanel.Size = new System.Drawing.Size(579, 609);
            webBrowserPanel.TabIndex = 0;
            // 
            // printButton
            // 
            printButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            printButton.Location = new System.Drawing.Point(445, 662);
            printButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            printButton.Name = "printButton";
            printButton.Size = new System.Drawing.Size(100, 35);
            printButton.TabIndex = 5;
            printButton.Text = "&Print...";
            printButton.UseVisualStyleBackColor = true;
            printButton.Click += printButton_Click;
            // 
            // editButton
            // 
            editButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            editButton.Location = new System.Drawing.Point(121, 662);
            editButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new System.Drawing.Size(100, 35);
            editButton.TabIndex = 2;
            editButton.Text = "&Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // HtmlDocEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(607, 711);
            Controls.Add(editButton);
            Controls.Add(printButton);
            Controls.Add(webBrowserPanel);
            Controls.Add(titleLabel);
            Controls.Add(titleTextBox);
            Controls.Add(saveButton);
            Controls.Add(openButton);
            Controls.Add(newButton);
            Name = "HtmlDocEditForm";
            ShowIcon = false;
            Text = "HtmlDocEdit - RedJ HTML Document Editor";
            webBrowserPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel webBrowserPanel;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button editButton;
    }
}