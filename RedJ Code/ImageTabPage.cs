using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedJ_Code
{
    internal class ImageTabPage : TabPage
    {
        private readonly Panel pictureBoxPanel;
        private readonly PictureBox pictureBox;
        private readonly SaveFileDialog saveFileDialog;

        private string FilePath {  get; }

        public ImageTabPage(string filePath) : base()
        {
            FilePath = filePath;

            pictureBoxPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            pictureBox = new PictureBox()
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                SizeMode = PictureBoxSizeMode.AutoSize,
                ImageLocation = FilePath
            };

            saveFileDialog = new SaveFileDialog()
            {
                Title = "Save Image",
                Filter = "Bitmap|*.bmp;*.dib|PNG|*.png|GIF|*.gif|JPEG|*.jpeg;*.jpe;*.jpg;*.jfif;*.jfi;*.jif|TIFF|*.tiff;*.tif|WMF|*.wmf|EMF|*.emf|Icon|*.ico",
                FileName = FilePath
            };

            pictureBoxPanel.Controls.Add(pictureBox);
            Controls.Add(pictureBoxPanel);
        }

        public void CopyImage()
        {
            Clipboard.SetImage(pictureBox.Image);
        }

        public void CopyFilePath()
        {
            Clipboard.SetText(FilePath);
        }

        public void SaveAs()
        {
            saveFileDialog.FilterIndex = 
                Path.GetExtension(FilePath).ToLowerInvariant().TrimStart('.') switch
                {
                    "bmp" or "dib"                                          => 1, // Bitmap
                    "png"                                                   => 2, // PNG
                    "gif"                                                   => 3, // GIF
                    "jpeg" or "jpe" or "jpg" or "jfif" or "jfi" or "jif"    => 4, // JPEG
                    "tiff" or "tif"                                         => 5, // TIFF
                    "wmf"                                                   => 6, // WMF
                    "emf"                                                   => 7, // EMF
                    "ico"                                                   => 8, // Icon
                    _                                                       => 1  // Other
                };

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox.Image.Save(saveFileDialog.FileName, GetImageFormat(saveFileDialog.FilterIndex));
            }
        }

        private ImageFormat GetImageFormat(int index) =>
            index switch
            {
                1 => ImageFormat.Bmp,
                2 => ImageFormat.Png,
                3 => ImageFormat.Gif,
                4 => ImageFormat.Jpeg,
                5 => ImageFormat.Tiff,
                6 => ImageFormat.Wmf,
                7 => ImageFormat.Emf,
                8 => ImageFormat.Icon,
                _ => throw new ArgumentException(null, nameof(index))
            };
    }
}
