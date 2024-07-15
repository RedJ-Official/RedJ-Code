using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    internal static class Util
    {
        public static Language GetLanguageFromFileExtension(string fileExt)
        {
            return fileExt.TrimStart('.').ToLowerInvariant() switch
            {
                "cs" => Language.CSharp,
                "html" or "htm" => Language.HTML,
                "js" or "jsx" => Language.JS,
                "json" => Language.JSON,
                "lua" => Language.Lua,
                "php" or "inc" => Language.PHP,
                "sql" => Language.SQL,
                "vb" or "vba" => Language.VB,
                "xml" or "xsl" or "svg" or "svgz" or "msc" or "xht" or "xhtml" or "csproj" or "vbproj" or "xslt" or "xsd" or "tt" or "vstemplate" => Language.XML,
                _ => Language.PlainText
            };
        }

        public static int GetFilterIndexFromLangauge(Language language)
        {
            return language switch
            {
                Language.PlainText => 1,
                Language.CSharp => 2,
                Language.HTML => 3,
                Language.JS => 4,
                Language.JSON => 5,
                Language.Lua => 6,
                Language.PHP => 7,
                Language.SQL => 8,
                Language.VB => 9,
                Language.XML => 10,
                _ => 11
            };
        }

        public static Font GenerateFont(string familyName, int sizeInPt, bool bold, bool italic, bool underline, bool strikeout)
        {
            FontStyle style = FontStyle.Regular;
            if (bold)      style |= FontStyle.Bold;
            if (italic)    style |= FontStyle.Italic;
            if (underline) style |= FontStyle.Underline;
            if (strikeout) style |= FontStyle.Strikeout;
            return new Font(familyName, sizeInPt, style, GraphicsUnit.Point);
        }

        public static void StartProcess(string file, string args = "", string verb = "", bool shellExec = false, bool noWindow = false, bool waitForExit = false)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName        = file      ,
                Arguments       = args      ,
                UseShellExecute = shellExec ,
                CreateNoWindow  = noWindow  ,
                Verb            = verb
            };

            using Process? proc = Process.Start(startInfo);

            if (waitForExit)
            {
                proc?.WaitForExit();
            }
        }

        public static void ShowControlsList(Form form)
        {
            string msg = new string("");

            foreach (Control control in form.Controls)
            {
                msg += $"{control.Name} | {control.Text} | {control.GetType().Name}{Environment.NewLine}";
            }

            MessageBox.Show(msg);
        }

        public static void MakeAppear(this Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }

            form.BringToFront();
            form.Activate();
        }

        public static string TrimStart(this string s, string trimString)
        {
            while (s.StartsWith(trimString))
            {
                s = s.Remove(0, trimString.Length);
            }

            return s;
        }

        public static string TrimEnd(this string s, string trimString)
        {
            while (s.EndsWith(trimString))
            {
                s = s.Remove(s.Length - trimString.Length);
            }

            return s;
        }

        public static string Trim(this string s, string trimString)
        {
            return s.TrimStart(trimString).TrimEnd(trimString);
        }

        public static void TryLoadRTF(this RichTextBox richTextBox, string rtf)
        {
            try
            {
                richTextBox.Rtf = rtf;
            }
            catch
            {
            }
        }
    }
}
