#pragma warning disable SYSLIB0001

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class EncodingSelectionDialog : Form
    {
        public Encoding Encoding { get; private set; }

        public EncodingSelectionDialog(Encoding encoding)
        {
            InitializeComponent();
            codepageNumericUpDown.Maximum = int.MaxValue;
            SetEncoding(encoding);
        }

        private void SetEncoding(Encoding encoding)
        {
            Encoding = encoding;
            bomCheckBox.Checked = Encoding.HasBOM();
            (Encoding.CodePage switch {
                20127 => asciiRadioButton,   // ASCII
                28591 => latin1RadioButton,  // Latin1 (ISO-8859-1)
                65000 => utf7RadioButton,    // UTF-7
                65001 => utf8RadioButton,    // UTF-8
                1200 => utf16leRadioButton,  // UTF-16 LE
                1201 => utf16beRadioButton,  // UTF-16 BE
                12000 => utf32leRadioButton, // UTF-32 LE
                12001 => utf32beRadioButton, // UTF-32 BE
                _ => otherRadioButton        // Other
            }).Checked = true;
            codepageNumericUpDown.Value = Encoding.CodePage;
        }

        private void GetEncoding()
        {
            bool bom = bomCheckBox.Checked;
            if (asciiRadioButton.Checked) {
                Encoding = Encoding.ASCII;
            } else if (latin1RadioButton.Checked) {
                Encoding = Encoding.Latin1;
            } else if (utf7RadioButton.Checked) {
                Encoding = new UTF7Encoding();
            } else if (utf8RadioButton.Checked) {
                Encoding = new UTF8Encoding(bom);
            } else if (utf16leRadioButton.Checked) {
                Encoding = new UnicodeEncoding(false, bom);
            } else if (utf16beRadioButton.Checked) {
                Encoding = new UnicodeEncoding(true, bom);
            } else if (utf32leRadioButton.Checked) {
                Encoding = new UTF32Encoding(false, bom);
            } else if (utf32beRadioButton.Checked) {
                Encoding = new UTF32Encoding(true, bom);
            } else {
                Encoding = Encoding.GetEncoding((int)codepageNumericUpDown.Value);
            }
            codepageNumericUpDown.Value = Encoding.CodePage;
        }

        private void CheckBOMSupport()
        {
            bomCheckBox.Visible =
                utf8RadioButton.Checked ||
                utf16leRadioButton.Checked ||
                utf16beRadioButton.Checked ||
                utf32leRadioButton.Checked ||
                utf32beRadioButton.Checked ;
        }

        private void anyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            GetEncoding();
            CheckBOMSupport();
        }

        private void otherRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            codepageNumericUpDown.Enabled = otherRadioButton.Checked;
        }

        private void EncodingSelectionDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                GetEncoding();
            }
        }
    }
}
