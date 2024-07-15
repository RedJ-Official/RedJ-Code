using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace RedJ_Code
{
    internal class Settings
    {
        public string FilePath { get; }

        public Settings(string settingsFilePath)
        {
            FilePath = settingsFilePath;
        }

        public static string GetSettingsFilePath(string applicationFilePath)
        {
            return Path.ChangeExtension(applicationFilePath, "ini");
        }

        public string ReadString(string section, string key, string defaultValue)
        {
            StringBuilder retVal = new StringBuilder(255);
            _ = GetPrivateProfileString(section, key, defaultValue, retVal, retVal.Capacity, FilePath);
            return retVal.ToString();
        }

        public bool ReadBool(string section, string key, bool defaultValue)
        {
            return bool.TryParse(ReadString(section, key, string.Empty), out bool result) ? result : defaultValue;
        }

        public int ReadInt(string section, string key, int defaultValue)
        {
            return int.TryParse(ReadString(section, key, string.Empty), out int result) ? result : defaultValue;
        }

        public void WriteString(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, FilePath);
        }

        public void WriteBool(string section, string key, bool value)
        {
            WriteString(section, key, value.ToString());
        }

        public void WriteInt(string section, string key, int value)
        {
            WriteString(section, key, value.ToString());
        }

        public bool Exists(string section, string key)
        {
            return ReadString(section, key, null!) != null;
        }

        public void Delete(string section, string key)
        {
            WriteString(section, key, null!);
        }

        public void DeleteSection(string section)
        {
            WriteString(section, null!, null!);
        }
        
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    }
}
