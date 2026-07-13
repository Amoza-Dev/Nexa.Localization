using Microsoft.CodeAnalysis;
using Nexa.Localization.SourceGenerator.Diagnostics;
using Nexa.Localization.SourceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nexa.Localization.SourceGenerator.Validation;

internal static class MissingKeyValidator
{
    public static void Validate(
        SourceProductionContext context,
        IReadOnlyList<JsonFile> files)
    {
        var allKeys = files
            .SelectMany(file => file.Values.Keys)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        var cultures = files
            .GroupBy(file => file.Culture, StringComparer.OrdinalIgnoreCase);

        foreach (var culture in cultures)
        {
            var cultureKeys = new HashSet<string>(
                culture.SelectMany(file => file.Values.Keys),
                StringComparer.OrdinalIgnoreCase);

            foreach (var key in allKeys)
            {
                if (!cultureKeys.Contains(key))
                {
                    MissingKeyDiagnostic.Report(
                        context,
                        Location.None,
                        key);
                }
            }
        }
    }
}