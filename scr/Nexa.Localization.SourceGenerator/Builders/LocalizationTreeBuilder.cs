using Nexa.Localization.SourceGenerator.Models;
using System.Collections.Generic;

namespace Nexa.Localization.SourceGenerator.Builders;

public sealed class LocalizationTreeBuilder
{
    public LocalizationTree Build(IEnumerable<JsonFile> files)
    {
        var tree = new LocalizationTree();

        foreach (var file in files)
        {
            foreach (var key in file.Values.Keys)
            {
                AddKey(tree.Root, key);
            }
        }

        return tree;
    }

    private static void AddKey(
        LocalizationNode root,
        string key)
    {
        var parts = key.Split('.');

        var current = root;

        foreach (var part in parts)
        {
            if (!current.Children.TryGetValue(part, out var child))
            {
                child = new LocalizationNode(part);

                // ⭐⭐⭐ ئەمە هۆکاری کێشەکەت بوو
                child.Parent = current;

                current.Children.Add(part, child);
            }

            current = child;
        }

        current.IsLeaf = true;
    }
}