using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RedJ_Code
{
    internal partial class HtmlDocEditForm : Form
    {
        private static readonly string NewDocument = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"></head><body></body></html>";

        public HtmlDocEditForm()
        {
            InitializeComponent();

            NewFile();
        }

        private void LoadHTML(string html)
        {
            webBrowser.DocumentText = HtmlExtensions.InsertXUACompatible(html);
        }

        private void NewFile()
        {
            LoadHTML(NewDocument);
        }

        private void EditFile()
        {
            webBrowser.Document.InvokeScript("eval", new object[] { "document.designMode='on';" });
        }

        private void OpenFile()
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadHTML(File.ReadAllText(openFileDialog.FileName));
            }
        }

        private void SaveFile()
        {
            webBrowser.ShowSaveAsDialog();
        }

        private void PrintFile()
        {
            webBrowser.ShowPrintDialog();
        }

        private void SetDocumentTitle()
        {
            if (webBrowser.Document != null)
            {
                webBrowser.Document.Title = titleTextBox.Text;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditFile();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintFile();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            SetDocumentTitle();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            titleTextBox.Text = webBrowser.DocumentTitle;
        }
    }

    internal static class HtmlExtensions
    {
        public static string InsertXUACompatible(string html)
        {
            if (Regex.IsMatch(html, @"<\s*meta\s+http-equiv\s*=\s*(""|')x-ua-compatible(""|')\s*content\s*=\s*(""|')ie=.+(""|')\s*(/)?\s*>", RegexOptions.IgnoreCase))
            {
                return html;
            }

            Match head = Regex.Match(html, @"<\s*head.*>", RegexOptions.IgnoreCase);

            if (head.Success)
            {
                return html.Insert(head.Index + head.Length, "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            }

            return html;
        }
    }
}
