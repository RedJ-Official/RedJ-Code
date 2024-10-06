using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class PreferencesDialog : Form
    {
        private Dictionary<Control, string> HelpStrings = new();

        public Preferences Preferences { get; }

        public PreferencesDialog(Preferences preferences)
        {
            InitializeComponent();
            InitHelpStrings();

            Preferences = preferences;
        }

        private void LoadPreferences()
        {
            statusStripCheckBox.Checked = Preferences.StatusStripVisible;
            toolStripCheckBox.Checked = Preferences.ToolStripVisible;

            tabControlMultilineCheckBox.Checked = Preferences.TabControlMultiline;
            tabControlAppearanceComboBox.SelectedIndex = Preferences.TabControlAppearance;
            tabControlSizeModeComboBox.SelectedIndex = Preferences.TabControlSizingMode;

            wordWrapCheckBox.Checked = Preferences.WordWrap;
            wordWrapAutoIndentCheckBox.Checked = Preferences.WordWrapAutoIndent;
            wordWrapModeComboBox.SelectedIndex = Preferences.WordWrapMode;

            showLineNumbersCheckBox.Checked = Preferences.ShowLineNumbers;
            lineNumberColorButton.BackColor = Color.FromArgb(Preferences.LineNumberColor);
            reservedCountOfLineNumberCharsNumericUpDown.Value = Preferences.ReservedCountOfLineNumberChars;
            leftPaddingNumericUpDown.Value = Preferences.LeftPadding;

            bookmarkColorButton.BackColor = Color.FromArgb(Preferences.BookmarkColor);

            showFoldingLinesCheckBox.Checked = Preferences.ShowFoldingLines;
            highlightFoldingIndicatorCheckBox.Checked = Preferences.HighlightFoldingIndicator;
            foldingIndicatorColorButton.BackColor = Color.FromArgb(Preferences.FoldingIndicatorColor);

            highlightCurrentLineCheckBox.Checked = Preferences.HighlightCurrentLine;
            currentLineColorButton.BackColor = Color.FromArgb(Preferences.CurrentLineColor);
            highlightCurrentWordCheckBox.Checked = Preferences.HighlightCurrentWord;

            allowDragDropCheckBox.Checked = Preferences.AllowDragDrop;
            autoIndentCheckBox.Checked = Preferences.AutoIndent;
            autoCompleteBracketsCheckBox.Checked = Preferences.AutoCompleteBrackets;
            virtualSpaceCheckBox.Checked = Preferences.VirtualSpace;

            documentMapVisibleCheckBox.Checked = Preferences.DocumentMapVisible;
            documentMapScrollbarVisibleCheckBox.Checked = Preferences.DocumentMapScrollbarVisible;
            documentMapForeColorButton.BackColor = Color.FromArgb(Preferences.DocumentMapForeColor);
            documentMapWidthNumericUpDown.Value = Preferences.DocumentMapWidth;

            rulerVisibleCheckBox.Checked = Preferences.RulerVisible;

            autocompleteMenuEnabledCheckBox.Checked = Preferences.AutocompleteMenuEnabled;
            autocompleteMenuForeColorButton.BackColor = Color.FromArgb(Preferences.AutocompleteMenuForeColor);
        }

        private void SavePreferences()
        {

        }

        private void ResetPreferences()
        {

        }

        private void InitHelpStrings()
        {
            
        }

        private void PreferencesDialog_Load(object sender, EventArgs e)
        {
            LoadPreferences();
        }

        private void PreferencesDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                SavePreferences();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, StringTable.ResetSettingsMessageBoxText, StringTable.ResetSettingsMessageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ResetPreferences();
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (sender is not Button button)
                return;
            using var colorDialog = new ColorDialog();
            colorDialog.Color = button.BackColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
                button.BackColor = colorDialog.Color;
        }

        private void anyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numUD)
                return;
            numUD.Controls[0].Controls[0].Enabled = numUD.Value != numUD.Maximum;
            numUD.Controls[0].Controls[1].Enabled = numUD.Value != numUD.Minimum;
        }

        private void anyControl_HelpRequested(object sender, HelpEventArgs e)
        {
            if (sender is not Control ctl)
                return;
            if (HelpStrings.ContainsKey(ctl))
                Help.ShowPopup(ctl, HelpStrings[ctl], e.MousePos);
        }
    }
}
