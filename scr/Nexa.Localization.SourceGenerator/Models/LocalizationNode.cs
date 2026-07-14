using System;
using System.Collections.Generic;

namespace Nexa.Localization.SourceGenerator.Models;

public sealed class LocalizationNode
{
    public string Name { get; }

    public LocalizationNode? Parent { get; internal set; }

    public Dictionary<string, LocalizationNode> Children { get; }

    public bool IsLeaf { get; set; }

    public LocalizationNode(string name, LocalizationNode? parent = null)
    {
        Name = name;
        Parent = parent;

        Children = new Dictionary<string, LocalizationNode>(
            StringComparer.OrdinalIgnoreCase);
    }

    public string FullKey
    {
        get
        {
            if (Parent is null)
                return string.Empty;

            var stack = new Stack<string>();

            var current = this;

            while (current.Parent is not null)
            {
                stack.Push(current.Name);
                current = current.Parent;
            }

            return string.Join(".", stack);
        }
    }
}