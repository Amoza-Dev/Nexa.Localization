using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexa.Localization.Models
{
    public sealed class LocalizationNode
    {
        public string Name { get; set; } = string.Empty;

        public string? FullKey { get; set; }

        public Dictionary<string, LocalizationNode> Children { get; }
            = new(StringComparer.OrdinalIgnoreCase);

        public bool IsLeaf => FullKey is not null;
    }
}
