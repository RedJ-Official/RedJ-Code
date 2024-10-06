using System;
using System.Drawing;
using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class ColorPreferencesDialog : Form
    {
        public Color LineNumberColor
        {
            get => lineNumberColorButton.BackColor;
            set => lineNumberColorButton.BackColor = value;
        }
        public Color BookmarkColor
        {
            get => bookmarkColorButton.BackColor;
            set => bookmarkColorButton.BackColor = value;
        }
        public Color FoldingIndicatorColor
        {
            get => foldingIndicatorColorButton.BackColor;
            set => foldingIndicatorColorButton.BackColor = value;
        }
        public Color CurrentLineColor
        {
            get => currentLineColorButton.BackColor;
            set => currentLineColorButton.BackColor = value;
        }
        public Color SelectionColor
        {
            get => selectionColorButton.BackColor;
            set => selectionColorButton.BackColor = value;
        }
        public Color DocumentMapColor
        {
            get => documentMapColorButton.BackColor;
            set => documentMapColorButton.BackColor = value;
        }
        public Color AutocompleteMenuColor
        {
            get => autocompleteMenuColorButton.BackColor;
            set => autocompleteMenuColorButton.BackColor = value;
        }
        public Color BackgroundColor
        {
            get => backgroundColorButton.BackColor;
            set => backgroundColorButton.BackColor = value;
        }

        public ColorPreferencesDialog()
        {
            InitializeComponent();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (sender is not null and Button button)
            {
                colorDialog.Color = button.BackColor;

                if (colorDialog.ShowDialog(this) == DialogResult.OK)
                {
                    button.BackColor = colorDialog.Color;
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to reset all colors the their default value?", "Reset Color Preferences", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetColors(); 
            }
        }

        private void ResetColors()
        {
            lineNumberColorButton.BackColor = ColorTable.LineNumberColor;
            bookmarkColorButton.BackColor = ColorTable.BookmarkColor;
            foldingIndicatorColorButton.BackColor = ColorTable.FoldingIndicatorColor;
            currentLineColorButton.BackColor = ColorTable.CurrentLineColor;
            selectionColorButton.BackColor = ColorTable.SelectionColor;
            documentMapColorButton.BackColor = ColorTable.DocumentMapForeColor;
            autocompleteMenuColorButton.BackColor = ColorTable.AutocompleteMenuColor;
            backgroundColorButton.BackColor = ColorTable.BackgroundColor;
        }
    }
}
