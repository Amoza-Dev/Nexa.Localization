using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nexa.Localization.Helpers
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static Dictionary<string, string> Read(string json)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json, Options)
                   ?? new Dictionary<string, string>();
        }
    }
}
