namespace RedJ_Code
{
    partial class PropertiesDialog
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
            iconPictureBox = new System.Windows.Forms.PictureBox();
            fileNameTextBox = new System.Windows.Forms.TextBox();
            tabControl = new System.Windows.Forms.TabControl();
            generalTab = new System.Windows.Forms.TabPage();
            changeEncodingButton = new System.Windows.Forms.Button();
            encodingTextBox = new System.Windows.Forms.TextBox();
            encodingLabel = new System.Windows.Forms.Label();
            hr3 = new System.Windows.Forms.Label();
            attributesTextBox = new System.Windows.Forms.TextBox();
            attributesLabel = new System.Windows.Forms.Label();
            lengthTextBox = new System.Windows.Forms.TextBox();
            lengthLabel = new System.Windows.Forms.Label();
            hr2 = new System.Windows.Forms.Label();
            lastAccessTimeTextBox = new System.Windows.Forms.TextBox();
            lastWriteTimeTextBox = new System.Windows.Forms.TextBox();
            creationTimeTextBox = new System.Windows.Forms.TextBox();
            creationTimeLabel = new System.Windows.Forms.Label();
            lastWriteTimeLabel = new System.Windows.Forms.Label();
            lastAccessTimeLabel = new System.Windows.Forms.Label();
            hr1 = new System.Windows.Forms.Label();
            hashTab = new System.Windows.Forms.TabPage();
            md5TextBox = new System.Windows.Forms.TextBox();
            md5Label = new System.Windows.Forms.Label();
            sha512TextBox = new System.Windows.Forms.TextBox();
            sha512Label = new System.Windows.Forms.Label();
            sha384TextBox = new System.Windows.Forms.TextBox();
            sha384Label = new System.Windows.Forms.Label();
            sha256TextBox = new System.Windows.Forms.TextBox();
            sha256Label = new System.Windows.Forms.Label();
            sha1TextBox = new System.Windows.Forms.TextBox();
            sha1Label = new System.Windows.Forms.Label();
            okButton = new System.Windows.Forms.Button();
            toolTip = new System.Windows.Forms.ToolTip(components);
            cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            tabControl.SuspendLayout();
            generalTab.SuspendLayout();
            hashTab.SuspendLayout();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.Location = new System.Drawing.Point(6, 6);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(64, 64);
            iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fileNameTextBox.Location = new System.Drawing.Point(76, 26);
            fileNameTextBox.MaxLength = 255;
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new System.Drawing.Size(245, 23);
            fileNameTextBox.TabIndex = 0;
            fileNameTextBox.Click += nameTextBox_Click;
            fileNameTextBox.Enter += nameTextBox_Enter;
            fileNameTextBox.KeyPress += fileNameTextBox_KeyPress;
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(generalTab);
            tabControl.Controls.Add(hashTab);
            tabControl.Location = new System.Drawing.Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(335, 313);
            tabControl.TabIndex = 0;
            // 
            // generalTab
            // 
            generalTab.Controls.Add(changeEncodingButton);
            generalTab.Controls.Add(encodingTextBox);
            generalTab.Controls.Add(encodingLabel);
            generalTab.Controls.Add(hr3);
            generalTab.Controls.Add(attributesTextBox);
            generalTab.Controls.Add(attributesLabel);
            generalTab.Controls.Add(lengthTextBox);
            generalTab.Controls.Add(lengthLabel);
            generalTab.Controls.Add(hr2);
            generalTab.Controls.Add(lastAccessTimeTextBox);
            generalTab.Controls.Add(lastWriteTimeTextBox);
            generalTab.Controls.Add(creationTimeTextBox);
            generalTab.Controls.Add(creationTimeLabel);
            generalTab.Controls.Add(lastWriteTimeLabel);
            generalTab.Controls.Add(lastAccessTimeLabel);
            generalTab.Controls.Add(hr1);
            generalTab.Controls.Add(iconPictureBox);
            generalTab.Controls.Add(fileNameTextBox);
            generalTab.Location = new System.Drawing.Point(4, 24);
            generalTab.Name = "generalTab";
            generalTab.Padding = new System.Windows.Forms.Padding(3);
            generalTab.Size = new System.Drawing.Size(327, 285);
            generalTab.TabIndex = 0;
            generalTab.Text = "General";
            generalTab.UseVisualStyleBackColor = true;
            // 
            // changeEncodingButton
            // 
            changeEncodingButton.Location = new System.Drawing.Point(111, 256);
            changeEncodingButton.Name = "changeEncodingButton";
            changeEncodingButton.Size = new System.Drawing.Size(87, 23);
            changeEncodingButton.TabIndex = 16;
            changeEncodingButton.Text = "Chang&e...";
            changeEncodingButton.UseVisualStyleBackColor = true;
            changeEncodingButton.Click += changeEncodingButton_Click;
            // 
            // encodingTextBox
            // 
            encodingTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            encodingTextBox.BackColor = System.Drawing.Color.White;
            encodingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            encodingTextBox.Location = new System.Drawing.Point(111, 234);
            encodingTextBox.Name = "encodingTextBox";
            encodingTextBox.ReadOnly = true;
            encodingTextBox.Size = new System.Drawing.Size(210, 16);
            encodingTextBox.TabIndex = 15;
            // 
            // encodingLabel
            // 
            encodingLabel.AutoSize = true;
            encodingLabel.Location = new System.Drawing.Point(6, 235);
            encodingLabel.Name = "encodingLabel";
            encodingLabel.Size = new System.Drawing.Size(60, 15);
            encodingLabel.TabIndex = 14;
            encodingLabel.Text = "Encoding:";
            // 
            // hr3
            // 
            hr3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hr3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            hr3.Location = new System.Drawing.Point(6, 222);
            hr3.Name = "hr3";
            hr3.Size = new System.Drawing.Size(315, 2);
            hr3.TabIndex = 13;
            // 
            // attributesTextBox
            // 
            attributesTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            attributesTextBox.BackColor = System.Drawing.Color.White;
            attributesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            attributesTextBox.Location = new System.Drawing.Point(111, 198);
            attributesTextBox.Name = "attributesTextBox";
            attributesTextBox.ReadOnly = true;
            attributesTextBox.Size = new System.Drawing.Size(210, 16);
            attributesTextBox.TabIndex = 12;
            // 
            // attributesLabel
            // 
            attributesLabel.AutoSize = true;
            attributesLabel.Location = new System.Drawing.Point(6, 198);
            attributesLabel.Name = "attributesLabel";
            attributesLabel.Size = new System.Drawing.Size(83, 15);
            attributesLabel.TabIndex = 11;
            attributesLabel.Text = "File Attributes:";
            // 
            // lengthTextBox
            // 
            lengthTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lengthTextBox.BackColor = System.Drawing.Color.White;
            lengthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lengthTextBox.Location = new System.Drawing.Point(111, 169);
            lengthTextBox.Name = "lengthTextBox";
            lengthTextBox.ReadOnly = true;
            lengthTextBox.Size = new System.Drawing.Size(210, 16);
            lengthTextBox.TabIndex = 10;
            // 
            // lengthLabel
            // 
            lengthLabel.AutoSize = true;
            lengthLabel.Location = new System.Drawing.Point(6, 169);
            lengthLabel.Name = "lengthLabel";
            lengthLabel.Size = new System.Drawing.Size(51, 15);
            lengthLabel.TabIndex = 9;
            lengthLabel.Text = "File Size:";
            // 
            // hr2
            // 
            hr2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hr2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            hr2.Location = new System.Drawing.Point(6, 162);
            hr2.Name = "hr2";
            hr2.Size = new System.Drawing.Size(315, 2);
            hr2.TabIndex = 8;
            // 
            // lastAccessTimeTextBox
            // 
            lastAccessTimeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lastAccessTimeTextBox.BackColor = System.Drawing.Color.White;
            lastAccessTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lastAccessTimeTextBox.Location = new System.Drawing.Point(111, 138);
            lastAccessTimeTextBox.Name = "lastAccessTimeTextBox";
            lastAccessTimeTextBox.ReadOnly = true;
            lastAccessTimeTextBox.Size = new System.Drawing.Size(210, 16);
            lastAccessTimeTextBox.TabIndex = 7;
            // 
            // lastWriteTimeTextBox
            // 
            lastWriteTimeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lastWriteTimeTextBox.BackColor = System.Drawing.Color.White;
            lastWriteTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lastWriteTimeTextBox.Location = new System.Drawing.Point(111, 109);
            lastWriteTimeTextBox.Name = "lastWriteTimeTextBox";
            lastWriteTimeTextBox.ReadOnly = true;
            lastWriteTimeTextBox.Size = new System.Drawing.Size(210, 16);
            lastWriteTimeTextBox.TabIndex = 5;
            // 
            // creationTimeTextBox
            // 
            creationTimeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            creationTimeTextBox.BackColor = System.Drawing.Color.White;
            creationTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            creationTimeTextBox.Location = new System.Drawing.Point(111, 80);
            creationTimeTextBox.Name = "creationTimeTextBox";
            creationTimeTextBox.ReadOnly = true;
            creationTimeTextBox.Size = new System.Drawing.Size(210, 16);
            creationTimeTextBox.TabIndex = 3;
            // 
            // creationTimeLabel
            // 
            creationTimeLabel.AutoSize = true;
            creationTimeLabel.Location = new System.Drawing.Point(6, 80);
            creationTimeLabel.Name = "creationTimeLabel";
            creationTimeLabel.Size = new System.Drawing.Size(51, 15);
            creationTimeLabel.TabIndex = 2;
            creationTimeLabel.Text = "Created:";
            // 
            // lastWriteTimeLabel
            // 
            lastWriteTimeLabel.AutoSize = true;
            lastWriteTimeLabel.Location = new System.Drawing.Point(6, 109);
            lastWriteTimeLabel.Name = "lastWriteTimeLabel";
            lastWriteTimeLabel.Size = new System.Drawing.Size(82, 15);
            lastWriteTimeLabel.TabIndex = 4;
            lastWriteTimeLabel.Text = "Last Modified:";
            // 
            // lastAccessTimeLabel
            // 
            lastAccessTimeLabel.AutoSize = true;
            lastAccessTimeLabel.Location = new System.Drawing.Point(6, 138);
            lastAccessTimeLabel.Name = "lastAccessTimeLabel";
            lastAccessTimeLabel.Size = new System.Drawing.Size(83, 15);
            lastAccessTimeLabel.TabIndex = 6;
            lastAccessTimeLabel.Text = "Last Accessed:";
            // 
            // hr1
            // 
            hr1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            hr1.Location = new System.Drawing.Point(6, 73);
            hr1.Name = "hr1";
            hr1.Size = new System.Drawing.Size(315, 2);
            hr1.TabIndex = 1;
            // 
            // hashTab
            // 
            hashTab.Controls.Add(md5TextBox);
            hashTab.Controls.Add(md5Label);
            hashTab.Controls.Add(sha512TextBox);
            hashTab.Controls.Add(sha512Label);
            hashTab.Controls.Add(sha384TextBox);
            hashTab.Controls.Add(sha384Label);
            hashTab.Controls.Add(sha256TextBox);
            hashTab.Controls.Add(sha256Label);
            hashTab.Controls.Add(sha1TextBox);
            hashTab.Controls.Add(sha1Label);
            hashTab.Location = new System.Drawing.Point(4, 24);
            hashTab.Name = "hashTab";
            hashTab.Padding = new System.Windows.Forms.Padding(3);
            hashTab.Size = new System.Drawing.Size(327, 417);
            hashTab.TabIndex = 1;
            hashTab.Text = "Hashes";
            hashTab.UseVisualStyleBackColor = true;
            hashTab.Enter += hashTab_Enter;
            // 
            // md5TextBox
            // 
            md5TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            md5TextBox.BackColor = System.Drawing.Color.White;
            md5TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            md5TextBox.Location = new System.Drawing.Point(63, 122);
            md5TextBox.Name = "md5TextBox";
            md5TextBox.ReadOnly = true;
            md5TextBox.Size = new System.Drawing.Size(258, 16);
            md5TextBox.TabIndex = 9;
            // 
            // md5Label
            // 
            md5Label.AutoSize = true;
            md5Label.Location = new System.Drawing.Point(6, 122);
            md5Label.Name = "md5Label";
            md5Label.Size = new System.Drawing.Size(35, 15);
            md5Label.TabIndex = 8;
            md5Label.Text = "MD5:";
            // 
            // sha512TextBox
            // 
            sha512TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sha512TextBox.BackColor = System.Drawing.Color.White;
            sha512TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sha512TextBox.Location = new System.Drawing.Point(63, 93);
            sha512TextBox.Name = "sha512TextBox";
            sha512TextBox.ReadOnly = true;
            sha512TextBox.Size = new System.Drawing.Size(258, 16);
            sha512TextBox.TabIndex = 7;
            // 
            // sha512Label
            // 
            sha512Label.AutoSize = true;
            sha512Label.Location = new System.Drawing.Point(6, 93);
            sha512Label.Name = "sha512Label";
            sha512Label.Size = new System.Drawing.Size(51, 15);
            sha512Label.TabIndex = 6;
            sha512Label.Text = "SHA512:";
            // 
            // sha384TextBox
            // 
            sha384TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sha384TextBox.BackColor = System.Drawing.Color.White;
            sha384TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sha384TextBox.Location = new System.Drawing.Point(63, 64);
            sha384TextBox.Name = "sha384TextBox";
            sha384TextBox.ReadOnly = true;
            sha384TextBox.Size = new System.Drawing.Size(258, 16);
            sha384TextBox.TabIndex = 5;
            // 
            // sha384Label
            // 
            sha384Label.AutoSize = true;
            sha384Label.Location = new System.Drawing.Point(6, 64);
            sha384Label.Name = "sha384Label";
            sha384Label.Size = new System.Drawing.Size(51, 15);
            sha384Label.TabIndex = 4;
            sha384Label.Text = "SHA384:";
            // 
            // sha256TextBox
            // 
            sha256TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sha256TextBox.BackColor = System.Drawing.Color.White;
            sha256TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sha256TextBox.Location = new System.Drawing.Point(63, 35);
            sha256TextBox.Name = "sha256TextBox";
            sha256TextBox.ReadOnly = true;
            sha256TextBox.Size = new System.Drawing.Size(258, 16);
            sha256TextBox.TabIndex = 3;
            // 
            // sha256Label
            // 
            sha256Label.AutoSize = true;
            sha256Label.Location = new System.Drawing.Point(6, 35);
            sha256Label.Name = "sha256Label";
            sha256Label.Size = new System.Drawing.Size(51, 15);
            sha256Label.TabIndex = 2;
            sha256Label.Text = "SHA256:";
            // 
            // sha1TextBox
            // 
            sha1TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sha1TextBox.BackColor = System.Drawing.Color.White;
            sha1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sha1TextBox.Location = new System.Drawing.Point(63, 6);
            sha1TextBox.Name = "sha1TextBox";
            sha1TextBox.ReadOnly = true;
            sha1TextBox.Size = new System.Drawing.Size(258, 16);
            sha1TextBox.TabIndex = 1;
            // 
            // sha1Label
            // 
            sha1Label.AutoSize = true;
            sha1Label.Location = new System.Drawing.Point(6, 6);
            sha1Label.Name = "sha1Label";
            sha1Label.Size = new System.Drawing.Size(39, 15);
            sha1Label.TabIndex = 0;
            sha1Label.Text = "SHA1:";
            // 
            // okButton
            // 
            okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Location = new System.Drawing.Point(191, 331);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            toolTip.IsBalloon = true;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(272, 331);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // PropertiesDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(359, 366);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(tabControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PropertiesDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            tabControl.ResumeLayout(false);
            generalTab.ResumeLayout(false);
            generalTab.PerformLayout();
            hashTab.ResumeLayout(false);
            hashTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.TabPage hashTab;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label hr1;
        private System.Windows.Forms.Label creationTimeLabel;
        private System.Windows.Forms.Label lastWriteTimeLabel;
        private System.Windows.Forms.Label lastAccessTimeLabel;
        private System.Windows.Forms.TextBox lastAccessTimeTextBox;
        private System.Windows.Forms.TextBox lastWriteTimeTextBox;
        private System.Windows.Forms.TextBox creationTimeTextBox;
        private System.Windows.Forms.Label hr2;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TextBox attributesTextBox;
        private System.Windows.Forms.Label attributesLabel;
        private System.Windows.Forms.TextBox encodingTextBox;
        private System.Windows.Forms.Label encodingLabel;
        private System.Windows.Forms.Label hr3;
        private System.Windows.Forms.Button changeEncodingButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox sha256TextBox;
        private System.Windows.Forms.Label sha256Label;
        private System.Windows.Forms.TextBox sha1TextBox;
        private System.Windows.Forms.Label sha1Label;
        private System.Windows.Forms.TextBox sha512TextBox;
        private System.Windows.Forms.Label sha512Label;
        private System.Windows.Forms.TextBox sha384TextBox;
        private System.Windows.Forms.Label sha384Label;
        private System.Windows.Forms.TextBox md5TextBox;
        private System.Windows.Forms.Label md5Label;
    }
}