namespace RedJ_Code
{
    partial class PreferencesDialog
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
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            preferencesPanel = new System.Windows.Forms.Panel();
            tabControlGroupBox = new System.Windows.Forms.GroupBox();
            tabControlSizeModeComboBox = new System.Windows.Forms.ComboBox();
            tabControlSizeModeLabel = new System.Windows.Forms.Label();
            tabControlAppearanceComboBox = new System.Windows.Forms.ComboBox();
            tabControlAppearanceLabel = new System.Windows.Forms.Label();
            tabControlMultilineCheckBox = new System.Windows.Forms.CheckBox();
            uiElementsGroupBox = new System.Windows.Forms.GroupBox();
            statusStripCheckBox = new System.Windows.Forms.CheckBox();
            toolStripCheckBox = new System.Windows.Forms.CheckBox();
            documentMapGroupBox = new System.Windows.Forms.GroupBox();
            documentMapWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            documentMapWidthLabel = new System.Windows.Forms.Label();
            documentMapForeColorButton = new System.Windows.Forms.Button();
            documentMapForeColorLabel = new System.Windows.Forms.Label();
            documentMapScrollbarVisibleCheckBox = new System.Windows.Forms.CheckBox();
            documentMapVisibleCheckBox = new System.Windows.Forms.CheckBox();
            rulerGroupBox = new System.Windows.Forms.GroupBox();
            rulerVisibleCheckBox = new System.Windows.Forms.CheckBox();
            autocompleteMenuGroupBox = new System.Windows.Forms.GroupBox();
            autocompleteMenuForeColorButton = new System.Windows.Forms.Button();
            autocompleteMenuForeColorLabel = new System.Windows.Forms.Label();
            autocompleteMenuEnabledCheckBox = new System.Windows.Forms.CheckBox();
            featuresGroupBox = new System.Windows.Forms.GroupBox();
            virtualSpaceCheckBox = new System.Windows.Forms.CheckBox();
            autoCompleteBracketsCheckBox = new System.Windows.Forms.CheckBox();
            autoIndentCheckBox = new System.Windows.Forms.CheckBox();
            allowDragDropCheckBox = new System.Windows.Forms.CheckBox();
            highlightingGroupBox = new System.Windows.Forms.GroupBox();
            highlightCurrentWordCheckBox = new System.Windows.Forms.CheckBox();
            currentLineColorLabel = new System.Windows.Forms.Label();
            currentLineColorButton = new System.Windows.Forms.Button();
            highlightCurrentLineCheckBox = new System.Windows.Forms.CheckBox();
            boomarksGroupBox = new System.Windows.Forms.GroupBox();
            bookmarkColorLabel = new System.Windows.Forms.Label();
            bookmarkColorButton = new System.Windows.Forms.Button();
            foldingBlockGroupBox = new System.Windows.Forms.GroupBox();
            foldingIndicatorColorLabel = new System.Windows.Forms.Label();
            foldingIndicatorColorButton = new System.Windows.Forms.Button();
            highlightFoldingIndicatorCheckBox = new System.Windows.Forms.CheckBox();
            showFoldingLinesCheckBox = new System.Windows.Forms.CheckBox();
            lineNumbersGroupBox = new System.Windows.Forms.GroupBox();
            leftPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            leftPaddingLabel = new System.Windows.Forms.Label();
            reservedCountOfLineNumberCharsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            reservedCountOfLineNumberCharsLabel = new System.Windows.Forms.Label();
            lineNumberColorLabel = new System.Windows.Forms.Label();
            lineNumberColorButton = new System.Windows.Forms.Button();
            showLineNumbersCheckBox = new System.Windows.Forms.CheckBox();
            wordWrapGoupBox = new System.Windows.Forms.GroupBox();
            wordWrapModeComboBox = new System.Windows.Forms.ComboBox();
            wordWrapModeLabel = new System.Windows.Forms.Label();
            wordWrapAutoIndentCheckBox = new System.Windows.Forms.CheckBox();
            wordWrapCheckBox = new System.Windows.Forms.CheckBox();
            resetButton = new System.Windows.Forms.Button();
            preferencesPanel.SuspendLayout();
            tabControlGroupBox.SuspendLayout();
            uiElementsGroupBox.SuspendLayout();
            documentMapGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)documentMapWidthNumericUpDown).BeginInit();
            rulerGroupBox.SuspendLayout();
            autocompleteMenuGroupBox.SuspendLayout();
            featuresGroupBox.SuspendLayout();
            highlightingGroupBox.SuspendLayout();
            boomarksGroupBox.SuspendLayout();
            foldingBlockGroupBox.SuspendLayout();
            lineNumbersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leftPaddingNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reservedCountOfLineNumberCharsNumericUpDown).BeginInit();
            wordWrapGoupBox.SuspendLayout();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Location = new System.Drawing.Point(632, 415);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(713, 415);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // preferencesPanel
            // 
            preferencesPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            preferencesPanel.AutoScroll = true;
            preferencesPanel.Controls.Add(tabControlGroupBox);
            preferencesPanel.Controls.Add(uiElementsGroupBox);
            preferencesPanel.Controls.Add(documentMapGroupBox);
            preferencesPanel.Controls.Add(rulerGroupBox);
            preferencesPanel.Controls.Add(autocompleteMenuGroupBox);
            preferencesPanel.Controls.Add(featuresGroupBox);
            preferencesPanel.Controls.Add(highlightingGroupBox);
            preferencesPanel.Controls.Add(boomarksGroupBox);
            preferencesPanel.Controls.Add(foldingBlockGroupBox);
            preferencesPanel.Controls.Add(lineNumbersGroupBox);
            preferencesPanel.Controls.Add(wordWrapGoupBox);
            preferencesPanel.Location = new System.Drawing.Point(12, 9);
            preferencesPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            preferencesPanel.Name = "preferencesPanel";
            preferencesPanel.Size = new System.Drawing.Size(776, 400);
            preferencesPanel.TabIndex = 0;
            // 
            // tabControlGroupBox
            // 
            tabControlGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControlGroupBox.Controls.Add(tabControlSizeModeComboBox);
            tabControlGroupBox.Controls.Add(tabControlSizeModeLabel);
            tabControlGroupBox.Controls.Add(tabControlAppearanceComboBox);
            tabControlGroupBox.Controls.Add(tabControlAppearanceLabel);
            tabControlGroupBox.Controls.Add(tabControlMultilineCheckBox);
            tabControlGroupBox.Location = new System.Drawing.Point(3, 81);
            tabControlGroupBox.Name = "tabControlGroupBox";
            tabControlGroupBox.Size = new System.Drawing.Size(753, 105);
            tabControlGroupBox.TabIndex = 11;
            tabControlGroupBox.TabStop = false;
            tabControlGroupBox.Text = "Tab Control";
            // 
            // tabControlSizeModeComboBox
            // 
            tabControlSizeModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            tabControlSizeModeComboBox.FormattingEnabled = true;
            tabControlSizeModeComboBox.Items.AddRange(new object[] { "Default", "Stretch", "Fixed" });
            tabControlSizeModeComboBox.Location = new System.Drawing.Point(258, 76);
            tabControlSizeModeComboBox.Name = "tabControlSizeModeComboBox";
            tabControlSizeModeComboBox.Size = new System.Drawing.Size(121, 23);
            tabControlSizeModeComboBox.TabIndex = 4;
            // 
            // tabControlSizeModeLabel
            // 
            tabControlSizeModeLabel.AutoSize = true;
            tabControlSizeModeLabel.Location = new System.Drawing.Point(6, 79);
            tabControlSizeModeLabel.Name = "tabControlSizeModeLabel";
            tabControlSizeModeLabel.Size = new System.Drawing.Size(64, 15);
            tabControlSizeModeLabel.TabIndex = 3;
            tabControlSizeModeLabel.Text = "Size Mode:";
            // 
            // tabControlAppearanceComboBox
            // 
            tabControlAppearanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            tabControlAppearanceComboBox.FormattingEnabled = true;
            tabControlAppearanceComboBox.Items.AddRange(new object[] { "Default", "Button", "Flat" });
            tabControlAppearanceComboBox.Location = new System.Drawing.Point(258, 47);
            tabControlAppearanceComboBox.Name = "tabControlAppearanceComboBox";
            tabControlAppearanceComboBox.Size = new System.Drawing.Size(121, 23);
            tabControlAppearanceComboBox.TabIndex = 2;
            // 
            // tabControlAppearanceLabel
            // 
            tabControlAppearanceLabel.AutoSize = true;
            tabControlAppearanceLabel.Location = new System.Drawing.Point(6, 50);
            tabControlAppearanceLabel.Name = "tabControlAppearanceLabel";
            tabControlAppearanceLabel.Size = new System.Drawing.Size(73, 15);
            tabControlAppearanceLabel.TabIndex = 1;
            tabControlAppearanceLabel.Text = "Appearance:";
            // 
            // tabControlMultilineCheckBox
            // 
            tabControlMultilineCheckBox.AutoSize = true;
            tabControlMultilineCheckBox.Location = new System.Drawing.Point(6, 22);
            tabControlMultilineCheckBox.Name = "tabControlMultilineCheckBox";
            tabControlMultilineCheckBox.Size = new System.Drawing.Size(73, 19);
            tabControlMultilineCheckBox.TabIndex = 0;
            tabControlMultilineCheckBox.Text = "Multiline";
            tabControlMultilineCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiElementsGroupBox
            // 
            uiElementsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            uiElementsGroupBox.Controls.Add(statusStripCheckBox);
            uiElementsGroupBox.Controls.Add(toolStripCheckBox);
            uiElementsGroupBox.Location = new System.Drawing.Point(3, 3);
            uiElementsGroupBox.Name = "uiElementsGroupBox";
            uiElementsGroupBox.Size = new System.Drawing.Size(753, 72);
            uiElementsGroupBox.TabIndex = 10;
            uiElementsGroupBox.TabStop = false;
            uiElementsGroupBox.Text = "UI Elements";
            // 
            // statusStripCheckBox
            // 
            statusStripCheckBox.AutoSize = true;
            statusStripCheckBox.Location = new System.Drawing.Point(6, 47);
            statusStripCheckBox.Name = "statusStripCheckBox";
            statusStripCheckBox.Size = new System.Drawing.Size(85, 19);
            statusStripCheckBox.TabIndex = 1;
            statusStripCheckBox.Text = "Status Strip";
            statusStripCheckBox.UseVisualStyleBackColor = true;
            // 
            // toolStripCheckBox
            // 
            toolStripCheckBox.AutoSize = true;
            toolStripCheckBox.Location = new System.Drawing.Point(6, 22);
            toolStripCheckBox.Name = "toolStripCheckBox";
            toolStripCheckBox.Size = new System.Drawing.Size(75, 19);
            toolStripCheckBox.TabIndex = 0;
            toolStripCheckBox.Text = "Tool Strip";
            toolStripCheckBox.UseVisualStyleBackColor = true;
            // 
            // documentMapGroupBox
            // 
            documentMapGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            documentMapGroupBox.Controls.Add(documentMapWidthNumericUpDown);
            documentMapGroupBox.Controls.Add(documentMapWidthLabel);
            documentMapGroupBox.Controls.Add(documentMapForeColorButton);
            documentMapGroupBox.Controls.Add(documentMapForeColorLabel);
            documentMapGroupBox.Controls.Add(documentMapScrollbarVisibleCheckBox);
            documentMapGroupBox.Controls.Add(documentMapVisibleCheckBox);
            documentMapGroupBox.Location = new System.Drawing.Point(3, 838);
            documentMapGroupBox.Name = "documentMapGroupBox";
            documentMapGroupBox.Size = new System.Drawing.Size(753, 128);
            documentMapGroupBox.TabIndex = 9;
            documentMapGroupBox.TabStop = false;
            documentMapGroupBox.Text = "Document Map";
            // 
            // documentMapWidthNumericUpDown
            // 
            documentMapWidthNumericUpDown.Location = new System.Drawing.Point(258, 98);
            documentMapWidthNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            documentMapWidthNumericUpDown.Name = "documentMapWidthNumericUpDown";
            documentMapWidthNumericUpDown.Size = new System.Drawing.Size(121, 23);
            documentMapWidthNumericUpDown.TabIndex = 6;
            // 
            // documentMapWidthLabel
            // 
            documentMapWidthLabel.AutoSize = true;
            documentMapWidthLabel.Location = new System.Drawing.Point(6, 99);
            documentMapWidthLabel.Name = "documentMapWidthLabel";
            documentMapWidthLabel.Size = new System.Drawing.Size(42, 15);
            documentMapWidthLabel.TabIndex = 5;
            documentMapWidthLabel.Text = "Width:";
            // 
            // documentMapForeColorButton
            // 
            documentMapForeColorButton.Location = new System.Drawing.Point(258, 68);
            documentMapForeColorButton.Name = "documentMapForeColorButton";
            documentMapForeColorButton.Size = new System.Drawing.Size(121, 23);
            documentMapForeColorButton.TabIndex = 3;
            documentMapForeColorButton.UseVisualStyleBackColor = true;
            // 
            // documentMapForeColorLabel
            // 
            documentMapForeColorLabel.AutoSize = true;
            documentMapForeColorLabel.Location = new System.Drawing.Point(6, 72);
            documentMapForeColorLabel.Name = "documentMapForeColorLabel";
            documentMapForeColorLabel.Size = new System.Drawing.Size(65, 15);
            documentMapForeColorLabel.TabIndex = 2;
            documentMapForeColorLabel.Text = "Fore Color:";
            // 
            // documentMapScrollbarVisibleCheckBox
            // 
            documentMapScrollbarVisibleCheckBox.AutoSize = true;
            documentMapScrollbarVisibleCheckBox.Location = new System.Drawing.Point(6, 44);
            documentMapScrollbarVisibleCheckBox.Name = "documentMapScrollbarVisibleCheckBox";
            documentMapScrollbarVisibleCheckBox.Size = new System.Drawing.Size(109, 19);
            documentMapScrollbarVisibleCheckBox.TabIndex = 1;
            documentMapScrollbarVisibleCheckBox.Text = "Scrollbar Visible";
            documentMapScrollbarVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // documentMapVisibleCheckBox
            // 
            documentMapVisibleCheckBox.AutoSize = true;
            documentMapVisibleCheckBox.Location = new System.Drawing.Point(6, 19);
            documentMapVisibleCheckBox.Name = "documentMapVisibleCheckBox";
            documentMapVisibleCheckBox.Size = new System.Drawing.Size(60, 19);
            documentMapVisibleCheckBox.TabIndex = 0;
            documentMapVisibleCheckBox.Text = "Visible";
            documentMapVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // rulerGroupBox
            // 
            rulerGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rulerGroupBox.Controls.Add(rulerVisibleCheckBox);
            rulerGroupBox.Location = new System.Drawing.Point(3, 965);
            rulerGroupBox.Name = "rulerGroupBox";
            rulerGroupBox.Size = new System.Drawing.Size(753, 47);
            rulerGroupBox.TabIndex = 7;
            rulerGroupBox.TabStop = false;
            rulerGroupBox.Text = "Ruler";
            // 
            // rulerVisibleCheckBox
            // 
            rulerVisibleCheckBox.AutoSize = true;
            rulerVisibleCheckBox.Location = new System.Drawing.Point(6, 22);
            rulerVisibleCheckBox.Name = "rulerVisibleCheckBox";
            rulerVisibleCheckBox.Size = new System.Drawing.Size(60, 19);
            rulerVisibleCheckBox.TabIndex = 1;
            rulerVisibleCheckBox.Text = "Visible";
            rulerVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // autocompleteMenuGroupBox
            // 
            autocompleteMenuGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            autocompleteMenuGroupBox.Controls.Add(autocompleteMenuForeColorButton);
            autocompleteMenuGroupBox.Controls.Add(autocompleteMenuForeColorLabel);
            autocompleteMenuGroupBox.Controls.Add(autocompleteMenuEnabledCheckBox);
            autocompleteMenuGroupBox.Location = new System.Drawing.Point(3, 1018);
            autocompleteMenuGroupBox.Name = "autocompleteMenuGroupBox";
            autocompleteMenuGroupBox.Size = new System.Drawing.Size(753, 75);
            autocompleteMenuGroupBox.TabIndex = 8;
            autocompleteMenuGroupBox.TabStop = false;
            autocompleteMenuGroupBox.Text = "Autocomplete Menu";
            // 
            // autocompleteMenuForeColorButton
            // 
            autocompleteMenuForeColorButton.Location = new System.Drawing.Point(258, 46);
            autocompleteMenuForeColorButton.Name = "autocompleteMenuForeColorButton";
            autocompleteMenuForeColorButton.Size = new System.Drawing.Size(121, 23);
            autocompleteMenuForeColorButton.TabIndex = 6;
            autocompleteMenuForeColorButton.UseVisualStyleBackColor = true;
            autocompleteMenuForeColorButton.Click += colorButton_Click;
            // 
            // autocompleteMenuForeColorLabel
            // 
            autocompleteMenuForeColorLabel.AutoSize = true;
            autocompleteMenuForeColorLabel.Location = new System.Drawing.Point(6, 50);
            autocompleteMenuForeColorLabel.Name = "autocompleteMenuForeColorLabel";
            autocompleteMenuForeColorLabel.Size = new System.Drawing.Size(65, 15);
            autocompleteMenuForeColorLabel.TabIndex = 5;
            autocompleteMenuForeColorLabel.Text = "Fore Color:";
            // 
            // autocompleteMenuEnabledCheckBox
            // 
            autocompleteMenuEnabledCheckBox.AutoSize = true;
            autocompleteMenuEnabledCheckBox.Location = new System.Drawing.Point(6, 22);
            autocompleteMenuEnabledCheckBox.Name = "autocompleteMenuEnabledCheckBox";
            autocompleteMenuEnabledCheckBox.Size = new System.Drawing.Size(68, 19);
            autocompleteMenuEnabledCheckBox.TabIndex = 4;
            autocompleteMenuEnabledCheckBox.Text = "Enabled";
            autocompleteMenuEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // featuresGroupBox
            // 
            featuresGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            featuresGroupBox.Controls.Add(virtualSpaceCheckBox);
            featuresGroupBox.Controls.Add(autoCompleteBracketsCheckBox);
            featuresGroupBox.Controls.Add(autoIndentCheckBox);
            featuresGroupBox.Controls.Add(allowDragDropCheckBox);
            featuresGroupBox.Location = new System.Drawing.Point(3, 710);
            featuresGroupBox.Name = "featuresGroupBox";
            featuresGroupBox.Size = new System.Drawing.Size(753, 122);
            featuresGroupBox.TabIndex = 5;
            featuresGroupBox.TabStop = false;
            featuresGroupBox.Text = "Features";
            // 
            // virtualSpaceCheckBox
            // 
            virtualSpaceCheckBox.AutoSize = true;
            virtualSpaceCheckBox.Location = new System.Drawing.Point(6, 97);
            virtualSpaceCheckBox.Name = "virtualSpaceCheckBox";
            virtualSpaceCheckBox.Size = new System.Drawing.Size(94, 19);
            virtualSpaceCheckBox.TabIndex = 3;
            virtualSpaceCheckBox.Text = "Virtual Space";
            virtualSpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoCompleteBracketsCheckBox
            // 
            autoCompleteBracketsCheckBox.AutoSize = true;
            autoCompleteBracketsCheckBox.Location = new System.Drawing.Point(6, 72);
            autoCompleteBracketsCheckBox.Name = "autoCompleteBracketsCheckBox";
            autoCompleteBracketsCheckBox.Size = new System.Drawing.Size(154, 19);
            autoCompleteBracketsCheckBox.TabIndex = 2;
            autoCompleteBracketsCheckBox.Text = "Auto Complete Brackets";
            autoCompleteBracketsCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoIndentCheckBox
            // 
            autoIndentCheckBox.AutoSize = true;
            autoIndentCheckBox.Location = new System.Drawing.Point(6, 47);
            autoIndentCheckBox.Name = "autoIndentCheckBox";
            autoIndentCheckBox.Size = new System.Drawing.Size(89, 19);
            autoIndentCheckBox.TabIndex = 1;
            autoIndentCheckBox.Text = "Auto Indent";
            autoIndentCheckBox.UseVisualStyleBackColor = true;
            // 
            // allowDragDropCheckBox
            // 
            allowDragDropCheckBox.AutoSize = true;
            allowDragDropCheckBox.Location = new System.Drawing.Point(6, 22);
            allowDragDropCheckBox.Name = "allowDragDropCheckBox";
            allowDragDropCheckBox.Size = new System.Drawing.Size(113, 19);
            allowDragDropCheckBox.TabIndex = 0;
            allowDragDropCheckBox.Text = "Allow Drag Drop";
            allowDragDropCheckBox.UseVisualStyleBackColor = true;
            // 
            // highlightingGroupBox
            // 
            highlightingGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            highlightingGroupBox.Controls.Add(highlightCurrentWordCheckBox);
            highlightingGroupBox.Controls.Add(currentLineColorLabel);
            highlightingGroupBox.Controls.Add(currentLineColorButton);
            highlightingGroupBox.Controls.Add(highlightCurrentLineCheckBox);
            highlightingGroupBox.Location = new System.Drawing.Point(3, 606);
            highlightingGroupBox.Name = "highlightingGroupBox";
            highlightingGroupBox.Size = new System.Drawing.Size(753, 98);
            highlightingGroupBox.TabIndex = 4;
            highlightingGroupBox.TabStop = false;
            highlightingGroupBox.Text = "Highlighting";
            // 
            // highlightCurrentWordCheckBox
            // 
            highlightCurrentWordCheckBox.AutoSize = true;
            highlightCurrentWordCheckBox.Location = new System.Drawing.Point(6, 76);
            highlightCurrentWordCheckBox.Name = "highlightCurrentWordCheckBox";
            highlightCurrentWordCheckBox.Size = new System.Drawing.Size(151, 19);
            highlightCurrentWordCheckBox.TabIndex = 3;
            highlightCurrentWordCheckBox.Text = "Highlight Current Word";
            highlightCurrentWordCheckBox.UseVisualStyleBackColor = true;
            // 
            // currentLineColorLabel
            // 
            currentLineColorLabel.AutoSize = true;
            currentLineColorLabel.Location = new System.Drawing.Point(6, 51);
            currentLineColorLabel.Name = "currentLineColorLabel";
            currentLineColorLabel.Size = new System.Drawing.Size(107, 15);
            currentLineColorLabel.TabIndex = 1;
            currentLineColorLabel.Text = "Current Line Color:";
            // 
            // currentLineColorButton
            // 
            currentLineColorButton.Location = new System.Drawing.Point(258, 47);
            currentLineColorButton.Name = "currentLineColorButton";
            currentLineColorButton.Size = new System.Drawing.Size(121, 23);
            currentLineColorButton.TabIndex = 2;
            currentLineColorButton.UseVisualStyleBackColor = true;
            // 
            // highlightCurrentLineCheckBox
            // 
            highlightCurrentLineCheckBox.AutoSize = true;
            highlightCurrentLineCheckBox.Location = new System.Drawing.Point(6, 22);
            highlightCurrentLineCheckBox.Name = "highlightCurrentLineCheckBox";
            highlightCurrentLineCheckBox.Size = new System.Drawing.Size(144, 19);
            highlightCurrentLineCheckBox.TabIndex = 0;
            highlightCurrentLineCheckBox.Text = "Highlight Current Line";
            highlightCurrentLineCheckBox.UseVisualStyleBackColor = true;
            // 
            // boomarksGroupBox
            // 
            boomarksGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            boomarksGroupBox.Controls.Add(bookmarkColorLabel);
            boomarksGroupBox.Controls.Add(bookmarkColorButton);
            boomarksGroupBox.Location = new System.Drawing.Point(3, 435);
            boomarksGroupBox.Name = "boomarksGroupBox";
            boomarksGroupBox.Size = new System.Drawing.Size(753, 58);
            boomarksGroupBox.TabIndex = 2;
            boomarksGroupBox.TabStop = false;
            boomarksGroupBox.Text = "Bookmarks";
            // 
            // bookmarkColorLabel
            // 
            bookmarkColorLabel.AutoSize = true;
            bookmarkColorLabel.Location = new System.Drawing.Point(6, 26);
            bookmarkColorLabel.Name = "bookmarkColorLabel";
            bookmarkColorLabel.Size = new System.Drawing.Size(96, 15);
            bookmarkColorLabel.TabIndex = 0;
            bookmarkColorLabel.Text = "Bookmark Color:";
            // 
            // bookmarkColorButton
            // 
            bookmarkColorButton.Location = new System.Drawing.Point(258, 22);
            bookmarkColorButton.Name = "bookmarkColorButton";
            bookmarkColorButton.Size = new System.Drawing.Size(121, 23);
            bookmarkColorButton.TabIndex = 1;
            bookmarkColorButton.UseVisualStyleBackColor = true;
            bookmarkColorButton.Click += colorButton_Click;
            // 
            // foldingBlockGroupBox
            // 
            foldingBlockGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            foldingBlockGroupBox.Controls.Add(foldingIndicatorColorLabel);
            foldingBlockGroupBox.Controls.Add(foldingIndicatorColorButton);
            foldingBlockGroupBox.Controls.Add(highlightFoldingIndicatorCheckBox);
            foldingBlockGroupBox.Controls.Add(showFoldingLinesCheckBox);
            foldingBlockGroupBox.Location = new System.Drawing.Point(3, 499);
            foldingBlockGroupBox.Name = "foldingBlockGroupBox";
            foldingBlockGroupBox.Size = new System.Drawing.Size(753, 101);
            foldingBlockGroupBox.TabIndex = 3;
            foldingBlockGroupBox.TabStop = false;
            foldingBlockGroupBox.Text = "Folding Blocks";
            // 
            // foldingIndicatorColorLabel
            // 
            foldingIndicatorColorLabel.AutoSize = true;
            foldingIndicatorColorLabel.Location = new System.Drawing.Point(6, 76);
            foldingIndicatorColorLabel.Name = "foldingIndicatorColorLabel";
            foldingIndicatorColorLabel.Size = new System.Drawing.Size(132, 15);
            foldingIndicatorColorLabel.TabIndex = 2;
            foldingIndicatorColorLabel.Text = "Folding Indicator Color:";
            // 
            // foldingIndicatorColorButton
            // 
            foldingIndicatorColorButton.Location = new System.Drawing.Point(258, 72);
            foldingIndicatorColorButton.Name = "foldingIndicatorColorButton";
            foldingIndicatorColorButton.Size = new System.Drawing.Size(121, 23);
            foldingIndicatorColorButton.TabIndex = 3;
            foldingIndicatorColorButton.UseVisualStyleBackColor = true;
            foldingIndicatorColorButton.Click += colorButton_Click;
            // 
            // highlightFoldingIndicatorCheckBox
            // 
            highlightFoldingIndicatorCheckBox.AutoSize = true;
            highlightFoldingIndicatorCheckBox.Location = new System.Drawing.Point(6, 47);
            highlightFoldingIndicatorCheckBox.Name = "highlightFoldingIndicatorCheckBox";
            highlightFoldingIndicatorCheckBox.Size = new System.Drawing.Size(169, 19);
            highlightFoldingIndicatorCheckBox.TabIndex = 1;
            highlightFoldingIndicatorCheckBox.Text = "Highlight Folding Indicator";
            highlightFoldingIndicatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // showFoldingLinesCheckBox
            // 
            showFoldingLinesCheckBox.AutoSize = true;
            showFoldingLinesCheckBox.Location = new System.Drawing.Point(6, 22);
            showFoldingLinesCheckBox.Name = "showFoldingLinesCheckBox";
            showFoldingLinesCheckBox.Size = new System.Drawing.Size(128, 19);
            showFoldingLinesCheckBox.TabIndex = 0;
            showFoldingLinesCheckBox.Text = "Show Folding Lines";
            showFoldingLinesCheckBox.UseVisualStyleBackColor = true;
            // 
            // lineNumbersGroupBox
            // 
            lineNumbersGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lineNumbersGroupBox.Controls.Add(leftPaddingNumericUpDown);
            lineNumbersGroupBox.Controls.Add(leftPaddingLabel);
            lineNumbersGroupBox.Controls.Add(reservedCountOfLineNumberCharsNumericUpDown);
            lineNumbersGroupBox.Controls.Add(reservedCountOfLineNumberCharsLabel);
            lineNumbersGroupBox.Controls.Add(lineNumberColorLabel);
            lineNumbersGroupBox.Controls.Add(lineNumberColorButton);
            lineNumbersGroupBox.Controls.Add(showLineNumbersCheckBox);
            lineNumbersGroupBox.Location = new System.Drawing.Point(3, 299);
            lineNumbersGroupBox.Name = "lineNumbersGroupBox";
            lineNumbersGroupBox.Size = new System.Drawing.Size(753, 136);
            lineNumbersGroupBox.TabIndex = 1;
            lineNumbersGroupBox.TabStop = false;
            lineNumbersGroupBox.Text = "Line Numbers";
            // 
            // leftPaddingNumericUpDown
            // 
            leftPaddingNumericUpDown.Location = new System.Drawing.Point(258, 107);
            leftPaddingNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            leftPaddingNumericUpDown.Name = "leftPaddingNumericUpDown";
            leftPaddingNumericUpDown.Size = new System.Drawing.Size(121, 23);
            leftPaddingNumericUpDown.TabIndex = 6;
            leftPaddingNumericUpDown.ValueChanged += anyNumericUpDown_ValueChanged;
            // 
            // leftPaddingLabel
            // 
            leftPaddingLabel.AutoSize = true;
            leftPaddingLabel.Location = new System.Drawing.Point(6, 109);
            leftPaddingLabel.Name = "leftPaddingLabel";
            leftPaddingLabel.Size = new System.Drawing.Size(77, 15);
            leftPaddingLabel.TabIndex = 5;
            leftPaddingLabel.Text = "Left Padding:";
            // 
            // reservedCountOfLineNumberCharsNumericUpDown
            // 
            reservedCountOfLineNumberCharsNumericUpDown.Location = new System.Drawing.Point(258, 78);
            reservedCountOfLineNumberCharsNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            reservedCountOfLineNumberCharsNumericUpDown.Name = "reservedCountOfLineNumberCharsNumericUpDown";
            reservedCountOfLineNumberCharsNumericUpDown.Size = new System.Drawing.Size(121, 23);
            reservedCountOfLineNumberCharsNumericUpDown.TabIndex = 4;
            reservedCountOfLineNumberCharsNumericUpDown.ValueChanged += anyNumericUpDown_ValueChanged;
            // 
            // reservedCountOfLineNumberCharsLabel
            // 
            reservedCountOfLineNumberCharsLabel.AutoSize = true;
            reservedCountOfLineNumberCharsLabel.Location = new System.Drawing.Point(6, 80);
            reservedCountOfLineNumberCharsLabel.Name = "reservedCountOfLineNumberCharsLabel";
            reservedCountOfLineNumberCharsLabel.Size = new System.Drawing.Size(212, 15);
            reservedCountOfLineNumberCharsLabel.TabIndex = 3;
            reservedCountOfLineNumberCharsLabel.Text = "Reserved Count of Line Number Chars:";
            // 
            // lineNumberColorLabel
            // 
            lineNumberColorLabel.AutoSize = true;
            lineNumberColorLabel.Location = new System.Drawing.Point(6, 50);
            lineNumberColorLabel.Name = "lineNumberColorLabel";
            lineNumberColorLabel.Size = new System.Drawing.Size(111, 15);
            lineNumberColorLabel.TabIndex = 1;
            lineNumberColorLabel.Text = "Line Number Color:";
            // 
            // lineNumberColorButton
            // 
            lineNumberColorButton.Location = new System.Drawing.Point(258, 49);
            lineNumberColorButton.Name = "lineNumberColorButton";
            lineNumberColorButton.Size = new System.Drawing.Size(121, 23);
            lineNumberColorButton.TabIndex = 2;
            lineNumberColorButton.UseVisualStyleBackColor = true;
            lineNumberColorButton.Click += colorButton_Click;
            // 
            // showLineNumbersCheckBox
            // 
            showLineNumbersCheckBox.AutoSize = true;
            showLineNumbersCheckBox.Location = new System.Drawing.Point(6, 21);
            showLineNumbersCheckBox.Name = "showLineNumbersCheckBox";
            showLineNumbersCheckBox.Size = new System.Drawing.Size(132, 19);
            showLineNumbersCheckBox.TabIndex = 0;
            showLineNumbersCheckBox.Text = "Show Line Numbers";
            showLineNumbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // wordWrapGoupBox
            // 
            wordWrapGoupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            wordWrapGoupBox.Controls.Add(wordWrapModeComboBox);
            wordWrapGoupBox.Controls.Add(wordWrapModeLabel);
            wordWrapGoupBox.Controls.Add(wordWrapAutoIndentCheckBox);
            wordWrapGoupBox.Controls.Add(wordWrapCheckBox);
            wordWrapGoupBox.Location = new System.Drawing.Point(3, 192);
            wordWrapGoupBox.Name = "wordWrapGoupBox";
            wordWrapGoupBox.Size = new System.Drawing.Size(753, 101);
            wordWrapGoupBox.TabIndex = 0;
            wordWrapGoupBox.TabStop = false;
            wordWrapGoupBox.Text = "Word Wrap";
            // 
            // wordWrapModeComboBox
            // 
            wordWrapModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            wordWrapModeComboBox.FormattingEnabled = true;
            wordWrapModeComboBox.Items.AddRange(new object[] { "Word Wrap", "Char Wrap" });
            wordWrapModeComboBox.Location = new System.Drawing.Point(258, 72);
            wordWrapModeComboBox.Name = "wordWrapModeComboBox";
            wordWrapModeComboBox.Size = new System.Drawing.Size(121, 23);
            wordWrapModeComboBox.TabIndex = 3;
            // 
            // wordWrapModeLabel
            // 
            wordWrapModeLabel.AutoSize = true;
            wordWrapModeLabel.Location = new System.Drawing.Point(6, 75);
            wordWrapModeLabel.Name = "wordWrapModeLabel";
            wordWrapModeLabel.Size = new System.Drawing.Size(104, 15);
            wordWrapModeLabel.TabIndex = 2;
            wordWrapModeLabel.Text = "Word Wrap Mode:";
            // 
            // wordWrapAutoIndentCheckBox
            // 
            wordWrapAutoIndentCheckBox.AutoSize = true;
            wordWrapAutoIndentCheckBox.Location = new System.Drawing.Point(6, 47);
            wordWrapAutoIndentCheckBox.Name = "wordWrapAutoIndentCheckBox";
            wordWrapAutoIndentCheckBox.Size = new System.Drawing.Size(152, 19);
            wordWrapAutoIndentCheckBox.TabIndex = 1;
            wordWrapAutoIndentCheckBox.Text = "Word Wrap Auto Indent";
            wordWrapAutoIndentCheckBox.UseVisualStyleBackColor = true;
            // 
            // wordWrapCheckBox
            // 
            wordWrapCheckBox.AutoSize = true;
            wordWrapCheckBox.Location = new System.Drawing.Point(6, 22);
            wordWrapCheckBox.Name = "wordWrapCheckBox";
            wordWrapCheckBox.Size = new System.Drawing.Size(86, 19);
            wordWrapCheckBox.TabIndex = 0;
            wordWrapCheckBox.Text = "Word Wrap";
            wordWrapCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            resetButton.Location = new System.Drawing.Point(12, 415);
            resetButton.Name = "resetButton";
            resetButton.Size = new System.Drawing.Size(75, 23);
            resetButton.TabIndex = 4;
            resetButton.Text = "&Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // PreferencesDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(preferencesPanel);
            Controls.Add(resetButton);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PreferencesDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "RedJ Code Preferences";
            FormClosed += PreferencesDialog_FormClosed;
            Load += PreferencesDialog_Load;
            preferencesPanel.ResumeLayout(false);
            tabControlGroupBox.ResumeLayout(false);
            tabControlGroupBox.PerformLayout();
            uiElementsGroupBox.ResumeLayout(false);
            uiElementsGroupBox.PerformLayout();
            documentMapGroupBox.ResumeLayout(false);
            documentMapGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)documentMapWidthNumericUpDown).EndInit();
            rulerGroupBox.ResumeLayout(false);
            rulerGroupBox.PerformLayout();
            autocompleteMenuGroupBox.ResumeLayout(false);
            autocompleteMenuGroupBox.PerformLayout();
            featuresGroupBox.ResumeLayout(false);
            featuresGroupBox.PerformLayout();
            highlightingGroupBox.ResumeLayout(false);
            highlightingGroupBox.PerformLayout();
            boomarksGroupBox.ResumeLayout(false);
            boomarksGroupBox.PerformLayout();
            foldingBlockGroupBox.ResumeLayout(false);
            foldingBlockGroupBox.PerformLayout();
            lineNumbersGroupBox.ResumeLayout(false);
            lineNumbersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)leftPaddingNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)reservedCountOfLineNumberCharsNumericUpDown).EndInit();
            wordWrapGoupBox.ResumeLayout(false);
            wordWrapGoupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel preferencesPanel;
        private System.Windows.Forms.Label wordWrapModeLabel;
        private System.Windows.Forms.ComboBox wordWrapModeComboBox;
        private System.Windows.Forms.GroupBox wordWrapGoupBox;
        private System.Windows.Forms.CheckBox wordWrapAutoIndentCheckBox;
        private System.Windows.Forms.CheckBox wordWrapCheckBox;
        private System.Windows.Forms.GroupBox lineNumbersGroupBox;
        private System.Windows.Forms.CheckBox showLineNumbersCheckBox;
        private System.Windows.Forms.Label lineNumberColorLabel;
        private System.Windows.Forms.Button lineNumberColorButton;
        private System.Windows.Forms.NumericUpDown reservedCountOfLineNumberCharsNumericUpDown;
        private System.Windows.Forms.Label reservedCountOfLineNumberCharsLabel;
        private System.Windows.Forms.NumericUpDown leftPaddingNumericUpDown;
        private System.Windows.Forms.Label leftPaddingLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox boomarksGroupBox;
        private System.Windows.Forms.Label bookmarkColorLabel;
        private System.Windows.Forms.Button bookmarkColorButton;
        private System.Windows.Forms.GroupBox foldingBlockGroupBox;
        private System.Windows.Forms.CheckBox showFoldingLinesCheckBox;
        private System.Windows.Forms.CheckBox highlightFoldingIndicatorCheckBox;
        private System.Windows.Forms.Label foldingIndicatorColorLabel;
        private System.Windows.Forms.Button foldingIndicatorColorButton;
        private System.Windows.Forms.GroupBox highlightingGroupBox;
        private System.Windows.Forms.CheckBox highlightCurrentLineCheckBox;
        private System.Windows.Forms.Label currentLineColorLabel;
        private System.Windows.Forms.Button currentLineColorButton;
        private System.Windows.Forms.CheckBox highlightCurrentWordCheckBox;
        private System.Windows.Forms.GroupBox featuresGroupBox;
        private System.Windows.Forms.CheckBox virtualSpaceCheckBox;
        private System.Windows.Forms.CheckBox autoCompleteBracketsCheckBox;
        private System.Windows.Forms.CheckBox autoIndentCheckBox;
        private System.Windows.Forms.CheckBox allowDragDropCheckBox;
        private System.Windows.Forms.GroupBox documentMapGroupBox;
        private System.Windows.Forms.NumericUpDown documentMapWidthNumericUpDown;
        private System.Windows.Forms.Label documentMapWidthLabel;
        private System.Windows.Forms.Button documentMapForeColorButton;
        private System.Windows.Forms.Label documentMapForeColorLabel;
        private System.Windows.Forms.CheckBox documentMapScrollbarVisibleCheckBox;
        private System.Windows.Forms.CheckBox documentMapVisibleCheckBox;
        private System.Windows.Forms.GroupBox rulerGroupBox;
        private System.Windows.Forms.CheckBox rulerVisibleCheckBox;
        private System.Windows.Forms.GroupBox autocompleteMenuGroupBox;
        private System.Windows.Forms.GroupBox uiElementsGroupBox;
        private System.Windows.Forms.CheckBox statusStripCheckBox;
        private System.Windows.Forms.CheckBox toolStripCheckBox;
        private System.Windows.Forms.GroupBox tabControlGroupBox;
        private System.Windows.Forms.ComboBox tabControlSizeModeComboBox;
        private System.Windows.Forms.Label tabControlSizeModeLabel;
        private System.Windows.Forms.ComboBox tabControlAppearanceComboBox;
        private System.Windows.Forms.Label tabControlAppearanceLabel;
        private System.Windows.Forms.CheckBox tabControlMultilineCheckBox;
        private System.Windows.Forms.Button autocompleteMenuForeColorButton;
        private System.Windows.Forms.Label autocompleteMenuForeColorLabel;
        private System.Windows.Forms.CheckBox autocompleteMenuEnabledCheckBox;
    }
}