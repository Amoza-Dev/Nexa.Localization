using System;
using System.Collections.Generic;
using System.Text;

namespace Nexa.Localization.SourceGenerator.Models
{
    public sealed class LocalizationTree
    {
        public LocalizationNode Root { get; }

        public LocalizationTree()
        {
            Root = new LocalizationNode("Root");
        }
    }
}
