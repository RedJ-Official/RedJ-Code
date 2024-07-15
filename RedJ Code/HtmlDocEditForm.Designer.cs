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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.newButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.webBrowserPanel = new System.Windows.Forms.Panel();
            this.printButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.webBrowserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(1, 1);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(577, 607);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newButton.Location = new System.Drawing.Point(13, 662);
            this.newButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(100, 35);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "&New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openButton.Location = new System.Drawing.Point(229, 662);
            this.openButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(100, 35);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "&Open...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(337, 662);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 35);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "&Save As...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(138, 12);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(455, 27);
            this.titleTextBox.TabIndex = 7;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(14, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(118, 20);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Document &Title :";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "HTML Files|*.html;*.htm|Text Files|*.txt|All Files|*";
            this.openFileDialog.Title = "Open File";
            // 
            // webBrowserPanel
            // 
            this.webBrowserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserPanel.BackColor = System.Drawing.Color.Black;
            this.webBrowserPanel.Controls.Add(this.webBrowser);
            this.webBrowserPanel.Location = new System.Drawing.Point(14, 45);
            this.webBrowserPanel.Name = "webBrowserPanel";
            this.webBrowserPanel.Padding = new System.Windows.Forms.Padding(1);
            this.webBrowserPanel.Size = new System.Drawing.Size(579, 609);
            this.webBrowserPanel.TabIndex = 0;
            // 
            // printButton
            // 
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.printButton.Location = new System.Drawing.Point(445, 662);
            this.printButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(100, 35);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "&Print...";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.Location = new System.Drawing.Point(121, 662);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(100, 35);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // HtmlDocEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 711);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.webBrowserPanel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.newButton);
            this.Name = "HtmlDocEditForm";
            this.ShowIcon = false;
            this.Text = "HtmlDocEdit";
            this.webBrowserPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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