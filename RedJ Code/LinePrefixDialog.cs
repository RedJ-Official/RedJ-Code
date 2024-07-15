using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class LinePrefixDialog : Form
    {
        public string Prefix => prefixTextBox.Text;
        public bool Remove => removeRadioButton.Checked;

        public LinePrefixDialog()
        {
            InitializeComponent();
        }
    }
}
