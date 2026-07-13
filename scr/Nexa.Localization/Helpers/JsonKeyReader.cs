using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nexa.Localization.Helpers
{
    public sealed class JsonKeyReader
    {
        public IReadOnlyList<string> ReadKeys(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            using var stream = File.OpenRead(filePath);
            using var document = JsonDocument.Parse(stream);

            var keys = new List<string>();

            ReadObject(document.RootElement, null, keys);

            return keys;
        }
        private static void ReadObject(
    JsonElement element,
    string? prefix,
    ICollection<string> keys)
        {
            foreach (var property in element.EnumerateObject())
            {
                var currentKey = string.IsNullOrWhiteSpace(prefix)
                    ? property.Name
                    : $"{prefix}.{property.Name}";

                if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    ReadObject(property.Value, currentKey, keys);
                }
                else
                {
                    keys.Add(currentKey);
                }
            }
        }
    }
}
