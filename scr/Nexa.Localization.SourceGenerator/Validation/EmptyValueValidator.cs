using Microsoft.CodeAnalysis;
using Nexa.Localization.SourceGenerator.Diagnostics;
using Nexa.Localization.SourceGenerator.Models;
using System.Collections.Generic;

namespace Nexa.Localization.SourceGenerator.Validation;

internal static class EmptyValueValidator
{
    public static void Validate(
        SourceProductionContext context,
        IReadOnlyList<JsonFile> files)
    {
        foreach (var file in files)
        {
            foreach (var item in file.Values)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    EmptyValueDiagnostic.Report(
                        context,
                        Location.None,
                        item.Key);
                }
            }
        }
    }
}