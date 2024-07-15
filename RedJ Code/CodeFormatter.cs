using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedJ_Code
{
    internal static class CodeFormatter
    {
        public static string FormatJSON(string json)
        {
            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented);
        }
    }
}
