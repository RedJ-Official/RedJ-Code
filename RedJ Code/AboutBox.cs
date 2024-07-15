using System.Windows.Forms;

namespace RedJ_Code
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.StartProcess(StringTable.WebsiteURL, shellExec:true);
        }
    }
}
