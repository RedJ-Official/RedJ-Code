using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    public partial class ExportDialog : Form
    {
        public FastColoredTextBox FCTB { get; set; }
        public Encoding Encoding { get; set; }

        public ExportDialog(FastColoredTextBox fctb)
        {
            InitializeComponent();

            FCTB = fctb;
            Encoding = Encoding.UTF8;

            selectionRadioButton.Enabled = !FCTB.Selection.IsEmpty;
        }

        private FastColoredTextBoxNS.Range GetRange()
        {
            if (rangeRadioButton.Checked)
            {
                return FCTB.Range;
            }
            else
            {
                return FCTB.Selection;
            }
        }

        private void ExportHTML()
        {
            if (saveHtmlFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            ExportToHTML exporter = new()
            {
                IncludeLineNumbers = includeLineNumbersCheckBox.Checked,
                UseBr = !usePreTagCheckBox.Checked,
                UseNbsp = !usePreTagCheckBox.Checked,
                UseForwardNbsp = !usePreTagCheckBox.Checked,
                UseStyleTag = useStyleTagCheckBox.Checked,
                UseOriginalFont = useOriginalFontCheckBox.Checked
            };

            string html = exporter.GetHtml(GetRange());

            if (usePreTagCheckBox.Checked)
            {
                html = $"<pre>{html}</pre>";
            }

            File.WriteAllText(saveHtmlFileDialog.FileName, html, Encoding);

            Close();
        }

        private void ExportRTF()
        {
            if (saveRtfFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            ExportToRTF exporter = new()
            {
                IncludeLineNumbers = includeLineNumbersCheckBox.Checked,
                UseOriginalFont = useOriginalFontCheckBox.Checked
            };

            string rtf = exporter.GetRtf(GetRange());

            File.WriteAllText(saveRtfFileDialog.FileName, rtf, Encoding);

            Close();
        }

        private void htmlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            usePreTagCheckBox.Visible = useStyleTagCheckBox.Visible = htmlRadioButton.Checked;
        }

        private void usePreTagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (usePreTagCheckBox.Checked)
            {
                useStyleTagCheckBox.Checked = false;
                useStyleTagCheckBox.Enabled = false;
            }
            else
            {
                useStyleTagCheckBox.Enabled = true;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (htmlRadioButton.Checked)
            {
                ExportHTML();
            }
            else if (rtfRadioButton.Checked)
            {
                ExportRTF();
            }
            else
            {
                MessageBox.Show(this, Text, "Select export type.");
            }
        }

        private void ExportDialog_Load(object sender, EventArgs e)
        {
            string iniPath = StaticINI.GetCurrentPathToINI();
            (StaticINI.ReadBoolean(iniPath, "Export", "RTF", false) ? rtfRadioButton : htmlRadioButton).Checked = true;
            includeLineNumbersCheckBox.Checked = StaticINI.ReadBoolean(iniPath, "Export", "IncludeLineNumbers", false);
            useOriginalFontCheckBox.Checked = StaticINI.ReadBoolean(iniPath, "Export", "UseOriginalFont", true);
            usePreTagCheckBox.Checked = StaticINI.ReadBoolean(iniPath, "Export", "UsePreTag", false);
            useStyleTagCheckBox.Checked = StaticINI.ReadBoolean(iniPath, "Export", "UseStyleTag", true);
        }

        private void ExportDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                string iniPath = StaticINI.GetCurrentPathToINI();
                StaticINI.WriteBoolean(iniPath, "Export", "RTF", rtfRadioButton.Checked);
                StaticINI.WriteBoolean(iniPath, "Export", "IncludeLineNumbers", includeLineNumbersCheckBox.Checked);
                StaticINI.WriteBoolean(iniPath, "Export", "UseOriginalFont", useOriginalFontCheckBox.Checked);
                StaticINI.WriteBoolean(iniPath, "Export", "UsePreTag", usePreTagCheckBox.Checked);
                StaticINI.WriteBoolean(iniPath, "Export", "UseStyleTag", useStyleTagCheckBox.Checked);
            }
        }
    }
}