namespace RedJ_Code
{
    partial class FileExplorerForm
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
            components = new System.ComponentModel.Container();
            browser = new System.Windows.Forms.WebBrowser();
            navMenuPanel = new System.Windows.Forms.Panel();
            pathTextBox = new System.Windows.Forms.TextBox();
            goForwardButton = new System.Windows.Forms.Button();
            goBackButton = new System.Windows.Forms.Button();
            goUpButton = new System.Windows.Forms.Button();
            browseButton = new System.Windows.Forms.Button();
            toolTip = new System.Windows.Forms.ToolTip(components);
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            navMenuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // browser
            // 
            browser.Dock = System.Windows.Forms.DockStyle.Fill;
            browser.Location = new System.Drawing.Point(0, 23);
            browser.Name = "browser";
            browser.Size = new System.Drawing.Size(285, 495);
            browser.TabIndex = 0;
            browser.CanGoBackChanged += browser_CanGoBackChanged;
            browser.CanGoForwardChanged += browser_CanGoForwardChanged;
            browser.Navigated += browser_Navigated;
            // 
            // navMenuPanel
            // 
            navMenuPanel.Controls.Add(pathTextBox);
            navMenuPanel.Controls.Add(goForwardButton);
            navMenuPanel.Controls.Add(goBackButton);
            navMenuPanel.Controls.Add(goUpButton);
            navMenuPanel.Controls.Add(browseButton);
            navMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            navMenuPanel.Location = new System.Drawing.Point(0, 0);
            navMenuPanel.Name = "navMenuPanel";
            navMenuPanel.Size = new System.Drawing.Size(285, 23);
            navMenuPanel.TabIndex = 1;
            // 
            // pathTextBox
            // 
            pathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            pathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            pathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pathTextBox.Location = new System.Drawing.Point(58, 0);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new System.Drawing.Size(169, 23);
            pathTextBox.TabIndex = 2;
            toolTip.SetToolTip(pathTextBox, "Current Directory");
            pathTextBox.KeyDown += pathTextBox_KeyDown;
            // 
            // goForwardButton
            // 
            goForwardButton.Dock = System.Windows.Forms.DockStyle.Left;
            goForwardButton.Enabled = false;
            goForwardButton.Location = new System.Drawing.Point(29, 0);
            goForwardButton.Name = "goForwardButton";
            goForwardButton.Size = new System.Drawing.Size(29, 23);
            goForwardButton.TabIndex = 1;
            goForwardButton.Text = "&>";
            toolTip.SetToolTip(goForwardButton, "Go Forward");
            goForwardButton.UseVisualStyleBackColor = true;
            goForwardButton.Click += goForwardButton_Click;
            // 
            // goBackButton
            // 
            goBackButton.Dock = System.Windows.Forms.DockStyle.Left;
            goBackButton.Enabled = false;
            goBackButton.Location = new System.Drawing.Point(0, 0);
            goBackButton.Name = "goBackButton";
            goBackButton.Size = new System.Drawing.Size(29, 23);
            goBackButton.TabIndex = 0;
            goBackButton.Text = "&<";
            toolTip.SetToolTip(goBackButton, "Go Back");
            goBackButton.UseVisualStyleBackColor = true;
            goBackButton.Click += goBackButton_Click;
            // 
            // goUpButton
            // 
            goUpButton.Dock = System.Windows.Forms.DockStyle.Right;
            goUpButton.Location = new System.Drawing.Point(227, 0);
            goUpButton.Name = "goUpButton";
            goUpButton.Size = new System.Drawing.Size(29, 23);
            goUpButton.TabIndex = 3;
            goUpButton.Text = "&^";
            toolTip.SetToolTip(goUpButton, "Go Up");
            goUpButton.UseVisualStyleBackColor = true;
            goUpButton.Click += goUpButton_Click;
            // 
            // browseButton
            // 
            browseButton.Dock = System.Windows.Forms.DockStyle.Right;
            browseButton.Location = new System.Drawing.Point(256, 0);
            browseButton.Name = "browseButton";
            browseButton.Size = new System.Drawing.Size(29, 23);
            browseButton.TabIndex = 4;
            browseButton.Text = "&...";
            toolTip.SetToolTip(browseButton, "Browse...");
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // folderBrowserDialog
            // 
            folderBrowserDialog.AutoUpgradeEnabled = false;
            // 
            // FileExplorerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(285, 518);
            Controls.Add(browser);
            Controls.Add(navMenuPanel);
            Name = "FileExplorerForm";
            ShowIcon = false;
            Text = "Explorer";
            navMenuPanel.ResumeLayout(false);
            navMenuPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.Panel navMenuPanel;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button goUpButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button goForwardButton;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}