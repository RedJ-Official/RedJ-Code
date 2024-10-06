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
    public partial class InsertDateTimeDialog : Form
    {
        public string DateTimeString => (string)formatsListBox.SelectedItem;

        public InsertDateTimeDialog()
        {
            InitializeComponent();
            LoadDateTimeFormats();
        }

        private void LoadDateTimeFormats()
        {
            DateTime dateTime = utcCheckBox.Checked ? DateTime.UtcNow : DateTime.Now;
            formatsListBox.Items.Clear();
            formatsListBox.Items.AddRange(dateTime.GetDateTimeFormats());
            formatsListBox.SelectedIndex = 0;
        }

        private void utcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadDateTimeFormats();
        }

        private void formatsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadDateTimeFormats();
            }
        }

        private void formatsListBox_DoubleClick(object sender, EventArgs e)
        {
            okButton.PerformClick();
        }

        private void InsertDateTimeDialog_Load(object sender, EventArgs e)
        {
            utcCheckBox.Checked = StaticINI.ReadBoolean(StaticINI.GetCurrentPathToINI(), "DateTime", "UTC", false);
        }

        private void InsertDateTimeDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                StaticINI.WriteBoolean(StaticINI.GetCurrentPathToINI(), "DateTime", "UTC", utcCheckBox.Checked);
        }
    }
}
