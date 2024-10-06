using System;
using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class GuidMakeForm : Form
    {
        private bool selectTb = true;

        public GuidMakeForm()
        {
            InitializeComponent();
        }

        private void newGuidButton_Click(object sender, EventArgs e)
        {
            guidTextBox.Text = Guid.NewGuid().ToString();

            if (upperCaseCheckBox.Checked)
            {
                guidTextBox.Text = guidTextBox.Text.ToUpperInvariant();
            }

            if (addBracketsCheckBox.Checked)
            {
                guidTextBox.Text = $"{{{guidTextBox.Text}}}";
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(guidTextBox.Text))
            {
                Clipboard.SetText(guidTextBox.Text);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void upperCaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (upperCaseCheckBox.Checked)
            {
                guidTextBox.Text = guidTextBox.Text.ToUpperInvariant();
            }
            else
            {
                guidTextBox.Text = guidTextBox.Text.ToLowerInvariant();
            }
        }

        private void addBracketsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (addBracketsCheckBox.Checked)
            {
                guidTextBox.Text = $"{{{guidTextBox.Text}}}";
            }
            else
            {
                guidTextBox.Text = guidTextBox.Text.TrimStart('{').TrimEnd('}');
            }
        }

        private void guidTextBox_Enter(object sender, EventArgs e)
        {
            guidTextBox.SelectAll();
            selectTb = true;
        }

        private void guidTextBox_Click(object sender, EventArgs e)
        {
            if (selectTb)
            {
                guidTextBox.SelectAll();
                selectTb = false;
            }
        }

        private void GuidMakeForm_Load(object sender, EventArgs e)
        {
            string iniPath = StaticINI.GetCurrentPathToINI();
            upperCaseCheckBox.Checked = StaticINI.ReadBoolean(iniPath, "GUID", "ToUpper", false);
            addBracketsCheckBox.Checked = StaticINI.ReadBoolean(iniPath, "GUID", "AddBrackets", false);
        }

        private void GuidMakeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string iniPath = StaticINI.GetCurrentPathToINI();
            StaticINI.WriteBoolean(iniPath, "GUID", "ToUpper", upperCaseCheckBox.Checked);
            StaticINI.WriteBoolean(iniPath, "GUID", "AddBrackets", addBracketsCheckBox.Checked);
        }
    }
}
