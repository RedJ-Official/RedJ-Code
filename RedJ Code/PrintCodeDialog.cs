using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace RedJ_Code
{
    public partial class PrintCodeDialog : Form
    {
        private readonly PrintDialog PrintDialog;
        private readonly PageSetupDialog PageSetupDialog;

        public PrintDocument PrintDocument { get; }

        public bool IncludeLineNumbers => includeLineNumbersCheckBox.Checked;

        public PrintCodeDialog(bool allowSelection)
        {
            InitializeComponent();

            PrintDialog = new PrintDialog()
            {
                Document = PrintDocument,
                UseEXDialog = false,
                AllowSelection = allowSelection
            };
            PageSetupDialog = new PageSetupDialog()
            {
                Document = PrintDocument,
                EnableMetric = true
            };
            PrintDocument = new PrintDocument()
            {
                PrinterSettings = PrintDialog.PrinterSettings,
                DefaultPageSettings = PageSetupDialog.PageSettings
            };
        }

        private void printerSetupButton_Click(object sender, EventArgs e)
        {
            PrintDialog.PrinterSettings = PrintDocument.PrinterSettings;

            if (PrintDialog.ShowDialog(this) == DialogResult.OK)
            {
                PrintDocument.PrinterSettings = PrintDialog.PrinterSettings;
            }
        }

        private void pageSetupButton_Click(object sender, EventArgs e)
        {
            PageSetupDialog.PageSettings = PrintDocument.DefaultPageSettings;

            if (PageSetupDialog.ShowDialog(this) == DialogResult.OK)
            {
                PrintDocument.DefaultPageSettings = PageSetupDialog.PageSettings;
            }
        }

        #region Settings

        private void PrintCodeDialog_Load(object sender, EventArgs e)
        {
            string iniPath = StaticINI.GetCurrentPathToINI();
            includeLineNumbersCheckBox.Checked = StaticINI.ReadBoolean(iniPath, "Print", "IncludeLineNumbers", false);
            PrintDocument.PrinterSettings.Copies = Convert.ToInt16(StaticINI.ReadInt32(iniPath, "PrinterSettings", "Copies", PrintDocument.PrinterSettings.Copies));
            PrintDocument.PrinterSettings.PrintToFile = StaticINI.ReadBoolean(iniPath, "PrinterSettings", "PrintToFile", PrintDocument.PrinterSettings.PrintToFile);
            PrintDocument.DefaultPageSettings.Landscape = StaticINI.ReadBoolean(iniPath, "PageSettings", "Landscape", PrintDocument.DefaultPageSettings.Landscape);
            PrintDocument.DefaultPageSettings.Margins.Bottom = StaticINI.ReadInt32(iniPath, "PageSettings", "Margins_Bottom", PrintDocument.DefaultPageSettings.Margins.Bottom);
            PrintDocument.DefaultPageSettings.Margins.Left = StaticINI.ReadInt32(iniPath, "PageSettings", "Margins_Left", PrintDocument.DefaultPageSettings.Margins.Left);
            PrintDocument.DefaultPageSettings.Margins.Right = StaticINI.ReadInt32(iniPath, "PageSettings", "Margins_Right", PrintDocument.DefaultPageSettings.Margins.Right);
            PrintDocument.DefaultPageSettings.Margins.Top = StaticINI.ReadInt32(iniPath, "PageSettings", "Margins_Top", PrintDocument.DefaultPageSettings.Margins.Top);
            PrintDocument.DefaultPageSettings.PaperSize.RawKind = StaticINI.ReadInt32(iniPath, "PageSettings", "PaperSize_RawKind", PrintDocument.DefaultPageSettings.PaperSize.RawKind);
        }

        private void PrintCodeDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                string iniPath = StaticINI.GetCurrentPathToINI();
                StaticINI.WriteBoolean(iniPath, "Print", "IncludeLineNumbers", includeLineNumbersCheckBox.Checked);
                StaticINI.WriteInt32(iniPath, "PrinterSettings", "Copies", PrintDocument.PrinterSettings.Copies);
                StaticINI.WriteBoolean(iniPath, "PrinterSettings", "PrintToFile", PrintDocument.PrinterSettings.PrintToFile);
                StaticINI.WriteBoolean(iniPath, "PageSettings", "Landscape", PrintDocument.DefaultPageSettings.Landscape);
                StaticINI.WriteInt32(iniPath, "PageSettings", "Margins_Bottom", PrintDocument.DefaultPageSettings.Margins.Bottom);
                StaticINI.WriteInt32(iniPath, "PageSettings", "Margins_Left", PrintDocument.DefaultPageSettings.Margins.Left);
                StaticINI.WriteInt32(iniPath, "PageSettings", "Margins_Right", PrintDocument.DefaultPageSettings.Margins.Right);
                StaticINI.WriteInt32(iniPath, "PageSettings", "Margins_Top", PrintDocument.DefaultPageSettings.Margins.Top);
                StaticINI.WriteInt32(iniPath, "PageSettings", "PaperSize_RawKind", PrintDocument.DefaultPageSettings.PaperSize.RawKind);
            }
        }

        #endregion
    }
}
