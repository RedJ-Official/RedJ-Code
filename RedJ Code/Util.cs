using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
                "cs"                    => Language.CSharp,
                "vb" or "vba" or "vbs"  => Language.VB,
                "html" or "htm"         => Language.HTML,
                "xml" or "xls" or "svg" or "svgz" or "csproj" or "vbproj" or "vcxproj" or "resx" or "tt" => Language.XML,
                "sql"                   => Language.SQLServer,
                "php" or "inc"          => Language.PHP,
                "js" or "jsx" or "ts" or "tsx" => Language.JS,
                "lua"                   => Language.Lua,
                "json"                  => Language.JSON,
                "bat" or "cmd"          => Language.Batch,
                "java"                  => Language.Java,
                "py"                    => Language.Python,
                "txt" or "text" or "log" or "ascii" => Language.PlainText,
                _                       => Language.Custom
            };
        }

        public static int GetFilterIndexFromLangauge(Language language)
        {
            return language switch
            {
                Language.PlainText => 1,
                Language.CSharp => 2,
                Language.Batch  => 3,
                Language.HTML   => 4,
                Language.Java   => 5,
                Language.JS     => 6,
                Language.JSON   => 7,
                Language.Lua    => 8,
                Language.PHP    => 9,
                Language.Python => 10,
                Language.SQLServer or 
                Language.MySQL  => 11,
                Language.VB     => 12,
                Language.XML    => 13,
                _ => 14
            };
        }

        public static Font GenerateFont(string familyName, int sizeInPt, bool bold, bool italic, bool underline, bool strikeout)
        {
            FontStyle      style  = FontStyle.Regular;
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

        public static void SelectFileName(this TextBox textBox)
        {
            textBox.Select(0, textBox.TextLength - Path.GetExtension(textBox.Text).Length);
        }

        public static bool HasBOM(this Encoding encoding)
        {
            return encoding.GetPreamble().Length > 0;
        }

        public static string ToString2(this Encoding encoding)
        {
            string s = encoding.CodePage switch
            {
                20127 =>  "ASCII",      // ASCII
                28591 =>  "Latin1",     // Latin1 (ISO-8859-1)
                65000 =>  "UTF-7",      // UTF-7
                65001 =>  "UTF-8",      // UTF-8
                1200  =>  "UTF-16 LE",  // UTF-16 LE
                1201  =>  "UTF-16 BE",  // UTF-16 BE
                12000 =>  "UTF-32 LE",  // UTF-32 LE
                12001 =>  "UTF-32 BE",  // UTF-32 BE
                                        // Unknown
                _     => $"Unknown (CodePage={encoding.CodePage})"
            };
            if (encoding.HasBOM())
            {
                s += " with BOM";
            }
            
            return s;
        }

        public static string GetFileSizeString(long fileSize)
        {
            long kib = 1024;
            long mib = 1048576;
            long gib = 1073741824;

                 if (fileSize > gib * 10) return $"{fileSize} B ({fileSize / gib} GiB)";
            else if (fileSize > mib * 10) return $"{fileSize} B ({fileSize / mib} MiB)";
            else if (fileSize > kib * 10) return $"{fileSize} B ({fileSize / kib} KiB)";
            else                          return $"{fileSize} B";
        }

        public static string GetFileAttributesString(FileAttributes attributes)
        {
            string attribString = string.Empty;

            if (attributes.HasFlag(FileAttributes.ReadOnly)) attribString           += "R";
            if (attributes.HasFlag(FileAttributes.Hidden)) attribString             += "H";
            if (attributes.HasFlag(FileAttributes.System)) attribString             += "S";
            if (attributes.HasFlag(FileAttributes.Directory)) attribString          += "D";
            if (attributes.HasFlag(FileAttributes.Archive)) attribString            += "A";
            if (attributes.HasFlag(FileAttributes.Device)) attribString             += "";
            if (attributes.HasFlag(FileAttributes.Temporary)) attribString          += "T";
            if (attributes.HasFlag(FileAttributes.SparseFile)) attribString         += "P";
            if (attributes.HasFlag(FileAttributes.ReparsePoint)) attribString       += "L";
            if (attributes.HasFlag(FileAttributes.Offline)) attribString            += "O";
            if (attributes.HasFlag(FileAttributes.NotContentIndexed)) attribString  += "I";
            if (attributes.HasFlag(FileAttributes.Encrypted)) attribString          += "E";
            if (attributes.HasFlag(FileAttributes.IntegrityStream)) attribString    += "V";
            if (attributes.HasFlag(FileAttributes.NoScrubData)) attribString        += "X";

            return attribString;
        }

        public static string GetHash(byte[] data, HashAlgorithm algorithm)
        {
            byte[] hash = algorithm.ComputeHash(data);
            string hashStr = BitConverter.ToString(hash);
            return hashStr.Replace("-", "").ToLowerInvariant();
        }

        public static FileKind GetFileKind(string fileExt)
        {
            return fileExt.TrimStart('.').ToLowerInvariant() switch
            {
                "png" or "gif" or "jpeg" or "jpe" or "jpg" or "jfif" or "jfi" or "jif" or "tiff" or "tif" or "bmp" or "dib" or "wmf" or "emf" or "ico" => FileKind.Image,
                "exe" or "com" or "dll" or "rll" or "msi" => FileKind.Executable,
                "wav" or "wave" or "wma" or "mpeg" or "mpg" or "mp3" or "midi" or "mid" or "rmi" or "aac" or "flac" or "m4a" or "mka" or "avi" or "mp4" or "mp4v" or "m4v" or "mkv" or "mod" or "wmv" or "mov" => FileKind.Media,
                _ => FileKind.Unknown
            };
        }
    }

    internal enum FileKind
    {
        Unknown = 0,
        Text    = 1,
        Image   = 2,
        Executable = 3,
        Media   = 4,
    }
}

#if false

public static class DEFAULTS
{
    // System
    public static readonly IntPtr           DEFAULT_IntPtr          = IntPtr.Zero;
    public static readonly UIntPtr          DEFAULT_UIntPtr         = UIntPtr.Zero;
    public static readonly Decimal          DEFAULT_Decimal         = Decimal.Zero;
    public static readonly String           DEFAULT_String          = String.Empty;
    public static readonly TimeSpan         DEFAULT_TimeSpan        = TimeSpan.Zero;
    public static readonly DateTime         DEFAULT_DateTime        = DateTime.UnixEpoch;
    public static readonly DateTimeOffset   DEFAULT_DateTimeOffset  = DateTimeOffset.UnixEpoch;
    public static readonly DateOnly         DEFAULT_DateOnly        = DateOnly.FromDateTime(DEFAULT_DateTime);
    public static readonly TimeOnly         DEFAULT_TimeOnly        = TimeOnly.FromDateTime(DEFAULT_DateTime);
    public static readonly TimeZoneInfo     DEFAULT_TimeZoneInfo    = TimeZoneInfo.Utc;
    public static readonly EventArgs        DEFAULT_EventArgs       = EventArgs.Empty;
    public static readonly DBNull           DEFAULT_DBNull          = DBNull.Value;
    // System.Drawing
    public static readonly Point            DEFAULT_Point           = Point.Empty;
    public static readonly PointF           DEFAULT_PointF          = PointF.Empty;
    public static readonly Size             DEFAULT_Size            = Size.Empty;
    public static readonly SizeF            DEFAULT_SizeF           = SizeF.Empty;
    public static readonly Rectangle        DEFAULT_Rectangle       = Rectangle.Empty;
    public static readonly RectangleF       DEFAULT_RectangleF      = RectangleF.Empty;
    public static readonly Color            DEFAULT_Color           = Color.Transparent;
    public static readonly Brush            DEFAULT_Brush           = Brushes.Transparent;
    public static readonly Pen              DEFAULT_Pen             = Pens.Transparent;
    public static readonly Font             DEFAULT_Font            = Control.DefaultFont;
    // System.IO
    public static readonly Stream           DEFAULT_Stream          = Stream.Null;
    public static readonly StreamReader     DEFAULT_StreamReader    = StreamReader.Null;
    public static readonly StreamWriter     DEFAULT_StreamWriter    = StreamWriter.Null;
    public static readonly FileMode         DEFAULT_FileMode        = FileMode.CreateNew;
    public static readonly FileAccess       DEFAULT_FileAccess      = FileAccess.Read;
    public static readonly FileShare        DEFAULT_FileShare       = FileShare.None;
    public static readonly FileAttributes   DEFAULT_FileAttributes  = FileAttributes.Normal;
    // System.Text
    public static readonly Encoding         DEFAULT_Encoding        = Encoding.Default;
    // System.Windows.Forms
    public static readonly Padding          DEFAULT_Padding         = Padding.Empty;
    public static readonly Keys             DEFAULT_Keys            = Keys.None;
}

#endif