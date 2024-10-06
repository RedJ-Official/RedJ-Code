#pragma warning disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RedJ_Code
{
    public class INI
    {
        public String FilePath { get; }

        public INI(String iniFile)
        {
            FilePath = iniFile;
        }

        public String ReadString(String section, String key, String defaultValue)
        {
            StringBuilder sb = new StringBuilder(255);
            _ = GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, FilePath);
            return sb.ToString();
        }

        public Int32 ReadInt32(String section, String key, Int32 defaultValue)
        {
            return (Int32)GetPrivateProfileInt(section, key, defaultValue, FilePath);
        }

        public Boolean ReadBoolean(String section, String key, Boolean defaultValue)
        {
            return ReadInt32(section, key, defaultValue ? 1 : 0) != 0;
        }

        public void WriteString(String section, String key, String value)
        {
            _ = WritePrivateProfileString(section, key, value, FilePath);
        }

        public void WriteInt32(String section, String key, Int32 value)
        {
            WriteString(section, key, value.ToString());
        }

        public void WriteBoolean(String section, String key, Boolean value)
        {
            WriteInt32(section, key, value ? 1 : 0);
        }

        public bool KeyExists(String section, String key)
        {
            return ReadString(section, key, null!) != null;
        }

        public void DeleteKey(String section, String key)
        {
            WriteString(section, key, null!);
        }

        public void DeleteSection(String section)
        {
            WriteString(section, null!, null!);
        }

        public String[] GetKeys(String section)
        {
            Byte[] buffer = new Byte[1024];
            _ = GetPrivateProfileSection(section, buffer, buffer.Length, FilePath);
            return Encoding.Default.GetString(buffer).Split('\0');
        }

        public String[] GetSections()
        {
            Byte[] buffer = new Byte[1024];
            _ = GetPrivateProfileSectionNames(buffer, buffer.Length, FilePath);
            return Encoding.Default.GetString(buffer).Split('\0');
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileString(String lpAppName, String lpKeyName, String lpDefault, StringBuilder lpReturnedString, Int32 nSize, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileInt(String lpAppName, String lpKeyName, Int32 nDefault, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileSection(String lpAppName, Byte[] pszReturnBuffer, Int32 nSize, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileSectionNames(Byte[] pszReturnBuffer, Int32 nSize, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern Boolean WritePrivateProfileString(String lpAppName, String lpKeyName, String lpString, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern Boolean WritePrivateProfileSection(String lpAppName, String lpString, String lpFileName);
    }

    public static class StaticINI
    {
        public static String GetCurrentPathToINI()
        {
            return GetPathToINI(Application.ExecutablePath);
        }

        public static String GetPathToINI(String exeFile)
        {
            return Path.ChangeExtension(exeFile, "ini");
        }

        public static String ResloveURL(String urlFile)
        {
            return ReadString(urlFile, "InternetShortcut", "URL", String.Empty);
        }

        public static String ReadString(String file, String section, String key, String defaultValue)
        {
            StringBuilder sb = new StringBuilder(255);
            _ = GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, file);
            return sb.ToString();
        }

        public static Int32 ReadInt32(String file, String section, String key, Int32 defaultValue)
        {
            return (Int32)GetPrivateProfileInt(section, key, defaultValue, file);
        }

        public static Boolean ReadBoolean(String file, String section, String key, Boolean defaultValue)
        {
            return ReadInt32(file, section, key, defaultValue ? 1 : 0) != 0;
        }

        public static void WriteString(String file, String section, String key, String value)
        {
            _ = WritePrivateProfileString(section, key, value, file);
        }

        public static void WriteInt32(String file, String section, String key, Int32 value)
        {
            WriteString(file, section, key, value.ToString());
        }

        public static void WriteBoolean(String file, String section, String key, Boolean value)
        {
            WriteInt32(file, section, key, value ? 1 : 0);
        }

        public static bool KeyExists(String file, String section, String key)
        {
            return ReadString(file, section, key, null) != null;
        }

        public static void DeleteKey(String file, String section, String key)
        {
            WriteString(file, section, key, null);
        }

        public static void DeleteSection(String file, String section)
        {
            WriteString(file, section, null, null);
        }

        public static String[] GetKeys(String file, String section)
        {
            Byte[] buffer = new Byte[1024];
            _ = GetPrivateProfileSection(section, buffer, buffer.Length, file);
            return Encoding.Default.GetString(buffer).Split('\0');
        }

        public static String[] GetSections(String file)
        {
            Byte[] buffer = new Byte[1024];
            _ = GetPrivateProfileSectionNames(buffer, buffer.Length, file);
            return Encoding.Default.GetString(buffer).Split('\0');
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileString(String lpAppName, String lpKeyName, String lpDefault, StringBuilder lpReturnedString, Int32 nSize, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileInt(String lpAppName, String lpKeyName, Int32 nDefault, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileSection(String lpAppName, Byte[] pszReturnBuffer, Int32 nSize, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 GetPrivateProfileSectionNames(Byte[] pszReturnBuffer, Int32 nSize, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern Boolean WritePrivateProfileString(String lpAppName, String lpKeyName, String lpString, String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern Boolean WritePrivateProfileSection(String lpAppName, String lpString, String lpFileName);
    }
}
