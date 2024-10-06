using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class FileExplorerForm : Form
    {
        private const string MYCOMPUTER = "shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";

        public FileExplorerForm()
        {
            InitializeComponent();

            browser.Navigate(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        }

        public void AdjustLeft()
        {
            Screen screen = Screen.FromControl(this);
            Rectangle area = screen.WorkingArea;

            int offset = 20;

            int posX = area.Left + offset;
            int posY = area.Top + offset;

            int lenW = area.Width / 5;
            int lenH = area.Height - (offset * 2);

            Location = new Point(posX, posY);
            Size = new Size(lenW, lenH);
        }

        private void Navigate(string? path)
        {
            browser.Navigate(string.IsNullOrWhiteSpace(path) ? MYCOMPUTER : path);
        }

        private void browser_Navigated(object? sender, WebBrowserNavigatedEventArgs e)
        {
            pathTextBox.Text = browser.Url.LocalPath;
        }

        private void browser_CanGoBackChanged(object? sender, EventArgs e)
        {
            goBackButton.Enabled = browser.CanGoBack;
        }

        private void browser_CanGoForwardChanged(object? sender, EventArgs e)
        {
            goForwardButton.Enabled = browser.CanGoForward;
        }

        private void pathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(pathTextBox.Text);
            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            browser.GoBack();
        }

        private void goForwardButton_Click(object sender, EventArgs e)
        {
            browser.GoForward();
        }

        private void goUpButton_Click(object sender, EventArgs e)
        {
            Navigate(Path.GetDirectoryName(pathTextBox.Text));
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.InitialDirectory = pathTextBox.Text;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                Navigate(folderBrowserDialog.SelectedPath);
            }
        }
    }
}
