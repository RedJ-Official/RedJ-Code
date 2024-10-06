using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class PropertiesDialog : Form
    {
        private static char[] illegelChars = new char[] { '"', '<', '>', '|', ':', '*', '?', '\\', '/' };

        private bool selectTb = true;

        public string FilePath { get; private set; }
        public Encoding FileEncoding { get; private set; }

        public string NewFilePath => Path.Combine(Path.GetDirectoryName(FilePath), fileNameTextBox.Text);

        private EncodingSelectionDialog encodingSelectionDialog;

        public PropertiesDialog(string path, Encoding encoding)
        {
            InitializeComponent();

            encodingSelectionDialog = new EncodingSelectionDialog(encoding);

            FilePath = path;
            FileEncoding = encoding;

            LoadFileInfo();
            LoadEncodingInfo();
        }

        private void LoadFileInfo()
        {
            fileNameTextBox.Text = Path.GetFileName(FilePath);
            Text = $"Properties of {fileNameTextBox.Text}";

            FileInfo info = new FileInfo(FilePath);

            creationTimeTextBox.Text = info.CreationTime.ToString();
            lastWriteTimeTextBox.Text = info.LastWriteTime.ToString();
            lastAccessTimeTextBox.Text = info.LastAccessTime.ToString();

            lengthTextBox.Text = Util.GetFileSizeString(info.Length);
            attributesTextBox.Text = Util.GetFileAttributesString(info.Attributes);

            iconPictureBox.Image = Icon.ExtractAssociatedIcon(FilePath)?.ToBitmap();
        }

        private void LoadEncodingInfo()
        {
            encodingTextBox.Text = FileEncoding.ToString2();
        }

        private void changeEncodingButton_Click(object sender, EventArgs e)
        {
            if (encodingSelectionDialog.ShowDialog(this) == DialogResult.OK)
            {
                FileEncoding = encodingSelectionDialog.Encoding;
                LoadEncodingInfo();
            }
        }

        private void fileNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (illegelChars.Contains(e.KeyChar))
            {
                toolTip.Show("Invalid file name character!", this, fileNameTextBox.Bounds.Left, fileNameTextBox.Bounds.Bottom, 2000);
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            fileNameTextBox.SelectFileName();
            selectTb = true;
        }

        private void nameTextBox_Click(object sender, EventArgs e)
        {
            if (selectTb)
            {
                fileNameTextBox.SelectFileName();
                selectTb = false;
            }
        }

        private void hashTab_Enter(object sender, EventArgs e)
        {
            ComputeHashes();
        }

        private void ComputeHashes()
        {
            byte[] data = File.ReadAllBytes(FilePath);
            
            using SHA1 sha1 = SHA1.Create();
            using SHA256 sha256 = SHA256.Create();
            using SHA384 sha384 = SHA384.Create();
            using SHA512 sha512 = SHA512.Create();
            using MD5 md5 = MD5.Create();

            sha1TextBox.Text = Util.GetHash(data, sha1);
            sha256TextBox.Text = Util.GetHash(data, sha256);
            sha384TextBox.Text = Util.GetHash(data, sha384);
            sha512TextBox.Text = Util.GetHash(data, sha512);
            md5TextBox.Text = Util.GetHash(data, md5);
        }
    }
}
