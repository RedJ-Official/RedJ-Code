namespace RedJ_Code
{
    partial class GuidMakeForm
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
            guidTextBox = new System.Windows.Forms.TextBox();
            newGuidButton = new System.Windows.Forms.Button();
            copyButton = new System.Windows.Forms.Button();
            doneButton = new System.Windows.Forms.Button();
            upperCaseCheckBox = new System.Windows.Forms.CheckBox();
            addBracketsCheckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // guidTextBox
            // 
            guidTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            guidTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            guidTextBox.Location = new System.Drawing.Point(10, 11);
            guidTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            guidTextBox.Name = "guidTextBox";
            guidTextBox.ReadOnly = true;
            guidTextBox.Size = new System.Drawing.Size(275, 22);
            guidTextBox.TabIndex = 5;
            guidTextBox.Click += guidTextBox_Click;
            guidTextBox.Enter += guidTextBox_Enter;
            // 
            // newGuidButton
            // 
            newGuidButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            newGuidButton.Location = new System.Drawing.Point(291, 11);
            newGuidButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            newGuidButton.Name = "newGuidButton";
            newGuidButton.Size = new System.Drawing.Size(75, 23);
            newGuidButton.TabIndex = 0;
            newGuidButton.Text = "&Generate";
            newGuidButton.UseVisualStyleBackColor = true;
            newGuidButton.Click += newGuidButton_Click;
            // 
            // copyButton
            // 
            copyButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            copyButton.Location = new System.Drawing.Point(291, 38);
            copyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            copyButton.Name = "copyButton";
            copyButton.Size = new System.Drawing.Size(75, 23);
            copyButton.TabIndex = 1;
            copyButton.Text = "&Copy";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // doneButton
            // 
            doneButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            doneButton.Location = new System.Drawing.Point(291, 65);
            doneButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            doneButton.Name = "doneButton";
            doneButton.Size = new System.Drawing.Size(75, 23);
            doneButton.TabIndex = 2;
            doneButton.Text = "&Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // upperCaseCheckBox
            // 
            upperCaseCheckBox.AutoSize = true;
            upperCaseCheckBox.Location = new System.Drawing.Point(10, 37);
            upperCaseCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            upperCaseCheckBox.Name = "upperCaseCheckBox";
            upperCaseCheckBox.Size = new System.Drawing.Size(86, 19);
            upperCaseCheckBox.TabIndex = 3;
            upperCaseCheckBox.Text = "&Upper Case";
            upperCaseCheckBox.UseVisualStyleBackColor = true;
            upperCaseCheckBox.CheckedChanged += upperCaseCheckBox_CheckedChanged;
            // 
            // addBracketsCheckBox
            // 
            addBracketsCheckBox.AutoSize = true;
            addBracketsCheckBox.Location = new System.Drawing.Point(10, 60);
            addBracketsCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            addBracketsCheckBox.Name = "addBracketsCheckBox";
            addBracketsCheckBox.Size = new System.Drawing.Size(95, 19);
            addBracketsCheckBox.TabIndex = 4;
            addBracketsCheckBox.Text = "&Add Brackets";
            addBracketsCheckBox.UseVisualStyleBackColor = true;
            addBracketsCheckBox.CheckedChanged += addBracketsCheckBox_CheckedChanged;
            // 
            // GuidMakeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = doneButton;
            ClientSize = new System.Drawing.Size(378, 99);
            Controls.Add(addBracketsCheckBox);
            Controls.Add(upperCaseCheckBox);
            Controls.Add(doneButton);
            Controls.Add(copyButton);
            Controls.Add(newGuidButton);
            Controls.Add(guidTextBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "GuidMakeForm";
            ShowIcon = false;
            Text = "MakeGuid - GUID Generator";
            FormClosed += GuidMakeForm_FormClosed;
            Load += GuidMakeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox guidTextBox;
        private System.Windows.Forms.Button newGuidButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.CheckBox upperCaseCheckBox;
        private System.Windows.Forms.CheckBox addBracketsCheckBox;
    }
}