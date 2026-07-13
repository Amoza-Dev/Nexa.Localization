using Microsoft.CodeAnalysis;
using Nexa.Localization.SourceGenerator.Diagnostics;
using Nexa.Localization.SourceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nexa.Localization.SourceGenerator.Validation;

internal static class DuplicateKeyValidator
{
    public static void Validate(
        SourceProductionContext context,
        IReadOnlyList<JsonFile> files)
    {
        foreach (var culture in files.GroupBy(f => f.Culture, StringComparer.OrdinalIgnoreCase))
        {
            var keyMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var file in culture)
            {
                foreach (var key in file.Values.Keys)
                {
                    if (keyMap.TryGetValue(key, out var existingFile))
                    {
                        if (!string.Equals(existingFile, file.Path, StringComparison.OrdinalIgnoreCase))
                        {
                            DuplicateKeyDiagnostic.Report(
                                context,
                                Location.None,
                                key,
                                existingFile,
                                file.Path);
                        }
                    }
                    else
                    {
                        keyMap.Add(key, file.Path);
                    }
                }
            }
        }
    }
}