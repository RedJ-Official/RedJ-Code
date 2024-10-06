using System;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RedJ_Code
{
    internal static class AdvancedStringManipulator
    {
        public static string FormatJSON(string json)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize(JsonDocument.Parse(json), options);
        }

        public static string FormatXML(string xml)
        {
            return XDocument.Parse(xml).ToString();
        }

        public static string EncodeBase64(string str, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        public static string DecodeBase64(string str, Encoding encoding)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return encoding.GetString(bytes);
        }

        public static string EncodeURL(string str)
        {
            return Uri.EscapeDataString(str);
        }

        public static string DecodeURL(string str)
        {
            return Uri.UnescapeDataString(str);
        }

        public static string EncodeRegex(string str)
        {
            return Regex.Escape(str);
        }

        public static string DecodeRegex(string str)
        {
            return Regex.Unescape(str);
        }
    }
}
